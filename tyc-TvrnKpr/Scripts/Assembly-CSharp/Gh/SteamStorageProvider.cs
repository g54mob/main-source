using System.Collections.Generic;
using System.IO;
using Gh.Tk;

namespace Gh
{
	public class SteamStorageProvider : BaseStorageProvider
	{
		private List<string> FilesOnCloud => null;

		protected override bool DoesFileExistInternal(string relativeFilePath)
		{
			return false;
		}

		protected override void DeleteFileInternal(string relativeFilePath)
		{
		}

		protected override string WriteFileSyncInternal(string relativeFilePath, Stream streamToWrite)
		{
			return null;
		}

		protected override Stream ReadFileSyncInternal(string relativeFilePath)
		{
			return null;
		}

		protected override IEnumerable<string> GetFilesInFolderInternal(string relativeFilePath, bool includeSubFolders)
		{
			return null;
		}

		protected override void DeleteFolderInternal(string relativePath)
		{
		}
	}
}
