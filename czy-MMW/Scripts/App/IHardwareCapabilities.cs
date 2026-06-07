using System;
using UnityEngine;

public interface IHardwareCapabilities
{
	RuntimePlatform Platform { get; }

	LocaleDatabase.LocaleId PreferredLocaleId { get; }

	string PersistentStoragePath { get; }

	string UniqueDeviceId { get; }

	DeviceInputType DefaultDeviceInputType { get; }

	DeviceInputGamepadStyle CurrentGamepadStyle { get; }

	bool SupportsHapticFeedback { get; }

	bool IsPreventingSleep { get; set; }

	bool SupportsManualExit { get; }

	bool SupportsChangingResolution { get; }

	Vector2Int DefaultMaximumResolution { get; }

	bool SupportsAntiAliasingOptions { get; }

	int DefaultAntiAliasingLevel { get; }

	bool SupportsMultipleDisplays { get; }

	int DisplayCount { get; }

	event Action<DeviceInputGamepadStyle> OnGamepadStyleChanged;

	void OnAppStart();

	void GenerateHapticFeedback(HapticFeedbackType feedback);

	void Exit();
}
