#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class Radio : MustCallDestroy, IGameEventsBase
	{
		public static Action<RadioDJQuote, bool> OnQueueDJQuoteRequest;

		public Action<RadioSong> OnSongStarted;

		public Action<RadioDJQuote> OnDJStarted;

		private readonly RadioConfig _config;

		private readonly RadioStatus _radioStatus;

		private readonly Level _level;

		private readonly AudioSource _songSource;

		private readonly AudioSource _djSource;

		private AudioSource _mainSource;

		private RadioPlaylistItem _currentPlaylistItem;

		private RadioSong _lastPlayedRadioSong;

		private float _lastSongFadeOutTimer;

		private float _lastSongFadeOutDuration;

		private float _targetVolumeSong;

		private float _targetVolumeDJ;

		private RadioDJQuote _lineInjection;

		public bool SongIsSolo
		{
			get
			{
				if (_songSource != null && _songSource.isPlaying)
				{
					if (!(_djSource == null))
					{
						return !_djSource.isPlaying;
					}
					return true;
				}
				return false;
			}
		}

		public bool DJIsSolo
		{
			get
			{
				if (_djSource != null && _djSource.isPlaying)
				{
					if (!(_songSource == null))
					{
						return !_songSource.isPlaying;
					}
					return true;
				}
				return false;
			}
		}

		public bool CanSkipToEnd
		{
			get
			{
				if (!SongIsSolo)
				{
					return DJIsSolo;
				}
				return true;
			}
		}

		public Radio(Level level, RadioConfig config)
		{
			_level = level;
			_config = config;
			_radioStatus = level.Metagame.RadioStatus;
			GameObject gameObject = new GameObject("Radio");
			_songSource = gameObject.AddComponent<AudioSource>();
			_songSource.spatialize = false;
			_songSource.volume = 1f;
			_songSource.outputAudioMixerGroup = _config.LevelMusicAudioMixerGroup;
			_songSource.priority = 0;
			_djSource = gameObject.AddComponent<AudioSource>();
			_djSource.spatialize = false;
			_djSource.volume = 1f;
			_djSource.outputAudioMixerGroup = _config.DJAudioMixerGroup;
			_djSource.priority = 1;
			if (_config != null && _level != null)
			{
				float pitch = 1f;
				foreach (LevelPitchOverride levelSongPitchOverride in _config.LevelSongPitchOverrides)
				{
					if (!(levelSongPitchOverride.LevelConfig == null) && _level.Config == levelSongPitchOverride.LevelConfig.Instance)
					{
						pitch = levelSongPitchOverride.PitchOverride;
						break;
					}
				}
				_songSource.pitch = pitch;
			}
			ConsoleCommandsDatabase.RegisterCommand("RadioSkipToEnd", "Skips to the last 10 seconds of a song.", "RadioSkipToEnd", Debug_SkipToEnd);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("RadioSkipToEnd");
			CheckNotifyLastRadioSongFinished();
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnQueueDJQuoteRequest.VerifyIsNull();
			OnSongStarted.VerifyIsNull();
			OnDJStarted.VerifyIsNull();
		}

		public void Start()
		{
		}

		public void Update(float timeDelta, bool bInLevel = true)
		{
			if (bInLevel)
			{
				if (!_level.HospitalAudioMixerManager.IsMusicMixerPlaying)
				{
					return;
				}
				if (_mainSource == null)
				{
					_level.App.DynamicPlaylistManager.Level = _level;
					_currentPlaylistItem = GetNextPlaylistItem();
					Logging.Info(LogChannels.Gameplay, "[RADIO]: Radio gets a new item as there is no track playing");
					Play(_currentPlaylistItem);
					_songSource.volume = 0f;
					_djSource.volume = 0f;
					return;
				}
				if (_mainSource.clip != null && !_level.TannoyManager.IsAnnouncing() && !_level.AwardCeremonyInProgress)
				{
					bool buttonDown = _level.InputManager.GetButtonDown(48);
					float num = _mainSource.clip.length - _mainSource.time;
					if (num <= _currentPlaylistItem.LeadOutTime || !_mainSource.isPlaying || buttonDown)
					{
						Logging.Info(LogChannels.Gameplay, "Radio gets a new item to play, as lead-out time is now {0}", num);
						_currentPlaylistItem = GetNextPlaylistItem();
						Play(_currentPlaylistItem);
					}
				}
				_targetVolumeSong = 1f;
				_targetVolumeDJ = 1f;
				if (_level.App.LoadSaveProgressScreen.IsVisible)
				{
					_targetVolumeSong = 0f;
					_targetVolumeDJ = _targetVolumeSong;
				}
				else if (_level.NotificationAudioExclusiveMode)
				{
					_targetVolumeSong = _config.VolumeMultiplierDuringNotificationAudioExclusiveMode;
					_targetVolumeDJ = _config.VolumeMultiplierDuringNotificationAudioExclusiveMode;
				}
				else if (_level.AwardCeremonyInProgress)
				{
					_targetVolumeSong = _config.VolumeMultiplierDuringAwardCeremony;
				}
				else if (_djSource.isPlaying)
				{
					float dJVolumeFactor = _level.HospitalAudioMixerManager.GetDJVolumeFactor();
					_targetVolumeSong = 1f - (1f - _config.VolumeMultiplierDuringDJQuote) * dJVolumeFactor;
				}
				else if (_level.TannoyManager.IsAnnouncing())
				{
					float tannoyVolumeFactor = _level.HospitalAudioMixerManager.GetTannoyVolumeFactor();
					_targetVolumeSong = 1f - (1f - _config.VolumeMultiplierDuringTannoyAnnouncement) * tannoyVolumeFactor;
				}
				if (_lastSongFadeOutTimer > 0f)
				{
					_targetVolumeSong *= _lastSongFadeOutTimer / _lastSongFadeOutDuration;
					_lastSongFadeOutTimer -= Time.unscaledDeltaTime;
					if (_lastSongFadeOutTimer <= 0f)
					{
						_lastSongFadeOutTimer = 0f;
						CheckNotifyLastRadioSongFinished();
					}
				}
			}
			else
			{
				_targetVolumeSong = 0f;
				_targetVolumeDJ = 0f;
			}
			float num2;
			float num3;
			if (_songSource != null)
			{
				num2 = _targetVolumeSong - _songSource.volume;
				num3 = Mathf.Abs(num2);
				if (num3 > 0f)
				{
					if (num3 > _config.VolumeChangeStep)
					{
						num3 = _config.VolumeChangeStep;
					}
					float num4 = ((num2 >= 0f) ? 1f : (-1f));
					_songSource.volume += num3 * num4;
				}
			}
			if (!(_djSource != null))
			{
				return;
			}
			num2 = _targetVolumeDJ - _djSource.volume;
			num3 = Mathf.Abs(num2);
			if (num3 > 0f)
			{
				if (num3 > _config.VolumeChangeStep)
				{
					num3 = _config.VolumeChangeStep;
				}
				float num5 = ((num2 >= 0f) ? 1f : (-1f));
				_djSource.volume += num3 * num5;
			}
		}

		private void Play(RadioPlaylistItem item)
		{
			CheckNotifyLastRadioSongFinishing();
			if (item is RadioSong)
			{
				CheckNotifyLastRadioSongFinished();
				_songSource.clip = item.LocalisedClip;
				_songSource.loop = false;
				_songSource.time = 0f;
				_songSource.Play();
				_mainSource = _songSource;
				_lastPlayedRadioSong = item as RadioSong;
				_lastSongFadeOutTimer = 0f;
				Logging.Info(LogChannels.Gameplay, "Start playing Radio Song {0}", ((RadioSong)item).SongNameLoc.Translation);
				OnSongStarted.InvokeSafe((RadioSong)item);
				OnAudioSourceSongStarted(_songSource, _lastPlayedRadioSong);
			}
			else if (item is RadioDJQuote)
			{
				_djSource.clip = item.LocalisedClip;
				_djSource.loop = false;
				_djSource.time = 0f;
				_djSource.Play();
				_mainSource = _djSource;
				RadioDJQuote radioDJQuote = (RadioDJQuote)item;
				if (radioDJQuote.Session != null && radioDJQuote.Session.DJ != null)
				{
					Logging.Info(LogChannels.Gameplay, "Start playing Radio DJ Quote {0}", ((RadioDJQuote)item).Session.DJ.Name);
				}
				else
				{
					Logging.Info(LogChannels.Gameplay, "Start playing Line Injection");
				}
				OnDJStarted.InvokeSafe((RadioDJQuote)item);
			}
		}

		private RadioPlaylistItem GetNextPlaylistItem()
		{
			RadioPlaylistItem radioPlaylistItem = null;
			if (_currentPlaylistItem == null || _currentPlaylistItem is RadioDJQuote || Mathf.Approximately(Time.timeScale, 0f))
			{
				CheckNotifyLastRadioSongFinished();
				return _radioStatus.GetNextSong();
			}
			if (_lineInjection != null)
			{
				RadioDJQuote lineInjection = _lineInjection;
				_lineInjection = null;
				return lineInjection;
			}
			return _radioStatus.GetNextQuote();
		}

		public void SuggestLineInjection(Dictionary<RadioDJDefinition, RadioDJQuote> lineInjectionDictionary)
		{
			Logging.Info(LogChannels.Gameplay, "Suggesting a Line Injection for the radio");
			if (lineInjectionDictionary != null && _radioStatus.IsLineInjectionAllowed())
			{
				RadioDJDefinition currentDJ = _radioStatus.CurrentDJ;
				if (currentDJ != null)
				{
					lineInjectionDictionary.TryGetValue(currentDJ, out _lineInjection);
					Logging.Info(LogChannels.Gameplay, "Radio line injection successful. {0} to read line injection on next quote.", currentDJ.Name);
				}
			}
		}

		public bool IsDJTalking()
		{
			if (_djSource.clip != null)
			{
				return _djSource.isPlaying;
			}
			return false;
		}

		private void CheckNotifyLastRadioSongFinishing()
		{
			if (_lastPlayedRadioSong != null)
			{
				OnAudioSourceSongFinishing(_songSource, _lastPlayedRadioSong);
				_lastSongFadeOutDuration = Mathf.Clamp(_lastPlayedRadioSong.LeadOutTime, 0f, 5f);
				_lastSongFadeOutTimer = _lastSongFadeOutDuration;
			}
		}

		private void CheckNotifyLastRadioSongFinished()
		{
			if (_songSource.isPlaying)
			{
				_songSource.Stop();
			}
			if (_lastPlayedRadioSong != null)
			{
				OnAudioSourceSongFinished(_songSource, _lastPlayedRadioSong);
				_lastPlayedRadioSong = null;
			}
		}

		private void OnAudioSourceSongStarted(AudioSource songAudioSource, RadioSong radioSong)
		{
			_radioStatus.NotifyAudioSourceSongStarted(songAudioSource, radioSong);
		}

		private void OnAudioSourceSongFinishing(AudioSource songAudioSource, RadioSong radioSong)
		{
			_radioStatus.NotifyAudioSourceSongFinishing(songAudioSource, radioSong);
		}

		private void OnAudioSourceSongFinished(AudioSource songAudioSource, RadioSong radioSong)
		{
			_radioStatus.NotifyAudioSourceSongFinished(songAudioSource, radioSong);
		}

		public void SkipToEnd(float timeFromEnd)
		{
			if (_mainSource != null && _mainSource.clip != null && !(_mainSource.clip.length - _mainSource.time <= timeFromEnd))
			{
				_mainSource.time = _mainSource.clip.length - timeFromEnd;
			}
		}

		private ConsoleCommandResult Debug_SkipToEnd(string[] args)
		{
			if (!CanSkipToEnd)
			{
				return ConsoleCommandResult.Failed("Can't skip because we are crossfading...");
			}
			SkipToEnd(10f);
			return ConsoleCommandResult.Succeeded();
		}
	}
}
