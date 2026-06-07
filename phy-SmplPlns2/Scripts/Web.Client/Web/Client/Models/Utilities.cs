using System;

namespace Web.Client.Models
{
	public static class Utilities
	{
		public static bool ParseBool(string s, bool defaultValue = false)
		{
			if (bool.TryParse(s, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static double ParseDouble(string s, double defaultValue = 0.0)
		{
			if (double.TryParse(s, out var result))
			{
				return result;
			}
			return defaultValue;
		}

		public static T ParseEnum<T>(string s, T defaultValue) where T : struct
		{
			if (!Enum.TryParse<T>(s, out var result))
			{
				return defaultValue;
			}
			return result;
		}
	}
}
