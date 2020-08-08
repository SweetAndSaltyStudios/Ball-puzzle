using UnityEngine;

public class CameraEngine : Singelton<CameraEngine>
{
    private Transform lookAt;

    private Vector3 desiredPosition;
    private Vector3 offset;

    private readonly float smoothSpeed = 10f;

    private void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("LookTarget").transform;
        offset = transform.position;
        transform.SetPositionAndRotation(new Vector3(-15, 20, 0), Quaternion.Euler(45, 90, 0));
    }

    private void Update()
    {
        if (InputManager.Instance.SWIPE_DIRECTION.Equals(SWIPE_DIRECTION.LEFT))
        {
            SlideCamera(Vector3.up * 90);
        }
        if (InputManager.Instance.SWIPE_DIRECTION.Equals(SWIPE_DIRECTION.RIGHT))
        {
            SlideCamera(Vector3.down * 90);
        }
        if (InputManager.Instance.SWIPE_DIRECTION.Equals(SWIPE_DIRECTION.UP))
        {
            SlideCamera(Vector3.back * 90);
        }
        if (InputManager.Instance.SWIPE_DIRECTION.Equals(SWIPE_DIRECTION.DOWN))
        {
            SlideCamera(Vector3.forward * 90);
        }
    }

    private void LateUpdate()
    {
        desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position);
    }

    private void SlideCamera(Vector3 rotation)
    {
        offset = Quaternion.Euler(rotation) * offset;
    }
}
