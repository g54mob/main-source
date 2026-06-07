using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class EventSound
	{
		[Tooltip("Name of the Sound you will call on the Animation Event")]
		public string name = "Name Here";

		public float volume = 1f;

		public float pitch = 1f;

		public bool active = true;

		[Tooltip("Interval Time to play a sound forever. Remember to call [PlaySoundForever]")]
		public float interval;

		public AudioSource source;

		public AudioClip[] Clips;

		public float VolumeWeight { get; internal set; }

		public void PlayAudio(AudioSource audio)
		{
			if (source == null)
			{
				source = audio;
			}
			if (!(source == null) && Clips != null && Clips.Length != 0)
			{
				source.spatialBlend = 1f;
				source.clip = Clips[UnityEngine.Random.Range(0, Clips.Length)];
				source.pitch = pitch;
				source.volume = Mathf.Clamp01(volume * VolumeWeight);
				source.Play();
			}
		}
	}
}
