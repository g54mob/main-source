using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
	[SerializeField]
	private PlayerInput playerInput;

	[SerializeField]
	public PlayerController PlayerController;

	[SerializeField]
	private float selectTapThreshold = 0.3f;

	private Coroutine selectHoldCoroutine;

	private bool selectHoldTriggered;

	private float _inputUpdateTimeout;

	private string currentScheme = "";

	private Vector2 lastMousePosSwitch;

	private Vector2 lastMousePosNotify;

	private float gamepadThreshold = 0.3f;

	private float mouseThreshold = 0.1f;

	private InputDevice currentDevice;

	public static Action<int, ControllerType> OnAnyInputDetected;

	private ControllerType _lastControllerUsed = ControllerType.KeyboardMouse;

	public PlayerInput PlayerInput => playerInput;

	public int PlayerIndex => playerInput?.playerIndex ?? (-1);

	public ControllerType controllerType { get; private set; }

	public bool IsGamepad
	{
		get
		{
			if (!(playerInput?.currentControlScheme == "GamepadXBox") && !(playerInput?.currentControlScheme == "GamepadPS4") && !(playerInput?.currentControlScheme == "GamepadPS5"))
			{
				return playerInput?.currentControlScheme == "GamepadPS";
			}
			return true;
		}
	}

	public Vector2 MoveInput => playerInput.actions["Move"].ReadValue<Vector2>();

	public Vector2 AimInput => playerInput.actions["Aim"].ReadValue<Vector2>();

	public Vector2 DpadInput => playerInput.actions["Dpad"].ReadValue<Vector2>();

	public Vector2 UIInput
	{
		get
		{
			if (!(MoveInput != Vector2.zero))
			{
				return DpadInput;
			}
			return MoveInput;
		}
	}

	public Vector2 UIInputStick
	{
		get
		{
			if (!(MoveInput != Vector2.zero))
			{
				return Vector2.zero;
			}
			return MoveInput;
		}
	}

	public Vector2 UIInputDpad
	{
		get
		{
			if (!(DpadInput != Vector2.zero))
			{
				return Vector2.zero;
			}
			return DpadInput;
		}
	}

	public Vector2 MinigameDir { get; private set; }

	public event Action<int, InputAction.CallbackContext> OnBackPressed;

	public event Action<int, InputAction.CallbackContext> OnMapPressed;

	public event Action<int, InputAction.CallbackContext> OnInventoryPressed;

	public event Action<int, InputAction.CallbackContext> OnPausePressed;

	public event Action<int, Vector2> OnPoint;

	public event Action<int, InputAction.CallbackContext> OnInteract;

	public event Action<int, InputAction.CallbackContext> OnInterrupt;

	public event Action<int, InputAction.CallbackContext> OnLB;

	public event Action<int, InputAction.CallbackContext> OnRB;

	public event Action<int, InputAction.CallbackContext> OnLT;

	public event Action<int, InputAction.CallbackContext> OnRT;

	public event Action<int, InputAction.CallbackContext> OnYPressed;

	public event Action<int, InputAction.CallbackContext> OnAPressed;

	public event Action<int, InputAction.CallbackContext> OnXPressed;

	public event Action<int, InputAction.CallbackContext> OnEnter;

	private void Start()
	{
		InputManager.Instance.Register(this);
		InputActionAsset actions = playerInput.actions;
		actions["Back"].performed += HandleBack;
		actions["Map"].performed += HandleMap;
		actions["Inventory"].performed += HandleInventory;
		actions["Pause"].performed += HandlePause;
		actions["Interact"].performed += HandleInteract;
		actions["Interrupt"].performed += HandleInterrupt;
		actions["Select"].started += OnSelectStarted;
		actions["Select"].canceled += OnSelectCanceled;
		actions["LB"].performed += HandleLB;
		actions["RB"].performed += HandleRB;
		actions["LT"].performed += HandleLT;
		actions["RT"].performed += HandleRT;
		actions["Y"].performed += HandleY;
		actions["A"].performed += HandleA;
		actions["X"].performed += HandleX;
		actions["Enter"].performed += HandleEnter;
	}

	private void OnDisable()
	{
		if (playerInput != null)
		{
			InputActionAsset actions = playerInput.actions;
			actions["Back"].performed -= HandleBack;
			actions["Map"].performed -= HandleMap;
			actions["Inventory"].performed -= HandleInventory;
			actions["Pause"].performed -= HandlePause;
			actions["Interact"].performed -= HandleInteract;
			actions["Interrupt"].performed -= HandleInterrupt;
			actions["Select"].started -= OnSelectStarted;
			actions["Select"].canceled -= OnSelectCanceled;
			actions["LB"].performed -= HandleLB;
			actions["RB"].performed -= HandleRB;
			actions["LT"].performed -= HandleLT;
			actions["RT"].performed -= HandleRT;
			actions["Y"].performed -= HandleY;
			actions["A"].performed -= HandleA;
			actions["X"].performed -= HandleX;
			actions["Enter"].performed -= HandleEnter;
			InputManager.Instance.Unregister(this, PlayerIndex);
		}
	}

	private void Update()
	{
		_inputUpdateTimeout -= Time.unscaledDeltaTime;
		if (_inputUpdateTimeout < 0f)
		{
			_inputUpdateTimeout = 0.1f;
			if (!PlayerManager.Instance.IsCoop)
			{
				TrySwitchInput();
			}
			CheckInputsNotifyOnly();
		}
	}

	public bool TrySetInput(ControllerType controllerType)
	{
		if (controllerType == ControllerType.KeyboardMouse)
		{
			AssignKeyboardAndMouse();
			return true;
		}
		if (InputSystem.devices.FirstOrDefault((InputDevice d) => d.name.Contains(StringControllerConverter.GetName(controllerType))) is Gamepad gamepad)
		{
			AssignGamepad(gamepad, onlyScheme: true, forCoop: true);
			return true;
		}
		return false;
	}

	private void TrySwitchInput()
	{
		if (Keyboard.current.anyKey.wasPressedThisFrame)
		{
			TrySwitchTo("Keyboard&Mouse");
		}
		Vector2 vector = Mouse.current.position.ReadValue();
		float magnitude = (vector - lastMousePosSwitch).magnitude;
		lastMousePosSwitch = vector;
		if (magnitude > mouseThreshold)
		{
			TrySwitchTo("Keyboard&Mouse");
		}
		if (Gamepad.current != null)
		{
			Vector2 vector2 = Gamepad.current.leftStick.ReadValue();
			Vector2 vector3 = Gamepad.current.rightStick.ReadValue();
			if (vector2.magnitude > gamepadThreshold || vector3.magnitude > gamepadThreshold)
			{
				TrySwitchTo(Gamepad.current);
			}
			if (Gamepad.current.allControls.Any((InputControl control) => control is ButtonControl && control.IsPressed()))
			{
				TrySwitchTo(Gamepad.current);
			}
		}
	}

	private void CheckInputsNotifyOnly()
	{
		if (_lastControllerUsed != ControllerType.KeyboardMouse)
		{
			if (Keyboard.current.anyKey.wasPressedThisFrame)
			{
				_lastControllerUsed = ControllerType.KeyboardMouse;
				OnAnyInputDetected?.Invoke(PlayerIndex, ControllerType.KeyboardMouse);
				return;
			}
			Vector2 vector = Mouse.current.position.ReadValue();
			float magnitude = (vector - lastMousePosNotify).magnitude;
			lastMousePosNotify = vector;
			if (magnitude > mouseThreshold)
			{
				_lastControllerUsed = ControllerType.KeyboardMouse;
				OnAnyInputDetected?.Invoke(PlayerIndex, ControllerType.KeyboardMouse);
			}
		}
		else if (Gamepad.current != null)
		{
			Vector2 vector2 = Gamepad.current.leftStick.ReadValue();
			Vector2 vector3 = Gamepad.current.rightStick.ReadValue();
			if (vector2.magnitude > gamepadThreshold || vector3.magnitude > gamepadThreshold)
			{
				_lastControllerUsed = StringControllerConverter.GetController(Gamepad.current.name);
				OnAnyInputDetected?.Invoke(PlayerIndex, StringControllerConverter.GetController(Gamepad.current.name));
			}
			else if (Gamepad.current.allControls.Any((InputControl control) => control is ButtonControl && control.IsPressed()))
			{
				_lastControllerUsed = StringControllerConverter.GetController(Gamepad.current.name);
				OnAnyInputDetected?.Invoke(PlayerIndex, StringControllerConverter.GetController(Gamepad.current.name));
			}
		}
	}

	private void TrySwitchTo(string scheme)
	{
		if (!(currentScheme == scheme))
		{
			currentScheme = scheme;
			if (scheme == "Gamepad" && Gamepad.current != null)
			{
				AssignGamepad(Gamepad.current);
			}
			else if (scheme == "Keyboard&Mouse" && Keyboard.current != null && Mouse.current != null)
			{
				AssignKeyboardAndMouse();
			}
			InputManager.Instance.NotifyDeviceChanged(PlayerIndex);
		}
	}

	private void TrySwitchTo(InputDevice newDevice)
	{
		if (currentDevice != newDevice)
		{
			if (Gamepad.current != null)
			{
				AssignGamepad(Gamepad.current);
			}
			else if (Keyboard.current != null && Mouse.current != null)
			{
				AssignKeyboardAndMouse();
			}
			InputManager.Instance.NotifyDeviceChanged(PlayerIndex);
		}
	}

	public void AssignKeyboardAndMouse(bool onlyScheme = true, bool forCoop = false)
	{
		Keyboard current = Keyboard.current;
		Mouse current2 = Mouse.current;
		if (current != null && current2 != null)
		{
			playerInput.user.UnpairDevices();
			InputUser.PerformPairingWithDevice(current, playerInput.user);
			InputUser.PerformPairingWithDevice(current2, playerInput.user);
			controllerType = ControllerType.KeyboardMouse;
			if (onlyScheme)
			{
				playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", current, current2);
			}
			currentDevice = current;
			currentScheme = "Keyboard&Mouse";
		}
	}

	public void AssignGamepad(Gamepad gamepad, bool onlyScheme = true, bool forCoop = false)
	{
		string controlScheme = "";
		if (gamepad.name.Contains("XInput"))
		{
			controllerType = ControllerType.GamepadXBox;
			controlScheme = "GamepadXBox";
		}
		else if (gamepad.name.Contains("DualShock"))
		{
			controllerType = ControllerType.GamepadPS4;
			controlScheme = "GamepadPS4";
		}
		else if (gamepad.name.Contains("DualSense"))
		{
			controllerType = ControllerType.GamepadPS5;
			controlScheme = "GamepadPS5";
		}
		playerInput.user.UnpairDevices();
		InputUser.PerformPairingWithDevice(gamepad, playerInput.user);
		if (onlyScheme)
		{
			playerInput.SwitchCurrentControlScheme(controlScheme, gamepad);
		}
		currentDevice = gamepad;
		currentScheme = "Gamepad";
	}

	private void HandleBack(InputAction.CallbackContext ctx)
	{
		this.OnBackPressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandleMap(InputAction.CallbackContext ctx)
	{
		this.OnMapPressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandleInventory(InputAction.CallbackContext ctx)
	{
		this.OnInventoryPressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandlePause(InputAction.CallbackContext ctx)
	{
		this.OnPausePressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandleMinigame(InputAction.CallbackContext ctx)
	{
		MinigameDir = ctx.ReadValue<Vector2>();
	}

	private void HandlePoint(InputAction.CallbackContext ctx)
	{
		this.OnPoint?.Invoke(PlayerIndex, ctx.ReadValue<Vector2>());
	}

	private void HandleLB(InputAction.CallbackContext ctx)
	{
		this.OnLB?.Invoke(PlayerIndex, ctx);
	}

	private void HandleRB(InputAction.CallbackContext ctx)
	{
		this.OnRB?.Invoke(PlayerIndex, ctx);
	}

	private void HandleLT(InputAction.CallbackContext ctx)
	{
		this.OnLT?.Invoke(PlayerIndex, ctx);
	}

	private void HandleRT(InputAction.CallbackContext ctx)
	{
		this.OnRT?.Invoke(PlayerIndex, ctx);
	}

	private void HandleY(InputAction.CallbackContext ctx)
	{
		this.OnYPressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandleA(InputAction.CallbackContext ctx)
	{
		this.OnAPressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandleX(InputAction.CallbackContext ctx)
	{
		this.OnXPressed?.Invoke(PlayerIndex, ctx);
	}

	private void HandleEnter(InputAction.CallbackContext ctx)
	{
		this.OnEnter?.Invoke(PlayerIndex, ctx);
	}

	private void HandleInteract(InputAction.CallbackContext ctx)
	{
		if (!PlayerController.interactor.ActiveInteractable || (bool)PlayerController.interactor.InterruptingInteractable)
		{
			return;
		}
		if (ctx.control.device is Gamepad)
		{
			GameObject gameObject = EventSystem.current?.currentSelectedGameObject;
			if (gameObject != null && gameObject.activeInHierarchy)
			{
				gameObject.GetComponent<Button>()?.onClick.Invoke();
			}
		}
		this.OnInteract?.Invoke(PlayerIndex, ctx);
	}

	private void HandleInterrupt(InputAction.CallbackContext ctx)
	{
		if ((bool)PlayerController.interactor.InterruptingInteractable)
		{
			this.OnInterrupt?.Invoke(PlayerIndex, ctx);
		}
	}

	private void OnSelectStarted(InputAction.CallbackContext ctx)
	{
		selectHoldTriggered = false;
		selectHoldCoroutine = StartCoroutine(SelectHoldRoutine(ctx));
	}

	private IEnumerator SelectHoldRoutine(InputAction.CallbackContext ctx)
	{
		yield return new WaitForSeconds(selectTapThreshold);
		selectHoldTriggered = true;
		this.OnMapPressed?.Invoke(PlayerIndex, ctx);
	}

	private void OnSelectCanceled(InputAction.CallbackContext ctx)
	{
		if (selectHoldCoroutine != null)
		{
			StopCoroutine(selectHoldCoroutine);
		}
		if (!selectHoldTriggered)
		{
			if (MenuManager.Instance.CurrentMenu?.MenuType == MenuType.Map)
			{
				this.OnMapPressed?.Invoke(PlayerIndex, ctx);
			}
			else
			{
				this.OnInventoryPressed?.Invoke(PlayerIndex, ctx);
			}
		}
	}
}
