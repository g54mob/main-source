using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(AudioSourceController))]
	public class AmbientOneShot : MonoBehaviour
	{
		private enum EPlayTime
		{
			All = 0,
			Day = 1,
			Night = 2
		}

		[Range(0f, 1f)]
		[SerializeField]
		[FormerlySerializedAs("Volume")]
		[Header("Settings")]
		private float _volume;

		[SerializeField]
		[FormerlySerializedAs("ChancePerHour")]
		[Range(0f, 1f)]
		private float _playChancePerHour;

		[FormerlySerializedAs("CooldownTime")]
		[SerializeField]
		private int _cooldownTime;

		[SerializeField]
		[FormerlySerializedAs("PlayTime")]
		private EPlayTime _playTime;

		[SerializeField]
		[FormerlySerializedAs("MinDistance")]
		private float _minDistanceFromCameraToPlay;

		[FormerlySerializedAs("MaxDistance")]
		[SerializeField]
		private float _maxDistanceFromCameraToPlay;

		[SerializeField]
		[FormerlySerializedAs("PlayWhileInSewer")]
		private bool _canPlayWhilePlayerInSewer;

		private int _timeSinceLastPlay;

		private AudioSourceController _audioSource;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnUncappedMinPass()
		{
		}

		private void Play()
		{
		}
	}
}
