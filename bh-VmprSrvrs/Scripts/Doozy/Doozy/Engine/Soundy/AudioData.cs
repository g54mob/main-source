using System;
using UnityEngine;

namespace Doozy.Engine.Soundy
{
	[Serializable]
	public class AudioData
	{
		public const float DEFAULT_WEIGHT = 1f;

		public const float MAX_WEIGHT = 1f;

		public const float MIN_WEIGHT = 0f;

		public AudioClip AudioClip;

		[Range(0f, 1f)]
		public float Weight;

		public AudioData()
		{
		}

		public AudioData(AudioClip audioClip)
		{
		}

		public AudioData(AudioClip audioClip, float weight)
		{
		}

		public void Reset()
		{
		}
	}
}
