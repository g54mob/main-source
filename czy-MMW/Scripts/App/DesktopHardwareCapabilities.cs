using System;
using Factory;
using UnityEngine;

public class DesktopHardwareCapabilities : IHardwareCapabilities
{
	[Dependency]
	private IScope _scope;

	[Dependency]
	private LocaleDatabase _localeDatabase;

	[Dependency]
	private IInputState _inputState;

	private string _deviceId;

	private bool _hasHighPowerGpu;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DesktopHardwareCapabilities");

	public RuntimePlatform Platform => Application.platform;

	public LocaleDatabase.LocaleId PreferredLocaleId => UnityLocaleQuery.GetLocaleId(_localeDatabase);

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

	public DeviceInputType DefaultDeviceInputType => DeviceInputType.Mouse;

	public DeviceInputGamepadStyle CurrentGamepadStyle => DeviceInputGamepadStyle.Generic;

	public bool SupportsHapticFeedback => false;

	public bool SupportsManualExit => true;

	public bool SupportsChangingResolution => true;

	public Vector2Int DefaultMaximumResolution
	{
		get
		{
			if (!_hasHighPowerGpu)
			{
				return new Vector2Int(1920, 1080);
			}
			return new Vector2Int(-1, -1);
		}
	}

	public bool SupportsMultipleDisplays => DisplayCount > 1;

	public int DisplayCount => MultiDisplayCapabilitiesBridge.GetDisplayCount();

	public bool SupportsAntiAliasingOptions => !UsingOpenGL;

	public int DefaultAntiAliasingLevel
	{
		get
		{
			if (!_hasHighPowerGpu || UsingOpenGL)
			{
				return 0;
			}
			return 1;
		}
	}

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

	private static bool UsingOpenGL => SystemInfo.graphicsDeviceVersion.Contains("OpenGL");

	public static Vector2Int SafeAreaDimensions
	{
		get
		{
			if (Screen.resolutions.Length != 0)
			{
				Resolution resolution = Screen.resolutions[Screen.resolutions.Length - 1];
				return new Vector2Int(resolution.width, resolution.height - SafeAreaHeight);
			}
			return Vector2Int.zero;
		}
	}

	public static int SafeAreaHeight => GetSafeAreaHeight();

	public static bool HasHighPowerGpu
	{
		get
		{
			if (Application.platform == RuntimePlatform.OSXPlayer)
			{
				string deviceModel = SystemInfo.deviceModel;
				if (deviceModel.StartsWith("Macmini"))
				{
					string[] array = deviceModel.Substring(7).Split(new char[1] { ',' });
					if (array.Length != 0 && int.TryParse(array[0], out var result) && result <= 8)
					{
						return false;
					}
				}
			}
			return true;
		}
	}

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
		Application.Quit();
	}

	public virtual void OnAppStart()
	{
		_hasHighPowerGpu = HasHighPowerGpu;
		if (FeatureToggle.IsFeatureEnabled(Feature.MockControllerAsRemote))
		{
			_inputState.ControllerConnected(_scope.Get<IAppleTVRemoteController>());
		}
		else
		{
			_inputState.ControllerConnected(_scope.Get<IGamepadController>());
		}
		_inputState.ControllerConnected(_scope.Get<IMouseController>());
		_inputState.ControllerConnected(_scope.Get<IKeyboardController>());
		_inputState.ControllerConnected(_scope.Get<ITouchScreenController>());
		SetMinimumWindowAspectRatio(1.3333334f);
		SetMaximumWindowAspectRatio(2.1666667f);
	}

	private static string GetDeviceId()
	{
		string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		if (string.IsNullOrEmpty(deviceUniqueIdentifier))
		{
			return "";
		}
		return deviceUniqueIdentifier;
	}

	private static void HideWindow()
	{
	}

	private static void SetMinimumWindowSize(int width, int height)
	{
	}

	private static void SetMinimumWindowAspectRatio(float minimumAspectRatio)
	{
	}

	private static void SetMaximumWindowAspectRatio(float maximumAspectRatio)
	{
	}

	private static int GetSafeAreaHeight()
	{
		return 0;
	}

	public static Vector2Int GetClosestResolution(Vector2Int resolution)
	{
		float num = -1f;
		Vector2Int result = Vector2Int.zero;
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution resolution2 = resolutions[i];
			float magnitude = (new Vector2Int(resolution2.width, resolution2.height) - resolution).magnitude;
			if (num < 0f || num > magnitude)
			{
				num = magnitude;
				result = new Vector2Int(resolution2.width, resolution2.height);
			}
		}
		return result;
	}
}
