using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Coherence.Prefs
{
	public class DotnetPrefs : IPrefsImplementation
	{
		private struct PrefsObject
		{
			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public int? Int;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public float? Float;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public string String;

			public PrefsObject SetBool(bool value)
			{
				return default(PrefsObject);
			}

			public PrefsObject SetInt(int value)
			{
				return default(PrefsObject);
			}

			public PrefsObject SetFloat(float value)
			{
				return default(PrefsObject);
			}

			public PrefsObject SetString(string value)
			{
				return default(PrefsObject);
			}
		}

		private Dictionary<string, PrefsObject> prefsByKey;

		private readonly string prefsFilePath;

		private static readonly byte[] xorTable;

		public DotnetPrefs(string prefsFilePath = null)
		{
		}

		public void Save()
		{
		}

		private void Load()
		{
		}

		private void EnsurePrefsPathExists()
		{
		}

		public void DeleteAll()
		{
		}

		public void DeleteKey(string key)
		{
		}

		public bool HasKey(string key)
		{
			return false;
		}

		public void SetFloat(string key, float value)
		{
		}

		public float GetFloat(string key)
		{
			return 0f;
		}

		public float GetFloat(string key, float defaultValue)
		{
			return 0f;
		}

		public void SetBool(string key, bool value)
		{
		}

		public bool GetBool(string key, bool defaultValue)
		{
			return false;
		}

		public void SetInt(string key, int value)
		{
		}

		public int GetInt(string key)
		{
			return 0;
		}

		public int GetInt(string key, int defaultValue)
		{
			return 0;
		}

		public void SetString(string key, string value)
		{
		}

		public string GetString(string key)
		{
			return null;
		}

		public string GetString(string key, string defaultValue)
		{
			return null;
		}

		private ArraySegment<byte> SerializePrefs()
		{
			return default(ArraySegment<byte>);
		}

		private Dictionary<string, PrefsObject> Deserialize(byte[] prefsBinary)
		{
			return null;
		}
	}
}
