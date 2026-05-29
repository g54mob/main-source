using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

namespace CTS
{
	[CreateAssetMenu(fileName = "New Audio Asset", menuName = "Audio/Audio Asset")]
	public class AudioAsset : ScriptableObject
	{
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

		[field: SerializeField]
		[field: Range(0f, 1f)]
		public float SpatialMix { get; private set; }

		[field: SerializeField]
		public AudioMixerGroup MixerGroup { get; private set; }

		[field: SerializeField]
		public float PlaybackDelay { get; private set; }

		[field: SerializeField]
		public bool AffectedByTime { get; private set; }

		public void PlayOneShot(AudioSource audioSource)
		{
			audioSource.PlaySoundAsset(this);
		}
	}
}
