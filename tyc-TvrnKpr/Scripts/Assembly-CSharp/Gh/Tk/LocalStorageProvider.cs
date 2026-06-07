using System.Collections.Generic;
using System.IO;

namespace Gh.Tk
{
	public class LocalStorageProvider : BaseStorageProvider
	{
		private const string TEMP_FILE_EXTENSION = "tmp";

		private readonly string _pathPrefix;

		private readonly string _pathSuffix;

		public LocalStorageProvider(string pathPrefix = null, string pathSuffix = null)
		{
		}

		private string GetStoragePath(string relativeFilePath = null)
		{
			return null;
		}

		protected override bool DoesFileExistInternal(string relativeFilePath)
		{
			return false;
		}

		protected override IEnumerable<string> GetFilesInFolderInternal(string relativeFilePath, bool includeSubFolders)
		{
			return null;
		}

		protected override string WriteFileSyncInternal(string relativeFilePath, Stream streamToWrite)
		{
			return null;
		}

		protected override Stream ReadFileSyncInternal(string relativeFilePath)
		{
			return null;
		}

		protected override void DeleteFileInternal(string relativeFilePath)
		{
		}

		protected override void DeleteFolderInternal(string relativePath)
		{
		}
	}
}
