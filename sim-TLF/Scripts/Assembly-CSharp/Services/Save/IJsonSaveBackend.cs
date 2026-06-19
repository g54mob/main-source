namespace Services.Save
{
	public interface IJsonSaveBackend
	{
		void WriteKey(string key, string json);

		string ReadKey(string key);

		bool HasKey(string key);

		void DeleteKey(string key);

		void DeleteAll();
	}
}
