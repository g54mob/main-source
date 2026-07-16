using UnityEngine;

public class HudScrambleParticleController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem healthBarPs;

	[SerializeField]
	private ParticleSystem progressBarPs;

	[SerializeField]
	private ParticleSystem coalBarPs;

	[SerializeField]
	private ParticleSystem ammoBarPs;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayParticles()
	{
		audioSource.Play();
		healthBarPs.Play();
		progressBarPs.Play();
		coalBarPs.Play();
		ammoBarPs.Play();
	}

	public void StopParticles()
	{
		audioSource.Stop();
		healthBarPs.Stop();
		progressBarPs.Stop();
		coalBarPs.Stop();
		ammoBarPs.Stop();
	}
}
