using System.Collections.Generic;
using System.IO;

namespace Gh.Tk
{
	public static class Platform
	{
		public enum StorageLocation
		{
			LocalOnly = 0,
			RemotePreferred = 1,
			Temporary = 2
		}

		private const string TEMP_FOLDER = "temp";

		private static IStorageProvider _localStorage;

		private static IStorageProvider _tempStorage;

		private static IStorageProvider _remoteStorage;

		public static string PERSISTENT_DATA_PATH { get; private set; }

		public static string VARIANT_FOLDER { get; private set; }

		public static string LOCAL_STORAGE_PATH { get; private set; }

		public static string TEMP_STORAGE_PATH { get; private set; }

		public static bool IsRemoteStorageAvailable => false;

		private static IStorageProvider GetStorageProvider(StorageLocation storageLocation)
		{
			return null;
		}

		private static IStorageProvider GetStorageProvider(StorageLocation storageLocation, ref string filePath)
		{
			return null;
		}

		public static void Init()
		{
		}

		public static string GetDownloadStoragePath(string relativeFilePath = null)
		{
			return null;
		}

		public static void DeleteFile(string filePath, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
		}

		public static void DeleteFolder(string folderPath, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
		}

		public static bool DoesFileExist(string filePath, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return false;
		}

		public static string WriteFileUnsafe(string filePath, string dataText, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		public static string WriteFile(string filePath, byte[] bytes, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		public static string WriteFile(string filePath, Stream dataStream, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		private static string WriteFileInternal(string filePath, Stream dataStream, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		public static Stream ReadFile(string filePath, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		public static string ReadTextFile(string filePath, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		public static IEnumerable<string> GetFilesInFolder(string filePath, bool includeSubFolders, StorageLocation storageLocation = StorageLocation.RemotePreferred)
		{
			return null;
		}

		public static string SanitizePathCrossPlatform(string path)
		{
			return null;
		}

		public static byte[] StreamToByteArray(Stream stream)
		{
			return null;
		}

		public static string SanitizeFileName(string saveName)
		{
			return null;
		}

		public static void OpenInExplorer(string path)
		{
		}
	}
}
