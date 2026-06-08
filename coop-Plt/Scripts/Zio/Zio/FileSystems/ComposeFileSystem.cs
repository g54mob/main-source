using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Zio.FileSystems
{
	public abstract class ComposeFileSystem : FileSystem
	{
		protected bool Owned { get; }

		protected IFileSystem? Fallback { get; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected IFileSystem FallbackSafe
		{
			get
			{
				if (Fallback == null)
				{
					throw new InvalidOperationException("The delegate filesystem for this instance is null");
				}
				return Fallback;
			}
		}

		protected ComposeFileSystem(IFileSystem? fileSystem, bool owned = true)
		{
			Fallback = fileSystem;
			Owned = owned;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && Owned)
			{
				Fallback?.Dispose();
			}
		}

		protected override string DebuggerDisplay()
		{
			return base.DebuggerDisplay() + " (Fallback: " + ((Fallback is FileSystem fileSystem) ? fileSystem.DebuggerKindName() : Fallback?.GetType().Name.Replace("FileSystem", "fs").ToLowerInvariant()) + ")";
		}

		protected override void CreateDirectoryImpl(UPath path)
		{
			FallbackSafe.CreateDirectory(ConvertPathToDelegate(path));
		}

		protected override bool DirectoryExistsImpl(UPath path)
		{
			return FallbackSafe.DirectoryExists(ConvertPathToDelegate(path));
		}

		protected override void MoveDirectoryImpl(UPath srcPath, UPath destPath)
		{
			FallbackSafe.MoveDirectory(ConvertPathToDelegate(srcPath), ConvertPathToDelegate(destPath));
		}

		protected override void DeleteDirectoryImpl(UPath path, bool isRecursive)
		{
			FallbackSafe.DeleteDirectory(ConvertPathToDelegate(path), isRecursive);
		}

		protected override void CopyFileImpl(UPath srcPath, UPath destPath, bool overwrite)
		{
			FallbackSafe.CopyFile(ConvertPathToDelegate(srcPath), ConvertPathToDelegate(destPath), overwrite);
		}

		protected override void ReplaceFileImpl(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			FallbackSafe.ReplaceFile(ConvertPathToDelegate(srcPath), ConvertPathToDelegate(destPath), destBackupPath.IsNull ? destBackupPath : ConvertPathToDelegate(destBackupPath), ignoreMetadataErrors);
		}

		protected override long GetFileLengthImpl(UPath path)
		{
			return FallbackSafe.GetFileLength(ConvertPathToDelegate(path));
		}

		protected override bool FileExistsImpl(UPath path)
		{
			return FallbackSafe.FileExists(ConvertPathToDelegate(path));
		}

		protected override void MoveFileImpl(UPath srcPath, UPath destPath)
		{
			FallbackSafe.MoveFile(ConvertPathToDelegate(srcPath), ConvertPathToDelegate(destPath));
		}

		protected override void DeleteFileImpl(UPath path)
		{
			FallbackSafe.DeleteFile(ConvertPathToDelegate(path));
		}

		protected override Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			return FallbackSafe.OpenFile(ConvertPathToDelegate(path), mode, access, share);
		}

		protected override FileAttributes GetAttributesImpl(UPath path)
		{
			return FallbackSafe.GetAttributes(ConvertPathToDelegate(path));
		}

		protected override void SetAttributesImpl(UPath path, FileAttributes attributes)
		{
			FallbackSafe.SetAttributes(ConvertPathToDelegate(path), attributes);
		}

		protected override DateTime GetCreationTimeImpl(UPath path)
		{
			return FallbackSafe.GetCreationTime(ConvertPathToDelegate(path));
		}

		protected override void SetCreationTimeImpl(UPath path, DateTime time)
		{
			FallbackSafe.SetCreationTime(ConvertPathToDelegate(path), time);
		}

		protected override DateTime GetLastAccessTimeImpl(UPath path)
		{
			return FallbackSafe.GetLastAccessTime(ConvertPathToDelegate(path));
		}

		protected override void SetLastAccessTimeImpl(UPath path, DateTime time)
		{
			FallbackSafe.SetLastAccessTime(ConvertPathToDelegate(path), time);
		}

		protected override DateTime GetLastWriteTimeImpl(UPath path)
		{
			return FallbackSafe.GetLastWriteTime(ConvertPathToDelegate(path));
		}

		protected override void SetLastWriteTimeImpl(UPath path, DateTime time)
		{
			FallbackSafe.SetLastWriteTime(ConvertPathToDelegate(path), time);
		}

		protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
		{
			foreach (UPath item in FallbackSafe.EnumeratePaths(ConvertPathToDelegate(path), searchPattern, searchOption, searchTarget))
			{
				yield return ConvertPathFromDelegate(item);
			}
		}

		protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
		{
			foreach (FileSystemItem item in FallbackSafe.EnumerateItems(ConvertPathToDelegate(path), searchOption, searchPredicate))
			{
				FileSystemItem current = item;
				current.Path = ConvertPathFromDelegate(current.Path);
				yield return current;
			}
		}

		protected override bool CanWatchImpl(UPath path)
		{
			return FallbackSafe.CanWatch(ConvertPathToDelegate(path));
		}

		protected override IFileSystemWatcher WatchImpl(UPath path)
		{
			return FallbackSafe.Watch(ConvertPathToDelegate(path));
		}

		protected override string ConvertPathToInternalImpl(UPath path)
		{
			return FallbackSafe.ConvertPathToInternal(ConvertPathToDelegate(path));
		}

		protected override UPath ConvertPathFromInternalImpl(string innerPath)
		{
			return ConvertPathFromDelegate(FallbackSafe.ConvertPathFromInternal(innerPath));
		}

		protected abstract UPath ConvertPathToDelegate(UPath path);

		protected abstract UPath ConvertPathFromDelegate(UPath path);
	}
}
