using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;

namespace DarkTonic.MasterAudio
{
	[AudioScriptOrder(-80)]
	[RequireComponent(typeof(AudioSource))]
	public class PlaylistController : MonoBehaviour
	{
		public enum FadeStatus
		{
			NotFading = 0,
			FadingIn = 1,
			FadeingOut = 2
		}

		public enum AudioPlayType
		{
			PlayNow = 0,
			Schedule = 1,
			AlreadyScheduled = 2
		}

		public enum PlaylistStates
		{
			NotInScene = 0,
			Stopped = 1,
			Playing = 2,
			Paused = 3,
			Crossfading = 4
		}

		public enum FadeMode
		{
			None = 0,
			GradualFade = 1
		}

		public enum AudioDuckingMode
		{
			NotDucking = 0,
			SetToDuck = 1,
			Ducked = 2,
			Unducking = 3
		}

		public delegate void SongChangedEventHandler(string newSongName, MusicSetting song);

		public delegate void SongEndedEventHandler(string songName);

		public delegate void SongLoopedEventHandler(string songName);

		public delegate void PlaylistEndedEventHandler();

		public const int FramesEarlyToTrigger = 2;

		public const int FramesEarlyToBeSyncable = 10;

		private const double UniversalAudioReactionTime = 0.3;

		private const int NextScheduleTimeRecalcConsecutiveFrameCount = 5;

		private const string NotReadyMessage = "Playlist Controller is not initialized yet. It must call its own Awake & Start method before any other methods are called. If you have a script with an Awake or Start event that needs to call it, make sure PlaylistController.cs is set to execute first (Script Execution Order window in Unity). Awake event is still not guaranteed to work, so use Start where possible.";

		private const float MinSongLength = 0.5f;

		private const float SlowestFrameTimeForCalc = 0.3f;

		public bool startPlaylistOnAwake;

		public bool isShuffle;

		public bool isAutoAdvance;

		public bool loopPlaylist;

		public float _playlistVolume;

		public bool isMuted;

		public string startPlaylistName;

		public int syncGroupNum;

		public bool ignoreListenerPause;

		public AudioMixerGroup mixerChannel;

		public MasterAudio.ItemSpatialBlendType spatialBlendType;

		public float spatialBlend;

		public bool initializedEventExpanded;

		public string initializedCustomEvent;

		public bool crossfadeStartedExpanded;

		public string crossfadeStartedCustomEvent;

		public bool songChangedEventExpanded;

		public string songChangedCustomEvent;

		public bool songEndedEventExpanded;

		public string songEndedCustomEvent;

		public bool songLoopedEventExpanded;

		public string songLoopedCustomEvent;

		public bool playlistStartedEventExpanded;

		public string playlistStartedCustomEvent;

		public bool playlistEndedEventExpanded;

		public string playlistEndedCustomEvent;

		private AudioSource _activeAudio;

		private AudioSource _transitioningAudio;

		private float _activeAudioEndVolume;

		private float _transitioningAudioStartVolume;

		private float _crossFadeStartTime;

		private readonly List<int> _clipsRemaining;

		private int _currentSequentialClipIndex;

		private AudioDuckingMode _duckingMode;

		private float _timeToStartUnducking;

		private float _timeToFinishUnducking;

		private float _originalMusicVolume;

		private float _initialDuckVolume;

		private float _duckRange;

		private SoundGroupVariationUpdater _actorUpdater;

		private float _unduckTime;

		private MusicSetting _currentSong;

		private GameObject _go;

		private string _name;

		private FadeMode _curFadeMode;

		private float _slowFadeStartTime;

		private float _slowFadeCompletionTime;

		private float _slowFadeStartVolume;

		private float _slowFadeTargetVolume;

		private MasterAudio.Playlist _currentPlaylist;

		private float _lastTimeMissingPlaylistLogged;

		private Action _fadeCompleteCallback;

		private readonly List<MusicSetting> _queuedSongs;

		private bool _lostFocus;

		private bool _autoStartedPlaylist;

		private AudioSource _audioClip;

		private AudioSource _transClip;

		private MusicSetting _newSongSetting;

		private bool _nextSongRequested;

		private bool _nextSongScheduled;

		private int _lastRandomClipIndex;

		private float _lastTimeSongRequested;

		private float _currentDuckVolCut;

		private int? _lastSongPosition;

		private double? _currentSchedSongDspStartTime;

		private double? _currentSchedSongDspEndTime;

		private int _lastFrameSongPosition;

		private int _nextScheduleTimeRecalcDifferentFirstFrameNum;

		private double? _nextScheduledTimeRecalcStart;

		private readonly Dictionary<AudioSource, double> _scheduledSongOffsetByAudioSource;

		private readonly Dictionary<AudioSource, AssetReference> _loadedAddressablesByAudioSource;

		public int _frames;

		private static List<PlaylistController> _instances;

		private Coroutine _resourceCoroutine;

		private Coroutine _addressableCoroutine;

		private int _songsPlayedFromPlaylist;

		private AudioSource _audio1;

		private AudioSource _audio2;

		private string _activeSongAlias;

		private Transform _trans;

		private bool _willPersist;

		private double? _songPauseTime;

		private int framesOfSongPlayed;

		private bool WillSyncToOtherClip => false;

		public bool CurrentSongIsPlaying => false;

		private bool SongIsNonAdvancible => false;

		public bool ControllerIsReady { get; private set; }

		public FadeStatus CurrentFadeStatus => default(FadeStatus);

		public PlaylistStates PlaylistState => default(PlaylistStates);

		public AudioSource ActiveAudioSource => null;

		public static List<PlaylistController> Instances
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameObject PlaylistControllerGameObject => null;

		public AudioSource CurrentPlaylistSource => null;

		public AudioClip CurrentPlaylistClip => null;

		public AudioClip FadingPlaylistClip => null;

		public AudioSource FadingSource => null;

		public bool IsCrossFading { get; private set; }

		public bool IsFading => false;

		public float PlaylistVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MasterAudio.Playlist CurrentPlaylist => null;

		public bool HasPlaylist => false;

		public string PlaylistName => null;

		public MusicSetting CurrentSong => null;

		private bool IsMuted => false;

		private bool PlaylistIsMuted
		{
			set
			{
			}
		}

		private float CrossFadeTime => 0f;

		private bool IsAutoAdvance => false;

		public GameObject GameObj => null;

		public string ControllerName => null;

		public bool CanSchedule => false;

		private bool IsFrameFastEnough => false;

		private bool ShouldNotSwitchEarly => false;

		private Transform Trans => null;

		public int ClipsRemainingInCurrentPlaylist => 0;

		public event SongChangedEventHandler SongChanged
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

		public event SongEndedEventHandler SongEnded
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

		public event SongLoopedEventHandler SongLooped
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

		public event PlaylistEndedEventHandler PlaylistEnded
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

		private void Awake()
		{
		}

		public void SetSpatialBlend()
		{
		}

		private void DetectAndRescheduleNextGaplessSongIfOff()
		{
		}

		private MusicSetting FindSongByAliasOrName(string clipName)
		{
			return null;
		}

		private void SetAudiosIfEmpty()
		{
		}

		private void SetAudioSpatialBlend(float blend)
		{
		}

		private void Start()
		{
		}

		private void AutoStartPlaylist()
		{
		}

		private void CoUpdate()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnApplicationPause(bool pauseStatus)
		{
		}

		private void Update()
		{
		}

		public static PlaylistController InstanceByName(string playlistControllerName, bool errorIfNotFound = true)
		{
			return null;
		}

		public bool IsSongPlaying(string songName)
		{
			return false;
		}

		public void ClearQueue()
		{
		}

		public void ToggleMutePlaylist()
		{
		}

		public void MutePlaylist()
		{
		}

		public void UnmutePlaylist()
		{
		}

		public void PausePlaylist()
		{
		}

		public bool UnpausePlaylist()
		{
			return false;
		}

		public void StopPlaylist(bool onlyFadingClip = false)
		{
		}

		public void FadeToVolume(float targetVolume, float fadeTime, Action callback = null)
		{
		}

		public void PlayRandomSong()
		{
		}

		public void PlayARandomSong(AudioPlayType playType)
		{
		}

		private void RemoveRandomClip(int randIndex)
		{
		}

		private void PlayFirstQueuedSong(AudioPlayType playType)
		{
		}

		public void PlayNextSong()
		{
		}

		public void PlayTheNextSong(AudioPlayType playType)
		{
		}

		private void AdvanceSongCounter()
		{
		}

		public void StopPlaylistAfterCurrentSong()
		{
		}

		public void StopLoopingCurrentSong()
		{
		}

		public void QueuePlaylistClip(string clipName, bool scheduleNow = true)
		{
		}

		public bool TriggerPlaylistClip(string clipName)
		{
			return false;
		}

		public void EndDucking(SoundGroupVariationUpdater actorUpdater)
		{
		}

		public void DuckMusicForTime(SoundGroupVariationUpdater actorUpdater, float duckLength, float unduckTime, float pitch, float duckedTimePercentage, float duckedVolCut)
		{
		}

		private void InitControllerIfNot()
		{
		}

		public void UpdateMasterVolume()
		{
		}

		public void StartPlaylist(string playlistName, string clipName = null)
		{
		}

		public void ChangePlaylist(string playlistName, bool playFirstClip = true, string clipName = null)
		{
		}

		private void FinishPlaylistInit(bool playFirstClip = true, string clipName = null)
		{
		}

		public void RestartPlaylist(string clipName = null)
		{
		}

		private void CheckIfPlaylistStarted()
		{
		}

		private PlaylistController FindOtherControllerInSameSyncGroup()
		{
			return null;
		}

		private void FadeOutPlaylist()
		{
		}

		private void InitializePlaylist()
		{
		}

		private void PlayNextOrRandom(AudioPlayType playType)
		{
		}

		private void FirePlaylistEndedEventIfAny()
		{
		}

		private void FillClips()
		{
		}

		private void PlaySong(MusicSetting setting, AudioPlayType playType)
		{
		}

		public double? ScheduledGaplessNextSongStartTime()
		{
			return null;
		}

		public void FinishLoadingNewSong(MusicSetting songSetting, AudioClip clipToPlay, AudioPlayType playType)
		{
		}

		private void RemoveScheduledClip()
		{
		}

		private void ScheduleNextSong()
		{
		}

		private void FadeInScheduledSong()
		{
		}

		private double CalculateNextTrackStartTimeOffset()
		{
			return 0.0;
		}

		private double GetClipDuration(AudioSource src)
		{
			return 0.0;
		}

		private void ScheduleClipPlay(double scheduledPlayTimeOffset, AudioSource source, bool calledAfterPause, bool addDspTime = true)
		{
		}

		private void CrossFadeNow(AudioSource audioClip)
		{
		}

		private void CeaseAudioSource(AudioSource source)
		{
		}

		private void SetDuckProperties()
		{
		}

		private void AudioDucking()
		{
		}

		private void ResetDuckingState()
		{
		}

		private bool SongShouldLoop(MusicSetting setting)
		{
			return false;
		}

		public void RouteToMixerChannel(AudioMixerGroup group)
		{
		}
	}
}
