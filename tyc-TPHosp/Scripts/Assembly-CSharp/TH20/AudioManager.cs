#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using UnityConsole;
using UnityEngine;
using UnityEngine.Profiling;

namespace TH20
{
	public class AudioManager
	{
		private readonly AudioManagerConfig _config;

		private readonly VOManager _voManager;

		private readonly Dictionary<string, AudioEvent> _audioEvents = new Dictionary<string, AudioEvent>();

		private readonly List<AudioEmitter> _activeEmitters = new List<AudioEmitter>();

		private readonly Dictionary<string, int> _bankReferenceCounts = new Dictionary<string, int>();

		private AudioEmitter _musicEmitter;

		private string _currentMusicEvent;

		private readonly Queue<string> _musicQueue = new Queue<string>();

		private const string AudioEventSeparator = ":";

		public readonly GameObject GameObject;

		private CustomSampler _playSampler;

		private CustomSampler _getSoundForEventSampler;

		private List<AudioEmitter> _emitterPool = new List<AudioEmitter>(128);

		public static AudioManager Instance { get; private set; }

		public static VOManager VOManager => Instance._voManager;

		public static string MakeEvent(string s1, params object[] vars)
		{
			string text = s1.ToUpper();
			for (int i = 0; i < vars.Length; i++)
			{
				string text2 = vars[i] as string;
				if (!string.IsNullOrEmpty(text2))
				{
					text += ":";
					text += text2.ToUpper();
				}
			}
			return text;
		}

		public AudioManager(Preferences preferences, AudioManagerConfig config)
		{
			_config = config;
			_playSampler = CustomSampler.Create("AudioManager.Play");
			_getSoundForEventSampler = CustomSampler.Create("AudioManager.GetSoundForEvent");
			_voManager = new VOManager(preferences, config);
			GameObject = new GameObject("AudioManager");
			Instance = this;
			for (int i = 0; i < 128; i++)
			{
				AudioEmitter audioEmitter = AudioEmitter.Create(null, null);
				audioEmitter.gameObject.SetActive(value: false);
				_emitterPool.Add(audioEmitter);
			}
			ConsoleCommandsDatabase.RegisterCommand("PlayAudioEvent", "Triggers an audio event", "PlayAudioEvent eventName", Debug_PlayAudioEvent);
		}

		public void Destroy()
		{
			_voManager.Destroy();
		}

		public void PlayMusic(string eventName)
		{
			StopMusic();
			Instance._currentMusicEvent = eventName;
		}

		public void QueueMusic(string eventName)
		{
			Instance._musicQueue.Enqueue(eventName);
		}

		public void StopMusic()
		{
			_musicQueue.Clear();
			if ((bool)_musicEmitter)
			{
				_musicEmitter.Stop();
				_musicEmitter = null;
			}
		}

		public void StopEmittersWhere(Func<AudioEmitter, bool> remove)
		{
			for (int i = 0; i < _activeEmitters.Count; i++)
			{
				AudioEmitter audioEmitter = _activeEmitters[i];
				if (remove(audioEmitter))
				{
					audioEmitter.Stop(playOutro: false);
				}
			}
		}

		public void Update()
		{
			if (_musicQueue.Count > 0 && string.IsNullOrEmpty(_currentMusicEvent))
			{
				PlayMusic(_musicQueue.Dequeue());
			}
			for (int i = 0; i < _activeEmitters.Count; i++)
			{
				AudioEmitter audioEmitter = _activeEmitters[i];
				if (audioEmitter.Finished)
				{
					audioEmitter.gameObject.SetActive(value: false);
					_emitterPool.Add(audioEmitter);
					_activeEmitters.RemoveAt(i);
					i--;
				}
			}
		}

		public void PlayTemp(string audioEventName)
		{
			Play(audioEventName);
		}

		public AudioEmitter Play(string audioEventName, GameObject source = null)
		{
			if (string.IsNullOrEmpty(audioEventName))
			{
				return null;
			}
			if (source == null)
			{
				source = GameObject;
			}
			if (_config.LogAllEvents)
			{
				Logging.Info(source, LogChannels.Audio, "Trying event '{0}' (source = '{1}')", audioEventName, source.name);
			}
			AudioEvent soundForEvent = GetSoundForEvent(audioEventName, _audioEvents, _config.LogLookups);
			if (soundForEvent != null && soundForEvent.Clips.Count > 0)
			{
				AudioEmitter audioEmitter;
				if (_emitterPool.Count > 0)
				{
					audioEmitter = _emitterPool[0];
					audioEmitter.gameObject.SetActive(value: true);
					AudioEmitter.SetupAudioEmitter(audioEmitter, source.transform, soundForEvent);
					_emitterPool.RemoveAt(0);
				}
				else
				{
					audioEmitter = AudioEmitter.Create(source.transform, soundForEvent);
				}
				audioEmitter.Play();
				_activeEmitters.Add(audioEmitter);
				return audioEmitter;
			}
			_ = _config.LogMissingEvents;
			return null;
		}

		public void Stop(AudioEmitter emitter, bool playOutro = true)
		{
			if (emitter != null)
			{
				emitter.Stop(playOutro);
			}
		}

		public bool DoesSoundEventExist(string audioEventName)
		{
			return GetSoundForEvent(audioEventName, _audioEvents, logLookups: false) != null;
		}

		private static AudioEvent GetSoundForEvent(string audioEventName, Dictionary<string, AudioEvent> audioEvents, bool logLookups)
		{
			if (logLookups)
			{
				Logging.Info(LogChannels.Audio, "Looking for sound event {0}", audioEventName);
			}
			while (!string.IsNullOrEmpty(audioEventName))
			{
				if (audioEvents.TryGetValue(audioEventName, out var value))
				{
					if (logLookups)
					{
						Logging.Info(LogChannels.Audio, "Found sound event {0}", audioEventName);
					}
					return value;
				}
				audioEventName = SplitAudioEventName(audioEventName);
			}
			return null;
		}

		public static AudioEvent GetSoundForEvent(string audioEventName, List<AudioEvent> audioEvents, bool logLookups)
		{
			if (logLookups)
			{
				Logging.Info(LogChannels.Audio, "Looking for sound event {0}", audioEventName);
			}
			while (!string.IsNullOrEmpty(audioEventName))
			{
				AudioEvent audioEvent = audioEvents.Find((AudioEvent ae) => ae.EventName == audioEventName);
				if (audioEvent != null)
				{
					if (logLookups)
					{
						Logging.Info(LogChannels.Audio, "Found sound event {0}", audioEventName);
					}
					return audioEvent;
				}
				audioEventName = SplitAudioEventName(audioEventName);
			}
			return null;
		}

		private static string SplitAudioEventName(string audioEventName)
		{
			int num = audioEventName.LastIndexOf(":", StringComparison.InvariantCulture);
			if (num > 0 && num < audioEventName.Length - 1)
			{
				return audioEventName.Substring(0, num);
			}
			return null;
		}

		public void LoadEventBank(string bankName)
		{
			if (_bankReferenceCounts.ContainsKey(bankName))
			{
				_bankReferenceCounts[bankName]++;
				return;
			}
			_bankReferenceCounts[bankName] = 1;
			AudioEventBank audioEventBank = Resources.Load(bankName, typeof(AudioEventBank)) as AudioEventBank;
			if (audioEventBank == null)
			{
				Logging.Error(LogChannels.Audio, "Failed to load audio bank {0}", bankName);
				return;
			}
			if (_config.LogBankLoads)
			{
				Logging.Info(LogChannels.Audio, "Loading bank {0}", bankName);
			}
			foreach (AudioEvent audioEvent in audioEventBank.AudioEvents)
			{
				if (_audioEvents.ContainsKey(audioEvent.EventName))
				{
					Logging.Error("{0} Audio Bank trying to load {1} audio event when it already exists in {2}", bankName, audioEvent.EventName, _audioEvents[audioEvent.EventName].BankName);
				}
				audioEvent.BankName = bankName;
				_audioEvents[audioEvent.EventName] = audioEvent;
			}
		}

		public void UnloadEventBank(string bankName)
		{
			if (!_bankReferenceCounts.ContainsKey(bankName))
			{
				return;
			}
			_bankReferenceCounts[bankName]--;
			if (_bankReferenceCounts[bankName] > 0)
			{
				return;
			}
			_bankReferenceCounts.Remove(bankName);
			Logging.Info(LogChannels.Audio, "AudioManager: Unload bank {0}", bankName);
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, AudioEvent> audioEvent in _audioEvents)
			{
				if (audioEvent.Value.BankName == bankName)
				{
					list.Add(audioEvent.Key);
				}
			}
			foreach (string item in list)
			{
				_audioEvents.Remove(item);
			}
		}

		private ConsoleCommandResult Debug_PlayAudioEvent(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Need eventName parameter");
			}
			Play(args[0]);
			return ConsoleCommandResult.Succeeded();
		}

		public void Refresh(Preferences userPreferences)
		{
			_voManager.Refresh(userPreferences);
		}
	}
}
