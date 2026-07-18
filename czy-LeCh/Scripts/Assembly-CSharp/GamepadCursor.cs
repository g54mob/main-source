using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

public class GamepadCursor : MonoBehaviour
{
	public static GamepadCursor Instance;

	[SerializeField]
	private Canvas cursorCanvas;

	[SerializeField]
	private RectTransform cursorTransform;

	[SerializeField]
	private RectTransform cursorCanvasTransform;

	private Mouse virtualMouse;

	[SerializeField]
	private Vector2 lastMousePos;

	[SerializeField]
	private Vector2 lastGamepadPos;

	[SerializeField]
	private bool updatedMouse;

	[SerializeField]
	private bool gamepadActive;

	[SerializeField]
	private float cursorSpeed = 1000f;

	[SerializeField]
	private float padding = 35f;

	[SerializeField]
	private Vector2 _newPos;

	private bool previousMouseState;

	private void Awake()
	{
		Instance = this;
	}

	private void OnEnable()
	{
		_newPos = Vector3.zero;
		Cursor.visible = false;
		if (virtualMouse == null)
		{
			virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
		}
		else if (!virtualMouse.added)
		{
			InputSystem.AddDevice(virtualMouse);
		}
		if (cursorTransform != null)
		{
			InputState.Change(state: new Vector2(Screen.width / 2, Screen.height / 2), control: virtualMouse.position);
		}
		InputSystem.onAfterUpdate += UpdateMotion;
	}

	private void OnDisable()
	{
		InputSystem.RemoveDevice(virtualMouse);
		InputSystem.onAfterUpdate -= UpdateMotion;
	}

	private void Update()
	{
		if (Mouse.current.position.ReadValue() != lastMousePos || Keyboard.current.anyKey.isPressed)
		{
			if (!updatedMouse)
			{
				Mouse.current.WarpCursorPosition(_newPos);
				updatedMouse = true;
			}
			gamepadActive = false;
			ChangeActiveInputDevice();
			lastMousePos = Mouse.current.position.ReadValue();
		}
		if (Gamepad.current != null && (Gamepad.current.leftStick.ReadValue() != lastGamepadPos || Gamepad.current.allControls.Any((InputControl x) => x is ButtonControl && x.IsPressed() && !x.synthetic)))
		{
			gamepadActive = true;
			ChangeActiveInputDevice();
			lastGamepadPos = Gamepad.current.leftStick.ReadValue();
		}
	}

	private void UpdateMotion()
	{
		if (virtualMouse == null || Gamepad.current == null)
		{
			AnchorCursor(_newPos);
			return;
		}
		Vector2 vector = Gamepad.current.leftStick.ReadValue();
		vector *= cursorSpeed * Time.deltaTime;
		Vector2 vector2 = virtualMouse.position.ReadValue();
		_newPos = vector2 + vector;
		_newPos.x = Mathf.Clamp(_newPos.x, padding, (float)Screen.width - padding);
		_newPos.y = Mathf.Clamp(_newPos.y, padding, (float)Screen.height - padding);
		InputState.Change(virtualMouse.position, _newPos);
		InputState.Change(virtualMouse.delta, vector);
		bool isPressed = Gamepad.current.aButton.isPressed;
		if (previousMouseState != isPressed)
		{
			virtualMouse.CopyState<MouseState>(out var state);
			state.WithButton(MouseButton.Left, isPressed);
			InputState.Change(virtualMouse, state);
			previousMouseState = isPressed;
		}
		AnchorCursor(_newPos);
	}

	private void AnchorCursor(Vector2 pos)
	{
		if (gamepadActive)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(cursorCanvasTransform, pos, (cursorCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : Camera.main, out var localPoint);
			cursorTransform.anchoredPosition = localPoint;
			updatedMouse = false;
		}
		else
		{
			cursorTransform.position = Mouse.current.position.ReadValue();
		}
	}

	private void ChangeActiveInputDevice()
	{
		if (!gamepadActive)
		{
			InputState.Change(virtualMouse, Mouse.current.position.ReadValue());
		}
	}

	public Vector2 GetRelevantCursorPosition()
	{
		if (!gamepadActive)
		{
			return Mouse.current.position.ReadValue();
		}
		return virtualMouse.position.ReadValue();
	}

	public bool IsGamepadActive()
	{
		return gamepadActive;
	}

	public void ResetSelectedButton()
	{
		EventSystem.current.SetSelectedGameObject(null);
	}
}
