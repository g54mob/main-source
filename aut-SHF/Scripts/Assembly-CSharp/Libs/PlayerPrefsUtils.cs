using System;
using UnityEngine;

namespace Libs
{
	public static class PlayerPrefsUtils
	{
		public static void SetObject<T>(string key, T obj, Version inGameVersion = null)
		{
		}

		public static T GetObject<T>(string key)
		{
			return default(T);
		}

		public static bool TryGetObject<T>(string key, out T obj)
		{
			obj = default(T);
			return false;
		}

		public static bool Save(bool withSave = true, bool withLocal = false)
		{
			return false;
		}

		public static bool HasKey(string key)
		{
			return false;
		}

		public static bool DeleteKey(string key)
		{
			return false;
		}

		public static bool DeleteKeyLocal(string key)
		{
			return false;
		}

		public static bool RecordObject<T>(string key, T obj, Texture2D screenShot, bool isChallengeMode = false)
		{
			return false;
		}

		public static T ReadJson<T>(string json)
		{
			return default(T);
		}

		public static void DeleteAllRecord()
		{
		}

		public static void PreserveImportantFiles()
		{
		}

		public static string RemoveEndPadding(this string str)
		{
			return null;
		}

		public static string AddEndPadding(this string str)
		{
			return null;
		}
	}
}
