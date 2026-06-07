using System;
using System.Collections.Generic;
using Doozy.Engine.Attributes;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy
{
	[Serializable]
	public class SoundGroupData : ScriptableObject
	{
		public enum PlayMode
		{
			Random = 0,
			Sequence = 1
		}

		public const bool DEFAULT_IGNORE_LISTENER_PAUSE = true;

		public const bool DEFAULT_LOOP = false;

		public const bool DEFAULT_RESET_SEQUENCE_AFTER_INACTIVE_TIME = false;

		public const float DEFAULT_PITCH = 0f;

		public const float DEFAULT_SEQUENCE_RESET_TIME = 5f;

		public const float DEFAULT_SPATIAL_BLEND = 0f;

		public const float DEFAULT_VOLUME = 0f;

		public const float MAX_PITCH = 24f;

		public const float MAX_SPATIAL_BLEND = 1f;

		public const float MAX_VOLUME = 0f;

		public const float MIN_PITCH = -24f;

		public const float MIN_SPATIAL_BLEND = 0f;

		public const float MIN_VOLUME = -80f;

		public const PlayMode DEFAULT_PLAY_MODE = PlayMode.Random;

		public const string DEFAULT_SOUND_NAME = "No Sound";

		public string DatabaseName;

		public string SoundName;

		public bool IgnoreListenerPause;

		[MinMaxRange(-80f, 0f)]
		public RangedFloat Volume;

		[MinMaxRange(-24f, 24f)]
		public RangedFloat Pitch;

		[Range(0f, 1f)]
		public float SpatialBlend;

		public bool Loop;

		public PlayMode Mode;

		public bool ResetSequenceAfterInactiveTime;

		public float SequenceResetTime;

		public List<AudioData> Sounds;

		private int m_lastPlayedSoundsIndex;

		private float m_lastPlayedSoundTime;

		private readonly List<AudioData> m_playedSounds;

		private AudioData m_lastPlayedAudioData;

		public bool HasMissingAudioClips => false;

		public bool HasSound => false;

		public float RandomPitch => 0f;

		public float RandomVolume => 0f;

		private void Reset()
		{
		}

		public bool Contains(AudioClip audioClip)
		{
			return false;
		}

		public SoundyController Play(Transform followTarget, AudioMixerGroup outputAudioMixerGroup = null)
		{
			return null;
		}

		public SoundyController Play(Vector3 position, AudioMixerGroup outputAudioMixerGroup = null)
		{
			return null;
		}

		public void PlaySoundPreview(AudioSource audioSource, AudioMixerGroup outputAudioMixerGroup, AudioClip audioClip)
		{
		}

		public void PlaySoundPreview(AudioSource audioSource, AudioMixerGroup outputAudioMixerGroup)
		{
		}

		public void StopSoundPreview(AudioSource audioSource)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		private AudioData GetAudioData(PlayMode playMode)
		{
			return null;
		}
	}
}
