using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
	[SerializeField]
	private GameObject[] grids;

	private int currentIndex;

	private Resolution[] resolutions;

	[SerializeField]
	private Toggle fullScreenToggle;

	[SerializeField]
	private Toggle vsyncToggle;

	[SerializeField]
	private TMP_Dropdown fpsDropdown;

	[SerializeField]
	private TMP_Dropdown resoultionDropdown;

	[SerializeField]
	private TMP_Dropdown qualitySettingDropdown;

	[SerializeField]
	private TMP_Dropdown languageDropdown;

	[SerializeField]
	private Slider masterVolumeSlider;

	[SerializeField]
	private Slider musicVolumeSlider;

	[SerializeField]
	private Slider sfxVolumeSlider;

	[SerializeField]
	private Slider mouseSensitivitySlider;

	[SerializeField]
	private CustomUIButton[] categoryBtns;

	private bool isInitialized;

	private List<int> fpsValues = new List<int>();

	private IEnumerator SetupLanguageDropdown()
	{
		yield return LocalizationSettings.InitializationOperation;
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		int value = 0;
		List<Locale> locales = LocalizationSettings.AvailableLocales.Locales;
		for (int i = 0; i < locales.Count; i++)
		{
			Locale locale = locales[i];
			if (LocalizationSettings.SelectedLocale == locale)
			{
				value = i;
			}
			string text = ((locale.Identifier.CultureInfo != null) ? locale.Identifier.CultureInfo.NativeName : locale.name);
			string text2 = locale.Identifier.Code.ToLower();
			if (text2.StartsWith("zh"))
			{
				if (text2.Contains("hans") || text2.Contains("cn"))
				{
					text = "简体中文";
				}
				else if (text2.Contains("hant") || text2.Contains("tw") || text2.Contains("hk"))
				{
					text = "繁體中文";
				}
			}
			else if (text2.StartsWith("ko"))
			{
				text = "한국어";
			}
			list.Add(new TMP_Dropdown.OptionData(text));
		}
		languageDropdown.ClearOptions();
		languageDropdown.AddOptions(list);
		languageDropdown.value = value;
		languageDropdown.RefreshShownValue();
		languageDropdown.onValueChanged.RemoveAllListeners();
		languageDropdown.onValueChanged.AddListener(SetLanguage);
	}

	public void SetLanguage(int index)
	{
		StartCoroutine(ChangeLocale(index));
	}

	private IEnumerator ChangeLocale(int index)
	{
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
		yield return null;
	}

	private void Start()
	{
	}

	private void SyncUIWithCurrentSettings()
	{
		ES3Settings settings = new ES3Settings("ES3_Setting.es3");
		int value = 0;
		for (int i = 0; i < SettingManager.S.filteredResolutions.Length; i++)
		{
			if (SettingManager.S.filteredResolutions[i].width == Screen.width && SettingManager.S.filteredResolutions[i].height == Screen.height)
			{
				value = i;
				break;
			}
		}
		resoultionDropdown.value = value;
		fullScreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
		qualitySettingDropdown.value = QualitySettings.GetQualityLevel();
		vsyncToggle.SetIsOnWithoutNotify(QualitySettings.vSyncCount > 0);
		int savedFPS = ES3.Load("TargetFPS", 60, settings);
		int num = fpsValues.FindIndex((int fps) => fps == savedFPS);
		if (num == -1)
		{
			num = fpsValues.FindIndex((int fps) => fps == 60);
			if (num == -1)
			{
				num = fpsValues.Count - 1;
			}
		}
		fpsDropdown.SetValueWithoutNotify(num);
		masterVolumeSlider.value = ES3.Load("MasterVolume", 1f, settings);
		musicVolumeSlider.value = ES3.Load("MusicVolume", 0.4f, settings);
		sfxVolumeSlider.value = ES3.Load("SFXVolume", 1f, settings);
		mouseSensitivitySlider.value = ES3.Load("MouseSensitivity", 0.05f, settings);
	}

	public void CloseSettingUI()
	{
		SettingManager.S.SaveAllSettings(masterVolumeSlider.value, musicVolumeSlider.value, sfxVolumeSlider.value, mouseSensitivitySlider.value, fullScreenToggle.isOn, vsyncToggle.isOn, Application.targetFrameRate);
		base.gameObject.SetActive(value: false);
	}

	public void OpenSettingWindow()
	{
		base.gameObject.SetActive(value: true);
		if (!isInitialized)
		{
			InitializeUIElements();
			isInitialized = true;
		}
		currentIndex = 0;
		CategorySelected(currentIndex);
	}

	private void InitializeUIElements()
	{
		SetupFPSDropdown();
		resoultionDropdown.ClearOptions();
		resoultionDropdown.AddOptions(SettingManager.S.resOptionsStrings);
		SyncUIWithCurrentSettings();
		fullScreenToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SettingManager.S.SetResolution(resoultionDropdown.value, isOn);
		});
		resoultionDropdown.onValueChanged.AddListener(delegate(int idx)
		{
			SettingManager.S.SetResolution(idx, fullScreenToggle.isOn);
		});
		qualitySettingDropdown.onValueChanged.AddListener(delegate(int idx)
		{
			SettingManager.S.SetQuality(idx);
		});
		vsyncToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SettingManager.S.SetVSync(isOn);
		});
		fpsDropdown.onValueChanged.AddListener(delegate(int idx)
		{
			int frameRate = fpsValues[idx];
			SettingManager.S.SetFrameRate(frameRate);
		});
		masterVolumeSlider.onValueChanged.AddListener(delegate(float val)
		{
			SettingManager.S.SetVolume("MasterVolume", val);
		});
		musicVolumeSlider.onValueChanged.AddListener(delegate(float val)
		{
			SettingManager.S.SetVolume("MusicVolume", val);
		});
		sfxVolumeSlider.onValueChanged.AddListener(delegate(float val)
		{
			SettingManager.S.SetVolume("SFXVolume", val);
		});
		mouseSensitivitySlider.onValueChanged.AddListener(delegate(float val)
		{
			SettingManager.S.SetSensitivity(val);
		});
		StartCoroutine(SetupLanguageDropdown());
	}

	private void SetupFPSDropdown()
	{
		fpsDropdown.ClearOptions();
		fpsValues.Clear();
		AddFPSOption(30);
		AddFPSOption(60);
		int num = Mathf.RoundToInt((float)Screen.currentResolution.refreshRateRatio.value);
		if (num > 60)
		{
			AddFPSOption(num);
		}
		if (num < 120)
		{
			AddFPSOption(120);
		}
		if (num < 144)
		{
			AddFPSOption(144);
		}
		fpsValues.Add(-1);
		List<string> list = new List<string>();
		foreach (int fpsValue in fpsValues)
		{
			if (fpsValue == -1)
			{
				list.Add("Unlimited");
			}
			else if (fpsValue == num)
			{
				list.Add($"{fpsValue} FPS (Monitor)");
			}
			else
			{
				list.Add($"{fpsValue} FPS");
			}
		}
		fpsDropdown.AddOptions(list);
	}

	private void AddFPSOption(int fps)
	{
		if (!fpsValues.Contains(fps))
		{
			fpsValues.Add(fps);
		}
		fpsValues.Sort();
	}

	public void CategorySelected(int index)
	{
		currentIndex = index;
		GameObject[] array = grids;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		grids[index].SetActive(value: true);
		categoryBtns[index].WhenOpenSettingUI();
	}

	public void OnFullScreenToggleClicked(bool isOn)
	{
		Screen.fullScreenMode = (isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
	}

	public void PlaySFX(AudioClip clip)
	{
		if (isInitialized)
		{
			AudioManager.S.PlaySFX(clip);
		}
	}
}
