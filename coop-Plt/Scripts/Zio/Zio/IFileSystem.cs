using System;
using System.Collections.Generic;
using System.IO;

namespace Zio
{
	public interface IFileSystem : IDisposable
	{
		void CreateDirectory(UPath path);

		bool DirectoryExists(UPath path);

		void MoveDirectory(UPath srcPath, UPath destPath);

		void DeleteDirectory(UPath path, bool isRecursive);

		void CopyFile(UPath srcPath, UPath destPath, bool overwrite);

		void ReplaceFile(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors);

		long GetFileLength(UPath path);

		bool FileExists(UPath path);

		void MoveFile(UPath srcPath, UPath destPath);

		void DeleteFile(UPath path);

		Stream OpenFile(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None);

		FileAttributes GetAttributes(UPath path);

		void SetAttributes(UPath path, FileAttributes attributes);

		DateTime GetCreationTime(UPath path);

		void SetCreationTime(UPath path, DateTime time);

		DateTime GetLastAccessTime(UPath path);

		void SetLastAccessTime(UPath path, DateTime time);

		DateTime GetLastWriteTime(UPath path);

		void SetLastWriteTime(UPath path, DateTime time);

		IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget);

		IEnumerable<FileSystemItem> EnumerateItems(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate = null);

		bool CanWatch(UPath path);

		IFileSystemWatcher Watch(UPath path);

		string ConvertPathToInternal(UPath path);

		UPath ConvertPathFromInternal(string systemPath);
	}
}
