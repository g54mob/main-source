using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMSoundManagerSettings
	{
		public const float _minimalVolume = 0.0001f;

		public const float _maxVolume = 10f;

		public const float _defaultVolume = 1f;

		[Header("Audio Mixer Control")]
		[Tooltip("whether or not the settings described below should override the ones defined in the AudioMixer")]
		public bool OverrideMixerSettings;

		[Header("Audio Mixer Exposed Parameters")]
		[Tooltip("the name of the exposed MasterVolume parameter in the AudioMixer")]
		public string MasterVolumeParameter;

		[Tooltip("the name of the exposed MusicVolume parameter in the AudioMixer")]
		public string MusicVolumeParameter;

		[Tooltip("the name of the exposed SfxVolume parameter in the AudioMixer")]
		public string SfxVolumeParameter;

		[Tooltip("the name of the exposed UIVolume parameter in the AudioMixer")]
		public string UIVolumeParameter;

		[MMReadOnly]
		[Tooltip("the master volume")]
		[Range(0.0001f, 10f)]
		[Header("Master")]
		public float MasterVolume;

		[Tooltip("whether the master track is active at the moment or not")]
		[MMReadOnly]
		public bool MasterOn;

		[Tooltip("the volume of the master track before it was muted")]
		[MMReadOnly]
		public float MutedMasterVolume;

		[Header("Music")]
		[Range(0.0001f, 10f)]
		[Tooltip("the music volume")]
		[MMReadOnly]
		public float MusicVolume;

		[Tooltip("whether the music track is active at the moment or not")]
		[MMReadOnly]
		public bool MusicOn;

		[Tooltip("the volume of the music track before it was muted")]
		[MMReadOnly]
		public float MutedMusicVolume;

		[MMReadOnly]
		[Tooltip("the sound fx volume")]
		[Header("Sound Effects")]
		[Range(0.0001f, 10f)]
		public float SfxVolume;

		[Tooltip("whether the SFX track is active at the moment or not")]
		[MMReadOnly]
		public bool SfxOn;

		[Tooltip("the volume of the SFX track before it was muted")]
		[MMReadOnly]
		public float MutedSfxVolume;

		[Header("UI")]
		[Range(0.0001f, 10f)]
		[Tooltip("the UI sounds volume")]
		[MMReadOnly]
		public float UIVolume;

		[Tooltip("whether the UI track is active at the moment or not")]
		[MMReadOnly]
		public bool UIOn;

		[MMReadOnly]
		[Tooltip("the volume of the UI track before it was muted")]
		public float MutedUIVolume;

		[Header("Save & Load")]
		[Tooltip("whether or not the MMSoundManager should automatically load settings when starting")]
		public bool AutoLoad;

		[Tooltip("whether or not each change in the settings should be automaticall saved. If not, you'll have to call a save MMSoundManager event for settings to be saved.")]
		public bool AutoSave;
	}
}
