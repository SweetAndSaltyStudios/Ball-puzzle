using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private Vector3 rotation;
    private readonly float rotationLimit = 14.0f;

    private void Update()
    {
        Rotating();
    }

    private void Rotating()
    {
        rotation = new Vector3(InputManager.Instance.VERTICAL_AXIS, 0, -InputManager.Instance.HORIZONTAL_AXIS);
        Vector3 currentRotation = CameraEngine.Instance.transform.TransformDirection(rotation.x, rotation.z, 0);
        transform.rotation = new Quaternion(currentRotation.x, 0, currentRotation.z, rotationLimit);      
    }
}
