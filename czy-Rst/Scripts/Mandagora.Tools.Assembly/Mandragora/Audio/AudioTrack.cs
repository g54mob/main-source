using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Mandragora.Audio
{
	[RequireComponent(typeof(AudioSource))]
	public abstract class AudioTrack : MonoBehaviour
	{
		public string soundName;

		public AudioThread thread;

		private Action<string> _onDestroyAction;

		private AudioSource _audioSource;

		private float _volume;

		public float _time;

		private bool _isLoop;

		private string _name;

		private List<AudioClip> _clipList = new List<AudioClip>();

		public bool _isPlaying;

		public float volume
		{
			get
			{
				return _volume;
			}
			private set
			{
				_volume = value;
				if (audioSource != null)
				{
					audioSource.volume = _volume;
				}
			}
		}

		protected AudioSource audioSource
		{
			get
			{
				if (this == null || base.gameObject == null)
				{
					return null;
				}
				if (_audioSource == null)
				{
					_audioSource = GetComponent<AudioSource>();
				}
				return _audioSource;
			}
		}

		public void Add(AudioClip clip, AudioMixerGroup mixer, bool isLoop = false, float currentVolume = 1f, Action<string> onDestroy = null)
		{
			if (audioSource != null)
			{
				audioSource.outputAudioMixerGroup = mixer;
				if (onDestroy != null)
				{
					_onDestroyAction = (Action<string>)Delegate.Remove(_onDestroyAction, onDestroy);
					_onDestroyAction = (Action<string>)Delegate.Combine(_onDestroyAction, onDestroy);
				}
				_clipList.Add(clip);
				_isLoop = isLoop;
				volume = currentVolume;
			}
		}

		public void Play()
		{
			if (audioSource != null && _clipList.Count > 0)
			{
				audioSource.clip = _clipList[0];
				if (!_isLoop)
				{
					_clipList.RemoveAt(0);
				}
				_isPlaying = true;
				if (audioSource.clip != null)
				{
					_time = audioSource.clip.length;
					audioSource.Play();
				}
			}
		}

		public void Pause(AudioThread thread = AudioThread.baseThread)
		{
			if (audioSource != null && this.thread == thread)
			{
				audioSource.Pause();
				_isPlaying = false;
			}
		}

		public void UnPause(AudioThread thread = AudioThread.baseThread)
		{
			if (audioSource != null && this.thread == thread)
			{
				audioSource.UnPause();
				_isPlaying = true;
			}
		}

		public void Stop(AudioThread thread = AudioThread.baseThread)
		{
			if (audioSource != null && this.thread == thread)
			{
				audioSource.Stop();
				_isPlaying = false;
			}
		}

		private void Update()
		{
			if (!(audioSource == null) && _isPlaying)
			{
				if (_time > 0f)
				{
					_time -= Time.deltaTime;
				}
				else if (_clipList.Count > 0)
				{
					Play();
				}
				else
				{
					Remove();
				}
			}
		}

		public void OnDestroyAction()
		{
			if (_onDestroyAction != null)
			{
				_onDestroyAction(soundName);
				_onDestroyAction = null;
			}
		}

		protected virtual void Remove()
		{
		}
	}
}
