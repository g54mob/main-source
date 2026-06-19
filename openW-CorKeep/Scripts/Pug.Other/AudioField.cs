using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioField
{
	public enum AudioClipPlayOrder
	{
		SEQUENCE = 0,
		RANDOM = 1,
		SEQUENCE_RANDOM_START = 2
	}

	public string audioFieldName = "name";

	[Header("Settings:")]
	public float volumeMin = 1f;

	public float volumeMax = 1f;

	public float offsetMin;

	public float offsetMax;

	public float pitchMin = 1f;

	public float pitchMax = 1f;

	public bool loop;

	public float audioPlaytimeCapMax = 1000f;

	public AudioClipPlayOrder audioClipPlayOrder = AudioClipPlayOrder.RANDOM;

	public AudioManager.MixerGroupEnum mixerGroup = AudioManager.MixerGroupEnum.EFFECTS;

	[Header("Playables")]
	public List<AudioClip> audioPlayables = new List<AudioClip>();

	private int lastPlayedClipIndex = -1;

	public void ResetAudioField()
	{
		lastPlayedClipIndex = -1;
	}

	public AudioClip GetNextAudioClip()
	{
		if (audioPlayables.Count == 0)
		{
			Debug.LogError("The audio field " + audioFieldName + " has 0 members and is being called!");
			return null;
		}
		if (audioPlayables.Count == 1)
		{
			return audioPlayables[0];
		}
		int num = -1;
		switch (audioClipPlayOrder)
		{
		case AudioClipPlayOrder.RANDOM:
			if (lastPlayedClipIndex == -1)
			{
				num = UnityEngine.Random.Range(0, audioPlayables.Count);
				break;
			}
			num = UnityEngine.Random.Range(0, audioPlayables.Count - 1);
			if (num >= lastPlayedClipIndex)
			{
				num++;
			}
			break;
		case AudioClipPlayOrder.SEQUENCE_RANDOM_START:
			if (lastPlayedClipIndex == -1)
			{
				lastPlayedClipIndex = UnityEngine.Random.Range(0, audioPlayables.Count);
			}
			goto case AudioClipPlayOrder.SEQUENCE;
		case AudioClipPlayOrder.SEQUENCE:
			num = lastPlayedClipIndex + 1;
			if (num >= audioPlayables.Count)
			{
				num = 0;
			}
			break;
		}
		if (num == -1)
		{
			Debug.LogError("Play order " + audioClipPlayOrder.ToString() + " not supported.");
			return null;
		}
		lastPlayedClipIndex = num;
		return audioPlayables[num];
	}

	public float GetVolume()
	{
		return UnityEngine.Random.Range(volumeMin, volumeMax);
	}

	public float GetOffset()
	{
		return UnityEngine.Random.Range(offsetMin, offsetMax);
	}

	public float GetPitch()
	{
		return UnityEngine.Random.Range(pitchMin, pitchMax);
	}
}
