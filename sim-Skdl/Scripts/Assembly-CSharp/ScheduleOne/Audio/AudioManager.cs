using System;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Audio;

namespace ScheduleOne.Audio
{
	public class AudioManager : PersistentSingleton<AudioManager>
	{
		private const float MinGameVolume = 0.0001f;

		private const float MaxGameVolume = 1f;

		private const float GameVolumeLerpSpeed = 2f;

		public Action onVolumeSettingsChanged;

		[SerializeField]
		private AudioMixerSnapshot _defaultSnapshot;

		[SerializeField]
		private AudioMixerSnapshot _distortedSnapshot;

		private float _masterVolume;

		private float _ambientVolume;

		private float _footstepsVolume;

		private float _fxVolume;

		private float _uiVolume;

		private float _musicVolume;

		private float _voiceVolume;

		private float _weatherVolume;

		private float _currentMainMixerVolume;

		public float MasterVolume => 0f;

		[field: SerializeField]
		public AudioMixerGroup MainGameMixer { get; private set; }

		[field: SerializeField]
		public AudioMixerGroup MenuMixer { get; private set; }

		[field: SerializeField]
		public AudioMixerGroup MusicMixer { get; private set; }

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Update()
		{
		}

		public void SetDistorted(bool distorted, float transition = 5f)
		{
		}

		public float GetVolume(EAudioType audioType, bool scaled = true)
		{
			return 0f;
		}

		public void SetMasterVolume(float volume)
		{
		}

		public void SetVolume(EAudioType type, float volume)
		{
		}

		private void SetMainMixerVolume(float value)
		{
		}

		private static float ValueToVolume(float value)
		{
			return 0f;
		}
	}
}
