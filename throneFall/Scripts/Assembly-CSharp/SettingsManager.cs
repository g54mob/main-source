using System.Collections;
using System.Collections.Generic;
using Rewired;
using Steamworks;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{
	public enum MixerChannel
	{
		Master = 0,
		Music = 1,
		SFX = 2,
		Environment = 3
	}

	public enum ColorBlindMode
	{
		Off = 0,
		YellowEnemies = 1,
		OrangeEnemies = 2,
		PurpleEnemies = 3,
		WhiteEnemies = 4
	}

	private static SettingsManager instance;

	public UniversalRenderPipelineAsset renderAsset;

	public AudioMixer mixer;

	[HideInInspector]
	public UnityEvent onPPSettingsChange = new UnityEvent();

	[HideInInspector]
	public UnityEvent onUIScaleChange = new UnityEvent();

	[HideInInspector]
	public UnityEvent shouldDisplayExtraTipsChange = new UnityEvent();

	private bool fullscreen = true;

	private bool vSync;

	private Resolution currentResolution;

	private bool postProcessing = true;

	private MsaaQuality antiAliasing = MsaaQuality._4x;

	private float renderscale = 1f;

	private float volumeMaster;

	private float volumeSFX;

	private float volumeEnvironment;

	private float volumeMusic;

	private bool resetUnitFormationEveryMorning;

	private float uiReferenceResolutionFactor = 1f;

	private bool disableTooltips;

	private bool disableExtraTips;

	private ColorBlindMode colorblindMode;

	private string VIDEO_INITIALIZED = "Video_Initialized";

	private string VIDEO_RESOLUTION_WIDTH = "Video_ResWidth";

	private string VIDEO_RESOLUTION_HEIGHT = "Video_ResHeight";

	private string VIDEO_POSTPROCESSING = "Video_PostProcessing";

	private string VIDEO_FULLSCREEN = "Video_Fullscreen";

	private string VIDEO_VSYNC = "Video_Vsync";

	private string VIDEO_ANTIALIASING = "Video_AntiAliasing";

	private string VIDEO_RENDERSCALE = "Video_Renderscale";

	private string AUDIO_INITIALIZED = "Audio_Initialized_1.1";

	private string AUDIO_MASTER = "Audio_Master";

	private string AUDIO_MUSIC = "Audio_Music";

	private string AUDIO_SFX = "Audio_SFX";

	private string AUDIO_ENVIRONMENT = "Audio_Environment";

	private string MIXER_MASTER = "MasterVolume";

	private string MIXER_MUSIC = "SettingsMusicVolume";

	private string MIXER_SFX = "SettingsSFXVolume";

	private string MIXER_ENVIRONMENT = "SettingsEnvironmentVolume";

	private string GAMEPLAY_INITIALIZED = "Gameplay_Initialized_1.1";

	private string GAMEPLAY_RESET_UNIS_EVERY_MORNING = "Gameplay_ResetUnitFormationEveryMorning";

	private string GAMEPLAY_DISABLE_TOOLTIPS = "Gameplay_DisableTooltips";

	private string GAMEPLAY_DISABLE_EXTRATIPS = "Gameplay_DisableExtraTips";

	private string GAMEPLAY_UI_SCALE_FACTOR = "Gameplay_UIScaleFactor";

	private string GAMEPLAY_COLORBLIND = "Gameplay_Colorblind";

	private bool isInDefferedControlsLoadingCoroutine;

	public static SettingsManager Instance => instance;

	public bool Fullscreen => fullscreen;

	public bool VSync => vSync;

	public Resolution CurrentResolution => currentResolution;

	public bool PostProcessing => postProcessing;

	public MsaaQuality AntiAliasing => antiAliasing;

	public float Renderscale => renderscale;

	public float VolumeMaster => volumeMaster;

	public float VolumeSFX => volumeSFX;

	public float VolumeEnvironment => volumeEnvironment;

	public float VolumeMusic => volumeMusic;

	public bool ResetUnitFormationEveryMorning => resetUnitFormationEveryMorning;

	public float UiReferenceResolutionFactor => uiReferenceResolutionFactor;

	public bool DisableTooltips => disableTooltips;

	public bool DisableExtraTips => disableExtraTips;

	public ColorBlindMode ColorblindMode => colorblindMode;

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	private void Start()
	{
		LoadVideoSettingsFromPlayerPrefs();
		LoadAudioSettingsFromPlayerPrefs();
		LoadGameplaySettingsFromPlayerPrefs();
	}

	private void OnEnable()
	{
		StartCoroutine(LoadControlsConfigDeffered());
		ReInput.ControllerConnectedEvent += OnControllerConnect;
	}

	private void OnDisable()
	{
		ReInput.ControllerDisconnectedEvent -= OnControllerConnect;
	}

	private void OnControllerConnect(ControllerStatusChangedEventArgs e)
	{
		StartCoroutine(LoadControlsConfigDeffered());
	}

	private IEnumerator LoadControlsConfigDeffered()
	{
		if (!isInDefferedControlsLoadingCoroutine)
		{
			isInDefferedControlsLoadingCoroutine = true;
			yield return null;
			ControlConfigSaveLoad.LoadControlConfigFromJson();
			isInDefferedControlsLoadingCoroutine = false;
		}
	}

	public void SetResolution(Resolution newRes)
	{
		List<Resolution> list = new List<Resolution>(Screen.resolutions);
		bool flag = false;
		foreach (Resolution item in list)
		{
			if (newRes.CompareResolutions(item))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			newRes = Screen.currentResolution;
		}
		currentResolution = newRes;
		FullScreenMode fullscreenMode = FullScreenMode.FullScreenWindow;
		if (!fullscreen)
		{
			fullscreenMode = FullScreenMode.Windowed;
		}
		Screen.SetResolution(currentResolution.width, currentResolution.height, fullscreenMode, currentResolution.refreshRateRatio);
		PlayerPrefs.SetInt(VIDEO_RESOLUTION_WIDTH, currentResolution.width);
		PlayerPrefs.SetInt(VIDEO_RESOLUTION_HEIGHT, currentResolution.height);
	}

	public void SetVSync(bool active)
	{
		vSync = active;
		if (active)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
		PlayerPrefs.SetInt(VIDEO_VSYNC, active ? 1 : 0);
	}

	public void SetPostProcessing(bool active)
	{
		postProcessing = active;
		onPPSettingsChange.Invoke();
		PlayerPrefs.SetInt(VIDEO_POSTPROCESSING, active ? 1 : 0);
	}

	public void SetAntiAliasing(MsaaQuality quality)
	{
		antiAliasing = quality;
		renderAsset.msaaSampleCount = (int)antiAliasing;
		PlayerPrefs.SetInt(VIDEO_ANTIALIASING, AALevelToInt(antiAliasing));
	}

	public void SetColorblind(ColorBlindMode _colorblind)
	{
		colorblindMode = _colorblind;
		if ((bool)ColorAndLightManager.Instance)
		{
			ColorAndLightManager.Instance.EasyReloadColorScheme();
		}
		PlayerPrefs.SetInt(GAMEPLAY_COLORBLIND, (int)colorblindMode);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		fullscreen = isFullscreen;
		Screen.fullScreen = isFullscreen;
		PlayerPrefs.SetInt(VIDEO_FULLSCREEN, isFullscreen ? 1 : 0);
	}

	public void SetShadowResolution(int res)
	{
	}

	public void SetRenderscale(float scale)
	{
		renderscale = scale;
		renderAsset.renderScale = renderscale;
		PlayerPrefs.SetFloat(VIDEO_RENDERSCALE, renderscale);
	}

	public void SetAudioValue(float value, MixerChannel channel)
	{
		string text;
		switch (channel)
		{
		case MixerChannel.Environment:
			volumeEnvironment = value;
			PlayerPrefs.SetFloat(AUDIO_ENVIRONMENT, value);
			text = MIXER_ENVIRONMENT;
			break;
		case MixerChannel.Music:
			volumeMusic = value;
			PlayerPrefs.SetFloat(AUDIO_MUSIC, value);
			text = MIXER_MUSIC;
			break;
		case MixerChannel.SFX:
			volumeSFX = value;
			PlayerPrefs.SetFloat(AUDIO_SFX, value);
			text = MIXER_SFX;
			break;
		case MixerChannel.Master:
			volumeMaster = value;
			PlayerPrefs.SetFloat(AUDIO_MASTER, value);
			text = MIXER_MASTER;
			break;
		default:
			text = MIXER_MASTER;
			break;
		}
		mixer.SetFloat(text, PercentageToAudioLogarithmic(value));
	}

	public float GetAudioVolume(MixerChannel channel)
	{
		return channel switch
		{
			MixerChannel.Environment => volumeEnvironment, 
			MixerChannel.Music => volumeMusic, 
			MixerChannel.SFX => volumeSFX, 
			MixerChannel.Master => volumeMaster, 
			_ => volumeMaster, 
		};
	}

	public static float PercentageToAudioLogarithmic(float value)
	{
		if ((double)value < 0.0001)
		{
			value = 0.0001f;
		}
		if (value > 1f)
		{
			value = 1f;
		}
		value = Mathf.Log10(value) * 20f;
		return value;
	}

	public void SetResetUnitsInTheMorning(bool value)
	{
		resetUnitFormationEveryMorning = value;
		PlayerPrefs.SetInt(GAMEPLAY_RESET_UNIS_EVERY_MORNING, value ? 1 : 0);
	}

	public void SetDisableTooltips(bool value)
	{
		disableTooltips = value;
		PlayerPrefs.SetInt(GAMEPLAY_DISABLE_TOOLTIPS, value ? 1 : 0);
	}

	public void SetDisableExtraTips(bool value)
	{
		disableExtraTips = value;
		PlayerPrefs.SetInt(GAMEPLAY_DISABLE_EXTRATIPS, value ? 1 : 0);
		shouldDisplayExtraTipsChange.Invoke();
	}

	public void SetUIReferenceResolutionScaleFactor(float factor)
	{
		uiReferenceResolutionFactor = factor;
		PlayerPrefs.SetFloat(GAMEPLAY_UI_SCALE_FACTOR, uiReferenceResolutionFactor);
		onUIScaleChange.Invoke();
	}

	public static int AALevelToInt(MsaaQuality level)
	{
		return level switch
		{
			MsaaQuality.Disabled => 0, 
			MsaaQuality._2x => 1, 
			MsaaQuality._4x => 2, 
			MsaaQuality._8x => 3, 
			_ => 0, 
		};
	}

	public static MsaaQuality IntToAALevel(int i)
	{
		return i switch
		{
			0 => MsaaQuality.Disabled, 
			1 => MsaaQuality._2x, 
			2 => MsaaQuality._4x, 
			3 => MsaaQuality._8x, 
			_ => MsaaQuality.Disabled, 
		};
	}

	private void InitializeVideoSettingsToPlayerPrefs()
	{
		Resolution resolution = Screen.resolutions[Screen.resolutions.Length - 1];
		PlayerPrefs.SetInt(VIDEO_RESOLUTION_WIDTH, resolution.width);
		PlayerPrefs.SetInt(VIDEO_RESOLUTION_HEIGHT, resolution.height);
		PlayerPrefs.SetInt(VIDEO_FULLSCREEN, 1);
		PlayerPrefs.SetInt(VIDEO_VSYNC, 1);
		PlayerPrefs.SetInt(VIDEO_POSTPROCESSING, 1);
		PlayerPrefs.SetInt(VIDEO_ANTIALIASING, AALevelToInt(MsaaQuality._4x));
		PlayerPrefs.SetFloat(VIDEO_RENDERSCALE, 1f);
		PlayerPrefs.SetInt(VIDEO_INITIALIZED, 1);
	}

	private void LoadVideoSettingsFromPlayerPrefs()
	{
		if (PlayerPrefs.GetInt(VIDEO_INITIALIZED) == 0)
		{
			InitializeVideoSettingsToPlayerPrefs();
		}
		Resolution resolution = new Resolution
		{
			width = PlayerPrefs.GetInt(VIDEO_RESOLUTION_WIDTH),
			height = PlayerPrefs.GetInt(VIDEO_RESOLUTION_HEIGHT)
		};
		fullscreen = PlayerPrefs.GetInt(VIDEO_FULLSCREEN) != 0;
		vSync = PlayerPrefs.GetInt(VIDEO_VSYNC) != 0;
		renderscale = PlayerPrefs.GetFloat(VIDEO_RENDERSCALE);
		SetVSync(vSync);
		SetResolution(resolution);
		SetPostProcessing(PlayerPrefs.GetInt(VIDEO_POSTPROCESSING) != 0);
		SetAntiAliasing(IntToAALevel(PlayerPrefs.GetInt(VIDEO_ANTIALIASING)));
		SetRenderscale(renderscale);
	}

	private void InitializeAudioSettingsToPlayerPrefs()
	{
		PlayerPrefs.SetFloat(AUDIO_MASTER, 0.6f);
		PlayerPrefs.SetFloat(AUDIO_MUSIC, 1f);
		PlayerPrefs.SetFloat(AUDIO_SFX, 1f);
		PlayerPrefs.SetFloat(AUDIO_ENVIRONMENT, 1f);
		PlayerPrefs.SetInt(AUDIO_INITIALIZED, 1);
	}

	private void LoadAudioSettingsFromPlayerPrefs()
	{
		if (PlayerPrefs.GetInt(AUDIO_INITIALIZED) == 0)
		{
			InitializeAudioSettingsToPlayerPrefs();
		}
		volumeMaster = PlayerPrefs.GetFloat(AUDIO_MASTER);
		volumeMusic = PlayerPrefs.GetFloat(AUDIO_MUSIC);
		volumeSFX = PlayerPrefs.GetFloat(AUDIO_SFX);
		volumeEnvironment = PlayerPrefs.GetFloat(AUDIO_ENVIRONMENT);
		SetAudioValue(volumeMaster, MixerChannel.Master);
		SetAudioValue(volumeMusic, MixerChannel.Music);
		SetAudioValue(volumeEnvironment, MixerChannel.Environment);
		SetAudioValue(volumeSFX, MixerChannel.SFX);
	}

	private void InitializeGameplaySettingsToPlayerPrefs()
	{
		PlayerPrefs.SetInt(GAMEPLAY_RESET_UNIS_EVERY_MORNING, 1);
		PlayerPrefs.SetFloat(GAMEPLAY_UI_SCALE_FACTOR, 1f);
		if (SteamManager.Initialized && SteamUtils.IsSteamRunningOnSteamDeck())
		{
			PlayerPrefs.SetFloat(GAMEPLAY_UI_SCALE_FACTOR, 0.8f);
		}
		PlayerPrefs.SetInt(GAMEPLAY_DISABLE_TOOLTIPS, 0);
		PlayerPrefs.SetInt(GAMEPLAY_DISABLE_EXTRATIPS, 0);
		PlayerPrefs.SetInt(GAMEPLAY_INITIALIZED, 1);
		PlayerPrefs.SetInt(GAMEPLAY_COLORBLIND, 0);
	}

	private void LoadGameplaySettingsFromPlayerPrefs()
	{
		if (PlayerPrefs.GetInt(GAMEPLAY_INITIALIZED) == 0)
		{
			InitializeGameplaySettingsToPlayerPrefs();
		}
		resetUnitFormationEveryMorning = PlayerPrefs.GetInt(GAMEPLAY_RESET_UNIS_EVERY_MORNING) != 0;
		uiReferenceResolutionFactor = PlayerPrefs.GetFloat(GAMEPLAY_UI_SCALE_FACTOR);
		disableTooltips = PlayerPrefs.GetInt(GAMEPLAY_DISABLE_TOOLTIPS) != 0;
		disableExtraTips = PlayerPrefs.GetInt(GAMEPLAY_DISABLE_EXTRATIPS) != 0;
		colorblindMode = (ColorBlindMode)PlayerPrefs.GetInt(GAMEPLAY_COLORBLIND, 0);
		if (uiReferenceResolutionFactor < 0.001f)
		{
			uiReferenceResolutionFactor = 1f;
			PlayerPrefs.SetFloat(GAMEPLAY_UI_SCALE_FACTOR, 1f);
			if (SteamManager.Initialized && SteamUtils.IsSteamRunningOnSteamDeck())
			{
				uiReferenceResolutionFactor = 1f;
				PlayerPrefs.SetFloat(GAMEPLAY_UI_SCALE_FACTOR, 0.8f);
			}
		}
		if (uiReferenceResolutionFactor < 0.8f || uiReferenceResolutionFactor > 1.2f)
		{
			uiReferenceResolutionFactor = Mathf.Clamp(uiReferenceResolutionFactor, 0.8f, 1.2f);
			SetUIReferenceResolutionScaleFactor(uiReferenceResolutionFactor);
		}
	}

	public void ResetVideoSettings()
	{
		InitializeVideoSettingsToPlayerPrefs();
		LoadVideoSettingsFromPlayerPrefs();
	}

	public void ResetAudioSettings()
	{
		InitializeAudioSettingsToPlayerPrefs();
		LoadAudioSettingsFromPlayerPrefs();
	}

	public void ResetGameplaySettings()
	{
		InitializeGameplaySettingsToPlayerPrefs();
		LoadGameplaySettingsFromPlayerPrefs();
	}

	public void ResetGameProgress()
	{
		GameProgressResetter.ResetAndBackupAllGameProgress();
	}
}
