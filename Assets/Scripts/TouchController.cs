using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField touchField;
    public CameraLook cameraLook;

    void Update()
    {
        cameraLook.lockAxis = touchField.TouchDist;
    }
}
