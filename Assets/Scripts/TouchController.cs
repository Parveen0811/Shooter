using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField touchField;
    public CameraLook cameraLook;
    public PlayerMovement playerMovement;
    public FixedButton fixedButton;
    public FireButton fireButton;

    void Start()
    {
        // Initialize any necessary components or settings here if needed
        touchField = FindFirstObjectByType<FixedTouchField>();
        fixedButton = FindFirstObjectByType<FixedButton>();
        fireButton = FindFirstObjectByType<FireButton>();
    }

    void Update()
    {
        cameraLook.lockAxis = touchField.TouchDist;
        playerMovement.Pressed = fixedButton.Pressed;
        playerMovement.FirePressed = fireButton.Pressed;
    }
}
