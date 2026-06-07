using UnityEngine;

namespace ModApi.Common.Extensions
{
	public static class AudioSourceExtensions
	{
		public static AudioSource AddHighPassCutoff(this AudioSource audioSource, float cutoff)
		{
			audioSource.gameObject.AddComponent<AudioHighPassFilter>().cutoffFrequency = cutoff;
			return audioSource;
		}

		public static AudioSource AddLowpassCutoff(this AudioSource audioSource, float cutoff)
		{
			audioSource.gameObject.AddComponent<AudioLowPassFilter>().cutoffFrequency = cutoff;
			return audioSource;
		}

		public static AudioSource SetPitch(this AudioSource audioSource, float pitch)
		{
			audioSource.pitch = pitch;
			return audioSource;
		}
	}
}
