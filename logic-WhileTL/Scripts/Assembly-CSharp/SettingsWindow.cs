using System.Collections.Generic;
using System.Runtime.InteropServices;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsWindow : ActiveComponent, IPointerUpHandler, IEventSystemHandler
{
	[SceneBind("SettingsWindow")]
	public Image SettingsSubWindow;

	[SceneBind("ControlsWindow")]
	public Image ControlsWindow;

	[SceneBind("ControlsWindow/KeyboardBtnBack/KeyboardBtn")]
	public Button KeyboardBtn;

	[SceneBind("ControlsWindow/JoystickBtnBack/JoystickBtn")]
	public Button JoystickBtn;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolder")]
	public Image ControlsHolder;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolderJoystick")]
	public Image ControlsHolderJoystick;

	[SceneBind("SettingsWindow/ControlsBtn")]
	public Button ControlsBtn;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolder/Scroll View")]
	public ScrollRect ScrollRect;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolderJoystick/Scroll View")]
	public ScrollRect ScrollRectJoystick;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolder/Scroll View/Viewport/Content")]
	public Transform Content;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolderJoystick/Scroll View/Viewport/Content")]
	public Transform ContentJoystick;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolder/Scroll View/BackControlsRect")]
	public RectTransform BackControlsRect;

	[SceneBind("ControlsWindow/ControlsHover/ControlsHolderJoystick/Scroll View/BackControlsRect")]
	public RectTransform BackControlsRectJoyStick;

	[SceneBind("SettingsWindow/Delete")]
	public Button Delete;

	[SceneBind("SettingsWindow/AttentionDelete/Accept")]
	public Button AcceptDelete;

	[SceneBind("SettingsWindow/AttentionDelete/Cancel")]
	public Button CancelDelete;

	[SceneBind("SettingsWindow/AttentionDelete/InputDelete")]
	public InputField InputDelete;

	[SceneBind("SettingsWindow/AttentionDelete")]
	public Image AttentionDelete;

	[SceneBind("ControlsWindow/SettingsBtn")]
	public Button SettingsBtn;

	[SceneBind("SettingsWindow/ColorBlind")]
	public Toggle ColorBlind;

	[SceneBind("SettingsWindow/SoundSlider")]
	public Slider SoundSlider;

	[SceneBind("SettingsWindow/MusicSlider")]
	public Slider Music;

	[SceneBind("SettingsWindow/DisableTutorial")]
	public Toggle DisableTutorial;

	[SceneBind("SettingsWindow/ForcedVisualKeyboard")]
	public Toggle ForcedVisualKeyboard;

	[SceneBind("SettingsWindow/ForcedDisableController")]
	public Toggle ForcedDisableController;

	[SceneBind("SettingsWindow/FullScreen")]
	public Toggle FullScreen;

	[SceneBind("SettingsWindow/ChooseRandomTheme")]
	public Toggle ChooseRandomTheme;

	private List<Dropdown.OptionData> optionsLang = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsVideo = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsTheme = new List<Dropdown.OptionData>();

	private List<Dropdown.OptionData> optionsVibration = new List<Dropdown.OptionData>();

	[SceneBind("SettingsWindow/LanguageDropdown")]
	public Dropdown LanguageDropdown;

	[SceneBind("SettingsWindow/LanguagesHolder/Text")]
	public Text Languages;

	[SceneBind("SettingsWindow/LanguagesHolder/Prev")]
	public Button PrevLanguages;

	[SceneBind("SettingsWindow/LanguagesHolder/Next")]
	public Button NextLanguages;

	[SceneBind("SettingsWindow/ThemesHolder/Text")]
	public Text Themes;

	[SceneBind("SettingsWindow/ThemesHolder/Prev")]
	public Button PrevThemes;

	[SceneBind("SettingsWindow/ThemesHolder/Next")]
	public Button NextThemes;

	[SceneBind("SettingsWindow/ResolutionsHolder/Text")]
	public Text Resoulutions;

	[SceneBind("SettingsWindow/ResolutionsHolder/Prev")]
	public Button PrevResolutions;

	[SceneBind("SettingsWindow/ResolutionsHolder/Next")]
	public Button NextResolutions;

	[SceneBind("SettingsWindow/ThemeDropdown")]
	public Dropdown ThemeDropdown;

	[SceneBind("SettingsWindow/ResolutionDropdown")]
	public Dropdown ResolutionDropdown;

	public List<string> aviableThemeKeys = new List<string>();

	[SceneBind("SettingsWindow/VideoDropdown")]
	public Dropdown VideoDropdown;

	[SceneBind("Close")]
	public Button Close;

	[SceneBind("SettingsWindow/RestorePurchases")]
	public Button RestorePurchases;

	[SceneBind("SettingsWindow/RestorePurchases/Text")]
	public Text RestorePurchasesText;

	[SceneBind("SettingsWindow/HideHomeBtnOnIphoneX")]
	public Toggle HideHomeBtnOnIphoneX;

	[SceneBind("SettingsWindow/DisableVibration")]
	public Toggle DisableVibration;

	[SceneBind("SettingsWindow/VibrationSettings")]
	public Dropdown VibrationSettings;

	private bool pointerUpOnFrame;

	private bool valueChangedOnFrame;

	private Dictionary<string, Pair<int, int>> UnityResolutions = new Dictionary<string, Pair<int, int>>();

	private List<string> resolutions = new List<string>();

	private string progressChars = "-\\|/";

	private float progressSpeed = 10f;

	private bool languageDropdownOpen;

	private bool videoDropdownOpen;

	private bool vibrationDropdownOpen;

	private bool themeDropdownOpen;

	private bool languageDropdownClosing;

	private bool videoDropdownClosing;

	private bool vibrationDropdownClosing;

	private bool themeDropdownClosing;

	private int skipFrames;

	private ContentSizeFitter sizeFilter;

	private GridLayoutGroup layoutGroup;

	private ContentSizeFitter sizeFilterJoyStick;

	private GridLayoutGroup layoutGroupJoyStick;

	[DllImport("user32.dll")]
	private static extern bool SetCursorPos(int X, int Y);

	private void UpdateLangState()
	{
		Languages.text = LanguageDropdown.options[ActiveComponent.Model.globalSaves.lang].text;
		PrevLanguages.gameObject.SetActive(ActiveComponent.Model.globalSaves.lang != 0);
		NextLanguages.gameObject.SetActive(ActiveComponent.Model.globalSaves.lang != LanguageDropdown.options.Count - 1);
	}

	private void NextLang(int value = 1)
	{
		ActiveComponent.Model.globalSaves.lang += value;
		LanguageDropdown.value = ActiveComponent.Model.globalSaves.lang;
		UpdateLangState();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	private void UpdateThemesState()
	{
		int num = ThemeDropdown.options.FindIndex((Dropdown.OptionData i) => i.text == TextResources.GetString(ActiveComponent.Model.globalSaves.activeTheme + "_THEME"));
		Themes.text = ThemeDropdown.options[num].text;
		PrevThemes.gameObject.SetActive(num != 0);
		NextThemes.gameObject.SetActive(num != ThemeDropdown.options.Count - 1);
	}

	private void NextTheme(int value = 1)
	{
		int num = ThemeDropdown.options.FindIndex((Dropdown.OptionData i) => i.text == TextResources.GetString(ActiveComponent.Model.globalSaves.activeTheme + "_THEME"));
		num += value;
		ThemeDropdown.value = num;
		UpdateThemesState();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	private void UpdateResolutionsState()
	{
		int num = ResolutionDropdown.options.FindIndex((Dropdown.OptionData i) => i.text == ActiveComponent.Model.globalSaves.Resolution.First + "x" + ActiveComponent.Model.globalSaves.Resolution.Second);
		Resoulutions.text = ResolutionDropdown.options[num].text;
		PrevResolutions.gameObject.SetActive(num != 0);
		NextResolutions.gameObject.SetActive(num != ResolutionDropdown.options.Count - 1);
	}

	private void NextResolution(int value = 1)
	{
		int num = ResolutionDropdown.options.FindIndex((Dropdown.OptionData i) => i.text == ActiveComponent.Model.globalSaves.Resolution.First + "x" + ActiveComponent.Model.globalSaves.Resolution.Second);
		num += value;
		SetResolution(num);
		UpdateResolutionsState();
		ResolutionDropdown.value = num;
		ResolutionDropdown.RefreshShownValue();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	public void OnPointerUp(PointerEventData data)
	{
		pointerUpOnFrame = true;
	}

	private void ToJoystickControls()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (ControlsHolderJoystick != null)
		{
			ControlsHolderJoystick.gameObject.SetActive(value: true);
		}
		if (ControlsHolder == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
		}
		if (ControlsHolder != null)
		{
			ControlsHolder.gameObject.SetActive(value: false);
		}
		KeyboardBtn.transform.parent.gameObject.SetActive(value: true);
		JoystickBtn.transform.parent.gameObject.SetActive(value: false);
	}

	private void ToKeybordControls()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (ControlsHolderJoystick != null)
		{
			ControlsHolderJoystick.gameObject.SetActive(value: false);
		}
		if (ControlsHolder == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
		}
		if (ControlsHolder != null)
		{
			ControlsHolder.gameObject.SetActive(value: true);
		}
		KeyboardBtn.transform.parent.gameObject.SetActive(value: false);
		JoystickBtn.transform.parent.gameObject.SetActive(value: true);
	}

	private void DeepClearAccept()
	{
		if (!(InputDelete.text != "DELETE"))
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			Steam.DeleteAllCloudSaves(Logic.GetSaveNameTemplate());
			Logic.DeleteAllSaves();
			ActiveComponent.Model.globalSaves.Preview.Clear();
			ActiveComponent.Model.globalSaves.newGames = 0;
			Logic.UpdateGlobalSaves();
			Application.Quit();
		}
	}

	private void ChangeDelete(string val)
	{
		AcceptDelete.gameObject.SetActive(val == "DELETE");
	}

	private void DeepClearCancel()
	{
		AttentionDelete.gameObject.SetActive(value: false);
	}

	private void DeleteClick()
	{
		AttentionDelete.gameObject.SetActive(value: true);
		AcceptDelete.gameObject.SetActive(value: false);
		InputDelete.text = "";
	}

	private void ToSettings()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		SettingsSubWindow.gameObject.SetActive(value: true);
		if (ControlsWindow == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			SettingsBtn.onClick.AddListener(ToSettings);
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
			InitKeyJoyBtns();
			ControlsHolderJoystick.gameObject.SetActive(value: false);
			ControlsHolder.gameObject.SetActive(value: true);
		}
		ControlsWindow.gameObject.SetActive(value: false);
	}

	private void ToControls()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		SettingsSubWindow.gameObject.SetActive(value: false);
		if (ControlsWindow == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			SettingsBtn.onClick.AddListener(ToSettings);
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
			InitKeyJoyBtns();
			ControlsHolderJoystick.gameObject.SetActive(value: false);
			ControlsHolder.gameObject.SetActive(value: true);
		}
		ControlsWindow.gameObject.SetActive(value: true);
	}

	private void ColorBlindChange(bool click)
	{
		ActiveComponent.Model.globalSaves.Set(SaveFlags.ColorBlind, click);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.UpdateGlobalSaves();
	}

	private void RandomThemeClick(bool click)
	{
		ActiveComponent.Model.globalSaves.useRandomTheme = click;
		if (!click)
		{
			ChangeTheme();
		}
		else
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		Logic.UpdateGlobalSaves();
	}

	private void DisableTutorialClick(bool click)
	{
		ActiveComponent.Model.globalSaves.Set(SaveFlags.DisabledTutorial, click);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.UpdateGlobalSaves();
	}

	private void ForcedVisualClick(bool click)
	{
		ActiveComponent.Model.globalSaves.ForcedVisualKeyBoard = click;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.UpdateGlobalSaves();
	}

	private void ForcedIgnoreController(bool click)
	{
		ActiveComponent.Model.globalSaves.ForcedDisableController = click;
		if (ActiveComponent.Model.globalSaves.ForcedDisableController)
		{
			Logic.GetModel().InputDeviceChanged.Invoke("PC");
			Logic.GetModel().CurInputDevice = "PC";
			Debug.LogError("C");
			Logic.GetModel().CurInputDeviceIsController = false;
			Vector2Int vector2Int = MonitorUtils.WorldToMonitorPoint(base.transform.position);
			SetCursorPos(vector2Int.x, vector2Int.y);
			Cursor.SetCursor(ActiveComponent.Program.cursor.cursorSprite, Vector2.zero, CursorMode.Auto);
			Cursor.visible = true;
			ActiveComponent.Program.cursor.curImg.enabled = false;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.UpdateGlobalSaves();
	}

	private void ChangeLang()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.lang = LanguageDropdown.value;
		TextResources.DropCachedTexts();
		TextResources.UpdateTexts();
		Redraw();
		Logic.UpdateGlobalSaves();
	}

	private void ChangeVideo()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.video = VideoDropdown.value;
		base.gameObject.transform.root.GetComponent<Canvas>().pixelPerfect = ActiveComponent.Model.globalSaves.video == 0;
		Logic.UpdateGlobalSaves();
	}

	private void MusicChange(float val)
	{
		ActiveComponent.Model.globalSaves.musicVolume = val;
		ActiveComponent._controller.MenuView.Music.value = val;
		ActiveComponent.Sound.SetVolume(SoundGroup.MUSIC, val);
	}

	private void SoundChange(float val)
	{
		ActiveComponent.Model.globalSaves.soundVolume = val;
		ActiveComponent._controller.MenuView.SoundSlider.value = val;
		ActiveComponent.Sound.SetVolume(SoundGroup.UI, val);
		valueChangedOnFrame = true;
	}

	private void CloseClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Program.cursor.SetPosition(ActiveComponent.Program.mainMenu.Settings.transform.position);
		base.gameObject.SetActive(value: false);
	}

	private void ResetVideoSettings()
	{
		VideoDropdown.onValueChanged.RemoveAllListeners();
		VideoDropdown.ClearOptions();
		optionsVideo.Clear();
		optionsVideo.Add(new Dropdown.OptionData(TextResources.GetString("LOWVIDEO")));
		optionsVideo.Add(new Dropdown.OptionData(TextResources.GetString("HIGHVIDEO")));
		VideoDropdown.AddOptions(optionsVideo);
		VideoDropdown.value = ActiveComponent.Model.globalSaves.video;
		VideoDropdown.onValueChanged.AddListener(delegate
		{
			ChangeVideo();
		});
	}

	private void ResetVibrationSettings()
	{
		VibrationSettings.onValueChanged.RemoveAllListeners();
		VibrationSettings.ClearOptions();
		optionsVibration.Clear();
		optionsVibration.Add(new Dropdown.OptionData(TextResources.GetString("VIBRATION_DISABLED")));
		optionsVibration.Add(new Dropdown.OptionData(TextResources.GetString("VIBRATION_ONLY_SOCKETS")));
		optionsVibration.Add(new Dropdown.OptionData(TextResources.GetString("VIBRATION_NODES_UI")));
		optionsVibration.Add(new Dropdown.OptionData(TextResources.GetString("VIBRATION_SOCKETS_AND_UI")));
		optionsVibration.Add(new Dropdown.OptionData(TextResources.GetString("VIBRATION_ALL")));
		VibrationSettings.AddOptions(optionsVibration);
		VibrationSettings.value = ActiveComponent.Model.globalSaves.vibration;
		VibrationSettings.onValueChanged.AddListener(delegate
		{
			ChangeVibrationSettings();
		});
	}

	private void ChangeTheme()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.activeTheme = aviableThemeKeys[ThemeDropdown.value];
		base.gameObject.transform.parent.GetComponent<MainMenu>().ActiveTheme(aviableThemeKeys[ThemeDropdown.value]);
		Logic.UpdateGlobalSaves();
	}

	private void ChangeVibrationSettings()
	{
		ActiveComponent.Model.globalSaves.vibration = VibrationSettings.value;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.UpdateGlobalSaves();
	}

	public void RedrawRewiredStates()
	{
		if (!Model.steamDeckRunning)
		{
			if (PrevLanguages != null)
			{
				UpdateLangState();
			}
			if (PrevResolutions != null)
			{
				UpdateResolutionsState();
			}
		}
	}

	public void Redraw()
	{
		optionsTheme.Clear();
		aviableThemeKeys.Clear();
		foreach (BaseItem theme in ActiveComponent._staticData.Themes)
		{
			if (ActiveComponent.Model.globalSaves.unlockedMainThemes.Contains(theme.KeyName.ToLower()))
			{
				optionsTheme.Add(new Dropdown.OptionData(TextResources.GetString(theme.KeyName + "_THEME")));
				aviableThemeKeys.Add(theme.KeyName);
			}
		}
		ThemeDropdown.ClearOptions();
		ThemeDropdown.AddOptions(optionsTheme);
		int value = aviableThemeKeys.FindIndex((string i) => i.ToLower() == ActiveComponent.Model.globalSaves.activeTheme.ToLower());
		ThemeDropdown.value = value;
		ResetVideoSettings();
		ResetVibrationSettings();
		ThemeDropdown.onValueChanged.AddListener(delegate
		{
			ChangeTheme();
		});
		ThemeDropdown.gameObject.SetActive(ActiveComponent.Model.globalSaves.unlockedMainThemes.Count > 0 && !ActiveComponent.Model.CurInputDeviceIsController);
		ChooseRandomTheme.gameObject.SetActive(value: true);
		if (NextThemes != null)
		{
			NextThemes.onClick.RemoveAllListeners();
			NextThemes.onClick.AddListener(delegate
			{
				NextTheme();
			});
		}
		if (PrevThemes != null)
		{
			PrevThemes.onClick.RemoveAllListeners();
			PrevThemes.onClick.AddListener(delegate
			{
				NextTheme(-1);
			});
			UpdateThemesState();
		}
	}

	private void HideHomeBtnOnIphoneXClick(bool value)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.hideHomeBtnOnIphoneX = value;
	}

	private void DisableVibrationState(bool value)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.disableVibration = value;
	}

	private void BigNodesState(bool value)
	{
		ActiveComponent.Model.ClearBaseBlocksPool();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.bigNodes = value;
	}

	private void OnFullscreenToggleChanged(bool value)
	{
		Screen.fullScreen = value;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.FullScreen = value;
	}

	private void SetResolution(int index)
	{
		Pair<int, int> pair = UnityResolutions[resolutions[index]];
		Screen.SetResolution(pair.First, pair.Second, ActiveComponent.Model.globalSaves.FullScreen);
		ActiveComponent.Model.globalSaves.Resolution = pair;
	}

	private void OnResolutionDropdownChanged(int index)
	{
		SetResolution(index);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		PlatformDependendSelfDestroy component = ControlsWindow.transform.GetComponent<PlatformDependendSelfDestroy>();
		if (component != null)
		{
			component.Check();
		}
		if (ControlsWindow == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
		}
		if (ControlsWindow != null)
		{
			PlatformDependendSelfDestroy component2 = ControlsWindow.gameObject.GetComponent<PlatformDependendSelfDestroy>();
			if (component2 != null)
			{
				component2.Check();
			}
		}
		if (ControlsWindow != null)
		{
			ControlsWindow.gameObject.SetActive(value: false);
		}
		SettingsBtn.onClick.AddListener(ToSettings);
		ControlsBtn.onClick.AddListener(ToControls);
		ColorBlind.isOn = ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ColorBlind);
		ColorBlind.onValueChanged.AddListener(ColorBlindChange);
		ForcedVisualKeyboard.isOn = ActiveComponent.Model.globalSaves.ForcedVisualKeyBoard;
		ForcedVisualKeyboard.onValueChanged.AddListener(ForcedVisualClick);
		ForcedDisableController.isOn = ActiveComponent.Model.globalSaves.ForcedDisableController;
		ForcedDisableController.onValueChanged.AddListener(ForcedIgnoreController);
		if (Logic.IsSteamDeckRunning())
		{
			ForcedDisableController.gameObject.SetActive(value: false);
		}
		DisableTutorial.isOn = ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial);
		DisableTutorial.onValueChanged.AddListener(DisableTutorialClick);
		if (Logic.IsSteamDeckRunning())
		{
			FullScreen.gameObject.SetActive(value: false);
			ResolutionDropdown.gameObject.SetActive(value: false);
		}
		else
		{
			FullScreen.isOn = ActiveComponent.Model.globalSaves.FullScreen;
			FullScreen.onValueChanged.AddListener(OnFullscreenToggleChanged);
			for (int num = Screen.resolutions.Length - 1; num >= 0; num--)
			{
				Resolution resolution = Screen.resolutions[num];
				string text = $"{resolution.width}x{resolution.height}";
				if (!resolutions.Contains(text))
				{
					UnityResolutions.Add(text, new Pair<int, int>(resolution.width, resolution.height));
					resolutions.Add(text);
				}
			}
			foreach (string commonSteamResolution in ActiveComponent.Program.CommonSteamResolutions)
			{
				if (!resolutions.Contains(commonSteamResolution))
				{
					string[] array = commonSteamResolution.Split('x');
					int first = int.Parse(array[0]);
					int second = int.Parse(array[1]);
					resolutions.Add(commonSteamResolution);
					UnityResolutions.Add(commonSteamResolution, new Pair<int, int>(first, second));
				}
			}
			resolutions.Sort();
			ResolutionDropdown.ClearOptions();
			ResolutionDropdown.AddOptions(resolutions);
			ResolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownChanged);
			ResolutionDropdown.value = resolutions.FindIndex((string i) => i == Logic.GetModel().globalSaves.Resolution.First + "x" + Logic.GetModel().globalSaves.Resolution.Second);
			ResolutionDropdown.RefreshShownValue();
		}
		HideHomeBtnOnIphoneX.gameObject.SetActive(value: false);
		DisableVibration.gameObject.SetActive(value: false);
		if (Model.steamDeckRunning)
		{
			VibrationSettings.gameObject.SetActive(value: false);
		}
		DisableVibration.isOn = ActiveComponent.Model.globalSaves.disableVibration;
		DisableVibration.onValueChanged.AddListener(DisableVibrationState);
		HideHomeBtnOnIphoneX.isOn = ActiveComponent.Model.globalSaves.hideHomeBtnOnIphoneX;
		HideHomeBtnOnIphoneX.onValueChanged.AddListener(HideHomeBtnOnIphoneXClick);
		optionsLang.Clear();
		foreach (Language language in ActiveComponent._staticData.Languages)
		{
			optionsLang.Add(new Dropdown.OptionData(language.ShowName));
		}
		LanguageDropdown.ClearOptions();
		LanguageDropdown.AddOptions(optionsLang);
		LanguageDropdown.value = ActiveComponent.Model.globalSaves.lang;
		LanguageDropdown.onValueChanged.AddListener(delegate
		{
			ChangeLang();
		});
		ResetVideoSettings();
		ResetVibrationSettings();
		SoundSlider.onValueChanged.AddListener(SoundChange);
		Music.onValueChanged.AddListener(MusicChange);
		Delete.onClick.AddListener(DeleteClick);
		AcceptDelete.onClick.AddListener(DeepClearAccept);
		CancelDelete.onClick.AddListener(DeepClearCancel);
		AttentionDelete.gameObject.SetActive(value: false);
		InputDelete.onValueChanged.AddListener(ChangeDelete);
		ChooseRandomTheme.isOn = ActiveComponent.Model.globalSaves.useRandomTheme;
		ChooseRandomTheme.onValueChanged.AddListener(RandomThemeClick);
		Redraw();
		SoundSystem sound = ActiveComponent.Sound;
		float value = (Music.value = ActiveComponent.Model.globalSaves.musicVolume);
		sound.SetVolume(SoundGroup.MUSIC, value);
		SoundSystem sound2 = ActiveComponent.Sound;
		value = (SoundSlider.value = ActiveComponent.Model.globalSaves.soundVolume);
		sound2.SetVolume(SoundGroup.UI, value);
		Close.onClick.AddListener(CloseClick);
		sizeFilter = Content.GetComponent<ContentSizeFitter>();
		layoutGroup = Content.GetComponent<GridLayoutGroup>();
		skipFrames = 0;
		ScrollRect.onValueChanged.AddListener(delegate
		{
			UpdateVisibilityOnScreen();
		});
		Delete.gameObject.SetActive(value: false);
		InitKeyJoyBtns();
		if (NextResolutions != null)
		{
			NextResolutions.onClick.AddListener(delegate
			{
				NextResolution();
			});
		}
		if (PrevResolutions != null)
		{
			PrevResolutions.onClick.AddListener(delegate
			{
				NextResolution(-1);
			});
		}
		if (NextLanguages != null)
		{
			NextLanguages.onClick.AddListener(delegate
			{
				NextLang();
			});
		}
		if (PrevLanguages != null)
		{
			PrevLanguages.onClick.AddListener(delegate
			{
				NextLang(-1);
			});
		}
	}

	private void InitKeyJoyBtns()
	{
		if (KeyboardBtn != null)
		{
			KeyboardBtn.onClick.AddListener(ToKeybordControls);
		}
		if (JoystickBtn != null)
		{
			JoystickBtn.onClick.AddListener(ToJoystickControls);
			KeyboardBtn.transform.parent.gameObject.SetActive(value: false);
		}
	}

	private void UpdateVisibilityOnScreen(bool ignoreCounter = false)
	{
		if (skipFrames < 15)
		{
			return;
		}
		if (sizeFilter == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			SettingsBtn.onClick.AddListener(ToSettings);
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
		}
		foreach (Transform item in Content.transform)
		{
			bool flag = BackControlsRect.rect.Contains(item.position);
			if (item.gameObject.activeInHierarchy != flag)
			{
				item.gameObject.SetActive(flag);
			}
		}
	}

	private void UpdateVisibilityOnScreenJoyStick(bool ignoreCounter = false)
	{
		if (skipFrames < 15)
		{
			return;
		}
		if (sizeFilterJoyStick == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRectJoystick.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreenJoyStick();
			});
			sizeFilterJoyStick = ContentJoystick.GetComponent<ContentSizeFitter>();
			layoutGroupJoyStick = ContentJoystick.GetComponent<GridLayoutGroup>();
		}
		foreach (Transform item in Content.transform)
		{
			bool flag = BackControlsRectJoyStick.rect.Contains(item.position);
			if (item.gameObject.activeInHierarchy != flag)
			{
				item.gameObject.SetActive(flag);
			}
		}
	}

	private void LateUpdate()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (ControlsWindow == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			SettingsBtn.onClick.AddListener(ToSettings);
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
			InitKeyJoyBtns();
			ControlsHolderJoystick.gameObject.SetActive(value: false);
			ControlsHolder.gameObject.SetActive(value: true);
			ControlsWindow.gameObject.SetActive(value: false);
		}
		if (SettingsSubWindow.gameObject.activeSelf)
		{
			return;
		}
		if (ControlsWindow == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			SettingsBtn.onClick.AddListener(ToSettings);
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
			InitKeyJoyBtns();
			ControlsHolderJoystick.gameObject.SetActive(value: false);
			ControlsHolder.gameObject.SetActive(value: true);
			ControlsWindow.gameObject.SetActive(value: true);
		}
		else
		{
			ControlsWindow.gameObject.SetActive(value: true);
		}
	}

	private void Update()
	{
		if (!base.IsInited)
		{
			return;
		}
		if (ControlsWindow == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
			SettingsBtn.onClick.AddListener(ToSettings);
			ControlsWindow.gameObject.SetActive(value: false);
		}
		skipFrames++;
		if (Input.GetMouseButtonUp(0) && valueChangedOnFrame)
		{
			valueChangedOnFrame = false;
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
		Logic.UpdateCursorCanvasStatus(ref languageDropdownOpen, ref languageDropdownClosing, LanguageDropdown);
		Logic.UpdateCursorCanvasStatus(ref videoDropdownOpen, ref videoDropdownClosing, VideoDropdown);
		Logic.UpdateCursorCanvasStatus(ref vibrationDropdownOpen, ref vibrationDropdownClosing, VibrationSettings);
		Logic.UpdateCursorCanvasStatus(ref themeDropdownOpen, ref themeDropdownClosing, ThemeDropdown);
		if (!ActiveComponent.Program.joyInput.areaMove)
		{
			return;
		}
		if (ScrollRect == null)
		{
			SceneBindContainer.BindObjects(this, base.transform);
			ScrollRect.onValueChanged.AddListener(delegate
			{
				UpdateVisibilityOnScreen();
			});
			sizeFilter = Content.GetComponent<ContentSizeFitter>();
			layoutGroup = Content.GetComponent<GridLayoutGroup>();
			SettingsBtn.onClick.AddListener(ToSettings);
		}
		Vector3 areaMoveDelta = ActiveComponent.Program.joyInput.areaMoveDelta;
		areaMoveDelta.x = 0f;
		if (ScrollRect.gameObject.activeInHierarchy)
		{
			ScrollRect.content.transform.position += Logic.ModifySliderMoveDelta(areaMoveDelta);
		}
		if (ScrollRectJoystick.gameObject.activeInHierarchy)
		{
			ScrollRectJoystick.content.transform.position += Logic.ModifySliderMoveDelta(areaMoveDelta);
		}
		UpdateVisibilityOnScreen();
		UpdateVisibilityOnScreenJoyStick();
	}
}
