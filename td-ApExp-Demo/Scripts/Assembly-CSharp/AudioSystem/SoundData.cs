using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioSystem
{
	[Serializable]
	public class SoundData
	{
		public List<AudioClip> clips;

		public AudioMixerGroup mixerGroup;

		public FrequentSoundTypes frequentSoundType;

		public bool loop;

		public bool frequentSound;

		public bool mute;

		public float volume = 1f;

		public float pitch = 1f;

		public bool randomPitch = true;

		[SerializeField]
		[Range(-0.2f, 0f)]
		public float minPitchDown = -0.05f;

		[SerializeField]
		[Range(0f, 0.2f)]
		public float maxPitchUp = 0.05f;

		public Transform withPosition;

		public GameObject stopWhenSourceIsDestroyed;
	}
}
