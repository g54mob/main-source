using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	public class HeartbeatSoundController : MonoBehaviour
	{
		[FormerlySerializedAs("VolumeController")]
		[SerializeField]
		private FloatSmoother _volumeController;

		[FormerlySerializedAs("PitchController")]
		[SerializeField]
		private FloatSmoother _pitchController;

		[SerializeField]
		[FormerlySerializedAs("sound")]
		private AudioSourceController _sound;

		public FloatSmoother VolumeController => null;

		public FloatSmoother PitchController => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
