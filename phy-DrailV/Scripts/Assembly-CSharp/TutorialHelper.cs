using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Bolt;
using DV;
using DV.CabControls;
using DV.Common;
using DV.Game.Tutorial;
using DV.Game.Tutorial.ItemTracker;
using DV.Interaction;
using DV.Interaction.Inputs;
using DV.JObjectExtstensions;
using DV.Localization;
using DV.OriginShift;
using DV.Scenarios.Common;
using DV.Tutorial;
using DV.Tutorial.QT;
using DV.UI;
using DV.UIFramework;
using DV.UserManagement;
using DV.Utils;
using DV.VRTK_Extensions;
using DV.WeatherSystem;
using Newtonsoft.Json.Linq;
using Rewired;
using UnityEngine;
using VRTK;

public class TutorialHelper : SingletonBehaviour<TutorialHelper>
{
	public enum SoundType
	{
		None = 0,
		Regular = 1,
		Acknowledge = 2
	}

	[Header("Dialog")]
	public Popup dialogPrefabOK;

	public Popup dialogPrefabYesNo;

	public Popup dialogPrefabPrompt;

	public Popup dialogDifficultySelection;

	[Header("Floatie")]
	public GameObject inputTooltipsPrefab;

	public AudioClip floatieSound;

	public AudioClip acknowledgeSound;

	public AudioClip floatieClick;

	[Header("Helpers")]
	public LocoTutorialBlocker locoTutorialBlocker;

	public const string CHAPTER_KEY = "TutorialChapter";

	public const int LEFT = 0;

	public const int RIGHT = 1;

	private bool isVR;

	private bool[] isWand = new bool[2];

	private bool[] isIndex = new bool[2];

	private TeleportPointerController[] teleportControllers = new TeleportPointerController[2];

	private GameObject[] controllerObjects = new GameObject[2];

	private GameObject[] lastControllerObjects = new GameObject[2];

	private VRTK_InteractGrab[] vrGrabs = new VRTK_InteractGrab[2];

	private Grabber nonvrGrab;

	private GameObject attentionOffset;

	private GameObject notification;

	private GameObject controlHintNotification;

	private GameObject locoBlockedNotification;

	private GameObject tutorialHostObject;

	private bool ready;

	private bool tutorialRunning;

	private bool devMode;

	private Streamer[] worldStreamers;

	private List<ItemTracker> activeItemTrackers = new List<ItemTracker>();

	private GameObject[] currentControllerObjects = new GameObject[2];

	private Popup lastPopupShown;

	private Coroutine dismissableFloatieRoutine;

	private Dictionary<TrainCar, LocoImmobilizationData> hookedImmobilizedLocos = new Dictionary<TrainCar, LocoImmobilizationData>();

	public static bool InRestrictedMode
	{
		get
		{
			if (!SingletonBehaviour<TutorialHelper>.Instance)
			{
				return false;
			}
			return SingletonBehaviour<TutorialHelper>.Instance.tutorialRunning;
		}
	}

	public bool IsReady => ready;

	public GameObject[] GrabbedObjects { get; private set; } = new GameObject[2];

	public InventoryItemSpec[] GrabbedInventoryItems { get; private set; } = new InventoryItemSpec[2];

	public ItemBase[] GrabbedItems { get; private set; } = new ItemBase[2];

	public VRTK_ControllerReference[] ControllerReferences { get; private set; } = new VRTK_ControllerReference[2];

	public VRTK_ControllerEvents[] ControllerEvents { get; private set; } = new VRTK_ControllerEvents[2];

	public GameObject GrabbedObjectLeftHand => GrabbedObjects[0];

	public GameObject GrabbedObjectRightHand => GrabbedObjects[1];

	public InventoryItemSpec GrabbedInventoryItemLeftHand => GrabbedInventoryItems[0];

	public InventoryItemSpec GrabbedInventoryItemRightHand => GrabbedInventoryItems[1];

	public ItemBase GrabbedItemLeftHand => GrabbedItems[0];

	public ItemBase GrabbedItemRightHand => GrabbedItems[1];

	public VRTK_ControllerReference ControllerReferenceLeftHand => ControllerReferences[0];

	public VRTK_ControllerReference ControllerReferenceRightHand => ControllerReferences[1];

	public VRTK_ControllerEvents ControllerEventsLeftHand => ControllerEvents[0];

	public VRTK_ControllerEvents ControllerEventsRightHand => ControllerEvents[1];

	public TeleportPointerController[] TeleportControllers => teleportControllers;

	public Grabber NonVRGrab => nonvrGrab;

	public bool IsWand
	{
		get
		{
			if (!isWand[0])
			{
				return isWand[1];
			}
			return true;
		}
	}

	public bool IsIndex
	{
		get
		{
			if (!isIndex[0])
			{
				return isIndex[1];
			}
			return true;
		}
	}

	public bool IsAnyVRContinueButtonPressed
	{
		get
		{
			if (!VRManager.IsVREnabled())
			{
				return false;
			}
			if (ControllerReferences[1] == null || !ControllerReferences[1].IsValid())
			{
				return false;
			}
			ControllerType_DV controllerTypeDV = ControllerReferences[1].GetControllerTypeDV();
			VRTK_ControllerEvents.Vector2AxisAlias vector2AxisType = ((controllerTypeDV != ControllerType_DV.WMR && controllerTypeDV != ControllerType_DV.HPReverbG2) ? VRTK_ControllerEvents.Vector2AxisAlias.Touchpad : VRTK_ControllerEvents.Vector2AxisAlias.TouchpadTwo);
			if (TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(ControllerEvents[1].GetAxis(vector2AxisType)) != TouchpadInputDirection.Up)
			{
				return false;
			}
			if (IsWand)
			{
				return ControllerEvents[1].IsButtonPressed(VRTK_ControllerEvents.ButtonAlias.TouchpadPress);
			}
			return true;
		}
	}

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Initialize()
	{
		base.Initialize();
		devMode = DevUtil.IsDevMachine();
		isVR = VRManager.IsVREnabled();
		worldStreamers = UnityEngine.Object.FindObjectsOfType<Streamer>();
		StartCoroutine(InitializationRoutine());
	}

	public static void SetCurrentlyRunningTutorial(GameObject hostObject)
	{
		SingletonBehaviour<TutorialHelper>.Instance.tutorialHostObject = hostObject;
		Debug.Log("CURRENT TUTORIAL HOST: " + hostObject, hostObject);
	}

	public static bool IsTutorialPhaseCompleted(int phaseID)
	{
		switch (phaseID)
		{
		case 1:
			return SingletonBehaviour<SaveGameManager>.Instance.data.GetBool("Tutorial_01_completed") ?? true;
		case 2:
			return SingletonBehaviour<SaveGameManager>.Instance.data.GetBool("Tutorial_02_completed") ?? true;
		default:
			return false;
		}
	}

	public void RegisterItemTracker(ItemTracker tracker)
	{
		if (!activeItemTrackers.Contains(tracker))
		{
			activeItemTrackers.Add(tracker);
		}
	}

	public void UnregisterItemTracker(ItemTracker tracker)
	{
		activeItemTrackers.Remove(tracker);
	}

	private void Update()
	{
		if (VRManager.IsVREnabled())
		{
			currentControllerObjects[0] = VRTK_DeviceFinder.GetControllerLeftHand(getActual: true);
			currentControllerObjects[1] = VRTK_DeviceFinder.GetControllerRightHand(getActual: true);
			for (int i = 0; i < 2; i++)
			{
				if (currentControllerObjects[i] != lastControllerObjects[i])
				{
					vrGrabs[i] = null;
					ControllerEvents[i] = null;
					teleportControllers[i] = null;
					ControllerReferences[i] = (currentControllerObjects[i] ? VRTK_DeviceFinder.GetControllerReferenceForHand((SDK_BaseController.ControllerHand)(i + 1)) : null);
					if (ControllerReferences[i] != null && ControllerReferences[i].IsValid())
					{
						lastControllerObjects[i] = currentControllerObjects[i];
						isWand[i] = ControllerReferences[i].IsWandOrUndefined();
						isIndex[i] = ControllerReferences[i].GetControllerTypeDV() == ControllerType_DV.ValveIndex;
					}
					else
					{
						lastControllerObjects[i] = null;
						isWand[i] = false;
						isIndex[i] = false;
					}
				}
				if (!vrGrabs[i] && (bool)currentControllerObjects[i])
				{
					vrGrabs[i] = currentControllerObjects[i].GetComponentInChildren<VRTK_InteractGrab>();
				}
				if (!ControllerEvents[i] && ControllerReferences[i] != null && ControllerReferences[i].IsValid())
				{
					ControllerEvents[i] = ControllerReferences[i].scriptAlias.GetComponent<VRTK_ControllerEvents>();
				}
				if (!teleportControllers[i] && (bool)currentControllerObjects[i])
				{
					teleportControllers[i] = currentControllerObjects[i].GetComponentInChildren<TeleportPointerController>(includeInactive: true);
				}
				GameObject gameObject = (vrGrabs[i] ? vrGrabs[i].GetGrabbedObject() : null);
				if (gameObject != GrabbedObjects[i])
				{
					GrabbedObjects[i] = gameObject;
					GrabbedInventoryItems[i] = (gameObject ? gameObject.GetComponent<InventoryItemSpec>() : null);
					GrabbedItems[i] = (gameObject ? gameObject.GetComponent<ItemBase>() : null);
				}
			}
		}
		else
		{
			GrabbedObjects[0] = null;
			GrabbedInventoryItems[0] = null;
			GrabbedItems[0] = null;
			ControllerEvents[0] = null;
			ControllerEvents[1] = null;
			GameObject gameObject2 = ((!nonvrGrab || !nonvrGrab.IsGrabbing()) ? null : (nonvrGrab.CurrentItemHeld ? nonvrGrab.CurrentItemHeld.gameObject : null));
			if (gameObject2 != GrabbedObjects[1])
			{
				GrabbedObjects[1] = gameObject2;
				GrabbedInventoryItems[1] = (gameObject2 ? gameObject2.GetComponent<InventoryItemSpec>() : null);
				GrabbedItems[1] = (gameObject2 ? gameObject2.GetComponent<ItemBase>() : null);
			}
		}
		for (int num = activeItemTrackers.Count - 1; num >= 0; num--)
		{
			activeItemTrackers[num].Update();
			if (num >= activeItemTrackers.Count)
			{
				num = activeItemTrackers.Count - 1;
			}
		}
		if (!devMode || !Input.GetKeyDown(KeyCode.KeypadDivide) || !tutorialHostObject)
		{
			return;
		}
		if (Variables.ActiveScene.IsDefined("SKIP") && Variables.ActiveScene.Get<bool>("SKIP"))
		{
			Debug.Log("ALREADY MID-SKIP!");
			return;
		}
		Debug.Log("TUTORIAL CHAPTER SKIP!", tutorialHostObject);
		ScreenFade.Fade(Color.black, 0f);
		StateMachine component = tutorialHostObject.GetComponent<StateMachine>();
		if (QuickTutorialHost.IsTutorialRunning)
		{
			QuickTutorialHost.AbortTutorial();
		}
		component.StopAllCoroutines();
		for (int num2 = activeItemTrackers.Count - 1; num2 >= 0; num2--)
		{
			activeItemTrackers[num2].Dispose();
		}
		activeItemTrackers.Clear();
		HideTutorialFloatie();
		HidePrompt();
		HideControlHint();
		Variables.ActiveScene.Set("SKIP", true);
		CustomEvent.Trigger(tutorialHostObject, "SKIP");
		StartCoroutine(Unfade());
	}

	public bool CheckIfStreaming()
	{
		if (worldStreamers != null)
		{
			Streamer[] array = worldStreamers;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].LoadingProgress < 1f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private IEnumerator Unfade()
	{
		while (CheckIfStreaming())
		{
			yield return null;
		}
		for (int i = 0; i < 5; i++)
		{
			yield return null;
		}
		ScreenFade.Fade(Color.clear, 0.5f);
	}

	private IEnumerator InitializationRoutine()
	{
		while (!PlayerManager.PlayerCamera)
		{
			yield return null;
		}
		while (LoadingScreenManager.IsLoading)
		{
			yield return null;
		}
		if (!isVR)
		{
			teleportControllers[0] = PlayerManager.PlayerCamera.GetComponentInChildren<TeleportPointerController>();
			nonvrGrab = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>();
		}
		else
		{
			while (!LocomotionSetup.Initialized)
			{
				yield return null;
			}
			yield return null;
			yield return null;
			bool rightReady;
			bool leftReady;
			do
			{
				rightReady = SetupDeviceSpecificControls.AreControlsSetRight;
				leftReady = SetupDeviceSpecificControls.AreControlsSetLeft;
				yield return null;
			}
			while (!rightReady && !leftReady);
			yield return null;
		}
		ready = true;
	}

	public void StartRestrictedTutorialMode(bool forceWeather = true, bool modifyDifficulty = true, bool denyAllFeatures = true)
	{
		if (!tutorialRunning)
		{
			tutorialRunning = true;
			if (forceWeather)
			{
				SingletonBehaviour<WeatherDriver>.Instance.SetStartingWeather(SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime + TimeSpan.FromDays(30.0), TimeSpan.FromDays(1.0), Vector2.zero, 0f, 0f, 0f);
			}
			SingletonBehaviour<SaveGameManager>.Instance.disableAutosave = true;
			if (modifyDifficulty)
			{
				DifficultyParamsSetter.SetDifficultyParams(DifficultyParamsSetter.Comfort);
				Globals.G.GameParams.DerailBuildUpThreshold = float.PositiveInfinity;
				Globals.G.GameParams.DamageSensitivityModifier = 0f;
				Globals.G.GameParams.FreeCamAllowed = false;
				Globals.G.GameParams.AutoHeadlightsDirectionAllowed = false;
				Globals.G.GameParams.AutoHeadlightsOnOffAllowed = false;
				Globals.G.GameParams.DayLengthInMinutes = 999999f;
			}
			if (denyAllFeatures)
			{
				GameFeatureFlags.Deny(GameFeatureFlags.Flag.ALL);
			}
			if ((bool)SingletonBehaviour<TutorialBoundsPlayerChecker>.Instance)
			{
				SingletonBehaviour<TutorialBoundsPlayerChecker>.Instance.PlayerWithinTutorialBoundsChanged += OnPlayerOutOfBoundsChanged;
			}
		}
	}

	public static void ResetPlayerToDefaultSpawn()
	{
		if ((bool)SingletonBehaviour<LevelInfo>.Instance)
		{
			PlayerManager.TeleportPlayer(LevelInfo.DefaultSpawnPosition + WorldMover.currentMove, Quaternion.Euler(LevelInfo.DefaultSpawnRotation), null, useRotation: true);
		}
		else
		{
			Debug.LogWarning("LevelInfo not found in this level, not teleporting!");
		}
	}

	public void EndTutorial()
	{
		tutorialRunning = false;
		SingletonBehaviour<WeatherDriver>.Instance.SetStartingWeather(SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime, TimeSpan.FromDays(1.0), Vector2.zero, 0f, 0f, 0f);
		if ((bool)SingletonBehaviour<TutorialBoundsPlayerChecker>.Instance)
		{
			SingletonBehaviour<TutorialBoundsPlayerChecker>.Instance.PlayerWithinTutorialBoundsChanged -= OnPlayerOutOfBoundsChanged;
		}
	}

	private void OnPlayerOutOfBoundsChanged(bool withinBounds)
	{
		Debug.LogWarning("WITHIN BOUNDS: " + withinBounds);
	}

	public void ShowDialog(string message, string confirm, string cancel, Action onConfirm, Action onCancel)
	{
		Popup popup = null;
		popup = ((string.IsNullOrEmpty(cancel) || onCancel == null) ? SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(dialogPrefabOK, new PopupLocalizationKeys
		{
			labelKey = message,
			positiveKey = confirm
		}) : SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(dialogPrefabYesNo, new PopupLocalizationKeys
		{
			labelKey = message,
			positiveKey = confirm,
			negativeKey = cancel
		}));
		popup.Closed += delegate(PopupResult result)
		{
			if (result.closedBy == PopupClosedByAction.Positive)
			{
				onConfirm?.Invoke();
			}
			else
			{
				onCancel?.Invoke();
			}
		};
	}

	public void SelectDifficultyAndReload()
	{
		SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(dialogDifficultySelection).Closed += delegate(PopupResult result)
		{
			IDifficulty difficulty = null;
			switch (result.closedBy)
			{
			case PopupClosedByAction.Positive:
				difficulty = DifficultyParamsSetter.Standard;
				break;
			case PopupClosedByAction.Negative:
				difficulty = DifficultyParamsSetter.Comfort;
				break;
			case PopupClosedByAction.Abortion:
				difficulty = DifficultyParamsSetter.Realistic;
				break;
			default:
				Debug.LogError($"Unexpected state: Dialog closed by {result.closedBy}, defaulting to Standard difficulty");
				difficulty = DifficultyParamsSetter.Standard;
				break;
			}
			SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.SetDifficulty(difficulty, forcePreset: true, forceConsistency: true);
			SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameData.SetBool("Difficulty_picked", value: true);
			StartGameData_NewCareer.PrepareNewSaveData(ref SingletonBehaviour<SaveGameManager>.Instance.data, out var _, SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession, difficulty, skipTutorial: true);
			SingletonBehaviour<SaveGameManager>.Instance.data.SetVector3("Player_position", PlayerManager.PlayerTransform.AbsolutePosition());
			SingletonBehaviour<SaveGameManager>.Instance.data.SetVector3("Player_rotation", PlayerManager.PlayerTransform.rotation.eulerAngles);
			SingletonBehaviour<SaveGameManager>.Instance.data.SetBool("Tutorial_03_completed", value: false);
			SingletonBehaviour<SaveGameManager>.Instance.data.SetBool("Tutorial_just_finished", value: true);
			SingletonBehaviour<WeatherDriver>.Instance.SetStartingWeather(SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime, TimeSpan.FromDays(1.0), Vector2.zero, 0f, 0f, 0f);
			JObject saveData = SingletonBehaviour<WeatherDriver>.Instance.GetSaveData(packOverrides: false);
			SingletonBehaviour<SaveGameManager>.Instance.data.SetJObject("Time_and_date", saveData);
			SingletonBehaviour<SaveGameManager>.Instance.StashScreenshot();
			ISaveGame save = SingletonBehaviour<SaveGameManager>.Instance.Save(SaveType.Manual, null, updateInternalData: false);
			SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.Save();
			AStartGameData.Continue(save, useSessionDifficulty: true);
			SceneSwitcher.SwitchToScene(DVScenes.Game);
		};
	}

	public static string LocalizeAndFormatMarkups(string input, bool doLocalization = true)
	{
		if (doLocalization)
		{
			input = ((!input.StartsWith("!")) ? LocalizationAPI.L(input) : input.Substring(1));
		}
		if (input.Contains("|"))
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (num < input.Length)
			{
				int num2 = input.IndexOf('|', num);
				if (num2 == -1)
				{
					stringBuilder.Append(input.Substring(num, input.Length - num));
					num = input.Length;
					continue;
				}
				stringBuilder.Append(input.Substring(num, num2 - num));
				int num3 = input.IndexOf('|', num2 + 1);
				if (num3 == -1)
				{
					num = num2 + 1;
					continue;
				}
				string keybInput = input.Substring(num2 + 1, num3 - num2 - 1);
				stringBuilder.Append(LocalizeKeybinding(keybInput));
				num = num3 + 1;
			}
			input = stringBuilder.ToString();
		}
		if (input.Contains("{"))
		{
			input = input.Replace("{", "<color=#ffff00>").Replace("}", "</color>");
		}
		return input;
	}

	private static string LocalizeKeybinding(string keybInput)
	{
		if (keybInput.EndsWith("]"))
		{
			int num = keybInput.LastIndexOf("[");
			if (num > 0)
			{
				string text = keybInput.Substring(num + 1, keybInput.Length - num - 2);
				if (int.TryParse(text, out var _))
				{
					keybInput = keybInput.Substring(0, num);
				}
				else
				{
					Debug.LogWarning("Invalid keybinding index '" + text + "'");
				}
			}
			else
			{
				Debug.LogWarning("Keybinding entry has ] but no [: " + keybInput);
			}
		}
		if (keybInput.StartsWith("~") && keybInput.Length >= 2)
		{
			return LocalizeSpecialKeys(keybInput);
		}
		if (keybInput.StartsWith("!") && keybInput.Length >= 2)
		{
			return TutorialInputPromptsBridge.GetLocalizedForSemantic(keybInput.Substring(1));
		}
		if (VRManager.IsVREnabled())
		{
			if (keybInput.ToLower() == "teleport")
			{
				return "X/A";
			}
			if (keybInput.ToLower() == "dropitem")
			{
				if (!VRManager.AnyWandController())
				{
					return LocalizationAPI.L("vr/meta/grip");
				}
				return LocalizationAPI.L("vr/meta/trigger");
			}
			if (keybInput.ToLower() == "inventoryopen")
			{
				return "Y/B";
			}
			if (keybInput.ToLower() == "uiinteractionprimary")
			{
				return LocalizationAPI.L("vr/meta/trigger");
			}
		}
		InputAction action = ReInput.mapping.GetAction(keybInput);
		if (action != null)
		{
			return action.id.LocalizeInput();
		}
		Debug.LogWarning("Invalid keybinding key '" + keybInput + "'");
		return keybInput;
	}

	private static string LocalizeSpecialKeys(string keybInput)
	{
		switch (keybInput)
		{
		case "~Mouse":
			return LocalizationAPI.L("keycode/meta/mouse");
		case "~MouseWheel":
			return LocalizationAPI.L("keycode/meta/mouse_wheel");
		case "~Trigger":
			return LocalizationAPI.L("vr/meta/trigger");
		case "~Grip":
			return LocalizationAPI.L("vr/meta/grip");
		case "~Joystick":
			return LocalizationAPI.L("vr/meta/joystick");
		case "~A":
			return "A";
		case "~B":
			return "B";
		case "~Y":
			return "Y";
		case "~X":
			return "X";
		case "~Mouse0":
			return LocalizationAPI.L("keycode/mouse0");
		case "~Mouse1":
			return LocalizationAPI.L("keycode/mouse1");
		case "~Mouse2":
			return LocalizationAPI.L("keycode/mouse2");
		case "~LeftControl":
			return LocalizationAPI.L("keycode/leftcontrol");
		case "~LeftAlt":
			return LocalizationAPI.L("keycode/leftalt");
		case "~LeftShift":
			return LocalizationAPI.L("keycode/leftshift");
		case "~KeypadPlus":
			return LocalizationAPI.L("keycode/keypadplus");
		case "~KeypadMinus":
			return LocalizationAPI.L("keycode/keypadminus");
		case "~KeypadDivide":
			return LocalizationAPI.L("keycode/keypaddivide");
		case "~KeypadMultiply":
			return LocalizationAPI.L("keycode/keypadmultiply");
		case "~KeypadEnter":
			return LocalizationAPI.L("keycode/keypadenter");
		case "~Space":
			return LocalizationAPI.L("keycode/space");
		case "~LeftBracket":
			return "[";
		case "~RightBracket":
			return "]";
		case "~LeftCurlyBracket":
			return "{";
		case "~RightCurlyBracket":
			return "}";
		default:
			Debug.LogWarning("Invalid keycode '" + keybInput + "'");
			return keybInput;
		}
	}

	public void ShowPrompt(string message, bool pause, Action onConfirm, bool localize = true)
	{
		if ((bool)lastPopupShown)
		{
			lastPopupShown.RequestClose(PopupClosedByAction.Abortion, "");
			UnityEngine.Object.Destroy(lastPopupShown);
			lastPopupShown = null;
		}
		message = LocalizeAndFormatMarkups(message, localize);
		lastPopupShown = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.PopupManager.ShowPopup(dialogPrefabPrompt, new PopupLocalizationKeys
		{
			labelKey = message
		}, null, keepLiteralData: true);
		if (pause)
		{
			SingletonBehaviour<AppUtil>.Instance.PauseGame();
		}
		lastPopupShown.Closed += delegate
		{
			lastPopupShown = null;
			if (pause)
			{
				SingletonBehaviour<AppUtil>.Instance.UnpauseGame();
			}
			onConfirm?.Invoke();
		};
	}

	public void HidePrompt()
	{
		if ((bool)lastPopupShown)
		{
			UnityEngine.Object.Destroy(lastPopupShown);
			lastPopupShown = null;
		}
	}

	public void ShowTutorialFloatie(string message, Transform attentionTarget, Vector3 offset = default(Vector3), bool localize = true, bool targetIsUI = false, SoundType soundType = SoundType.Regular, bool manualDismiss = false)
	{
		if (attentionTarget != null && offset != Vector3.zero)
		{
			if ((bool)attentionOffset)
			{
				UnityEngine.Object.Destroy(attentionOffset);
			}
			attentionOffset = new GameObject("_AttentionOffset_");
			attentionOffset.transform.SetParent(attentionTarget);
			attentionOffset.transform.localPosition = offset;
			attentionTarget = attentionOffset.transform;
		}
		if (notification != null)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(notification);
			notification = null;
		}
		HideLocoBlockedNotification();
		PlayNotification(soundType);
		notification = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ShowNotification(LocalizeAndFormatMarkups(message, localize), null, float.MaxValue, clearExisting: false, attentionTarget, localize: false, targetIsUI, default(NotificationManager.SizeOverrides), NotificationManager.Ordering.First);
		NukeTheAwaitingCoroutine();
		if (manualDismiss)
		{
			dismissableFloatieRoutine = StartCoroutine(AwaitNotificationDismissal());
		}
	}

	public void ShowControlHint(ControlHint hint)
	{
		if (hint == ControlHint.None)
		{
			HideControlHint();
			return;
		}
		string message = hint.GetAttribute().GetMessage();
		if (!string.IsNullOrEmpty(message))
		{
			if (controlHintNotification != null)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(controlHintNotification);
			}
			controlHintNotification = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ShowNotification(message, null, float.MaxValue, clearExisting: false, null, localize: false, targetIsUI: false, new NotificationManager.SizeOverrides
			{
				textScale = 0.85f,
				verticalMarginScale = 0.5f
			}, NotificationManager.Ordering.Last, new NotificationManager.ColorOverrides
			{
				backgroundColor = new Color(0.2f, 0.2f, 0.2f, 0.9f)
			});
		}
	}

	public void HideControlHint()
	{
		if (controlHintNotification != null)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(controlHintNotification);
			controlHintNotification = null;
		}
	}

	private void ShowLocoBlockedNotification()
	{
		if (!(locoBlockedNotification != null))
		{
			PlayNotification();
			locoBlockedNotification = SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ShowNotification("tutorial/generic/loco_blocked", null, float.MaxValue, clearExisting: false, null, localize: true, targetIsUI: false, new NotificationManager.SizeOverrides
			{
				textScale = 0.85f,
				verticalMarginScale = 0.5f
			}, NotificationManager.Ordering.Last, new NotificationManager.ColorOverrides
			{
				backgroundColor = new Color(1f, 0.2f, 0.2f, 0.9f)
			});
		}
	}

	private void HideLocoBlockedNotification()
	{
		if (locoBlockedNotification != null)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(locoBlockedNotification);
			locoBlockedNotification = null;
		}
	}

	private void NukeTheAwaitingCoroutine()
	{
		if (dismissableFloatieRoutine != null)
		{
			if (!VRManager.IsVREnabled())
			{
				DV.Interaction.Inputs.InputManager.SetInteractConflictersEnabled(on: true);
			}
			StopCoroutine(dismissableFloatieRoutine);
			dismissableFloatieRoutine = null;
		}
	}

	private IEnumerator AwaitNotificationDismissal()
	{
		if (!VRManager.IsVREnabled())
		{
			DV.Interaction.Inputs.InputManager.SetInteractConflictersEnabled(on: false);
		}
		while (!DV.Interaction.Inputs.InputManager.NewPlayer.GetButton(DV.Interaction.Inputs.InputManager.Actions.Interact) && !IsAnyVRContinueButtonPressed)
		{
			yield return null;
		}
		while (DV.Interaction.Inputs.InputManager.NewPlayer.GetButton(DV.Interaction.Inputs.InputManager.Actions.Interact) || IsAnyVRContinueButtonPressed)
		{
			yield return null;
		}
		HideTutorialFloatie(playClick: true);
	}

	public static string GetContinuePromptSuffix()
	{
		string text;
		if (VRManager.IsVREnabled())
		{
			string firstParamValue = (VRManager.AnyWandController() ? LocalizationAPI.L("vr/meta/right_touchpad_up") : LocalizationAPI.L("vr/meta/right_joystick_up"));
			text = LocalizationAPI.L("tutorial/to_continue_vr", firstParamValue);
		}
		else
		{
			text = LocalizationAPI.L("tutorial/to_continue_nonvr", DV.Interaction.Inputs.InputManager.Actions.Interact.LocalizeInput());
		}
		return "<align=\"left\"><br>\n<b><color=#00ffff>" + text + "</color></b></align>\n";
	}

	public void HideTutorialFloatie(bool playClick = false)
	{
		if (!UnloadWatcher.isUnloading)
		{
			NukeTheAwaitingCoroutine();
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager.ClearNotification(notification);
			notification = null;
			if ((bool)attentionOffset)
			{
				UnityEngine.Object.Destroy(attentionOffset);
			}
			if (playClick)
			{
				PlayClick();
			}
		}
	}

	public void PlayNotification(SoundType soundType = SoundType.Regular)
	{
		if (soundType == SoundType.Regular && (bool)floatieSound)
		{
			floatieSound.Play2D(1f, playDuringPause: true);
		}
		else if (soundType == SoundType.Acknowledge && (bool)acknowledgeSound)
		{
			acknowledgeSound.Play2D(1f, playDuringPause: true);
		}
	}

	public void PlayClick()
	{
		if ((bool)floatieClick)
		{
			floatieClick.Play2D(1f, playDuringPause: true);
		}
	}

	public static void MakeItemEssential(GameObject item, bool belongsToPlayer, bool immuneToDumpster)
	{
		InventoryItemSpec component = item.GetComponent<InventoryItemSpec>();
		if (component == null)
		{
			Debug.LogWarning("Requested item cannot be made essential - it is not an inventory item. Skipping...");
		}
		else
		{
			MakeItemEssential(component, belongsToPlayer, immuneToDumpster);
		}
	}

	public static void MakeItemEssential(InventoryItemSpec specs, bool belongsToPlayer, bool immuneToDumpster)
	{
		if (specs.BelongsToPlayer)
		{
			Debug.LogWarning("Item already essential. Skipping...");
			return;
		}
		specs.BelongsToPlayer = belongsToPlayer;
		specs.ImmuneToDumpster = immuneToDumpster;
		RespawnOnDrop component = specs.GetComponent<RespawnOnDrop>();
		if ((bool)component)
		{
			component.SetMaxDistance(200f);
			component.ignoreDistanceFromSpawnPosition = true;
		}
		else
		{
			Debug.LogWarning("Item " + specs.gameObject.name + " doesn't have a RespawnOnDrop! Should wait for object to get enabled?", specs.gameObject);
		}
	}

	public static string GetCurrentTutorialPhaseName(Flow flow)
	{
		if (flow.stack.parentElement is FlowState)
		{
			return ((FlowState)flow.stack.parentElement).nest.embed.title;
		}
		return "N/A";
	}

	public bool ImmobilizeLoco(GameObject carObject)
	{
		TrainCar trainCar = TrainCar.Resolve(carObject);
		if (!trainCar)
		{
			return false;
		}
		return ImmobilizeLoco(trainCar);
	}

	private void OnImmobilizedLocoValueChanged(TrainCar car, ValueChangedEventArgs eventData)
	{
		ShowLocoBlockedNotification();
	}

	public bool ImmobilizeLoco(TrainCar car)
	{
		if (hookedImmobilizedLocos.ContainsKey(car))
		{
			Debug.LogWarning("Loco " + car.ID + " is already immobilized!");
			return true;
		}
		LocoImmobilizationData locoImmobilizationData = new LocoImmobilizationData(car);
		hookedImmobilizedLocos.Add(car, locoImmobilizationData);
		locoImmobilizationData.OnInteriorControlValueChanged += OnImmobilizedLocoValueChanged;
		Rigidbody componentInChildren = car.GetComponentInChildren<Rigidbody>();
		if ((bool)componentInChildren && !componentInChildren.isKinematic)
		{
			if (Time.timeScale == 0f)
			{
				car.StartCoroutine(DelayedRigidBodyKinematicSet(componentInChildren, kinematic: true));
			}
			else
			{
				componentInChildren.isKinematic = true;
			}
			return true;
		}
		return false;
	}

	public bool RemoveImmobilizationFromLoco(GameObject carObject)
	{
		TrainCar trainCar = TrainCar.Resolve(carObject);
		if (!trainCar)
		{
			return false;
		}
		return RemoveImmobilizationFromLoco(trainCar);
	}

	public bool RemoveImmobilizationFromLoco(TrainCar car)
	{
		if (hookedImmobilizedLocos.TryGetValue(car, out var value))
		{
			value.OnInteriorControlValueChanged -= OnImmobilizedLocoValueChanged;
			value.Dispose();
			hookedImmobilizedLocos.Remove(car);
		}
		HideLocoBlockedNotification();
		Rigidbody componentInChildren = car.GetComponentInChildren<Rigidbody>();
		if ((bool)componentInChildren && componentInChildren.isKinematic)
		{
			car.StartCoroutine(DelayedRigidBodyKinematicSet(componentInChildren, kinematic: false));
			return true;
		}
		return false;
	}

	private static IEnumerator DelayedRigidBodyKinematicSet(Rigidbody rb, bool kinematic)
	{
		int unpausedFrames = 0;
		while (unpausedFrames < 5)
		{
			unpausedFrames = ((Time.timeScale != 0f) ? (unpausedFrames + 1) : 0);
			yield return null;
		}
		yield return new WaitForFixedUpdate();
		rb.isKinematic = kinematic;
		if (!kinematic)
		{
			rb.WakeUp();
		}
	}

	public LocoTutorialBlocker BlockLoco(GameObject carObject)
	{
		TrainCar trainCar = TrainCar.Resolve(carObject);
		if (!trainCar)
		{
			return null;
		}
		return BlockLoco(trainCar);
	}

	public LocoTutorialBlocker BlockLoco(TrainCar car)
	{
		LocoTutorialBlocker componentInChildren = car.GetComponentInChildren<LocoTutorialBlocker>();
		if ((bool)componentInChildren)
		{
			return componentInChildren;
		}
		componentInChildren = UnityEngine.Object.Instantiate(locoTutorialBlocker.gameObject, car.transform).GetComponent<LocoTutorialBlocker>();
		componentInChildren.transform.localPosition = Vector3.zero;
		componentInChildren.transform.localRotation = Quaternion.identity;
		return componentInChildren;
	}

	public void UnblockLoco(GameObject carObject)
	{
		TrainCar trainCar = TrainCar.Resolve(carObject);
		if ((bool)trainCar)
		{
			UnblockLoco(trainCar);
		}
	}

	public void UnblockLoco(TrainCar car)
	{
		LocoTutorialBlocker componentInChildren = car.GetComponentInChildren<LocoTutorialBlocker>();
		if ((bool)componentInChildren)
		{
			componentInChildren.UnblockLoco();
		}
		else if (car.interior != null)
		{
			componentInChildren = car.interior.GetComponentInChildren<LocoTutorialBlocker>();
			if ((bool)componentInChildren)
			{
				componentInChildren.UnblockLoco();
			}
		}
	}
}
