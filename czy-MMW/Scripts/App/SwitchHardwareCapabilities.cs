using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Factory;
using JetBrains.Annotations;
using Rewired;
using UnityEngine;

public class SwitchHardwareCapabilities : IHardwareCapabilities, IReleasedFromScopeHandler
{
	private struct SwitchVibrationData
	{
		public float amplitudeLow;

		public float amplitudeHigh;

		public float frequencyLow;

		public float frequencyHigh;

		public float durationSeconds;
	}

	[Dependency]
	private IScope _scope;

	[Dependency]
	private LocaleDatabase _localeDatabase;

	[Dependency]
	private InputState _inputState;

	[Dependency]
	private TickRegistry _tickRegistry;

	private Rewired.Player _rewiredPlayer;

	private bool _checkForControllerChange;

	private float _vibrationTimer;

	private Task _rumbleTask;

	private CancellationTokenSource _rumbleTaskCancellationSource;

	private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("SwitchHardwareCapabilities");

	private DeviceInputGamepadStyle _currentGamepadStyle;

	public RuntimePlatform Platform => Application.platform;

	public LocaleDatabase.LocaleId PreferredLocaleId => UnityLocaleQuery.GetLocaleId(_localeDatabase);

	public string PersistentStoragePath => "";

	public string UniqueDeviceId => "nx";

	public bool SupportsHapticFeedback => true;

	public bool SupportsManualExit => false;

	public bool IsPreventingSleep
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool SupportsChangingResolution => false;

	public Vector2Int DefaultMaximumResolution => new Vector2Int(-1, -1);

	public bool SupportsAntiAliasingOptions => false;

	public int DefaultAntiAliasingLevel => 1;

	public bool SupportsMultipleDisplays => false;

	public int DisplayCount => 1;

	public DeviceInputType DefaultDeviceInputType => DeviceInputType.Controller;

	public DeviceInputGamepadStyle CurrentGamepadStyle
	{
		get
		{
			if (_currentGamepadStyle == DeviceInputGamepadStyle.None)
			{
				CurrentGamepadStyle = GetCurrentGamepadStyle();
			}
			return _currentGamepadStyle;
		}
		private set
		{
			if (value != _currentGamepadStyle)
			{
				Log.Info("Changing gamepad style from {0} to {1}.", _currentGamepadStyle, value);
				_currentGamepadStyle = value;
				this.OnGamepadStyleChanged?.Invoke(value);
			}
		}
	}

	public event Action<DeviceInputGamepadStyle> OnGamepadStyleChanged;

	public void GenerateHapticFeedback(HapticFeedbackType feedback)
	{
		if (feedback != HapticFeedbackType.Selection || _inputState.CurrentDeviceInputType == DeviceInputType.Touch)
		{
			SwitchVibrationData vibration = GetVibration(feedback);
			SetVibration(vibration);
		}
	}

	private SwitchVibrationData GetVibration(HapticFeedbackType feedback)
	{
		SwitchVibrationData result = new SwitchVibrationData
		{
			frequencyLow = 160f,
			frequencyHigh = 320f
		};
		switch (feedback)
		{
		case HapticFeedbackType.LightImpact:
		case HapticFeedbackType.Selection:
		case HapticFeedbackType.Warning:
			result.amplitudeLow = 0.05f;
			result.amplitudeHigh = 0.025f;
			result.durationSeconds = 0.05f;
			break;
		case HapticFeedbackType.MediumImpact:
		case HapticFeedbackType.Error:
			result.amplitudeLow = 0.15f;
			result.amplitudeHigh = 0.1f;
			result.durationSeconds = 0.075f;
			break;
		case HapticFeedbackType.HeavyImpact:
		case HapticFeedbackType.Success:
			result.amplitudeLow = 0.5f;
			result.amplitudeHigh = 0.25f;
			result.durationSeconds = 0.1f;
			break;
		}
		return result;
	}

	public void ActivateControllerSelect()
	{
		ShowControllerSupportApplet();
		_checkForControllerChange = true;
	}

	public void Exit()
	{
		Diagnostics.FailAssert("Exit() not supported on Switch.");
	}

	private DeviceInputGamepadStyle GetCurrentGamepadStyle()
	{
		GetLastActiveJoystick();
		return DeviceInputGamepadStyle.SwitchHandheld;
	}

	[CanBeNull]
	private Joystick GetLastActiveJoystick()
	{
		return _rewiredPlayer.controllers.GetLastActiveController<Joystick>() as Joystick;
	}

	public virtual void OnAppStart()
	{
		_inputState.ControllerConnected(_scope.Get<ITouchScreenController>());
		_inputState.ControllerConnected(_scope.Get<IGamepadController>());
		_tickRegistry.AppTicking += Tick;
		_rewiredPlayer = ReInput.players.GetPlayer(0);
		_rewiredPlayer.controllers.AddLastActiveControllerChangedDelegate(OnLastActiveControllerChanged);
		_rumbleTaskCancellationSource = new CancellationTokenSource();
		CancellationToken token = _rumbleTaskCancellationSource.Token;
		_rumbleTask = Task.Run((Action)RumbleThreadProc, token);
	}

	private void RumbleThreadProc()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		long num = stopwatch.ElapsedMilliseconds;
		while (true)
		{
			long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
			float num2 = (float)(elapsedMilliseconds - num) / 1000f;
			num = elapsedMilliseconds;
			if (_vibrationTimer > 0f)
			{
				_vibrationTimer -= num2;
				if (_vibrationTimer <= 0f)
				{
					CancelVibration();
					_vibrationTimer = 0f;
				}
			}
		}
	}

	private void OnLastActiveControllerChanged(Rewired.Player player, Controller controller)
	{
		if (player == _rewiredPlayer && _rewiredPlayer.controllers.joystickCount > 0)
		{
			CurrentGamepadStyle = GetCurrentGamepadStyle();
		}
		CancelVibration();
	}

	private void Tick(float deltaTime)
	{
		if (_rewiredPlayer.controllers.joystickCount == 0)
		{
			Log.Info("No active joysticks! Showing controller selection applet.");
			ActivateControllerSelect();
		}
		if (_checkForControllerChange && _rewiredPlayer.controllers.joystickCount > 0)
		{
			Log.Info("Found a new active joystick.");
			CurrentGamepadStyle = GetCurrentGamepadStyle();
			CancelVibration();
			_checkForControllerChange = false;
		}
	}

	public void OnReleasedFromScope(IScope scope)
	{
		if (_rumbleTask != null && !_rumbleTask.IsCanceled && !_rumbleTask.IsCompleted && _rumbleTaskCancellationSource != null)
		{
			_rumbleTaskCancellationSource.Cancel();
			_rumbleTaskCancellationSource = null;
			_rumbleTask = null;
		}
	}

	private void ShowControllerSupportApplet()
	{
	}

	private void SetVibration(SwitchVibrationData vibrationData)
	{
		GetLastActiveJoystick();
	}

	private void CancelVibration()
	{
		Log.Info("Cancelling all vibration.");
		foreach (Joystick joystick in _rewiredPlayer.controllers.Joysticks)
		{
			_ = joystick;
		}
	}
}
