using System.Collections.Generic;
using UnityEngine;

public class CoalHoseLastSegment : CoalHoseSegment
{
	[SerializeField]
	private ParticleSystem emberPs;

	[SerializeField]
	private List<AudioClip> gulpClips;

	[SerializeField]
	private AudioSource audioSource;

	public void PlayEmbers()
	{
		if (emberPs != null)
		{
			emberPs.Play();
		}
	}

	public void RandomGulp()
	{
		if (gulpClips.Count > 0)
		{
			audioSource.PlayOneShot(gulpClips[Random.Range(0, gulpClips.Count)]);
		}
	}
}
