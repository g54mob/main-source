using System.Collections.Generic;
using Aggro.Core;
using TMPro;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public static class AggroInputManager
{
	private struct Vibration
	{
		public float lowFrequency;

		public float highFrequency;

		public double endTime;
	}

	private class OverlayInputController : IInputController
	{
		public void OnInputControlGained()
		{
			input.Debug.Disable();
			input.Always.Disable();
			PauseVibrations();
		}

		public void OnInputControlLost()
		{
			input.Debug.Enable();
			input.Always.Enable();
			ResumeVibrations();
		}
	}

	private enum UIRequest
	{
		None = 0,
		Enable = 1,
		Disable = 2
	}

	public static readonly AggroInput input = new AggroInput();

	private static List<IInputController> _controllers = new List<IInputController>();

	private static bool _managingControllers;

	private static UIRequest _request;

	private static Gamepad _prevController;

	private static List<Vibration> _vibrations = new List<Vibration>();

	private static OverlayInputController _overlayInputController = new OverlayInputController();

	private static readonly int SETTINGS_CONTROLLERSHAKE = AggroSettings.IdToHash("game-controllershake");

	private const float ANALOG_THRESHOLD_SQR = 0.64000005f;

	private static bool _hideMouseCursor;

	private static PlayerMessageManager.Message _queuedDisconnectMessage = new PlayerMessageManager.Message(null);

	public static InputMode mode { get; private set; }

	public static bool enabled { get; private set; }

	public static bool isPlayerInControl
	{
		get
		{
			if (GameUtil.isReady)
			{
				return HasControl(GameUtil.world.GetOrCreateSystem<InputSystemGroup>());
			}
			return false;
		}
	}

	public static int version { get; private set; } = 1;

	public static InputBinding kbmInputBinding => InputBinding.MaskByGroup(input.KBMScheme.bindingGroup);

	public static InputBinding gamepadInputBinding => InputBinding.MaskByGroup(input.GamepadScheme.bindingGroup);

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Initialize()
	{
		mode = InputMode.KBM;
		input.bindingMask = kbmInputBinding;
		input.Disable();
		_controllers.Clear();
		_managingControllers = false;
		_request = UIRequest.Disable;
		InputSystem.onDeviceChange += OnDeviceChange;
	}

	public static void Enable()
	{
		input.Debug.Enable();
		input.Always.Enable();
		enabled = true;
	}

	public static void Disable()
	{
		if (_controllers.Count > 0)
		{
			_controllers[_controllers.Count - 1].OnInputControlLost();
		}
		_controllers.Clear();
		input.Disable();
		enabled = false;
		_hideMouseCursor = false;
		InputSystem.ResetHaptics();
		_vibrations.Clear();
		if (EventSystem.current != null)
		{
			EventSystem.current.sendNavigationEvents = false;
			EventSystem.current.SetSelectedGameObject(null);
			if (EventSystem.current.currentInputModule != null)
			{
				EventSystem.current.currentInputModule.enabled = false;
			}
		}
	}

	private static void OnDeviceChange(InputDevice device, InputDeviceChange change)
	{
		switch (change)
		{
		case InputDeviceChange.Disconnected:
			_queuedDisconnectMessage = PlayerMessageManager.QueueMessage("CONTROLLERDISCONNECT", highPriority: true, isError: true);
			break;
		case InputDeviceChange.Reconnected:
			PlayerMessageManager.DequeueMessage(_queuedDisconnectMessage);
			_queuedDisconnectMessage = new PlayerMessageManager.Message(null);
			break;
		}
	}

	public static void EnableUIModule()
	{
		_request = UIRequest.Enable;
	}

	public static void DisableUIModule()
	{
		_request = UIRequest.Disable;
		if (EventSystem.current != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public static void HideMouseCursor()
	{
		_hideMouseCursor = true;
	}

	public static void ResetMouseCursor()
	{
		_hideMouseCursor = false;
	}

	public static void PushController(IInputController controller)
	{
		try
		{
			_managingControllers = true;
			if (HasControl(controller))
			{
				return;
			}
			if (_controllers.Count > 0)
			{
				_controllers[_controllers.Count - 1].OnInputControlLost();
				int num = _controllers.IndexOf(controller);
				if (num >= 0)
				{
					_controllers.RemoveAt(num);
				}
			}
			controller.OnInputControlGained();
			_controllers.Add(controller);
		}
		finally
		{
			_managingControllers = false;
		}
	}

	public static bool RemoveController(IInputController controller)
	{
		try
		{
			_managingControllers = true;
			int num = _controllers.IndexOf(controller);
			if (num < 0)
			{
				return false;
			}
			if (HasControl(controller))
			{
				controller.OnInputControlLost();
				if (num > 0)
				{
					_controllers[num - 1].OnInputControlGained();
				}
			}
			_controllers.RemoveAt(num);
			return true;
		}
		finally
		{
			_managingControllers = false;
		}
	}

	public static bool HasControl(IInputController controller)
	{
		if (_controllers.Count > 0)
		{
			return _controllers[_controllers.Count - 1] == controller;
		}
		return false;
	}

	public static bool IsControllerInStack(IInputController controller)
	{
		return _controllers.Contains(controller);
	}

	public static IInputController GetActiveController()
	{
		if (_controllers.Count > 0)
		{
			return _controllers[_controllers.Count - 1];
		}
		return null;
	}

	public static void ChangeMode(InputMode requestedMode)
	{
		if (requestedMode == mode)
		{
			return;
		}
		try
		{
			_managingControllers = true;
			version++;
			IInputController activeController = GetActiveController();
			activeController?.OnInputControlLost();
			if (EventSystem.current != null)
			{
				EventSystem.current.SetSelectedGameObject(null);
				if (EventSystem.current.currentInputModule != null && EventSystem.current.currentInputModule.enabled)
				{
					EventSystem.current.currentInputModule.enabled = false;
					EventSystem.current.currentInputModule.enabled = true;
				}
			}
			InputBinding value = default(InputBinding);
			switch (requestedMode)
			{
			case InputMode.KBM:
				value = InputBinding.MaskByGroup(input.KBMScheme.bindingGroup);
				break;
			case InputMode.Gamepad:
				value = InputBinding.MaskByGroup(input.GamepadScheme.bindingGroup);
				break;
			default:
				throw new InvalidEnumException();
			case InputMode.None:
				break;
			}
			input.bindingMask = value;
			mode = requestedMode;
			activeController?.OnInputControlGained();
		}
		finally
		{
			_managingControllers = false;
		}
	}

	public static void Update()
	{
		if (Platform.ShouldPause())
		{
			if (enabled && !IsControllerInStack(_overlayInputController))
			{
				PushController(_overlayInputController);
			}
			return;
		}
		if (enabled && HasControl(_overlayInputController))
		{
			RemoveController(_overlayInputController);
		}
		ConsiderInputModeChange();
		if (_prevController != Gamepad.current)
		{
			_prevController = Gamepad.current;
			version++;
			if (AggroSettings.isInitialized)
			{
				AggroSettings.RefreshSettingUIs();
			}
		}
		if (EventSystem.current != null && EventSystem.current.currentInputModule != null)
		{
			switch (_request)
			{
			case UIRequest.Enable:
				if (!EventSystem.current.currentInputModule.enabled)
				{
					EventSystem.current.currentInputModule.enabled = true;
				}
				if (mode == InputMode.Gamepad)
				{
					EventSystem.current.sendNavigationEvents = true;
				}
				break;
			case UIRequest.Disable:
				if (EventSystem.current.currentInputModule.enabled)
				{
					EventSystem.current.currentInputModule.enabled = false;
				}
				EventSystem.current.sendNavigationEvents = false;
				break;
			default:
				throw new InvalidEnumException();
			case UIRequest.None:
				break;
			}
			_request = UIRequest.None;
		}
		if (mode == InputMode.Gamepad && Gamepad.current != null)
		{
			for (int i = 0; i < _vibrations.Count; i++)
			{
				Vibration vibration = _vibrations[i];
				if (Time.unscaledTimeAsDouble > vibration.endTime)
				{
					_vibrations.RemoveAtSwapBack(i);
					i--;
				}
			}
			if (_vibrations.Count > 0)
			{
				float x = 0f;
				float x2 = 0f;
				for (int j = 0; j < _vibrations.Count; j++)
				{
					Vibration vibration2 = _vibrations[j];
					x = math.max(x, vibration2.lowFrequency);
					x2 = math.max(x2, vibration2.highFrequency);
				}
				float value = AggroSettings.GetSetting<FloatSetting>(SETTINGS_CONTROLLERSHAKE).value;
				x = math.saturate(x) * value;
				x2 = math.saturate(x2) * value;
				Gamepad.current.SetMotorSpeeds(x, x2);
			}
		}
		else
		{
			_vibrations.Clear();
		}
		if (_vibrations.Count == 0)
		{
			InputSystem.ResetHaptics();
		}
	}

	private static void ConsiderInputModeChange()
	{
		switch (mode)
		{
		case InputMode.None:
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			break;
		case InputMode.KBM:
			if (Gamepad.current != null && (Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current.buttonNorth.wasPressedThisFrame || Gamepad.current.buttonSouth.wasPressedThisFrame || Gamepad.current.buttonWest.wasPressedThisFrame || Gamepad.current.startButton.wasPressedThisFrame || Gamepad.current.rightTrigger.wasPressedThisFrame || Gamepad.current.leftTrigger.wasPressedThisFrame || Gamepad.current.leftShoulder.wasPressedThisFrame || Gamepad.current.rightShoulder.wasPressedThisFrame || Gamepad.current.dpad.right.wasPressedThisFrame || Gamepad.current.dpad.up.wasPressedThisFrame || Gamepad.current.dpad.down.wasPressedThisFrame || Gamepad.current.dpad.left.wasPressedThisFrame || Gamepad.current.leftStick.ReadValue().sqrMagnitude >= 0.64000005f))
			{
				ChangeMode(InputMode.Gamepad);
				break;
			}
			if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponentInParent<TMP_InputField>() == null && EventSystem.current.currentSelectedGameObject.GetComponentInParent<InputField>() == null)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			Cursor.visible = !_hideMouseCursor;
			if (Screen.fullScreen)
			{
				Cursor.lockState = CursorLockMode.Confined;
			}
			else
			{
				Cursor.lockState = CursorLockMode.None;
			}
			break;
		case InputMode.Gamepad:
			if (Application.isFocused)
			{
				if ((Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame) || (Mouse.current != null && (Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame)))
				{
					ChangeMode(InputMode.KBM);
					break;
				}
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
			break;
		default:
			throw new InvalidEnumException();
		}
	}

	public static void Vibrate(float lowFrequency, float highFrequency, float duration)
	{
		if (mode == InputMode.Gamepad)
		{
			Vibration item = new Vibration
			{
				lowFrequency = lowFrequency,
				highFrequency = highFrequency,
				endTime = Time.unscaledTimeAsDouble + (double)duration
			};
			_vibrations.Add(item);
		}
	}

	public static void VibrateForFrame(float lowFrequency, float highFrequency)
	{
		if (mode == InputMode.Gamepad)
		{
			Vibration item = new Vibration
			{
				lowFrequency = lowFrequency,
				highFrequency = highFrequency,
				endTime = Time.unscaledTimeAsDouble
			};
			_vibrations.Add(item);
		}
	}

	public static void Vibrate(VibrateStrength strength)
	{
		if (strength != VibrateStrength.None && mode == InputMode.Gamepad)
		{
			GlobalScriptableObject<InputGlobalData>.instance.GetVibrateValues(strength, out var lowFrequency, out var highFrequency, out var duration);
			Vibrate(lowFrequency, highFrequency, duration);
		}
	}

	public static void VibrateForFrame(VibrateStrength strength)
	{
		if (strength != VibrateStrength.None && mode == InputMode.Gamepad)
		{
			GlobalScriptableObject<InputGlobalData>.instance.GetVibrateFrameValues(strength, out var lowFrequency, out var highFrequency);
			VibrateForFrame(lowFrequency, highFrequency);
		}
	}

	public static void PauseVibrations()
	{
		InputSystem.PauseHaptics();
	}

	public static void ResumeVibrations()
	{
		InputSystem.ResumeHaptics();
	}

	public static void ResetVibrations()
	{
		InputSystem.PauseHaptics();
	}

	public static InputBinding GetKbmCompositeBinding(string bindingName)
	{
		return new InputBinding
		{
			groups = input.KBMScheme.bindingGroup,
			name = bindingName
		};
	}
}
