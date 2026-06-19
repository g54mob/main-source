using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[ExecuteInEditMode]
	public class TH20ViewerAnimationEventListener : MonoBehaviour
	{
		private class LoopingAudioSources
		{
			public AudioSource Intro;

			public AudioSource Main;

			public AudioEvent AudioEvent;
		}

		[SerializeField]
		private AudioEventBank _audioEventBank;

		private List<AudioSource> _audioSources = new List<AudioSource>();

		private List<AudioSource> _claimedAudioSources = new List<AudioSource>();

		private Dictionary<string, LoopingAudioSources> _loopingAudioPlayers = new Dictionary<string, LoopingAudioSources>();

		private bool stopThisFrame;

		public bool IgnoreInvokeAudioEvent;

		public Character.Sex Sex;

		private AudioSource GetAvailableAudioSource()
		{
			AudioSource audioSource = _audioSources.Find((AudioSource s) => !s.isPlaying && !_claimedAudioSources.Contains(s));
			if (audioSource == null)
			{
				audioSource = AudioEditorUtils.CreateAudioPlayer();
				_audioSources.Add(audioSource);
			}
			_claimedAudioSources.Add(audioSource);
			return audioSource;
		}

		public void StopAllSounds(bool stopThisFrame)
		{
			this.stopThisFrame = stopThisFrame;
			foreach (AudioSource audioSource in _audioSources)
			{
				audioSource.Stop();
			}
		}

		public void PauseAllSounds()
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				audioSource.Pause();
			}
		}

		public void UnPauseAllSounds()
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				audioSource.UnPause();
			}
		}

		public void OnDestroy()
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				UnityEngine.Object.DestroyImmediate(audioSource.gameObject);
			}
			_audioSources.Clear();
		}

		public void RegisterEvent(string eventName, Action<AnimationEvent> callback)
		{
		}

		public void UnregisterEvent(string eventName, Action<AnimationEvent> callback)
		{
		}

		public void Event(AnimationEvent animationEvent)
		{
		}

		public void SpawnFX(AnimationEvent animationEvent)
		{
		}

		public void InvokeGenderAudioEvent(string audioEventName)
		{
			if (!IgnoreInvokeAudioEvent && !stopThisFrame)
			{
				if (Sex == Character.Sex.Male)
				{
					audioEventName += ":Male";
				}
				else if (Sex == Character.Sex.Female)
				{
					audioEventName += ":Female";
				}
				AudioEditorUtils.PlayAudio(AudioManager.GetSoundForEvent(audioEventName, _audioEventBank.AudioEvents, logLookups: false), GetAvailableAudioSource());
			}
		}

		public void InvokeAudioEvent(string audioEventName)
		{
			if (!IgnoreInvokeAudioEvent && !stopThisFrame)
			{
				AudioEditorUtils.PlayAudio(AudioManager.GetSoundForEvent(audioEventName, _audioEventBank.AudioEvents, logLookups: false), GetAvailableAudioSource());
			}
		}

		public void BeginAudioLoop(string audioEventName)
		{
			if (!stopThisFrame)
			{
				AudioEvent soundForEvent = AudioManager.GetSoundForEvent(audioEventName, _audioEventBank.AudioEvents, logLookups: false);
				LoopingAudioSources loopingAudioSources = new LoopingAudioSources
				{
					Intro = GetAvailableAudioSource(),
					Main = GetAvailableAudioSource(),
					AudioEvent = soundForEvent
				};
				AudioEditorUtils.PlayAudioLoop(soundForEvent, loopingAudioSources.Intro, loopingAudioSources.Main);
				_loopingAudioPlayers[audioEventName] = loopingAudioSources;
			}
		}

		public void EndAudioLoop(string audioEventName)
		{
			if (_loopingAudioPlayers.ContainsKey(audioEventName))
			{
				LoopingAudioSources loopingAudioSources = _loopingAudioPlayers[audioEventName];
				loopingAudioSources.Intro.Stop();
				loopingAudioSources.Main.Stop();
				_loopingAudioPlayers.Remove(audioEventName);
				AudioEditorUtils.PlayAudioOutro(loopingAudioSources.AudioEvent, GetAvailableAudioSource());
			}
		}

		public void LateUpdate()
		{
			_claimedAudioSources.Clear();
			stopThisFrame = false;
		}
	}
}
