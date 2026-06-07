using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
	public class AudioFile
	{
		public float DefaultVolume { get; set; }

		public float Doppler { get; set; }

		public string Id { get; set; }

		public float MaxDistance { get; set; }

		public float MinDistance { get; set; }

		public AudioMixerGroup MixerGroup { get; set; }

		public AudioClip Resource { get; set; }

		public float Spread { get; set; }
	}
}
