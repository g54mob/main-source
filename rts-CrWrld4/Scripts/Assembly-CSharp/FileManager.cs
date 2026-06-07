public class FileManager
{
	public const string PREFS_DATASTORAGELOCATION_KEY = "DATASTORAGELOCATION";

	public const string PREFS_USEDATASTORAGELOCATION_KEY = "USEDATASTORAGELOCATION";

	public static bool useDataStorageCACHED;

	public static string dataStorageLocationCACHED;

	public static string GetAppDataDir()
	{
		return null;
	}

	public static string GetPlatformBaseDir(bool forceDemo = false)
	{
		return null;
	}

	public static void RefreshPlayerPrefs()
	{
	}

	public static string GetBaseDataDirDemo()
	{
		return null;
	}

	public static string GetBaseDataDir()
	{
		return null;
	}

	public static string GetPrintFile()
	{
		return null;
	}

	public static string GetMarkVFile()
	{
		return null;
	}

	public static string GetSavesDir(bool create = true)
	{
		return null;
	}

	public static string GetSavesDir(string missionGUID, GameSpace.CATEGORY category, bool create = false)
	{
		return null;
	}

	private static string Escape(string input)
	{
		return null;
	}

	public static string GetColoniesDir()
	{
		return null;
	}

	public static string GetFavoritesDataDir()
	{
		return null;
	}

	public static string GetMCSDataDir()
	{
		return null;
	}

	public static string GetAchievementsDataDir()
	{
		return null;
	}

	public static string GetRecordingsDir(bool create = true)
	{
		return null;
	}

	public static string GetVideosDir(bool create = true)
	{
		return null;
	}

	public static string GetRunnersBaseDir()
	{
		return null;
	}

	public static string GetEditorBaseDir()
	{
		return null;
	}

	public static string GetFinalizedBaseDir()
	{
		return null;
	}

	public static string[] GetFinalizedDirectories()
	{
		return null;
	}

	public static string CreateFinalizedDirectory(string name)
	{
		return null;
	}

	public static string[] GetEditorDirectories()
	{
		return null;
	}

	public static string CreateEditorDirectory(string name)
	{
		return null;
	}

	public static string GetScreenShotFileName(string extension)
	{
		return null;
	}

	public static string GetRecordingFileName(string baseName, string extension)
	{
		return null;
	}

	public static string GetRecordingFileName(string extension)
	{
		return null;
	}

	public static string GetMVerseMapFileName()
	{
		return null;
	}

	private static string GetUniqueFileName(string fname)
	{
		return null;
	}

	public static string GetDocumentsDir()
	{
		return null;
	}

	public static string GetScriptsDir(string dir)
	{
		return null;
	}

	public static string[] GetScripts(string dir, bool onlyNames = false)
	{
		return null;
	}

	public static bool CreateScript(string dir, string scriptName, string scriptContents)
	{
		return false;
	}

	public static string Sanitize(string filename)
	{
		return null;
	}

	public static bool ScriptExists(string dir, string scriptName)
	{
		return false;
	}

	public static bool DeleteScript(string fullPath)
	{
		return false;
	}

	public static string GetThemesDir()
	{
		return null;
	}

	public static string[] GetThemes()
	{
		return null;
	}

	public static bool CreateTheme(string themeName)
	{
		return false;
	}

	public static bool ThemeExists(string themeName)
	{
		return false;
	}

	public static bool DeleteTheme(string themeName)
	{
		return false;
	}

	public static string GetKeyFile()
	{
		return null;
	}

	private static string GetMachineGUID()
	{
		return null;
	}

	public static string GetKey()
	{
		return null;
	}

	public static void SaveKey(string key)
	{
	}
}
