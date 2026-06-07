using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using UnityEngine;
using UnityEngine.Audio;

namespace GameCreator.Runtime.Common.Audio
{
	public class AudioBuffer
	{
		[NonSerialized]
		private IAudioConfig m_AudioConfig;

		[NonSerialized]
		private Args m_Args;

		[NonSerialized]
		private readonly AnimFloat m_Volume = new AnimFloat(1f);

		internal AudioClip AudioClip => AudioSource.clip;

		internal GameObject Target { get; private set; }

		internal AudioSource AudioSource { get; }

		internal Transform Transform { get; }

		public float Pitch { get; set; }

		internal AudioBuffer(Transform parent, AudioMixerGroup audioMixerGroup)
		{
			GameObject gameObject = new GameObject("Audio Source");
			Target = null;
			Transform = gameObject.GetComponent<Transform>();
			AudioSource = gameObject.AddComponent<AudioSource>();
			AudioSource.outputAudioMixerGroup = audioMixerGroup;
			AudioSource.dopplerLevel = 0f;
			Transform.SetParent(parent);
		}

		internal bool Update(float volume)
		{
			AnimFloat volume2 = m_Volume;
			volume2.UpdateWithDelta(m_AudioConfig.UpdateMode switch
			{
				TimeMode.UpdateMode.GameTime => Time.deltaTime, 
				TimeMode.UpdateMode.UnscaledTime => Time.unscaledDeltaTime, 
				_ => throw new ArgumentOutOfRangeException(), 
			});
			volume *= m_Volume.Current;
			AudioSource.volume = Rescale(volume);
			GameObject gameObject = m_AudioConfig?.GetTrackTarget(m_Args);
			Character character = gameObject.Get<Character>();
			if (character != null && character.Animim.Animator.isHuman)
			{
				gameObject = character.Animim.Animator.GetBoneTransform(HumanBodyBones.Head).gameObject;
			}
			if (gameObject != null)
			{
				Transform.position = gameObject.transform.position;
			}
			IAudioConfig audioConfig = m_AudioConfig;
			float num = ((audioConfig != null && audioConfig.UpdateMode == TimeMode.UpdateMode.GameTime) ? Time.timeScale : 1f);
			AudioSource.pitch = Pitch * num;
			return AudioSource.isPlaying;
		}

		internal async Task Play(AudioClip audioClip, IAudioConfig audioConfig, Args args)
		{
			AudioSource.clip = audioClip;
			m_AudioConfig = audioConfig;
			m_Args = args;
			Setup();
			AudioSource.Stop();
			AudioSource.Play();
			while (!ApplicationManager.IsExiting && AudioSource.isPlaying)
			{
				await Task.Yield();
			}
		}

		internal async Task Stop(float transition)
		{
			m_Volume.Target = 0f;
			m_Volume.Smooth = transition;
			AudioSource.SetScheduledEndTime(AudioSettings.dspTime + (double)transition);
			while (!ApplicationManager.IsExiting && AudioSource.isPlaying)
			{
				await Task.Yield();
			}
		}

		private void Setup()
		{
			float num = ((m_AudioConfig.TransitionIn <= float.Epsilon) ? m_AudioConfig.Volume : 0f);
			Pitch = m_AudioConfig.Pitch;
			m_Volume.Current = num;
			m_Volume.Target = m_AudioConfig.Volume;
			m_Volume.Smooth = m_AudioConfig.TransitionIn;
			AudioSource.volume = Rescale(num);
			AudioSource.pitch = Pitch;
			AudioSource.spatialBlend = m_AudioConfig.SpatialBlend;
			Target = m_AudioConfig.GetTrackTarget(m_Args);
		}

		private static float Rescale(float volume)
		{
			return volume * volume;
		}
	}
}
