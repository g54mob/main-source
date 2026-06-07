using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(AudioSourceController))]
	public class TimeOfDayVolumeController : MonoBehaviour
	{
		private const float MinVolume = 0.3f;

		private const float FadeSpeed = 0.25f;

		[SerializeField]
		[FormerlySerializedAs("VolumeCurve")]
		private AnimationCurve _timeOfDayVolumeCurve;

		[SerializeField]
		[FormerlySerializedAs("FadeDuringMusic")]
		private bool _reduceVolumeWhenSoundtrackPlaying;

		private AudioSourceController _audioSourceController;

		private float _volumeMultiplier;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
