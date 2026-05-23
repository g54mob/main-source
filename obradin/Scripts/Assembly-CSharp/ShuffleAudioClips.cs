using System;
using UnityEngine;

[Serializable]
public class ShuffleAudioClips
{
	public AudioClip[] clips;

	private ShuffledSequence shuffledSequence;

	public AudioClip next
	{
		get
		{
			if (shuffledSequence == null)
			{
				shuffledSequence = new ShuffledSequence(clips.Length);
			}
			return clips[shuffledSequence.next];
		}
	}

	public ShuffleAudioClips()
	{
	}

	public ShuffleAudioClips(params AudioClip[] clips_)
	{
		clips = clips_;
		shuffledSequence = new ShuffledSequence(clips.Length);
	}
}
