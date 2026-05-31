using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixelCrushers
{
	[AddComponentMenu("")]
	public class InputDeviceManager : MonoBehaviour
	{
		public enum KeyInputSwitchesModeTo
		{
			Keyboard = 0,
			Mouse = 1
		}

		public delegate bool GetButtonDownDelegate(string buttonName);

		public delegate float GetAxisDelegate(string axisName);

		[Tooltip("Current input mode.")]
		public InputDevice inputDevice;

		[Tooltip("If any of these keycodes are pressed, current device is joystick.")]
		public KeyCode[] joystickKeyCodesToCheck = new KeyCode[4]
		{
			KeyCode.JoystickButton0,
			KeyCode.JoystickButton1,
			KeyCode.JoystickButton2,
			KeyCode.JoystickButton7
		};

		[Tooltip("If any of these buttons are pressed, current device is joystick. Must be defined in Input Manager.")]
		public string[] joystickButtonsToCheck = new string[0];

		[Tooltip("If any of these axes are greater than Joystick Axis Threshold, current device is joystick. Must be defined in Input Manager.")]
		public string[] joystickAxesToCheck = new string[0];

		[Tooltip("Joystick axis values must be above this threshold to switch to joystick mode.")]
		public float joystickAxisThreshold = 0.5f;

		[Tooltip("If any of these buttons are pressed, current device is keyboard (unless device is currently mouse).")]
		public string[] keyButtonsToCheck = new string[0];

		[Tooltip("If any of these keys are pressed, current device is keyboard (unless device is currently mouse).")]
		public KeyCode[] keyCodesToCheck = new KeyCode[1] { KeyCode.Escape };

		[Tooltip("Which mode to switch to if user presses Key Buttons/Codes To Check.")]
		public KeyInputSwitchesModeTo keyInputSwitchesModeTo = KeyInputSwitchesModeTo.Mouse;

		[Tooltip("Always enable joystick/keyboard navigation even in Mouse mode.")]
		public bool alwaysAutoFocus;

		[Tooltip("Switch to mouse control if player clicks mouse buttons or moves mouse.")]
		public bool detectMouseControl = true;

		[Tooltip("If mouse moves more than this, current device is mouse.")]
		public float mouseMoveThreshold = 0.1f;

		[Tooltip("Hide cursor in joystick/key mode, show in mouse mode.")]
		public bool controlCursorState = true;

		[Tooltip("When paused and device is mouse, make sure cursor is visible.")]
		public bool enforceCursorOnPause;

		[Tooltip("Enable GraphicRaycasters (which detect cursor clicks on UI elements) only when device is mouse.")]
		public bool controlGraphicRaycasters;

		[Tooltip("If any of these keycodes are pressed, go back to the previous menu.")]
		public KeyCode[] backKeyCodes = new KeyCode[1] { KeyCode.JoystickButton1 };

		[Tooltip("If any of these buttons are pressed, go back to the previous menu.")]
		public string[] backButtons = new string[1] { "Cancel" };

		[Tooltip("'Submit' input button defined on Event System.")]
		public string submitButton = "Submit";

		[Tooltip("Survive scene changes and only allow one instance.")]
		public bool singleton = true;

		public UnityEvent onUseKeyboard = new UnityEvent();

		public UnityEvent onUseJoystick = new UnityEvent();

		public UnityEvent onUseMouse = new UnityEvent();

		public UnityEvent onUseTouch = new UnityEvent();

		public GetButtonDownDelegate GetButtonDown;

		public GetButtonDownDelegate GetButtonUp;

		public GetAxisDelegate GetInputAxis;

		private Vector3 m_lastMousePosition;

		private bool m_ignoreMouse;

		private bool m_inputAllowed = true;

		private static InputDeviceManager m_instance = null;

		public static Dictionary<string, InputAction> inputActionDict = new Dictionary<string, InputAction>();

		protected static Dictionary<KeyCode, KeyControl> m_specialKeyCodeDict = null;

		public static InputDeviceManager instance
		{
			get
			{
				return m_instance;
			}
			set
			{
				m_instance = value;
			}
		}

		public static InputDevice currentInputDevice
		{
			get
			{
				if (!(m_instance != null))
				{
					return InputDevice.Joystick;
				}
				return m_instance.inputDevice;
			}
		}

		public static bool deviceUsesCursor => currentInputDevice == InputDevice.Mouse;

		public static bool autoFocus
		{
			get
			{
				if ((!(instance != null) || !instance.alwaysAutoFocus) && currentInputDevice != InputDevice.Joystick)
				{
					return currentInputDevice == InputDevice.Keyboard;
				}
				return true;
			}
		}

		public static bool isBackButtonDown
		{
			get
			{
				if (!(m_instance != null))
				{
					return false;
				}
				return m_instance.IsBackButtonDown();
			}
		}

		public static bool isInputAllowed
		{
			get
			{
				if (!(m_instance != null))
				{
					return true;
				}
				return m_instance.m_inputAllowed;
			}
			set
			{
				if (m_instance != null)
				{
					m_instance.m_inputAllowed = value;
				}
			}
		}

		protected static Dictionary<KeyCode, KeyControl> specialKeyCodeDict
		{
			get
			{
				if (m_specialKeyCodeDict == null)
				{
					m_specialKeyCodeDict = new Dictionary<KeyCode, KeyControl>();
					for (int i = 48; i <= 57; i++)
					{
						try
						{
							m_specialKeyCodeDict.Add((KeyCode)i, Keyboard.current[(i - 48).ToString()] as KeyControl);
						}
						catch (KeyNotFoundException)
						{
						}
					}
					for (int j = 256; j <= 265; j++)
					{
						try
						{
							m_specialKeyCodeDict.Add((KeyCode)j, Keyboard.current["numpad" + (j - 256)] as KeyControl);
						}
						catch (KeyNotFoundException)
						{
						}
					}
				}
				return m_specialKeyCodeDict;
			}
		}

		public static bool IsButtonDown(string buttonName)
		{
			if (!isInputAllowed)
			{
				return false;
			}
			if (!(m_instance != null) || m_instance.GetButtonDown == null)
			{
				return DefaultGetButtonDown(buttonName);
			}
			return m_instance.GetButtonDown(buttonName);
		}

		public static bool IsButtonUp(string buttonName)
		{
			if (!isInputAllowed)
			{
				return false;
			}
			if (!(m_instance != null) || m_instance.GetButtonUp == null)
			{
				return DefaultGetButtonUp(buttonName);
			}
			return m_instance.GetButtonUp(buttonName);
		}

		public static bool IsKeyDown(KeyCode keyCode)
		{
			if (!isInputAllowed)
			{
				return false;
			}
			return DefaultGetKeyDown(keyCode);
		}

		public static bool IsAnyKeyDown()
		{
			if (!isInputAllowed)
			{
				return false;
			}
			return DefaultGetAnyKeyDown();
		}

		public static float GetAxis(string axisName)
		{
			if (!isInputAllowed)
			{
				return 0f;
			}
			if (!(m_instance != null) || m_instance.GetInputAxis == null)
			{
				return DefaultGetAxis(axisName);
			}
			return m_instance.GetInputAxis(axisName);
		}

		public static Vector3 GetMousePosition()
		{
			if (!isInputAllowed)
			{
				return Vector3.zero;
			}
			return DefaultGetMousePosition();
		}

		public void Awake()
		{
			if (m_instance != null && singleton)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			m_instance = this;
			GetButtonDown = DefaultGetButtonDown;
			GetButtonUp = DefaultGetButtonUp;
			GetInputAxis = DefaultGetAxis;
			if (singleton)
			{
				base.transform.SetParent(null);
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		public void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		public void Start()
		{
			m_lastMousePosition = GetMousePosition();
			SetInputDevice(inputDevice);
			BrieflyIgnoreMouseMovement();
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			BrieflyIgnoreMouseMovement();
		}

		public void SetInputDevice(InputDevice newDevice)
		{
			inputDevice = newDevice;
			m_lastMousePosition = GetMousePosition();
			SetCursor(deviceUsesCursor);
			SetGraphicRaycasters(deviceUsesCursor);
			switch (inputDevice)
			{
			case InputDevice.Joystick:
				onUseJoystick.Invoke();
				break;
			case InputDevice.Keyboard:
				onUseKeyboard.Invoke();
				break;
			case InputDevice.Mouse:
			{
				EventSystem current = EventSystem.current;
				Selectable selectable = ((current != null && current.currentSelectedGameObject != null) ? current.currentSelectedGameObject.GetComponent<Selectable>() : null);
				if (selectable != null && !autoFocus)
				{
					selectable.OnDeselect(null);
				}
				onUseMouse.Invoke();
				break;
			}
			case InputDevice.Touch:
				onUseTouch.Invoke();
				break;
			}
		}

		private void SetGraphicRaycasters(bool deviceUsesCursor)
		{
			if (controlGraphicRaycasters)
			{
				GraphicRaycaster[] array = GameObjectUtility.FindObjectsByType<GraphicRaycaster>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].enabled = deviceUsesCursor;
				}
			}
		}

		public void Update()
		{
			switch (inputDevice)
			{
			case InputDevice.Joystick:
				if (IsUsingMouse())
				{
					SetInputDevice(InputDevice.Mouse);
				}
				else if (IsUsingKeyboard())
				{
					SetInputDevice((keyInputSwitchesModeTo == KeyInputSwitchesModeTo.Keyboard) ? InputDevice.Keyboard : InputDevice.Mouse);
				}
				break;
			case InputDevice.Keyboard:
				if (IsUsingMouse())
				{
					SetInputDevice(InputDevice.Mouse);
				}
				else if (IsUsingJoystick())
				{
					SetInputDevice(InputDevice.Joystick);
				}
				break;
			case InputDevice.Mouse:
				if (IsUsingJoystick())
				{
					SetInputDevice(InputDevice.Joystick);
				}
				else if (keyInputSwitchesModeTo == KeyInputSwitchesModeTo.Keyboard && IsUsingKeyboard())
				{
					SetInputDevice(InputDevice.Keyboard);
				}
				break;
			case InputDevice.Touch:
				if (IsUsingMouse())
				{
					SetInputDevice(InputDevice.Mouse);
				}
				else if (IsUsingKeyboard())
				{
					SetInputDevice(InputDevice.Mouse);
				}
				break;
			}
		}

		public bool IsUsingJoystick()
		{
			try
			{
				for (int i = 0; i < joystickKeyCodesToCheck.Length; i++)
				{
					if (IsKeyDown(joystickKeyCodesToCheck[i]))
					{
						return true;
					}
				}
				for (int j = 0; j < joystickButtonsToCheck.Length; j++)
				{
					if (GetButtonDown(joystickButtonsToCheck[j]))
					{
						return true;
					}
				}
				for (int k = 0; k < joystickAxesToCheck.Length; k++)
				{
					if (Mathf.Abs(DefaultGetAxis(joystickAxesToCheck[k])) > joystickAxisThreshold)
					{
						return true;
					}
				}
			}
			catch (ArgumentException ex)
			{
				Debug.LogError("Some input settings listed on the Input Device Manager component are missing from Unity's Input Manager. To automatically add them, inspect the Input Device Manager component on the GameObject '" + base.name + "' and click the 'Add Input Definitions' button at the bottom.\n" + ex.Message, this);
			}
			return false;
		}

		public bool IsUsingMouse()
		{
			if (!detectMouseControl)
			{
				return false;
			}
			if (DefaultGetMouseButtonDown(0) || DefaultGetMouseButtonDown(1))
			{
				return true;
			}
			Vector3 lastMousePosition = DefaultGetMousePosition();
			bool result = !m_ignoreMouse && (Mathf.Abs(lastMousePosition.x - m_lastMousePosition.x) > mouseMoveThreshold || Mathf.Abs(lastMousePosition.y - m_lastMousePosition.y) > mouseMoveThreshold);
			m_lastMousePosition = lastMousePosition;
			return result;
		}

		public void BrieflyIgnoreMouseMovement()
		{
			StartCoroutine(BrieflyIgnoreMouseMovementCoroutine());
		}

		private IEnumerator BrieflyIgnoreMouseMovementCoroutine()
		{
			m_ignoreMouse = true;
			yield return new WaitForSeconds(0.5f);
			m_ignoreMouse = false;
			m_lastMousePosition = DefaultGetMousePosition();
			if (deviceUsesCursor)
			{
				SetCursor(visible: true);
			}
		}

		public bool IsUsingKeyboard()
		{
			try
			{
				for (int i = 0; i < keyCodesToCheck.Length; i++)
				{
					if (DefaultGetKeyDown(keyCodesToCheck[i]))
					{
						return true;
					}
				}
				for (int j = 0; j < keyButtonsToCheck.Length; j++)
				{
					if (GetButtonDown(keyButtonsToCheck[j]))
					{
						return true;
					}
				}
			}
			catch (ArgumentException ex)
			{
				Debug.LogError("Some input settings listed on the Input Device Manager component are missing from Unity's Input Manager. To automatically add them, inspect the Input Device Manager component and click the 'Add Input Definitions' button at the bottom.\n" + ex.Message, this);
			}
			return false;
		}

		public bool IsBackButtonDown()
		{
			try
			{
				for (int i = 0; i < backKeyCodes.Length; i++)
				{
					if (DefaultGetKeyDown(backKeyCodes[i]))
					{
						return true;
					}
				}
				for (int j = 0; j < backButtons.Length; j++)
				{
					if (GetButtonDown(backButtons[j]))
					{
						return true;
					}
				}
			}
			catch (ArgumentException ex)
			{
				Debug.LogError("Some input settings listed on the Input Device Manager component are missing from Unity's Input Manager. To automatically add them, inspect the Input Device Manager component and click the 'Add Input Definitions' button at the bottom.\n" + ex.Message, this);
			}
			return false;
		}

		public void SetCursor(bool visible)
		{
			if (controlCursorState)
			{
				ForceCursor(visible);
			}
		}

		public void ForceCursor(bool visible)
		{
			Cursor.visible = visible;
			Cursor.lockState = ((!visible) ? CursorLockMode.Locked : CursorLockMode.None);
			m_lastMousePosition = GetMousePosition();
			StartCoroutine(ForceCursorAfterOneFrameCoroutine(visible));
		}

		private IEnumerator ForceCursorAfterOneFrameCoroutine(bool visible)
		{
			yield return CoroutineUtility.endOfFrame;
			Cursor.visible = visible;
			Cursor.lockState = ((!visible) ? CursorLockMode.Locked : CursorLockMode.None);
		}

		public static void RegisterInputAction(string name, InputAction inputAction)
		{
			inputActionDict[name] = inputAction;
		}

		public static void UnregisterInputAction(string name)
		{
			if (inputActionDict.ContainsKey(name))
			{
				inputActionDict.Remove(name);
			}
		}

		public static bool DefaultGetKeyDown(KeyCode keyCode)
		{
			if (Keyboard.current != null)
			{
				switch (keyCode)
				{
				case KeyCode.None:
					break;
				case KeyCode.Return:
					return (Keyboard.current["enter"] as KeyControl).wasPressedThisFrame;
				default:
				{
					string text = keyCode.ToString().ToLower();
					if (text.StartsWith("mouse"))
					{
						switch (text)
						{
						case "mouse0":
							return Mouse.current.leftButton.wasPressedThisFrame;
						case "mouse1":
							return Mouse.current.rightButton.wasPressedThisFrame;
						case "mouse2":
							return Mouse.current.middleButton.wasPressedThisFrame;
						}
					}
					if (text.StartsWith("joystick") || text.StartsWith("mouse"))
					{
						return false;
					}
					if ((KeyCode.Alpha0 <= keyCode && keyCode <= KeyCode.Alpha9) || (KeyCode.Keypad0 <= keyCode && keyCode <= KeyCode.Keypad9))
					{
						if (!specialKeyCodeDict.TryGetValue(keyCode, out var value))
						{
							return false;
						}
						return value.wasPressedThisFrame;
					}
					if (!(Keyboard.current[text] is KeyControl keyControl))
					{
						return false;
					}
					return keyControl.wasPressedThisFrame;
				}
				}
			}
			return false;
		}

		public static bool DefaultGetAnyKeyDown()
		{
			if (Keyboard.current != null)
			{
				return Keyboard.current.anyKey.wasPressedThisFrame;
			}
			return false;
		}

		public static bool DefaultGetButtonDown(string buttonName)
		{
			try
			{
				if (inputActionDict.TryGetValue(buttonName, out var value))
				{
					foreach (InputControl control in value.controls)
					{
						if ((control is ButtonControl && (control as ButtonControl).wasPressedThisFrame) || (control is KeyControl && (control as KeyControl).wasPressedThisFrame))
						{
							return true;
						}
					}
				}
				return false;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public static bool DefaultGetButtonUp(string buttonName)
		{
			try
			{
				if (inputActionDict.TryGetValue(buttonName, out var value))
				{
					foreach (InputControl control in value.controls)
					{
						if ((control is ButtonControl && (control as ButtonControl).wasReleasedThisFrame) || (control is KeyControl && (control as KeyControl).wasReleasedThisFrame))
						{
							return true;
						}
					}
				}
				return false;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public static float DefaultGetAxis(string axisName)
		{
			try
			{
				if (inputActionDict.TryGetValue(axisName, out var value))
				{
					return value.ReadValue<float>();
				}
				return 0f;
			}
			catch (ArgumentException)
			{
				return 0f;
			}
		}

		public static Vector3 DefaultGetMousePosition()
		{
			if (Mouse.current == null)
			{
				return Vector3.zero;
			}
			Vector2 vector = Mouse.current.position.ReadValue();
			return new Vector3(vector.x, vector.y, 0f);
		}

		public static bool DefaultGetMouseButtonDown(int buttonNumber)
		{
			if (Mouse.current == null)
			{
				return false;
			}
			return buttonNumber switch
			{
				0 => Mouse.current.leftButton.wasPressedThisFrame, 
				1 => Mouse.current.rightButton.wasPressedThisFrame, 
				2 => Mouse.current.middleButton.wasPressedThisFrame, 
				_ => false, 
			};
		}
	}
}
