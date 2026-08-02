using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
	private static SettingsPanel _instance;

	private CanvasGroup cg;

	public Button closeButton;

	private bool isMainMenu;

	private bool isOpen;

	public HorizontalSelector languages;

	public Michsky.UI.Heat.Dropdown displayDropdown;

	public Michsky.UI.Heat.Dropdown screenModeDropdown;

	public Michsky.UI.Heat.Dropdown resolutionDropdown;

	public Michsky.UI.Heat.Dropdown inputDeviceDropdown;

	private bool isInitialized;

	private MainMenuPanel mainMenuPanel;

	private AudioSettingsBridge audioSettingsBridge;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		_instance = this;
		cg = GetComponent<CanvasGroup>();
		if (cg != null)
		{
			cg.alpha = 0f;
			cg.interactable = false;
			cg.blocksRaycasts = false;
		}
		base.gameObject.SetActive(value: true);
	}

	private void Start()
	{
		mainMenuPanel = Object.FindAnyObjectByType<MainMenuPanel>();
		audioSettingsBridge = Object.FindAnyObjectByType<AudioSettingsBridge>();
		Object.DontDestroyOnLoad(base.gameObject);
		closeButton.onClick.AddListener(ClosePanel);
		CheckCurrentScene();
		SceneManager.sceneLoaded += OnSceneLoaded;
		SetupLanguageSelector();
		StartCoroutine(SetupDropdownsWhenReady());
		StartCoroutine(PreWarmSettingsPanels());
	}

	private IEnumerator SetupDropdownsWhenReady()
	{
		if (displayDropdown != null)
		{
			displayDropdown.initOnEnable = false;
		}
		if (screenModeDropdown != null)
		{
			screenModeDropdown.initOnEnable = false;
		}
		if (resolutionDropdown != null)
		{
			resolutionDropdown.initOnEnable = false;
		}
		if (inputDeviceDropdown != null)
		{
			inputDeviceDropdown.initOnEnable = false;
		}
		while (SettingsManager.Instance == null)
		{
			yield return null;
		}
		SetupDisplayDropdown();
		SetupScreenModeDropdown();
		SetupResolutionDropdown();
		SetupInputDeviceDropdown();
	}

	private IEnumerator PreWarmSettingsPanels()
	{
		PanelManager panelManager = GetComponentInChildren<PanelManager>(includeInactive: true);
		if (panelManager == null)
		{
			yield break;
		}
		yield return null;
		for (int i = 0; i < panelManager.panels.Count; i++)
		{
			if (panelManager.panels[i].panelObject != null && !panelManager.panels[i].panelObject.gameObject.activeSelf)
			{
				panelManager.panels[i].panelObject.gameObject.SetActive(value: true);
				yield return null;
			}
		}
		yield return null;
		if (panelManager.cullPanels)
		{
			for (int j = 0; j < panelManager.panels.Count; j++)
			{
				if (j != panelManager.currentPanelIndex && panelManager.panels[j].panelObject != null)
				{
					panelManager.panels[j].panelObject.gameObject.SetActive(value: false);
				}
			}
		}
		while (SettingsManager.Instance == null)
		{
			yield return null;
		}
		SyncAllSliders();
	}

	private void SyncAllSliders()
	{
		if (SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SyncMouseSlider();
			SettingsManager.Instance.SyncInvertMouseSwitch();
		}
		if (audioSettingsBridge != null)
		{
			audioSettingsBridge.SyncSliders();
		}
	}

	private void SetupLanguageSelector()
	{
		languages.items.Clear();
		languages.saveSelected = false;
		List<Locale> locales = UnityEngine.Localization.Settings.LocalizationSettings.AvailableLocales.Locales;
		foreach (Locale item in locales)
		{
			string title = item.LocaleName.Split(' ')[0].ToUpper(item.Identifier.CultureInfo);
			languages.CreateNewItem(title);
		}
		int num = 0;
		string text = ((SettingsManager.Instance != null) ? SettingsManager.Instance.GetSettingsData().languageCode : "en");
		if (string.IsNullOrEmpty(text))
		{
			text = "en";
		}
		for (int i = 0; i < locales.Count; i++)
		{
			if (locales[i].Identifier.Code == text)
			{
				num = i;
				UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale = locales[i];
				break;
			}
		}
		languages.defaultIndex = num;
		languages.index = num;
		languages.InitializeSelector();
		languages.onValueChanged.AddListener(OnLanguageChanged);
	}

	private void SetupDisplayDropdown()
	{
		if (!(displayDropdown == null))
		{
			displayDropdown.items.Clear();
			displayDropdown.saveSelected = false;
			List<DisplayInfo> list = new List<DisplayInfo>();
			Screen.GetDisplayLayout(list);
			int num = Mathf.Max(list.Count, 1);
			for (int i = 0; i < num; i++)
			{
				string title = ((i < list.Count && !string.IsNullOrEmpty(list[i].name)) ? $"Display {i + 1}: {list[i].name}" : $"Display {i + 1}");
				displayDropdown.CreateNewItem(title, notify: false);
			}
			int selectedItemIndex = 0;
			if (SettingsManager.Instance != null)
			{
				selectedItemIndex = Mathf.Clamp(SettingsManager.Instance.GetSettingsData().targetDisplay, 0, num - 1);
			}
			displayDropdown.selectedItemIndex = selectedItemIndex;
			displayDropdown.Initialize();
			displayDropdown.onValueChanged.AddListener(OnDisplayChanged);
		}
	}

	private void OnDisplayChanged(int index)
	{
		if (SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetTargetDisplay(index);
		}
	}

	private void SetupScreenModeDropdown()
	{
		if (!(screenModeDropdown == null))
		{
			screenModeDropdown.items.Clear();
			screenModeDropdown.saveSelected = false;
			screenModeDropdown.CreateNewItem("Full Screen Windowed", notify: false);
			screenModeDropdown.CreateNewItem("Full Screen", notify: false);
			screenModeDropdown.CreateNewItem("Windowed", notify: false);
			int selectedItemIndex = 0;
			if (SettingsManager.Instance != null)
			{
				selectedItemIndex = SettingsManager.Instance.GetSettingsData().fullscreenMode switch
				{
					FullScreenMode.ExclusiveFullScreen => 1, 
					FullScreenMode.FullScreenWindow => 0, 
					_ => 2, 
				};
			}
			screenModeDropdown.selectedItemIndex = selectedItemIndex;
			screenModeDropdown.Initialize();
			screenModeDropdown.onValueChanged.AddListener(OnScreenModeChanged);
		}
	}

	private void OnScreenModeChanged(int index)
	{
		if (SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetFullscreenModeIndex(index);
		}
	}

	private void SetupResolutionDropdown()
	{
		if (resolutionDropdown == null || SettingsManager.Instance == null)
		{
			return;
		}
		SettingsData settingsData = SettingsManager.Instance.GetSettingsData();
		settingsData.RefreshAvailableResolutions();
		if (settingsData.availableResolutions != null && settingsData.availableResolutions.Length != 0)
		{
			resolutionDropdown.items.Clear();
			resolutionDropdown.saveSelected = false;
			for (int i = 0; i < settingsData.availableResolutions.Length; i++)
			{
				Resolution resolution = settingsData.availableResolutions[i];
				resolutionDropdown.CreateNewItem($"{resolution.width} x {resolution.height}", notify: false);
			}
			int selectedItemIndex = Mathf.Clamp(settingsData.resolutionIndex, 0, settingsData.availableResolutions.Length - 1);
			resolutionDropdown.selectedItemIndex = selectedItemIndex;
			resolutionDropdown.Initialize();
			resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
		}
	}

	private void OnResolutionChanged(int index)
	{
		if (SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetResolutionIndex(index);
		}
	}

	private void SetupInputDeviceDropdown()
	{
		if (!(inputDeviceDropdown == null) && !(SettingsManager.Instance == null))
		{
			inputDeviceDropdown.items.Clear();
			inputDeviceDropdown.saveSelected = false;
			string[] voiceInputDeviceOptions = SettingsManager.Instance.GetVoiceInputDeviceOptions();
			for (int i = 0; i < voiceInputDeviceOptions.Length; i++)
			{
				inputDeviceDropdown.CreateNewItem(voiceInputDeviceOptions[i], notify: false);
			}
			int selectedItemIndex = Mathf.Clamp(SettingsManager.Instance.GetCurrentVoiceInputDeviceIndex(), 0, Mathf.Max(voiceInputDeviceOptions.Length - 1, 0));
			inputDeviceDropdown.selectedItemIndex = selectedItemIndex;
			inputDeviceDropdown.Initialize();
			inputDeviceDropdown.onValueChanged.AddListener(OnInputDeviceChanged);
		}
	}

	private void OnInputDeviceChanged(int index)
	{
		if (SettingsManager.Instance != null)
		{
			SettingsManager.Instance.SetVoiceInputDeviceByIndex(index);
		}
	}

	private void OnLanguageChanged(int languageIndex)
	{
		List<Locale> locales = UnityEngine.Localization.Settings.LocalizationSettings.AvailableLocales.Locales;
		if (languageIndex >= 0 && languageIndex < locales.Count)
		{
			Locale locale = (UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale = locales[languageIndex]);
			SettingsManager.SetThreadCulture(locale);
			if (SettingsManager.Instance != null)
			{
				SettingsManager.Instance.SetLanguageCode(locale.Identifier.Code);
			}
		}
	}

	private void Update()
	{
		if (isOpen && !SettingsKeyBindItem.IsAnyListening && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.ExitKey))
		{
			ClosePanel();
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		CheckCurrentScene();
		if (isMainMenu)
		{
			mainMenuPanel = Object.FindAnyObjectByType<MainMenuPanel>();
			audioSettingsBridge = Object.FindAnyObjectByType<AudioSettingsBridge>();
		}
	}

	private void CheckCurrentScene()
	{
		string text = SceneManager.GetActiveScene().name;
		isMainMenu = text == "MainMenu";
	}

	public void OpenPanel()
	{
		isOpen = true;
		cg.alpha = 1f;
		cg.interactable = true;
		cg.blocksRaycasts = true;
		SyncAllSliders();
	}

	public void ClosePanel()
	{
		if (!isOpen)
		{
			return;
		}
		SaveAllSettings();
		isOpen = false;
		if (isMainMenu)
		{
			DOTween.To(() => cg.alpha, delegate(float x)
			{
				cg.alpha = x;
			}, 0f, 0.3f).SetUpdate(isIndependentUpdate: true);
			cg.interactable = false;
			cg.blocksRaycasts = false;
			mainMenuPanel.ShowMainMenuCanvas();
			return;
		}
		DOTween.To(() => cg.alpha, delegate(float x)
		{
			cg.alpha = x;
		}, 0f, 0.3f).SetUpdate(isIndependentUpdate: true);
		cg.interactable = false;
		cg.blocksRaycasts = false;
		UIPausePanelController uIPausePanelController = Object.FindAnyObjectByType<UIPausePanelController>(FindObjectsInactive.Include);
		if (uIPausePanelController != null)
		{
			uIPausePanelController.ChangePanelActive();
		}
	}

	private void SaveAllSettings()
	{
		if (SettingsManager.Instance != null)
		{
			SettingsManager.Instance.OnCloseSettingsPanel();
		}
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		if (languages != null)
		{
			languages.onValueChanged.RemoveListener(OnLanguageChanged);
		}
		if (displayDropdown != null)
		{
			displayDropdown.onValueChanged.RemoveListener(OnDisplayChanged);
		}
		if (screenModeDropdown != null)
		{
			screenModeDropdown.onValueChanged.RemoveListener(OnScreenModeChanged);
		}
		if (resolutionDropdown != null)
		{
			resolutionDropdown.onValueChanged.RemoveListener(OnResolutionChanged);
		}
		if (inputDeviceDropdown != null)
		{
			inputDeviceDropdown.onValueChanged.RemoveListener(OnInputDeviceChanged);
		}
	}
}
