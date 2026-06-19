using System;
using UnityEngine;

namespace TH20
{
	public class AppAudioMixerManager : MustCallDestroy
	{
		private static readonly string MasterVolume_ParamName = "MasterVolume";

		private static readonly string SFXVolume_ParamName = "SFXVolume";

		private static readonly string MusicVolume_ParamName = "MusicVolume";

		private static readonly string SubMasterVolume_ParamName = "SubMasterVolume";

		private static readonly string PreviewMusicVolume_ParamName = "MusicPreviewVolume";

		private AppAudioMixerManagerConfig _config;

		private LocalPreferences _userPreferences;

		private float _overrideVolume = 1f;

		private float _sfxVolume = 1f;

		private float _previewFadeVel;

		private float _previewFadeFactorCurrent;

		private float _previewFadeFactorTarget;

		private bool _subMasterChannelVolumeSet;

		private float _subMasterChannelVolume;

		private float _musicChannelVolume;

		public AppAudioMixerManager(LocalPreferences userPreferences, AppAudioMixerManagerConfig config)
		{
			_config = config;
			Refresh(userPreferences);
		}

		public void Refresh(LocalPreferences userPreferences)
		{
			if (_userPreferences != null)
			{
				LocalPreferences.AudioPreferences audio = _userPreferences.Audio;
				audio.MasterVolumeChanged = (Action<float>)Delegate.Remove(audio.MasterVolumeChanged, new Action<float>(MasterVolumeChanged));
				LocalPreferences.AudioPreferences audio2 = _userPreferences.Audio;
				audio2.MusicVolumeChanged = (Action<float>)Delegate.Remove(audio2.MusicVolumeChanged, new Action<float>(MusicVolumeChanged));
				LocalPreferences.AudioPreferences audio3 = _userPreferences.Audio;
				audio3.SFXVolumeChanged = (Action<float>)Delegate.Remove(audio3.SFXVolumeChanged, new Action<float>(SFXVolumeChanged));
			}
			_userPreferences = userPreferences;
			MasterVolumeChanged(_userPreferences.Audio.MasterVolume);
			MusicVolumeChanged(_userPreferences.Audio.MusicVolume);
			SFXVolumeChanged(_userPreferences.Audio.SFXVolume);
			LocalPreferences.AudioPreferences audio4 = _userPreferences.Audio;
			audio4.MasterVolumeChanged = (Action<float>)Delegate.Combine(audio4.MasterVolumeChanged, new Action<float>(MasterVolumeChanged));
			LocalPreferences.AudioPreferences audio5 = _userPreferences.Audio;
			audio5.MusicVolumeChanged = (Action<float>)Delegate.Combine(audio5.MusicVolumeChanged, new Action<float>(MusicVolumeChanged));
			LocalPreferences.AudioPreferences audio6 = _userPreferences.Audio;
			audio6.SFXVolumeChanged = (Action<float>)Delegate.Combine(audio6.SFXVolumeChanged, new Action<float>(SFXVolumeChanged));
		}

		private void MasterVolumeChanged(float volume)
		{
			_config.AudioMixer.SetFloat(MasterVolume_ParamName, MathUtils.VolumeFractionToDecibelFraction(volume, _config.MinMasterVolumeDecibels, _config.MaxMasterVolumeDecibels));
		}

		private void SFXVolumeChanged(float volume)
		{
			_sfxVolume = volume;
			_config.AudioMixer.SetFloat(SFXVolume_ParamName, MathUtils.VolumeFractionToDecibelFraction(volume * _overrideVolume, _config.MinSFXVolumeDecibels, _config.MaxSFXVolumeDecibels));
		}

		private void MusicVolumeChanged(float volume)
		{
			_config.AudioMixer.SetFloat(MusicVolume_ParamName, MathUtils.VolumeFractionToDecibelFraction(volume, _config.MinMusicVolumeDecibels, _config.MaxMusicVolumeDecibels));
		}

		public override void Destroy()
		{
			LocalPreferences.AudioPreferences audio = _userPreferences.Audio;
			audio.MasterVolumeChanged = (Action<float>)Delegate.Remove(audio.MasterVolumeChanged, new Action<float>(MasterVolumeChanged));
			LocalPreferences.AudioPreferences audio2 = _userPreferences.Audio;
			audio2.SFXVolumeChanged = (Action<float>)Delegate.Remove(audio2.SFXVolumeChanged, new Action<float>(SFXVolumeChanged));
			LocalPreferences.AudioPreferences audio3 = _userPreferences.Audio;
			audio3.MusicVolumeChanged = (Action<float>)Delegate.Remove(audio3.MusicVolumeChanged, new Action<float>(MusicVolumeChanged));
			base.Destroy();
		}

		public void SetSFXVolumeOverride(float volume)
		{
			_overrideVolume = volume;
			SFXVolumeChanged(_sfxVolume);
		}

		public void Update()
		{
			ProcessPreviewMusicChannelFading();
		}

		public void SetPreviewMusicChannelFadingIn(float fadeInDuration = 1f)
		{
			if (!_subMasterChannelVolumeSet)
			{
				_subMasterChannelVolumeSet = true;
				_config.AudioMixer.GetFloat(SubMasterVolume_ParamName, out _subMasterChannelVolume);
			}
			_config.AudioMixer.GetFloat(MusicVolume_ParamName, out _musicChannelVolume);
			fadeInDuration = Mathf.Max(fadeInDuration, 0.01f);
			_previewFadeFactorTarget = 1f;
			_previewFadeVel = 1f / fadeInDuration;
		}

		public void SetPreviewMusicChannelFadingOut(float fadeOutDuration = 1f)
		{
			fadeOutDuration = Mathf.Max(fadeOutDuration, 0.01f);
			_previewFadeFactorTarget = 0f;
			_previewFadeVel = 1f / fadeOutDuration;
		}

		private void ProcessPreviewMusicChannelFading()
		{
			if (_previewFadeFactorCurrent != _previewFadeFactorTarget)
			{
				float num = ((_previewFadeFactorCurrent < _previewFadeFactorTarget) ? 1f : (-1f));
				_previewFadeFactorCurrent += num * (_previewFadeVel * Time.unscaledDeltaTime);
				_previewFadeFactorCurrent = Mathf.Clamp(_previewFadeFactorCurrent, 0f, 1f);
				SetPreviewChannelVolumes();
			}
		}

		private void SetPreviewChannelVolumes()
		{
			float value = MathUtils.VolumeFractionToDecibelFraction(_previewFadeFactorCurrent, _config.MinMusicVolumeDecibels, _musicChannelVolume);
			float value2 = MathUtils.VolumeFractionToDecibelFraction(1f - _previewFadeFactorCurrent, _config.MinMusicVolumeDecibels, _subMasterChannelVolume);
			_config.AudioMixer.SetFloat(PreviewMusicVolume_ParamName, value);
			_config.AudioMixer.SetFloat(SubMasterVolume_ParamName, value2);
		}
	}
}
