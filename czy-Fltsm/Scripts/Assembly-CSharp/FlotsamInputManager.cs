using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using Rewired;
using Rewired.Integration.UnityUI;
using RewiredConsts;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlotsamInputManager : MonoBehaviour
{
	public enum Layouts
	{
		World = 0,
		Map = 1
	}

	public const float CLICK_INTERVAL = 0.15f;

	[SerializeField]
	private RewiredStandaloneInputModule _inputModule;

	[Header("Joystick")]
	[SerializeField]
	private JoystickMouseInputSource.Mode _joystickMouseMode = JoystickMouseInputSource.Mode.Cumulative;

	[SerializeField]
	private float _joystickMouseCumulativeMultiplier = 1920f;

	[Header("Camera Input Settings")]
	[Tooltip("The horizontal rotation speed for keyboard and joystick.")]
	[SerializeField]
	private float _horizontalRotationSpeed = 400f;

	[Tooltip("The horizontal rotation speed for mouse")]
	private float _horizontalRotationSpeedMouse = 60f;

	[Header("Hotkey Actions")]
	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _gameMenuAction;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _cycleDriftersAction;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _leftShiftAction;

	[SerializeField]
	[ActionIdProperty(typeof(RewiredConsts.Action))]
	private int _mouseCancelActionID;

	[SerializeField]
	private float _mouseCancelActionTabExpireIn = 0.7f;

	[SerializeField]
	private RewiredGlyphProvider _glyphProvider;

	[Header("Debug")]
	[SerializeField]
	private bool _forceGamePad;

	private static FlotsamInputManager _instance;

	private bool _mapCameraToTownheartMovementInput;

	private JoystickMouseInputSource _joystickMouseInputSource;

	private Controller _activeController;

	private List<ICancelable> _cancelStack = new List<ICancelable>(4);

	private bool _forceMouseAndKeyboard;

	private Vector3 _mouseCancelDownCameraPosition;

	public static bool Initialized { get; private set; } = false;

	public static Rewired.Player RewiredPlayer { get; private set; }

	public static InputFlags ActiveInput { get; private set; } = InputFlags.MouseAndKeyboard;

	public static Vector3 MousePosition
	{
		get
		{
			if (IsJoystickMouse)
			{
				return _instance._joystickMouseInputSource.screenPosition;
			}
			if (IsJoystick)
			{
				return new Vector3(Screen.width / 2, Screen.height / 2, 0f);
			}
			return Input.mousePosition;
		}
	}

	public static bool IsJoystick => (ActiveInput & InputFlags.Joystick) != 0;

	public static bool IsJoystickMouse => false;

	public static bool MapCameraToTownheartMovementInput
	{
		get
		{
			if ((bool)_instance)
			{
				return _instance._mapCameraToTownheartMovementInput;
			}
			return false;
		}
	}

	public static float RepeatDelay
	{
		get
		{
			if (!(_instance == null))
			{
				return _instance._inputModule.repeatDelay;
			}
			return 0f;
		}
	}

	public static float InputActionsPerSecond
	{
		get
		{
			if (!(_instance == null))
			{
				return _instance._inputModule.inputActionsPerSecond;
			}
			return 0f;
		}
	}

	public static bool HasKeyboard
	{
		get
		{
			if (RewiredPlayer != null)
			{
				return RewiredPlayer.controllers.hasKeyboard;
			}
			return true;
		}
	}

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			Initialize();
		}
		base.enabled = _instance == this;
	}

	private void Start()
	{
		i_SetForceMouseAndKeyboard(Settings.Instance.GameplayPlayerData.ForceMouseAndKeyboard, force: true);
	}

	private void Update()
	{
		GameManager instance = GameManager.Instance;
		if (instance == null || instance.IntroScene || LoadingScreen.IsLoading || !instance.InitializeEnvironment || GameManager.UIManager == null || GameManager.UIManager.UIState == UIState.Typing || GUIUtility.hotControl != 0)
		{
			return;
		}
		HotkeyControls();
		bool flag = GetButtonDown(_gameMenuAction);
		if (GetUICancel())
		{
			int count = _cancelStack.Count;
			if (0 < count)
			{
				ICancelable cancelable = _cancelStack[--count];
				if (cancelable.TryCancel())
				{
					_cancelStack.Remove(cancelable);
				}
				flag = false;
			}
		}
		if (flag)
		{
			GameManager.UIManager.OpenGameMenu();
		}
	}

	private void OnDestroy()
	{
		if (RewiredPlayer != null)
		{
			RewiredPlayer.controllers.RemoveLastActiveControllerChangedDelegate(SetActiveController);
		}
	}

	public void Initialize()
	{
		RewiredPlayer = ReInput.players.GetPlayer(0);
		Controller firstControllerWithTemplate = RewiredPlayer.controllers.GetFirstControllerWithTemplate(GamepadTemplate.typeGuid);
		if (firstControllerWithTemplate == null)
		{
			SetActiveController(RewiredPlayer, RewiredPlayer.controllers.Keyboard);
		}
		else
		{
			SetActiveController(RewiredPlayer, firstControllerWithTemplate);
		}
		Initialized = true;
	}

	public static void SetForceMouseAndKeyboard(bool forceMouseAndKeyboard)
	{
		if ((bool)_instance)
		{
			_instance.i_SetForceMouseAndKeyboard(forceMouseAndKeyboard);
		}
	}

	private void i_SetForceMouseAndKeyboard(bool forceMouseAndKeyboard, bool force = false)
	{
		forceMouseAndKeyboard = forceMouseAndKeyboard && HasKeyboard;
		if (_forceMouseAndKeyboard != forceMouseAndKeyboard || force)
		{
			_forceMouseAndKeyboard = forceMouseAndKeyboard;
			if (_forceMouseAndKeyboard)
			{
				RewiredPlayer.controllers.RemoveLastActiveControllerChangedDelegate(SetActiveController);
				ReInput.ControllerConnectedEvent -= ReInput_ControllerConnectedEvent;
				ReInput.ControllerDisconnectedEvent -= ReInput_ControllerDisconnectedEvent;
				SetActiveController(RewiredPlayer, RewiredPlayer.controllers.Keyboard);
			}
			else
			{
				RewiredPlayer.controllers.AddLastActiveControllerChangedDelegate(SetActiveController);
				ReInput.ControllerConnectedEvent += ReInput_ControllerConnectedEvent;
				ReInput.ControllerDisconnectedEvent += ReInput_ControllerDisconnectedEvent;
			}
		}
	}

	private void SetActiveController(Rewired.Player player, Controller controller)
	{
		if (controller == null || controller == _activeController || UIManager.State == UIState.Typing)
		{
			return;
		}
		InputFlags activeInput = InputFlags.None;
		switch (controller.type)
		{
		case ControllerType.Keyboard:
		case ControllerType.Mouse:
			controller = RewiredPlayer.controllers.Keyboard;
			activeInput = InputFlags.MouseAndKeyboard;
			EventSystem.current?.SetSelectedGameObject(null);
			Cursor.lockState = CursorLockMode.None;
			break;
		case ControllerType.Joystick:
			if (!controller.ImplementsTemplate(GamepadTemplate.typeGuid))
			{
				controller = _activeController;
			}
			Cursor.lockState = CursorLockMode.Locked;
			activeInput = InputFlags.Joystick;
			break;
		}
		if (_activeController != controller)
		{
			_activeController = controller;
			ActiveInput = activeInput;
			GameEventDispatcher.Dispatch(GameEventType.ActiveInputUpdated);
		}
	}

	private void ReInput_ControllerConnectedEvent(ControllerStatusChangedEventArgs obj)
	{
		if (ActiveInput != InputFlags.Joystick && TryGetActiveJoystickWithTemplate(GamepadTemplate.typeGuid, out var joystick))
		{
			SetActiveController(RewiredPlayer, joystick);
		}
	}

	private void ReInput_ControllerDisconnectedEvent(ControllerStatusChangedEventArgs obj)
	{
		if (ActiveInput == InputFlags.Joystick && !TryGetActiveJoystickWithTemplate(GamepadTemplate.typeGuid, out var _))
		{
			SetActiveController(RewiredPlayer, RewiredPlayer.controllers.Keyboard);
		}
	}

	private IEnumerator AddJoystickMouseInputSource()
	{
		if (_joystickMouseInputSource == null)
		{
			EventSystem current = EventSystem.current;
			while (current == null || current.currentInputModule == null || !ReInput.isReady)
			{
				yield return null;
			}
			_joystickMouseInputSource = new JoystickMouseInputSource(_joystickMouseMode, _joystickMouseCumulativeMultiplier);
		}
		if (EventSystem.current.currentInputModule is RewiredStandaloneInputModule rewiredStandaloneInputModule)
		{
			rewiredStandaloneInputModule.AddMouseInputSource(_joystickMouseInputSource);
			ActiveInput = InputFlags.Joystick;
			GameEventDispatcher.Dispatch(GameEventType.ActiveInputUpdated);
			Settings.Instance.GameplayPlayerData.SnapBuilding = true;
			Settings.Instance.GameplayPlayerData.ShowBuildingGrid = true;
		}
	}

	private void RemoveJoystickMouseInputSource()
	{
		if (_joystickMouseInputSource != null && EventSystem.current.currentInputModule is RewiredStandaloneInputModule rewiredStandaloneInputModule)
		{
			rewiredStandaloneInputModule.RemoveMouseInputSource(_joystickMouseInputSource);
			ActiveInput = InputFlags.MouseAndKeyboard;
			EventSystem.current.SetSelectedGameObject(null);
			GameEventDispatcher.Dispatch(GameEventType.ActiveInputUpdated);
		}
	}

	private void HotkeyControls()
	{
		if (!GameManager.Gamepaused && RewiredPlayer.GetButtonDown(_cycleDriftersAction))
		{
			Community.PlayerCommunity.CycleAgents(RewiredPlayer.GetButton(_leftShiftAction));
		}
	}

	private Vector4 Internal_GetCameraInput(Layouts layout)
	{
		Vector4 result = layout switch
		{
			Layouts.World => RewiredActions.ReturnWorldCameraMovementInput(), 
			Layouts.Map => (!_mapCameraToTownheartMovementInput && !UIManager.HasFlagsSet(PanelContainerFlags.BlockCameraInput)) ? ((Vector4)RewiredActions.ReturnMapCameraMovementInput()) : default(Vector4), 
			_ => throw new NotImplementedException(), 
		};
		result.z = Internal_GetCameraRotation() * _horizontalRotationSpeed;
		if (GetButton(150))
		{
			result.z += GetAxis(145) * _horizontalRotationSpeedMouse;
			result.w = GetAxis(146);
		}
		return result;
	}

	private float Internal_GetCameraRotation()
	{
		float num = RewiredPlayer.GetAxisRaw(2) - RewiredPlayer.GetAxisRaw(33);
		if (IsJoystick)
		{
			return ApplyDeadzone(num, 0.3f);
		}
		return num;
	}

	private float Internal_GetCameraZoom()
	{
		float axisRaw = RewiredPlayer.GetAxisRaw(89);
		if (HasActiveInput(InputFlags.Joystick))
		{
			return ApplyDeadzone(axisRaw, 0.5f);
		}
		return axisRaw;
	}

	private float ApplyDeadzone(float value, float deadzone)
	{
		deadzone = Mathf.Clamp01(deadzone);
		if (deadzone < 1f)
		{
			float num = 1f - deadzone;
			if (value > deadzone)
			{
				return Mathf.Clamp01(value - deadzone) / num;
			}
			if (value < 0f - deadzone)
			{
				return Mathf.Clamp(value + deadzone, -1f, 0f) / num;
			}
		}
		return 0f;
	}

	private bool TryGetActiveJoystickWithTemplate(Guid templateGuid, out Joystick joystick)
	{
		joystick = RewiredPlayer.controllers.GetLastActiveController<Joystick>() as Joystick;
		if (joystick != null && joystick.ImplementsTemplate(templateGuid))
		{
			return true;
		}
		if (RewiredPlayer.controllers.GetFirstControllerWithTemplate(templateGuid) is Joystick joystick2)
		{
			joystick = joystick2;
		}
		return joystick != null;
	}

	public static void PushCancelable(ICancelable cancelable)
	{
		if ((bool)_instance)
		{
			_instance._cancelStack.AddUnique(cancelable);
		}
	}

	public static void RemoveCancelable(ICancelable cancelable)
	{
		if ((bool)_instance)
		{
			_instance._cancelStack.Remove(cancelable);
		}
	}

	public static bool HasActiveInput(InputFlags inputFlags)
	{
		return (ActiveInput & inputFlags) != 0;
	}

	public static Controller GetActiveController()
	{
		if (_instance == null || RewiredPlayer == null)
		{
			return null;
		}
		return _instance._activeController;
	}

	public static bool GetAnyButtonUp()
	{
		if (!GetAnyButtonUp(GetActiveController()) && !GetAnyButtonUp(RewiredPlayer.controllers.Keyboard))
		{
			return GetAnyButtonUp(RewiredPlayer.controllers.Mouse);
		}
		return true;
	}

	private static bool GetAnyButtonUp(Controller controller)
	{
		return controller?.GetAnyButtonUp() ?? false;
	}

	public static ActionElementMap GetFirstElementMapWithAction(Controller controller, int actionId, bool skipDisabledMaps = true)
	{
		return RewiredPlayer.controllers.maps.GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps);
	}

	public static ActionElementMap GetFirstAxisMapWithAction(Controller controller, int actionId, bool skipDisabledMaps = true)
	{
		return RewiredPlayer.controllers.maps.GetFirstAxisMapWithAction(controller, actionId, skipDisabledMaps);
	}

	public static ActionElementMap GetFirstButtonMapWithAction(Controller controller, int actionId, bool skipDisabledMaps = true)
	{
		return RewiredPlayer.controllers.maps.GetFirstButtonMapWithAction(controller, actionId, skipDisabledMaps);
	}

	public static ActionElementMap GetFirstMouseMapWithAction(int actionId, bool skipDisabledMaps = true)
	{
		return RewiredPlayer.controllers.maps.GetFirstElementMapWithAction(RewiredPlayer.controllers.Mouse, actionId, skipDisabledMaps);
	}

	public static ActionElementMap GetFirstKeyboardMapWithAction(int actionId, bool skipDisabledMaps = true)
	{
		return RewiredPlayer.controllers.maps.GetFirstButtonMapWithAction(RewiredPlayer.controllers.Keyboard, actionId, skipDisabledMaps);
	}

	public static bool TryActiveControllerActionKeyCode(int actionId, out KeyCode keyCode)
	{
		Controller activeController = GetActiveController();
		keyCode = KeyCode.None;
		GetActiveController();
		if (activeController.type == ControllerType.Keyboard)
		{
			ActionElementMap firstKeyboardMapWithAction = GetFirstKeyboardMapWithAction(actionId);
			if (firstKeyboardMapWithAction != null)
			{
				keyCode = firstKeyboardMapWithAction.keyCode;
			}
		}
		return keyCode != KeyCode.None;
	}

	public static bool GetUISubmit()
	{
		if ((bool)_instance)
		{
			return RewiredPlayer.GetButtonDown(_instance._inputModule.SubmitActionId);
		}
		return false;
	}

	public static bool GetUICancel(bool ignoreAllowCancel = false)
	{
		if ((UIManager.AllowCancel || ignoreAllowCancel) && (bool)_instance)
		{
			if (!RewiredPlayer.GetButtonDown(_instance._inputModule.CancelActionId))
			{
				return _instance.GetMouseUICancel();
			}
			return true;
		}
		return false;
	}

	public bool GetMouseUICancel()
	{
		if (GetButtonDown(_instance._mouseCancelActionID))
		{
			_mouseCancelDownCameraPosition = CameraController.MainCameraPosition;
		}
		else if (RewiredPlayer.GetButtonTimedPressUp(_mouseCancelActionID, 0f, _mouseCancelActionTabExpireIn) && !CursorManager.WasActiveThisFrame() && !EventSystem.current.IsPointerOverGameObject() && _mouseCancelDownCameraPosition.DistanceToLeveled(CameraController.MainCameraPosition) < 0.25f)
		{
			return true;
		}
		return false;
	}

	public static bool IsMappedToUICancel(int actionId)
	{
		if (_instance != null)
		{
			return AreActionElementsEqual(_instance._activeController, actionId, _instance._inputModule.CancelActionId);
		}
		return false;
	}

	public static bool AreActionElementsEqual(Controller controller, int ActionId, int otherActionId)
	{
		using ListPool<ActionElementMap>.List list = ListPool<ActionElementMap>.Get();
		ActionElementMap firstElementMapWithAction = GetFirstElementMapWithAction(controller, ActionId);
		RewiredPlayer.controllers.maps.GetElementMapsWithAction(otherActionId, skipDisabledMaps: true, list);
		if (firstElementMapWithAction == null)
		{
			return false;
		}
		foreach (ActionElementMap item in list)
		{
			if (item != null && firstElementMapWithAction.elementIdentifierId == item.elementIdentifierId)
			{
				return true;
			}
		}
		return false;
	}

	public static Vector2 GetLeftStick()
	{
		return RewiredPlayer.GetAxis2DRaw(103, 104);
	}

	public static Vector2 GetRightStick()
	{
		return RewiredPlayer.GetAxis2DRaw(105, 106);
	}

	public static float GetAxis(int actionId)
	{
		return RewiredPlayer.GetAxis(actionId);
	}

	public static float GetAxisRaw(int actionId)
	{
		return RewiredPlayer.GetAxisRaw(actionId);
	}

	public static Vector2 GetAxis(int xAxisActionId, int yAxisActionId)
	{
		return RewiredPlayer.GetAxis2D(xAxisActionId, yAxisActionId);
	}

	public static bool GetButton(int actionId)
	{
		return RewiredPlayer.GetButton(actionId);
	}

	public static bool GetAnyButton(params int[] actionIds)
	{
		foreach (int actionId in actionIds)
		{
			if (RewiredPlayer.GetButton(actionId))
			{
				return true;
			}
		}
		return false;
	}

	public static bool GetButtonDown(int actionId)
	{
		return RewiredPlayer.GetButtonDown(actionId);
	}

	public static bool GetButtonRepeating(int actionId)
	{
		return RewiredPlayer.GetButtonRepeating(actionId);
	}

	public static bool GetButtonUp(int actionId)
	{
		return RewiredPlayer.GetButtonUp(actionId);
	}

	public static bool GetButtonShortPress(int actionId)
	{
		return RewiredPlayer.GetButtonShortPress(actionId);
	}

	public static bool GetButtonLongPress(int actionId)
	{
		return RewiredPlayer.GetButtonLongPress(actionId);
	}

	public static bool GetButtonDoublePressUp(int actionId)
	{
		return RewiredPlayer.GetButtonDoublePressUp(actionId);
	}

	public static bool GetButtonTimedPress(int actionId, float time)
	{
		return RewiredPlayer.GetButtonTimedPress(actionId, time);
	}

	public static Vector4 GetCameraInput(Layouts layout)
	{
		if (!TryGetInstance(out var instance))
		{
			return Vector4.zero;
		}
		return instance.Internal_GetCameraInput(layout);
	}

	public static float GetCameraRotation()
	{
		if (!TryGetInstance(out var instance))
		{
			return 0f;
		}
		return instance.Internal_GetCameraRotation();
	}

	public static float GetCameraZoom()
	{
		if (!TryGetInstance(out var instance))
		{
			return 0f;
		}
		return instance.Internal_GetCameraZoom();
	}

	public static Vector2 GetMovementInput(RewiredAction rotateLeft, RewiredAction rotateRight, RewiredAction backward, RewiredAction forward)
	{
		Vector2 vector = default(Vector2);
		if (TryGetInstance(out var instance))
		{
			vector = new Vector2(0f - rotateLeft.GetAxisRaw() + rotateRight.GetAxisRaw(), 0f - backward.GetAxisRaw() + forward.GetAxisRaw());
			if (instance._mapCameraToTownheartMovementInput)
			{
				return vector + RewiredActions.ReturnMapCameraMovementInput();
			}
		}
		return vector;
	}

	public static bool ReturnCameraTownheartMovementInput()
	{
		if (TryGetInstance(out var instance))
		{
			return instance._mapCameraToTownheartMovementInput;
		}
		return false;
	}

	public static void ToggleCameraTownheartMovementInputToggle(bool active)
	{
		if (TryGetInstance(out var instance))
		{
			instance._mapCameraToTownheartMovementInput = active;
		}
	}

	public static void ResetCameraTownheartMovementInputToggle()
	{
		if (TryGetInstance(out var instance))
		{
			instance._mapCameraToTownheartMovementInput = false;
		}
	}

	private static bool TryGetInstance(out FlotsamInputManager instance)
	{
		instance = _instance;
		return instance != null;
	}

	public static string GetButtonKeyCodeString(string actionName, string fallback = "[Unbound]")
	{
		ActionElementMap firstButtonMapWithAction = RewiredPlayer.controllers.maps.GetFirstButtonMapWithAction(actionName, skipDisabledMaps: true);
		if (firstButtonMapWithAction != null)
		{
			return firstButtonMapWithAction.keyCode.ToString();
		}
		return fallback;
	}
}
