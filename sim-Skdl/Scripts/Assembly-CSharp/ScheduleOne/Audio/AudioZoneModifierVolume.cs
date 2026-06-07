using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	public class AudioZoneModifierVolume : MonoBehaviour, IAudioZoneModifier
	{
		[FormerlySerializedAs("Zones")]
		[SerializeField]
		private List<AudioZone> _zones;

		[FormerlySerializedAs("VolumeMultiplier")]
		[SerializeField]
		private float _volumeMultiplier;

		private BoxCollider[] _colliders;

		public float VolumeMultiplier => 0f;

		private void Start()
		{
		}

		private void Refresh()
		{
		}

		private bool IsCameraWithinVolume()
		{
			return false;
		}
	}
}
