using System;
using System.Collections.Generic;
using Factory;
using Motorways;
using Motorways.Views;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputState : IInputState
{
	[Flags]
	public enum BlockInput
	{
		AllowEverything = 0,
		BlockUI = 1,
		BlockGame = 2,
		BlockActions = 4,
		BlockEverything = 3
	}

	public interface IObserver
	{
		void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType);
	}

	public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("Input");

	private BlockInput _blockInputFlags;

	private bool _unblockActionsNextTick;

	private bool _appHasWindowFocus;

	private bool _appHasInternalFocus;

	private bool _appHasFocus;

	private const int DefaultMaxTouchCount = 4;

	private const int DefaultMaxMouseButtonCount = 3;

	[Dependency]
	private PlayerActionController _playerActionController;

	[Dependency]
	private readonly IPointerState _mouse;

	[Dependency]
	private readonly IPointerState[] _touches = new IPointerState[4];

	[Dependency]
	private IHardwareCapabilities _hardware;

	[Dependency]
	private IScope _scope;

	private readonly Dictionary<int, ButtonState> _keys = new Dictionary<int, ButtonState>();

	private readonly Dictionary<int, AxisState> _axis = new Dictionary<int, AxisState>();

	private readonly List<IController> _controllers = new List<IController>();

	[Dependency]
	private IOnScreenToolManager _onScreenToolManager;

	private readonly ObserverList<IControllerConnectionObserver> _controllerConnectionObservers = new ObserverList<IControllerConnectionObserver>();

	private DeviceInputType _currentDeviceInputType;

	[Serialize(false, null)]
	private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

	private static readonly ProfilerMarker Profiler_Tick = new ProfilerMarker("InputSystem.Tick");

	private static readonly ProfilerMarker Profiler_IsInputEventOverUI = new ProfilerMarker("InputSystem.IsInputEventOverUI");

	public float LastInputTimestamp { get; private set; }

	public int MaxRecognizedTouchCount { get; set; } = 1;

	public IEnumerable<int> InputActionsToPoll => _keys.Keys;

	public HashSet<int> InputActionsToIgnore { get; private set; }

	public IEnumerable<int> AxisToPoll => _axis.Keys;

	public HashSet<int> AxisToIgnore { get; private set; }

	public DeviceInputType CurrentDeviceInputType
	{
		get
		{
			return _currentDeviceInputType;
		}
		private set
		{
			DeviceInputType currentDeviceInputType = _currentDeviceInputType;
			_currentDeviceInputType = value;
			if (_currentDeviceInputType != currentDeviceInputType)
			{
				Log.Info("Changing device input type to {0} from {1}", _currentDeviceInputType, currentDeviceInputType);
				ObserverList<IObserver>.Enumerator enumerator = Observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnCurrentDeviceInputTypeChanged(_currentDeviceInputType);
				}
				CurrentInputTypeRequiresFocus = DeviceInputTypeRequiresFocus(_currentDeviceInputType);
			}
		}
	}

	public IPointerState Mouse => _mouse;

	public bool MousePresent => Mouse != null;

	public int TouchCount
	{
		get
		{
			int num = 0;
			IPointerState[] touches = _touches;
			foreach (IPointerState pointerState in touches)
			{
				if (pointerState != null && (pointerState.GetButtonState(0).IsDown || pointerState.GetButtonState(0).CurrentState == InputEventButtonState.JustUp))
				{
					num++;
				}
			}
			return num;
		}
	}

	public int MaxTouchCount => 4;

	public int MaxMouseButtonCount => 3;

	public bool BlockUIInput
	{
		get
		{
			return _blockInputFlags.HasFlag(BlockInput.BlockUI);
		}
		set
		{
			_blockInputFlags = (BlockInput)((int)(_blockInputFlags & ~BlockInput.BlockUI) | (value ? 1 : 0));
			_playerActionController.UpdateBlockFlags(_blockInputFlags);
		}
	}

	public bool BlockGameInput
	{
		get
		{
			return _blockInputFlags.HasFlag(BlockInput.BlockGame);
		}
		set
		{
			_blockInputFlags = (BlockInput)((int)(_blockInputFlags & ~BlockInput.BlockGame) | (value ? 2 : 0));
			_playerActionController.UpdateBlockFlags(_blockInputFlags);
		}
	}

	public bool BlockAllInput
	{
		get
		{
			return _blockInputFlags == BlockInput.BlockEverything;
		}
		set
		{
			_blockInputFlags = (value ? BlockInput.BlockEverything : BlockInput.AllowEverything);
			_playerActionController.UpdateBlockFlags(_blockInputFlags);
		}
	}

	public bool BlockActions
	{
		get
		{
			return _blockInputFlags.HasFlag(BlockInput.BlockActions);
		}
		set
		{
			_blockInputFlags = (BlockInput)((int)(_blockInputFlags & ~BlockInput.BlockActions) | (value ? 4 : 0));
			_playerActionController.UpdateBlockFlags(_blockInputFlags);
		}
	}

	public bool CurrentInputTypeRequiresFocus { get; set; }

	protected ObserverList<IObserver> Observers => _observers;

	public virtual void SubscribeToControllerConnectionMessages(IControllerConnectionObserver controllerConnectionObserver)
	{
		_controllerConnectionObservers.Subscribe(controllerConnectionObserver);
		for (int i = 0; i < _controllers.Count; i++)
		{
			controllerConnectionObserver.OnControllerConnected(_controllers[i]);
		}
	}

	public virtual void UnsubscribeFromControllerConnectionMessages(IControllerConnectionObserver controllerConnectionObserver)
	{
		_controllerConnectionObservers.Unsubscribe(controllerConnectionObserver);
	}

	public virtual void ControllerConnected(IController newController)
	{
		if (Diagnostics.Verify(!_controllers.Contains(newController)))
		{
			_controllers.Add(newController);
			newController.OnControllerConnected();
			ObserverList<IControllerConnectionObserver>.Enumerator enumerator = _controllerConnectionObservers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnControllerConnected(newController);
			}
		}
	}

	public virtual void ControllerDisconnected(IController oldController)
	{
		if (Diagnostics.Verify(_controllers.Contains(oldController)))
		{
			_controllers.Remove(oldController);
			oldController.OnControllerDisconnected();
			ObserverList<IControllerConnectionObserver>.Enumerator enumerator = _controllerConnectionObservers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnControllerDisconnected(oldController);
			}
		}
	}

	public void OnGameLoseFocus()
	{
		foreach (ButtonState value in _keys.Values)
		{
			value.SetState(value.StateChangeTime + 0.0001f, InputEventButtonState.Up);
		}
	}

	public virtual void EnsurePollingRewiredAction(int rewiredAction)
	{
		if (!_keys.ContainsKey(rewiredAction))
		{
			_keys.Add(rewiredAction, _scope.Get<ButtonState>());
		}
	}

	public virtual void IgnoreInputAction(int rewiredAction)
	{
		if (InputActionsToIgnore == null)
		{
			InputActionsToIgnore = new HashSet<int>();
		}
		InputActionsToIgnore.Add(rewiredAction);
		if (!_keys.ContainsKey(rewiredAction))
		{
			_keys.Add(rewiredAction, _scope.Get<ButtonState>());
		}
	}

	public virtual void EnsurePollingAxis(int rewiredAxis)
	{
		if (!_axis.ContainsKey(rewiredAxis))
		{
			_axis.Add(rewiredAxis, new AxisState());
		}
	}

	public virtual void IgnorePollingAxis(int axisName)
	{
		if (AxisToIgnore == null)
		{
			AxisToIgnore = new HashSet<int>();
		}
		AxisToIgnore.Add(axisName);
		if (!_axis.ContainsKey(axisName))
		{
			_axis.Add(axisName, new AxisState());
		}
	}

	public void Start()
	{
		_appHasWindowFocus = true;
		_appHasInternalFocus = true;
		_appHasFocus = true;
		_mouse.Initialize(_scope);
		IPointerState[] touches = _touches;
		for (int i = 0; i < touches.Length; i++)
		{
			touches[i].Initialize(_scope);
		}
		CurrentDeviceInputType = _hardware.DefaultDeviceInputType;
	}

	public bool TryGetTouch(int touchIndex, out IPointerState result)
	{
		if (Diagnostics.Verify(touchIndex >= 0 && touchIndex < MaxTouchCount))
		{
			result = _touches[touchIndex];
			return true;
		}
		result = null;
		return false;
	}

	public ButtonState GetKeyButtonState(int rewiredAction)
	{
		if (!_keys.ContainsKey(rewiredAction))
		{
			return null;
		}
		return _keys[rewiredAction];
	}

	public bool GetButton(int inputAction)
	{
		return GetKeyButtonState(inputAction)?.IsDown ?? false;
	}

	public bool GetKeyUp(int inputAction)
	{
		ButtonState keyButtonState = GetKeyButtonState(inputAction);
		if (keyButtonState == null)
		{
			return false;
		}
		return keyButtonState.CurrentState == InputEventButtonState.JustUp;
	}

	public bool GetButtonDown(int keyCode)
	{
		ButtonState keyButtonState = GetKeyButtonState(keyCode);
		if (keyButtonState == null)
		{
			return false;
		}
		return keyButtonState.CurrentState == InputEventButtonState.JustDown;
	}

	public float GetAxis(int axisName)
	{
		if (_axis.ContainsKey(axisName))
		{
			return _axis[axisName].GetAxisValue();
		}
		return 0f;
	}

	public static bool DeviceInputTypeRequiresFocus(DeviceInputType type)
	{
		if (type != DeviceInputType.Controller)
		{
			return type == DeviceInputType.Remote;
		}
		return true;
	}

	public void Tick(float appTime)
	{
		_mouse.Tick(appTime);
		IPointerState[] touches = _touches;
		for (int i = 0; i < touches.Length; i++)
		{
			touches[i].Tick(appTime);
		}
		foreach (ButtonState value in _keys.Values)
		{
			value.Tick(appTime);
		}
		foreach (AxisState value2 in _axis.Values)
		{
			value2.Tick(appTime);
		}
		if (_unblockActionsNextTick)
		{
			BlockActions = false;
			_unblockActionsNextTick = false;
		}
	}

	private void UpdateCurrentInputDevice(InputEvent lastInputEvent)
	{
		switch (lastInputEvent.Source)
		{
		case InputEventSource.Mouse:
			if (lastInputEvent.ButtonState == InputEventButtonState.JustDown)
			{
				CurrentDeviceInputType = DeviceInputType.Mouse;
			}
			break;
		case InputEventSource.Keyboard:
			CurrentDeviceInputType = DeviceInputType.Mouse;
			break;
		case InputEventSource.Touch:
			CurrentDeviceInputType = DeviceInputType.Touch;
			break;
		case InputEventSource.Remote:
			CurrentDeviceInputType = DeviceInputType.Remote;
			break;
		case InputEventSource.Generic:
			CurrentDeviceInputType = DeviceInputType.Controller;
			break;
		}
	}

	private bool IsMouseButton(InputEvent inputEvent)
	{
		if (inputEvent.InputAction != 19 && inputEvent.InputAction != 20)
		{
			return inputEvent.InputAction == 30;
		}
		return true;
	}

	public void OnInputEvent(float appTime, InputEvent inputEvent)
	{
		if (inputEvent.ButtonState != InputEventButtonState.None)
		{
			LastInputTimestamp = appTime;
		}
		UpdateCurrentInputDevice(inputEvent);
		if ((inputEvent.Source == InputEventSource.Mouse || inputEvent.Source == InputEventSource.Touch) && _onScreenToolManager.IsPointInsideTool(inputEvent.PointerPosition))
		{
			return;
		}
		if (!BlockUIInput)
		{
			if (IsMouseButton(inputEvent) || inputEvent.InputAction == 23)
			{
				UpdateMousePointerState(appTime, inputEvent.PointerPosition);
				if (IsMouseButton(inputEvent) && inputEvent.ButtonState != InputEventButtonState.DoubleTapDown)
				{
					UpdateMouseButtonState(appTime, inputEvent.InputAction, inputEvent.ButtonState);
				}
			}
			else if (inputEvent.Source == InputEventSource.Touch)
			{
				PointerMoveToDeltaBehaviour deltaBehaviour = ((inputEvent.ButtonState == InputEventButtonState.JustDown || inputEvent.ButtonState == InputEventButtonState.JustUp) ? PointerMoveToDeltaBehaviour.ResetDelta : PointerMoveToDeltaBehaviour.CalculateDelta);
				UpdateTouchPointerState(appTime, inputEvent.SourceIndex, inputEvent.PointerPosition, deltaBehaviour);
				UpdateTouchButtonState(appTime, inputEvent.SourceIndex, inputEvent.ButtonState);
			}
			else if (inputEvent.ButtonState == InputEventButtonState.Axis)
			{
				AxisInputEvent axisInputEvent = (AxisInputEvent)inputEvent;
				UpdateAxisState(appTime, axisInputEvent.InputAction, axisInputEvent.AxisValue);
			}
			else
			{
				UpdateButtonState(appTime, inputEvent.InputAction, inputEvent.ButtonState);
			}
		}
		if (!BlockActions)
		{
			_playerActionController.OnInputEvent(appTime, inputEvent);
		}
	}

	public bool IsInputEventOverUI(InputEvent inputEvent)
	{
		if (inputEvent is MotorwaysUIInputEvent)
		{
			return true;
		}
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		if (inputEvent.Source == InputEventSource.Mouse)
		{
			pointerEventData.position = Mouse.Position;
		}
		else
		{
			if (inputEvent.Source != InputEventSource.Touch)
			{
				return false;
			}
			if (inputEvent.ButtonState == InputEventButtonState.Up)
			{
				return false;
			}
			if (TryGetTouch(inputEvent.SourceIndex, out var result))
			{
				pointerEventData.position = result.Position;
			}
		}
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current?.RaycastAll(pointerEventData, list);
		return list.Count > 0;
	}

	public void OnWindowFocusChanged(bool appHasWindowFocus)
	{
		Log.Info("Window focus changing from {0} to {1}.", _appHasWindowFocus, appHasWindowFocus);
		_appHasWindowFocus = appHasWindowFocus;
		UpdateAppFocus();
	}

	public void OnInternalFocusChanged(bool appHasInternalFocus)
	{
		Log.Info("Internal focus changing from {0} to {1}.", _appHasInternalFocus, appHasInternalFocus);
		_appHasInternalFocus = appHasInternalFocus;
		UpdateAppFocus();
	}

	public void UpdateButtonState(float appTime, int rewiredInput, InputEventButtonState buttonState)
	{
		if (!_keys.ContainsKey(rewiredInput))
		{
			_keys.Add(rewiredInput, _scope.Get<ButtonState>());
		}
		_keys[rewiredInput].SetState(appTime, buttonState);
	}

	public void UpdateMouseButtonState(float appTime, int rewiredAction, InputEventButtonState buttonState)
	{
		Mouse.SetButtonState(appTime, rewiredAction, buttonState);
	}

	public void UpdateTouchButtonState(float appTime, int touchIndex, InputEventButtonState buttonState)
	{
		if (!TryGetTouch(touchIndex, out var result))
		{
			return;
		}
		if (touchIndex >= MaxRecognizedTouchCount)
		{
			ButtonState buttonState2 = result.GetButtonState(0);
			if (buttonState2.CurrentState == InputEventButtonState.Down)
			{
				buttonState = InputEventButtonState.JustUp;
			}
			else if (buttonState2.CurrentState == InputEventButtonState.Up)
			{
				buttonState = InputEventButtonState.Up;
			}
		}
		result.SetButtonState(appTime, 0, buttonState);
	}

	private void UpdateMousePointerState(float appTime, Vector2 position, PointerMoveToDeltaBehaviour deltaBehaviour = PointerMoveToDeltaBehaviour.CalculateDelta)
	{
		Mouse.MoveTo(appTime, position, deltaBehaviour);
	}

	private void UpdateTouchPointerState(float appTime, int touchIndex, Vector2 position, PointerMoveToDeltaBehaviour deltaBehaviour = PointerMoveToDeltaBehaviour.CalculateDelta)
	{
		if (TryGetTouch(touchIndex, out var result))
		{
			result.MoveTo(appTime, position, deltaBehaviour);
		}
	}

	private void UpdateAxisState(float appTime, int axisName, float newAxisValue)
	{
		if (Diagnostics.Verify(_axis.ContainsKey(axisName)))
		{
			_axis[axisName].SetAxisValue(newAxisValue);
		}
	}

	public IPointerState GetPointerFromInputEvent(InputEvent inputEvent)
	{
		if (inputEvent.Source == InputEventSource.Mouse)
		{
			return Mouse;
		}
		if (inputEvent.Source == InputEventSource.Touch)
		{
			TryGetTouch(inputEvent.SourceIndex, out var result);
			return result;
		}
		if (inputEvent.Source == InputEventSource.Keyboard)
		{
			return Mouse;
		}
		return null;
	}

	public ButtonState GetButtonFromInputEvent(InputEvent inputEvent)
	{
		if (inputEvent.Source == InputEventSource.Keyboard)
		{
			if (_keys.TryGetValue(inputEvent.InputAction, out var value))
			{
				return value;
			}
			return null;
		}
		IPointerState pointerFromInputEvent = GetPointerFromInputEvent(inputEvent);
		if (pointerFromInputEvent != null)
		{
			int buttonIndex = inputEvent.InputAction;
			if (inputEvent.Source == InputEventSource.Touch)
			{
				buttonIndex = 0;
			}
			return pointerFromInputEvent.GetButtonState(buttonIndex);
		}
		return null;
	}

	public void Subscribe(IObserver observer)
	{
		_observers.Subscribe(observer);
	}

	public bool Unsubscribe(IObserver observer)
	{
		return _observers.Unsubscribe(observer);
	}

	private void UpdateAppFocus()
	{
		bool flag = _appHasWindowFocus && _appHasInternalFocus;
		if (flag != _appHasFocus)
		{
			Log.Info("App {0} input focus.", flag ? "has gained" : "no longer has");
			_appHasFocus = flag;
			if (_appHasFocus)
			{
				_unblockActionsNextTick = true;
				return;
			}
			BlockActions = true;
			_unblockActionsNextTick = false;
			_playerActionController.CancelAllActions();
		}
	}

	public static bool HasAController()
	{
		return true;
	}
}
