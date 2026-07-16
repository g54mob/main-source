using UnityEngine;

public class PitchRandomizer : MonoBehaviour
{
	[SerializeField]
	private float minPitch = 0.9f;

	[SerializeField]
	private float maxPitch = 1f;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		float pitch = Random.Range(minPitch, maxPitch);
		audioSource.pitch = pitch;
	}
}
