using Coherence.Log;
using UnityEngine;

namespace Coherence.Prefs
{
	public static class Prefs
	{
		private static readonly Coherence.Log.Logger logger;

		private static IPrefsImplementation implementation;

		public static IPrefsImplementation Implementation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetPoolInUnity()
		{
		}

		public static void Save()
		{
		}

		public static void DeleteAll()
		{
		}

		public static void DeleteKey(string key)
		{
		}

		public static bool HasKey(string key)
		{
			return false;
		}

		public static void SetFloat(string key, float value)
		{
		}

		public static float GetFloat(string key)
		{
			return 0f;
		}

		public static float GetFloat(string key, float defaultValue)
		{
			return 0f;
		}

		public static void SetInt(string key, int value)
		{
		}

		public static int GetInt(string key)
		{
			return 0;
		}

		public static int GetInt(string key, int defaultValue)
		{
			return 0;
		}

		public static void SetString(string key, string value)
		{
		}

		public static string GetString(string key)
		{
			return null;
		}

		public static string GetString(string key, string defaultValue)
		{
			return null;
		}
	}
}
