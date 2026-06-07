using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsController : MonoBehaviour
{
	public static SettingsController instance;

	[SerializeField]
	private InputActionAsset inputActions;

	private bool screenBorderCameraMovementEnabled = true;

	private float cameraSpeedMultiplier = 1f;

	private bool cursorLockedToWindow = true;

	private bool seasonalContentEnabled = true;

	private bool screenShakeEnabled = true;

	private bool autoLootChests;

	public bool CursorLockedToWindow
	{
		get
		{
			return cursorLockedToWindow;
		}
		set
		{
			cursorLockedToWindow = value;
			Cursor.lockState = (CursorLockedToWindow ? CursorLockMode.Confined : CursorLockMode.None);
			PlayerPrefs.SetInt("CursorLockedToWindow", CursorLockedToWindow ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	public float CameraSpeedMultiplier
	{
		get
		{
			return cameraSpeedMultiplier;
		}
		set
		{
			cameraSpeedMultiplier = value;
			PlayerPrefs.SetFloat("CameraSpeedMultiplier", cameraSpeedMultiplier);
			PlayerPrefs.Save();
		}
	}

	public bool ScreenBorderCameraMovementEnabled
	{
		get
		{
			return screenBorderCameraMovementEnabled;
		}
		set
		{
			screenBorderCameraMovementEnabled = value;
			PlayerPrefs.SetInt("ScreenBorderCameraMovement", ScreenBorderCameraMovementEnabled ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	public bool SeasonalContentEnabled
	{
		get
		{
			return seasonalContentEnabled;
		}
		set
		{
			seasonalContentEnabled = value;
			PlayerPrefs.SetInt("SeasonalContent", seasonalContentEnabled ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	public bool ScreenShakeEnabled
	{
		get
		{
			return screenShakeEnabled;
		}
		set
		{
			screenShakeEnabled = value;
			PlayerPrefs.SetInt("ScreenShakeEnabled", ScreenShakeEnabled ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	public bool AutoLootChests
	{
		get
		{
			return autoLootChests;
		}
		set
		{
			autoLootChests = value;
			PlayerPrefs.SetInt("AutoLootChests", AutoLootChests ? 1 : 0);
			PlayerPrefs.Save();
		}
	}

	private void Awake()
	{
		if (!instance)
		{
			instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		LoadPlayerPrefs();
	}

	private void LoadPlayerPrefs()
	{
		if (PlayerPrefs.HasKey("CameraSpeedMultiplier"))
		{
			CameraSpeedMultiplier = PlayerPrefs.GetFloat("CameraSpeedMultiplier");
		}
		if (PlayerPrefs.HasKey("ScreenBorderCameraMovement"))
		{
			ScreenBorderCameraMovementEnabled = PlayerPrefs.GetInt("ScreenBorderCameraMovement") == 1;
		}
		if (PlayerPrefs.HasKey("CursorLockedToWindow"))
		{
			CursorLockedToWindow = PlayerPrefs.GetInt("CursorLockedToWindow") == 1;
		}
		else
		{
			CursorLockedToWindow = true;
		}
		if (PlayerPrefs.HasKey("SeasonalContent"))
		{
			SeasonalContentEnabled = PlayerPrefs.GetInt("SeasonalContent") == 1;
		}
		if (PlayerPrefs.HasKey("ScreenShakeEnabled"))
		{
			ScreenShakeEnabled = PlayerPrefs.GetInt("ScreenShakeEnabled") == 1;
		}
		if (PlayerPrefs.HasKey("AutoLootChests"))
		{
			AutoLootChests = PlayerPrefs.GetInt("AutoLootChests") == 1;
		}
		int value = 0;
		if (PlayerPrefs.HasKey("VSync"))
		{
			value = PlayerPrefs.GetInt("VSync");
		}
		SetVSync(Convert.ToBoolean(value));
		int targetFPS = 60;
		if (PlayerPrefs.HasKey("TargetFramerate"))
		{
			targetFPS = PlayerPrefs.GetInt("TargetFramerate");
		}
		SetTargetFPS(targetFPS);
		if (PlayerPrefs.HasKey("TargetFramerate"))
		{
			targetFPS = PlayerPrefs.GetInt("TargetFramerate");
		}
		LoadInputActions();
	}

	public void SetScreenResolution(int width, int height, FullScreenMode fullScreenMode)
	{
		Screen.SetResolution(width, height, fullScreenMode);
	}

	public void SetVSync(bool enabled)
	{
		QualitySettings.vSyncCount = (enabled ? 1 : 0);
		PlayerPrefs.SetInt("VSync", QualitySettings.vSyncCount);
		PlayerPrefs.Save();
	}

	public bool IsVSyncEnabled()
	{
		return QualitySettings.vSyncCount > 0;
	}

	public void SetTargetFPS(int fps)
	{
		Application.targetFrameRate = fps;
		PlayerPrefs.SetInt("TargetFramerate", fps);
		PlayerPrefs.Save();
	}

	public int GetTargetFPS()
	{
		return Application.targetFrameRate;
	}

	public float GetMasterVolume()
	{
		return AudioSystem.Instance.GetMixerVolumePercentage(AudioSystem.EAudioMixerGroup.Master);
	}

	public void SetMasterVolume(float percentage, bool updateMixer = true)
	{
		if (updateMixer)
		{
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.Master);
		}
		PlayerPrefs.SetFloat("MasterVolumePercentage", percentage);
		PlayerPrefs.Save();
	}

	public float GetMusicVolume()
	{
		return AudioSystem.Instance.GetMixerVolumePercentage(AudioSystem.EAudioMixerGroup.Music);
	}

	public void SetMusicVolume(float percentage, bool updateMixer = true)
	{
		if (updateMixer)
		{
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.Music);
		}
		PlayerPrefs.SetFloat("MusicVolumePercentage", percentage);
		PlayerPrefs.Save();
	}

	public float GetSFXVolume()
	{
		return AudioSystem.Instance.GetMixerVolumePercentage(AudioSystem.EAudioMixerGroup.SFX);
	}

	public void SetSFXVolume(float percentage, bool updateMixer = true)
	{
		if (updateMixer)
		{
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.SFX);
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.Ambience);
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.UI);
		}
		PlayerPrefs.SetFloat("SoundVolumePercentage", percentage);
		PlayerPrefs.Save();
	}

	public float GetUIVolume()
	{
		return AudioSystem.Instance.GetMixerVolumePercentage(AudioSystem.EAudioMixerGroup.UI);
	}

	public void SetUIVolume(float percentage, bool updateMixer = true)
	{
		if (updateMixer)
		{
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.UI);
		}
		PlayerPrefs.SetFloat("UIVolumePercentage", percentage);
		PlayerPrefs.Save();
	}

	public float GetAmbienceVolume()
	{
		return AudioSystem.Instance.GetMixerVolumePercentage(AudioSystem.EAudioMixerGroup.Ambience);
	}

	public void SetAmbienceVolume(float percentage, bool updateMixer = true)
	{
		if (updateMixer)
		{
			AudioSystem.Instance.SetMixerVolume(percentage, AudioSystem.EAudioMixerGroup.Ambience);
		}
		PlayerPrefs.SetFloat("AmbienceVolumePercentage", percentage);
		PlayerPrefs.Save();
	}

	public void SaveInputActions()
	{
		if ((bool)inputActions)
		{
			string value = inputActions.SaveBindingOverridesAsJson();
			PlayerPrefs.SetString("rebinds", value);
		}
	}

	public void LoadInputActions()
	{
		if ((bool)inputActions)
		{
			string text = PlayerPrefs.GetString("rebinds");
			if (!string.IsNullOrEmpty(text))
			{
				inputActions.LoadBindingOverridesFromJson(text);
			}
		}
	}
}
