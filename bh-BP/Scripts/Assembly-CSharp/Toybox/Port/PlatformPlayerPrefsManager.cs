namespace Toybox.Port
{
	public static class PlatformPlayerPrefsManager
	{
		private static IPlatformPlayerPrefs s_platformPlayerPrefs;

		public static void SetPlatformPlayerPrefs(IPlatformPlayerPrefs platformPlayerPrefs)
		{
		}

		public static void Initialize()
		{
		}

		public static void SetInt(string key, int value)
		{
		}

		public static void SetString(string key, string value)
		{
		}

		public static void SetFloat(string key, float value)
		{
		}

		public static int GetInt(string key, int defaultValue)
		{
			return 0;
		}

		public static string GetString(string key, string defaultValue = "")
		{
			return null;
		}

		public static float GetFloat(string key, float defaultValue)
		{
			return 0f;
		}

		public static bool HasKey(string key)
		{
			return false;
		}

		public static void DeleteKey(string key)
		{
		}

		public static void Save()
		{
		}
	}
}
