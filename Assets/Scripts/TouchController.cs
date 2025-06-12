using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField touchField;
    public CameraLook cameraLook;
    public PlayerMovement playerMovement;
    public FixedButton fixedButton;

    void Update()
    {
        cameraLook.lockAxis = touchField.TouchDist;
        playerMovement.Pressed = fixedButton.Pressed;
    }
}
