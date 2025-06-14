using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public FixedJoystick joystick;
    public float Speed = 5f;
    private CharacterController controller;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float Gravity = -9.81f;
    public float GroundDistance = 0.3f;
    public LayerMask layermask;
    Vector3 velocity;
    public float jumpheight = 3f;

    public bool isGround;
    public bool Pressed;
    public bool FirePressed;
    public float fireRate = 0.5f; // Time in seconds between shots
    private float nextFireTime = 0f;
    
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        joystick = FindFirstObjectByType<FixedJoystick>();

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

        // Set isRunning parameter for animation
        bool isRunning = Move.magnitude > 0.1f;
        animator.SetBool("isRunning", isRunning);


        if (isGround && Pressed)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * Gravity);
            isGround = false;
        }

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (FirePressed && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    
    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
