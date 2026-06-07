namespace Gh.Tk
{
	public interface IDataStore
	{
		bool HasValue(string key);

		void SetValue(string key, object value);

		T GetValue<T>(string key);

		T GetOrSetValue<T>(string key, T fallback);

		void RemoveValue(string key);

		IDataStore CreateSubEntry(string key);
	}
}
