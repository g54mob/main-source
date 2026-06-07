using System;
using UnityEngine;

namespace Crosstales.Common.Util
{
	public abstract class CTPlayerPrefs
	{
		public static bool HasKey(string key)
		{
			return false;
		}

		public static void DeleteAll()
		{
		}

		public static void DeleteKey(string key)
		{
		}

		public static void Save()
		{
		}

		public static string GetString(string key)
		{
			return null;
		}

		public static float GetFloat(string key)
		{
			return 0f;
		}

		public static int GetInt(string key)
		{
			return 0;
		}

		public static bool GetBool(string key)
		{
			return false;
		}

		public static DateTime GetDate(string key)
		{
			return default(DateTime);
		}

		public static Vector2 GetVector2(string key)
		{
			return default(Vector2);
		}

		public static Vector3 GetVector3(string key)
		{
			return default(Vector3);
		}

		public static Vector4 GetVector4(string key)
		{
			return default(Vector4);
		}

		public static Quaternion GetQuaternion(string key)
		{
			return default(Quaternion);
		}

		public static Color GetColor(string key)
		{
			return default(Color);
		}

		public static SystemLanguage GetLanguage(string key)
		{
			return default(SystemLanguage);
		}

		public static void SetString(string key, string value)
		{
		}

		public static void SetFloat(string key, float value)
		{
		}

		public static void SetInt(string key, int value)
		{
		}

		public static void SetBool(string key, bool value)
		{
		}

		public static void SetDate(string key, DateTime value)
		{
		}

		public static void SetVector2(string key, Vector2 value)
		{
		}

		public static void SetVector3(string key, Vector3 value)
		{
		}

		public static void SetVector4(string key, Vector4 value)
		{
		}

		public static void SetQuaternion(string key, Quaternion value)
		{
		}

		public static void SetColor(string key, Color value)
		{
		}

		public static void SetLanguage(string key, SystemLanguage language)
		{
		}
	}
}
