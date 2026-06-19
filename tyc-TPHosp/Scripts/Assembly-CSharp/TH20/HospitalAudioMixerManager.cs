using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Profiling;

namespace TH20
{
	[DontSave]
	public class HospitalAudioMixerManager : MustCallDestroy
	{
		private static readonly string HospitalSFXVolume_ParamName = "HospitalSFXVolume";

		private static readonly string TannoyVolume_ParamName = "TannoyVolume";

		private static readonly string DJVolume_ParamName = "DJVolume";

		private static readonly string TannoyPitchParamName = "TannoyPitch";

		private static readonly string HospitalSFXPitchParamName = "HospitalSFXPitch";

		private static readonly string LevelMusicPitchParamName = "LevelMusicPitch";

		private static readonly string AmbiencePitchParamName = "AmbiencePitch";

		private static readonly string DJPitchParamName = "DJPitch";

		private static readonly string HospitalSFXLowPassCutoffName = "HospitalSFXLowPassCutoff";

		private static readonly string HospitalAmbienceLowPassCutoffName = "HospitalAmbienceLowPassCutOff";

		private static readonly string TannoyDryLevelName = "TannoyDryLevel";

		private static readonly string TannoyRoomName = "TannoyRoom";

		private static readonly string TannoyRoomHFName = "TannoyRoomHF";

		private static readonly string TannoyRoomLFName = "TannoyRoomLF";

		private static readonly string TannoyDecayTimeName = "TannoyDecayTime";

		private static readonly string TannoyDecayHFRatioName = "TannoyDecayHFRatio";

		private static readonly string TannoyReflectionsName = "TannoyReflections";

		private static readonly string TannoyReflectDelayName = "TannoyReflectDelay";

		private static readonly string TannoyReverbName = "TannoyReverb";

		private static readonly string TannoyReverbDelayName = "TannoyReverbDelay";

		private static readonly string TannoyHFReferenceName = "TannoyHFReference";

		private static readonly string TannoyLFReferenceName = "TannoyLFReference";

		private static readonly string TannoyDiffusionName = "TannoyDiffusion";

		private static readonly string TannoyDensityName = "TannoyDensity";

		private static readonly string HospitalSFXDryLevelName = "HospitalSFXDryLevel";

		private static readonly string HospitalSFXRoomName = "HospitalSFXRoom";

		private static readonly string HospitalSFXRoomHFName = "HospitalSFXRoomHF";

		private static readonly string HospitalSFXRoomLFName = "HospitalSFXRoomLF";

		private static readonly string HospitalSFXDecayTimeName = "HospitalSFXDecayTime";

		private static readonly string HospitalSFXDecayHFRatioName = "HospitalSFXDecayHFRatio";

		private static readonly string HospitalSFXReflectionsName = "HospitalSFXReflections";

		private static readonly string HospitalSFXReflectDelayName = "HospitalSFXReflectDelay";

		private static readonly string HospitalSFXReverbName = "HospitalSFXReverb";

		private static readonly string HospitalSFXReverbDelayName = "HospitalSFXReverbDelay";

		private static readonly string HospitalSFXHFReferenceName = "HospitalSFXHFReference";

		private static readonly string HospitalSFXLFReferenceName = "HospitalSFXLFReference";

		private static readonly string HospitalSFXDiffusionName = "HospitalSFXDiffusion";

		private static readonly string HospitalSFXDensityName = "HospitalSFXDensity";

		private readonly HospitalAudioMixerManagerConfig _config;

		private readonly Level _level;

		private readonly LevelCameraManager _levelCameraManager;

		private readonly LocalPreferences _userPreferences;

		private CustomSampler _tannoyReverbSampler;

		private bool _levelLoadInProgress;

		public bool IsMusicMixerPlaying
		{
			get
			{
				if (_config.HospitalAudioMixer.GetFloat(LevelMusicPitchParamName, out var value))
				{
					return !Mathf.Approximately(value, 0f);
				}
				return false;
			}
		}

		public HospitalAudioMixerManager(Level level, LevelCameraManager levelCameraManager, LocalPreferences userPreferences, HospitalAudioMixerManagerConfig config)
		{
			_level = level;
			_levelCameraManager = levelCameraManager;
			_config = config;
			_userPreferences = userPreferences;
			_levelLoadInProgress = false;
			_tannoyReverbSampler = CustomSampler.Create("HospitalAudioMixerManager.Update.Reverb");
			TannoyVolumeChanged(_userPreferences.Audio.TannoyVolume);
			DJVolumeChanged(_userPreferences.Audio.DJVolume);
			LocalPreferences.AudioPreferences audio = _userPreferences.Audio;
			audio.TannoyVolumeChanged = (Action<float>)Delegate.Combine(audio.TannoyVolumeChanged, new Action<float>(TannoyVolumeChanged));
			LocalPreferences.AudioPreferences audio2 = _userPreferences.Audio;
			audio2.DJVolumeChanged = (Action<float>)Delegate.Combine(audio2.DJVolumeChanged, new Action<float>(DJVolumeChanged));
			MetagameMap metagameMap = _level.MetagameMap;
			metagameMap.OnOpen = (Action)Delegate.Combine(metagameMap.OnOpen, new Action(OnMetagameMapOpen));
			App app = _level.Metagame.App;
			app.OnLevelLoadStarting = (Action)Delegate.Combine(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
			App app2 = _level.Metagame.App;
			app2.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app2.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
		}

		public float GetTannoyVolumeFactor()
		{
			return Mathf.Clamp(_userPreferences.Audio.TannoyVolume / _userPreferences.Audio.MaxTannoyVolume, 0f, 1f);
		}

		public float GetDJVolumeFactor()
		{
			return Mathf.Clamp(_userPreferences.Audio.DJVolume / _userPreferences.Audio.MaxDJVolume, 0f, 1f);
		}

		private void OnMetagameMapOpen()
		{
			SetRadioMixersPitch(0f);
			SetPauseableMixerPitches(0f);
		}

		private void OnLevelLoadStarting()
		{
			_levelLoadInProgress = true;
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			_levelLoadInProgress = false;
		}

		private void TannoyVolumeChanged(float volume)
		{
			_config.HospitalAudioMixer.SetFloat(TannoyVolume_ParamName, MathUtils.VolumeFractionToDecibelFraction(volume, _config.MinVolumeDecibels, _config.MaxVolumeDecibels));
		}

		private void DJVolumeChanged(float volume)
		{
			_config.HospitalAudioMixer.SetFloat(DJVolume_ParamName, MathUtils.VolumeFractionToDecibelFraction(volume, _config.MinVolumeDecibels, _config.MaxVolumeDecibels));
		}

		private void SetRadioMixersPitch(float mixerPitch)
		{
			_config.HospitalAudioMixer.SetFloat(LevelMusicPitchParamName, mixerPitch);
			_config.HospitalAudioMixer.SetFloat(DJPitchParamName, mixerPitch);
			_config.HospitalAudioMixer.SetFloat(TannoyPitchParamName, mixerPitch);
		}

		private void SetPauseableMixerPitches(float mixerPitch)
		{
			_config.HospitalAudioMixer.SetFloat(HospitalSFXPitchParamName, mixerPitch);
			_config.HospitalAudioMixer.SetFloat(AmbiencePitchParamName, mixerPitch);
		}

		public void Update()
		{
			float pauseableMixerPitches = (Mathf.Approximately(Time.timeScale, 0f) ? 0f : 1f);
			if (_levelLoadInProgress)
			{
				pauseableMixerPitches = 0f;
			}
			SetPauseableMixerPitches(pauseableMixerPitches);
			SetRadioMixersPitch(1f);
			TopDownCameraLogic currentLevelCamera = _levelCameraManager.CurrentLevelCamera;
			if (currentLevelCamera != null)
			{
				Camera cameraComponent = currentLevelCamera.CameraComponent;
				float time = Mathf.InverseLerp(_config.LowestHospitalCameraHeight, _config.GreatestHospitalCameraHeight, cameraComponent.transform.position.y);
				time = _config.HospitalSFXHeightFallOffCurve.Evaluate(time);
				time = Mathf.Clamp01(time);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXVolume_ParamName, MathUtils.VolumeFractionToDecibelFraction(time, _config.HospitalSFXVolumeAtFurthestHeight, _config.HospitalSFXVolumeAtLowestHeight));
				float p = Mathf.InverseLerp(_config.SFXLowPassLowestHospitalCameraHeight, _config.SFXLowPassGreatestHospitalCameraHeight, cameraComponent.transform.position.y);
				p = EasingsUtils.ExponentialEaseOut(p);
				p = Mathf.Clamp01(p);
				float value = Mathf.Lerp(_config.HospitalSFXLowPassSettings.LowestHeightFreqCutoff, _config.HospitalSFXLowPassSettings.GreatestHeightFreqCutoff, p);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXLowPassCutoffName, value);
				float p2 = Mathf.InverseLerp(_config.HospitalAmbienceLowestCameraHeight, _config.HospitalAmbienceGreatestCameraHeight, cameraComponent.transform.position.y);
				p2 = EasingsUtils.ExponentialEaseOut(p2);
				p2 = Mathf.Clamp01(p2);
				float value2 = Mathf.Lerp(_config.HospitalAmbienceLowPassSettings.LowestHeightFreqCutoff, _config.HospitalAmbienceLowPassSettings.GreatestHeightFreqCutoff, p2);
				_config.HospitalAudioMixer.SetFloat(HospitalAmbienceLowPassCutoffName, value2);
				float p3 = Mathf.InverseLerp(_config.HospitalSFXReverbLowestHospitalCameraHeight, _config.HospitalSFXReverbGreatestHospitalCameraHeight, cameraComponent.transform.position.y);
				p3 = EasingsUtils.ExponentialEaseOut(p3);
				p3 = Mathf.Clamp01(p3);
				float value3 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.DryLevel, _config.HospitalSFXGreatestHeightReverb.DryLevel, p3);
				float value4 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.Room, _config.HospitalSFXGreatestHeightReverb.Room, p3);
				float value5 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.RoomHF, _config.HospitalSFXGreatestHeightReverb.RoomHF, p3);
				float value6 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.RoomLF, _config.HospitalSFXGreatestHeightReverb.RoomLF, p3);
				float value7 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.DecayTime, _config.HospitalSFXGreatestHeightReverb.DecayTime, p3);
				float value8 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.DecayHFRatio, _config.HospitalSFXGreatestHeightReverb.DecayHFRatio, p3);
				float value9 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.Reflections, _config.HospitalSFXGreatestHeightReverb.Reflections, p3);
				float value10 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.ReflectDelay, _config.HospitalSFXGreatestHeightReverb.ReflectDelay, p3);
				float value11 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.Reverb, _config.HospitalSFXGreatestHeightReverb.Reverb, p3);
				float value12 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.ReverbDelay, _config.HospitalSFXGreatestHeightReverb.ReverbDelay, p3);
				float value13 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.HFReference, _config.HospitalSFXGreatestHeightReverb.HFReference, p3);
				float value14 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.LFReference, _config.HospitalSFXGreatestHeightReverb.LFReference, p3);
				float value15 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.Diffusion, _config.HospitalSFXGreatestHeightReverb.Diffusion, p3);
				float value16 = Mathf.Lerp(_config.HospitalSFXLowestHeightReverb.Density, _config.HospitalSFXGreatestHeightReverb.Density, p3);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXDryLevelName, value3);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXRoomName, value4);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXRoomHFName, value5);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXRoomLFName, value6);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXDecayTimeName, value7);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXDecayHFRatioName, value8);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXReflectionsName, value9);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXReflectDelayName, value10);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXReverbName, value11);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXReverbDelayName, value12);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXHFReferenceName, value13);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXLFReferenceName, value14);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXDiffusionName, value15);
				_config.HospitalAudioMixer.SetFloat(HospitalSFXDensityName, value16);
				float p4 = Mathf.InverseLerp(_config.TannoyReverbLowestHospitalCameraHeight, _config.TannoyReverbGreatestHospitalCameraHeight, cameraComponent.transform.position.y);
				p4 = EasingsUtils.ExponentialEaseOut(p4);
				p4 = Mathf.Clamp01(p4);
				float value17 = Mathf.Lerp(_config.TannoyLowestHeightReverb.DryLevel, _config.TannoyGreatestHeightReverb.DryLevel, p4);
				float value18 = Mathf.Lerp(_config.TannoyLowestHeightReverb.Room, _config.TannoyGreatestHeightReverb.Room, p4);
				float value19 = Mathf.Lerp(_config.TannoyLowestHeightReverb.RoomHF, _config.TannoyGreatestHeightReverb.RoomHF, p4);
				float value20 = Mathf.Lerp(_config.TannoyLowestHeightReverb.RoomLF, _config.TannoyGreatestHeightReverb.RoomLF, p4);
				float value21 = Mathf.Lerp(_config.TannoyLowestHeightReverb.DecayTime, _config.TannoyGreatestHeightReverb.DecayTime, p4);
				float value22 = Mathf.Lerp(_config.TannoyLowestHeightReverb.DecayHFRatio, _config.TannoyGreatestHeightReverb.DecayHFRatio, p4);
				float value23 = Mathf.Lerp(_config.TannoyLowestHeightReverb.Reflections, _config.TannoyGreatestHeightReverb.Reflections, p4);
				float value24 = Mathf.Lerp(_config.TannoyLowestHeightReverb.ReflectDelay, _config.TannoyGreatestHeightReverb.ReflectDelay, p4);
				float value25 = Mathf.Lerp(_config.TannoyLowestHeightReverb.Reverb, _config.TannoyGreatestHeightReverb.Reverb, p4);
				float value26 = Mathf.Lerp(_config.TannoyLowestHeightReverb.ReverbDelay, _config.TannoyGreatestHeightReverb.ReverbDelay, p4);
				float value27 = Mathf.Lerp(_config.TannoyLowestHeightReverb.HFReference, _config.TannoyGreatestHeightReverb.HFReference, p4);
				float value28 = Mathf.Lerp(_config.TannoyLowestHeightReverb.LFReference, _config.TannoyGreatestHeightReverb.LFReference, p4);
				float value29 = Mathf.Lerp(_config.TannoyLowestHeightReverb.Diffusion, _config.TannoyGreatestHeightReverb.Diffusion, p4);
				float value30 = Mathf.Lerp(_config.TannoyLowestHeightReverb.Density, _config.TannoyGreatestHeightReverb.Density, p4);
				_config.HospitalAudioMixer.SetFloat(TannoyDryLevelName, value17);
				_config.HospitalAudioMixer.SetFloat(TannoyRoomName, value18);
				_config.HospitalAudioMixer.SetFloat(TannoyRoomHFName, value19);
				_config.HospitalAudioMixer.SetFloat(TannoyRoomLFName, value20);
				_config.HospitalAudioMixer.SetFloat(TannoyDecayTimeName, value21);
				_config.HospitalAudioMixer.SetFloat(TannoyDecayHFRatioName, value22);
				_config.HospitalAudioMixer.SetFloat(TannoyReflectionsName, value23);
				_config.HospitalAudioMixer.SetFloat(TannoyReflectDelayName, value24);
				_config.HospitalAudioMixer.SetFloat(TannoyReverbName, value25);
				_config.HospitalAudioMixer.SetFloat(TannoyReverbDelayName, value26);
				_config.HospitalAudioMixer.SetFloat(TannoyHFReferenceName, value27);
				_config.HospitalAudioMixer.SetFloat(TannoyLFReferenceName, value28);
				_config.HospitalAudioMixer.SetFloat(TannoyDiffusionName, value29);
				_config.HospitalAudioMixer.SetFloat(TannoyDensityName, value30);
			}
			else
			{
				UnityEngine.Debug.LogWarning("AudioMixerManager does not have access to a level camera");
			}
		}

		public override void Destroy()
		{
			if (_config.HospitalAudioMixerGroups != null)
			{
				AudioManager.Instance.StopEmittersWhere(delegate(AudioEmitter e)
				{
					AudioMixerGroup audioMixerGroup = e.AudioMixerGroup;
					for (int i = 0; i < _config.HospitalAudioMixerGroups.Length; i++)
					{
						if (audioMixerGroup == _config.HospitalAudioMixerGroups[i])
						{
							return true;
						}
					}
					return false;
				});
			}
			MetagameMap metagameMap = _level.MetagameMap;
			metagameMap.OnOpen = (Action)Delegate.Remove(metagameMap.OnOpen, new Action(OnMetagameMapOpen));
			App app = _level.Metagame.App;
			app.OnLevelLoadStarting = (Action)Delegate.Remove(app.OnLevelLoadStarting, new Action(OnLevelLoadStarting));
			App app2 = _level.Metagame.App;
			app2.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app2.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			LocalPreferences.AudioPreferences audio = _userPreferences.Audio;
			audio.TannoyVolumeChanged = (Action<float>)Delegate.Remove(audio.TannoyVolumeChanged, new Action<float>(TannoyVolumeChanged));
			LocalPreferences.AudioPreferences audio2 = _userPreferences.Audio;
			audio2.DJVolumeChanged = (Action<float>)Delegate.Remove(audio2.DJVolumeChanged, new Action<float>(DJVolumeChanged));
			base.Destroy();
		}
	}
}
