using UnityEngine;

namespace Kitchen
{
	public static class PlayerPrefsHelpers
	{
		public static void SetBool(string key, bool value)
		{
			PlayerPrefs.SetInt(key, value ? 1 : 0);
		}

		public static bool GetBool(string key)
		{
			return (float)PlayerPrefs.GetInt(key) > 0.5f;
		}

		public static bool Require(string key, out bool result)
		{
			result = false;
			if (!PlayerPrefs.HasKey(key))
			{
				return false;
			}
			result = GetBool(key);
			return true;
		}

		public static bool Require(string key, out int result)
		{
			result = 0;
			if (!PlayerPrefs.HasKey(key))
			{
				return false;
			}
			result = PlayerPrefs.GetInt(key);
			return true;
		}

		public static bool Require(string key, out float result)
		{
			result = 0f;
			if (!PlayerPrefs.HasKey(key))
			{
				return false;
			}
			result = PlayerPrefs.GetFloat(key);
			return true;
		}

		public static bool Require(string key, out string result)
		{
			result = null;
			if (!PlayerPrefs.HasKey(key))
			{
				return false;
			}
			result = PlayerPrefs.GetString(key);
			return true;
		}
	}
}
