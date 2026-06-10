using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	[Header("UI Components")]
	public GameObject settingsPanelObject;

	public Slider musicSlider;

	public Slider ambienceSlider;

	public Slider sfxSlider;

	public TMP_Dropdown fpsDropdown;

	public TMP_Dropdown resolutionDropdown;

	public TMP_Dropdown displayDropdown;

	[Header("Language Settings")]
	public TMP_Dropdown languageDropdown;

	public TMP_Text languageLabel;

	public GameObject languageLockedText;

	public int mainMenuBuildIndex;

	[Header("Graphics & Accessibility")]
	public Toggle shakeToggle;

	public Toggle vfxToggle;

	public Toggle zoomToggle;

	public Toggle autoReelToggle;

	private const string PREF_SHAKE = "Setting_Shake";

	private const string PREF_VFX = "Setting_VFX";

	private const string PREF_ZOOM = "Setting_Zoom";

	private const string PREF_AUTO_REEL = "Setting_AutoReel";

	private const string PREF_FPS_INDEX = "Setting_FPS_Index";

	private const string PREF_RES_INDEX = "Setting_Res_Index";

	private const string PREF_DISPLAY = "Setting_Display";

	public float maxMusicVolume;

	public float maxAmbienceVolume;

	public float maxSFXVolume;

	private bool _uiBuiltOnce;

	[SerializeField]
	private GameObject settingsRoot;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private float fadeDuration = 0.25f;

	private Tween currentTween;

	private static readonly Vector2Int[] allResolutions = new Vector2Int[7]
	{
		new Vector2Int(960, 540),
		new Vector2Int(1280, 720),
		new Vector2Int(1366, 768),
		new Vector2Int(1600, 900),
		new Vector2Int(1920, 1080),
		new Vector2Int(2560, 1440),
		new Vector2Int(3840, 2160)
	};

	private List<Vector2Int> supportedResolutions = new List<Vector2Int>();

	public bool IsVisible
	{
		get
		{
			if (canvasGroup != null && canvasGroup.blocksRaycasts)
			{
				return canvasGroup.alpha > 0.01f;
			}
			return false;
		}
	}

	private void Awake()
	{
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
		InitializeResolutionSettings();
	}

	private IEnumerator Start()
	{
		yield return LocalizationSettings.InitializationOperation;
		if (languageDropdown != null)
		{
			languageDropdown.onValueChanged.RemoveAllListeners();
		}
		InitializeLanguageOptions();
		InitializeUI();
		_uiBuiltOnce = true;
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	private void InitializeLanguageOptions()
	{
		if (languageDropdown == null)
		{
			return;
		}
		if (LocalizationSettings.AvailableLocales == null || LocalizationSettings.AvailableLocales.Locales == null)
		{
			Debug.LogWarning("Localization Settings or Locales are missing!");
			return;
		}
		List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
		foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
		{
			if (locale == null)
			{
				continue;
			}
			string text;
			if (locale.Identifier.CultureInfo != null)
			{
				text = locale.Identifier.CultureInfo.NativeName;
				if (!string.IsNullOrEmpty(text) && text.Length > 1)
				{
					text = char.ToUpper(text[0]) + text.Substring(1);
				}
			}
			else
			{
				text = locale.name;
			}
			list.Add(new TMP_Dropdown.OptionData(text));
		}
		languageDropdown.ClearOptions();
		languageDropdown.AddOptions(list);
	}

	private void InitializeUI()
	{
		if (SoundManager.Instance != null)
		{
			musicSlider.maxValue = maxMusicVolume;
			ambienceSlider.maxValue = maxAmbienceVolume;
			sfxSlider.maxValue = maxSFXVolume;
			musicSlider.value = SoundManager.Instance.globalMusicVolume;
			ambienceSlider.value = SoundManager.Instance.globalAmbianceVolume;
			sfxSlider.value = SoundManager.Instance.globalSfxVolume;
		}
		bool flag = PlayerPrefs.GetInt("Setting_Shake", 1) == 1;
		bool flag2 = PlayerPrefs.GetInt("Setting_VFX", 1) == 1;
		bool flag3 = PlayerPrefs.GetInt("Setting_Zoom", 1) == 1;
		bool isOn = PlayerPrefs.GetInt("Setting_AutoReel", 0) == 1;
		shakeToggle.isOn = flag;
		vfxToggle.isOn = flag2;
		zoomToggle.isOn = flag3;
		if (autoReelToggle != null)
		{
			autoReelToggle.isOn = isOn;
		}
		fpsDropdown.ClearOptions();
		List<string> options = new List<string> { "30 FPS", "60 FPS", "120 FPS", "Uncapped" };
		fpsDropdown.AddOptions(options);
		int value = PlayerPrefs.GetInt("Setting_FPS_Index", 2);
		fpsDropdown.value = value;
		fpsDropdown.RefreshShownValue();
		if (languageDropdown != null && LocalizationSettings.InitializationOperation.IsDone)
		{
			int valueWithoutNotify = 0;
			List<Locale> locales = LocalizationSettings.AvailableLocales.Locales;
			for (int i = 0; i < locales.Count; i++)
			{
				if (LocalizationSettings.SelectedLocale == locales[i])
				{
					valueWithoutNotify = i;
					break;
				}
			}
			languageDropdown.SetValueWithoutNotify(valueWithoutNotify);
			UpdateLanguageLockUI();
		}
		if (CameraController.Instance != null)
		{
			if (CameraController.Instance.enableScreenShake != flag)
			{
				CameraController.Instance.SetShakeEnabled(flag);
			}
			if (CameraController.Instance.enableVisualEffects != flag2)
			{
				CameraController.Instance.SetVFXEnabled(flag2);
			}
			if (CameraController.Instance.enableCameraZoom != flag3)
			{
				CameraController.Instance.SetZoomEnabled(flag3);
			}
		}
		musicSlider.onValueChanged.RemoveAllListeners();
		ambienceSlider.onValueChanged.RemoveAllListeners();
		sfxSlider.onValueChanged.RemoveAllListeners();
		zoomToggle.onValueChanged.RemoveAllListeners();
		shakeToggle.onValueChanged.RemoveAllListeners();
		vfxToggle.onValueChanged.RemoveAllListeners();
		if (autoReelToggle != null)
		{
			autoReelToggle.onValueChanged.RemoveAllListeners();
		}
		fpsDropdown.onValueChanged.RemoveAllListeners();
		if (resolutionDropdown != null)
		{
			resolutionDropdown.onValueChanged.RemoveAllListeners();
		}
		if (displayDropdown != null)
		{
			displayDropdown.onValueChanged.RemoveAllListeners();
		}
		if (languageDropdown != null)
		{
			languageDropdown.onValueChanged.RemoveAllListeners();
		}
		musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
		ambienceSlider.onValueChanged.AddListener(OnAmbienceVolumeChanged);
		sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
		shakeToggle.onValueChanged.AddListener(OnShakeToggled);
		vfxToggle.onValueChanged.AddListener(OnVFXToggled);
		fpsDropdown.onValueChanged.AddListener(OnFPSChanged);
		zoomToggle.onValueChanged.AddListener(OnZoomToggled);
		if (autoReelToggle != null)
		{
			autoReelToggle.onValueChanged.AddListener(OnAutoReelToggled);
		}
		if (resolutionDropdown != null)
		{
			resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
		}
		if (displayDropdown != null)
		{
			displayDropdown.onValueChanged.AddListener(OnDisplayChanged);
		}
		if (languageDropdown != null)
		{
			languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
		}
	}

	private void PopulateDisplayDropdown()
	{
		if (!(displayDropdown == null))
		{
			displayDropdown.ClearOptions();
			string text = new LocalizedString("Skills", "#ui.settings.window.size.borderless").GetLocalizedString();
			if (string.IsNullOrEmpty(text) || text.StartsWith("#ui"))
			{
				text = "Borderless";
			}
			string text2 = new LocalizedString("Skills", "#ui.settings.window.size.fullscreen").GetLocalizedString();
			if (string.IsNullOrEmpty(text2) || text2.StartsWith("#ui"))
			{
				text2 = "Fullscreen";
			}
			string text3 = new LocalizedString("Skills", "#ui.settings.window.size.windowed").GetLocalizedString();
			if (string.IsNullOrEmpty(text3) || text3.StartsWith("#ui"))
			{
				text3 = "Windowed";
			}
			displayDropdown.AddOptions(new List<string> { text, text2, text3 });
		}
	}

	private void InitializeResolutionSettings()
	{
		if (resolutionDropdown == null)
		{
			return;
		}
		supportedResolutions.Clear();
		supportedResolutions.AddRange(allResolutions);
		if (displayDropdown != null)
		{
			PopulateDisplayDropdown();
			int valueWithoutNotify = PlayerPrefs.GetInt("Setting_Display", 0);
			displayDropdown.SetValueWithoutNotify(valueWithoutNotify);
			displayDropdown.RefreshShownValue();
		}
		resolutionDropdown.ClearOptions();
		List<string> list = new List<string>();
		for (int i = 0; i < supportedResolutions.Count; i++)
		{
			string item = $"{supportedResolutions[i].x} x {supportedResolutions[i].y}";
			list.Add(item);
		}
		resolutionDropdown.AddOptions(list);
		int num = PlayerPrefs.GetInt("Setting_Res_Index", -1);
		if (num < 0)
		{
			Resolution currentResolution = Screen.currentResolution;
			num = -1;
			for (int num2 = supportedResolutions.Count - 1; num2 >= 0; num2--)
			{
				if (supportedResolutions[num2].x <= currentResolution.width && supportedResolutions[num2].y <= currentResolution.height)
				{
					num = num2;
					break;
				}
			}
			if (num < 0)
			{
				num = 0;
			}
		}
		else if (num >= supportedResolutions.Count)
		{
			num = supportedResolutions.Count - 1;
		}
		resolutionDropdown.SetValueWithoutNotify(num);
		resolutionDropdown.RefreshShownValue();
		int displayIndex = ((displayDropdown != null) ? displayDropdown.value : 0);
		ApplySupportedResolution(num, displayIndex);
	}

	public void OnZoomToggled(bool isEnabled)
	{
		if (CameraController.Instance != null)
		{
			CameraController.Instance.SetZoomEnabled(isEnabled);
		}
		PlayerPrefs.SetInt("Setting_Zoom", isEnabled ? 1 : 0);
	}

	public void OnAutoReelToggled(bool isEnabled)
	{
		PlayerPrefs.SetInt("Setting_AutoReel", isEnabled ? 1 : 0);
	}

	public void OnLanguageChanged(int index)
	{
		if (LocalizationSettings.AvailableLocales != null && index < LocalizationSettings.AvailableLocales.Locales.Count)
		{
			Locale locale = LocalizationSettings.AvailableLocales.Locales[index];
			if (LocalizationSettings.SelectedLocale != locale)
			{
				LocalizationSettings.SelectedLocale = locale;
			}
		}
	}

	public void OnFPSChanged(int index)
	{
		PlayerPrefs.SetInt("Setting_FPS_Index", index);
		PlayerPrefs.Save();
		if (PauseMenuManager.Instance != null)
		{
			PauseMenuManager.Instance.ApplyFrameRateSettings();
		}
	}

	public void OnShakeToggled(bool isEnabled)
	{
		if (CameraController.Instance != null)
		{
			CameraController.Instance.SetShakeEnabled(isEnabled);
		}
		PlayerPrefs.SetInt("Setting_Shake", isEnabled ? 1 : 0);
	}

	public void OnVFXToggled(bool isEnabled)
	{
		if (CameraController.Instance != null)
		{
			CameraController.Instance.SetVFXEnabled(isEnabled);
		}
		PlayerPrefs.SetInt("Setting_VFX", isEnabled ? 1 : 0);
	}

	public void OnMusicVolumeChanged(float value)
	{
		if (SoundManager.Instance != null)
		{
			SoundManager.Instance.globalMusicVolume = value;
		}
	}

	public void OnAmbienceVolumeChanged(float value)
	{
		if (SoundManager.Instance != null)
		{
			SoundManager.Instance.globalAmbianceVolume = value;
		}
	}

	public void OnSFXVolumeChanged(float value)
	{
		if (SoundManager.Instance != null)
		{
			SoundManager.Instance.globalSfxVolume = value;
		}
	}

	private void ApplySupportedResolution(int resIndex, int displayIndex)
	{
		if (resIndex >= 0 && resIndex < supportedResolutions.Count)
		{
			Vector2Int vector2Int = supportedResolutions[resIndex];
			FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;
			switch (displayIndex)
			{
			case 1:
				fullScreenMode = FullScreenMode.ExclusiveFullScreen;
				break;
			case 2:
				fullScreenMode = FullScreenMode.Windowed;
				break;
			}
			if (fullScreenMode == FullScreenMode.Windowed)
			{
				Resolution currentResolution = Screen.currentResolution;
				vector2Int.x = Mathf.Min(vector2Int.x, currentResolution.width);
				vector2Int.y = Mathf.Min(vector2Int.y, currentResolution.height);
			}
			Screen.SetResolution(vector2Int.x, vector2Int.y, fullScreenMode);
		}
	}

	public void OnDisplayChanged(int displayIndex)
	{
		PlayerPrefs.SetInt("Setting_Display", displayIndex);
		PlayerPrefs.Save();
		int resIndex = ((resolutionDropdown != null) ? resolutionDropdown.value : 3);
		ApplySupportedResolution(resIndex, displayIndex);
	}

	public void OnResolutionChanged(int index)
	{
		PlayerPrefs.SetInt("Setting_Res_Index", index);
		PlayerPrefs.Save();
		int displayIndex = ((displayDropdown != null) ? displayDropdown.value : 0);
		ApplySupportedResolution(index, displayIndex);
	}

	public void CloseSettings()
	{
		if (SoundManager.Instance != null)
		{
			SoundManager.Instance.SaveSettings();
		}
		PlayerPrefs.SetInt("Setting_Shake", shakeToggle.isOn ? 1 : 0);
		PlayerPrefs.SetInt("Setting_VFX", vfxToggle.isOn ? 1 : 0);
		PlayerPrefs.SetInt("Setting_Zoom", zoomToggle.isOn ? 1 : 0);
		if (autoReelToggle != null)
		{
			PlayerPrefs.SetInt("Setting_AutoReel", autoReelToggle.isOn ? 1 : 0);
		}
		PlayerPrefs.Save();
		HidePanel();
	}

	public void ShowPanel()
	{
		if (_uiBuiltOnce)
		{
			RefreshUIValues();
		}
		Canvas.ForceUpdateCanvases();
		RectTransform rectTransform = canvasGroup.transform as RectTransform;
		if (rectTransform != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		}
		currentTween?.Kill();
		canvasGroup.DOKill();
		canvasGroup.alpha = 0f;
		canvasGroup.interactable = true;
		canvasGroup.blocksRaycasts = false;
		currentTween = canvasGroup.DOFade(1f, fadeDuration).SetEase(Ease.Linear).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				canvasGroup.blocksRaycasts = true;
			});
	}

	private void RefreshUIValues()
	{
		if (SoundManager.Instance != null)
		{
			musicSlider.SetValueWithoutNotify(SoundManager.Instance.globalMusicVolume);
			ambienceSlider.SetValueWithoutNotify(SoundManager.Instance.globalAmbianceVolume);
			sfxSlider.SetValueWithoutNotify(SoundManager.Instance.globalSfxVolume);
		}
		shakeToggle.onValueChanged.RemoveAllListeners();
		shakeToggle.isOn = PlayerPrefs.GetInt("Setting_Shake", 1) == 1;
		shakeToggle.onValueChanged.AddListener(OnShakeToggled);
		vfxToggle.onValueChanged.RemoveAllListeners();
		vfxToggle.isOn = PlayerPrefs.GetInt("Setting_VFX", 1) == 1;
		vfxToggle.onValueChanged.AddListener(OnVFXToggled);
		zoomToggle.onValueChanged.RemoveAllListeners();
		zoomToggle.isOn = PlayerPrefs.GetInt("Setting_Zoom", 1) == 1;
		zoomToggle.onValueChanged.AddListener(OnZoomToggled);
		if (autoReelToggle != null)
		{
			autoReelToggle.onValueChanged.RemoveAllListeners();
			autoReelToggle.isOn = PlayerPrefs.GetInt("Setting_AutoReel", 0) == 1;
			autoReelToggle.onValueChanged.AddListener(OnAutoReelToggled);
		}
		fpsDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("Setting_FPS_Index", 2));
		fpsDropdown.RefreshShownValue();
		resolutionDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("Setting_Res_Index", 3));
		resolutionDropdown.RefreshShownValue();
		if (displayDropdown != null)
		{
			PopulateDisplayDropdown();
			displayDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("Setting_Display", 0));
			displayDropdown.RefreshShownValue();
		}
		UpdateLanguageLockUI();
	}

	private void UpdateLanguageLockUI()
	{
		if (languageDropdown == null)
		{
			return;
		}
		bool flag = SceneManager.GetActiveScene().buildIndex == mainMenuBuildIndex;
		languageDropdown.interactable = flag;
		if (languageLabel != null)
		{
			languageLabel.alpha = (flag ? 1f : 0.5f);
		}
		if (languageLockedText != null)
		{
			languageLockedText.SetActive(!flag);
		}
		List<Locale> locales = LocalizationSettings.AvailableLocales.Locales;
		int value = 0;
		for (int i = 0; i < locales.Count; i++)
		{
			if (locales[i] == LocalizationSettings.SelectedLocale)
			{
				value = i;
				break;
			}
		}
		languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
		languageDropdown.value = value;
		languageDropdown.RefreshShownValue();
		languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
	}

	public void HidePanel()
	{
		currentTween?.Kill();
		canvasGroup.DOKill();
		canvasGroup.blocksRaycasts = false;
		canvasGroup.interactable = true;
		currentTween = canvasGroup.DOFade(0f, fadeDuration).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			canvasGroup.blocksRaycasts = false;
		});
	}
}
