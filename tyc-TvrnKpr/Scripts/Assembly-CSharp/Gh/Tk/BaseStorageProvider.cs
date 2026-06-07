using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Gh.Tk
{
	public abstract class BaseStorageProvider : IStorageProvider
	{
		private readonly ReaderWriterLockSlim _readerWriterLock;

		public bool DoesFileExist(string relativeFilePath)
		{
			return false;
		}

		protected abstract bool DoesFileExistInternal(string relativeFilePath);

		public void DeleteFile(string relativeFilePath)
		{
		}

		protected abstract void DeleteFileInternal(string relativeFilePath);

		public string WriteFileSync(string relativeFilePath, Stream streamToWrite)
		{
			return null;
		}

		protected abstract string WriteFileSyncInternal(string relativeFilePath, Stream streamToWrite);

		public Stream ReadFileSync(string relativeFilePath)
		{
			return null;
		}

		protected abstract Stream ReadFileSyncInternal(string relativeFilePath);

		public IEnumerable<string> GetFilesInFolder(string relativeFilePath, bool includeSubFolders)
		{
			return null;
		}

		protected abstract IEnumerable<string> GetFilesInFolderInternal(string relativeFilePath, bool includeSubFolders);

		public void DeleteFolder(string relativePath)
		{
		}

		protected abstract void DeleteFolderInternal(string relativePath);
	}
}
