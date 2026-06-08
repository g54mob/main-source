using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
	[Serializable]
	public enum Wallpaper
	{
		DEFAULT = 0,
		BLISS = 1,
		IMG100 = 2,
		KOALA = 3
	}

	protected class SettingFields
	{
		public int resolutionIndex;

		public bool isFullscreen;

		public bool isWindowed;

		public bool isAssistantDisabled;

		public Wallpaper wallpaper;

		public float masterVolume;

		public float soundEffectVolume;

		public CRTSettings.SettingFields crtSettings;

		public SettingFields(int resIndex, bool isFullscreen, bool isWindowed, float masterVol, float sfxVolume, Wallpaper wallpaper, bool isAssistantDisabled, CRTSettings.SettingFields crtSettings)
		{
			resolutionIndex = resIndex;
			this.isFullscreen = isFullscreen;
			this.isWindowed = isWindowed;
			this.wallpaper = wallpaper;
			masterVolume = masterVol;
			soundEffectVolume = sfxVolume;
			this.isAssistantDisabled = isAssistantDisabled;
			this.crtSettings = crtSettings;
		}

		public bool Equals(SettingFields other)
		{
			if (resolutionIndex == other.resolutionIndex && isFullscreen == other.isFullscreen && isWindowed == other.isWindowed && isAssistantDisabled == other.isAssistantDisabled && wallpaper == other.wallpaper && masterVolume == other.masterVolume && soundEffectVolume == other.soundEffectVolume)
			{
				return crtSettings.Equals(other.crtSettings);
			}
			return false;
		}

		public void SetFields(SettingFields other)
		{
			resolutionIndex = other.resolutionIndex;
			isFullscreen = other.isFullscreen;
			isWindowed = other.isWindowed;
			isAssistantDisabled = other.isAssistantDisabled;
			wallpaper = other.wallpaper;
			masterVolume = other.masterVolume;
			soundEffectVolume = other.soundEffectVolume;
			crtSettings = new CRTSettings.SettingFields(other.crtSettings);
		}
	}

	[SerializeField]
	private TMP_Dropdown resolutionDropdown;

	[SerializeField]
	private ThomasGridLayoutGroup iconGrid;

	[SerializeField]
	private Button applySettingsButton;

	[SerializeField]
	private Toggle fullscreen;

	[SerializeField]
	private Toggle windowed;

	[SerializeField]
	private Slider masterVol;

	[SerializeField]
	private Slider sfxVol;

	[SerializeField]
	private AudioMixer sfxMixer;

	[SerializeField]
	private GameObject clearSavePopup;

	[SerializeField]
	private Button resetProgressButton;

	[SerializeField]
	private GameObject clearSaveFinalPopup;

	[SerializeField]
	private IconGenerator iconController;

	[SerializeField]
	private SceneSwitcher sceneSwitcher;

	[SerializeField]
	private BackgroundManager backgroundManager;

	[SerializeField]
	private Button wallpaperDefault;

	[SerializeField]
	private Button wallpaperBliss;

	[SerializeField]
	private Button wallpaperKoala;

	[SerializeField]
	private Button wallpaperImg100;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private AssistantSpawner peeker;

	[SerializeField]
	private Toggle assistantToggle;

	[SerializeField]
	private MouseClick mouseClick;

	[SerializeField]
	private CoroutineRunner runner;

	[SerializeField]
	private CRTSettings crt;

	[SerializeField]
	private AudioClip[] crtSfx;

	[SerializeField]
	private ClickDrag clickDrag;

	[SerializeField]
	private Animator taskbarAnimator;

	[SerializeField]
	private GameObject hotkeyWindow;

	[SerializeField]
	private TaskbarManager taskbarManager;

	[SerializeField]
	private Sprite hotkeyTaskbarSprite;

	private static int MIN_RESOLUTION = 1000;

	private static float MIXER_MIN_VOLUME = -80f;

	public static float DEFAULT_VOLUME = 0.8f;

	public static string SFX_VOLUME_MIXER_KEY = "SfxVolume";

	private List<Resolution> filteredResolutions;

	private SettingFields currentSettings;

	private SettingFields settingsChanges;

	private Canvas canvas;

	protected ClosePanelAudio panelSfx;

	protected Notification toggleSfx;

	protected AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		panelSfx = SoundEffectUtils.GetOpenClosePanelPlayer();
		toggleSfx = SoundEffectUtils.GetNotificationPlayer();
		SetDisplayToggles();
		toggleSfx.AddToggleListener(fullscreen);
		toggleSfx.AddToggleListener(windowed);
		toggleSfx.AddToggleListener(assistantToggle);
		float num = SetMasterVolumeSlider();
		float sfxVolume = SetSfxVolumeSlider();
		int resIndex = PopulateResolutions();
		Wallpaper savedWallpaper = PlayerPrefsManager.GetSavedWallpaper();
		bool flag = IsAssistantDisabled();
		Debug.Log($"isAssistantDisabled -> {flag}");
		currentSettings = new SettingFields(resIndex, fullscreen.isOn, windowed.isOn, num, sfxVolume, savedWallpaper, flag, GetCRTSettings());
		settingsChanges = new SettingFields(resIndex, fullscreen.isOn, windowed.isOn, num, sfxVolume, savedWallpaper, flag, GetCRTSettings());
		assistantToggle.isOn = flag;
		ApplyBackgroundButtonInteractable(savedWallpaper);
	}

	private CRTSettings.SettingFields GetCRTSettings()
	{
		return new CRTSettings.SettingFields(CRTSettings.IsCrtEnabled(), CRTSettings.GetSavedChromaticValue(), CRTSettings.GetSavedScanLinesValue());
	}

	private void OnEnable()
	{
		resetProgressButton.interactable = true;
	}

	public void InstantiateClearSavePopup()
	{
		if (CreateTables.DEV_MODE)
		{
			NukeSaves();
			return;
		}
		CreateClearSaveConfirmationPopup(delegate
		{
			CreateClearSaveConfirmationPopup(delegate
			{
				CreateClearSaveConfirmationPopup(delegate
				{
					CreateClearSaveConfirmationPopup(delegate
					{
						CreateClearSaveConfirmationPopup(delegate
						{
							CreateClearSaveConfirmationPopup(NukeSaves, "Ok, fine. I wasn't honest with you previously but I <b>WILL</b> delete your save this time!", "WAIT!");
						}, "Two more chances to back out.");
					}, "You know you can't undo this right? I'll give you one more chance to back out.");
				}, "Like, really really sure?", "No...");
			}, "Are you sure?");
		}, "Are you sure you would like to delete your current save and restart your progress?");
	}

	public void CreateClearSaveConfirmationPopup(UnityAction onYes, string textBody, string noText = "Cancel")
	{
		panelSfx.PlayOpen();
		GameObject popup = UnityEngine.Object.Instantiate(clearSavePopup, canvas.transform.position, Quaternion.identity, canvas.transform);
		UIUtils.SetPenultimateLayer(popup);
		Confirmation confirmation = popup.GetComponent<Confirmation>();
		resetProgressButton.interactable = false;
		confirmation.SetYesButton(delegate
		{
			onYes();
			UnityEngine.Object.Destroy(popup);
		});
		confirmation.SetNoButton(delegate
		{
			confirmation.GetToolbar().Close();
			resetProgressButton.interactable = true;
		});
		confirmation.SetText(textBody);
		confirmation.SetYesButtonText("Yes");
		confirmation.SetNoButtonText(noText);
		popup.GetComponent<Panel>().SetToolbarName("Reset Progress");
		confirmation.GetToolbar().AddCloseFunction(delegate
		{
			resetProgressButton.interactable = true;
		});
		PanelManager.OpenWindow(popup);
	}

	public void OpenHotkeyPanel()
	{
		if (!taskbarManager.IsMaximumTaskbarButtons(hotkeyWindow))
		{
			panelSfx.PlayOpen();
			PanelManager.OpenWindow(hotkeyWindow);
			taskbarManager.AddTaskbar(hotkeyWindow, hotkeyTaskbarSprite, "Hotkeys");
		}
	}

	public void SetBackground(int wallpaper)
	{
		if (settingsChanges != null)
		{
			settingsChanges.wallpaper = (Wallpaper)wallpaper;
			ApplyBackgroundButtonInteractable((Wallpaper)wallpaper);
			SetApplyInteractable();
		}
	}

	public void PlaySfx(AudioClip clip, float volume = 0.3f, float pitch = 1f)
	{
		audioSource.pitch = pitch;
		audioSource.volume = volume;
		audioSource.PlayOneShot(clip);
	}

	public void ApplyBackground()
	{
		Wallpaper wallpaper = settingsChanges.wallpaper;
		PlaySfx(crtSfx[2], 0.25f, 0.9f + 0.05f * (float)wallpaper);
		backgroundManager.EnableWallpaper(wallpaper);
		PlayerPrefs.SetInt(PlayerPrefsManager.CURRENT_WALLPAPER, (int)wallpaper);
	}

	public void InitializeBackground()
	{
		backgroundManager.EnableWallpaper(PlayerPrefsManager.GetSavedWallpaper());
	}

	private void ApplyBackgroundButtonInteractable(Wallpaper wallpaper)
	{
		wallpaperDefault.interactable = wallpaper != Wallpaper.DEFAULT;
		wallpaperBliss.interactable = wallpaper != Wallpaper.BLISS;
		wallpaperImg100.interactable = wallpaper != Wallpaper.IMG100;
		wallpaperKoala.interactable = wallpaper != Wallpaper.KOALA;
	}

	public void NukeSaves()
	{
		UIUtils.CloseAllPanels(canvas);
		if (!currentSettings.isAssistantDisabled)
		{
			assistant.DespawnAssistants();
		}
		mouseClick.RemoveAllListeners();
		GameObject obj = CreateResettingPopup();
		Panel component = obj.GetComponent<Panel>();
		Transcript component2 = obj.GetComponent<Transcript>();
		sceneSwitcher.SwitchToStart(component, component2);
		iconController.IconMoveOut();
		clickDrag.ClearSelectedIcons();
		taskbarAnimator.Play("Hold Despawn Taskbar");
		DeleteSaves();
	}

	public static void DeleteSaves()
	{
		DatabaseUtils.DropAllTables();
		Save.EraseSave();
		LevelManager.SetLevel(0);
	}

	public GameObject CreateResettingPopup()
	{
		panelSfx.PlayOpen();
		GameObject obj = UnityEngine.Object.Instantiate(clearSaveFinalPopup, canvas.transform.position, Quaternion.identity, canvas.transform);
		PanelManager.OpenWindow(obj);
		return obj;
	}

	public int PopulateResolutions()
	{
		Resolution[] resolutions = Screen.resolutions;
		filteredResolutions = new List<Resolution>();
		resolutionDropdown.ClearOptions();
		float num = (float)Screen.currentResolution.refreshRateRatio.value;
		Resolution[] array = resolutions;
		for (int i = 0; i < array.Length; i++)
		{
			Resolution item = array[i];
			if ((float)item.refreshRateRatio.value == num && (item.width > MIN_RESOLUTION || item.height > MIN_RESOLUTION))
			{
				filteredResolutions.Add(item);
			}
		}
		filteredResolutions.Sort((Resolution a, Resolution b) => (a.width != b.width) ? b.width.CompareTo(a.width) : b.height.CompareTo(a.height));
		int num2 = 0;
		List<string> list = new List<string>();
		for (int num3 = 0; num3 < filteredResolutions.Count; num3++)
		{
			string item2 = filteredResolutions[num3].width + "x" + filteredResolutions[num3].height;
			list.Add(item2);
			if (filteredResolutions[num3].width == Screen.width && filteredResolutions[num3].height == Screen.height && (float)filteredResolutions[num3].refreshRateRatio.value == num)
			{
				num2 = num3;
			}
		}
		resolutionDropdown.AddOptions(list);
		resolutionDropdown.value = num2;
		return num2;
	}

	public float SetMasterVolumeSlider()
	{
		float? volume = PlayerPrefsManager.GetVolume(PlayerPrefsManager.MASTER_VOLUME);
		AudioListener.volume = (volume.HasValue ? volume.Value : DEFAULT_VOLUME);
		masterVol.value = AudioListener.volume;
		return AudioListener.volume;
	}

	public float SetSfxVolumeSlider()
	{
		float? volume = PlayerPrefsManager.GetVolume(PlayerPrefsManager.SFX_VOLUME);
		sfxVol.value = (volume.HasValue ? volume.Value : DEFAULT_VOLUME);
		return sfxVol.value;
	}

	public void SetResolution(int resolutionIndex)
	{
		if (settingsChanges != null)
		{
			settingsChanges.resolutionIndex = resolutionIndex;
			SetApplyInteractable();
		}
	}

	public void SetFullscreen()
	{
		if (settingsChanges != null)
		{
			settingsChanges.isFullscreen = fullscreen.isOn;
			if (!fullscreen.isOn && !windowed.isOn)
			{
				windowed.isOn = true;
				settingsChanges.isWindowed = true;
			}
			SetApplyInteractable();
		}
	}

	public void SetMasterVolume(float sliderValue)
	{
		if (settingsChanges != null)
		{
			settingsChanges.masterVolume = sliderValue;
			SetApplyInteractable();
		}
	}

	public void SetSfxVolume(float sliderValue)
	{
		if (settingsChanges != null)
		{
			settingsChanges.soundEffectVolume = sliderValue;
			SetApplyInteractable();
		}
	}

	public bool IsAssistantDisabled()
	{
		return PlayerPrefsManager.GetBool(PlayerPrefsManager.IS_ASSISTANT_DISABLED);
	}

	public void SetAssistant()
	{
		if (settingsChanges != null)
		{
			settingsChanges.isAssistantDisabled = assistantToggle.isOn;
			SetApplyInteractable();
		}
	}

	public void ApplyAssistantChanges()
	{
		PlayerPrefsManager.SetBool(PlayerPrefsManager.IS_ASSISTANT_DISABLED, settingsChanges.isAssistantDisabled);
		if (settingsChanges.isAssistantDisabled)
		{
			Debug.Log("ApplyAssistantChanges -> Despawn");
			assistant.DespawnAssistants();
			return;
		}
		Debug.Log("ApplyAssistantChanges -> Peek");
		runner.StartCoroutine(delegate
		{
			float remainingDelaySeconds = assistant.GetRemainingDelaySeconds();
			Debug.Log($"There are {remainingDelaySeconds} seconds remaining of no hints");
			return peeker.PeekRoutine(remainingDelaySeconds);
		});
	}

	public void SetCrtEnablement()
	{
		if (settingsChanges != null)
		{
			settingsChanges.crtSettings.crtEnabled = crt.GetCrtEnablement();
			SetApplyInteractable();
			crt.SetSubOptionsInteractable();
		}
	}

	public void SetChromaticAbberation()
	{
		if (settingsChanges != null)
		{
			settingsChanges.crtSettings.chromaticAbberationIndex = crt.GetChromaticAbberationIndex();
			SetApplyInteractable();
		}
	}

	public void SetScanLines()
	{
		if (settingsChanges != null)
		{
			settingsChanges.crtSettings.scanLineIndex = crt.GetScanLineIndex();
			SetApplyInteractable();
		}
	}

	public void ApplyMasterVolume()
	{
		PlayerPrefs.SetFloat(PlayerPrefsManager.MASTER_VOLUME, settingsChanges.masterVolume);
		AudioListener.volume = settingsChanges.masterVolume;
	}

	public void ApplySfxVolume()
	{
		float soundEffectVolume = settingsChanges.soundEffectVolume;
		PlayerPrefs.SetFloat(PlayerPrefsManager.SFX_VOLUME, soundEffectVolume);
		sfxMixer.SetFloat(SFX_VOLUME_MIXER_KEY, GetSfxVolume(soundEffectVolume));
	}

	public static float GetSfxVolume(float sliderValue)
	{
		if (sliderValue <= 0f)
		{
			return MIXER_MIN_VOLUME;
		}
		if (sliderValue >= 0.8f)
		{
			return sliderValue * 40f - 32f;
		}
		return sliderValue * 31.25f - 25f;
	}

	public IEnumerator ApplyExclusiveFullscreen(Resolution chosenRes)
	{
		yield return new WaitUntil(() => Screen.width == chosenRes.width && Screen.height == chosenRes.height);
		Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
	}

	public void SetDisplayToggles()
	{
		switch (Screen.fullScreenMode)
		{
		case FullScreenMode.ExclusiveFullScreen:
			fullscreen.isOn = true;
			windowed.isOn = false;
			break;
		case FullScreenMode.Windowed:
			fullscreen.isOn = false;
			windowed.isOn = true;
			break;
		case FullScreenMode.FullScreenWindow:
			fullscreen.isOn = true;
			windowed.isOn = true;
			break;
		case FullScreenMode.MaximizedWindow:
			break;
		}
	}

	public void ApplyScreenChange()
	{
		if (fullscreen.isOn && !windowed.isOn)
		{
			Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
		}
		else if (fullscreen.isOn && windowed.isOn)
		{
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		}
		else
		{
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
	}

	public void SetWindowed()
	{
		if (settingsChanges != null)
		{
			settingsChanges.isWindowed = windowed.isOn;
			if (!fullscreen.isOn && !windowed.isOn)
			{
				fullscreen.isOn = true;
				settingsChanges.isFullscreen = true;
			}
			SetApplyInteractable();
		}
	}

	public IEnumerator ApplyResolution(Resolution resolution)
	{
		yield return new WaitForSeconds(0.5f);
		Screen.SetResolution(resolution.width, resolution.height, fullscreen.isOn);
		iconGrid.SetIconLocations(useSavedLocation: false);
		StartCoroutine(SetIcons(resolution));
	}

	protected IEnumerator SetIcons(Resolution res)
	{
		yield return new WaitUntil(() => iconGrid.IsAspectRatioUpdated(res));
		yield return new WaitForSeconds(0.2f);
		iconGrid.SetIconLocations(useSavedLocation: false);
		backgroundManager.ResizeWallpaper();
	}

	public void ApplySettingsChanges()
	{
		if (currentSettings.isAssistantDisabled != settingsChanges.isAssistantDisabled)
		{
			ApplyAssistantChanges();
		}
		if (currentSettings.wallpaper != settingsChanges.wallpaper)
		{
			ApplyBackground();
		}
		if (currentSettings.masterVolume != settingsChanges.masterVolume)
		{
			ApplyMasterVolume();
		}
		if (currentSettings.soundEffectVolume != settingsChanges.soundEffectVolume)
		{
			ApplySfxVolume();
		}
		if (!currentSettings.crtSettings.Equals(settingsChanges.crtSettings))
		{
			crt.SaveSettings();
			bool flag = crt.SetCrtEnablement();
			if (flag)
			{
				StartCoroutine(crt.LoadChromaticAbberation());
				StartCoroutine(crt.LoadScanLines());
			}
			PlaySfx(crtSfx[(!flag) ? 1u : 0u]);
		}
		if (currentSettings.resolutionIndex != settingsChanges.resolutionIndex)
		{
			if (Screen.fullScreenMode == FullScreenMode.ExclusiveFullScreen)
			{
				Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
			}
			Resolution resolution = filteredResolutions[settingsChanges.resolutionIndex];
			StartCoroutine(ApplyResolution(resolution));
			if (fullscreen.isOn && !windowed.isOn)
			{
				StartCoroutine(ApplyExclusiveFullscreen(resolution));
			}
		}
		else if (currentSettings.isFullscreen != settingsChanges.isFullscreen || currentSettings.isWindowed != settingsChanges.isWindowed)
		{
			ApplyScreenChange();
		}
		currentSettings.SetFields(settingsChanges);
		Debug.Log($"Setting currentSettings to {currentSettings.isAssistantDisabled}");
		applySettingsButton.interactable = false;
	}

	public void SetApplyInteractable()
	{
		applySettingsButton.interactable = currentSettings != null && !currentSettings.Equals(settingsChanges);
	}
}
