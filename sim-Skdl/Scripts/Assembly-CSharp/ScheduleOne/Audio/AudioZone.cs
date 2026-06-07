using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	public class AudioZone : PolygonalZone
	{
		private const float VolumeChangeRate = 1f;

		private const float UpdateInterval = 0.25f;

		[SerializeField]
		[FormerlySerializedAs("MaxDistance")]
		[Range(1f, 200f)]
		private float _maximumAudibleDistance;

		[SerializeField]
		[FormerlySerializedAs("Tracks")]
		private List<AudioZoneTrack> _tracks;

		private float _localCameraDistance;

		private float _currentVolume;

		private List<IAudioZoneModifier> _modifiers;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnUncappedMinPass()
		{
		}

		private void Update()
		{
		}

		private float GetModifierMultiplier()
		{
			return 0f;
		}

		private void RecalculateCameraDistance()
		{
		}

		public void AddModifier(IAudioZoneModifier modifier)
		{
		}

		public void RemoveModifier(IAudioZoneModifier modifier)
		{
		}

		private float GetFalloffFactor(float distance)
		{
			return 0f;
		}
	}
}
