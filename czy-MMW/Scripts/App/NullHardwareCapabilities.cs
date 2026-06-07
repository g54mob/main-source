using System;
using UnityEngine;

public class NullHardwareCapabilities : IHardwareCapabilities
{
	public RuntimePlatform Platform => Application.platform;

	public LocaleDatabase.LocaleId PreferredLocaleId => LocaleDatabase.LocaleId.en_US;

	public string PersistentStoragePath => Application.persistentDataPath;

	public DeviceInputType DefaultDeviceInputType => DeviceInputType.Touch;

	public DeviceInputGamepadStyle CurrentGamepadStyle => DeviceInputGamepadStyle.None;

	public string UniqueDeviceId => HashUtils.GetMD5(SystemInfo.deviceUniqueIdentifier);

	public bool SupportsHapticFeedback => false;

	public bool SupportsManualExit => true;

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

	public int DefaultAntiAliasingLevel => 0;

	public bool SupportsMultipleDisplays => false;

	public int DisplayCount => 1;

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
	}
}
