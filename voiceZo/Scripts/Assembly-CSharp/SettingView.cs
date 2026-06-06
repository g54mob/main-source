using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SettingView : MonoBehaviour
{
	[SerializeField]
	private Slider _bgmSlider;

	[SerializeField]
	private Slider _sfxSlider;

	[SerializeField]
	private TextMeshProUGUI _bgmVolumeText;

	[SerializeField]
	private TextMeshProUGUI _sfxVolumeText;

	[SerializeField]
	private TMP_Dropdown _resolutionDropdown;

	[SerializeField]
	private Toggle _fullscreenToggle;

	[SerializeField]
	private TMP_Dropdown _languageDropdown;

	private bool _isChanging;

	private List<Vector2Int> _availableResolutions;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnClickExitButton();
		}
	}

	private void OnEnable()
	{
		_bgmSlider.onValueChanged.AddListener(OnChangeBGMVolume);
		_sfxSlider.onValueChanged.AddListener(OnChangeSFXVolume);
		_fullscreenToggle.onValueChanged.AddListener(OnToggleChanged);
		_resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
		_languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
	}

	private void OnDisable()
	{
		_bgmSlider.onValueChanged.RemoveListener(OnChangeBGMVolume);
		_sfxSlider.onValueChanged.RemoveListener(OnChangeSFXVolume);
		_fullscreenToggle.onValueChanged.RemoveListener(OnToggleChanged);
		_resolutionDropdown.onValueChanged.RemoveListener(OnResolutionChanged);
		_languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
	}

	public void Show()
	{
		InitSoundVolumeSliders();
		InitFullScreenToggle();
		InitResolutionDropdown();
		InitLanguageDropdown();
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void InitSoundVolumeSliders()
	{
		_bgmSlider.value = MonoSingleton<SoundManager>.Instance.CurrentBGMVolume;
		_sfxSlider.value = MonoSingleton<SoundManager>.Instance.CurrentSFXVolume;
		_bgmVolumeText.text = (_bgmSlider.value * 100f).ToString("F0") + "%";
		_sfxVolumeText.text = (_sfxSlider.value * 100f).ToString("F0") + "%";
	}

	private void InitFullScreenToggle()
	{
		bool isOnWithoutNotify = Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen || Screen.fullScreenMode == FullScreenMode.FullScreenWindow;
		_fullscreenToggle.SetIsOnWithoutNotify(isOnWithoutNotify);
	}

	private void InitResolutionDropdown()
	{
		_resolutionDropdown.ClearOptions();
		List<Resolution> list = (from r in Screen.resolutions
			group r by new { r.width, r.height } into g
			select g.First() into r
			orderby r.width, r.height
			select r).ToList();
		List<string> options = list.Select((Resolution r) => $"{r.width} x {r.height}").ToList();
		_resolutionDropdown.AddOptions(options);
		Vector2Int cur = new Vector2Int(Screen.width, Screen.height);
		int num = list.FindIndex((Resolution r) => r.width == cur.x && r.height == cur.y);
		if (num < 0)
		{
			num = 0;
		}
		_resolutionDropdown.SetValueWithoutNotify(num);
		_availableResolutions = list.Select((Resolution r) => new Vector2Int(r.width, r.height)).ToList();
	}

	private void InitLanguageDropdown()
	{
		_languageDropdown.ClearOptions();
		List<string> options = new List<string>
		{
			"English", "한국어", "简体中文", "繁體中文", "日本語", "Русский", "Deutsch", "Français", "Italiano", "Español (España)",
			"Español (México)", "Português (Portugal)", "Português (Brasil)", "Thai", "Bahasa Indonesia"
		};
		_languageDropdown.AddOptions(options);
		string code = LocalizationSettings.SelectedLocale.Identifier.Code;
		int valueWithoutNotify = 0;
		switch (code)
		{
		case "en":
			valueWithoutNotify = 0;
			break;
		case "ko":
			valueWithoutNotify = 1;
			break;
		case "zh-Hans":
			valueWithoutNotify = 2;
			break;
		case "zh-Hant":
			valueWithoutNotify = 3;
			break;
		case "ja":
			valueWithoutNotify = 4;
			break;
		case "ru":
			valueWithoutNotify = 5;
			break;
		case "de":
			valueWithoutNotify = 6;
			break;
		case "fr":
			valueWithoutNotify = 7;
			break;
		case "it":
			valueWithoutNotify = 8;
			break;
		case "es-ES":
			valueWithoutNotify = 9;
			break;
		case "es-MX":
			valueWithoutNotify = 10;
			break;
		case "pt-PT":
			valueWithoutNotify = 11;
			break;
		case "pt-BR":
			valueWithoutNotify = 12;
			break;
		case "th":
			valueWithoutNotify = 13;
			break;
		case "id":
			valueWithoutNotify = 14;
			break;
		}
		_languageDropdown.SetValueWithoutNotify(valueWithoutNotify);
	}

	private void OnChangeBGMVolume(float value)
	{
		MonoSingleton<SoundManager>.Instance.SetBGMVolume(value);
		_bgmVolumeText.text = (value * 100f).ToString("F0") + "%";
	}

	private void OnChangeSFXVolume(float value)
	{
		MonoSingleton<SoundManager>.Instance.SetSFXVolume(value);
		_sfxVolumeText.text = (value * 100f).ToString("F0") + "%";
	}

	private void OnResolutionChanged(int index)
	{
		if (_availableResolutions != null && index >= 0 && index < _availableResolutions.Count)
		{
			Vector2Int vector2Int = _availableResolutions[index];
			Screen.SetResolution(vector2Int.x, vector2Int.y, Screen.fullScreenMode);
			MonoSingleton<GameManager>.Instance.SaveGame();
		}
	}

	private void OnToggleChanged(bool isOn)
	{
		if (isOn)
		{
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		}
		else
		{
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
		MonoSingleton<GameManager>.Instance.SaveGame();
	}

	public void ChangeLocale(string code)
	{
		if (!_isChanging)
		{
			StartCoroutine(Co_ChangeLocale(code));
		}
	}

	private IEnumerator Co_ChangeLocale(string code)
	{
		_isChanging = true;
		yield return LocalizationSettings.InitializationOperation;
		Locale locale = LocalizationSettings.AvailableLocales.GetLocale(new LocaleIdentifier(code));
		if (locale != null)
		{
			LocalizationSettings.SelectedLocale = locale;
		}
		else
		{
			Debug.LogWarning("Locale not found for code: " + code);
		}
		MonoSingleton<GameManager>.Instance.SaveGame();
		_isChanging = false;
	}

	private void OnLanguageChanged(int index)
	{
		switch (index)
		{
		case 0:
			ChangeLocale("en");
			break;
		case 1:
			ChangeLocale("ko");
			break;
		case 2:
			ChangeLocale("zh-Hans");
			break;
		case 3:
			ChangeLocale("zh-Hant");
			break;
		case 4:
			ChangeLocale("ja");
			break;
		case 5:
			ChangeLocale("ru");
			break;
		case 6:
			ChangeLocale("de");
			break;
		case 7:
			ChangeLocale("fr");
			break;
		case 8:
			ChangeLocale("it");
			break;
		case 9:
			ChangeLocale("es-ES");
			break;
		case 10:
			ChangeLocale("es-MX");
			break;
		case 11:
			ChangeLocale("pt-PT");
			break;
		case 12:
			ChangeLocale("pt-BR");
			break;
		case 13:
			ChangeLocale("th");
			break;
		case 14:
			ChangeLocale("id");
			break;
		}
	}

	public void OnClickExitButton()
	{
		Hide();
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
	}

	public void OnClickQuitGameButton()
	{
		MonoSingleton<GameManager>.Instance.SaveGame();
		Application.Quit();
	}
}
