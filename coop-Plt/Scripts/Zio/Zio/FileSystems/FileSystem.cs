using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Zio.FileSystems
{
	public abstract class FileSystem : IFileSystem, IDisposable
	{
		public static readonly DateTime DefaultFileTime = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected bool IsDisposing { get; private set; }

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		protected bool IsDisposed { get; private set; }

		public string? Name { get; set; }

		~FileSystem()
		{
			DisposeInternal(disposing: false);
		}

		public void Dispose()
		{
			DisposeInternal(disposing: true);
			GC.SuppressFinalize(this);
		}

		public void CreateDirectory(UPath path)
		{
			AssertNotDisposed();
			if (path == UPath.Root)
			{
				throw new UnauthorizedAccessException("Cannot create root directory `/`");
			}
			CreateDirectoryImpl(ValidatePath(path));
		}

		protected abstract void CreateDirectoryImpl(UPath path);

		public bool DirectoryExists(UPath path)
		{
			AssertNotDisposed();
			if (path.IsNull)
			{
				return false;
			}
			return DirectoryExistsImpl(ValidatePath(path));
		}

		protected abstract bool DirectoryExistsImpl(UPath path);

		public void MoveDirectory(UPath srcPath, UPath destPath)
		{
			AssertNotDisposed();
			if (srcPath == UPath.Root)
			{
				throw new UnauthorizedAccessException("Cannot move from the source root directory `/`");
			}
			if (destPath == UPath.Root)
			{
				throw new UnauthorizedAccessException("Cannot move to the root directory `/`");
			}
			if (srcPath == destPath)
			{
				throw new IOException($"The source and destination path are the same `{srcPath}`");
			}
			MoveDirectoryImpl(ValidatePath(srcPath, "srcPath"), ValidatePath(destPath, "destPath"));
		}

		protected abstract void MoveDirectoryImpl(UPath srcPath, UPath destPath);

		public void DeleteDirectory(UPath path, bool isRecursive)
		{
			AssertNotDisposed();
			if (path == UPath.Root)
			{
				throw new UnauthorizedAccessException("Cannot delete root directory `/`");
			}
			DeleteDirectoryImpl(ValidatePath(path), isRecursive);
		}

		protected abstract void DeleteDirectoryImpl(UPath path, bool isRecursive);

		internal string DebuggerDisplayInternal()
		{
			return DebuggerDisplay();
		}

		internal string DebuggerKindName()
		{
			string text = GetType().Name.Replace("FileSystem", "fs").ToLowerInvariant();
			if (Name == null)
			{
				return text;
			}
			return text + "-" + Name;
		}

		protected virtual string DebuggerDisplay()
		{
			return DebuggerKindName();
		}

		public void CopyFile(UPath srcPath, UPath destPath, bool overwrite)
		{
			AssertNotDisposed();
			CopyFileImpl(ValidatePath(srcPath, "srcPath"), ValidatePath(destPath, "destPath"), overwrite);
		}

		protected abstract void CopyFileImpl(UPath srcPath, UPath destPath, bool overwrite);

		public void ReplaceFile(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			AssertNotDisposed();
			srcPath = ValidatePath(srcPath, "srcPath");
			destPath = ValidatePath(destPath, "destPath");
			destBackupPath = ValidatePath(destBackupPath, "destBackupPath", allowNull: true);
			if (!FileExistsImpl(srcPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
			if (!FileExistsImpl(destPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
			if (destBackupPath == srcPath)
			{
				throw new IOException($"The source and backup cannot have the same path `{srcPath}`");
			}
			ReplaceFileImpl(srcPath, destPath, destBackupPath, ignoreMetadataErrors);
		}

		protected abstract void ReplaceFileImpl(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors);

		public long GetFileLength(UPath path)
		{
			AssertNotDisposed();
			return GetFileLengthImpl(ValidatePath(path));
		}

		protected abstract long GetFileLengthImpl(UPath path);

		public bool FileExists(UPath path)
		{
			AssertNotDisposed();
			if (path.IsNull)
			{
				return false;
			}
			return FileExistsImpl(ValidatePath(path));
		}

		protected abstract bool FileExistsImpl(UPath path);

		public void MoveFile(UPath srcPath, UPath destPath)
		{
			AssertNotDisposed();
			MoveFileImpl(ValidatePath(srcPath, "srcPath"), ValidatePath(destPath, "destPath"));
		}

		protected abstract void MoveFileImpl(UPath srcPath, UPath destPath);

		public void DeleteFile(UPath path)
		{
			AssertNotDisposed();
			DeleteFileImpl(ValidatePath(path));
		}

		protected abstract void DeleteFileImpl(UPath path);

		public Stream OpenFile(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			AssertNotDisposed();
			return OpenFileImpl(ValidatePath(path), mode, access, share);
		}

		protected abstract Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share);

		public FileAttributes GetAttributes(UPath path)
		{
			AssertNotDisposed();
			return GetAttributesImpl(ValidatePath(path));
		}

		protected abstract FileAttributes GetAttributesImpl(UPath path);

		public void SetAttributes(UPath path, FileAttributes attributes)
		{
			AssertNotDisposed();
			SetAttributesImpl(ValidatePath(path), attributes);
		}

		protected abstract void SetAttributesImpl(UPath path, FileAttributes attributes);

		public DateTime GetCreationTime(UPath path)
		{
			AssertNotDisposed();
			return GetCreationTimeImpl(ValidatePath(path));
		}

		protected abstract DateTime GetCreationTimeImpl(UPath path);

		public void SetCreationTime(UPath path, DateTime time)
		{
			AssertNotDisposed();
			SetCreationTimeImpl(ValidatePath(path), time);
		}

		protected abstract void SetCreationTimeImpl(UPath path, DateTime time);

		public DateTime GetLastAccessTime(UPath path)
		{
			AssertNotDisposed();
			return GetLastAccessTimeImpl(ValidatePath(path));
		}

		protected abstract DateTime GetLastAccessTimeImpl(UPath path);

		public void SetLastAccessTime(UPath path, DateTime time)
		{
			AssertNotDisposed();
			SetLastAccessTimeImpl(ValidatePath(path), time);
		}

		protected abstract void SetLastAccessTimeImpl(UPath path, DateTime time);

		public DateTime GetLastWriteTime(UPath path)
		{
			AssertNotDisposed();
			return GetLastWriteTimeImpl(ValidatePath(path));
		}

		protected abstract DateTime GetLastWriteTimeImpl(UPath path);

		public void SetLastWriteTime(UPath path, DateTime time)
		{
			AssertNotDisposed();
			SetLastWriteTimeImpl(ValidatePath(path), time);
		}

		protected abstract void SetLastWriteTimeImpl(UPath path, DateTime time);

		public IEnumerable<UPath> EnumeratePaths(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
		{
			AssertNotDisposed();
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return EnumeratePathsImpl(ValidatePath(path), searchPattern, searchOption, searchTarget);
		}

		protected abstract IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget);

		public IEnumerable<FileSystemItem> EnumerateItems(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate = null)
		{
			AssertNotDisposed();
			return EnumerateItemsImpl(ValidatePath(path), searchOption, searchPredicate);
		}

		protected abstract IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate);

		public bool CanWatch(UPath path)
		{
			AssertNotDisposed();
			return CanWatchImpl(ValidatePath(path));
		}

		protected virtual bool CanWatchImpl(UPath path)
		{
			return true;
		}

		public IFileSystemWatcher Watch(UPath path)
		{
			AssertNotDisposed();
			UPath uPath = ValidatePath(path);
			if (!CanWatchImpl(uPath))
			{
				throw new NotSupportedException($"The file system or path `{uPath}` does not support watching");
			}
			return WatchImpl(uPath);
		}

		protected abstract IFileSystemWatcher WatchImpl(UPath path);

		public string ConvertPathToInternal(UPath path)
		{
			AssertNotDisposed();
			return ConvertPathToInternalImpl(ValidatePath(path));
		}

		protected abstract string ConvertPathToInternalImpl(UPath path);

		public UPath ConvertPathFromInternal(string systemPath)
		{
			AssertNotDisposed();
			if (systemPath == null)
			{
				throw new ArgumentNullException("systemPath");
			}
			return ValidatePath(ConvertPathFromInternalImpl(systemPath));
		}

		protected abstract UPath ConvertPathFromInternalImpl(string innerPath);

		protected virtual UPath ValidatePathImpl(UPath path, string name = "path")
		{
			if (path.FullName.IndexOf(':') >= 0)
			{
				throw new NotSupportedException($"The path `{path}` cannot contain the `:` character");
			}
			return path;
		}

		protected UPath ValidatePath(UPath path, string name = "path", bool allowNull = false)
		{
			if (allowNull && path.IsNull)
			{
				return path;
			}
			path.AssertAbsolute(name);
			return ValidatePathImpl(path, name);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private void AssertNotDisposed()
		{
			if (IsDisposing || IsDisposed)
			{
				throw new ObjectDisposedException($"This instance `{GetType()}` is already disposed.");
			}
		}

		private void DisposeInternal(bool disposing)
		{
			if (!IsDisposed)
			{
				AssertNotDisposed();
				IsDisposing = true;
				Dispose(disposing);
				IsDisposed = true;
			}
		}
	}
}
