namespace Toybox.Port
{
	public abstract class IPlatformPlayerPrefs
	{
		public virtual void Initialize()
		{
		}

		public abstract bool IsInitialized();

		public virtual void Save()
		{
		}

		public virtual void SetInt(string key, int value)
		{
		}

		public virtual void SetString(string key, string value)
		{
		}

		public virtual void SetFloat(string key, float value)
		{
		}

		public virtual int GetInt(string key, int defaultValue)
		{
			return 0;
		}

		public virtual string GetString(string key, string defaultValue)
		{
			return null;
		}

		public virtual float GetFloat(string key, float defaultValue)
		{
			return 0f;
		}

		public virtual bool HasKey(string key)
		{
			return false;
		}

		public virtual void DeleteKey(string key)
		{
		}
	}
}
