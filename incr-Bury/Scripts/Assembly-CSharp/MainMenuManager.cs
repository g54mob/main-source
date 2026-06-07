using System;
using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using VolFx;

public class MainMenuManager : MonoBehaviour
{
	public enum MainMenuState
	{
		Main = 0,
		Options = 1,
		Credits = 2,
		SavedGameSlots = 3,
		NgMods = 4,
		LanguageSelector = 5
	}

	public static MainMenuManager Singleton;

	[SerializeField]
	private VolumeProfile postVolumeProfile;

	public MainMenuState mainMenuState;

	[Header("Navigation")]
	public GameObject defaultSelectedUI;

	public GameObject defaultSelectedUI_CreditsScreen;

	public GameObject defaultSelectedUI_SaveSlots;

	public GameObject defaultSelectedUI_NGMods;

	public GameObject defaultSelectedUI_LanguageSelector;

	public GameObject mainMenuCanvas;

	[Header("UI Groups")]
	public GameObject uiGroup_Main;

	public GameObject uiGroup_Credits;

	public GameObject uiGroup_SaveSlots;

	public GameObject uiGroup_NgMods;

	public GameObject uiGroup_LanguageSelector;

	[Header("Buttons")]
	[SerializeField]
	private GameObject button_Play;

	[Header("Title Variant")]
	[SerializeField]
	private GameObject title_Default;

	[SerializeField]
	private GameObject title_BarryVariant;

	[SerializeField]
	private GameObject poisonWater;

	[SerializeField]
	private GameObject gnomeEnding_VariantGroup;

	[SerializeField]
	private GameObject pigEnding_VariantGroup;

	[Header("Save Slots")]
	[SerializeField]
	private List<SaveSlotUI> saveSlotButtons;

	public bool ngPlus_Unlocked;

	[Header("NG Mods")]
	[SerializeField]
	private List<NGPlusMod_CheckBox> modsCheckBoxs;

	[SerializeField]
	private GameObject ngPlusUnlockedDisplayText;

	private bool mods_ToggleAllState;

	private int cheevoReset_Presses;

	private float cheevoReset_Timer = 3f;

	public int savedLanguageIndex;

	private bool firstTimeLoading_LanguageSelectorCheck;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private IEnumerator WaitForLocalizationInitializationThenForceEnglishForNow()
	{
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
		Debug.Log("Language Set to English");
	}

	private void Start()
	{
		Time.timeScale = 1f;
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Combine(singleton.ControllerTypeChanged, new Action(ControllerChanged));
		MainMenuCanvas_Show();
		LoadSavedLanguageSetting();
		if (CheckIfFirstLaunch_ShouldShowLanguageSelector())
		{
			ShowUIGroup(MainMenuState.LanguageSelector);
		}
		else
		{
			ShowUIGroup(MainMenuState.Main);
		}
		AudioManager.Singleton.PlayAmbientTrack(0, 0f, _fadeIn: false);
		if (MenuToGameBridger.Singleton.comingBackToMainMenuFromTrueEnding)
		{
			title_Default.SetActive(value: false);
			title_BarryVariant.SetActive(value: true);
		}
		else
		{
			title_Default.SetActive(value: true);
			title_BarryVariant.SetActive(value: false);
		}
		MenuToGameBridger.Singleton.comingBackToMainMenuFromBelladonnaEnding = false;
		MenuToGameBridger.Singleton.comingBackToMainMenuFromTrueEnding = false;
		MenuToGameBridger.Singleton.comingBackToMainMenuFromGnomeEnding = false;
		MenuToGameBridger.Singleton.comingBackToMainMenuFromPigEnding = false;
		MenuToGameBridger.Singleton.enteredCreditsFromMainMenu = false;
		SaveLoadManager.LoadGlobalSaveData();
	}

	public void OnDestroy()
	{
		InputManager singleton = InputManager.Singleton;
		singleton.ControllerTypeChanged = (Action)Delegate.Remove(singleton.ControllerTypeChanged, new Action(ControllerChanged));
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		HandleDebugCheevoResetting();
	}

	private void HandleDebugCheevoResetting()
	{
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			cheevoReset_Presses++;
			cheevoReset_Timer = 3f;
			if (cheevoReset_Presses >= 10)
			{
				cheevoReset_Timer = 0f;
				cheevoReset_Presses = 0;
				AchievementHelper.ResetAllAchievements();
				Debug.Log("RESET ALL ACHIEVEMENTS!");
				AudioManager.Singleton.PlaySFX_PopGun_Fire(new Vector3(-6.4f, 3.5f, 26f));
			}
		}
		if (cheevoReset_Timer > 0f)
		{
			cheevoReset_Timer -= Time.deltaTime;
			return;
		}
		cheevoReset_Timer = 0f;
		cheevoReset_Presses = 0;
	}

	public void SelectDefaultUiElement(GameObject _element)
	{
		EventSystem.current.SetSelectedGameObject(_element);
	}

	public void LoadGameScene()
	{
		MenuToGameBridger.Singleton.comingBackToMainMenuFromTrueEnding = false;
		SceneManager.LoadScene("Game");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public string GetSteamDisplayNameText()
	{
		return SteamClient.Name;
	}

	public void HideAllUIGroups()
	{
		uiGroup_Main.SetActive(value: false);
		uiGroup_Credits.SetActive(value: false);
		uiGroup_SaveSlots.SetActive(value: false);
		uiGroup_NgMods.SetActive(value: false);
		uiGroup_LanguageSelector.SetActive(value: false);
	}

	public void ShowVhsEffect()
	{
		if (postVolumeProfile.TryGet<VhsVol>(out var component))
		{
			component._weight.value = 1f;
		}
	}

	public void HideVhsEffect()
	{
		if (postVolumeProfile.TryGet<VhsVol>(out var component))
		{
			component._weight.value = 0f;
		}
	}

	public void MainMenuCanvas_Show()
	{
		mainMenuState = MainMenuState.Main;
		mainMenuCanvas.SetActive(value: true);
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			HighlightDefaultButton_WithController();
		}
	}

	private void HighlightDefaultButton_WithController()
	{
		SelectDefaultUiElement(defaultSelectedUI);
	}

	public void MainMenuCanvas_Hide()
	{
		mainMenuCanvas.SetActive(value: false);
	}

	public void OpenOptionsMenu()
	{
		mainMenuState = MainMenuState.Options;
		OptionsManager.Singleton.OptionsMenuCanvas_Show();
		MainMenuCanvas_Hide();
	}

	public void QuitGame_Button()
	{
		Application.Quit();
	}

	public void Discord_Button()
	{
		Application.OpenURL("https://www.discord.gg/wormtown");
	}

	public void Credits_Button_Open()
	{
		ShowUIGroup(MainMenuState.Credits);
	}

	public void Credits_Button_Close()
	{
		ShowUIGroup(MainMenuState.Main);
	}

	public void SaveFilesMenu_Open()
	{
		ShowUIGroup(MainMenuState.SavedGameSlots);
		ngPlusUnlockedDisplayText.SetActive(ngPlus_Unlocked);
	}

	public void SaveFilesMenu_Close()
	{
		ShowUIGroup(MainMenuState.Main);
	}

	public void NGPlusModsMenu_Open()
	{
		ShowUIGroup(MainMenuState.NgMods);
	}

	public void ShowUIGroup(MainMenuState _state)
	{
		HideAllUIGroups();
		switch (_state)
		{
		case MainMenuState.Main:
			uiGroup_Main.SetActive(value: true);
			if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
			{
				HighlightDefaultButton_WithController();
			}
			break;
		case MainMenuState.Credits:
			uiGroup_Credits.SetActive(value: true);
			if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
			{
				EventSystem.current.SetSelectedGameObject(defaultSelectedUI_CreditsScreen);
			}
			break;
		case MainMenuState.SavedGameSlots:
			uiGroup_SaveSlots.SetActive(value: true);
			UpdateAllSaveSlotUIButtons();
			if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
			{
				EventSystem.current.SetSelectedGameObject(defaultSelectedUI_SaveSlots);
			}
			break;
		case MainMenuState.NgMods:
			uiGroup_NgMods.SetActive(value: true);
			MenuToGameBridger.Singleton.ResetNgPlusMods();
			foreach (NGPlusMod_CheckBox modsCheckBox in modsCheckBoxs)
			{
				modsCheckBox.UncheckBox();
			}
			if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
			{
				EventSystem.current.SetSelectedGameObject(defaultSelectedUI_NGMods);
			}
			break;
		case MainMenuState.LanguageSelector:
			uiGroup_LanguageSelector.SetActive(value: true);
			if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
			{
				SelectDefaultUiElement(defaultSelectedUI_LanguageSelector);
			}
			break;
		}
		mainMenuState = _state;
	}

	public void StorePage_Button()
	{
		Application.OpenURL("https://store.steampowered.com/app/3370870/Berry_Bury_Berry/");
	}

	private void ControllerChanged()
	{
		if (InputManager.Singleton.lastUsedControllerType != InputManager.ControllerType.controller)
		{
			return;
		}
		if (mainMenuState == MainMenuState.Main)
		{
			SelectDefaultUiElement(defaultSelectedUI);
			StartCoroutine(WaitAFrameThenSelectMainMenuUI());
		}
		else if (mainMenuState != MainMenuState.Options)
		{
			if (mainMenuState == MainMenuState.Credits)
			{
				SelectDefaultUiElement(defaultSelectedUI_CreditsScreen);
			}
			else if (mainMenuState == MainMenuState.SavedGameSlots)
			{
				SelectDefaultUiElement(defaultSelectedUI_SaveSlots);
			}
			else if (mainMenuState == MainMenuState.LanguageSelector)
			{
				SelectDefaultUiElement(defaultSelectedUI_LanguageSelector);
				StartCoroutine(WaitAFrameThenSelectDefaultEnglishButton());
			}
		}
	}

	private IEnumerator WaitAFrameThenSelectMainMenuUI()
	{
		yield return null;
		SelectDefaultUiElement(defaultSelectedUI);
	}

	private IEnumerator WaitAFrameThenSelectDefaultEnglishButton()
	{
		yield return null;
		SelectDefaultUiElement(defaultSelectedUI_LanguageSelector);
	}

	public void UpdateAllSaveSlotUIButtons()
	{
		foreach (SaveSlotUI saveSlotButton in saveSlotButtons)
		{
			saveSlotButton.UpdateSlotUI();
		}
	}

	public void SetSaveSlotWereUsing(int _slot)
	{
		MenuToGameBridger.Singleton.activeSaveGameSlot = _slot;
		saveSlotButtons[_slot].OnClicked_AreWeLoadingDataOrIsThisNewGame();
		if (MenuToGameBridger.Singleton.loadDataOnNextGameSceneLoad)
		{
			MenuToGameBridger.Singleton.SetNGPlusModsFromData(saveSlotButtons[_slot]);
			LoadGameScene();
		}
		else if (ngPlus_Unlocked)
		{
			ShowUIGroup(MainMenuState.NgMods);
		}
		else
		{
			MenuToGameBridger.Singleton.ResetNgPlusMods();
			LoadGameScene();
		}
	}

	public void LoadGameScene_FromNGPlusModsMenu()
	{
		MenuToGameBridger.Singleton.ResetNgPlusMods();
		foreach (NGPlusMod_CheckBox modsCheckBox in modsCheckBoxs)
		{
			if (modsCheckBox.isChecked)
			{
				switch (modsCheckBox.modType)
				{
				case NgPlusModType.GrowthBoost:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_GrowthBoost = modsCheckBox.isChecked;
					break;
				case NgPlusModType.InfiniteHoleMove:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteHoleMove = modsCheckBox.isChecked;
					break;
				case NgPlusModType.InfiniteDayTime:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_InfiniteDaytime = modsCheckBox.isChecked;
					break;
				case NgPlusModType.FastAbilities:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FastAbilityCooldowns = modsCheckBox.isChecked;
					break;
				case NgPlusModType.NoWalls:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_NoWalls = modsCheckBox.isChecked;
					break;
				case NgPlusModType.UnlockStarPopper:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartStarPopper = modsCheckBox.isChecked;
					break;
				case NgPlusModType.UnlockedAutoCoinPickUp:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartAutoCoinPickUp = modsCheckBox.isChecked;
					break;
				case NgPlusModType.UnlockAbilities:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartAbilities = modsCheckBox.isChecked;
					break;
				case NgPlusModType.UnlockTrampoline:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartTrampoline = modsCheckBox.isChecked;
					break;
				case NgPlusModType.UnlockHammerAndChainsaw:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_FromStartHammerAndChainsaw = modsCheckBox.isChecked;
					break;
				case NgPlusModType.SkipCutscenes:
					MenuToGameBridger.Singleton.activeSaveGame_NGPlusModifiers.ngMod_CutSceneSkip = modsCheckBox.isChecked;
					break;
				}
			}
		}
		LoadGameScene();
	}

	public void LoadCreditsScene_ViaMainMenuButton()
	{
		MenuToGameBridger.Singleton.enteredCreditsFromMainMenu = true;
		MenuToGameBridger.Singleton.endingCompletedString = "";
		SceneManager.LoadScene("Credits");
	}

	public void ToggleAllMods()
	{
		mods_ToggleAllState = !mods_ToggleAllState;
		foreach (NGPlusMod_CheckBox modsCheckBox in modsCheckBoxs)
		{
			if (mods_ToggleAllState)
			{
				modsCheckBox.CheckBox();
			}
			else
			{
				modsCheckBox.UncheckBox();
			}
		}
	}

	public void ChangeLanguageButton(int _index)
	{
		SetLanguageByIndex(_index);
		OptionsManager.Singleton.SetLocalizedPuzzles(_index != 0);
		PlayerPrefs.SetInt("FirstLaunchLanguage", 1);
		ShowUIGroup(MainMenuState.Main);
	}

	public void OpenLanguageSelector()
	{
		ShowUIGroup(MainMenuState.LanguageSelector);
	}

	public void SetLanguageByIndex(int _index)
	{
		StartCoroutine(WaitForLocalizationInitializationThenSetLanguage(_index));
	}

	private IEnumerator WaitForLocalizationInitializationThenSetLanguage(int _index)
	{
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_index];
		PlayerPrefs.SetInt("Language", _index);
		Debug.Log("Changed Language");
	}

	private void LoadSavedLanguageSetting()
	{
		savedLanguageIndex = PlayerPrefs.GetInt("Language", 0);
		SetLanguageByIndex(savedLanguageIndex);
	}

	private bool CheckIfFirstLaunch_ShouldShowLanguageSelector()
	{
		return PlayerPrefs.GetInt("FirstLaunchLanguage", 0) == 0;
	}
}
