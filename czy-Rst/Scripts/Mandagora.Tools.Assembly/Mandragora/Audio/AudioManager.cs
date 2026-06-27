using System;
using Helpers.Singletons;
using UnityEngine;
using UnityEngine.Audio;

namespace Mandragora.Audio
{
	[Obsolete("Whole Audio management moved to AudioFMODManager", false)]
	[RequireComponent(typeof(AudioListener))]
	public class AudioManager : SingletonBehaviour<AudioManager>
	{
		private AudioSystem _music = new AudioSystem();

		private AudioSystem _sound = new AudioSystem();

		private AudioMixerGroup _musicMixerGroup;

		private AudioMixerGroup _soundMixerGroup;

		private string[] _currentMusicList;

		private string[] _currentSoundList;

		protected override void Awake()
		{
			base.Awake();
		}

		public AudioTrack PlaySound(string soundName, bool loop = false, float volume = 0.8f, bool isReplace = false, AudioThread thread = AudioThread.baseThread, Action<string> onDestroy = null)
		{
			string[] soundNames = new string[1] { soundName };
			return PlaySound(soundNames, loop, volume, isReplace, thread, onDestroy);
		}

		public AudioTrack PlaySound(string[] soundNames, bool loop = false, float volume = 1f, bool isReplace = false, AudioThread thread = AudioThread.baseThread, Action<string> onDestroy = null)
		{
			if (ArraysEqual(_currentSoundList, soundNames) && !isReplace)
			{
				return null;
			}
			if (soundNames.Length != 0)
			{
				_currentSoundList = soundNames;
				AudioTrack audioTrack = _sound.Add<SoundTrack>(soundNames[0], loop, volume, dontDestroyOnLoad: false);
				audioTrack.thread = thread;
				audioTrack.soundName = soundNames[0];
				for (int i = 0; i < soundNames.Length; i++)
				{
					audioTrack.Add(_sound.Get("sound/fx/" + soundNames[i]), _soundMixerGroup, loop, volume, onDestroy);
				}
				audioTrack.Play();
				return audioTrack;
			}
			return null;
		}

		public AudioTrack PlayMusic(string soundName, bool loop = false, float volume = 1f, bool isReplace = false, AudioThread thread = AudioThread.baseThread, Action<string> onDestroy = null)
		{
			string[] soundNames = new string[1] { soundName };
			return PlayMusic(soundNames, loop, volume, isReplace, thread, onDestroy);
		}

		public AudioTrack PlayMusic(string[] soundNames, bool loop = false, float volume = 1f, bool isReplace = false, AudioThread thread = AudioThread.baseThread, Action<string> onDestroy = null)
		{
			if (ArraysEqual(_currentMusicList, soundNames) && !isReplace)
			{
				return null;
			}
			if (soundNames.Length != 0)
			{
				_currentMusicList = soundNames;
				_music.Clear();
				AudioTrack audioTrack = _music.Add<MusicTrack>(soundNames[0], loop, volume, dontDestroyOnLoad: true);
				audioTrack.thread = thread;
				audioTrack.soundName = soundNames[0];
				for (int i = 0; i < soundNames.Length; i++)
				{
					audioTrack.Add(_music.Get("sound/music/" + soundNames[i]), _musicMixerGroup, loop, volume, onDestroy);
				}
				audioTrack.Play();
				return audioTrack;
			}
			return null;
		}

		public bool ArraysEqual(string[] a, string[] b)
		{
			if (a == null || b == null)
			{
				return false;
			}
			if (a.Length == b.Length && a.Length != 0)
			{
				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] != b[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public void RemoveMusic(MusicTrack track)
		{
			if (_currentMusicList != null && _currentMusicList.Length != 0 && _currentMusicList[0] == track.name)
			{
				_currentMusicList = null;
			}
			_music.Remove(track);
			UnityEngine.Object.Destroy(track.gameObject);
		}

		public void RemoveSound(SoundTrack track)
		{
			if (!(track == null))
			{
				if (_currentSoundList != null && _currentSoundList.Length != 0 && _currentSoundList[0] == track.name)
				{
					_currentSoundList = null;
				}
				_sound.Remove(track);
				UnityEngine.Object.Destroy(track.gameObject);
			}
		}

		public void StopAndClearAll()
		{
			_currentMusicList = null;
			_sound.Stop();
			_music.Stop();
			_sound.Clear();
			_music.Clear();
		}

		public void PauseAll(AudioThread thread = AudioThread.baseThread)
		{
			PauseSounds(thread);
			PauseMusic(thread);
		}

		public void UnPauseAll(AudioThread thread = AudioThread.baseThread)
		{
			UnPauseSounds(thread);
			UnPauseMusic(thread);
		}

		public void PauseSounds(AudioThread thread = AudioThread.baseThread)
		{
			_sound.Pause(thread);
		}

		public void PauseMusic(AudioThread thread = AudioThread.baseThread)
		{
			_music.Pause(thread);
		}

		public void UnPauseSounds(AudioThread thread = AudioThread.baseThread)
		{
			_sound.UnPause(thread);
		}

		public void UnPauseMusic(AudioThread thread = AudioThread.baseThread)
		{
			_music.UnPause(thread);
		}

		public void SetSoundLowpass(float value)
		{
			value = Mathf.Clamp(value, 10f, 22000f);
			_soundMixerGroup.audioMixer.SetFloat("lowpass", value);
		}

		public void SetMusicLowpass(float value)
		{
			value = Mathf.Clamp(value, 10f, 22000f);
			_musicMixerGroup.audioMixer.SetFloat("lowpass", value);
		}
	}
}
