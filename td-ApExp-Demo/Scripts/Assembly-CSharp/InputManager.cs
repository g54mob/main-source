using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	private Dictionary<int, InputHandler> handlers = new Dictionary<int, InputHandler>();

	private InputHandler kbInputHandler;

	public float InterruptTime = 0.5f;

	public int InterruptAttemptsRequired = 3;

	private MoveInput lastIdentifiedMoveInput = new MoveInput(null, Vector2.zero);

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> mapDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> backDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> inventoryDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> pauseDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> interactDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> interruptDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> lbDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> rbDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> ltDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> rtDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> yDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> aDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> xDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private Dictionary<InputHandler, Action<int, InputAction.CallbackContext>> enterDelegates = new Dictionary<InputHandler, Action<int, InputAction.CallbackContext>>();

	private bool interactBlocked;

	private ControllerType _controllerTypeForLastInput;

	public static InputManager Instance { get; private set; }

	public PlayerController LastPlayerControllerUsed { get; private set; }

	public ControllerType LastControllerTypeUsed { get; private set; }

	public bool IsLastInputGamepad
	{
		get
		{
			if (LastControllerTypeUsed != ControllerType.GamepadXBox && LastControllerTypeUsed != ControllerType.GamepadPS4)
			{
				return LastControllerTypeUsed == ControllerType.GamepadPS5;
			}
			return true;
		}
	}

	public bool IsInputBlocked => interactBlocked;

	public event Action<int, InputAction.CallbackContext> OnMapPressed;

	public event Action<int, InputAction.CallbackContext> OnBackPressed;

	public event Action<int, InputAction.CallbackContext> OnInventoryPressed;

	public event Action<int, InputAction.CallbackContext> OnPausePressed;

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

	public event Action<int, InputAction.CallbackContext> OnAnyInput;

	public event Action<int, ControllerType> OnDeviceChanged;

	public event Action<int, ControllerType> OnAnyInputDetected;

	public Vector2 GetAnyLeftStickInput()
	{
		foreach (InputHandler value in handlers.Values)
		{
			if (value.UIInputStick != Vector2.zero)
			{
				return value.UIInputStick;
			}
		}
		return Vector2.zero;
	}

	public MoveInput GetAnyIdentifiedMoveInput()
	{
		foreach (InputHandler value in handlers.Values)
		{
			if (value.UIInput != Vector2.zero)
			{
				lastIdentifiedMoveInput.Device = value.PlayerInput.devices[0];
				lastIdentifiedMoveInput.Move = value.UIInput;
				return lastIdentifiedMoveInput;
			}
		}
		lastIdentifiedMoveInput.Device = null;
		lastIdentifiedMoveInput.Move = Vector2.zero;
		return lastIdentifiedMoveInput;
	}

	public Vector2 GetAnyMoveInput()
	{
		foreach (InputHandler value in handlers.Values)
		{
			if (value.MoveInput != Vector2.zero)
			{
				LastControllerTypeUsed = value.controllerType;
				return value.MoveInput;
			}
		}
		return Vector2.zero;
	}

	public void BlockInteract(bool block)
	{
		interactBlocked = block;
	}

	public void NotifyDeviceChanged(int playerIndex)
	{
		if (PlayerManager.Instance.IsCoop)
		{
			if (handlers.TryGetValue(playerIndex, out var value))
			{
				this.OnAnyInputDetected?.Invoke(playerIndex, value.controllerType);
			}
			return;
		}
		InputHandler value2;
		PlayerController playerController = (handlers.TryGetValue(playerIndex, out value2) ? value2.PlayerController : null);
		if (playerController == null)
		{
			Debug.LogWarning($"No PlayerController found for player index {playerIndex}");
		}
		else if (LastControllerTypeUsed != playerController?.InputHandler.controllerType)
		{
			LastPlayerControllerUsed = playerController;
			LastControllerTypeUsed = LastPlayerControllerUsed.InputHandler.controllerType;
			this.OnDeviceChanged?.Invoke(playerIndex, LastControllerTypeUsed);
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Combine(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleAnyInputDetected));
	}

	private void OnDestroy()
	{
	}

	public void Register(InputHandler handler)
	{
		if (handlers.ContainsKey(handler.PlayerIndex))
		{
			return;
		}
		Action<int, InputAction.CallbackContext> value = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnMapPressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value2 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnBackPressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value3 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnInventoryPressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value4 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnPausePressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value5 = delegate(int i, InputAction.CallbackContext ctx)
		{
			if (!interactBlocked)
			{
				this.OnInteract?.Invoke(i, ctx);
			}
		};
		Action<int, InputAction.CallbackContext> value6 = delegate(int i, InputAction.CallbackContext ctx)
		{
			if (!interactBlocked)
			{
				this.OnInterrupt?.Invoke(i, ctx);
			}
		};
		Action<int, InputAction.CallbackContext> value7 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnLB?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value8 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnRB?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value9 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnLT?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value10 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnRT?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value11 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnYPressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value12 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnAPressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value13 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnXPressed?.Invoke(i, ctx);
		};
		Action<int, InputAction.CallbackContext> value14 = delegate(int i, InputAction.CallbackContext ctx)
		{
			this.OnEnter?.Invoke(i, ctx);
		};
		mapDelegates[handler] = value;
		backDelegates[handler] = value2;
		inventoryDelegates[handler] = value3;
		pauseDelegates[handler] = value4;
		interactDelegates[handler] = value5;
		interruptDelegates[handler] = value6;
		lbDelegates[handler] = value7;
		rbDelegates[handler] = value8;
		ltDelegates[handler] = value9;
		rtDelegates[handler] = value10;
		yDelegates[handler] = value11;
		handler.OnMapPressed += value;
		handler.OnBackPressed += value2;
		handler.OnInventoryPressed += value3;
		handler.OnPausePressed += value4;
		handler.OnInteract += value5;
		handler.OnInterrupt += value6;
		handler.OnLB += value7;
		handler.OnRB += value8;
		handler.OnLT += value9;
		handler.OnRT += value10;
		handler.OnYPressed += value11;
		handler.OnAPressed += value12;
		handler.OnXPressed += value13;
		handler.OnEnter += value14;
		handlers.Add(handler.PlayerIndex, handler);
	}

	public void Unregister(InputHandler handler, int assignedIndex)
	{
		if (mapDelegates.TryGetValue(handler, out var value))
		{
			handler.OnMapPressed -= value;
		}
		if (backDelegates.TryGetValue(handler, out var value2))
		{
			handler.OnBackPressed -= value2;
		}
		if (inventoryDelegates.TryGetValue(handler, out var value3))
		{
			handler.OnInventoryPressed -= value3;
		}
		if (pauseDelegates.TryGetValue(handler, out var value4))
		{
			handler.OnPausePressed -= value4;
		}
		if (interactDelegates.TryGetValue(handler, out var value5))
		{
			handler.OnInteract -= value5;
		}
		if (interruptDelegates.TryGetValue(handler, out var value6))
		{
			handler.OnInterrupt -= value6;
		}
		if (lbDelegates.TryGetValue(handler, out var value7))
		{
			handler.OnLB -= value7;
		}
		if (rbDelegates.TryGetValue(handler, out var value8))
		{
			handler.OnRB -= value8;
		}
		if (ltDelegates.TryGetValue(handler, out var value9))
		{
			handler.OnLT -= value9;
		}
		if (rtDelegates.TryGetValue(handler, out var value10))
		{
			handler.OnRT -= value10;
		}
		if (yDelegates.TryGetValue(handler, out var value11))
		{
			handler.OnYPressed -= value11;
		}
		if (aDelegates.TryGetValue(handler, out var value12))
		{
			handler.OnAPressed -= value12;
		}
		if (xDelegates.TryGetValue(handler, out var value13))
		{
			handler.OnXPressed -= value13;
		}
		if (enterDelegates.TryGetValue(handler, out var value14))
		{
			handler.OnEnter -= value14;
		}
		mapDelegates.Remove(handler);
		backDelegates.Remove(handler);
		inventoryDelegates.Remove(handler);
		pauseDelegates.Remove(handler);
		interactDelegates.Remove(handler);
		interruptDelegates.Remove(handler);
		lbDelegates.Remove(handler);
		rbDelegates.Remove(handler);
		ltDelegates.Remove(handler);
		rtDelegates.Remove(handler);
		yDelegates.Remove(handler);
		aDelegates.Remove(handler);
		xDelegates.Remove(handler);
		enterDelegates.Remove(handler);
		handlers.Remove(assignedIndex);
	}

	private void HandleAnyInputDetected(int index, ControllerType controllerType)
	{
		if (controllerType != _controllerTypeForLastInput)
		{
			_controllerTypeForLastInput = controllerType;
			this.OnAnyInputDetected?.Invoke(index, controllerType);
		}
	}
}
