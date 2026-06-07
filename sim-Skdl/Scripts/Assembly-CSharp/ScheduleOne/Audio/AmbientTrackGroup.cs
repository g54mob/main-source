using System.Collections.Generic;
using ScheduleOne.Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	public class AmbientTrackGroup : MonoBehaviour
	{
		private const float AmbientTrackCooldown = 540f;

		private static float TimeOnLastAmbientTrackStart;

		private static AmbientTrackGroup LastPlayedTrackGroup;

		private static bool IsAnyTrackGroupQueued;

		[FormerlySerializedAs("Tracks")]
		[SerializeField]
		private List<MusicTrack> _trackList;

		[FormerlySerializedAs("MinTime")]
		[SerializeField]
		private int _windowStartTime;

		[FormerlySerializedAs("MaxTime")]
		[SerializeField]
		private int _windowEndTime;

		[SerializeField]
		[FormerlySerializedAs("Chance")]
		[Range(0f, 1f)]
		private float _chanceToPlay;

		private int _startTime;

		private bool _playTrack;

		private bool _trackRandomized;

		private void Awake()
		{
		}

		[Button]
		public void ForcePlay()
		{
		}

		public void Stop()
		{
		}

		private void Update()
		{
		}

		protected virtual bool CanPlayNow()
		{
			return false;
		}
	}
}
