using UnityEngine;

public class BallEngine : MonoBehaviour
{
    private Rigidbody rb;

	private void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = Mathf.Infinity;
	}
}
