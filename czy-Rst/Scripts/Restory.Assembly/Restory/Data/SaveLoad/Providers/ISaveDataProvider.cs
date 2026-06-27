namespace Restory.Data.SaveLoad.Providers
{
	public interface ISaveDataProvider
	{
		void CreateDirectory(string directory);

		void RemoveDirectory(string directory);

		void CopyDirectory(string directoryA, string directoryB);

		bool FileExists(string subDirectoryFilename);

		bool DirectoryExits(string subDirectory);

		void RenameFile(string oldPathToFile, string newPathToFile);
	}
}
