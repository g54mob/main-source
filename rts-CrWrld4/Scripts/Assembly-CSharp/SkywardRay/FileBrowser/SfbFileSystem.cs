using System.Collections.Generic;
using SimpleJSON;

namespace SkywardRay.FileBrowser
{
	public class SfbFileSystem
	{
		private Dictionary<string, SfbFileSystemEntry> entries;

		public SfbFileSystemEntry root;

		private SfbFileSystemThread thread;

		private bool IsUpdatingDirectoryContents;

		public bool IsFake { get; private set; }

		public SfbFileSystem(bool isFake)
		{
		}

		public void Update()
		{
		}

		public void AddEntry(SfbFileSystemEntry entry)
		{
		}

		public void RemoveEntry(SfbFileSystemEntry entry)
		{
		}

		public void DeleteEntryOnDiskAndRemove(SfbFileSystemEntry entry)
		{
		}

		public void NewDirectory(string path)
		{
		}

		public void NewDirectory(string parentPath, string name)
		{
		}

		public static bool RealDirectoryExists(string path)
		{
			return false;
		}

		public bool DirectoryExists(string path)
		{
			return false;
		}

		public bool DirectoryExists(SfbFileSystemEntry entry)
		{
			return false;
		}

		public bool FileExists(string path)
		{
			return false;
		}

		public bool FileExists(SfbFileSystemEntry entry)
		{
			return false;
		}

		public SfbFileSystemEntry GetDirectory(string path)
		{
			return null;
		}

		public SfbFileSystemEntry GetFile(string path)
		{
			return null;
		}

		public List<SfbFileSystemEntry> GetDirectoryContents(SfbFileSystemEntry entry)
		{
			return null;
		}

		public List<SfbFileSystemEntry> GetDirectoryContents(SfbFileSystemEntry entry, SfbFileSortingOrder sortingOrder)
		{
			return null;
		}

		public static char[] GetInvalidFileNameChars()
		{
			return null;
		}

		public static string GetExtension(string path)
		{
			return null;
		}

		public static string GetFileName(string path)
		{
			return null;
		}

		public static string GetParentPath(string path)
		{
			return null;
		}

		public static string GetNormalizedPath(string path)
		{
			return null;
		}

		public static SfbFileSystem CreateFromJSON(string json)
		{
			return null;
		}

		public static void ParseJSONInto(JSONNode N, string parentPath, SfbFileSystem fileSystem)
		{
		}

		public SfbFileSystemEntry GetParentDirectory(string path)
		{
			return null;
		}

		private SfbFileSystemEntry ReadFile(string path)
		{
			return null;
		}

		private SfbFileSystemEntry ReadDirectory(string path)
		{
			return null;
		}

		private void ReadLogicalDrives()
		{
		}

		public SfbFileSystemEntry CreateNewFileAndAddEntry(string path)
		{
			return null;
		}

		public void ReadFileOrBackupFromDisk(SfbFileSystemEntry fileSystemEntry, string backupExtension)
		{
		}

		public void CreateBackup(string path, string backupExtension)
		{
		}

		public void WriteBytesToDisk(string path, byte[] bytes)
		{
		}

		public void AsyncUpdateDirectoryContents(SfbFileSystemEntry fileSystemEntry)
		{
		}

		private void AsyncRecieveDirectoryContents(string path, SfbFileSystemEntry[] contents)
		{
		}
	}
}
