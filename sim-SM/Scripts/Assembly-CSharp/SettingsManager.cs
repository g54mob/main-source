using UnityEngine;

public static class SettingsManager
{
	private const string k_FilePath = "settings.conf";

	public static readonly SettingsData DefaultSettings;

	private static string FilePath { get; }

	public static SettingsContainer Container { get; private set; }

	public static SettingsData CreateDefaultSettings()
	{
		return default(SettingsData);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	public static void Load()
	{
	}

	private static void LoadDefaultLanguage()
	{
	}

	private static bool TryLoadFromExistingSave()
	{
		return false;
	}

	public static void Save()
	{
	}

	private static void CreateSettingsFile()
	{
	}
}
