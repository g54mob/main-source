using System.IO;
using UnityEngine;

public class AkBasePathGetter
{
	public delegate void CustomPlatformNameGetter(ref string platformName);

	public static CustomPlatformNameGetter GetCustomPlatformName;

	public static readonly string DefaultBasePath = Path.Combine("Audio", "GeneratedSoundBanks");

	private const string DecodedBankFolder = "DecodedBanks";

	private static bool LogWarnings_Internal = true;

	private static AkBasePathGetter Instance;

	private static string DefaultPlatformName = "Windows";

	public static bool LogWarnings
	{
		get
		{
			return LogWarnings_Internal;
		}
		set
		{
			LogWarnings_Internal = value;
		}
	}

	public string SoundBankBasePath { get; private set; }

	public string PersistentDataPath { get; private set; }

	public string DecodedBankFullPath { get; private set; }

	public static string GetPlatformName()
	{
		string platformName = string.Empty;
		GetCustomPlatformName?.Invoke(ref platformName);
		if (!string.IsNullOrEmpty(platformName))
		{
			return platformName;
		}
		return DefaultPlatformName;
	}

	public static string GetPlatformBasePath()
	{
		string platformName = GetPlatformName();
		string text = string.Empty;
		if (string.IsNullOrEmpty(text))
		{
			text = AkWwiseInitializationSettings.ActivePlatformSettings.SoundbankPath;
		}
		text = Path.Combine(Application.streamingAssetsPath, text);
		string path = Path.Combine(text, platformName);
		AkUtilities.FixSlashes(ref path);
		return path;
	}

	public static AkBasePathGetter Get()
	{
		if (Instance == null)
		{
			Instance = new AkBasePathGetter();
			Instance.EvaluateGamePaths();
		}
		return Instance;
	}

	public void EvaluateGamePaths()
	{
		string text = (PersistentDataPath = Application.persistentDataPath);
		string soundBankPersistentDataPath = AkWwiseInitializationSettings.ActivePlatformSettings.SoundBankPersistentDataPath;
		string text2 = null;
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(soundBankPersistentDataPath))
		{
			text2 = Path.GetFullPath(Path.Combine(text, soundBankPersistentDataPath));
			if (LogWarnings)
			{
				Debug.LogFormat("WwiseUnity: Using persistentDataPath. SoundBanks base path set to <{0}>.", text2);
			}
		}
		else
		{
			text2 = GetPlatformBasePath();
			File.Exists(Path.Combine(text2, "Init.bnk"));
		}
		SoundBankBasePath = text2;
		string text3 = null;
		text3 = Path.Combine(text2, "DecodedBanks");
		DecodedBankFullPath = text3;
	}
}
