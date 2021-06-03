using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 1.5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask objectMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isOnObject;
    public bool canJump = false;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnObject = Physics.CheckSphere(groundCheck.position, groundDistance, objectMask);

        if ((controller.isGrounded || isGrounded) && velocity.y < 0)
        {
            velocity.y = -2f;
            velocity.x = 0f;
            velocity.z = 0f;

            canJump = true;
        }

        if ((controller.isGrounded || isOnObject) && velocity.y < 0)
        {
            velocity.y = -2f;
            velocity.x = 0f;
            velocity.z = 0f;

            canJump = true;
        }

        if (speed > 12f)
        {
            speed -= 6f * Time.deltaTime;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && canJump == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            canJump = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
