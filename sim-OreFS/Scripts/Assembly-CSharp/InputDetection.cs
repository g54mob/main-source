using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Switch;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.XInput;

public class InputDetection : MonoBehaviour
{
	public static InputDetection Instance;

	public UnityEvent gamepadEvent;

	public UnityEvent keyboardEvent;

	public bool isBackBusy;

	public bool persistOnLoad = true;

	public bool KeyboardEnabled;

	public bool GamepadEnabled;

	public int activeDeviceId;

	public InputDevice connectedDevice;

	public CurrentInputDevice _activeInputDevice;

	public GameManager gManager;

	private IDisposable m_EventListener;

	public CurrentInputDevice activeInputDevice
	{
		get
		{
			return _activeInputDevice;
		}
		set
		{
			_activeInputDevice = value;
			if (_activeInputDevice == CurrentInputDevice.Keyboard)
			{
				GamepadEnabled = false;
				KeyboardEnabled = true;
				keyboardEvent.Invoke();
			}
			else
			{
				GamepadEnabled = true;
				KeyboardEnabled = false;
				gamepadEvent.Invoke();
			}
			UpdateButtonImages();
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		if (persistOnLoad)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	private void Start()
	{
		InputSystem.onDeviceChange += OnDeviceChange;
	}

	private void OnEnable()
	{
		m_EventListener = InputSystem.onAnyButtonPress.Call(OnButtonPressed);
	}

	private void OnDisable()
	{
		m_EventListener?.Dispose();
		m_EventListener = null;
	}

	private void OnDestroy()
	{
		InputSystem.onDeviceChange -= OnDeviceChange;
	}

	private void Update()
	{
		if (activeInputDevice != CurrentInputDevice.Keyboard)
		{
			return;
		}
		foreach (Gamepad item in Gamepad.all)
		{
			if (item.deviceId != activeDeviceId && (item.leftStick.IsActuated() || item.rightStick.IsActuated()))
			{
				SetActiveDevice(item, isStart: false);
				break;
			}
		}
	}

	public void FirstDeviceControll()
	{
		connectedDevice = DetermineActiveDevice();
		if (connectedDevice != null)
		{
			SetActiveDevice(connectedDevice, isStart: true);
		}
	}

	private InputDevice DetermineActiveDevice()
	{
		foreach (InputDevice device in InputSystem.devices)
		{
			if (device is Gamepad || device is Keyboard)
			{
				return device;
			}
		}
		return null;
	}

	private void OnButtonPressed(InputControl button)
	{
		InputDevice device = button.device;
		if (device is Mouse)
		{
			Keyboard current = Keyboard.current;
			if (current != null && activeInputDevice != CurrentInputDevice.Keyboard)
			{
				SetActiveDevice(current, isStart: false);
			}
		}
		else if (device.deviceId != activeDeviceId)
		{
			SetActiveDevice(device, isStart: false);
		}
	}

	private void SetActiveDevice(InputDevice device, bool isStart)
	{
		if (isStart)
		{
			activeInputDevice = GetDeviceType(device);
			activeDeviceId = device.deviceId;
		}
		else if (device.description.deviceClass.Contains("Keyboard") || device.name.Contains("Keyboard"))
		{
			activeInputDevice = CurrentInputDevice.Keyboard;
			activeDeviceId = device.deviceId;
		}
		else
		{
			activeInputDevice = GetDeviceType(device);
			activeDeviceId = device.deviceId;
		}
	}

	private CurrentInputDevice GetDeviceType(InputDevice device)
	{
		if (device is Gamepad gamepad)
		{
			if (gamepad is DualShockGamepad)
			{
				return CurrentInputDevice.PlaystationGamepad;
			}
			if (gamepad is XInputController)
			{
				return CurrentInputDevice.XboxGamepad;
			}
			if (gamepad is SwitchProControllerHID)
			{
				return CurrentInputDevice.SwitchGamepad;
			}
			return CurrentInputDevice.XboxGamepad;
		}
		_ = device is Keyboard;
		return CurrentInputDevice.Keyboard;
	}

	private void UpdateButtonImages()
	{
		ControllerButtonImage[] array = UnityEngine.Object.FindObjectsOfType<ControllerButtonImage>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateButtonImage();
		}
	}

	private void OnDeviceChange(InputDevice device, InputDeviceChange change)
	{
		switch (change)
		{
		case InputDeviceChange.Added:
		case InputDeviceChange.Reconnected:
		case InputDeviceChange.Enabled:
			if (device is Gamepad || device is Keyboard)
			{
				SetActiveDevice(device, isStart: false);
			}
			break;
		case InputDeviceChange.Removed:
		case InputDeviceChange.Disconnected:
		case InputDeviceChange.Disabled:
			if (device.deviceId == activeDeviceId)
			{
				InputDevice inputDevice = DetermineActiveDevice();
				if (inputDevice != null)
				{
					SetActiveDevice(inputDevice, isStart: true);
				}
			}
			break;
		}
	}
}
