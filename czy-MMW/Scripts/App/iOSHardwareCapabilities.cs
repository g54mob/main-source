using System;
using Factory;
using UnityEngine;

public class iOSHardwareCapabilities : IHardwareCapabilities
{
	[Dependency]
	protected IScope _scope;

	[Dependency]
	private LocaleDatabase _localeDatabase;

	[Dependency]
	private IInputState _inputState;

	private string _deviceId;

	public RuntimePlatform Platform => Application.platform;

	public LocaleDatabase.LocaleId PreferredLocaleId => CoreFoundationLocaleQuery.GetLocaleId(_localeDatabase);

	public string PersistentStoragePath => Application.persistentDataPath;

	public string UniqueDeviceId
	{
		get
		{
			if (_deviceId == null)
			{
				_deviceId = HashUtils.GetMD5(GetDeviceId());
			}
			return _deviceId;
		}
	}

	public bool SupportsHapticFeedback => true;

	public bool IsPreventingSleep
	{
		get
		{
			return IsIdleTimerDisabled();
		}
		set
		{
			SetIdleTimerDisabled(value);
		}
	}

	public bool SupportsManualExit => false;

	public bool SupportsChangingResolution => false;

	public Vector2Int DefaultMaximumResolution => new Vector2Int(-1, -1);

	public bool SupportsAntiAliasingOptions => false;

	public int DefaultAntiAliasingLevel => 0;

	public bool SupportsMultipleDisplays => false;

	public int DisplayCount => 1;

	public DeviceInputType DefaultDeviceInputType => DeviceInputType.Touch;

	public DeviceInputGamepadStyle CurrentGamepadStyle => DeviceInputGamepadStyle.Generic;

	public event Action<DeviceInputGamepadStyle> OnGamepadStyleChanged
	{
		add
		{
		}
		remove
		{
		}
	}

	public void GenerateHapticFeedback(HapticFeedbackType feedback)
	{
		switch (feedback)
		{
		case HapticFeedbackType.LightImpact:
			TriggerLightImpact();
			break;
		case HapticFeedbackType.MediumImpact:
			TriggerMediumImpact();
			break;
		case HapticFeedbackType.HeavyImpact:
			TriggerHeavyImpact();
			break;
		case HapticFeedbackType.Selection:
			TriggerSelection();
			break;
		case HapticFeedbackType.Success:
			TriggerSuccess();
			break;
		case HapticFeedbackType.Warning:
			TriggerWarning();
			break;
		case HapticFeedbackType.Error:
			TriggerError();
			break;
		}
	}

	public void Exit()
	{
		Diagnostics.FailAssert("Exit() not supported on iOS.");
	}

	public virtual void OnAppStart()
	{
		int targetFrameRate = 60;
		if (SystemInfo.deviceModel.StartsWith("iPad5,") || SystemInfo.deviceModel.StartsWith("iPhone8,"))
		{
			targetFrameRate = 30;
		}
		Application.targetFrameRate = targetFrameRate;
		if (FeatureToggle.IsFeatureEnabled(Feature.MockControllerAsRemote))
		{
			_inputState.ControllerConnected(_scope.Get<IAppleTVRemoteController>());
		}
		else
		{
			_inputState.ControllerConnected(_scope.Get<IGamepadController>());
		}
		_inputState.ControllerConnected(_scope.Get<ITouchScreenController>());
	}

	private static string GetDeviceId()
	{
		return SystemInfo.deviceUniqueIdentifier;
	}

	private static void SetIdleTimerDisabled(bool disabled)
	{
	}

	private static bool IsIdleTimerDisabled()
	{
		return false;
	}

	private static void TriggerLightImpact()
	{
	}

	private static void TriggerMediumImpact()
	{
	}

	private static void TriggerHeavyImpact()
	{
	}

	private static void TriggerSelection()
	{
	}

	private static void TriggerSuccess()
	{
	}

	private static void TriggerWarning()
	{
	}

	private static void TriggerError()
	{
	}
}
