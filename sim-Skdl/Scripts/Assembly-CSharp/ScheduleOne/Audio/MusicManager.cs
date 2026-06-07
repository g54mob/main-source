using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	public class MusicManager : PersistentSingleton<MusicManager>
	{
		private const float TrackUpdateInterval = 0.2f;

		[FormerlySerializedAs("DefaultSnapshot")]
		[SerializeField]
		private AudioMixerSnapshot _defaultSnapshot;

		[FormerlySerializedAs("DistortedSnapshot")]
		[SerializeField]
		private AudioMixerSnapshot _distortedSnapshot;

		private List<MusicTrack> _tracks;

		private MusicTrack _currentTrack;

		public bool IsAnyTrackPlaying => false;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public void SetMusicDistorted(bool distorted, float transition = 5f)
		{
		}

		public void SetTrackEnabled(string trackName, bool enabled)
		{
		}

		public bool TryGetTrack(string trackName, out MusicTrack track)
		{
			track = null;
			return false;
		}

		public void StopTrack(string trackName)
		{
		}

		public void StopAndDisableTracks()
		{
		}

		private void UpdateTracks()
		{
		}
	}
}
