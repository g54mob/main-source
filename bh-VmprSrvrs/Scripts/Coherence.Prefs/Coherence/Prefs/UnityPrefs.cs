namespace Coherence.Prefs
{
	public sealed class UnityPrefs : IPrefsImplementation
	{
		public void Save()
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

		public void SetBool(string key, bool value)
		{
		}

		public bool GetBool(string key, bool defaultValue)
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
	}
}
