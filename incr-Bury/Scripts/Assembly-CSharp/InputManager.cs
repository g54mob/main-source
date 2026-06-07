using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.UI;

public class InputManager : MonoBehaviour
{
	public enum ControllerType
	{
		keyboard = 0,
		controller = 1
	}

	public static InputManager Singleton;

	public InputActions inputActions;

	public PlayerInput playerInput;

	public InputSystemUIInputModule uiInputModule;

	public ControllerType lastUsedControllerType;

	private ControllerType lastUsedControllerType_PrevFrame;

	[Header("Controller Mouse Emulation")]
	public float controllerCursorMovement_CursorSpeed;

	public Action ControllerTypeChanged;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void OnEnable()
	{
		playerInput.onControlsChanged += OnControlsChanged;
	}

	private void OnDisable()
	{
		playerInput.onControlsChanged -= OnControlsChanged;
	}

	private void Start()
	{
		inputActions = new InputActions();
		EnableAllActionMaps();
	}

	private void Update()
	{
		_ = (bool)MainMenuManager.Singleton;
		if (uiInputModule == null)
		{
			try
			{
				uiInputModule = EventSystem.current.GetComponent<InputSystemUIInputModule>();
			}
			catch
			{
			}
		}
	}

	public void DisableAllActionMaps()
	{
		inputActions.PlayerActionMap.Disable();
	}

	public void EnableAllActionMaps()
	{
		inputActions.PlayerActionMap.Enable();
	}

	private void OnControlsChanged(PlayerInput _input)
	{
		string currentControlScheme = _input.currentControlScheme;
		if (!(currentControlScheme == "KBM"))
		{
			if (currentControlScheme == "Controller")
			{
				SetControllerType(ControllerType.controller);
				uiInputModule.point.action.Disable();
				uiInputModule.leftClick.action.Disable();
				if ((bool)GameManager.Singleton && GameManager.Singleton.gameState == GameManager.GameState.RoundOverShop)
				{
					WarpMouseToBottom();
					Cursor.visible = false;
				}
			}
		}
		else
		{
			SetControllerType(ControllerType.keyboard);
			uiInputModule.point.action.Enable();
			uiInputModule.leftClick.action.Enable();
			if ((bool)GameManager.Singleton && GameManager.Singleton.gameState == GameManager.GameState.RoundOverShop)
			{
				Cursor.visible = true;
			}
		}
	}

	private void SetControllerType(ControllerType newType)
	{
		if (lastUsedControllerType != newType)
		{
			lastUsedControllerType = newType;
			ControllerTypeChanged?.Invoke();
			Debug.Log("CONTROLS CHANGED: " + newType);
		}
	}

	public void WarpMouseToBottom()
	{
		Vector2 vector = new Vector2((float)Screen.width * 0.5f, 5f);
		Mouse.current.WarpCursorPosition(vector);
		InputState.Change(Mouse.current.position, vector);
	}
}
