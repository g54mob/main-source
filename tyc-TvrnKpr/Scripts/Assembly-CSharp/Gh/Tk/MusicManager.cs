using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using Utils;

namespace Gh.Tk
{
	public class MusicManager
	{
		public const string SILENCE_TRACKID = "SilenceTrack";

		public const float SILENCE_TRACK_LENGTH_MIN = 15f;

		public const float SILENCE_TRACK_LENGTH_MAX = 30f;

		private float _silenceRemainingTime;

		private const string AUDIO_FLAG_IS_DYNAMIC_MUSIC_ENABLED = "AudioFlag_IsDynamicMusicEnabled";

		private RollingList<string> _debugLogs;

		private const string MUSIC_STATE = "MusicState";

		private string _previousLastTrackId;

		private List<AudioController.AudioInfo> _previousMusicInfo;

		private static List<MusicTrackData> _tracks;

		public const string DEFAULT_THEME = "Default";

		private GameObject _backgroundMusicObj;

		private MusicTrackData _lastTrack;

		private float _timeLastTrackPlayed;

		private List<string> _recentlyPlayedTracks;

		private bool _isTrackStopping;

		private uint _currentPlayingId;

		public bool skipNextMusicFinishedCallback;

		private TweenerCore<float, float, FloatOptions> _musicDelay;

		private float _musicDelayTime;

		private float _defaultDelayTime;

		private bool _isPatronsForMaxIntensityDirty;

		private float _cachedPatronsForMaxIntensity;

		private List<GameLevel> _workshopLevelOrder;

		private GameLevel _currentWorkshopLevel;

		private int _workshopLevelTracksRemaining;

		public static bool IsDebug;

		private bool _isCreditsMusicPlaying;

		public bool IsDynamicMusicEnabled { get; private set; }

		private static MusicManagerConfig Config => null;

		public static List<MusicTrackData> Tracks => null;

		public MusicTrackData LastTrack => null;

		public static event EventHandler<EventArgs<MusicTrackData>> SongEnded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler SongStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void SetDynamicMusicEnabled(bool enabled)
		{
		}

		public void OnFinishedLoading()
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		public void OnReset()
		{
		}

		public void OnUpdate()
		{
		}

		private void UpdateSilenceTrack()
		{
		}

		private void RaiseSongStateChanged()
		{
		}

		public static void AddTrack(MusicTrackData data)
		{
		}

		public MusicManager(GameObject backgroundMusicObj)
		{
		}

		public void PlayLoadingMusic(string music, string ambience)
		{
		}

		public void PlayThemeMusic(string level)
		{
		}

		public void InitListeners()
		{
		}

		private void OnPostLevelUnloaded(object sender, EventArgs e)
		{
		}

		private void OnDayChanged(object sender, EventArgs e)
		{
		}

		private void OnHourChanged(object sender, EventArgs e)
		{
		}

		private void MarkPatronIntensityDirty(object sender, EventArgs e)
		{
		}

		private void FlushRecentTracks()
		{
		}

		private IEnumerable<Patron> GetActivePatrons()
		{
			return null;
		}

		private void OnMinuteChanged(object sender, EventArgs e)
		{
		}

		private bool TryPlaySilence(float currentTavernIntensity)
		{
			return false;
		}

		private void AllowSilenceTrackNext()
		{
		}

		private float GetSilenceTrackLength()
		{
			return 0f;
		}

		public bool IsSongPlaying(string songId)
		{
			return false;
		}

		public bool IsSongPlaying()
		{
			return false;
		}

		private void OnPlayNewTrack()
		{
		}

		public void PlayNextTrack(bool fadeTransition = false)
		{
		}

		public void PlayTrack(string id)
		{
		}

		private void PlayMusicTrackInternal(MusicTrackData data, bool fadeTransition = false)
		{
		}

		private void TrackCallback(object cookie, AkCallbackType callbackType, AkCallbackInfo callbackInfo)
		{
		}

		private void PrepareNextTrack()
		{
		}

		private float RateTavernIntensity()
		{
			return 0f;
		}

		private float GetExpectedPatronsForMaxIntensity()
		{
			return 0f;
		}

		private int GetMinPatronsForMaxIntensity()
		{
			return 0;
		}

		private ListPoolX.DisposablePooledList<MusicTrackData> GetAvailableTavernTracksAsDisposableList()
		{
			return null;
		}

		public void PauseMusic()
		{
		}

		public void ResumeMusic()
		{
		}

		public void ResumeOrPlayMusic()
		{
		}

		public void StopMusicInstant()
		{
		}

		public void StopMusicSlowFade()
		{
		}

		public void StopMusicQuickFade()
		{
		}

		private void StopMusic(string eventId, int fadeTime)
		{
		}

		public void StartMusic()
		{
		}

		private MusicTrackData ChooseWorkshopTrack()
		{
			return null;
		}

		private void NextWorkshopLevel()
		{
		}

		private void DebugLog(string message, bool saveLog = false)
		{
		}

		private void DebugError(string message, bool saveLog = false)
		{
		}

		private void SaveLog(string message)
		{
		}

		public void PlayCreditsMusic()
		{
		}

		public void StopCreditsMusic()
		{
		}
	}
}
