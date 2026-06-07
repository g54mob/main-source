using System;
using Infrastructure.Services;
using Infrastructure.Services.LocalizationService;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using Tasks_for_levels;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour, ISavedProgress, ISavedProgressReader
{
	[SerializeField]
	private Button exitButton;

	[SerializeField]
	private Toggle musicButton;

	[SerializeField]
	private Toggle soundButton;

	[SerializeField]
	private Slider soundSlider;

	[SerializeField]
	private Slider musicSlider;

	[SerializeField]
	private TMP_Dropdown languageDropdown;

	[SerializeField]
	private TMP_Dropdown windowModeDropdown;

	private PlayerInputActions playerInputActions;

	private int currentLanguage;

	private int currentWindowMode;

	private bool muteMusic;

	private bool muteSound;

	private float soundValue;

	private float musicValue;

	public static SettingsUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
		playerInputActions = new PlayerInputActions();
	}

	private void Start()
	{
		MainMenuUI.Instance.OnSettingsButton += Instance_OnSettingsButton;
		InputManager.Instance.OnEscape += InputManager_OnEscape;
		playerInputActions.MainMenu.CloseWindow.performed += CloseWindowButton;
		exitButton.onClick.AddListener(Hide);
		musicButton.onValueChanged.AddListener(OnMusicButtonClick);
		soundButton.onValueChanged.AddListener(OnSoundButtonClick);
		soundSlider.onValueChanged.AddListener(OnSoundSliderChanged);
		musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
		windowModeDropdown.onValueChanged.AddListener(ToggleFullscreen);
		Hide();
	}

	private void OnEnable()
	{
		playerInputActions.MainMenu.Enable();
	}

	private void OnDisable()
	{
		playerInputActions.MainMenu.Disable();
	}

	private void ToggleFullscreen(int arg)
	{
		switch (arg)
		{
		case 0:
			SetFullscreenMode();
			break;
		case 1:
			SetWindowedMode_1366x768();
			break;
		case 2:
			SetWindowedMode_1920x1080();
			break;
		case 3:
			SetWindowedMode_2560x1440();
			break;
		}
	}

	private void SetWindowedMode_2560x1440()
	{
		Screen.fullScreenMode = FullScreenMode.Windowed;
		Screen.fullScreen = false;
		Screen.SetResolution(2560, 1440, fullscreen: false);
		currentWindowMode = 3;
	}

	private void SetWindowedMode_1920x1080()
	{
		Screen.fullScreenMode = FullScreenMode.Windowed;
		Screen.fullScreen = false;
		Screen.SetResolution(1920, 1080, fullscreen: false);
		currentWindowMode = 2;
	}

	private void SetWindowedMode_1366x768()
	{
		Screen.fullScreenMode = FullScreenMode.Windowed;
		Screen.fullScreen = false;
		Screen.SetResolution(1366, 768, fullscreen: false);
		currentWindowMode = 1;
	}

	private void SetFullscreenMode()
	{
		Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		Screen.fullScreen = true;
		currentWindowMode = 0;
	}

	private void OnMusicSliderChanged(float newVolume)
	{
		musicValue = newVolume;
		MusicManager.Instance.ChangeVolume(musicValue);
	}

	private void OnSoundSliderChanged(float newVolume)
	{
		soundValue = newVolume;
		SoundManager.Instance.ChangeVolume(newVolume);
	}

	private void OnSoundButtonClick(bool sound)
	{
		muteSound = sound;
		AudioController.Instance.MuteSound(sound);
	}

	private void OnMusicButtonClick(bool music)
	{
		muteMusic = music;
		AudioController.Instance.MuteMusic(music);
	}

	private void InputManager_OnEscape(object sender, EventArgs e)
	{
		Hide();
	}

	private void Instance_OnSettingsButton(object sender, EventArgs e)
	{
		Show();
	}

	private void CloseWindowButton(InputAction.CallbackContext obj)
	{
		Hide();
	}

	public void ChangeLanguage(int index)
	{
		switch (index)
		{
		default:
			LocalizationManager.Language = "English";
			break;
		case 1:
			LocalizationManager.Language = "Russian";
			break;
		case 2:
			LocalizationManager.Language = "Japanese";
			break;
		case 3:
			LocalizationManager.Language = "German";
			break;
		case 4:
			LocalizationManager.Language = "French";
			break;
		case 5:
			LocalizationManager.Language = "Spanish";
			break;
		case 6:
			LocalizationManager.Language = "SChinese";
			break;
		case 7:
			LocalizationManager.Language = "TChinese";
			break;
		case 8:
			LocalizationManager.Language = "Korean";
			break;
		case 9:
			LocalizationManager.Language = "Portuguese-BRZ";
			break;
		case 10:
			LocalizationManager.Language = "Ukranian";
			break;
		case 11:
			LocalizationManager.Language = "Thai";
			break;
		case 12:
			LocalizationManager.Language = "Turkish";
			break;
		}
		currentLanguage = index;
		AllServices.Container.Single<IPersistentProgressService>().Progress.Language = currentLanguage;
		AllServices.Container.Single<ITaskService>().GetCurrentTask()?.UpdateSliders();
		CollectionManager.Instance.LocalizePlants();
	}

	private void OnDestroy()
	{
		MainMenuUI.Instance.OnSettingsButton -= Instance_OnSettingsButton;
		InputManager.Instance.OnEscape -= InputManager_OnEscape;
		playerInputActions.MainMenu.CloseWindow.performed -= CloseWindowButton;
		exitButton.onClick.RemoveAllListeners();
		musicButton.onValueChanged.RemoveAllListeners();
		soundButton.onValueChanged.RemoveAllListeners();
		soundSlider.onValueChanged.RemoveAllListeners();
		musicSlider.onValueChanged.RemoveAllListeners();
		windowModeDropdown.onValueChanged.RemoveAllListeners();
	}

	private void Show()
	{
		MainMenuUI.Instance.InnerWindowOpen = true;
		languageDropdown.value = currentLanguage;
		windowModeDropdown.value = currentWindowMode;
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		if (base.isActiveAndEnabled)
		{
			MainMenuUI.Instance.ToggleMainMenu(value: true);
			MainMenuUI.Instance.InnerWindowOpen = false;
			base.gameObject.SetActive(value: false);
		}
	}

	public void LoadProgress(PlayerProgress progress)
	{
		ChangeLanguage(progress.Language);
		OnMusicButtonClick(progress.MuteMusic);
		OnSoundButtonClick(progress.MuteSound);
		musicButton.isOn = progress.MuteMusic;
		soundButton.isOn = progress.MuteSound;
		soundSlider.value = progress.SoundVolume;
		musicSlider.value = progress.MusicVolume;
		soundValue = progress.SoundVolume;
		musicValue = progress.MusicVolume;
		currentWindowMode = progress.WindowMode;
	}

	public void UpdateProgress(PlayerProgress progress)
	{
		progress.Language = currentLanguage;
		progress.WindowMode = currentWindowMode;
		progress.MuteMusic = muteMusic;
		progress.MuteSound = muteSound;
		progress.SoundVolume = soundValue;
		progress.MusicVolume = musicValue;
	}
}
