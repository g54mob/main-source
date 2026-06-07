using System;
using System.Collections.Generic;
using Factory;
using Rewired;
using UnityEngine;

public class RuntimeAppCommandSource : IAppCommandSource
{
	[Dependency]
	private Scope _scope;

	private List<IAppCommand> _frameCommands = new List<IAppCommand>(8);

	private float _absoluteRealTimeAtStart;

	[Dependency]
	private InputState inputState;

	private float _absoluteTime = -1f;

	private bool hasInitialized;

	private bool _appHasFocus;

	private bool _hasAppFocusChanged;

	private Rewired.Player _rewiredPlayer;

	private int _currentControllerMapCategory;

	private InputEventSource _lastActiveInputSource;

	private int _framesSinceLastTouch;

	private const int NumberOfFramesToIgnoreMouseAfterTouch = 30;

	private static bool _wasTouchingDs4Touchpad = false;

	private static readonly Guid SiriRemoteGuid = new Guid("bc043dba-df07-4135-929c-5b4398d29579");

	public bool AppHasFocus
	{
		get
		{
			return _appHasFocus;
		}
		set
		{
			if (_appHasFocus != value)
			{
				_appHasFocus = value;
				_hasAppFocusChanged = true;
			}
		}
	}

	public void Start()
	{
		_appHasFocus = true;
		_hasAppFocusChanged = false;
		_rewiredPlayer = ReInput.players.GetPlayer(0);
		ReInput.ControllerConnectedEvent += OnRewiredControllerConnected;
		ReInput.controllers.AddLastActiveControllerChangedDelegate(OnLastActiveControllerChanged);
		new GameObject("FocusListener").AddComponent<ApplicationFocusListener>().Initialize(this);
		Input.simulateMouseWithTouches = false;
		_absoluteRealTimeAtStart = Time.time;
		_absoluteTime = -1f;
	}

	public IEnumerable<IAppCommand> GetFrameCommands()
	{
		_frameCommands.Clear();
		float num = Time.time - _absoluteRealTimeAtStart;
		if (!hasInitialized)
		{
			hasInitialized = true;
			ConfigureDeviceCommand configureDeviceCommand = _scope.Get<ConfigureDeviceCommand>();
			configureDeviceCommand.Initialize();
			_frameCommands.Add(configureDeviceCommand);
			InitRandomCommand initRandomCommand = _scope.Get<InitRandomCommand>();
			initRandomCommand.Configure((uint)(Random.Double() * 4294967295.0));
			_frameCommands.Add(initRandomCommand);
		}
		if (_hasAppFocusChanged)
		{
			_hasAppFocusChanged = false;
			ChangeWindowFocusCommand changeWindowFocusCommand = _scope.Get<ChangeWindowFocusCommand>();
			changeWindowFocusCommand.Configure(_appHasFocus);
			_frameCommands.Add(changeWindowFocusCommand);
		}
		Touch[] touches = Input.touches;
		for (int i = 0; i < touches.Length; i++)
		{
			Touch touch = touches[i];
			InputEventButtonState inputEventButtonState = TouchPhaseToButtonState(touch.phase);
			InputEvent inputEvent = InputEvent.CreateTouchEvent(_scope, touch.fingerId, inputEventButtonState, touch.position);
			ProcessInputEventCommand processInputEventCommand = _scope.Get<ProcessInputEventCommand>();
			processInputEventCommand.Configure(num, inputEvent);
			_frameCommands.Add(processInputEventCommand);
			if (inputEventButtonState == InputEventButtonState.JustDown)
			{
				_framesSinceLastTouch = 0;
			}
		}
		bool flag = FeatureToggle.IsFeatureEnabled(Feature.MockPhone);
		bool flag2 = _framesSinceLastTouch <= 30;
		flag2 = flag2 || flag;
		if (Input.mousePresent)
		{
			Vector2 screenPosition = _rewiredPlayer.controllers.Mouse.screenPosition;
			Vector2 position = inputState.Mouse.Position;
			if (!Mathf.Approximately(position.x, screenPosition.x) || !Mathf.Approximately(position.y, screenPosition.y))
			{
				if (flag && _rewiredPlayer.controllers.Mouse.GetButton(0) && !_rewiredPlayer.controllers.Mouse.GetButtonDown(0))
				{
					InputEvent inputEvent2 = InputEvent.CreateTouchEvent(_scope, 0, InputEventButtonState.Down, screenPosition);
					ProcessInputEventCommand processInputEventCommand2 = _scope.Get<ProcessInputEventCommand>();
					processInputEventCommand2.Configure(num, inputEvent2);
					_frameCommands.Add(processInputEventCommand2);
					_framesSinceLastTouch = 0;
				}
				InputEvent inputEvent3 = InputEvent.CreateMouseEvent(_scope, 23, InputEventButtonState.None, screenPosition);
				ProcessInputEventCommand processInputEventCommand3 = _scope.Get<ProcessInputEventCommand>();
				processInputEventCommand3.Configure(num, inputEvent3);
				_frameCommands.Add(processInputEventCommand3);
			}
		}
		if (inputState.AxisToPoll != null)
		{
			foreach (int item in inputState.AxisToPoll)
			{
				if (inputState.AxisToIgnore == null || !inputState.AxisToIgnore.Contains(item))
				{
					float axis = _rewiredPlayer.GetAxis(item);
					if (!Mathf.Approximately(inputState.GetAxis(item), axis))
					{
						AxisInputEvent inputEvent4 = AxisInputEvent.CreateAxisEvent(_scope, item, axis, _lastActiveInputSource);
						ProcessInputEventCommand processInputEventCommand4 = _scope.Get<ProcessInputEventCommand>();
						processInputEventCommand4.Configure(num, inputEvent4);
						_frameCommands.Add(processInputEventCommand4);
					}
				}
			}
		}
		if (inputState.InputActionsToPoll != null)
		{
			HashSet<int> inputActionsToIgnore = inputState.InputActionsToIgnore;
			foreach (int item2 in inputState.InputActionsToPoll)
			{
				if (inputActionsToIgnore != null && inputActionsToIgnore.Contains(item2))
				{
					continue;
				}
				if (_rewiredPlayer.GetButtonDown(item2))
				{
					InputEvent inputEvent5 = CreateInputEventFor(item2, InputEventButtonState.JustDown, _lastActiveInputSource);
					if (inputEvent5.Source != InputEventSource.Mouse || !flag2)
					{
						ProcessInputEventCommand processInputEventCommand5 = _scope.Get<ProcessInputEventCommand>();
						processInputEventCommand5.Configure(num, inputEvent5);
						_frameCommands.Add(processInputEventCommand5);
					}
				}
				if (_rewiredPlayer.GetButtonDoublePressDown(item2))
				{
					InputEvent inputEvent6 = CreateInputEventFor(item2, InputEventButtonState.DoubleTapDown, _lastActiveInputSource);
					if (inputEvent6.Source != InputEventSource.Mouse || !flag2)
					{
						ProcessInputEventCommand processInputEventCommand6 = _scope.Get<ProcessInputEventCommand>();
						processInputEventCommand6.Configure(num, inputEvent6);
						_frameCommands.Add(processInputEventCommand6);
					}
				}
				if (_rewiredPlayer.GetButtonUp(item2))
				{
					InputEvent inputEvent7 = CreateInputEventFor(item2, InputEventButtonState.JustUp, _lastActiveInputSource);
					if (inputEvent7.Source != InputEventSource.Mouse || !flag2)
					{
						ProcessInputEventCommand processInputEventCommand7 = _scope.Get<ProcessInputEventCommand>();
						processInputEventCommand7.Configure(num, inputEvent7);
						_frameCommands.Add(processInputEventCommand7);
					}
				}
			}
		}
		if (flag)
		{
			InputEventButtonState inputEventButtonState2 = InputEventButtonState.None;
			if (_rewiredPlayer.controllers.Mouse.GetButtonDown(0))
			{
				inputEventButtonState2 = InputEventButtonState.JustDown;
			}
			else if (_rewiredPlayer.controllers.Mouse.GetButtonUp(0))
			{
				inputEventButtonState2 = InputEventButtonState.JustUp;
			}
			else if (_rewiredPlayer.controllers.Mouse.GetButton(0))
			{
				inputEventButtonState2 = InputEventButtonState.Down;
			}
			if (inputEventButtonState2 != InputEventButtonState.None)
			{
				InputEvent inputEvent8 = InputEvent.CreateTouchEvent(_scope, 0, inputEventButtonState2, _rewiredPlayer.controllers.Mouse.screenPosition);
				ProcessInputEventCommand processInputEventCommand8 = _scope.Get<ProcessInputEventCommand>();
				processInputEventCommand8.Configure(num, inputEvent8);
				_frameCommands.Add(processInputEventCommand8);
			}
		}
		TickAppCommand tickAppCommand = _scope.Get<TickAppCommand>();
		float frameTime = 0f;
		float num2 = 1f;
		if (_absoluteTime >= 0f)
		{
			frameTime = (num - _absoluteTime) * num2;
		}
		_absoluteTime = num;
		tickAppCommand.Configure(num, frameTime);
		_frameCommands.Add(tickAppCommand);
		_framesSinceLastTouch++;
		return _frameCommands;
	}

	public static InputEventSource GetSourceForController(Controller controller)
	{
		ApplicationFocusListener.LastKnownController = controller;
		if (controller.type == ControllerType.Keyboard || controller.type == ControllerType.Mouse)
		{
			Diagnostics.Log.Info("MotorwaysInputEvent", $"GetSourceForController {controller.type}");
			return InputEventSource.Keyboard;
		}
		if (FeatureToggle.IsFeatureEnabled(Feature.MockControllerAsRemote))
		{
			return InputEventSource.Remote;
		}
		return InputEventSource.Generic;
	}

	private InputEvent CreateInputEventFor(int inputAction, InputEventButtonState state, InputEventSource source)
	{
		if (inputAction == 19 || inputAction == 20 || inputAction == 30)
		{
			return InputEvent.CreateMouseEvent(_scope, inputAction, state, _rewiredPlayer.controllers.Mouse.screenPosition);
		}
		return InputEvent.CreateEvent(_scope, inputAction, state, source);
	}

	public void SetRewiredMode(int mode)
	{
		_currentControllerMapCategory = mode;
		if (_rewiredPlayer != null)
		{
			_rewiredPlayer.controllers.maps.SetAllMapsEnabled(state: false);
			_rewiredPlayer.controllers.maps.SetMapsEnabled(state: true, mode);
		}
	}

	private void OnRewiredControllerConnected(ControllerStatusChangedEventArgs eventArgs)
	{
		SetRewiredMode(_currentControllerMapCategory);
	}

	private void OnLastActiveControllerChanged(Controller newController)
	{
		_lastActiveInputSource = GetSourceForController(newController);
	}

	private InputEventButtonState TouchPhaseToButtonState(TouchPhase phase)
	{
		return phase switch
		{
			TouchPhase.Began => InputEventButtonState.JustDown, 
			TouchPhase.Moved => InputEventButtonState.Down, 
			TouchPhase.Stationary => InputEventButtonState.Down, 
			TouchPhase.Ended => InputEventButtonState.JustUp, 
			TouchPhase.Canceled => InputEventButtonState.Up, 
			_ => InputEventButtonState.None, 
		};
	}
}
