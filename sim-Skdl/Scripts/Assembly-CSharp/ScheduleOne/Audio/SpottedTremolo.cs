using ScheduleOne.Vision;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(AudioSourceController))]
	public class SpottedTremolo : MonoBehaviour
	{
		private const float MinVolume = 0f;

		private const float MaxVolume = 1f;

		private const float MinPitch = 1.2f;

		private const float MaxPitch = 1.3f;

		private const float SmoothTime = 0.25f;

		[SerializeField]
		[FormerlySerializedAs("PlayerVisibility")]
		private EntityVisibility _visibilityComponent;

		private AudioSourceController _audio;

		private float _targetIntensity;

		private float _smoothedIntensity;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
