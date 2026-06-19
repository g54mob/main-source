namespace PugMod
{
	public interface IConfig
	{
		IConfigEntry<T> Register<T>(string mod, string section, string description, string key, T defaultValue = default(T));

		bool TryGet<T>(string mod, string section, string key, out T value);

		T Get<T>(string mod, string section, string key);

		void Set<T>(string mod, string section, string key, T value);
	}
}
