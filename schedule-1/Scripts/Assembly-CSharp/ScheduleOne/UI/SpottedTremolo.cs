using ScheduleOne.Audio;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.UI
{
	public class SpottedTremolo : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float Intensity;

		public AudioSourceController Loop;

		public EntityVisibility PlayerVisibility;

		[Header("Settings")]
		public float MinVolume;

		public float MaxVolume;

		public float MinPitch;

		public float MaxPitch;

		public float SmoothTime;

		[SerializeField]
		[Range(0f, 1f)]
		private float smoothedIntensity;

		public void Update()
		{
		}
	}
}
