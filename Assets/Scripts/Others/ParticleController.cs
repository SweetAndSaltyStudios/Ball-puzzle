using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;

	private void Start ()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	private void Update ()
    {
        if (thisParticleSystem.isPlaying)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
