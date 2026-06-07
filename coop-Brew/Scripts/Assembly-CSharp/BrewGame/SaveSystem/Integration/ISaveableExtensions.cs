using System.Collections.Generic;

namespace BrewGame.SaveSystem.Integration
{
	public static class ISaveableExtensions
	{
		public static T GetValue<T>(this Dictionary<string, object> state, string key, T defaultValue = default(T))
		{
			return default(T);
		}

		public static float GetFloat(this Dictionary<string, object> state, string key, float defaultValue = 0f)
		{
			return 0f;
		}

		public static int GetInt(this Dictionary<string, object> state, string key, int defaultValue = 0)
		{
			return 0;
		}

		public static bool GetBool(this Dictionary<string, object> state, string key, bool defaultValue = false)
		{
			return false;
		}

		public static string GetString(this Dictionary<string, object> state, string key, string defaultValue = "")
		{
			return null;
		}

		public static long GetLong(this Dictionary<string, object> state, string key, long defaultValue = 0L)
		{
			return 0L;
		}
	}
}
