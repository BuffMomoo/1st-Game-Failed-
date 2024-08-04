using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float iniGameSpeed = 5f;
    public float incGameSpeed= 0.1f;
    public float gameSpeed {get; private set;}

    private Player player;
    private Spawner spawner;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;    
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        NewGame();
    }

    private void NewGame()
    {
        gameSpeed = iniGameSpeed;   
    }

    public void GameOver()

    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }
    private void Update()
    {
        gameSpeed += incGameSpeed * Time.deltaTime;
    }

}
