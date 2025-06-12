using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public FixedJoystick joystick;
    public float Speed = 5f;
    private CharacterController controller;

    private float Gravity = -9.81f;
    public float GroundDistance = 0.3f;
    public LayerMask layermask;
    Vector3 velocity;
    public float jumpheight = 3f;

    public bool isGround;
    public bool Pressed;
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    
    void Update()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, GroundDistance, layermask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * Speed * Time.deltaTime);


        if (isGround && Pressed)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * Gravity);
            isGround = false;
        }

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
