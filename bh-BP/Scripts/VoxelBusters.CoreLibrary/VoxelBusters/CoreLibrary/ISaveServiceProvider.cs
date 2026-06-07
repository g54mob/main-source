namespace VoxelBusters.CoreLibrary
{
	public interface ISaveServiceProvider
	{
		int GetInt(string key, int defaultValue = 0);

		float GetFloat(string key, float defaultValue = 0f);

		string GetString(string key, string defaultValue = null);

		string[] GetStringArray(string key, string[] defaultValue = null);

		void SetInt(string key, int value);

		void SetFloat(string key, float value);

		void SetString(string key, string value);

		void SetStringArray(string key, string[] value);

		void RemoveKey(string key);

		void Save();
	}
}
