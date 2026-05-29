namespace FuryStudios.FurySDK
{
	public interface IPlatformPlayerPrefs
	{
		IAsyncRequest Load();

		IAsyncRequest Load(ContainerID container, string filename);

		IAsyncRequest Save();

		void Update();

		IAsyncRequest DeleteAll();

		void DeleteKey(string keyToDel);

		bool HasKey(string key);

		int GetInt(string key, int defaultValue = 0);

		float GetFloat(string key, float defaultValue = 0f);

		string GetString(string key, string defaultValue = "");

		void SetInt(string key, int setValue);

		void SetFloat(string key, float setValue);

		void SetString(string key, string setValue);
	}
}
