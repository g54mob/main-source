using System.Collections;

namespace DarkTonic.MasterAudio
{
	public static class FilePlayerPrefs
	{
		private static readonly Hashtable PlayerPrefsHashtable;

		private static bool _hashTableChanged;

		private static string _serializedOutput;

		private static readonly string SerializedInput;

		private const string ParametersSeperator = ";";

		private const string KeyValueSeperator = ":";

		private static readonly string FileName;

		static FilePlayerPrefs()
		{
		}

		public static bool HasKey(string key)
		{
			return false;
		}

		public static void SetString(string key, string value)
		{
		}

		public static void SetInt(string key, int value)
		{
		}

		public static void SetFloat(string key, float value)
		{
		}

		public static void SetBool(string key, bool value)
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

		public static int GetInt(string key)
		{
			return 0;
		}

		public static int GetInt(string key, int defaultValue)
		{
			return 0;
		}

		public static float GetFloat(string key)
		{
			return 0f;
		}

		public static float GetFloat(string key, float defaultValue)
		{
			return 0f;
		}

		public static bool GetBool(string key)
		{
			return false;
		}

		public static bool GetBool(string key, bool defaultValue)
		{
			return false;
		}

		public static void DeleteKey(string key)
		{
		}

		public static void DeleteAll()
		{
		}

		public static void Flush()
		{
		}

		private static void Serialize()
		{
		}

		private static void Deserialize()
		{
		}

		private static string EscapeNonSeperators(string inputToEscape)
		{
			return null;
		}

		private static string DeEscapeNonSeperators(string inputToDeEscape)
		{
			return null;
		}

		public static object GetTypeValue(string typeName, string value)
		{
			return null;
		}
	}
}
