using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick joyStick; 
    public float speed = 5f;
    private CharacterController controller;
    private Animator animator; // Add this

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Add this
    }
    
    void Update()
    {
        Vector3 Move = transform.right * joyStick.Horizontal + transform.forward * joyStick.Vertical;
        controller.Move(Move * speed * Time.deltaTime);

        // Animation control
        bool isRunning = Move.magnitude > 0.1f;
        animator.SetBool("isRunning", isRunning); // "isRunning" should match your Animator parameter
    }
}
