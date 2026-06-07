using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
	public List<AudioClip> soundClips;

	public AudioSource audioSource;

	public bool playOnStart;

	public float fixedVolume = 1f;

	private void Start()
	{
		if (playOnStart)
		{
			PlaySoundEffect(1f);
		}
	}

	public void PlaySoundEffect(float volume)
	{
		int index = Random.Range(0, soundClips.Count);
		AudioClip clip = soundClips[index];
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.Play();
	}

	public void PlaySoundFromList(int list)
	{
		AudioClip clip = soundClips[list];
		audioSource.clip = clip;
		audioSource.volume = fixedVolume;
		audioSource.Play();
	}
}
