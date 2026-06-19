using System.Collections.Generic;
using System.Linq;
using Pug.UnityExtensions;
using PugMod;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;
using Unity.Profiling;
using UnityEngine;

public class InputManager : ManagerBase, IInput
{
	public interface TextInputInterface
	{
		bool WasAutoActivated { get; set; }

		int MaxCharactersForOnScreenKeyboard { get; }

		string GetInputText();

		void SetInputText(string input);

		void AppendString(string input);

		void Deactivate(bool commit);

		void MoveCharMarker(int n);

		void RemoveCharAtMarker();

		void RemoveCharBehindMarker();

		string GetHintString();

		bool IsHidden();
	}

	public enum ControllerPlatformType
	{
		Keyboard = 0,
		Mouse = 1,
		XboxController = 2,
		Playstation4Controller = 3,
		Playstation5Controller = 4,
		NintendoSwitchController = 5
	}

	public const string DEFAULT_MAP_CATEGORY_NAME = "Default";

	public const string MENU_MAP_CATEGORY_NAME = "Menu";

	public const string MAPVIEW_MAP_CATEGORY_NAME = "MapView";

	public const string INVENTORY_MAP_CATEGORY_NAME = "Inventory";

	public const string INGAME_MAP_CATEGORY_NAME = "Ingame";

	public const string VEHICLE_MAP_CATEGORY_NAME = "Vehicle";

	public const string MUSICINSTRUMENT_MAP_CATEGORY_NAME = "MusicInstrument";

	public const string MAP_CATEOORY_TAG_GAMEPLAY = "gameplay";

	public const string ACTION_CATEGORY_TAG_PLAYER = "player";

	public const string ACTION_CATEGORY_TAG_SYSTEM = "system";

	public const string DEFAULT_LAYOUT_NAME = "Default";

	public const string NINTENDO_SWITCH_LAYOUT_NAME = "NintendoSwitch";

	public const string PLAYSTATION_LAYOUT_NAME = "Playstation";

	public bool touchpadInUse;

	public static readonly string XboxPrefix = "Xbox";

	public static readonly string XInputPrefix = "XInput";

	public static readonly string SonyPrefix = "Sony";

	public static readonly string SonyDualShockPrefix = "Sony DualShock";

	public static readonly string SonyDualSensePrefix = "Sony DualSense";

	public static readonly string NintendoPrefix = "Nintendo";

	[Header("Gamepad rumble settings:")]
	public AnimationCurve defaultQuickRumbleCurve;

	public int maxRumbleInstanceCount = 10;

	private const bool timeMenuUnscaled = true;

	private const float MENU_INPUT_ACTIVATION_COOLDOWN_TIME = 0.04f;

	private const float MENU_INPUT_MOVE_COOLDOWN_TIME = 0.165f;

	private bool _allJoysticksDisconnected = true;

	private TimerSimple menuActivationInputCooldownTimer = new TimerSimple(0.04f, unscaled: true);

	private TimerSimple menuSelectionInputCooldownTimer = new TimerSimple(0.165f, unscaled: true);

	private TimerSimple menuInputCooldownTimer = new TimerSimple(1f, unscaled: true);

	private InputManager_Base _rewiredInputManager;

	private bool systemEnabled = true;

	private HashSet<int> playerActions = new HashSet<int>();

	private HashSet<int> systemActions = new HashSet<int>();

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("InputManager.Init");

	private readonly Dictionary<int, int> SwitchedActionsMappings = new Dictionary<int, int>
	{
		{ 15, 1 },
		{ 105, 0 },
		{ 68, 0 },
		{ 108, 0 },
		{ 110, 0 },
		{ 104, 0 },
		{ 112, 1 },
		{ 117, 1 },
		{ 207, 0 },
		{ 4, 0 },
		{ 6, 1 }
	};

	public bool UseSwitchStyleLayout { get; private set; }

	public TextInputInterface activeInputField { get; private set; }

	public bool inputFieldWasSetThisFrame { get; private set; }

	public bool textInputIsActive => activeInputField != null;

	public bool textInputWasActiveThisFrame { get; private set; }

	public DropdownUIElement activeDropdown { get; private set; }

	public AnimationCurve ConstantFullAnimationCurve { get; } = AnimationCurve.Constant(0f, 1f, 1f);

	public AnimationCurve LinearAscendingAnimationCurve { get; } = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve LinearDescendingAnimationCurve { get; } = AnimationCurve.Linear(0f, 1f, 1f, 0f);

	public Player system { get; private set; }

	public PlayerInput singleplayerInputModule { get; private set; }

	public bool IsAnyGamepadConnected()
	{
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers == null)
		{
			return false;
		}
		return controllers.joystickCount > 0;
	}

	public bool GetAnyButton()
	{
		return ReInput.controllers.GetAnyButton();
	}

	public bool IsDebugButtonDown(int key)
	{
		return system.GetButtonDown(key);
	}

	public bool IsDebugNoClipButtonDown()
	{
		return IsDebugButtonDown(7);
	}

	public bool IsToggleConsoleButtonDown()
	{
		return IsDebugButtonDown(72);
	}

	public bool IsToggleLightProfileDown()
	{
		return IsDebugButtonDown(96);
	}

	public bool IsToggleNetworkDebugDown()
	{
		return IsDebugButtonDown(224);
	}

	public bool LeftClickPressed()
	{
		if (systemEnabled)
		{
			if (!system.GetButton(75))
			{
				return system.GetButton(228);
			}
			return true;
		}
		return false;
	}

	public bool RightClickPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(76);
		}
		return false;
	}

	public float GetScrollValue()
	{
		if (!systemEnabled)
		{
			return 0f;
		}
		return system.GetAxis(77);
	}

	public bool IsMenuStartButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(14);
		}
		return false;
	}

	public bool IsMenuInteractButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(4);
		}
		return false;
	}

	public bool IsMenuInteractButtonPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(4);
		}
		return false;
	}

	public bool IsMenuBackButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(6);
		}
		return false;
	}

	public bool IsMenuDownButtonPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(13);
		}
		return false;
	}

	public bool IsMenuUpButtonPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(12);
		}
		return false;
	}

	public bool IsMenuRightButtonPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(11);
		}
		return false;
	}

	public bool IsMenuLeftButtonPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(10);
		}
		return false;
	}

	public bool IsMenuRightButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(11);
		}
		return false;
	}

	public bool IsMenuLeftButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(10);
		}
		return false;
	}

	public bool IsPasteButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(71);
		}
		return false;
	}

	public bool IsMenuMouseInteractButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(61);
		}
		return false;
	}

	public bool IsMenuMouseInteractButtonPressed()
	{
		if (systemEnabled)
		{
			return system.GetButton(61);
		}
		return false;
	}

	public bool IsMenuLeftShoulderButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(73);
		}
		return false;
	}

	public bool IsMenuRightShoulderButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(74);
		}
		return false;
	}

	public bool IsMenuChoosePreviousButtonDown()
	{
		if (!systemEnabled || !system.GetButtonDown(73))
		{
			return system.GetAxis(77) < -0.5f;
		}
		return true;
	}

	public bool IsMenuChooseNextButtonDown()
	{
		if (!systemEnabled || !system.GetButtonDown(74))
		{
			return system.GetAxis(77) > 0.5f;
		}
		return true;
	}

	public bool IsRefreshButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(222);
		}
		return false;
	}

	public bool IsOpenProfileButtonDown()
	{
		if (systemEnabled)
		{
			return system.GetButtonDown(223);
		}
		return false;
	}

	public bool SystemPrefersKeyboardAndMouse()
	{
		Controller controller = system?.controllers?.GetLastActiveController();
		if (controller != null)
		{
			if (controller.type != ControllerType.Keyboard && controller.type != ControllerType.Mouse)
			{
				return touchpadInUse;
			}
			return true;
		}
		return true;
	}

	public bool SystemIsUsingMouse()
	{
		Controller lastActiveController = system.controllers.GetLastActiveController();
		if (lastActiveController == null)
		{
			return false;
		}
		return lastActiveController.type == ControllerType.Mouse;
	}

	public bool SystemIsUsingKeyboard()
	{
		Controller lastActiveController = system.controllers.GetLastActiveController();
		if (lastActiveController == null)
		{
			return false;
		}
		return lastActiveController.type == ControllerType.Keyboard;
	}

	public ControllerPlatformType GetActiveControllerPlatformType(bool checkSystemInput)
	{
		if (Manager.input == null || (!checkSystemInput && (Manager.input.singleplayerInputModule == null || Manager.input.singleplayerInputModule.rewiredPlayer == null)) || (checkSystemInput && Manager.input.system == null))
		{
			return ControllerPlatformType.Keyboard;
		}
		Controller lastActiveController = (checkSystemInput ? Manager.input.system : Manager.input.singleplayerInputModule.rewiredPlayer).controllers.GetLastActiveController();
		if (lastActiveController == null)
		{
			return ControllerPlatformType.Keyboard;
		}
		ControllerType type = lastActiveController.type;
		string text = lastActiveController.name;
		switch (type)
		{
		case ControllerType.Keyboard:
			return ControllerPlatformType.Keyboard;
		case ControllerType.Mouse:
			return ControllerPlatformType.Mouse;
		case ControllerType.Joystick:
			if (text.StartsWith(SonyDualSensePrefix))
			{
				return ControllerPlatformType.Playstation5Controller;
			}
			if (text.StartsWith(SonyDualShockPrefix) || text.StartsWith(SonyPrefix))
			{
				return ControllerPlatformType.Playstation4Controller;
			}
			if (text.StartsWith(NintendoPrefix))
			{
				return ControllerPlatformType.NintendoSwitchController;
			}
			return ControllerPlatformType.XboxController;
		default:
			return ControllerPlatformType.Keyboard;
		}
	}

	public void SetActiveInputField(TextInputInterface _activeInputField)
	{
		activeInputField = _activeInputField;
		inputFieldWasSetThisFrame = activeInputField != null;
	}

	public void SetActiveDropdown(DropdownUIElement _activeDropdown)
	{
		activeDropdown = _activeDropdown;
	}

	public Direction MenuInputDirection()
	{
		if (IsMenuUpButtonPressed())
		{
			return Direction.forward;
		}
		if (IsMenuRightButtonPressed())
		{
			return Direction.right;
		}
		if (IsMenuDownButtonPressed())
		{
			return Direction.back;
		}
		if (IsMenuLeftButtonPressed())
		{
			return Direction.left;
		}
		return Direction.zero;
	}

	public bool IsMenuInputEnabled()
	{
		if (menuInputCooldownTimer.isRunning)
		{
			return menuInputCooldownTimer.isTimerElapsed;
		}
		return true;
	}

	public void StartMenuInputCooldown(float cooldownTime)
	{
		menuInputCooldownTimer.Start(cooldownTime);
	}

	public void StartMenuActivationInputCooldown()
	{
		menuActivationInputCooldownTimer.Start();
	}

	public bool IsMenuActivationInputOnCooldown()
	{
		if (menuActivationInputCooldownTimer.isRunning)
		{
			return !menuActivationInputCooldownTimer.isTimerElapsed;
		}
		return false;
	}

	public void StartMenuSelectionInputCooldown()
	{
		menuSelectionInputCooldownTimer.Start();
	}

	public bool IsMenuSelectionInputOnCooldown()
	{
		if (menuSelectionInputCooldownTimer.isRunning)
		{
			return !menuSelectionInputCooldownTimer.isTimerElapsed;
		}
		return false;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			InputManager_Base original = Resources.Load<InputManager_Base>("Rewired Input Manager");
			_rewiredInputManager = Object.Instantiate(original);
			if (_rewiredInputManager.gameObject.activeSelf)
			{
				Debug.LogError("InputManager.Init: Rewired input manager prefab GameObject is active! This will cause a nullref later on with the user data store as it is initialized on Awake and can't be initialized manually.");
			}
			InitializeControlMappingUserDataStore();
			_rewiredInputManager.gameObject.SetActive(value: true);
			foreach (InputAction action in ReInput.mapping.Actions)
			{
				InputCategory actionCategory = ReInput.mapping.GetActionCategory(action.categoryId);
				if (action.id == 77)
				{
					systemActions.Add(action.id);
				}
				else if (actionCategory.tag.Equals("player"))
				{
					playerActions.Add(action.id);
				}
				else if (actionCategory.tag.Equals("system"))
				{
					systemActions.Add(action.id);
				}
			}
			system = ReInput.players.GetSystemPlayer();
			Player player = ReInput.players.GetPlayer(0);
			singleplayerInputModule = new PlayerInput(player);
			UseSwitchStyleLayout = false;
			AssignJoysticksToSingleplayerInputModule();
			ReInput.ControllerConnectedEvent += OnControllerConnected;
			ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
			return true;
		}
	}

	private void InitializeControlMappingUserDataStore()
	{
		UserDataStore_File userDataStore_File = _rewiredInputManager.gameObject.AddComponent<UserDataStore_File>();
		userDataStore_File.fileName = "CoreKeeper_Controls.json";
		userDataStore_File.loadDataOnStart = false;
		userDataStore_File.isEnabled = false;
		userDataStore_File.loadJoystickAssignments = false;
		userDataStore_File.loadKeyboardAssignments = false;
		userDataStore_File.loadMouseAssignments = false;
	}

	public IUserDataStore GetRewiredUserDataStore()
	{
		return _rewiredInputManager.GetComponent<UserDataStore_File>();
	}

	private void OnControllerConnected(ControllerStatusChangedEventArgs args)
	{
		Debug.Log($"Controller connected: {args.name} type: {args.controllerType} id: {args.controllerId}");
		if (args.controllerType == ControllerType.Joystick)
		{
			system.controllers.AddController<Joystick>(args.controllerId, removeFromOtherPlayers: false);
		}
	}

	private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		Debug.Log($"Controller disconnected: {args.name} type: {args.controllerType} id: {args.controllerId}");
	}

	private void ChangeLayout(Joystick joystick, string mapCategory, string oldLayout, string newLayout)
	{
		foreach (Player allPlayer in ReInput.players.AllPlayers)
		{
			if (!allPlayer.controllers.ContainsController(joystick))
			{
				continue;
			}
			allPlayer.controllers.maps.RemoveMap<JoystickMap>(joystick.id, mapCategory, oldLayout);
			if (allPlayer.controllers.maps.GetMap<JoystickMap>(joystick.id, mapCategory, newLayout) == null)
			{
				allPlayer.controllers.maps.LoadMap<JoystickMap>(joystick.id, mapCategory, newLayout);
				if (allPlayer.controllers.maps.GetMap<JoystickMap>(joystick.id, mapCategory, newLayout) == null)
				{
					Debug.Log("Loading controller map resulted in null.");
				}
				allPlayer.controllers.maps.SetMapsEnabled(state: true, ControllerType.Joystick, mapCategory, newLayout);
				Debug.Log("Assign layout: " + allPlayer.name + ", " + joystick.name + ", " + mapCategory + ", " + (string.IsNullOrWhiteSpace(oldLayout) ? "NA" : oldLayout) + " -> " + (string.IsNullOrWhiteSpace(newLayout) ? "NA" : newLayout));
			}
		}
	}

	public void SetTouchpadMapsEnabled(bool enable)
	{
		string oldLayout = (enable ? "" : "Playstation");
		string newLayout = (enable ? "Playstation" : "");
		foreach (Joystick joystick in ReInput.controllers.Joysticks)
		{
			system.controllers.AddController<Joystick>(joystick.id, removeFromOtherPlayers: false);
			ChangeLayout(joystick, "Default", oldLayout, newLayout);
			ChangeLayout(joystick, "Menu", oldLayout, newLayout);
			ChangeLayout(joystick, "Inventory", oldLayout, newLayout);
			ChangeLayout(joystick, "Ingame", oldLayout, newLayout);
			ChangeLayout(joystick, "MapView", oldLayout, newLayout);
			ChangeLayout(joystick, "Vehicle", oldLayout, newLayout);
		}
	}

	public void AssignJoysticksToSingleplayerInputModule()
	{
		singleplayerInputModule.rewiredPlayer.controllers.ClearControllersOfType<Joystick>();
		singleplayerInputModule.rewiredPlayer.controllers.excludeFromControllerAutoAssignment = false;
		system.controllers.ClearControllersOfType<Joystick>();
		ReInput.controllers.AutoAssignJoysticks();
		foreach (Joystick joystick in ReInput.controllers.Joysticks)
		{
			system.controllers.AddController<Joystick>(joystick.id, removeFromOtherPlayers: false);
		}
	}

	public void Update()
	{
		singleplayerInputModule.UpdateState();
		if (Manager.DEBUG_MODE && !textInputIsActive)
		{
			_ = Manager.menu.isConsoleActive;
		}
	}

	private void LateUpdate()
	{
		inputFieldWasSetThisFrame = false;
		textInputWasActiveThisFrame = textInputIsActive;
	}

	public void DisableInput(float duration = -1f)
	{
		singleplayerInputModule.DisableInputFor(duration);
	}

	public void EnableInput()
	{
		singleplayerInputModule.EnableInput();
	}

	public void DisableSystemInput()
	{
		systemEnabled = false;
	}

	public void EnableSystemInput()
	{
		systemEnabled = true;
	}

	public bool IsSystemInputEnabled()
	{
		return systemEnabled;
	}

	public bool GetButton(int action)
	{
		if (playerActions.Contains(action))
		{
			return singleplayerInputModule.rewiredPlayer.GetButton(action);
		}
		if (systemActions.Contains(action))
		{
			return system.GetButton(action);
		}
		return false;
	}

	public bool GetButtonDown(int action)
	{
		if (playerActions.Contains(action))
		{
			return singleplayerInputModule.rewiredPlayer.GetButtonDown(action);
		}
		if (systemActions.Contains(action))
		{
			return system.GetButtonDown(action);
		}
		return false;
	}

	public bool GetButtonUp(int action)
	{
		if (playerActions.Contains(action))
		{
			return singleplayerInputModule.rewiredPlayer.GetButtonUp(action);
		}
		if (systemActions.Contains(action))
		{
			return system.GetButtonUp(action);
		}
		return false;
	}

	public float GetAxis(int action)
	{
		if (playerActions.Contains(action))
		{
			return singleplayerInputModule.rewiredPlayer.GetAxis(action);
		}
		if (systemActions.Contains(action))
		{
			return system.GetAxis(action);
		}
		return 0f;
	}

	public void EnableControlMap(string mapCategoryName, bool disableOtherMaps = false, bool disableDefaultMap = false, Player player = null)
	{
		if (player == null)
		{
			player = ReInput.players.GetPlayer(0);
		}
		if (player != null)
		{
			if (disableOtherMaps)
			{
				EnableAllControlMapsWithTag(enable: false, "gameplay", player);
			}
			if (disableDefaultMap)
			{
				DisableControlMap("Default", player);
			}
			string activeControllerLayoutName = GetActiveControllerLayoutName();
			player.controllers.maps.SetMapsEnabled(state: true, mapCategoryName, activeControllerLayoutName);
		}
	}

	public void DisableControlMap(string mapCategoryName, Player player = null)
	{
		if (player == null)
		{
			player = ReInput.players.GetPlayer(0);
		}
		if (player != null)
		{
			string activeControllerLayoutName = GetActiveControllerLayoutName();
			player.controllers.maps.SetMapsEnabled(state: false, mapCategoryName, activeControllerLayoutName);
		}
	}

	public void EnableAllControlMapsWithTag(bool enable, string tagString, Player player = null)
	{
		if (player == null)
		{
			player = ReInput.players.GetPlayer(0);
		}
		if (player == null)
		{
			return;
		}
		foreach (InputMapCategory item in ReInput.mapping.MapCategories.Where((InputMapCategory x) => x.tag.Contains(tagString)))
		{
			if (enable)
			{
				EnableControlMap(item.name, disableOtherMaps: false, disableDefaultMap: false, player);
			}
			else
			{
				DisableControlMap(item.name, player);
			}
		}
	}

	private string GetActiveControllerLayoutName()
	{
		if (!UseSwitchStyleLayout)
		{
			return "Default";
		}
		return "NintendoSwitch";
	}
}
