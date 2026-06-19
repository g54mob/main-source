using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformConfiguration_PlatformNameWithVariant", menuName = "Pug/Platform Configuration Asset", order = 0)]
public class PlatformConfiguration : ScriptableObject
{
	public static Action<PlatformConfiguration> OnPlatformConfigurationChanged;

	private static PlatformConfiguration _instance;

	public static PlatformConfiguration Instance => _instance;

	[field: SerializeField]
	public PerformanceDeviceProfile PerformanceDeviceProfile { get; private set; }

	[field: SerializeField]
	public SessionConfiguration SessionConfiguration { get; private set; }

	public static void Init()
	{
		PlatformVariant specificPlatformVariant = GetSpecificPlatformVariant();
		if (TryLoadConfigurationForVariant(specificPlatformVariant, out _instance))
		{
			Debug.Log(string.Format("{0}: successfully loaded specific platform configuration for variant {1}.", "PlatformConfiguration", specificPlatformVariant));
			OnPlatformConfigurationChanged?.Invoke(_instance);
			return;
		}
		specificPlatformVariant = GetBasePlatformVariant(specificPlatformVariant);
		if (TryLoadConfigurationForVariant(specificPlatformVariant, out _instance))
		{
			Debug.Log(string.Format("{0}: successfully loaded base platform configuration for variant {1}.", "PlatformConfiguration", specificPlatformVariant));
			OnPlatformConfigurationChanged?.Invoke(_instance);
			return;
		}
		specificPlatformVariant = PlatformVariant.PC;
		if (TryLoadConfigurationForVariant(specificPlatformVariant, out _instance))
		{
			Debug.LogWarning(string.Format("{0}: loaded fallback platform configuration {1} as no specific or base platform configuration was found.", "PlatformConfiguration", specificPlatformVariant));
			OnPlatformConfigurationChanged?.Invoke(_instance);
			return;
		}
		throw new NotImplementedException("No platform configuration found.");
	}

	public static void SetActivePlatformVariant(PlatformVariant platformVariant)
	{
		Debug.Log(string.Format("{0}: setting platform variant settings to {1}.", "PlatformConfiguration", platformVariant));
		if (!TryLoadConfigurationForVariant(platformVariant, out var platformConfiguration))
		{
			Debug.LogError(string.Format("{0}: failed to load platform configuration for variant {1}.", "PlatformConfiguration", platformVariant));
			return;
		}
		_instance = platformConfiguration;
		OnPlatformConfigurationChanged?.Invoke(_instance);
	}

	private static bool TryLoadConfigurationForVariant(PlatformVariant variant, out PlatformConfiguration platformConfiguration)
	{
		platformConfiguration = Resources.Load<PlatformConfiguration>($"Platform/PlatformConfiguration_{variant}");
		return platformConfiguration != null;
	}

	private static PlatformVariant GetSpecificPlatformVariant()
	{
		switch (Application.platform)
		{
		case RuntimePlatform.PS4:
		case RuntimePlatform.PS5:
			return PlatformVariant.PS5;
		case RuntimePlatform.Switch:
			return PlatformVariant.Switch;
		case RuntimePlatform.Switch2:
			return PlatformVariant.Switch2;
		case RuntimePlatform.GameCoreXboxOne:
			return PlatformVariant.XboxOne;
		case RuntimePlatform.GameCoreXboxSeries:
			return PlatformVariant.XboxSeries;
		case RuntimePlatform.WindowsPlayer:
		case RuntimePlatform.WindowsEditor:
			return PlatformVariant.Windows;
		case RuntimePlatform.LinuxPlayer:
		case RuntimePlatform.LinuxEditor:
			return PlatformVariant.Linux;
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
			return PlatformVariant.MacOs;
		default:
			Debug.LogWarning($"{Application.platform} has no dedicated platform configuration. Defaulting to PC.");
			return PlatformVariant.PC;
		}
	}

	private static PlatformVariant GetBasePlatformVariant(PlatformVariant variant)
	{
		switch (variant)
		{
		case PlatformVariant.PS4Pro:
			return PlatformVariant.PS4;
		case PlatformVariant.SwitchHandheld:
		case PlatformVariant.SwitchDocked:
			return PlatformVariant.Switch;
		case PlatformVariant.Switch2Handheld:
		case PlatformVariant.Switch2Docked:
			return PlatformVariant.Switch2;
		case PlatformVariant.XboxOneS:
		case PlatformVariant.XboxOneX:
			return PlatformVariant.XboxOne;
		case PlatformVariant.XboxSeriesS:
		case PlatformVariant.XboxSeriesX:
			return PlatformVariant.XboxSeries;
		case PlatformVariant.Windows:
		case PlatformVariant.Linux:
		case PlatformVariant.MacOs:
			return PlatformVariant.PC;
		default:
			return variant;
		}
	}
}
