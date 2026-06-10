using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Modding;
using NSMedieval.Sound;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.UI
{
	public class OptionsController : MonoSingleton<OptionsController>
	{
		public delegate void BoolCallbackDelegate(bool active);

		private bool fullscreenOn;

		private GlobalSettings globalSettings;

		private int newRefreshRate;

		private Vector2Int newResolutionSetting;

		private UISizes newScaleSetting;

		private int previousRefreshRate;

		private Vector2Int previousResolutionSetting;

		private int previousScaleSetting;

		private Dictionary<int, int> wantedResolutions;

		public event BoolCallbackDelegate ToggleWorkerNames;

		public event Action ToggleAnimalNames;

		public event Action AntiAliasingOptionEvent;

		public event Action PostProcessingOptionEvent;

		public event Action FullscreenExternalEvent;

		public event Action<Dictionary<string, float>> PlaylistPauseChangeEvent;

		public event Action AutosaveFrequencyChangedAction;

		public event Action LanguageChangedEvent;

		public event Action BirdsDisableEvent;

		public event Action GrassChangedEvent;

		public event Action CameraVisualsDurationChangedEvent;

		public event Action SharpnessChangedEvent;

		public event Action SetCameraOffsetByBuildingsEvent;

		public event Action SetHoverIntensityEvent;

		public void Initialize()
		{
			globalSettings = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings;
			previousScaleSetting = (int)globalSettings.CurrentUISize;
			previousResolutionSetting = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
			previousRefreshRate = Screen.currentResolution.refreshRate;
			newScaleSetting = globalSettings.CurrentUISize;
			fullscreenOn = Screen.fullScreen;
			SyncTextureQuality();
			SyncAnisotropicFiltering();
			SyncShadowsQuality();
			SyncVSync();
			SyncFPSCap();
			SyncSoftParticles();
			SyncRunInBackground();
			newResolutionSetting = new Vector2Int(globalSettings.DefaultResolution.x, globalSettings.DefaultResolution.y);
			if (newResolutionSetting.x == 0 || newResolutionSetting.y == 0)
			{
				newResolutionSetting = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
				KeepResolutionSettings();
				MonoSingleton<GlobalSaveController>.Instance.Serialize();
			}
		}

		private void Update()
		{
			if (fullscreenOn != Screen.fullScreen)
			{
				fullscreenOn = Screen.fullScreen;
				this.FullscreenExternalEvent?.Invoke();
				SetFullscreen(fullscreenOn);
			}
		}

		public void SetFullscreen(bool fullscreenOn)
		{
			if (globalSettings != null && globalSettings.Fullscreen != fullscreenOn)
			{
				globalSettings.SetFullscreen(fullscreenOn);
				SetResolutionSettings(globalSettings.DefaultResolution.x, globalSettings.DefaultResolution.y, globalSettings.RefreshRate);
			}
		}

		public void SetRunInBackground(bool runInBackground)
		{
			if (globalSettings.RunInBackground != runInBackground)
			{
				globalSettings.SetRunInBackground(runInBackground);
				SyncRunInBackground();
			}
		}

		private void SyncRunInBackground()
		{
			Application.runInBackground = globalSettings.RunInBackground;
		}

		public void SetResolution(Resolution resolution)
		{
			newResolutionSetting = new Vector2Int(resolution.width, resolution.height);
			newRefreshRate = resolution.refreshRate;
			previousResolutionSetting = new Vector2Int(Screen.currentResolution.width, Screen.currentResolution.height);
			previousRefreshRate = Screen.currentResolution.refreshRate;
			SetResolutionSettings(newResolutionSetting.x, newResolutionSetting.y, newRefreshRate);
		}

		private void SetResolution(Vector2Int resolution)
		{
			if (globalSettings.DefaultResolution != resolution)
			{
				globalSettings.SetResolution(resolution);
			}
		}

		public void KeepResolutionSettings()
		{
			SetResolution(newResolutionSetting);
			if (globalSettings.RefreshRate != newRefreshRate)
			{
				globalSettings.SetRefreshrate(newRefreshRate);
			}
		}

		public void RevertResolutionSettings()
		{
			SetResolutionSettings(previousResolutionSetting.x, previousResolutionSetting.y, previousRefreshRate);
		}

		private void SetResolutionSettings(int width, int height, int refreshRate)
		{
			Screen.SetResolution(width, height, globalSettings.Fullscreen, refreshRate);
		}

		public void KeepUIScale()
		{
			if (globalSettings.CurrentUISize != newScaleSetting)
			{
				globalSettings.SetUISize(newScaleSetting);
			}
		}

		public void RevertUIScale()
		{
			MonoSingleton<UIScaleController>.Instance.GetUISizeName(previousScaleSetting);
		}

		public void SetUIScale(int newUISizeIndex, int prevUISizeSetting)
		{
			previousScaleSetting = prevUISizeSetting;
			newScaleSetting = MonoSingleton<UIScaleController>.Instance.GetUISizeName(newUISizeIndex);
		}

		private void SyncAnisotropicFiltering()
		{
			bool anisotropicFiltering = globalSettings.AnisotropicFiltering;
			if (QualitySettings.anisotropicFiltering != AnisotropicFiltering.ForceEnable && anisotropicFiltering)
			{
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			}
			else if (QualitySettings.anisotropicFiltering != AnisotropicFiltering.Disable && !anisotropicFiltering)
			{
				QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			}
		}

		public void SetAnisotropicFiltering(bool value)
		{
			globalSettings.SetAnisotropicFiltering(value);
			SyncAnisotropicFiltering();
		}

		private void SyncTextureQuality()
		{
			int textureQuality = globalSettings.TextureQuality;
			if (textureQuality != QualitySettings.globalTextureMipmapLimit)
			{
				QualitySettings.globalTextureMipmapLimit = textureQuality;
			}
			if (textureQuality > 1)
			{
				globalSettings.SetTextureQuality(1);
				QualitySettings.globalTextureMipmapLimit = 1;
			}
		}

		public void SetTextureQuality(int value)
		{
			int textureQuality = Mathf.Clamp(value, 0, 1);
			globalSettings.SetTextureQuality(textureQuality);
			SyncTextureQuality();
		}

		private void SyncShadowsQuality()
		{
			int shadowQuality = globalSettings.ShadowQuality;
			if (shadowQuality == 4)
			{
				QualitySettings.shadows = ShadowQuality.Disable;
				return;
			}
			QualitySettings.shadows = ShadowQuality.All;
			QualitySettings.shadowResolution = (ShadowResolution)shadowQuality;
		}

		public void SetShadowsQuality(int value)
		{
			globalSettings.SetShadowQuality(value);
			SyncShadowsQuality();
		}

		public void SetAntiAliasing(int value)
		{
			globalSettings.SetAntiAliasing(value);
			this.AntiAliasingOptionEvent?.Invoke();
		}

		public void SetVSync(int value)
		{
			globalSettings.SetVSync(value);
			SyncVSync();
		}

		private void SyncVSync()
		{
			QualitySettings.vSyncCount = globalSettings.VSync;
			SyncFPSCap();
		}

		public void SetFPSCap(int value)
		{
			if (globalSettings.FPSCap != value)
			{
				globalSettings.SetFPSCap(value);
				SyncFPSCap();
			}
		}

		private void SyncFPSCap()
		{
			if (globalSettings.VSync != 0)
			{
				Application.targetFrameRate = -1;
				return;
			}
			switch (globalSettings.FPSCap)
			{
			case 1:
				Application.targetFrameRate = 30;
				break;
			case 2:
				Application.targetFrameRate = 60;
				break;
			default:
				Application.targetFrameRate = -1;
				break;
			}
		}

		public void SetSoftParticles(bool value)
		{
			globalSettings.SetSoftParticles(value);
			SyncSoftParticles();
		}

		private void SyncSoftParticles()
		{
			QualitySettings.softParticles = globalSettings.SoftParticles;
		}

		public void SetMotionBlur(bool value)
		{
			if (globalSettings.MotionBlur != value)
			{
				globalSettings.SetMotionBlur(value);
				this.PostProcessingOptionEvent?.Invoke();
			}
		}

		public void SetSharpness(float value)
		{
			globalSettings.SetSharpness(value);
			this.SharpnessChangedEvent?.Invoke();
		}

		public void SetAmbientOcclusion(bool value)
		{
			if (globalSettings.AmbientOcclusion != value)
			{
				globalSettings.SetAmbientOcclusion(value);
				this.PostProcessingOptionEvent?.Invoke();
			}
		}

		public void SetBloom(bool value)
		{
			if (globalSettings.Bloom != value)
			{
				globalSettings.SetBloom(value);
				this.PostProcessingOptionEvent?.Invoke();
			}
		}

		public void SetSunbeams(bool value)
		{
			if (globalSettings.SunBeams != value)
			{
				globalSettings.SetSunbeams(value);
			}
		}

		public void SetEnvironmentFootprintsParticles(bool value)
		{
			if (globalSettings.EnvironmentFootprintsParticles != value)
			{
				globalSettings.SetEnvironmentFootprintsParticles(value);
			}
		}

		public void SetBirdsEffect(bool value)
		{
			if (globalSettings.BirdsEffect != value)
			{
				globalSettings.SetBirdsEffect(value);
				if (!value)
				{
					this.BirdsDisableEvent?.Invoke();
				}
			}
		}

		public void SetGrassHidden(bool value)
		{
			if (globalSettings.GrassHidden != value)
			{
				globalSettings.SetGrassHidden(value);
				this.GrassChangedEvent?.Invoke();
			}
		}

		public void SetEnvironmentParticles(bool value)
		{
			if (globalSettings.EnvironmentParticles != value)
			{
				globalSettings.SetEnvironmentParticles(value);
			}
		}

		public void SetCameraShake(bool value)
		{
			if (globalSettings.CameraShake != value)
			{
				globalSettings.SetCameraShake(value);
			}
		}

		public void SetMasterVolume(float value)
		{
			MonoSingleton<AudioManager>.Instance.SetBusVolume("bus:/", value);
			if (globalSettings.MasterVolume != value)
			{
				globalSettings.SetMasterVolume(value);
			}
		}

		public void SetMusicVolume(float value)
		{
			MonoSingleton<AudioManager>.Instance.SetBusVolume("bus:/Music", value);
			if (globalSettings.MusicVolume != value)
			{
				globalSettings.SetMusicVolume(value);
			}
		}

		public void SetSfxVolume(float value)
		{
			MonoSingleton<AudioManager>.Instance.SetBusVolume("bus:/SFX", value);
			MonoSingleton<AudioManager>.Instance.SetBusVolume("bus:/UI", value);
			if (globalSettings.SfxVolume != value)
			{
				globalSettings.SetSfxVolume(value);
			}
		}

		public void SetAmbienceVolume(float value)
		{
			MonoSingleton<AudioManager>.Instance.SetBusVolume("bus:/Ambience", value);
			if (globalSettings.AmbienceVolume != value)
			{
				globalSettings.SetAmbienceVolume(value);
			}
		}

		public void SetPlaylistPause(bool pauseOn)
		{
			if (globalSettings.PlaylistPause != pauseOn)
			{
				globalSettings.SetMusicPause(pauseOn);
				Dictionary<string, float> obj = new Dictionary<string, float> { 
				{
					"PlaylistPause",
					pauseOn ? 1 : 0
				} };
				this.PlaylistPauseChangeEvent?.Invoke(obj);
			}
		}

		public void SetAutosaveFrequency(int frequency)
		{
			SetAutosaveActive(frequency > 0);
			if (globalSettings.AutosaveFrequency != frequency)
			{
				globalSettings.SetAutosaveFrequency(frequency);
				this.AutosaveFrequencyChangedAction?.Invoke();
			}
		}

		public void SetAutosaveActive(bool toggleIsOn)
		{
			if (globalSettings.AutosaveActive != toggleIsOn)
			{
				globalSettings.SetAutosaveActive(toggleIsOn);
			}
		}

		public void SetTemperatureUnits(TemperatureUnitsType unitType)
		{
			if (globalSettings.TemperatureUnits != unitType)
			{
				globalSettings.SetTemperatureUnits(unitType);
				if (MonoSingleton<WeatherManager>.IsInstantiated())
				{
					MonoSingleton<WeatherManager>.Instance.OnTimeUpdate();
				}
				if (MonoSingleton<UIController>.IsInstantiated())
				{
					MonoSingleton<UIController>.Instance.OnTemperatureUnitsChange();
				}
			}
		}

		public void SetCameraSensitivity(float value)
		{
			globalSettings.SetCameraSensitivity(value);
		}

		public void SetDevTools(bool devToolsOn)
		{
			if (globalSettings.DevTools != devToolsOn)
			{
				globalSettings.SetDevTools(devToolsOn);
				if (MonoSingleton<UIController>.IsInstantiated())
				{
					MonoSingleton<UIController>.Instance.SetDevToolsActive(devToolsOn);
				}
			}
		}

		public void SetCameraVisuals(bool camVisualsOn)
		{
			if (globalSettings.CameraVisuals != camVisualsOn)
			{
				globalSettings.SetCameraVisuals(camVisualsOn);
			}
		}

		public void SetCameraVisualsDurationTime(float value)
		{
			globalSettings.SetCameraVisualsDurationTime(value);
			this.CameraVisualsDurationChangedEvent?.Invoke();
		}

		public void SetCameraOffsetByBuildings(bool isOn)
		{
			globalSettings.SetCameraOffsetByBuildings(isOn);
			this.SetCameraOffsetByBuildingsEvent?.Invoke();
		}

		public void SetShowWorkerNames(bool isOn)
		{
			if (globalSettings.ShowWorkerNames != isOn)
			{
				globalSettings.SetWorkerNames(isOn);
				this.ToggleWorkerNames?.Invoke(isOn);
			}
		}

		public void SetSendAutoReports(bool isOn)
		{
			if (globalSettings.SendAutoReports != isOn)
			{
				globalSettings.SetSendAutoReports(isOn);
			}
		}

		public void SetScreenEdgeMouseScrool(bool scrollOn)
		{
			if (globalSettings.ScreenEdgeMouseScroll != scrollOn)
			{
				globalSettings.SetScreenEdgeMouseScroll(scrollOn);
			}
		}

		public void SetShowTutorial(bool isOn)
		{
			if (globalSettings != null && globalSettings.ShowTutorial != isOn)
			{
				globalSettings.SetShowTutorial(isOn);
			}
		}

		public void SaveCurrentLanguage(string value)
		{
			globalSettings.SetLanguageName(value);
			this.LanguageChangedEvent?.Invoke();
		}

		public void SaveModSettings(IEnumerable<ModInstance> allGeneralMods)
		{
			globalSettings?.SaveModSettings(allGeneralMods);
		}

		public void SetEulaVersion(int version)
		{
			globalSettings.SetEulaVersion(version);
		}

		public void SetAnimalNameOption(int value)
		{
			if (globalSettings.ShowAnimalNameOption != value)
			{
				globalSettings.SetAnimalNames(value);
				this.ToggleAnimalNames?.Invoke();
			}
		}

		public void SetHoverIntensity(float value)
		{
			globalSettings.SetHoverIntensity(value);
			this.SetHoverIntensityEvent?.Invoke();
		}
	}
}
