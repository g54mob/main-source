using System;
using Factory;
using Rewired;
using UnityEngine;

public class tvOSHardwareCapabilities : IHardwareCapabilities
{
	[Dependency]
	private IScope _scope;

	[Dependency]
	private LocaleDatabase _localeDatabase;

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

	public bool SupportsHapticFeedback => false;

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

	public bool SupportsManualExit => false;

	public bool SupportsChangingResolution => false;

	public Vector2Int DefaultMaximumResolution => new Vector2Int(-1, -1);

	public bool SupportsAntiAliasingOptions => false;

	public int DefaultAntiAliasingLevel => 0;

	public bool SupportsMultipleDisplays => false;

	public int DisplayCount => 1;

	public DeviceInputType DefaultDeviceInputType
	{
		get
		{
			DeviceInputType result = DeviceInputType.Remote;
			foreach (Controller controller in ReInput.controllers.Controllers)
			{
				if (RuntimeAppCommandSource.GetSourceForController(controller) == InputEventSource.Generic)
				{
					result = DeviceInputType.Controller;
				}
			}
			return result;
		}
	}

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
	}

	public void Exit()
	{
		Diagnostics.FailAssert("Exit() not supported on tvOS.");
	}

	public virtual void OnAppStart()
	{
		int targetFrameRate = 60;
		if (SystemInfo.deviceModel == "AppleTV5,3")
		{
			targetFrameRate = 30;
		}
		Application.targetFrameRate = targetFrameRate;
		_scope.Get<IInputState>().ControllerConnected(_scope.Get<IGamepadController>());
		_scope.Get<IInputState>().ControllerConnected(_scope.Get<IAppleTVRemoteController>());
	}

	private static string GetDeviceId()
	{
		return SystemInfo.deviceUniqueIdentifier;
	}
}
