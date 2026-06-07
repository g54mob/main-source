using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;

public class SettingsManager : MonoBehaviour
{
	public AudioMixerGroup masterMix;

	public AudioMixerGroup effectsMix;

	public AudioMixerGroup ambienceMix;

	public List<Setting> settings;

	private SettingsSaveData settingsSaveData;

	public Setting speedrunModeSetting;

	public Setting speedChessModeSetting;

	public Setting fullscreenSetting;

	public Setting resolutionSetting;

	public Setting maxFpsSetting;

	public Setting vSyncSetting;

	public Setting masterVolumeSetting;

	public Setting effectsVolumeSetting;

	public Setting ambienceVolumeSetting;

	public Setting languageSetting;

	public Setting screenshakeSetting;

	private static bool isInitialized;

	public void Awake()
	{
		this.settingsSaveData = new SettingsSaveData();
		SettingsSaveData settingsSaveData = LoadSettingsSaveData();
		if (settingsSaveData == null)
		{
			foreach (Setting setting in settings)
			{
				setting.currentOption = setting.settingOptions[0];
			}
			SettingsToData();
			SaveSettingsSaveData(this.settingsSaveData);
		}
		else
		{
			this.settingsSaveData = settingsSaveData;
			DataToSettings();
		}
	}

	public void Start()
	{
		if (!isInitialized)
		{
			ApplySettings();
			isInitialized = true;
		}
	}

	public static SettingsSaveData LoadSettingsSaveData()
	{
		string text = FileHandler.ReadString("player_settings");
		if (text == null)
		{
			return null;
		}
		return JsonUtility.FromJson<SettingsSaveData>(text);
	}

	public static void SaveSettingsSaveData(SettingsSaveData settingsSaveData)
	{
		string input = JsonUtility.ToJson(settingsSaveData);
		FileHandler.WriteString("player_settings", input);
	}

	public void SettingsToData()
	{
		settingsSaveData.settingContainers.Clear();
		foreach (Setting setting in settings)
		{
			SettingContainerData settingContainerData = new SettingContainerData();
			settingContainerData.settingID = setting.settingID;
			settingContainerData.settingValue = setting.currentOption.settingValue;
			settingsSaveData.settingContainers.Add(settingContainerData);
		}
	}

	public void DataToSettings()
	{
		foreach (SettingContainerData settingContainer in settingsSaveData.settingContainers)
		{
			foreach (Setting setting in settings)
			{
				if (!(settingContainer.settingID == setting.settingID))
				{
					continue;
				}
				foreach (SettingOption settingOption in setting.settingOptions)
				{
					if (settingOption.settingValue[0] == settingContainer.settingValue[0])
					{
						setting.currentOption = settingOption;
					}
				}
			}
		}
	}

	public void ApplySettings()
	{
		ApplySpeedrunModeSetting();
		ApplySpeedChessModeSetting();
		ApplyResolutionSetting();
		ApplyFullScreenSetting();
		ApplyMaxFpsSetting();
		ApplyVSyncSetting();
		ApplyAudioSettings();
		ApplyLanguageSettings();
		ApplyScreenshakeSettings();
		SettingsToData();
		SaveSettingsSaveData(settingsSaveData);
	}

	public void ApplySpeedrunModeSetting()
	{
		if (speedrunModeSetting.currentOption.settingValue[0] == 0f)
		{
			SpeedrunTimer.doSpeedrunTimer = false;
		}
		else
		{
			SpeedrunTimer.doSpeedrunTimer = true;
		}
	}

	public void ApplySpeedChessModeSetting()
	{
		if (speedChessModeSetting.currentOption.settingValue[0] != 0f)
		{
			SpeedChessManager.doSpeedChess = true;
		}
		else
		{
			SpeedChessManager.doSpeedChess = false;
		}
		SpeedChessManager.speedChessTime = speedChessModeSetting.currentOption.settingValue[0];
	}

	private void ApplyFullScreenSetting()
	{
		if (fullscreenSetting.currentOption.settingValue[0] > 0f)
		{
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
		}
		else
		{
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
	}

	private void ApplyResolutionSetting()
	{
		float num = resolutionSetting.currentOption.settingValue[0];
		float num2 = resolutionSetting.currentOption.settingValue[1];
		Screen.SetResolution((int)num, (int)num2, Screen.fullScreenMode, Screen.currentResolution.refreshRateRatio);
	}

	private void ApplyMaxFpsSetting()
	{
		Application.targetFrameRate = (int)maxFpsSetting.currentOption.settingValue[0];
	}

	private void ApplyVSyncSetting()
	{
		QualitySettings.vSyncCount = (int)vSyncSetting.currentOption.settingValue[0];
	}

	public void ApplyAudioSettings()
	{
		masterMix.audioMixer.SetFloat("MasterVolume", CalculateVolume(masterVolumeSetting.currentOption.settingValue[0]));
		effectsMix.audioMixer.SetFloat("EffectsVolume", CalculateVolume(effectsVolumeSetting.currentOption.settingValue[0]));
		ambienceMix.audioMixer.SetFloat("AmbienceVolume", CalculateVolume(ambienceVolumeSetting.currentOption.settingValue[0]));
	}

	public void ApplyLanguageSettings()
	{
		StartCoroutine(SetLocale((int)languageSetting.currentOption.settingValue[0]));
	}

	public IEnumerator SetLocale(int localeID)
	{
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
	}

	private void ApplyScreenshakeSettings()
	{
		if (screenshakeSetting.currentOption.settingValue[0] == 0f)
		{
			AccessibilityManager.doScreenshake = false;
		}
		else
		{
			AccessibilityManager.doScreenshake = true;
		}
	}

	private float CalculateVolume(float value)
	{
		return (40f - value / 100f * 40f) * -1f;
	}
}
