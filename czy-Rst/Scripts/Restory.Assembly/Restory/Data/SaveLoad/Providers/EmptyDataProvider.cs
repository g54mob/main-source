using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Restory.Data.SaveLoad.Providers
{
	public class EmptyDataProvider : IJsonSaveDataProvider, ISaveDataProvider, IJsonSaveDataProviderAsync
	{
		public string RootDirectory => string.Empty;

		public void CopyDirectory(string directoryA, string directoryB)
		{
			Debug.Log("[EmptyDataProvider] Finished CopyDirectory()");
		}

		public void CreateDirectory(string directory)
		{
			Debug.Log("[EmptyDataProvider] Finished CreateDirectory()");
		}

		public bool DirectoryExits(string subDirectory)
		{
			Debug.Log("[EmptyDataProvider] Finished DirectoryExits()");
			return false;
		}

		public void RenameFile(string oldPathToFile, string newPathToFile)
		{
			Debug.Log("[EmptyDataProvider] Finished RenameFile()");
		}

		public bool FileExists(string directory)
		{
			Debug.Log("[EmptyDataProvider] Finished FileExists()");
			return false;
		}

		public string Load(string subFolderFileName)
		{
			Debug.Log("[EmptyDataProvider] Finished Load()");
			return null;
		}

		public Task<string> LoadAsync(string subFolderFileName)
		{
			Debug.Log("[EmptyDataProvider] Finished LoadAsync()");
			return null;
		}

		public void RemoveFile(string fullPath)
		{
			Debug.Log("[EmptyDataProvider] Finished RemoveFile()");
		}

		public string[] GetDirectoryContent(string subDirectory)
		{
			Debug.Log("[EmptyDataProvider] Finished GetDirectoryContent()");
			return Array.Empty<string>();
		}

		public void RemoveDirectory(string directory)
		{
			Debug.Log("[EmptyDataProvider] Finished RemoveDirectory()");
		}

		public void Save(string jsonValue, string subFolderFileName)
		{
			Debug.Log("[EmptyDataProvider] Finished Save()");
		}

		public Task SaveAsync(string jsonValue, string subFolderFileName)
		{
			Debug.Log("[EmptyDataProvider] Finished SaveAsync()");
			return Task.CompletedTask;
		}
	}
}
