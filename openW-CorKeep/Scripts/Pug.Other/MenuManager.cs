using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using QFSW.QC;
using Rewired;
using Rewired.Data;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MenuManager : ManagerBase
{
	public const float OBFUSCATION_FADE_TIME = 2f;

	public const SfxID SELECT_CHANGE_SFX = SfxID.FIXME_menu_select;

	public const SfxID BACK_SFX = SfxID.FIXME_menu_select;

	public const SfxID ACTIVATE_SFX = SfxID.FIXME_menu_select;

	private TimerSimple sfxCooldownTimer = new TimerSimple(0.05f, unscaled: true);

	private bool preventPausing;

	private bool allowedToEnableMenu = true;

	public bool isStartingGame;

	private (bool success, string text)? _softwareKeyboardInput;

	private bool _showTitleMenuPopups = true;

	[Header("Prefabs:")]
	public GameObject pauseMenuPrefab;

	public GameObject optionsMenuPrefab;

	public GameObject videoOptionsMenuPrefab;

	public GameObject graphicsOptionsMenuPrefab;

	public GameObject audioOptionsMenuPrefab;

	public GameObject uiOptionsMenuPrefab;

	public GameObject performanceOptionsMenuPrefab;

	public GameObject gameplayOptionsMenuPrefab;

	public PopUpText centerPopUpText;

	public GameObject galleryMenuPrefab;

	public GameObject joinGameMenuPrefab;

	public GameObject bilibiliConnectMenuPrefab;

	public GameObject characterCustomizationMenuPrefab;

	public GameObject characterMagicMirrorMenuPrefab;

	public GameObject characterTypeSelectionMenuPrefab;

	public GameObject characterChooserMenuPrefab;

	public GameObject selectWorldMenuPrefab;

	public GameObject createWorldMenuPrefab;

	public GameObject worldSettingsMenuPrefab;

	public GameObject creditsMenuPrefab;

	public GameObject banListMenuPrefab;

	[Tooltip("Only relevant for PS4 as it doesn't have a system menu for invites.")]
	public GameObject inviteFriendsMenuPrefab;

	public GameObject selectSessionMenuPrefab;

	public GameObject eulaMenuPrefab;

	public GameObject loadWorldFromModMenuPrefab;

	public GameObject developerMenuPrefab;

	public GameObject controlMappingMenuPrefab;

	public RadicalMenu popUpMenu;

	public AssetReferenceGameObject quantumConsolePrefab;

	private readonly Stack<RadicalMenu> menuStack = new Stack<RadicalMenu>(4);

	private readonly Stack<int> intStack = new Stack<int>();

	private bool _anyMenuWasActiveThisUpdate;

	private TimerSimple recentMenuClosedTimer = new TimerSimple(0.2f);

	public MenuHelperButtons menuHelperButtons;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("MenuManager.Init");

	public List<MenuHelperButtons.HelpButtonTypes> defaultHelpButtons = new List<MenuHelperButtons.HelpButtonTypes>
	{
		MenuHelperButtons.HelpButtonTypes.NAVIGATE,
		MenuHelperButtons.HelpButtonTypes.SELECT,
		MenuHelperButtons.HelpButtonTypes.BACK
	};

	private bool typingActionWasClicked;

	private bool isShowingControllerTextInput;

	private float lastControllerTextTime;

	private TimerSimple typingInputCooldown = new TimerSimple(0.3f, unscaled: true);

	private float time => Time.unscaledTime;

	public RadicalMenu pauseMenu { get; private set; }

	public RadicalMenu optionsMenu { get; private set; }

	public RadicalMenu videoOptionsMenu { get; private set; }

	public RadicalMenu graphicsOptionsMenu { get; private set; }

	public RadicalMenu audioOptionsMenu { get; private set; }

	public RadicalMenu uiOptionsMenu { get; private set; }

	public RadicalMenu performanceOptionsMenu { get; private set; }

	public RadicalMenu gameplayOptionsMenu { get; private set; }

	public RadicalMenu galleryMenu { get; private set; }

	public RadicalMenu joinGameMenu { get; private set; }

	public RadicalMenu bilibiliConnectMenu { get; private set; }

	public RadicalMenu characterCustomizationMenu { get; private set; }

	public RadicalMenu characterMagicMirrorMenu { get; private set; }

	public RadicalMenu characterTypeSelectionMenu { get; private set; }

	public ChooseCharacterMenu characterChooserMenu { get; private set; }

	public RadicalMenu selectWorldMenu { get; private set; }

	public RadicalMenu createWorldMenu { get; private set; }

	public RadicalMenu worldSettingsMenu { get; private set; }

	public RadicalMenu creditsMenu { get; private set; }

	public RadicalMenu banListMenu { get; private set; }

	public RadicalMenu inviteFriendsMenu { get; private set; }

	public RadicalMenu selectSessionMenu { get; private set; }

	public RadicalMenu eulaMenu { get; private set; }

	public RadicalMenu loadWorldFromModMenu { get; private set; }

	public RadicalMenu developerMenu { get; private set; }

	public RadicalMenu controlMappingMenu { get; private set; }

	public QuantumConsole quantumConsole { get; private set; }

	public int menuStackCount => menuStack.Count;

	public bool isConsoleActive { get; private set; }

	public bool anyMenuWasActiveDuringThisUpdate
	{
		get
		{
			if (!_anyMenuWasActiveThisUpdate)
			{
				return IsAnyMenuActive();
			}
			return true;
		}
		private set
		{
			_anyMenuWasActiveThisUpdate = value;
		}
	}

	public bool anyMenuWasRecentlyClosed
	{
		get
		{
			if (recentMenuClosedTimer.isRunning)
			{
				return !recentMenuClosedTimer.isTimerElapsed;
			}
			return false;
		}
	}

	public void AttemptToPlayMenuSfx(SfxID sfx, float pitch = 1f, float pitchDev = 0f, bool reuse = true)
	{
		if (!sfxCooldownTimer.isRunning || sfxCooldownTimer.isTimerElapsed)
		{
			AudioManager.SfxUI(sfx, pitch, reuse, 1f, pitchDev, playOnGamepad: true);
			sfxCooldownTimer.Start();
		}
	}

	public void DisableAllowingToEnableMenu()
	{
		allowedToEnableMenu = false;
	}

	public void EnableAllowingToEnableMenu()
	{
		allowedToEnableMenu = true;
	}

	public RadicalMenu GetTopMenu()
	{
		if (menuStack.Count <= 0)
		{
			return null;
		}
		return menuStack.Peek();
	}

	public bool IsAnyMenuActive()
	{
		if (menuStack.Count <= 0)
		{
			return isConsoleActive;
		}
		return true;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			if (Manager.enableConsole)
			{
				AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.InstantiateAsync(quantumConsolePrefab, base.transform);
				asyncOperationHandle.Completed += delegate(AsyncOperationHandle<GameObject> handle)
				{
					quantumConsole = handle.Result.GetComponent<QuantumConsole>();
				};
			}
			_ = Manager.camera.uiCamera;
			pauseMenu = InstantiateMenu<RadicalMenu>(pauseMenuPrefab);
			optionsMenu = InstantiateMenu<RadicalMenu>(optionsMenuPrefab);
			videoOptionsMenu = InstantiateMenu<RadicalMenu>(videoOptionsMenuPrefab);
			graphicsOptionsMenu = InstantiateMenu<RadicalMenu>(graphicsOptionsMenuPrefab);
			uiOptionsMenu = InstantiateMenu<RadicalMenu>(uiOptionsMenuPrefab);
			performanceOptionsMenu = InstantiateMenu<RadicalMenu>(performanceOptionsMenuPrefab);
			gameplayOptionsMenu = InstantiateMenu<RadicalMenu>(gameplayOptionsMenuPrefab);
			galleryMenu = InstantiateMenu<RadicalGalleryMenu>(galleryMenuPrefab);
			joinGameMenu = InstantiateMenu<RadicalJoinGameMenu>(joinGameMenuPrefab);
			bilibiliConnectMenu = InstantiateMenu<RadicalMenu>(bilibiliConnectMenuPrefab);
			characterCustomizationMenu = InstantiateMenu<CharacterCustomizationMenu>(characterCustomizationMenuPrefab);
			characterMagicMirrorMenu = InstantiateMenu<CharacterCustomizationMenu>(characterMagicMirrorMenuPrefab);
			characterTypeSelectionMenu = InstantiateMenu<CharacterTypeSelectionMenu>(characterTypeSelectionMenuPrefab);
			characterChooserMenu = InstantiateMenu<ChooseCharacterMenu>(characterChooserMenuPrefab);
			selectWorldMenu = InstantiateMenu<SelectWorldMenu>(selectWorldMenuPrefab);
			createWorldMenu = InstantiateMenu<WorldSettingsMenu>(createWorldMenuPrefab);
			worldSettingsMenu = InstantiateMenu<WorldSettingsMenu>(worldSettingsMenuPrefab);
			audioOptionsMenu = InstantiateMenu<RadicalMenu>(audioOptionsMenuPrefab);
			creditsMenu = InstantiateMenu<RadicalMenu>(creditsMenuPrefab);
			banListMenu = InstantiateMenu<RadicalMenu>(banListMenuPrefab);
			loadWorldFromModMenu = InstantiateMenu<RadicalMenu>(loadWorldFromModMenuPrefab);
			controlMappingMenu = InstantiateMenu<RadicalMenu>(controlMappingMenuPrefab);
			return true;
		}
	}

	private T InstantiateMenu<T>(GameObject prefab) where T : MonoBehaviour
	{
		T component = Object.Instantiate(prefab, Manager.camera.uiCamera.transform).GetComponent<T>();
		component.gameObject.SetActive(value: false);
		return component;
	}

	private void PlatformOverlayStateChanged(bool changed)
	{
		if (GetTopMenu() == null && changed && !IsPauseDisabled())
		{
			PushMenu(RadicalMenu.MenuType.PAUSE);
		}
	}

	private void ApplicationFocusChanged(ApplicationFocusChange focusChange)
	{
		Debug.Log("Application focus changed: " + focusChange);
		if ((focusChange == ApplicationFocusChange.Suspended || focusChange == ApplicationFocusChange.Constrained) && GetTopMenu() == null && !IsPauseDisabled())
		{
			PushMenu(RadicalMenu.MenuType.PAUSE);
		}
	}

	public void OnSceneUnload()
	{
		centerPopUpText.FadeOutCurrentDisplaySequence(1f);
		PopAllMenus();
	}

	public void OnTitleMenuOpened()
	{
		if (_showTitleMenuPopups)
		{
			_showTitleMenuPopups = false;
			ShowTitleMenuPopup();
		}
	}

	private void ShowTitleMenuPopup()
	{
		if (CommandLineArgs.Has("-showforcedsafemodeinfo"))
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ForcedSafeMode", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
			}, new List<string> { "ok" }, 10f, 0.8f, 0, 20f);
		}
		else if (Manager.prefs.ShowExplorersEditionPopup && Manager.platform.HasDlc(Dlc.ExplorersEdition))
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ExplorersEditionInfoViaStoreDesc", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse confirm)
			{
				if (confirm.IsConfirm)
				{
					Manager.prefs.ShowExplorersEditionPopup = false;
				}
			}, new List<string> { "ok", "Menu/DontShowAgain" }, 10f, 0.8f, 0, 20f);
		}
		else if (UIManager.ShowOutdatedVersionPopUp && Manager.prefs.ShowOutdatedVersionPopUp)
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/CurrentVersionIsOutdated", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
			{
				UIManager.ShowOutdatedVersionPopUp = false;
				if (response.IsConfirm)
				{
					Manager.prefs.ShowOutdatedVersionPopUp = false;
				}
			}, new List<string> { "confirm", "Menu/DontShowAgain" }, 2f, 0.8f, 0, 25f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: true);
		}
		else if (UIManager.ShowInputMappingResetPopup && Manager.prefs.ShowInputMappingResetPopup && UserDataStore_PlayerPrefs.InputBehaviourPlayerPrefsKeyExists("CoreKeeperControls"))
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("ControlMapper/ResetNotification", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
				UIManager.ShowInputMappingResetPopup = false;
				Manager.prefs.ShowInputMappingResetPopup = false;
				Manager.prefs.Write();
			}, new List<string> { "confirm" }, 2f, 0.8f, 0, 25f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: true);
		}
	}

	public void PreventPausing(bool prevent)
	{
		preventPausing = prevent;
	}

	private void UpdateHelperButtons()
	{
		bool flag = menuStack.Count > 0 || (!Manager.load.IsSceneTransitionOrLoading() && Manager.sceneHandler.helpButtonsToShow.Count > 0);
		menuHelperButtons.gameObject.SetActive(flag);
		if (!flag)
		{
			return;
		}
		MenuHelperButtons.SelectButtonVariation selectButtonVariation = MenuHelperButtons.SelectButtonVariation.SELECT;
		if (menuStack.Count > 0)
		{
			RadicalMenu topMenu = GetTopMenu();
			RadicalMenuOption selectedMenuOption = topMenu.GetSelectedMenuOption();
			List<MenuHelperButtons.HelpButtonTypes> buttonsToShow = (topMenu.UseCustomHelpButtons ? topMenu.GetHelpButtonsToShow() : defaultHelpButtons);
			if (selectedMenuOption != null)
			{
				if (selectedMenuOption.isOnOffToggle)
				{
					selectButtonVariation = ((!selectedMenuOption.IsOn()) ? MenuHelperButtons.SelectButtonVariation.ACTIVATE : MenuHelperButtons.SelectButtonVariation.DEACTIVATE);
				}
				buttonsToShow = topMenu.GetHelpButtonsToShow();
			}
			menuHelperButtons.UpdateShowingButtons(buttonsToShow, selectButtonVariation);
		}
		else
		{
			menuHelperButtons.UpdateShowingButtons(Manager.sceneHandler.helpButtonsToShow, selectButtonVariation);
		}
	}

	private void LateUpdate()
	{
		UpdateHelperButtons();
		anyMenuWasActiveDuringThisUpdate = IsAnyMenuActive();
		if (Manager.enableConsole)
		{
			isConsoleActive = quantumConsole != null && quantumConsole.IsActive;
		}
	}

	public void DisableDefaultMapCategory()
	{
		if (!Manager.sceneHandler.isInGame)
		{
			return;
		}
		foreach (Player allPlayer in ReInput.players.AllPlayers)
		{
			Manager.input.DisableControlMap("Default", allPlayer);
			Manager.input.EnableAllControlMapsWithTag(enable: false, "gameplay", allPlayer);
		}
	}

	public void EnableDefaultMapCategory()
	{
		if (Manager.sceneHandler.isInGame)
		{
			StartCoroutine(EnableDefaultMapCategoryCoroutine());
		}
	}

	private IEnumerator EnableDefaultMapCategoryCoroutine()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		if (menuStack.Count != 0)
		{
			yield break;
		}
		foreach (Player allPlayer in ReInput.players.AllPlayers)
		{
			Manager.input.EnableControlMap("Default", disableOtherMaps: false, disableDefaultMap: false, allPlayer);
			Manager.input.EnableAllControlMapsWithTag(enable: true, "gameplay", allPlayer);
		}
	}

	public void Update()
	{
		if (_softwareKeyboardInput.HasValue)
		{
			bool item = _softwareKeyboardInput.Value.success;
			string item2 = _softwareKeyboardInput.Value.text;
			TrySetInputText(item, item2);
			_softwareKeyboardInput = null;
		}
		if (Manager.input.IsToggleConsoleButtonDown() && quantumConsole != null && Manager.enableConsole && (Manager.DEBUG_MODE || Manager.input.SystemPrefersKeyboardAndMouse()))
		{
			quantumConsole.Toggle();
			Manager.prefs.HasOpenedConsoleCommands = true;
		}
		if (isConsoleActive)
		{
			return;
		}
		isConsoleActive = quantumConsole != null && quantumConsole.IsActive;
		anyMenuWasActiveDuringThisUpdate = IsAnyMenuActive();
		if (Manager.input.activeInputField != null && !Manager.input.inputFieldWasSetThisFrame && HandleTypingInput())
		{
			return;
		}
		ResetIMECompositionMode();
		if (!allowedToEnableMenu)
		{
			return;
		}
		if (GetTopMenu() != null)
		{
			if (UpdateInputAndApplyToCurrentMenu())
			{
				Manager.input.DisableInput(0.005f);
			}
		}
		else if (!IsPauseDisabled() && Manager.input.IsMenuStartButtonDown())
		{
			PushMenu(RadicalMenu.MenuType.PAUSE);
			GetTopMenu().SelectOptionIndex(0);
		}
	}

	private static void ActivateIME()
	{
		if (Input.imeCompositionMode != IMECompositionMode.On)
		{
			Input.imeCompositionMode = IMECompositionMode.On;
			Input.compositionCursorPos = new Vector2(40f, Screen.height - 220);
		}
	}

	private static void ResetIMECompositionMode()
	{
		if (Input.imeCompositionMode != IMECompositionMode.Off)
		{
			Input.imeCompositionMode = IMECompositionMode.Off;
		}
	}

	private bool IsPauseDisabled()
	{
		if (!preventPausing && (bool)Manager.sceneHandler && !Manager.sceneHandler.isTitle && !Manager.sceneHandler.isIntro && !Manager.sceneHandler.isOutro && !Manager.sceneHandler.isGameStartUpLoading && Manager.sceneHandler.isSceneHandlerReady && !Manager.ui.isShowingMap && !Manager.ui.isAnyInventoryShowing && !Manager.ui.inventoryWasActiveThisFrame && !Manager.ui.mapWasActiveThisFrame)
		{
			if (Manager.main.player != null)
			{
				return Manager.main.player.instrumentHandler.IsPlayingInstrument;
			}
			return false;
		}
		return true;
	}

	private bool HandleTypingInput()
	{
		if (!Manager.input.SystemPrefersKeyboardAndMouse())
		{
			if (isShowingControllerTextInput || Time.unscaledTime - lastControllerTextTime < 1f)
			{
				return true;
			}
			string hintString = Manager.input.activeInputField.GetHintString();
			if (Manager.platform.platformImpl.GetControllerTextInput(hintString, Manager.input.activeInputField.MaxCharactersForOnScreenKeyboard, Manager.input.activeInputField.GetInputText(), delegate(bool success, string input)
			{
				TrySetInputText(success, input);
			}, Manager.input.activeInputField.IsHidden()))
			{
				isShowingControllerTextInput = true;
				return true;
			}
		}
		ActivateIME();
		typingActionWasClicked = false;
		if (IsKeyDown(KeyCode.Backspace))
		{
			Manager.input.activeInputField.RemoveCharBehindMarker();
		}
		else if (IsKeyDown(KeyCode.Delete))
		{
			Manager.input.activeInputField.RemoveCharAtMarker();
		}
		else if (Manager.input.IsMenuBackButtonDown() || IsKeyDown(KeyCode.Return, checkOnlyOnPressedDown: true) || IsKeyDown(KeyCode.KeypadEnter, checkOnlyOnPressedDown: true))
		{
			if (Input.imeIsSelected)
			{
				if (!Manager.input.IsMenuBackButtonDown())
				{
					Manager.input.activeInputField.Deactivate(commit: true);
					if (Manager.input.SystemPrefersKeyboardAndMouse())
					{
						return false;
					}
				}
			}
			else
			{
				bool wasAutoActivated = Manager.input.activeInputField.WasAutoActivated;
				Manager.input.activeInputField.Deactivate(!Manager.input.IsMenuBackButtonDown());
				if (wasAutoActivated && Manager.input.SystemPrefersKeyboardAndMouse())
				{
					return false;
				}
			}
		}
		else if (IsKeyDown(KeyCode.LeftArrow))
		{
			Manager.input.activeInputField.MoveCharMarker(-1);
		}
		else if (IsKeyDown(KeyCode.RightArrow))
		{
			Manager.input.activeInputField.MoveCharMarker(1);
		}
		else if (!typingActionWasClicked && Manager.input.IsPasteButtonDown())
		{
			Manager.input.activeInputField.AppendString(GUIUtility.systemCopyBuffer);
		}
		else if (!typingActionWasClicked && !string.IsNullOrEmpty(Input.inputString))
		{
			Manager.input.activeInputField.AppendString(Input.inputString);
		}
		return true;
	}

	private void TrySetInputText(bool success, string input)
	{
		lastControllerTextTime = Time.unscaledTime;
		Manager.input.StartMenuActivationInputCooldown();
		isShowingControllerTextInput = false;
		if (Manager.input.activeInputField != null)
		{
			if (success)
			{
				Manager.input.activeInputField.SetInputText(input);
			}
			Manager.input.activeInputField.Deactivate(success);
		}
	}

	private bool IsKeyDown(KeyCode keyCode, bool checkOnlyOnPressedDown = false)
	{
		typingActionWasClicked = Input.GetKeyUp(keyCode) || Input.GetKeyDown(keyCode) || Input.GetKey(keyCode) || typingActionWasClicked;
		if (Input.GetKeyDown(keyCode) || (!checkOnlyOnPressedDown && Input.GetKey(keyCode) && (typingInputCooldown.isTimerElapsed || !typingInputCooldown.isRunning)))
		{
			typingInputCooldown.Start(Input.GetKeyDown(keyCode) ? 0.3f : 0.05f);
			return true;
		}
		return false;
	}

	public void OnMenuEnabled()
	{
	}

	public void ShowPopUpMenu(List<string> options)
	{
		((RadicalPopUpMenu)popUpMenu).UpdateOptionTexts(options);
		PushMenu(RadicalMenu.MenuType.POP_UP);
	}

	public void PushMenu(RadicalMenu.MenuType type)
	{
		switch (type)
		{
		case RadicalMenu.MenuType.CREATIVE_CHARACTER_CHOOSER:
			Manager.menu.characterChooserMenu.isCreativeMenu = true;
			break;
		case RadicalMenu.MenuType.CHARACTER_CHOOSER:
			Manager.menu.characterChooserMenu.isCreativeMenu = false;
			break;
		}
		PushMenu(RadicalMenu.TypeToMenu(type));
	}

	public void PushMenu(RadicalMenu newMenu)
	{
		RadicalMenu topMenu = GetTopMenu();
		if (topMenu == newMenu)
		{
			Debug.Log("menu already pushed");
			return;
		}
		if (topMenu != null && newMenu.popsOtherActiveMenus)
		{
			DeactivateTopMenu(pop: false);
		}
		else
		{
			OnMenuEnabled();
		}
		menuStack.Push(newMenu);
		newMenu.OnFirstOpened();
		ActivateTopMenu();
	}

	public void PopMenu()
	{
		GetTopMenu();
		DeactivateTopMenu(pop: true);
		RadicalMenu radicalMenu = menuStack.Pop();
		if (menuStack.Count > 0 && radicalMenu.popsOtherActiveMenus)
		{
			ActivateTopMenu();
		}
	}

	public void PopAllMenus()
	{
		while (menuStackCount > 0)
		{
			DeactivateTopMenu(pop: true, fx: false);
			if (menuStack.Pop().popsOtherActiveMenus)
			{
				break;
			}
		}
		Manager.ui.EnableTemporarilyDisabledGameplayUI();
		menuStack.Clear();
		menuHelperButtons.gameObject.SetActive(value: false);
	}

	public bool HasMenuInStack(RadicalMenu.MenuType type)
	{
		return menuStack.Contains(RadicalMenu.TypeToMenu(type));
	}

	public void PopUntil(RadicalMenu.MenuType menuType, bool cancelWhenMenuNotInStack = false)
	{
		if (menuStackCount == 0)
		{
			return;
		}
		if (!HasMenuInStack(menuType))
		{
			Debug.LogWarning(string.Format("{0}.{1}: {2} doesn't exist in the stack.", "MenuManager", "PopUntil", menuType));
			if (cancelWhenMenuNotInStack)
			{
				return;
			}
		}
		RadicalMenu radicalMenu = RadicalMenu.TypeToMenu(menuType);
		while (GetTopMenu() != null && GetTopMenu() != radicalMenu && !(GetTopMenu() is RadicalMainMenu))
		{
			PopMenu();
		}
		GetTopMenu()?.Activate();
	}

	public int PopInt()
	{
		return intStack.Pop();
	}

	public void PushInt(int value)
	{
		intStack.Push(value);
	}

	private void ActivateTopMenu()
	{
		RadicalMenu topMenu = GetTopMenu();
		topMenu.Activate();
		if (!(topMenu is RadicalPopUpMenu))
		{
			Manager.ui.TemporarilyDisableGameplayUI();
		}
	}

	private void DeactivateTopMenu(bool pop, bool fx = true)
	{
		recentMenuClosedTimer.Start();
		RadicalMenu topMenu = GetTopMenu();
		if (menuStackCount <= 1)
		{
			Manager.ui.EnableTemporarilyDisabledGameplayUI();
		}
		if (topMenu != null)
		{
			topMenu.Deactivate(pop);
		}
	}

	public void ActivateSelectedOption()
	{
		RadicalMenu topMenu = GetTopMenu();
		if (topMenu.CanActivateCurrentOption())
		{
			Manager.input.StartMenuActivationInputCooldown();
			topMenu.ActivateSelectedIndex();
		}
	}

	public void SelectOption(UIelement option)
	{
		RadicalMenu topMenu = GetTopMenu();
		if (topMenu != null)
		{
			int indexForOption = topMenu.GetIndexForOption(option);
			if (indexForOption >= 0)
			{
				topMenu.SelectOptionIndex(indexForOption);
				AttemptToPlayMenuSfx(SfxID.FIXME_menu_select);
			}
		}
	}

	public void DeselectAnyCurrentOption()
	{
		RadicalMenu topMenu = GetTopMenu();
		if (topMenu != null)
		{
			topMenu.DeselectAnyCurrentOption();
		}
	}

	public bool UpdateInputAndApplyToCurrentMenu()
	{
		if (!Manager.input.IsMenuInputEnabled())
		{
			return false;
		}
		RadicalMenu topMenu = GetTopMenu();
		if (!Manager.input.IsMenuActivationInputOnCooldown())
		{
			bool flag = Manager.input.IsMenuInteractButtonDown();
			if (topMenu.CanActivateCurrentOption())
			{
				if (flag || Manager.input.IsMenuMouseInteractButtonDown())
				{
					AttemptToPlayMenuSfx(SfxID.FIXME_menu_select, 0.6f, 0f, reuse: false);
				}
				if (flag)
				{
					ActivateSelectedOption();
					return true;
				}
			}
			bool flag2 = Manager.input.IsMenuStartButtonDown();
			if (Manager.input.IsMenuBackButtonDown() || flag2)
			{
				if (Manager.input.activeDropdown != null && Manager.input.activeDropdown.isOpen)
				{
					Manager.input.activeDropdown.HideDropdownList(selectButton: true);
					Manager.input.SetActiveDropdown(null);
				}
				else if (topMenu.OnCloseMenuRequest() && (topMenu.backClosesMenu || menuStackCount > 1))
				{
					AudioManager.SfxUI(SfxID.FIXME_menu_select, 0.4f, reuse: false, 1f, 0f, playOnGamepad: true);
					Manager.input.StartMenuActivationInputCooldown();
					PopMenu();
				}
				return true;
			}
		}
		if (!Manager.input.IsMenuSelectionInputOnCooldown())
		{
			Direction direction = Manager.input.MenuInputDirection();
			if (!direction.is0)
			{
				Manager.input.StartMenuSelectionInputCooldown();
			}
			switch (direction.id)
			{
			case Direction.Id.back:
				if ((!topMenu.placeOptionsHorizontally && topMenu.SelectNextIndex()) || (topMenu.placeOptionsHorizontally && topMenu.SkimLeft()))
				{
					AttemptToPlayMenuSfx(SfxID.FIXME_menu_select);
					return true;
				}
				break;
			case Direction.Id.forward:
				if ((!topMenu.placeOptionsHorizontally && topMenu.SelectPrevIndex()) || (topMenu.placeOptionsHorizontally && topMenu.SkimRight()))
				{
					AttemptToPlayMenuSfx(SfxID.FIXME_menu_select);
					return true;
				}
				break;
			case Direction.Id.left:
				if ((!topMenu.placeOptionsHorizontally && topMenu.SkimLeft()) || (topMenu.placeOptionsHorizontally && topMenu.SelectPrevIndex()))
				{
					AttemptToPlayMenuSfx(SfxID.FIXME_menu_select);
					return true;
				}
				break;
			case Direction.Id.right:
				if ((!topMenu.placeOptionsHorizontally && topMenu.SkimRight()) || (topMenu.placeOptionsHorizontally && topMenu.SelectNextIndex()))
				{
					AttemptToPlayMenuSfx(SfxID.FIXME_menu_select);
					return true;
				}
				break;
			}
		}
		return false;
	}

	private void OnDestroy()
	{
	}

	public void OpenControlMappingMenu()
	{
		PushMenu(RadicalMenu.MenuType.CONTROL_MAPPER);
	}
}
