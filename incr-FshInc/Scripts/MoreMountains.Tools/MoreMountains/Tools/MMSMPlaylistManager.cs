using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMSMPlaylistManager : MMMonoBehaviour
	{
		public enum PlaylistManagerStates
		{
			Idle = 0,
			Playing = 1,
			Paused = 2
		}

		public delegate void PlaylistEvent();

		[MMInspectorGroup("Settings", true, 18, false)]
		[Tooltip("the channel used to target this playlist manager by playlist remote or playlist feedbacks")]
		public int Channel;

		[Tooltip("the current playlist this manager will play")]
		public MMSMPlaylist Playlist;

		[Tooltip("whether this playlist manager should auto play on start or not")]
		public bool PlayOnStart;

		[Tooltip("a global volume multiplier to apply when playing a song")]
		[Range(0f, 1f)]
		public float VolumeMultiplier = 1f;

		[Tooltip("a pitch multiplier to apply to all songs when playing them")]
		[Range(0f, 20f)]
		public float PitchMultiplier = 1f;

		[Tooltip("if this is true, this playlist manager will persist from scene to scene and will keep playing")]
		public bool Persistent;

		[Tooltip("if this is true, this singleton will auto detach if it finds itself parented on awake")]
		[MMCondition("Persistent", true)]
		public bool AutomaticallyUnparentOnAwake = true;

		[Tooltip("if this is true, this playlist will automatically pause/resume OnApplicationPause, useful if you've prevented your game from running in the background")]
		public bool AutoHandleApplicationPause = true;

		[MMInspectorGroup("Fade", true, 12, false)]
		[Tooltip("whether or not sounds should fade in when they start playing")]
		public bool FadeIn;

		[Tooltip("whether or not sounds should fade out when they stop playing")]
		public bool FadeOut;

		[Tooltip("the duration of the fade, in seconds")]
		public float FadeDuration = 1f;

		[Tooltip("the tween to use when fading the sound")]
		public MMTweenType FadeTween = new MMTweenType(MMTween.MMTweenCurve.EaseInCubic, "", "");

		[MMInspectorGroup("Time", true, 20, false)]
		[Tooltip("whether or not the playlist manager should have its pitch multiplier value driven by the current timescale. If set to true, songs would appear to slow down when time is slowed down, and to speed up when time scale is higher than normal")]
		public bool BindPitchToTimeScale;

		[Tooltip("the values to remap timescale from (min and max) - when timescale is equal to TimescaleRemapFrom.x, the pitch multiplier will be TimescaleRemapTo.x")]
		[MMCondition("BindPitchToTimeScale", true)]
		public Vector2 TimescaleRemapFrom = new Vector2(0f, 2f);

		[Tooltip("the values to remap timescale to (min and max) - when timescale is equal to TimescaleRemapFrom.x, the pitch multiplier will be TimescaleRemapTo.x")]
		[MMCondition("BindPitchToTimeScale", true)]
		public Vector2 TimescaleRemapTo = new Vector2(0.8f, 1.2f);

		[MMInspectorGroup("Status", true, 14, false)]
		[Tooltip("the current state of the playlist, debug display only")]
		[MMReadOnly]
		public PlaylistManagerStates DebugCurrentManagerState;

		[Tooltip("the index we're currently playing")]
		[MMReadOnly]
		public int CurrentSongIndex = -1;

		[Tooltip("the name of the song that is currently playing")]
		[MMReadOnly]
		public string CurrentSongName;

		[MMReadOnly]
		public MMStateMachine<PlaylistManagerStates> PlaylistManagerState;

		[Tooltip("the time of the currently playing song")]
		[MMReadOnly]
		public float CurrentTime;

		[Tooltip("the time (in seconds) left on the song currently playing")]
		[MMReadOnly]
		public float CurrentTimeLeft;

		[Tooltip("the total duration of the song currently playing")]
		[MMReadOnly]
		public float CurrentClipDuration;

		[Tooltip("the current normalized progress of the song currently playing")]
		[Range(0f, 1f)]
		public float CurrentProgress;

		[MMInspectorGroup("Test Controls", true, 15, false)]
		[MMInspectorButton("Play")]
		public bool PlayButton;

		[MMInspectorButton("Stop")]
		public bool StopButton;

		[MMInspectorButton("Pause")]
		public bool PauseButton;

		[MMInspectorButton("PlayPreviousSong")]
		public bool PreviousButton;

		[MMInspectorButton("PlayNextSong")]
		public bool NextButton;

		[Tooltip("the index of the song to play when pressing the PlayTargetSong button")]
		public int TargetSongIndex;

		[MMInspectorButton("PlayTargetSong")]
		public bool TargetSongButton;

		[MMInspectorButton("QueueTargetSong")]
		public bool QueueTargetSongButton;

		[MMInspectorButton("SetCurrentSongToLoop")]
		public bool SetLoopTargetSongButton;

		[MMInspectorButton("StopCurrentSongFromLooping")]
		public bool StopLoopTargetSongButton;

		[Tooltip("a playlist you can set to use with the SetTargetPlaylist and PlayTargetPlaylist buttons")]
		public MMSMPlaylist TestPlaylist;

		[MMInspectorButton("SetTargetPlaylist")]
		public bool SetTargetPlaylistButton;

		[MMInspectorButton("PlayTargetPlaylist")]
		public bool PlayTargetPlaylistButton;

		[MMInspectorButton("ResetPlayCount")]
		public bool ResetPlayCountButton;

		[Tooltip("a slider used to test volume control")]
		[Range(0f, 2f)]
		public float TestVolumeControl = 1f;

		[Tooltip("a slider used to test speed control")]
		[Range(0f, 20f)]
		public float TestPlaybackSpeedControl = 1f;

		public PlaylistEvent OnSongStart;

		public PlaylistEvent OnSongEnd;

		public PlaylistEvent OnPause;

		public PlaylistEvent OnStop;

		public PlaylistEvent OnPlaylistChange;

		public PlaylistEvent OnPlaylistEnd;

		protected bool _shouldResumeOnApplicationPause;

		protected static MMSMPlaylistManager _instance;

		protected int _queuedSongIndex = -1;

		protected AudioSource _currentlyPlayingAudioSource;

		protected MMSoundManagerPlayOptions _options;

		protected float _lastTestVolumeControl = 1f;

		protected float _lastTestPlaybackSpeedControl = 1f;

		internal bool _listeningToEvents;

		public virtual bool IsPlaying
		{
			get
			{
				if (_currentlyPlayingAudioSource != null)
				{
					return _currentlyPlayingAudioSource.isPlaying;
				}
				return false;
			}
		}

		public static bool HasInstance => _instance != null;

		public static MMSMPlaylistManager Current => _instance;

		public static MMSMPlaylistManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindAnyObjectByType<MMSMPlaylistManager>();
					if (_instance == null)
					{
						_instance = new GameObject
						{
							name = typeof(MMPlaylist).Name + "_AutoCreated"
						}.AddComponent<MMSMPlaylistManager>();
					}
				}
				return _instance;
			}
		}

		protected virtual void Awake()
		{
			InitializeSingleton();
		}

		protected virtual void InitializeSingleton()
		{
			if (Application.isPlaying && Persistent)
			{
				if (AutomaticallyUnparentOnAwake)
				{
					base.transform.SetParent(null);
				}
				if (_instance == null)
				{
					_instance = this;
					UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
				}
				else if (this != _instance)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}

		protected virtual void Start()
		{
			Initialization();
			if (PlayOnStart)
			{
				PlayFirstSong();
			}
			if (!_listeningToEvents)
			{
				StartListening();
			}
		}

		protected virtual void Initialization()
		{
			InitializeRandomSeed();
			Playlist.Initialization();
			InitializePlaylistManagerState();
		}

		protected virtual void InitializeRandomSeed()
		{
			if ((Playlist.PlayOrder == MMSMPlaylist.PlayOrders.Random || Playlist.PlayOrder == MMSMPlaylist.PlayOrders.RandomUnique) && Playlist.RandomizeOrderSeed)
			{
				UnityEngine.Random.InitState(Environment.TickCount);
			}
		}

		protected virtual void InitializePlaylistManagerState()
		{
			PlaylistManagerState = new MMStateMachine<PlaylistManagerStates>(base.gameObject, triggerEvents: true);
			ChangePlaylistManagerState(PlaylistManagerStates.Idle);
		}

		protected virtual void ChangePlaylistManagerState(PlaylistManagerStates newManagerState)
		{
			PlaylistManagerState.ChangeState(newManagerState);
		}

		protected virtual void Update()
		{
			if (!AudioListener.pause && !MMPersistentSingleton<MMSoundManager>.Instance.IsPaused(Playlist.Track))
			{
				if (PlaylistManagerState.CurrentState == PlaylistManagerStates.Idle)
				{
					base.enabled = false;
					return;
				}
				UpdateTimeAndProgress();
				HandleTimescale();
				HandleEndOfSong();
			}
		}

		protected virtual void HandleTimescale()
		{
			if (BindPitchToTimeScale)
			{
				float pitchMultiplier = MMMaths.Remap(Time.timeScale, TimescaleRemapFrom.x, TimescaleRemapFrom.y, TimescaleRemapTo.x, TimescaleRemapTo.y);
				SetPitchMultiplier(pitchMultiplier);
			}
		}

		protected virtual void UpdateTimeAndProgress()
		{
			CurrentTime = _currentlyPlayingAudioSource.time;
			CurrentTimeLeft = _currentlyPlayingAudioSource.clip.length - _currentlyPlayingAudioSource.time;
			CurrentProgress = CurrentTime / CurrentClipDuration;
		}

		protected virtual void PlayFirstSong()
		{
			Playlist.Initialization();
			CurrentSongIndex = -1;
			HandleNextSong(1, bypassLoop: false);
		}

		protected virtual void HandleEndOfSong()
		{
			if (PlaylistManagerState.CurrentState != PlaylistManagerStates.Playing)
			{
				return;
			}
			if (_currentlyPlayingAudioSource.isPlaying)
			{
				if (FadeIn && FadeOut && CurrentTimeLeft < FadeDuration)
				{
					if (FadeOut)
					{
						Stop();
					}
					HandleNextSong(1, bypassLoop: false);
				}
			}
			else
			{
				HandleNextSong(1, bypassLoop: false);
			}
		}

		protected virtual void HandleNextSong(int direction, bool bypassLoop)
		{
			if (IsPlaying)
			{
				OnSongEnd?.Invoke();
			}
			int num = Playlist.PickNextIndex(direction, CurrentSongIndex, ref _queuedSongIndex, bypassLoop);
			if (num == -1)
			{
				ChangePlaylistManagerState(PlaylistManagerStates.Idle);
			}
			if (num == -2)
			{
				HandleEndOfPlaylist();
			}
			else if (num >= 0 && num < Playlist.Songs.Count)
			{
				PlaySongAt(num);
			}
		}

		protected virtual void HandleEndOfPlaylist()
		{
			OnPlaylistEnd?.Invoke();
			if (Playlist.NextPlaylist != null)
			{
				ChangePlaylistAndPlay(Playlist.NextPlaylist);
			}
			else
			{
				ChangePlaylistManagerState(PlaylistManagerStates.Idle);
			}
		}

		public virtual void Play()
		{
			switch (PlaylistManagerState.CurrentState)
			{
			case PlaylistManagerStates.Idle:
				PlayFirstSong();
				break;
			case PlaylistManagerStates.Paused:
				MMPersistentSingleton<MMSoundManager>.Instance.ResumeSound(_currentlyPlayingAudioSource);
				ChangePlaylistManagerState(PlaylistManagerStates.Playing);
				break;
			case PlaylistManagerStates.Playing:
				break;
			}
		}

		public virtual void PlaySongAt(int songIndex)
		{
			base.enabled = true;
			if (Playlist.Songs.Count != 0)
			{
				Stop();
				_options = Playlist.Songs[songIndex].Options;
				_options.MmSoundManagerTrack = Playlist.Track;
				_options.Volume *= VolumeMultiplier;
				_options.Pitch *= PitchMultiplier;
				_options.Persistent = Persistent;
				_currentlyPlayingAudioSource = MMSoundManagerSoundPlayEvent.Trigger(Playlist.Songs[songIndex].Clip, _options);
				OnSongStart?.Invoke();
				if (FadeIn)
				{
					MMPersistentSingleton<MMSoundManager>.Instance.FadeSound(_currentlyPlayingAudioSource, FadeDuration, 0f, _currentlyPlayingAudioSource.volume, FadeTween);
				}
				ChangePlaylistManagerState(PlaylistManagerStates.Playing);
				CurrentSongIndex = songIndex;
				CurrentClipDuration = _currentlyPlayingAudioSource.clip.length;
				CurrentSongName = Playlist.Songs[songIndex].Name;
				Playlist.Songs[songIndex].PlayCount++;
				Playlist.PlayCount++;
				MMPlaylistNewSongStartedEvent.Trigger(Channel);
			}
		}

		public virtual void Pause()
		{
			if (PlaylistManagerState.CurrentState == PlaylistManagerStates.Playing)
			{
				MMPersistentSingleton<MMSoundManager>.Instance.PauseSound(_currentlyPlayingAudioSource);
				ChangePlaylistManagerState(PlaylistManagerStates.Paused);
				OnPause?.Invoke();
			}
		}

		public virtual void Stop()
		{
			if (_currentlyPlayingAudioSource == null || !_currentlyPlayingAudioSource.isPlaying)
			{
				return;
			}
			if (FadeOut)
			{
				if (MMPersistentSingleton<MMSoundManager>.Instance.SoundIsFadingOut(_currentlyPlayingAudioSource))
				{
					return;
				}
				MMPersistentSingleton<MMSoundManager>.Instance.FadeSound(_currentlyPlayingAudioSource, FadeDuration, _currentlyPlayingAudioSource.volume, 0f, FadeTween, freeAfterFade: true);
			}
			else
			{
				MMPersistentSingleton<MMSoundManager>.Instance.FreeSound(_currentlyPlayingAudioSource);
			}
			ChangePlaylistManagerState(PlaylistManagerStates.Idle);
			OnStop?.Invoke();
		}

		public virtual void StopWithFade(bool withFade = true)
		{
			if (PlaylistManagerState.CurrentState != PlaylistManagerStates.Idle)
			{
				if (!withFade)
				{
					MMPersistentSingleton<MMSoundManager>.Instance.FreeSound(_currentlyPlayingAudioSource);
					OnStop?.Invoke();
				}
				else
				{
					Stop();
				}
				CurrentSongIndex = -1;
				ChangePlaylistManagerState(PlaylistManagerStates.Idle);
			}
		}

		public virtual void SetCurrentSongLoop(bool loop)
		{
			_currentlyPlayingAudioSource.loop = loop;
		}

		public virtual void PlayNextSong()
		{
			Stop();
			HandleNextSong(1, bypassLoop: true);
		}

		public virtual void PlayPreviousSong()
		{
			Stop();
			HandleNextSong(-1, bypassLoop: true);
		}

		public virtual void QueueSongAtIndex(int songIndex)
		{
			_queuedSongIndex = songIndex;
		}

		public virtual void ChangePlaylist(MMSMPlaylist newPlaylist)
		{
			Playlist = newPlaylist;
			Playlist.Initialization();
			CurrentSongIndex = -1;
			OnPlaylistChange?.Invoke();
		}

		public virtual void ChangePlaylistAndPlay(MMSMPlaylist newPlaylist)
		{
			ChangePlaylist(newPlaylist);
			PlayFirstSong();
		}

		public virtual void ResetPlayCount()
		{
			Playlist.ResetPlayCount();
		}

		public virtual void SetVolumeMultiplier(float newVolumeMultiplier)
		{
			float newVolumeMultiplier2 = Mathf.Clamp(newVolumeMultiplier, 0f, 2f);
			MMPlaylistVolumeMultiplierEvent.Trigger(Channel, newVolumeMultiplier2, applyVolumeMultiplierInstantly: true);
		}

		public virtual void SetPitchMultiplier(float newPitchMultiplier)
		{
			float newPitchMultiplier2 = Mathf.Clamp(newPitchMultiplier, 0f, 20f);
			MMPlaylistPitchMultiplierEvent.Trigger(Channel, newPitchMultiplier2, applyPitchMultiplierInstantly: true);
		}

		protected virtual void SetTargetPlaylist()
		{
			ChangePlaylist(TestPlaylist);
		}

		protected virtual void PlayTargetPlaylist()
		{
			ChangePlaylistAndPlay(TestPlaylist);
		}

		protected virtual void QueueTargetSong()
		{
			int songIndex = Mathf.Clamp(TargetSongIndex, 0, Playlist.Songs.Count - 1);
			QueueSongAtIndex(songIndex);
		}

		protected virtual void PlayTargetSong()
		{
			int songIndex = Mathf.Clamp(TargetSongIndex, 0, Playlist.Songs.Count - 1);
			PlaySongAt(songIndex);
		}

		protected virtual void SetCurrentSongToLoop()
		{
			SetCurrentSongLoop(loop: true);
		}

		protected virtual void StopCurrentSongFromLooping()
		{
			SetCurrentSongLoop(loop: false);
		}

		protected virtual void OnPlayEvent(int channel)
		{
			if (channel == Channel)
			{
				Play();
			}
		}

		protected virtual void OnPauseEvent(int channel)
		{
			if (channel == Channel)
			{
				Pause();
			}
		}

		protected virtual void OnStopEvent(int channel)
		{
			if (channel == Channel)
			{
				Stop();
			}
		}

		protected virtual void OnPlayNextEvent(int channel)
		{
			if (channel == Channel)
			{
				PlayNextSong();
			}
		}

		protected virtual void OnPlayPreviousEvent(int channel)
		{
			if (channel == Channel)
			{
				PlayPreviousSong();
			}
		}

		protected virtual void OnPlayIndexEvent(int channel, int index)
		{
			if (channel == Channel)
			{
				PlaySongAt(index);
			}
		}

		protected virtual void OnMMPlaylistVolumeMultiplierEvent(int channel, float newVolumeMultiplier, bool applyVolumeMultiplierInstantly = false)
		{
			if (channel == Channel && CurrentSongIndex >= 0)
			{
				VolumeMultiplier = newVolumeMultiplier;
				if (applyVolumeMultiplierInstantly)
				{
					_currentlyPlayingAudioSource.volume = Playlist.Songs[CurrentSongIndex].Options.Volume * VolumeMultiplier;
				}
			}
		}

		protected virtual void OnMMPlaylistPitchMultiplierEvent(int channel, float newPitchMultiplier, bool applyPitchMultiplierInstantly = false)
		{
			if (channel == Channel && CurrentSongIndex >= 0)
			{
				PitchMultiplier = newPitchMultiplier;
				if (applyPitchMultiplierInstantly)
				{
					_currentlyPlayingAudioSource.pitch = Playlist.Songs[CurrentSongIndex].Options.Pitch * PitchMultiplier;
				}
			}
		}

		protected virtual void OnMMPlaylistChangeEvent(int channel, MMSMPlaylist newPlaylist, bool andPlay)
		{
			if (channel == Channel)
			{
				if (andPlay)
				{
					ChangePlaylistAndPlay(newPlaylist);
				}
				else
				{
					ChangePlaylist(newPlaylist);
				}
			}
		}

		public virtual void StartListening()
		{
			_listeningToEvents = true;
			MMPlaylistPauseEvent.Register(OnPauseEvent);
			MMPlaylistPlayEvent.Register(OnPlayEvent);
			MMPlaylistPlayNextEvent.Register(OnPlayNextEvent);
			MMPlaylistPlayPreviousEvent.Register(OnPlayPreviousEvent);
			MMPlaylistStopEvent.Register(OnStopEvent);
			MMPlaylistPlayIndexEvent.Register(OnPlayIndexEvent);
			MMPlaylistVolumeMultiplierEvent.Register(OnMMPlaylistVolumeMultiplierEvent);
			MMPlaylistPitchMultiplierEvent.Register(OnMMPlaylistPitchMultiplierEvent);
			MMPlaylistChangeEvent.Register(OnMMPlaylistChangeEvent);
		}

		public virtual void StopListening()
		{
			_listeningToEvents = false;
			MMPlaylistPauseEvent.Unregister(OnPauseEvent);
			MMPlaylistPlayEvent.Unregister(OnPlayEvent);
			MMPlaylistPlayNextEvent.Unregister(OnPlayNextEvent);
			MMPlaylistPlayPreviousEvent.Unregister(OnPlayPreviousEvent);
			MMPlaylistStopEvent.Unregister(OnStopEvent);
			MMPlaylistPlayIndexEvent.Unregister(OnPlayIndexEvent);
			MMPlaylistVolumeMultiplierEvent.Unregister(OnMMPlaylistVolumeMultiplierEvent);
			MMPlaylistPitchMultiplierEvent.Unregister(OnMMPlaylistPitchMultiplierEvent);
			MMPlaylistChangeEvent.Unregister(OnMMPlaylistChangeEvent);
		}

		protected virtual void OnDestroy()
		{
			StopListening();
		}

		protected virtual void OnApplicationPause(bool pauseStatus)
		{
			if (AutoHandleApplicationPause)
			{
				if (pauseStatus && PlaylistManagerState.CurrentState == PlaylistManagerStates.Playing)
				{
					Pause();
					_shouldResumeOnApplicationPause = true;
				}
				if (!pauseStatus && _shouldResumeOnApplicationPause)
				{
					_shouldResumeOnApplicationPause = false;
					Play();
				}
			}
		}
	}
}
