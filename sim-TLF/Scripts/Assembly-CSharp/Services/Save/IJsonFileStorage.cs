namespace Services.Save
{
	public interface IJsonFileStorage
	{
		void Write<T>(string key, T data);

		bool TryRead<T>(string key, out T data);

		void DeleteKey(string key);

		void DeleteAll();
	}
}
