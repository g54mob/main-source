using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
	private void OnEnable()
	{
		GetComponent<ParticleSystem>().Play();
	}

	private void OnDisable()
	{
		GetComponent<ParticleSystem>().Play();
	}
}
