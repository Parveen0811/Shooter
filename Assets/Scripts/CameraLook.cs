using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float xMove;
    private float yMove;
    private float xRotation;
    [SerializeField] private Transform playerBody; 
    public Vector2 lockAxis;
    public float Sensitivity = 40f;

    void Update()
    {
        xMove = lockAxis.x * Sensitivity * Time.deltaTime;
        yMove = lockAxis.y * Sensitivity * Time.deltaTime;

        xRotation -= yMove;
        xRotation = Mathf.Clamp(xRotation, -30f, 15f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xMove);
    }
}
