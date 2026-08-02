using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Dissonance;
using Dissonance.Audio.Capture;
using GPUInstancerPro;
using GPUInstancerPro.PrefabModule;
using GPUInstancerPro.TerrainModule;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
	[Header("Data & Refs")]
	[SerializeField]
	private SettingsData settings;

	[SerializeField]
	private Volume globalVolume;

	[SerializeField]
	private Camera targetCamera;

	[SerializeField]
	private SliderManager mouseSliderManager;

	[SerializeField]
	private SwitchManager invertMouseSwitch;

	private Bloom bloom;

	private Vignette vignette;

	private DepthOfField dof;

	private MotionBlur mblur;

	private ChromaticAberration chroma;

	private FilmGrain grain;

	private bool mouseSynced;

	private DissonanceComms _voiceComms;

	public static SettingsManager Instance { get; private set; }

	private void Awake()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
		StartCoroutine(DelayedAwake());
	}

	private IEnumerator DelayedAwake()
	{
		yield return new WaitForSeconds(0.1f);
		if (Instance == null)
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
			SceneManager.sceneLoaded += OnSceneLoaded;
			InitializeSettings();
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		if ((bool)mouseSliderManager)
		{
			mouseSliderManager.mainSlider.onValueChanged.AddListener(OnMouseSensitivityChanged);
		}
		if ((bool)invertMouseSwitch)
		{
			invertMouseSwitch.onValueChanged.AddListener(OnInvertMouseChanged);
		}
	}

	public void SyncMouseSlider()
	{
		if (mouseSliderManager != null && mouseSliderManager.mainSlider != null)
		{
			mouseSliderManager.mainSlider.value = settings.mouseSensitivity;
			mouseSliderManager.UpdateUI();
		}
		mouseSynced = true;
	}

	public void SyncInvertMouseSwitch()
	{
		if (invertMouseSwitch != null)
		{
			invertMouseSwitch.isOn = settings.invertMouse;
			invertMouseSwitch.UpdateUI();
		}
	}

	private void OnInvertMouseChanged(bool value)
	{
		SetInvertMouse(value);
	}

	private void OnMouseSensitivityChanged(float v)
	{
		if (mouseSynced)
		{
			v = Mathf.Clamp(v, 0.0001f, 10f);
			settings.mouseSensitivity = v;
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("mouseSensitivity", v);
			}
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		StartCoroutine(RefreshSceneReferences());
	}

	private IEnumerator RefreshSceneReferences()
	{
		if (GPUIRenderingSystem.Instance != null)
		{
			Object.Destroy(GPUIRenderingSystem.Instance.gameObject);
		}
		yield return null;
		GPUIPrefabManager[] prefabManagers = Object.FindObjectsOfType<GPUIPrefabManager>(includeInactive: true);
		GPUIDetailManager[] detailManagers = Object.FindObjectsOfType<GPUIDetailManager>(includeInactive: true);
		GPUIPrefabManager[] array = prefabManagers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
		GPUIDetailManager[] array2 = detailManagers;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].enabled = false;
		}
		yield return null;
		array = prefabManagers;
		foreach (GPUIPrefabManager gPUIPrefabManager in array)
		{
			if (gPUIPrefabManager != null)
			{
				gPUIPrefabManager.enabled = true;
			}
		}
		array2 = detailManagers;
		foreach (GPUIDetailManager gPUIDetailManager in array2)
		{
			if (gPUIDetailManager != null)
			{
				gPUIDetailManager.enabled = true;
			}
		}
		yield return null;
		FindSceneReferences();
		ApplyAllGraphicsFromData();
		ApplyAudioFromData();
		ApplyVoiceFromData();
	}

	private void FindSceneReferences()
	{
		if (!targetCamera)
		{
			targetCamera = Camera.main;
		}
		if (!globalVolume)
		{
			globalVolume = Object.FindObjectOfType<Volume>();
		}
		if (!_voiceComms)
		{
			_voiceComms = Object.FindObjectOfType<DissonanceComms>();
		}
		if ((bool)globalVolume && (bool)globalVolume.profile)
		{
			VolumeProfile profile = globalVolume.profile;
			profile.TryGet<Bloom>(out bloom);
			profile.TryGet<Vignette>(out vignette);
			profile.TryGet<DepthOfField>(out dof);
			profile.TryGet<MotionBlur>(out mblur);
			profile.TryGet<ChromaticAberration>(out chroma);
			profile.TryGet<FilmGrain>(out grain);
		}
	}

	private void InitializeSettings()
	{
		FindSceneReferences();
		settings.RefreshAvailableResolutions();
		if (Singleton<SettingsSaveManager>.Instance == null || !Singleton<SettingsSaveManager>.Instance.HasSetting("hasInitialized"))
		{
			Debug.Log("First run detected - setting up defaults");
			settings.languageCode = "en";
			settings.fullscreenMode = FullScreenMode.FullScreenWindow;
			int num = -1;
			for (int num2 = settings.availableResolutions.Length - 1; num2 >= 0; num2--)
			{
				Resolution resolution = settings.availableResolutions[num2];
				if (resolution.width == Display.main.systemWidth && resolution.height == Display.main.systemHeight)
				{
					num = num2;
					break;
				}
			}
			if (num < 0)
			{
				num = settings.availableResolutions.Length - 1;
			}
			settings.resolutionIndex = num;
			settings.currentResolution = settings.availableResolutions[num];
			Screen.SetResolution(settings.currentResolution.width, settings.currentResolution.height, settings.fullscreenMode, settings.currentResolution.refreshRate);
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("hasInitialized", true);
				SaveAllCurrentSettings();
			}
		}
		else
		{
			LoadSettingsFromStorage();
			if (settings.currentResolution.width > 0 && settings.currentResolution.height > 0)
			{
				Screen.SetResolution(settings.currentResolution.width, settings.currentResolution.height, settings.fullscreenMode, settings.currentResolution.refreshRate);
			}
		}
		PlayerPrefs.SetInt("UnitySelectMonitor", settings.targetDisplay);
		ApplyTargetDisplay();
		ApplyLanguageFromData();
		ApplyAllGraphicsFromData();
		ApplyAudioFromData();
		ApplyVoiceFromData();
	}

	public void SetLanguageCode(string code)
	{
		settings.languageCode = code;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("languageCode", code);
		}
	}

	public void SetMouseSensitivity(float sensitivity)
	{
		settings.mouseSensitivity = Mathf.Clamp(sensitivity, 0.1f, 10f);
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("mouseSensitivity", settings.mouseSensitivity);
		}
	}

	public void SetInvertMouse(bool invert)
	{
		settings.invertMouse = invert;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("invertMouse", invert);
		}
	}

	public void SetShowTutorial(bool on)
	{
		settings.showTutorial = on;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("showTutorial", on);
		}
	}

	public void SetShowPlayerNames(bool show)
	{
		settings.showPlayerNames = show;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("showPlayerNames", show);
		}
	}

	public void SetShowCompass(bool show)
	{
		settings.showCompass = show;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("showCompass", show);
		}
	}

	public void SetTargetDisplay(int index)
	{
		List<DisplayInfo> list = new List<DisplayInfo>();
		Screen.GetDisplayLayout(list);
		index = Mathf.Clamp(index, 0, list.Count - 1);
		settings.targetDisplay = index;
		PlayerPrefs.SetInt("UnitySelectMonitor", index);
		if (index < list.Count)
		{
			StartCoroutine(MoveToDisplay(list[index]));
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("targetDisplay", index);
		}
	}

	private void ApplyTargetDisplay()
	{
		if (settings.targetDisplay != 0)
		{
			List<DisplayInfo> list = new List<DisplayInfo>();
			Screen.GetDisplayLayout(list);
			if (settings.targetDisplay < list.Count)
			{
				StartCoroutine(MoveToDisplay(list[settings.targetDisplay]));
			}
		}
	}

	private IEnumerator MoveToDisplay(DisplayInfo target)
	{
		FullScreenMode prevMode = settings.fullscreenMode;
		if (prevMode == FullScreenMode.ExclusiveFullScreen)
		{
			Screen.fullScreenMode = FullScreenMode.Windowed;
			yield return null;
		}
		Screen.MoveMainWindowTo(in target, Vector2Int.zero);
		yield return null;
		if (settings.currentResolution.width > 0 && settings.currentResolution.height > 0)
		{
			Screen.SetResolution(settings.currentResolution.width, settings.currentResolution.height, prevMode, settings.currentResolution.refreshRate);
		}
	}

	public void SetVSync(bool on)
	{
		settings.vSync = on;
		QualitySettings.vSyncCount = (on ? 1 : 0);
		if (on)
		{
			Application.targetFrameRate = -1;
		}
		else
		{
			ApplyTargetFps();
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("vSync", on);
		}
	}

	public void SetTargetFrameRate(int fps)
	{
		settings.targetFrameRate = fps;
		if (!settings.vSync)
		{
			ApplyTargetFps();
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("targetFrameRate", fps);
		}
	}

	private void ApplyTargetFps()
	{
		Application.targetFrameRate = ((settings.targetFrameRate <= 0) ? (-1) : settings.targetFrameRate);
	}

	public void SetFullscreenModeIndex(int idx)
	{
		FullScreenMode fullScreenMode = idx switch
		{
			1 => FullScreenMode.ExclusiveFullScreen, 
			0 => FullScreenMode.FullScreenWindow, 
			_ => FullScreenMode.Windowed, 
		};
		settings.fullscreenMode = fullScreenMode;
		Screen.fullScreenMode = fullScreenMode;
		Screen.fullScreen = fullScreenMode != FullScreenMode.Windowed;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("fullscreenMode", (int)fullScreenMode);
		}
	}

	public void SetResolutionIndex(int index)
	{
		if (settings.availableResolutions == null || settings.availableResolutions.Length == 0)
		{
			settings.RefreshAvailableResolutions();
		}
		index = Mathf.Clamp(index, 0, settings.availableResolutions.Length - 1);
		settings.resolutionIndex = index;
		Resolution currentResolution = settings.availableResolutions[index];
		Screen.SetResolution(currentResolution.width, currentResolution.height, settings.fullscreenMode, currentResolution.refreshRate);
		settings.currentResolution = currentResolution;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("resolutionIndex", index);
			Singleton<SettingsSaveManager>.Instance.SaveSetting("resolutionWidth", currentResolution.width);
			Singleton<SettingsSaveManager>.Instance.SaveSetting("resolutionHeight", currentResolution.height);
			Singleton<SettingsSaveManager>.Instance.SaveSetting("resolutionRefreshRate", currentResolution.refreshRate);
		}
	}

	public void SetTextureQuality(int index)
	{
		index = Mathf.Clamp(index, 0, 3);
		QualitySettings.globalTextureMipmapLimit = index;
		settings.textureQuality = (SettingsData.TextureOption)index;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("textureQuality", index);
		}
	}

	public void SetAnisotropicFiltering(int index)
	{
		index = Mathf.Clamp(index, 0, 2);
		settings.anisotropic = (SettingsData.AnisotropicOption)index;
		QualitySettings.anisotropicFiltering = index switch
		{
			1 => AnisotropicFiltering.Enable, 
			2 => AnisotropicFiltering.ForceEnable, 
			_ => AnisotropicFiltering.Disable, 
		};
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("anisotropic", index);
		}
	}

	public void SetDepthOfField(bool on)
	{
		settings.depthOfField = on;
		if ((bool)dof)
		{
			dof.active = on;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("depthOfField", on);
		}
	}

	public void SetMotionBlur(bool on)
	{
		settings.motionBlur = on;
		if ((bool)mblur)
		{
			mblur.active = on;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("motionBlur", on);
		}
	}

	public void SetChromaticAberration(bool on)
	{
		settings.chromaticAberration = on;
		if ((bool)chroma)
		{
			chroma.active = on;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("chromaticAberration", on);
		}
	}

	public void SetFilmGrain(bool on)
	{
		settings.filmGrain = on;
		if ((bool)grain)
		{
			grain.active = on;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("filmGrain", on);
		}
	}

	public void SetAntiAliasingMode(int index)
	{
		settings.aaMode = Mathf.Clamp(index, 0, 2);
		if ((bool)targetCamera)
		{
			UniversalAdditionalCameraData universalAdditionalCameraData = targetCamera.GetUniversalAdditionalCameraData();
			universalAdditionalCameraData.antialiasing = settings.aaMode switch
			{
				1 => AntialiasingMode.FastApproximateAntialiasing, 
				2 => AntialiasingMode.SubpixelMorphologicalAntiAliasing, 
				_ => AntialiasingMode.None, 
			};
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("aaMode", settings.aaMode);
			}
		}
	}

	public void SetAntiAliasingQuality(int index)
	{
		settings.aaQuality = Mathf.Clamp(index, 0, 2);
		if ((bool)targetCamera)
		{
			targetCamera.GetUniversalAdditionalCameraData().antialiasingQuality = (AntialiasingQuality)settings.aaQuality;
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("aaQuality", settings.aaQuality);
			}
		}
	}

	private UniversalRenderPipelineAsset GetActiveURP()
	{
		return ((QualitySettings.renderPipeline != null) ? QualitySettings.renderPipeline : GraphicsSettings.defaultRenderPipeline) as UniversalRenderPipelineAsset;
	}

	public void SetMSAA(int index)
	{
		settings.msaa = Mathf.Clamp(index, 0, 3);
		UniversalRenderPipelineAsset activeURP = GetActiveURP();
		if (!(activeURP == null))
		{
			int[] array = new int[4] { 1, 2, 4, 8 };
			activeURP.msaaSampleCount = array[settings.msaa];
			if (Singleton<SettingsSaveManager>.Instance != null)
			{
				Singleton<SettingsSaveManager>.Instance.SaveSetting("msaa", settings.msaa);
			}
		}
	}

	public void SetRenderQualityPreset(int level)
	{
		level = Mathf.Clamp(level, 0, 3);
		settings.qualityPreset = level;
		float renderScale;
		float lodBias;
		switch (level)
		{
		case 0:
			renderScale = 0.7f;
			lodBias = 0.7f;
			break;
		case 1:
			renderScale = 0.85f;
			lodBias = 1f;
			break;
		case 2:
			renderScale = 1f;
			lodBias = 1.5f;
			break;
		default:
			renderScale = 1.2f;
			lodBias = 2f;
			break;
		}
		SetRenderScale(renderScale);
		QualitySettings.lodBias = lodBias;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("qualityPreset", level);
		}
	}

	public void OnCloseSettingsPanel()
	{
		SaveAllCurrentSettings();
	}

	public void ResetToDefaults()
	{
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.DeleteAllSettings();
		}
		settings.ResetToDefaults();
		InitializeSettings();
	}

	public void SetRenderScale(float value)
	{
		settings.renderScale = Mathf.Clamp(value, 0.5f, 1.5f);
		UniversalRenderPipelineAsset activeURP = GetActiveURP();
		if (activeURP != null)
		{
			activeURP.renderScale = settings.renderScale;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("renderScale", settings.renderScale);
		}
	}

	public void SetMasterVolume(float volume)
	{
		settings.masterVolume = volume;
		if (Singleton<AudioManager>.Instance != null)
		{
			Singleton<AudioManager>.Instance.SetMaster(volume);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("masterVolume", volume);
		}
	}

	public void SetMusicVolume(float volume)
	{
		settings.musicVolume = volume;
		if (Singleton<AudioManager>.Instance != null)
		{
			Singleton<AudioManager>.Instance.SetMusic(volume);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("musicVolume", volume);
		}
	}

	public void SetSFXVolume(float volume)
	{
		settings.sfxVolume = volume;
		if (Singleton<AudioManager>.Instance != null)
		{
			Singleton<AudioManager>.Instance.SetSFX(volume);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("sfxVolume", volume);
		}
	}

	public void SetUIVolume(float volume)
	{
		settings.uiVolume = volume;
		if (Singleton<AudioManager>.Instance != null)
		{
			Singleton<AudioManager>.Instance.SetUI(volume);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("uiVolume", volume);
		}
	}

	public void SetAmbienceVolume(float volume)
	{
		settings.ambienceVolume = volume;
		if (Singleton<AudioManager>.Instance != null)
		{
			Singleton<AudioManager>.Instance.SetAmbience(volume);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("ambienceVolume", volume);
		}
	}

	public void SetMuteAudio(bool mute)
	{
		settings.muteAudio = mute;
		if (Singleton<AudioManager>.Instance != null)
		{
			Singleton<AudioManager>.Instance.SetMuted(mute);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("muteAudio", mute);
		}
	}

	public void SetVoiceInputVolume(float volume)
	{
		settings.voiceInputVolume = Mathf.Clamp01(volume);
		BasicMicrophoneCapture.InputGain = settings.voiceInputVolume;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("voiceInputVolume", settings.voiceInputVolume);
		}
	}

	public void SetVoiceOutputVolume(float volume)
	{
		settings.voiceOutputVolume = Mathf.Clamp01(volume);
		if (!_voiceComms)
		{
			_voiceComms = Object.FindObjectOfType<DissonanceComms>();
		}
		if ((bool)_voiceComms)
		{
			_voiceComms.RemoteVoiceVolume = settings.voiceOutputVolume;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("voiceOutputVolume", settings.voiceOutputVolume);
		}
	}

	public void SetVoiceInputDevice(string deviceName)
	{
		settings.voiceInputDevice = deviceName ?? "";
		if (!_voiceComms)
		{
			_voiceComms = Object.FindObjectOfType<DissonanceComms>();
		}
		if ((bool)_voiceComms)
		{
			_voiceComms.MicrophoneName = (string.IsNullOrEmpty(settings.voiceInputDevice) ? null : settings.voiceInputDevice);
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("voiceInputDevice", settings.voiceInputDevice);
		}
	}

	public void SetVoiceInputDeviceByIndex(int index)
	{
		string[] devices = Microphone.devices;
		string voiceInputDevice = ((index <= 0 || index > devices.Length) ? "" : devices[index - 1]);
		SetVoiceInputDevice(voiceInputDevice);
	}

	public string[] GetVoiceInputDeviceOptions()
	{
		string[] devices = Microphone.devices;
		string[] array = new string[devices.Length + 1];
		array[0] = "Default";
		for (int i = 0; i < devices.Length; i++)
		{
			array[i + 1] = devices[i];
		}
		return array;
	}

	public int GetCurrentVoiceInputDeviceIndex()
	{
		if (string.IsNullOrEmpty(settings.voiceInputDevice))
		{
			return 0;
		}
		string[] devices = Microphone.devices;
		for (int i = 0; i < devices.Length; i++)
		{
			if (devices[i] == settings.voiceInputDevice)
			{
				return i + 1;
			}
		}
		return 0;
	}

	public void SetVoiceChatEnabled(bool enabled)
	{
		settings.voiceChatEnabled = enabled;
		if (!_voiceComms)
		{
			_voiceComms = Object.FindObjectOfType<DissonanceComms>();
		}
		if ((bool)_voiceComms)
		{
			_voiceComms.IsMuted = !enabled;
			_voiceComms.IsDeafened = !enabled;
		}
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("voiceChatEnabled", enabled);
		}
	}

	public void SetVoicePushToTalk(bool pushToTalk)
	{
		settings.voicePushToTalk = pushToTalk;
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSetting("voicePushToTalk", pushToTalk);
		}
	}

	private void ApplyVoiceFromData()
	{
		BasicMicrophoneCapture.InputGain = settings.voiceInputVolume;
		if (!_voiceComms)
		{
			_voiceComms = Object.FindObjectOfType<DissonanceComms>();
		}
		if ((bool)_voiceComms)
		{
			_voiceComms.RemoteVoiceVolume = settings.voiceOutputVolume;
			_voiceComms.MicrophoneName = (string.IsNullOrEmpty(settings.voiceInputDevice) ? null : settings.voiceInputDevice);
			_voiceComms.IsMuted = !settings.voiceChatEnabled;
			_voiceComms.IsDeafened = !settings.voiceChatEnabled;
		}
	}

	public void ApplyAllGraphicsFromData()
	{
		if ((bool)bloom)
		{
			bloom.active = true;
		}
		if ((bool)dof)
		{
			dof.active = settings.depthOfField;
		}
		if ((bool)mblur)
		{
			mblur.active = settings.motionBlur;
		}
		if ((bool)chroma)
		{
			chroma.active = settings.chromaticAberration;
		}
		if ((bool)grain)
		{
			grain.active = settings.filmGrain;
		}
		SetAntiAliasingMode(settings.aaMode);
		SetAntiAliasingQuality(settings.aaQuality);
		SetMSAA(settings.msaa);
		SetTextureQuality((int)settings.textureQuality);
		SetAnisotropicFiltering((int)settings.anisotropic);
		SetRenderQualityPreset(settings.qualityPreset);
		SetVSync(settings.vSync);
		if (!settings.vSync)
		{
			ApplyTargetFps();
		}
		Screen.fullScreenMode = settings.fullscreenMode;
		Screen.fullScreen = settings.fullscreenMode != FullScreenMode.Windowed;
	}

	private void ApplyAudioFromData()
	{
		if (!(Singleton<AudioManager>.Instance == null))
		{
			Singleton<AudioManager>.Instance.SetMuted(settings.muteAudio);
			Singleton<AudioManager>.Instance.SetMaster(settings.masterVolume);
			Singleton<AudioManager>.Instance.SetMusic(settings.musicVolume);
			Singleton<AudioManager>.Instance.SetSFX(settings.sfxVolume);
			Singleton<AudioManager>.Instance.SetUI(settings.uiVolume);
			Singleton<AudioManager>.Instance.SetAmbience(settings.ambienceVolume);
		}
	}

	private void ApplyLanguageFromData()
	{
		StartCoroutine(ApplyLanguageFromDataAsync());
	}

	private IEnumerator ApplyLanguageFromDataAsync()
	{
		yield return UnityEngine.Localization.Settings.LocalizationSettings.InitializationOperation;
		if (UnityEngine.Localization.Settings.LocalizationSettings.AvailableLocales == null)
		{
			Debug.LogWarning("LocalizationSettings.AvailableLocales is null - skipping language application");
			yield break;
		}
		List<Locale> locales = UnityEngine.Localization.Settings.LocalizationSettings.AvailableLocales.Locales;
		if (locales == null || locales.Count == 0)
		{
			Debug.LogWarning("No available locales found - skipping language application");
			yield break;
		}
		if (string.IsNullOrEmpty(settings.languageCode))
		{
			settings.languageCode = "en";
			Debug.Log("Language code was empty - defaulting to English");
		}
		foreach (Locale item in locales)
		{
			if (item != null && item.Identifier.Code == settings.languageCode)
			{
				UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale = item;
				SetThreadCulture(item);
				Debug.Log("Applied language from settings: " + settings.languageCode);
				yield break;
			}
		}
		Debug.LogWarning("Could not find locale for code '" + settings.languageCode + "' - attempting to default to English");
		foreach (Locale item2 in locales)
		{
			if (item2 != null && item2.Identifier.Code == "en")
			{
				UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale = item2;
				SetThreadCulture(item2);
				settings.languageCode = "en";
				Debug.Log("Defaulted to English locale");
				yield break;
			}
		}
		if (locales.Count > 0 && locales[0] != null)
		{
			UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale = locales[0];
			SetThreadCulture(locales[0]);
			settings.languageCode = locales[0].Identifier.Code;
			Debug.LogWarning("Could not find English - using first available locale: " + locales[0].name);
		}
	}

	public SettingsData GetSettingsData()
	{
		return settings;
	}

	private void LoadSettingsFromStorage()
	{
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.LoadSettingsData(settings);
		}
	}

	public void SaveAllCurrentSettings()
	{
		if (Singleton<SettingsSaveManager>.Instance != null)
		{
			Singleton<SettingsSaveManager>.Instance.SaveSettingsData(settings);
		}
	}

	public static void SetThreadCulture(Locale locale)
	{
		if (locale?.Identifier.CultureInfo != null)
		{
			Thread.CurrentThread.CurrentCulture = locale.Identifier.CultureInfo;
			Thread.CurrentThread.CurrentUICulture = locale.Identifier.CultureInfo;
		}
	}
}
