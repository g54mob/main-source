using UnityEngine;

public class LoveBurst : MonoBehaviour
{
	private ParticleSystem particleSystemRef;

	private void Awake()
	{
		particleSystemRef = GetComponent<ParticleSystem>();
		GetComponent<MeshRenderer>().enabled = false;
	}

	private void OnTriggerEnter(Collider c)
	{
		if (!particleSystemRef.isPlaying)
		{
			particleSystemRef.Play();
		}
	}
}
