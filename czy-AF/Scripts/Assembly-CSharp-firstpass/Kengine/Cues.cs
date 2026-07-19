using System.Collections.Generic;
using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Cues")]
	public class Cues : MonoBehaviour
	{
		[Header("Settings")]
		public AudioSource audioSource;

		public float repeat = 1f;

		public bool setVolume = true;

		[Header("Cues")]
		public AudioCue[] audioCues;

		private List<AudioCue> audioCues_randomList = new List<AudioCue>();

		private void Awake()
		{
			InvokeRepeating("PlayAudioCues", 0f, repeat);
			AudioCue[] array = audioCues;
			foreach (AudioCue audioCue in array)
			{
				for (int j = 0; j < audioCue.frequency; j++)
				{
					audioCues_randomList.Add(audioCue);
				}
			}
		}

		public void PlayAudioCues()
		{
			AudioCue audioCue = audioCues_randomList[Random.Range(0, audioCues_randomList.Count)];
			if (audioCue.randomPitch)
			{
				audioSource.pitch = Random.Range(0.8f, 1.2f);
			}
			else
			{
				audioSource.pitch = 1f;
			}
			if (setVolume)
			{
				audioSource.volume = audioCue.volume;
			}
			audioSource.PlayOneShot(audioCue.audioClip);
		}
	}
}
