using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.81f * 2f;
    public float jumpForce = 8f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (character.isGrounded)
        {
            direction = Vector3.zero;

            if (Input.GetButton("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction += Vector3.down * gravity * Time.deltaTime;
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Obstacles"))
        {


        }

    }
}
