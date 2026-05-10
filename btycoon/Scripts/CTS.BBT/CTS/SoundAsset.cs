using System;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class SoundAsset
	{
		public string _name;

		[field: SerializeField]
		public AudioClip[] AudioClips { get; private set; }

		[field: SerializeField]
		[field: MinMaxSlider(0f, 1f)]
		public Vector2 VolumeRange { get; private set; } = new Vector2(1f, 1f);

		[field: SerializeField]
		[field: MinMaxSlider(-3f, 3f)]
		public Vector2 PitchRange { get; private set; } = new Vector2(1f, 1f);

		[field: SerializeField]
		[field: Range(0f, 256f)]
		public int Priority { get; private set; } = 128;

		[field: SerializeField]
		public bool Loop { get; private set; }

		public Vector2 GetVolumeRange => VolumeRange;

		public AudioClip[] GetAudioClips => AudioClips;

		public void PlayOneShot(AudioSource audioSource)
		{
			audioSource.PlaySoundAsset(this);
		}
	}
}
