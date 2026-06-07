public class AkBasePathGetter
{
	public delegate void CustomPlatformNameGetter(ref string platformName);

	public static CustomPlatformNameGetter GetCustomPlatformName;

	public static readonly string DefaultBasePath;

	private const string DecodedBankFolder = "DecodedBanks";

	private static bool LogWarnings_Internal;

	private static AkBasePathGetter Instance;

	private static string DefaultPlatformName;

	public static bool LogWarnings
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string SoundBankBasePath { get; private set; }

	public string PersistentDataPath { get; private set; }

	public string DecodedBankFullPath { get; private set; }

	public static string GetPlatformName()
	{
		return null;
	}

	public static string GetPlatformBasePath()
	{
		return null;
	}

	public static AkBasePathGetter Get()
	{
		return null;
	}

	public void EvaluateGamePaths()
	{
	}

	public static void AdjustFullBasePathForPlatform(ref string fullBasePath)
	{
	}

	public static string GetPersistentDataPath()
	{
		return null;
	}

	public static bool InitBankExists(string tempSoundBankBasePath)
	{
		return false;
	}

	public static string GetDecodedBankPath()
	{
		return null;
	}
}
