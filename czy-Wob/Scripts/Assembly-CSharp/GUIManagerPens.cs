using System.Collections;
using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using TMPro;
using UnityEngine;

public class GUIManagerPens : GUIManagerBase
{
	public delegate void PopupStompRequest();

	public struct PopupNotif
	{
		public string header;

		public string body;

		public Sprite icon;

		public Researchable research;

		public PopupNotif(Researchable newResearch)
		{
			header = null;
			body = null;
			icon = null;
			research = newResearch;
		}

		public PopupNotif(string newHeader, string newBody, Sprite newIcon)
		{
			header = newHeader;
			body = newBody;
			icon = newIcon;
			research = null;
		}
	}

	private PopupStompRequest currentStompRequest;

	public Canvas mainCanvas;

	public Canvas globalCanvas;

	public Canvas photoModeCanvas;

	public Canvas passiveModeCanvas;

	public GameObject petGrabButtons;

	public GameObject HUDHolder;

	public GameObject modeButtons;

	public GameObject mainDock;

	public GameObject breedingDock;

	public TextMeshProUGUI modeShiftTextPet;

	public TextMeshProUGUI modeShiftTextGrab;

	public GameObject dogPenGUI;

	public GameObject dogStorageGUIPrefab;

	public GameObject goalsGUIPrefab;

	public GameObject dogBreedingSelectionGUIPrefab;

	public GameObject pauseMenuGUIPrefab;

	public GameObject playModeGUI;

	public GameObject playModeGUIBehindDock;

	public GameObject buildModeGUI;

	public GameObject placementModeGUI;

	public GameObject breedingChooserGUI;

	public PhotoModeGUI photoModeGUIRef;

	public PassiveModeGUI passiveModeGUIRef;

	public BreedingPenGUI breedingPenGUI;

	public FloraButtonBase floraButtonRef;

	public DogThumbnailController thumbnailRef;

	public CommandChooserGUI commandChooserRef;

	public GameObject unclaimedGoalIndicator;

	public GameObject genericChoicePopup;

	public CoreButtonUnityGUI panelInventoryButton;

	public InventoryPanel panelInventoryGUI;

	public InchwormBounce inventoryButtonBounce;

	public GameObject denInteriorGUI;

	public TextMeshProUGUI tutorialTipsText;

	public GameObject tutorialTipsObject;

	public GameObject objectUnlockGUI;

	public GoalCompletePopup goalCompletePopupRef;

	public PassiveMessagePopup genericMessagePopupRef;

	public GameObject passiveModeButton;

	public GameObject exitPassiveModeButton;

	public GameObject tutorialArrowPlay;

	public GameObject tutorialArrowPlacement;

	public GameObject tutorialArrowDogStorage;

	public GameObject tutorialArrowUtilities;

	public GameObject tutorialArrowIncubator;

	public GameObject tutorialArrowFoodDispenser;

	public GameObject tutorialArrowBreeding;

	private Vector3 startPos = new Vector3(-8.14f, -4.33f, -200f);

	private bool playModeGUILocked;

	private GameObject instantiatedDogPenGUI;

	private GUIMode currentGUIMode;

	private bool dogPenToggleRequested;

	private ElementStatus dogPenStatus = ElementStatus.UNLOADED;

	private bool initialItemSet;

	private bool GUIInteractiveStatus = true;

	private GoalsGUIManager goalsGUIRef;

	private DogStorageGUIManager dogStorageGUIRef;

	private DogBreedingSelectionGUIManager dogBreedingGUIRef;

	private List<LockReason> bgLocks = new List<LockReason>();

	private List<LockReason> guiInteractivityLocks = new List<LockReason>();

	private Coroutine currentTopPopRoutine;

	private List<string> completedGoalsQueue = new List<string>();

	private List<PopupNotif> newNotifQueue = new List<PopupNotif>();

	private string goalCompleteSound = "goal_complete";

	private string genericPopupSound = "tutorial_popup_open";

	private LockReason currentPopupLock = LockReason.NONE;

	private bool initialized;

	private bool needsPlayModeHide;

	private bool inPhotoMode;

	private bool inPassiveMode;

	private bool pauseMenuLocked;

	private bool passiveModeGUIHidden;

	private BuildGUI buildGUIRef;

	private DogHome dogHomeRef;

	private PenFocus penFocusRef;

	private DogFocus dogFocusRef;

	private PauseController pauseRef;

	private ObjectGrabber grabberRef;

	private DogRegistration dogRegRef;

	private SceneManagerBase sceneRef;

	private ControlManager controlsRef;

	private CursorController cursorRef;

	private ConstructionManager constructionRef;

	protected override void Initialize()
	{
		if (!initialized)
		{
			DisableAllTutorialArrows();
			SetGUIInteractiveStatus(status: false, LockReason.SCENE_TRANSITION);
			initialized = true;
			base.transform.position = startPos;
			instantiatedDogPenGUI = Object.Instantiate(dogPenGUI);
			instantiatedDogPenGUI.transform.SetParent(playModeGUI.transform.parent);
			instantiatedDogPenGUI.SetActive(value: false);
			HideTutorialTip();
			denInteriorGUI.SetActive(value: false);
			objectUnlockGUI.SetActive(value: false);
			goalCompletePopupRef.gameObject.SetActive(value: false);
			genericMessagePopupRef.gameObject.SetActive(value: false);
			penFocusRef = Camera.main.GetComponent<PenFocus>();
			dogFocusRef = Camera.main.GetComponent<DogFocus>();
			buildGUIRef = buildModeGUI.GetComponent<BuildGUI>();
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
			pauseRef = registrationScript.GetGlobalComponent<PauseController>(GlobalObject.GLOBAL_CLOCK);
			grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
			sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
			dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
			controlsRef = registrationScript.GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
			dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
			constructionRef = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
			photoModeCanvas.enabled = false;
			passiveModeCanvas.enabled = false;
			mainCanvas.worldCamera = registrationScript.GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
			UpdateControlVisuals();
			if (sceneRef.GetGameMode() != GameMode.HOME)
			{
				mainDock.SetActive(value: false);
				breedingDock.SetActive(value: true);
				HideModeButtons();
			}
			else
			{
				mainDock.SetActive(value: true);
				breedingDock.SetActive(value: false);
				HideBreedingPenGUI();
			}
			base.Initialize();
			thumbnailRef.Initialize(this);
			if (needsPlayModeHide)
			{
				HidePlayModeGUI();
			}
			GoalsController.SyncUnclaimedGoalIndicator(this);
			SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().SetGameLocation(GameLocation.PENS);
		}
	}

	public void UpdateControlVisuals()
	{
		UpdateShiftBindingDisplay();
	}

	private void UpdateShiftBindingDisplay()
	{
		string currentActiveBindingForCommand = controlsRef.GetCurrentActiveBindingForCommand(ControlCommand.PETTING_GRAB_SWAP, cursorRef);
		if (!cursorRef.IsSystemMouseActive())
		{
			currentActiveBindingForCommand = controlsRef.GetCurrentActiveBindingForCommand(ControlCommand.PETTING_GRAB_SWAP_GAMEPAD, cursorRef);
		}
		modeShiftTextPet.text = currentActiveBindingForCommand;
		modeShiftTextGrab.text = currentActiveBindingForCommand;
	}

	private void OnDestroy()
	{
		if (currentTopPopRoutine != null)
		{
			StopCoroutine(currentTopPopRoutine);
			currentTopPopRoutine = null;
		}
	}

	public override void OnSceneTransitionFinished()
	{
		base.OnSceneTransitionFinished();
		SyncNewIndicator();
		UpdateControlVisuals();
		SetGUIInteractiveStatus(status: true, LockReason.SCENE_TRANSITION);
	}

	public void RegisterNewPopup(LockReason reason, bool stomp = true, PopupStompRequest stompRequest = null)
	{
		if (stomp)
		{
			ExitPhotoMode();
			CloseInventoryPanel();
			thumbnailRef.CloseGutGUIIfOpened();
			floraButtonRef.CloseFloraGUIIfOpen();
			if (dogHomeRef.IsInBuildMode())
			{
				dogHomeRef.RequestExitBuildMode();
			}
			if (dogBreedingGUIRef != null)
			{
				OnDogBreedingSelectionGUIClosed();
			}
			if (dogStorageGUIRef != null)
			{
				OnDogStorageGUIClosed();
			}
			currentStompRequest?.Invoke();
			currentStompRequest = null;
		}
		if (currentPopupLock != LockReason.NONE)
		{
			Debug.LogError("Attempting to double-add popups!");
			Debug.LogError("Current popup: " + currentPopupLock);
			Debug.LogError("New popup: " + reason);
		}
		currentPopupLock = reason;
		currentStompRequest = stompRequest;
	}

	public void ClearPopupRegistration(LockReason reason)
	{
		if (currentPopupLock != reason)
		{
			Debug.LogError(string.Concat("Attempting to remove popup Lockreason: ", reason, " but the current lock doesn't match and is: ", currentPopupLock));
		}
		currentStompRequest = null;
		currentPopupLock = LockReason.NONE;
	}

	public bool IsPopupLockActive()
	{
		return currentPopupLock != LockReason.NONE;
	}

	public void DisableAllTutorialArrows()
	{
		tutorialArrowPlay.SetActive(value: false);
		tutorialArrowBreeding.SetActive(value: false);
		tutorialArrowPlacement.SetActive(value: false);
		tutorialArrowUtilities.SetActive(value: false);
		tutorialArrowIncubator.SetActive(value: false);
		tutorialArrowDogStorage.SetActive(value: false);
		tutorialArrowFoodDispenser.SetActive(value: false);
	}

	public void SetBreedingArrowVis(bool val)
	{
		tutorialArrowBreeding.SetActive(val);
	}

	public void SetStorageArrowVis(bool val)
	{
		tutorialArrowDogStorage.SetActive(val);
	}

	public void SetStorageExitArrowVis(bool val)
	{
		dogStorageGUIRef.SetExitArrowStatus(val);
	}

	public void SetPlayArrowVis(bool val)
	{
		tutorialArrowPlay.SetActive(val);
	}

	public void SetPlacementArrowVis(bool val)
	{
		tutorialArrowPlacement.SetActive(val);
	}

	public void SetUtilitiesArrowVis(bool val)
	{
		tutorialArrowUtilities.SetActive(val);
	}

	public void SetIncubatorArrowVis(bool val)
	{
		tutorialArrowIncubator.SetActive(val);
	}

	public void SetFoodDispenserArrowVis(bool val)
	{
		tutorialArrowFoodDispenser.SetActive(val);
	}

	public GUIMode GetCurrentMode()
	{
		return currentGUIMode;
	}

	public void OnEnterPassiveModeButtonClicked()
	{
		if (GameSettings.IsPassiveModeEnabled())
		{
			GameSettings.SetPassiveModeEnabled(val: false);
			ExitPassiveMode();
		}
		else
		{
			RequestGenericPopup(ScriptLocalization.AutomationOptions.AUTO_ENTER_HEADER, ScriptLocalization.AutomationOptions.AUTO_ENTER_BODY, OnConfirmEnterPassiveModeButtonClicked, OnCancelEnterPassiveModeButtonClicked);
			DisableBG(LockReason.PASSIVE_MODE_POPUP);
		}
	}

	public void OnConfirmEnterPassiveModeButtonClicked()
	{
		EnableBG(LockReason.PASSIVE_MODE_POPUP);
		exitPassiveModeButton.SetActive(value: true);
		GameSettings.SetPassiveModeEnabled(val: true);
	}

	public void OnCancelEnterPassiveModeButtonClicked()
	{
		EnableBG(LockReason.PASSIVE_MODE_POPUP);
	}

	protected override void UpdateFunctionality()
	{
		base.UpdateFunctionality();
		if (!initialItemSet)
		{
			initialItemSet = true;
		}
		if (!playModeGUILocked && bgLocks.Count == 0 && GameControls.actions.PhotoModeToggle.WasPressed)
		{
			OnPhotoModeButtonPressed();
		}
		if (currentGUIMode != GUIMode.PLAY)
		{
			return;
		}
		if (dogPenToggleRequested)
		{
			ToggleDogPenGUI();
		}
		if (bgLocks.Count == 0)
		{
			if (GameControls.actions.CycleNextDog.WasPressed)
			{
				dogRegRef.SelectNextDog();
			}
			else if (GameControls.actions.CyclePreviousDog.WasPressed)
			{
				dogRegRef.SelectPreviousDog();
			}
		}
		DisplayNextTopPopIfNeeded();
		if (inPhotoMode)
		{
			if (GameControls.actions.CloseMenu.WasPressed)
			{
				pauseRef.RequestUIEnabled();
				OnPhotoModeButtonPressed();
				CheckUIState();
			}
		}
		else if (GameSettings.IsPassiveModeEnabled() && sceneRef.GetGameMode() == GameMode.HOME)
		{
			if (!inPassiveMode)
			{
				inPassiveMode = true;
				passiveModeCanvas.enabled = true;
				passiveModeGUIRef.OnEnterPassiveMode();
			}
			if (GameSettings.PassiveModeAutoHideGUI())
			{
				if (cursorRef.IsPassiveModeCursorEnabled() && passiveModeGUIHidden)
				{
					passiveModeGUIHidden = false;
					SetUIVisibilityForPhotoMode(val: true);
				}
				else if (!cursorRef.IsPassiveModeCursorEnabled() && !passiveModeGUIHidden)
				{
					passiveModeGUIHidden = true;
					SetUIVisibilityForPhotoMode(val: false);
				}
			}
		}
		else if (inPassiveMode)
		{
			ExitPassiveMode();
		}
		exitPassiveModeButton.SetActive(GameSettings.IsPassiveModeEnabled());
		if (TutorialController.IsTutorialActive())
		{
			passiveModeButton.SetActive(value: false);
		}
		else
		{
			passiveModeButton.SetActive(value: true);
		}
	}

	public void SetUIVisibilityForPhotoMode(bool val)
	{
		if (val)
		{
			pauseRef.RequestUIEnabled();
		}
		else
		{
			pauseRef.RequestUIDisabled();
		}
		CheckUIState();
	}

	public void ToggleDogPenGUI()
	{
		dogPenToggleRequested = false;
		switch (dogPenStatus)
		{
		case ElementStatus.UNLOADED:
			ShowDogPenGUI();
			break;
		case ElementStatus.UNLOADING:
			dogPenToggleRequested = true;
			break;
		case ElementStatus.LOADED:
			HideDogPenGUI();
			break;
		case ElementStatus.LOADING:
			dogPenToggleRequested = true;
			break;
		}
	}

	public void RequestGenericPopup(string header, string message, CoreButton.OnClickDelegate newCallbackYes, CoreButton.OnClickDelegate newCallbackNo = null, bool cancelKeyAllowed = false)
	{
		if (currentGUIMode == GUIMode.PLACEMENT)
		{
			ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.IDLE);
		}
		else if (currentGUIMode == GUIMode.CONSTRUCT)
		{
			constructionRef.SetSubMode(ConstructionManager.SubMode.STANDARD);
		}
		Object.Instantiate(genericChoicePopup).GetComponent<GenericChoicePopup>().SetPopupInfo(header, message, newCallbackYes, newCallbackNo, cancelKeyAllowed);
	}

	public void SetConstructionInstructionVisibility(bool val, bool immediate = false)
	{
		if (val)
		{
			buildGUIRef.ShowConstructionInstructions(immediate);
		}
		else
		{
			buildGUIRef.HideConstructionInstructions(immediate);
		}
	}

	public void SetConstructionInstructionText(string newText, bool immediate = false)
	{
		buildGUIRef.UpdateConstructionInstructionText(newText, immediate);
	}

	public bool CanEnterBuildMode()
	{
		return currentGUIMode != GUIMode.OBJECT_INFO;
	}

	public bool ModeButtonsUsable()
	{
		return modeButtons.activeSelf;
	}

	public void OnEnterDenInterior()
	{
		DisablePanelInventory();
		denInteriorGUI.SetActive(value: true);
	}

	public void OnExitDenInterior()
	{
		EnablePanelInventory();
		denInteriorGUI.SetActive(value: false);
	}

	public void OnDenInteriorExitButtonPressed()
	{
		penFocusRef.ClearDenFocus();
	}

	public bool IsInPhotoMode()
	{
		return inPhotoMode;
	}

	public void ExitPhotoMode()
	{
		pauseRef.RequestUnpause(LockReason.PHOTO_MODE);
		photoModeGUIRef.OnExitPhotoMode();
		inPhotoMode = false;
		CheckUIState();
	}

	public void ExitPassiveMode()
	{
		inPassiveMode = false;
		CheckUIState();
	}

	public void OnPhotoModeButtonPressed()
	{
		if (inPhotoMode)
		{
			pauseRef.RequestUnpause(LockReason.PHOTO_MODE);
			photoModeGUIRef.OnExitPhotoMode();
		}
		else
		{
			pauseRef.RequestPause(LockReason.PHOTO_MODE);
			photoModeGUIRef.OnEnterPhotoMode();
		}
		inPhotoMode = !inPhotoMode;
		CheckUIState();
		if (inPhotoMode && dogHomeRef.IsInBuildMode())
		{
			dogHomeRef.RequestExitBuildMode();
		}
	}

	private void CheckUIState()
	{
		bool active = PauseController.IsUIEnabled();
		mainCanvas.enabled = active;
		globalCanvas.enabled = active;
		photoModeCanvas.enabled = inPhotoMode;
		passiveModeCanvas.enabled = inPassiveMode;
		if (inPassiveMode && bgLocks.Count > 0 && !bgLocks.Contains(LockReason.PASSIVE_MODE_MENU))
		{
			passiveModeCanvas.enabled = false;
		}
		if (inPhotoMode)
		{
			passiveModeCanvas.enabled = false;
		}
		if (IsGUIHiddenDueToPassiveMode())
		{
			globalCanvas.enabled = true;
			passiveModeCanvas.enabled = false;
		}
		petGrabButtons.SetActive(active);
		exitPassiveModeButton.SetActive(GameSettings.IsPassiveModeEnabled());
	}

	public bool IsGUIHiddenDueToPassiveMode()
	{
		if (!PauseController.IsUIEnabled() && !inPhotoMode && GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoHideGUI())
		{
			return passiveModeGUIHidden;
		}
		return false;
	}

	public void OnPlayMode()
	{
		currentGUIMode = GUIMode.PLAY;
		ShowModeButtons();
		ShowPlayModeGUI();
		HideBuildModeGUI();
		HidePlacementModeGUI();
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnEnterStandardMode();
		}
		pauseRef.RequestUnpause(LockReason.BUILD_MODE);
		pauseRef.RequestUnpause(LockReason.PLACEMENT_MODE);
	}

	public void OnBuildMode()
	{
		currentGUIMode = GUIMode.CONSTRUCT;
		ShowModeButtons();
		ShowBuildModeGUI();
		HidePlayModeGUI();
		HidePlacementModeGUI();
		pauseRef.RequestPause(LockReason.BUILD_MODE);
		pauseRef.RequestUnpause(LockReason.PLACEMENT_MODE);
	}

	public void OnPlacementMode()
	{
		currentGUIMode = GUIMode.PLACEMENT;
		ShowModeButtons();
		ShowPlacementModeGUI();
		HidePlayModeGUI();
		HideBuildModeGUI();
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnEnterPlacementMode();
		}
		pauseRef.RequestPause(LockReason.PLACEMENT_MODE);
		pauseRef.RequestUnpause(LockReason.BUILD_MODE);
	}

	public void MakeGUIInvisible()
	{
		base.gameObject.SetActive(value: false);
	}

	public void MakeGUIVisible()
	{
		base.gameObject.SetActive(value: true);
	}

	public void ShowTutorialTip(string text)
	{
		HideTutorialTip();
		tutorialTipsText.text = text;
		tutorialTipsObject.SetActive(value: true);
		tutorialTipsText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
	}

	public void UpdateTutorialTipForNewLanguage()
	{
		if (TutorialController.IsTutorialActive())
		{
			tutorialTipsText.text = TutorialController.GetCurrentTutorialTipText();
		}
	}

	public void HideTutorialTip()
	{
		tutorialTipsObject.SetActive(value: false);
	}

	public void ShowPassiveModeNotification(string header, string body, Sprite icon)
	{
		if (currentTopPopRoutine != null || !GetGUIInteractiveStatus())
		{
			newNotifQueue.Add(new PopupNotif(header, body, icon));
		}
		else
		{
			currentTopPopRoutine = StartCoroutine(TopPopRoutine("", null, header, body, icon));
		}
	}

	public void ShowObjectUnlockGUI(Researchable researchableRef, ObjectUnlockGUI.GUIClosedCallback callback = null, float soundDelay = -1f, bool autoOpen = false)
	{
		if (autoOpen)
		{
			if (currentTopPopRoutine != null || !GetGUIInteractiveStatus())
			{
				newNotifQueue.Add(new PopupNotif(researchableRef));
			}
			else
			{
				currentTopPopRoutine = StartCoroutine(TopPopRoutine("", researchableRef));
			}
		}
		else
		{
			RegisterNewPopup(LockReason.OBJECT_UNLOCK_GUI);
			DisableBG(LockReason.OBJECT_UNLOCK_GUI);
			objectUnlockGUI.SetActive(value: true);
			objectUnlockGUI.GetComponent<ObjectUnlockGUI>().SetUnlockedObject(researchableRef, callback, soundDelay);
		}
	}

	public void ShowObjectUnlockGUI(InventoryItem itemRef, ObjectUnlockGUI.GUIClosedCallback callback = null)
	{
		RegisterNewPopup(LockReason.OBJECT_UNLOCK_GUI);
		DisableBG(LockReason.OBJECT_UNLOCK_GUI);
		objectUnlockGUI.SetActive(value: true);
		objectUnlockGUI.GetComponent<ObjectUnlockGUI>().SetUnlockViaInventoryItem(itemRef, callback);
	}

	public void HideObjectUnlockGUI()
	{
		grabberRef.RequestFrameWait();
		objectUnlockGUI.SetActive(value: false);
		EnableBG(LockReason.OBJECT_UNLOCK_GUI);
		ClearPopupRegistration(LockReason.OBJECT_UNLOCK_GUI);
	}

	public void OnInstantPenEditButtonPressed()
	{
		GameObject gameObject = penFocusRef.GetFocusedRoom();
		if (gameObject == null)
		{
			gameObject = penFocusRef.GetRoomForFocusedObject();
			if (gameObject == null)
			{
				return;
			}
		}
		ulong uID = gameObject.GetComponent<BuildObjectInfo>().GetUID();
		if (constructionRef.IsInPlacementMode())
		{
			dogHomeRef.RequestExitBuildMode();
			return;
		}
		dogHomeRef.RequestEnterBuildMode(playSounds: false);
		constructionRef.SetConstructionMode(ConstructionManager.CurrentMode.PLACEMENT, uID, playEntrySound: true, playExitSound: false);
	}

	public void LockPlayModeGUI()
	{
		HidePlayModeGUI();
		playModeGUILocked = true;
	}

	public void ShowPlayModeGUI()
	{
		if (!playModeGUILocked)
		{
			playModeGUI.SetActive(value: true);
			playModeGUIBehindDock.SetActive(value: true);
		}
	}

	public void HidePlayModeGUI()
	{
		if (!initialized)
		{
			needsPlayModeHide = true;
			return;
		}
		needsPlayModeHide = false;
		playModeGUI.SetActive(value: false);
		playModeGUIBehindDock.SetActive(value: false);
	}

	private void ShowBuildModeGUI()
	{
		buildModeGUI.SetActive(value: true);
		buildModeGUI.GetComponent<BuildGUI>().Load();
	}

	private void HideBuildModeGUI()
	{
		buildModeGUI.GetComponent<BuildGUI>().Unload();
		buildModeGUI.SetActive(value: false);
	}

	private void ShowPlacementModeGUI()
	{
		placementModeGUI.SetActive(value: true);
	}

	private void HidePlacementModeGUI()
	{
		placementModeGUI.SetActive(value: false);
	}

	private void HideModeButtons()
	{
		modeButtons.SetActive(value: false);
	}

	private void ShowModeButtons()
	{
		if (sceneRef.GetGameMode() != GameMode.HOME)
		{
			HideModeButtons();
		}
		else
		{
			modeButtons.SetActive(value: true);
		}
	}

	private void EnableActiveGUI()
	{
		if (currentGUIMode == GUIMode.PLAY)
		{
			ShowPlayModeGUI();
		}
		else
		{
			ShowBuildModeGUI();
		}
	}

	private void DisableActiveGUI()
	{
		if (currentGUIMode == GUIMode.PLAY)
		{
			HidePlayModeGUI();
		}
		else if (currentGUIMode == GUIMode.CONSTRUCT || currentGUIMode == GUIMode.OBJECT_INFO)
		{
			HideBuildModeGUI();
		}
		else if (currentGUIMode == GUIMode.PLACEMENT)
		{
			HidePlacementModeGUI();
		}
	}

	public void ShowDogPenGUI()
	{
		dogPenStatus = ElementStatus.LOADING;
		DisableActiveGUI();
		grabberRef.DisableGrabber(LockReason.DOG_PEN_GUI);
		SFXOverlord.LockInWorldSFX(LockReason.DOG_PEN_GUI);
		instantiatedDogPenGUI.SetActive(value: true);
		instantiatedDogPenGUI.GetComponent<ScalableUIContainerLoader>().LoadContainer(DogPenLoadedCallback);
	}

	public void HideHUD()
	{
		mainCanvas.enabled = false;
		commandChooserRef.OnGUIHidden();
	}

	public void ShowHUD()
	{
		mainCanvas.enabled = true;
		commandChooserRef.OnGUIUnhidden();
	}

	private void DogPenLoadedCallback()
	{
		dogPenStatus = ElementStatus.LOADED;
		HidePlayModeGUI();
		HideBuildModeGUI();
		HidePlacementModeGUI();
	}

	public void SetUnclaimedGoalsStatus(bool status)
	{
		unclaimedGoalIndicator.SetActive(status);
	}

	public void OnGoalComplete(string completedGoalName)
	{
		if (currentTopPopRoutine != null || !GetGUIInteractiveStatus())
		{
			completedGoalsQueue.Add(completedGoalName);
		}
		else
		{
			currentTopPopRoutine = StartCoroutine(TopPopRoutine(completedGoalName));
		}
	}

	private IEnumerator TopPopRoutine(string completedGoalName = "", Researchable unlockedResearch = null, string customHeader = "", string customBody = "", Sprite customSprite = null)
	{
		bool customHeaderAndBody = false;
		if (unlockedResearch != null)
		{
			goalCompletePopupRef.gameObject.SetActive(value: false);
		}
		else if (customHeader != null && customBody != null && customHeader.Length > 0 && customBody.Length > 0)
		{
			customHeaderAndBody = true;
			goalCompletePopupRef.gameObject.SetActive(value: false);
		}
		else
		{
			genericMessagePopupRef.gameObject.SetActive(value: false);
		}
		float t = 0f;
		float easeInTime = 0.5f;
		float easeOutTime = 1f;
		float holdTime = 2f;
		float easeDistance = 150f;
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		if (GUIInteractiveStatus)
		{
			if (unlockedResearch != null || customHeaderAndBody)
			{
				AudioController.Play(genericPopupSound, 1f, easeInTime / 2f);
			}
			else
			{
				AudioController.Play(goalCompleteSound, 1f, easeInTime / 2f);
			}
		}
		Transform easedTransform = goalCompletePopupRef.transform;
		if (unlockedResearch != null || customHeaderAndBody)
		{
			easedTransform = genericMessagePopupRef.transform;
			genericMessagePopupRef.gameObject.SetActive(value: true);
			string text;
			string text2;
			Sprite sprite;
			if (customHeaderAndBody)
			{
				text = customBody;
				text2 = customHeader;
				sprite = customSprite;
			}
			else if (unlockedResearch.inventoryItemUnlock != null)
			{
				sprite = unlockedResearch.inventoryItemUnlock.icon;
				text2 = ScriptLocalization.GUI.GUI_GOALS_OBJUNLOCKED;
				text = unlockedResearch.inventoryItemUnlock.itemNameLocalized;
			}
			else if (unlockedResearch.roomCustomizationObjectUnlock != null)
			{
				sprite = unlockedResearch.roomCustomizationObjectUnlock.icon;
				text2 = ScriptLocalization.GUI.GUI_GOALS_OBJUNLOCKED;
				text = unlockedResearch.roomCustomizationObjectUnlock.GetName();
			}
			else
			{
				sprite = null;
				text = "ERROR";
				text2 = "ERROR";
				Debug.LogError("No valid unlock provided.");
			}
			genericMessagePopupRef.messageBodyText.text = text;
			genericMessagePopupRef.messageHeaderText.text = text2;
			genericMessagePopupRef.messageIconSprite.sprite = sprite;
		}
		else
		{
			goalCompletePopupRef.gameObject.SetActive(value: true);
			goalCompletePopupRef.goalNameText.text = completedGoalName;
		}
		easedTransform.localPosition = new Vector3(0f, easeDistance, 0f);
		for (; t < easeInTime; t += Time.unscaledDeltaTime)
		{
			float easeOutElasticValue = Inchworm.GetEaseOutElasticValue(t, 0f, 0f - easeDistance, easeInTime);
			easedTransform.localPosition = new Vector3(0f, easeDistance - easeOutElasticValue, 0f);
			yield return frameWait;
		}
		easedTransform.localPosition = Vector3.zero;
		yield return new WaitForSecondsRealtime(holdTime);
		for (t = 0f; t < easeOutTime; t += Time.unscaledDeltaTime)
		{
			float easeInElasticValue = Inchworm.GetEaseInElasticValue(t, 0f, 0f - easeDistance, easeOutTime);
			easedTransform.localPosition = new Vector3(0f, easeInElasticValue, 0f);
			yield return frameWait;
		}
		easedTransform.localPosition = new Vector3(0f, easeDistance, 0f);
		if (unlockedResearch != null || customHeaderAndBody)
		{
			genericMessagePopupRef.gameObject.SetActive(value: false);
		}
		else
		{
			goalCompletePopupRef.gameObject.SetActive(value: false);
		}
		yield return frameWait;
		currentTopPopRoutine = null;
		DisplayNextTopPopIfNeeded();
	}

	private void DisplayNextTopPopIfNeeded()
	{
		if (currentTopPopRoutine != null || !GetGUIInteractiveStatus() || (completedGoalsQueue.Count == 0 && newNotifQueue.Count == 0))
		{
			return;
		}
		if (completedGoalsQueue.Count > 0)
		{
			string completedGoalName = completedGoalsQueue[0];
			completedGoalsQueue.RemoveAt(0);
			currentTopPopRoutine = StartCoroutine(TopPopRoutine(completedGoalName));
		}
		else if (newNotifQueue.Count > 0)
		{
			PopupNotif popupNotif = newNotifQueue[0];
			newNotifQueue.RemoveAt(0);
			if (popupNotif.research != null)
			{
				currentTopPopRoutine = StartCoroutine(TopPopRoutine("", popupNotif.research));
			}
			else
			{
				currentTopPopRoutine = StartCoroutine(TopPopRoutine("", null, popupNotif.header, popupNotif.body, popupNotif.icon));
			}
		}
	}

	public void ShowGoalsGUI()
	{
		penFocusRef.DisableModularZoom();
		DisableBG(LockReason.DOG_GOALS_GUI);
		GameObject gameObject = Object.Instantiate(goalsGUIPrefab, Vector3.zero, Quaternion.identity);
		goalsGUIRef = gameObject.GetComponent<GoalsGUIManager>();
		goalsGUIRef.OnGUIOpened();
	}

	public void OnGoalsGUIClosed()
	{
		Object.Destroy(goalsGUIRef.gameObject);
		goalsGUIRef = null;
		penFocusRef.EnableModularZoom(penFocusRef.GetFocusedRoom());
		EnableBG(LockReason.DOG_GOALS_GUI);
	}

	public void ShowDogStorageGUI()
	{
		penFocusRef.DisableModularZoom();
		DisableBG(LockReason.DOG_STORAGE_GUI);
		GameObject gameObject = Object.Instantiate(dogStorageGUIPrefab, Vector3.zero, Quaternion.identity);
		dogStorageGUIRef = gameObject.GetComponent<DogStorageGUIManager>();
		dogStorageGUIRef.OnGUIOpened();
	}

	public void OnDogStorageGUIClosed()
	{
		Object.Destroy(dogStorageGUIRef.gameObject);
		dogStorageGUIRef = null;
		penFocusRef.EnableModularZoom(penFocusRef.GetFocusedRoom());
		EnableBG(LockReason.DOG_STORAGE_GUI);
	}

	public void OnSlowmoButtonPressed()
	{
		CheatEngine.cheatRef.ToggleSlowmo();
	}

	public void ShowDogBreedingSelectionGUI()
	{
		penFocusRef.DisableModularZoom();
		DisableBG(LockReason.DOG_BREEDING_SELECTION_GUI);
		GameObject gameObject = Object.Instantiate(dogBreedingSelectionGUIPrefab, Vector3.zero, Quaternion.identity);
		dogBreedingGUIRef = gameObject.GetComponent<DogBreedingSelectionGUIManager>();
		dogBreedingGUIRef.OnGUIOpened();
	}

	public void OnDogBreedingSelectionGUIClosed()
	{
		Object.Destroy(dogBreedingGUIRef.gameObject);
		dogBreedingGUIRef = null;
		penFocusRef.EnableModularZoom(penFocusRef.GetFocusedRoom());
		EnableBG(LockReason.DOG_BREEDING_SELECTION_GUI);
	}

	public void HideDogPenGUI()
	{
		dogPenStatus = ElementStatus.UNLOADING;
		EnableActiveGUI();
		instantiatedDogPenGUI.GetComponent<ScalableUIContainerLoader>().UnloadContainer(DogPenHiddenCallback);
		SFXOverlord.UnlockInWorldSFX(LockReason.DOG_PEN_GUI);
	}

	private void DogPenHiddenCallback()
	{
		dogPenStatus = ElementStatus.UNLOADED;
		instantiatedDogPenGUI.SetActive(value: false);
		grabberRef.EnableGrabber(LockReason.DOG_PEN_GUI);
	}

	public void SetPauseMenuLockedStatus(bool val)
	{
		pauseMenuLocked = val;
	}

	public void ShowPauseMenu()
	{
		if (!pauseMenuLocked && !grabberRef.IsCarryingInventoryObject() && bgLocks.Count <= 0 && sceneRef.HasSceneStarted())
		{
			Object.Instantiate(pauseMenuGUIPrefab);
		}
	}

	public void HidePauseMenu()
	{
	}

	public BreedingGUI ShowBreedingGUI()
	{
		mainDock.SetActive(value: false);
		breedingDock.SetActive(value: true);
		return Object.Instantiate(breedingChooserGUI).GetComponent<BreedingGUI>();
	}

	public BreedingPenGUI GetBreedingPenGUIRef()
	{
		return breedingPenGUI;
	}

	public void ShowBreedingPenGUI()
	{
		HidePlayModeGUI();
		mainDock.SetActive(value: false);
		breedingDock.SetActive(value: true);
		breedingPenGUI.gameObject.SetActive(value: true);
	}

	public void HideBreedingPenGUI()
	{
		mainDock.SetActive(value: true);
		breedingDock.SetActive(value: false);
		breedingPenGUI.gameObject.SetActive(value: false);
	}

	public bool IsAnyDogHatching()
	{
		if (guiInteractivityLocks.Contains(LockReason.COCOON_HATCHING))
		{
			return true;
		}
		return false;
	}

	public void SetGUIInteractiveStatus(bool status, LockReason reason)
	{
		if (status)
		{
			if (guiInteractivityLocks.Contains(reason))
			{
				guiInteractivityLocks.Remove(reason);
			}
		}
		else
		{
			if (guiInteractivityLocks.Contains(reason))
			{
				Debug.LogError("Attempting to double-add a gui lock reason. This will result in issues when trying to remove the locks later on.");
				return;
			}
			guiInteractivityLocks.Add(reason);
		}
		if (!status)
		{
			GUIInteractiveStatus = status;
		}
		else if (guiInteractivityLocks.Count == 0)
		{
			GUIInteractiveStatus = status;
		}
	}

	public bool GetGUIInteractiveStatus()
	{
		return GUIInteractiveStatus;
	}

	public void DisablePanelInventory()
	{
		CloseInventoryPanel();
		panelInventoryButton.interactable = false;
		panelInventoryButton.useGlobalGUIActiveStatus = false;
	}

	public void EnablePanelInventory()
	{
		panelInventoryButton.interactable = true;
		panelInventoryButton.useGlobalGUIActiveStatus = true;
	}

	public void CloseInventoryPanel()
	{
		panelInventoryGUI.ClosePanel();
	}

	public void OnObjectAddedToInventory(InventoryItem newItem)
	{
		inventoryButtonBounce.RequestBounce();
		panelInventoryGUI.RefreshPanel(newItem);
	}

	public void OnNewObjectAddedToInventory()
	{
		panelInventoryGUI.SyncNewIndicator();
	}

	public void SyncNewIndicator()
	{
		if (panelInventoryGUI != null)
		{
			panelInventoryGUI.SyncNewIndicator();
		}
	}

	public void OnGamePaused()
	{
		CloseInventoryPanel();
	}

	public void DisableBG(LockReason lockReason, bool blur = true, bool pause = true)
	{
		if (bgLocks.Contains(lockReason))
		{
			Debug.LogError("Attempting to lock the background via a duplicate reason: " + lockReason);
			return;
		}
		if (bgLocks.Count == 0)
		{
			if (blur)
			{
				EnableBlur();
			}
			ExitPhotoMode();
			CloseInventoryPanel();
			grabberRef.DisableGrabber(LockReason.BG_GUI);
			SetGUIInteractiveStatus(status: false, LockReason.BG_GUI);
			if (lockReason != LockReason.PASSIVE_MODE_MENU)
			{
				passiveModeCanvas.enabled = false;
			}
		}
		bgLocks.Add(lockReason);
		if (pause)
		{
			pauseRef.RequestPause(lockReason);
		}
	}

	public void EnableBG(LockReason lockReason)
	{
		if (bgLocks.Contains(lockReason))
		{
			bgLocks.Remove(lockReason);
			pauseRef.RequestUnpause(lockReason);
		}
		if (bgLocks.Count <= 0)
		{
			grabberRef.EnableGrabber(LockReason.BG_GUI);
			SetGUIInteractiveStatus(status: true, LockReason.BG_GUI);
			DisableBlur();
			CheckUIState();
		}
	}

	public void EnableBlur()
	{
		penFocusRef.SetInputAllowed(val: false, LockReason.BG_BLUR);
		dogFocusRef.Freeze();
		penFocusRef.BlurBG();
	}

	public void DisableBlur()
	{
		penFocusRef.UnblurBG();
		dogFocusRef.Unfreeze();
		penFocusRef.SetInputAllowed(val: true, LockReason.BG_BLUR);
	}

	public bool IsInputAllowed()
	{
		return penFocusRef.IsInputAllowed();
	}

	public bool IsBlurActive()
	{
		return penFocusRef.IsBlurActive();
	}
}
