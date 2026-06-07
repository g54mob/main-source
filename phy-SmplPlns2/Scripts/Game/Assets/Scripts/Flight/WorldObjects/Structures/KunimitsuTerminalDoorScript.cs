using System;
using Assets.Scripts.Audio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Structures
{
	public class KunimitsuTerminalDoorScript : MonoBehaviour, INetworkTriggerStateTarget
	{
		[SerializeField]
		private float _openDuration = 20f;

		[SerializeField]
		private AudioClip _sound;

		[SerializeField]
		private float _soundPitch = 1f;

		[SerializeField]
		private float _soundScale = 1f;

		[SerializeField]
		private AudioClip _soundEnd;

		[SerializeField]
		private AudioClip _soundStart;

		private AudioSource _source;

		private AudioSource _sourceEnd;

		private AudioSource _sourceStart;

		private float _openPercentage;

		private KunimitsuTerminalDoorSectionScript[] _sections;

		private int _state;

		private TweenerCore<float, float, FloatOptions> _tween;

		public bool IsOpen { get; private set; }

		private float OpenPercentage
		{
			get
			{
				return _openPercentage;
			}
			set
			{
				_openPercentage = value;
				KunimitsuTerminalDoorSectionScript[] sections = _sections;
				for (int i = 0; i < sections.Length; i++)
				{
					sections[i].OpenPercentage = value;
				}
			}
		}

		public event Action Opened;

		public void SetState(int state, bool initialState)
		{
			if (_state != state)
			{
				_state = state;
				if (_state == 1)
				{
					Open();
				}
				else
				{
					Close();
				}
			}
		}

		protected void Awake()
		{
			_sections = GetComponentsInChildren<KunimitsuTerminalDoorSectionScript>();
			if (_soundStart != null && _sourceStart == null)
			{
				_sourceStart = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_sourceStart, AudioStore.HangarDoorAudio, _soundStart, loop: false);
				_sourceStart.volume *= _soundScale;
				_sourceStart.minDistance *= _soundScale;
				_sourceStart.maxDistance *= _soundScale;
			}
			if (_soundEnd != null && _sourceEnd == null)
			{
				_sourceEnd = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_sourceEnd, AudioStore.HangarDoorAudio, _soundEnd, loop: false);
				_sourceEnd.volume *= _soundScale;
				_sourceEnd.minDistance *= _soundScale;
				_sourceEnd.maxDistance *= _soundScale;
			}
			if (_sound != null && _source == null)
			{
				_source = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_source, AudioStore.HangarDoorAudio, _sound);
				_source.pitch = _soundPitch;
				_source.volume *= _soundScale;
				_source.minDistance *= _soundScale;
				_source.maxDistance *= _soundScale;
			}
		}

		private void AnimateDoors(float openPercentage)
		{
			_tween?.Kill();
			_tween = DOTween.To(() => OpenPercentage, delegate(float x)
			{
				OpenPercentage = x;
			}, openPercentage, _openDuration).SetEase(Ease.Linear).SetLink(base.gameObject);
			AudioStart();
			TweenerCore<float, float, FloatOptions> tween = _tween;
			tween.onComplete = (TweenCallback)Delegate.Combine(tween.onComplete, new TweenCallback(AudioEnd));
		}

		private void AudioEnd()
		{
			if (_source != null)
			{
				_source.Stop();
			}
			if (_sourceEnd != null)
			{
				_sourceEnd.Play();
			}
			TweenerCore<float, float, FloatOptions> tween = _tween;
			tween.onComplete = (TweenCallback)Delegate.Remove(tween.onComplete, new TweenCallback(AudioEnd));
		}

		private void AudioStart()
		{
			if (_sourceStart != null)
			{
				_sourceStart.Play();
			}
			if (_source != null)
			{
				_source.timeSamples = (int)(UnityEngine.Random.value * (float)_source.clip.samples);
				_source.Play();
			}
		}

		[ContextMenu("Close Doors")]
		private void Close()
		{
			IsOpen = false;
			AnimateDoors(0f);
		}

		[ContextMenu("Open Doors")]
		private void Open()
		{
			IsOpen = true;
			AnimateDoors(1f);
			this.Opened?.Invoke();
		}
	}
}
