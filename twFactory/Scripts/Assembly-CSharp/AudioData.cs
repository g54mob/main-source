using System;
using UnityEngine;

[Serializable]
public class AudioData
{
	private enum EPitchMode
	{
		Constant = 0,
		Random = 1
	}

	[SerializeField]
	private AudioClip[] audioClips;

	[SerializeField]
	private float volume = 1f;

	[SerializeField]
	private float pitch = 1f;

	[SerializeField]
	private Vector2 pitchRandom = Vector2.one;

	[SerializeField]
	private EPitchMode pitchMode;

	public AudioClip GetRandomAudioClip
	{
		get
		{
			if (audioClips != null && audioClips.Length != 0)
			{
				return AudioClips[UnityEngine.Random.Range(0, AudioClips.Length)];
			}
			return null;
		}
	}

	public AudioClip[] AudioClips => audioClips;

	public float Volume => volume;

	public float Pitch
	{
		get
		{
			if (pitchMode == EPitchMode.Constant)
			{
				return pitch;
			}
			return UnityEngine.Random.Range(pitchRandom.x, pitchRandom.y);
		}
	}
}
