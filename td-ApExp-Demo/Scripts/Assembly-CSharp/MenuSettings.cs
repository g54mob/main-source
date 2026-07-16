using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class MenuSettings : Menu, ISaveable
{
	[Header("Settings")]
	public int maxResolutionMultiplier = 4;

	public int windowedWindowWidth = 960;

	public int windowedWindowHeight = 540;

	public AudioMixer audioMixer;

	public int resolutionIndex;

	public int fullscreenMode;

	public int chosenLanguage;

	public int chosenGameSpeed = 2;

	[Header("UI Elements")]
	[Header("Graphics")]
	public TMP_Dropdown windowModeDropdown;

	public TMP_Dropdown resolutionDropdown;

	[SerializeField]
	private Toggle VSyncToggle;

	[SerializeField]
	private Toggle MotionBlurToggle;

	[SerializeField]
	private Toggle FreeCameraToggle;

	[SerializeField]
	private Toggle BloomToggle;

	[SerializeField]
	private Toggle CameraShakeToggle;

	[Header("Volume Sliders")]
	[SerializeField]
	private Slider volumeSliderMaster;

	[SerializeField]
	private Slider volumeSliderMusic;

	[SerializeField]
	private Slider volumeSliderSFX;

	[Header("Gameplay")]
	[SerializeField]
	private Toggle DataTrackingToggle;

	[SerializeField]
	private Toggle ShowRoofsToggle;

	public TMP_Dropdown languageDropdown;

	public Slider gameSpeedSlider;

	[SerializeField]
	private Toggle ShowResourcePickupToggle;

	[SerializeField]
	private Toggle ShowHullDamageToggle;

	[Header("Components")]
	[Header("Bloom")]
	[SerializeField]
	private Volume postProcessingVolume;

	[SerializeField]
	private Material bloomMat;

	private Bloom bloom;

	private float volumeMaster;

	private float volumeMusic;

	private float volumeSFX;

	public bool isScreenStateDirty;

	[NonSerialized]
	public int lastGameSpeed = 999;

	[field: SerializeField]
	public AYellowpaper.SerializedCollections.SerializedDictionary<string, bool> languages { get; private set; }

	[field: SerializeField]
	public AYellowpaper.SerializedCollections.SerializedDictionary<string, float> gameSpeedSettings { get; private set; }

	public static event Action OnShowRoofsToggled;

	public void HandleVSyncToggled(bool isOn)
	{
		QualitySettings.vSyncCount = (isOn ? 1 : 0);
	}

	public void HandleMotionBlurToggled(bool isOn)
	{
		TrackManager.Instance.IsMotionBlurEnabled = isOn;
	}

	public void HandleFreeCameraToggled(bool isOn)
	{
		CameraController.Instance.IsCameraFree = isOn;
	}

	public void HandleBloomToggled(bool isOn)
	{
		if ((bool)bloom)
		{
			bloom.active = isOn;
			bloomMat.SetFloat("_EnableBloom", isOn ? 1f : 0f);
		}
	}

	public void HandleCameraShakeToggled(bool isOn)
	{
		CameraController.Instance.IsShakeEnabled = isOn;
	}

	public void HandleShowRoofsToggled(bool isOn)
	{
		SaveManager.Instance.SetShowRoofOnEmptyWagons(isOn);
		Train.ShowRoofOnEmptyWagons = isOn;
		MenuSettings.OnShowRoofsToggled?.Invoke();
	}

	public void HandleDataTrackingToggle(bool isOn)
	{
		SaveManager.Instance.SetDataTrackingEnabled(isOn);
	}

	public void HandleResourcePickupToggle(bool isOn)
	{
		SaveManager.Instance.ShowResourcePickupText = isOn;
	}

	public void HandleHullDamageToggle(bool isOn)
	{
		SaveManager.Instance.ShowHullDamageText = isOn;
	}

	private new void Awake()
	{
		base.Awake();
		VSyncToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleVSyncToggled(isOn);
		});
		MotionBlurToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleMotionBlurToggled(isOn);
		});
		FreeCameraToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleFreeCameraToggled(isOn);
		});
		BloomToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleBloomToggled(isOn);
		});
		CameraShakeToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleCameraShakeToggled(isOn);
		});
		volumeSliderMaster.onValueChanged.AddListener(delegate(float value)
		{
			SetMasterVolume(value);
		});
		volumeSliderMusic.onValueChanged.AddListener(delegate(float value)
		{
			SetMusicVolume(value);
		});
		volumeSliderSFX.onValueChanged.AddListener(delegate(float value)
		{
			SetSFXVolume(value);
		});
		ShowRoofsToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleShowRoofsToggled(isOn);
		});
		DataTrackingToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleDataTrackingToggle(isOn);
		});
		ShowResourcePickupToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleResourcePickupToggle(isOn);
		});
		ShowHullDamageToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			HandleHullDamageToggle(isOn);
		});
	}

	public void Start()
	{
		StartCoroutine(SetupFullscreenDropdown());
		SetupLanguageDropdown();
		windowModeDropdown.onValueChanged.AddListener(SetWindowMode);
		resolutionDropdown.onValueChanged.AddListener(SetResolution);
		languageDropdown.onValueChanged.AddListener(SetLanguage);
		gameSpeedSlider.onValueChanged.AddListener(SetGameSpeed);
		UpdateMenuState();
	}

	protected override void OnOpen()
	{
		windowModeDropdown.SetValueWithoutNotify(fullscreenMode);
		resolutionDropdown.SetValueWithoutNotify(resolutionIndex);
		VSyncToggle.isOn = QualitySettings.vSyncCount > 0;
		MotionBlurToggle.isOn = TrackManager.Instance.IsMotionBlurEnabled;
		FreeCameraToggle.isOn = CameraController.Instance.IsCameraFree;
		BloomToggle.isOn = bloom.active;
		CameraShakeToggle.isOn = CameraController.Instance.IsShakeEnabled;
		volumeSliderMaster.SetValueWithoutNotify(volumeMaster);
		volumeSliderMusic.SetValueWithoutNotify(volumeMusic);
		volumeSliderSFX.SetValueWithoutNotify(volumeSFX);
		ShowRoofsToggle.isOn = SaveManager.Instance.ShowRoofOnEmptyWagons;
		DataTrackingToggle.isOn = SaveManager.Instance.IsDataTrackingEnabled;
		languageDropdown.SetValueWithoutNotify(chosenLanguage);
		gameSpeedSlider.SetValueWithoutNotify(chosenGameSpeed);
		ShowHullDamageToggle.isOn = SaveManager.Instance.ShowHullDamageText;
		ShowResourcePickupToggle.isOn = SaveManager.Instance.ShowResourcePickupText;
		RectTransform[] componentsInChildren = GetComponentsInChildren<RectTransform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[i]);
		}
	}

	protected override void OnClose()
	{
		SaveManager.Instance.Save();
	}

	public void SetWindowMode(int index)
	{
		fullscreenMode = index;
		isScreenStateDirty = true;
	}

	public void SetResolution(int index)
	{
		resolutionIndex = index;
		isScreenStateDirty = true;
	}

	public void SetLanguage(int index)
	{
		chosenLanguage = index;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[chosenLanguage];
	}

	public void SetGameSpeed(float index)
	{
		chosenGameSpeed = (int)index;
		GameManager.Instance.SetCurrentGameSpeed(gameSpeedSettings.Values.ElementAt(chosenGameSpeed));
		Train.Instance.ChangeGameSpeed(gameSpeedSettings.Values.ElementAt(chosenGameSpeed));
	}

	private void UpdateMenuState()
	{
		windowModeDropdown.SetValueWithoutNotify(Math.Clamp(fullscreenMode, 0, windowModeDropdown.options.Count));
		resolutionDropdown.SetValueWithoutNotify(Math.Clamp(resolutionIndex, 0, resolutionDropdown.options.Count));
		languageDropdown.SetValueWithoutNotify(Math.Clamp(chosenLanguage, 0, languageDropdown.options.Count));
	}

	public void UpdateScreenState()
	{
		if (resolutionIndex < 0 || resolutionIndex >= maxResolutionMultiplier)
		{
			resolutionIndex = 0;
		}
		if (fullscreenMode < 0 || fullscreenMode > 1)
		{
			fullscreenMode = 0;
		}
		Resolution currentResolution = Screen.currentResolution;
		FullScreenMode fullScreenMode = IndexToFullScreenMode(fullscreenMode);
		if (fullScreenMode == FullScreenMode.Windowed)
		{
			int i;
			for (i = 1; windowedWindowWidth * (i + 1) <= currentResolution.width && windowedWindowHeight * (i + 1) <= currentResolution.height; i++)
			{
			}
			List<string> options = (from num3 in Enumerable.Range(1, Math.Clamp(i, 1, maxResolutionMultiplier))
				select "x" + num3).ToList();
			resolutionDropdown.ClearOptions();
			resolutionDropdown.AddOptions(options);
			resolutionDropdown.SetValueWithoutNotify(resolutionIndex);
			resolutionDropdown.enabled = true;
			int num = resolutionIndex + 1;
			Screen.SetResolution(windowedWindowWidth * num, windowedWindowHeight * num, FullScreenMode.Windowed);
		}
		else
		{
			int num2 = currentResolution.width * 9 / 16;
			if (num2 <= currentResolution.height)
			{
				Screen.SetResolution(currentResolution.width, num2, fullScreenMode);
			}
			else
			{
				Screen.SetResolution(currentResolution.height * 16 / 9, currentResolution.height, fullScreenMode);
			}
			List<string> options2 = new List<string> { "~" };
			resolutionDropdown.ClearOptions();
			resolutionDropdown.AddOptions(options2);
			resolutionDropdown.SetValueWithoutNotify(0);
			resolutionDropdown.enabled = false;
		}
	}

	private IEnumerator SetupFullscreenDropdown()
	{
		yield return LocalizationSettings.InitializationOperation;
		string tableName = "LocalizationTable";
		string[] array = new string[2] { "FullscreenMode_Fullscreen", "FullscreenMode_Windowed" };
		List<string> localizedOptions = new List<string>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			LocalizedString localizedString = new LocalizedString(tableName, text);
			yield return localizedString.GetLocalizedStringAsync();
			localizedOptions.Add(localizedString.GetLocalizedString());
		}
		windowModeDropdown.ClearOptions();
		windowModeDropdown.AddOptions(localizedOptions);
		windowModeDropdown.SetValueWithoutNotify(fullscreenMode);
	}

	private void SetupLanguageDropdown()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, bool> language in languages)
		{
			if (language.Value)
			{
				list.Add(language.Key);
			}
		}
		languageDropdown.ClearOptions();
		languageDropdown.AddOptions(list);
		languageDropdown.SetValueWithoutNotify(chosenLanguage);
	}

	private FullScreenMode IndexToFullScreenMode(int index)
	{
		return index switch
		{
			0 => FullScreenMode.FullScreenWindow, 
			1 => FullScreenMode.Windowed, 
			2 => FullScreenMode.ExclusiveFullScreen, 
			_ => FullScreenMode.Windowed, 
		};
	}

	public void SetMasterVolume(float value)
	{
		audioMixer.SetFloat("volume", Mathf.Log10(value) * 20f);
		volumeMaster = value;
	}

	public void SetMusicVolume(float value)
	{
		audioMixer.SetFloat("music", Mathf.Log10(value) * 20f);
		volumeMusic = value;
	}

	public void SetSFXVolume(float value)
	{
		audioMixer.SetFloat("sfx", Mathf.Log10(value) * 20f);
		volumeSFX = value;
	}

	public void OnCustomizeCharactersClicked()
	{
		MenuManager.Instance.OpenMenu(MenuType.CustomizeCharacters);
	}

	public void Save(SaveDataContext context)
	{
		Debug.Log("saving settings");
		SettingsSavefile settingsSave = context.SettingsSave;
		settingsSave.ResolutionIndex = resolutionIndex;
		settingsSave.WindowModeIndex = fullscreenMode;
		settingsSave.IsVSyncEnabled = QualitySettings.vSyncCount > 0;
		settingsSave.IsMotionBlurEnabled = TrackManager.Instance.IsMotionBlurEnabled;
		settingsSave.IsFreeCameraEnabled = CameraController.Instance.IsCameraFree;
		settingsSave.IsBloomEnabled = bloom.active;
		settingsSave.IsCameraShakeEnabled = CameraController.Instance.IsShakeEnabled;
		settingsSave.VolumeMaster = volumeMaster;
		settingsSave.VolumeMusic = volumeMusic;
		settingsSave.VolumeSFX = volumeSFX;
		settingsSave.ChosenLanguage = chosenLanguage;
		settingsSave.ChosenGameSpeed = chosenGameSpeed;
		settingsSave.IsDataTrackingEnabled = SaveManager.Instance.IsDataTrackingEnabled;
		settingsSave.ShowResourcePickupText = SaveManager.Instance.ShowResourcePickupText;
		settingsSave.ShowHullDamageText = SaveManager.Instance.ShowHullDamageText;
	}

	public async void Load(SaveDataContext context, bool isNewJourney)
	{
		if (postProcessingVolume != null)
		{
			postProcessingVolume.profile.TryGet<Bloom>(out bloom);
		}
		Debug.Log("loaded settings");
		SettingsSavefile settingsSave = context.SettingsSave;
		HandleVSyncToggled(settingsSave.IsVSyncEnabled);
		HandleMotionBlurToggled(settingsSave.IsMotionBlurEnabled);
		HandleFreeCameraToggled(settingsSave.IsFreeCameraEnabled);
		HandleBloomToggled(settingsSave.IsBloomEnabled);
		HandleCameraShakeToggled(settingsSave.IsCameraShakeEnabled);
		SetMasterVolume(settingsSave.VolumeMaster);
		SetMusicVolume(settingsSave.VolumeMusic);
		SetSFXVolume(settingsSave.VolumeSFX);
		HandleShowRoofsToggled(settingsSave.ShowRoofOnEmptyWagons);
		HandleDataTrackingToggle(settingsSave.IsDataTrackingEnabled);
		HandleResourcePickupToggle(settingsSave.ShowResourcePickupText);
		HandleHullDamageToggle(settingsSave.ShowHullDamageText);
		volumeSliderMaster.SetValueWithoutNotify(settingsSave.VolumeMaster);
		volumeSliderMusic.SetValueWithoutNotify(settingsSave.VolumeMusic);
		volumeSliderSFX.SetValueWithoutNotify(settingsSave.VolumeSFX);
		resolutionIndex = settingsSave.ResolutionIndex;
		fullscreenMode = settingsSave.WindowModeIndex;
		chosenLanguage = settingsSave.ChosenLanguage;
		chosenGameSpeed = settingsSave.ChosenGameSpeed;
		SetGameSpeed(chosenGameSpeed);
		await LocalizationSettings.InitializationOperation.Task;
		if (chosenLanguage < LocalizationSettings.AvailableLocales.Locales.Count && LocalizationSettings.AvailableLocales.Locales[chosenLanguage] != null)
		{
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[chosenLanguage];
		}
		else
		{
			for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
			{
				if (LocalizationSettings.AvailableLocales.Locales[i] == LocalizationSettings.SelectedLocale)
				{
					chosenLanguage = i;
					break;
				}
				chosenLanguage = 0;
			}
		}
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[chosenLanguage];
	}
}
