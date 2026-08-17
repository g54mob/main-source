using System;
using UnityEngine;

namespace Doozy.Engine.Soundy;

[Serializable]
public class AudioData
{
	public const float DEFAULT_WEIGHT = 1f;

	public const float MAX_WEIGHT = 1f;

	public const float MIN_WEIGHT = 0f;

	public AudioClip AudioClip;

	public float Weight;

	public AudioData()
	{
		Weight = 1f;
		AudioClip = null;
		Weight = 1f;
	}

	public AudioData(AudioClip audioClip)
	{
		Weight = 1f;
		AudioClip = null;
		Weight = 1f;
		AudioClip = audioClip;
	}

	public AudioData(AudioClip audioClip, float weight)
	{
		Weight = 1f;
		AudioClip = null;
		Weight = 1f;
		AudioClip = audioClip;
		Weight = weight;
	}

	public void Reset()
	{
		AudioClip = null;
		Weight = 1f;
	}
}
