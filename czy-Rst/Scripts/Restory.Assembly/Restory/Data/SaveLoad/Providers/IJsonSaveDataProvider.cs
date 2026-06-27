namespace Restory.Data.SaveLoad.Providers
{
	public interface IJsonSaveDataProvider : ISaveDataProvider
	{
		void Save(string jsonValue, string subFolderFileName);

		string Load(string subFolderFileName);

		void RemoveFile(string fullPath);

		string[] GetDirectoryContent(string subDirectory);
	}
}
