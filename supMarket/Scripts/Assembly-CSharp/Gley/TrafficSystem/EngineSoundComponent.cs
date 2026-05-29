using UnityEngine;

namespace Gley.TrafficSystem
{
	[RequireComponent(typeof(AudioSource))]
	public class EngineSoundComponent : MonoBehaviour
	{
		[Tooltip("Pitch used when vehicle is stationary")]
		public float minPitch;

		[Tooltip("Pitch used when vehicle is at max speed")]
		public float maxPitch;

		[Tooltip("Volume used when vehicle is stationary")]
		public float minVolume;

		[Tooltip("Volume used when vehicle is at max speed")]
		public float maxVolume;

		private AudioSource _audioSource;

		public void Initialize()
		{
		}

		public void Play(float masterVolume)
		{
		}

		public void Stop()
		{
		}

		public void UpdateEngineSound(float velocity, float maxVelocity, float masterVolume)
		{
		}
	}
}
