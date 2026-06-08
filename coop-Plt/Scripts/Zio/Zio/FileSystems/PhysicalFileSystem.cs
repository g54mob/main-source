using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Zio.FileSystems
{
	[DebuggerDisplay("{DebuggerDisplay(),nq}")]
	public class PhysicalFileSystem : FileSystem
	{
		private sealed class Watcher : IFileSystemWatcher, IDisposable
		{
			private readonly PhysicalFileSystem _fileSystem;

			private readonly System.IO.FileSystemWatcher _watcher;

			public IFileSystem FileSystem => _fileSystem;

			public UPath Path { get; }

			public int InternalBufferSize
			{
				get
				{
					return _watcher.InternalBufferSize;
				}
				set
				{
					_watcher.InternalBufferSize = value;
				}
			}

			public NotifyFilters NotifyFilter
			{
				get
				{
					return (NotifyFilters)_watcher.NotifyFilter;
				}
				set
				{
					_watcher.NotifyFilter = (System.IO.NotifyFilters)value;
				}
			}

			public bool EnableRaisingEvents
			{
				get
				{
					return _watcher.EnableRaisingEvents;
				}
				set
				{
					_watcher.EnableRaisingEvents = value;
				}
			}

			public string Filter
			{
				get
				{
					return _watcher.Filter;
				}
				set
				{
					_watcher.Filter = value;
				}
			}

			public bool IncludeSubdirectories
			{
				get
				{
					return _watcher.IncludeSubdirectories;
				}
				set
				{
					_watcher.IncludeSubdirectories = value;
				}
			}

			public event EventHandler<FileChangedEventArgs>? Changed;

			public event EventHandler<FileChangedEventArgs>? Created;

			public event EventHandler<FileChangedEventArgs>? Deleted;

			public event EventHandler<FileSystemErrorEventArgs>? Error;

			public event EventHandler<FileRenamedEventArgs>? Renamed;

			public Watcher(PhysicalFileSystem fileSystem, UPath path)
			{
				_fileSystem = fileSystem ?? throw new ArgumentNullException("fileSystem");
				_watcher = new System.IO.FileSystemWatcher(_fileSystem.ConvertPathToInternal(path))
				{
					Filter = "*"
				};
				Path = path;
				_watcher.Changed += delegate(object sender, FileSystemEventArgs args)
				{
					this.Changed?.Invoke(this, Remap(args));
				};
				_watcher.Created += delegate(object sender, FileSystemEventArgs args)
				{
					this.Created?.Invoke(this, Remap(args));
				};
				_watcher.Deleted += delegate(object sender, FileSystemEventArgs args)
				{
					this.Deleted?.Invoke(this, Remap(args));
				};
				_watcher.Error += delegate(object sender, ErrorEventArgs args)
				{
					this.Error?.Invoke(this, Remap(args));
				};
				_watcher.Renamed += delegate(object sender, RenamedEventArgs args)
				{
					this.Renamed?.Invoke(this, Remap(args));
				};
			}

			~Watcher()
			{
				Dispose(disposing: false);
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			private void Dispose(bool disposing)
			{
				if (disposing)
				{
					_watcher.Dispose();
				}
			}

			private FileChangedEventArgs Remap(FileSystemEventArgs args)
			{
				WatcherChangeTypes changeType = (WatcherChangeTypes)args.ChangeType;
				UPath fullPath = _fileSystem.ConvertPathFromInternal(args.FullPath);
				return new FileChangedEventArgs(FileSystem, changeType, fullPath);
			}

			private FileSystemErrorEventArgs Remap(ErrorEventArgs args)
			{
				return new FileSystemErrorEventArgs(args.GetException());
			}

			private FileRenamedEventArgs Remap(RenamedEventArgs args)
			{
				WatcherChangeTypes changeType = (WatcherChangeTypes)args.ChangeType;
				UPath fullPath = _fileSystem.ConvertPathFromInternal(args.FullPath);
				UPath oldFullPath = _fileSystem.ConvertPathFromInternal(args.OldFullPath);
				return new FileRenamedEventArgs(FileSystem, changeType, fullPath, oldFullPath);
			}
		}

		private const string DrivePrefixOnWindows = "/mnt/";

		private static readonly UPath PathDrivePrefixOnWindows = new UPath("/mnt/");

		private static readonly bool IsOnWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

		protected override void CreateDirectoryImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				throw new UnauthorizedAccessException($"Cannot create a directory in the path `{path}`");
			}
			Directory.CreateDirectory(ConvertPathToInternal(path));
		}

		protected override bool DirectoryExistsImpl(UPath path)
		{
			if (!IsWithinSpecialDirectory(path))
			{
				return Directory.Exists(ConvertPathToInternal(path));
			}
			return SpecialDirectoryExists(path);
		}

		protected override void MoveDirectoryImpl(UPath srcPath, UPath destPath)
		{
			if (IsOnWindows)
			{
				if (IsWithinSpecialDirectory(srcPath))
				{
					if (!SpecialDirectoryExists(srcPath))
					{
						throw FileSystemExceptionHelper.NewDirectoryNotFoundException(srcPath);
					}
					throw new UnauthorizedAccessException($"Cannot move the special directory `{srcPath}`");
				}
				if (IsWithinSpecialDirectory(destPath))
				{
					if (!SpecialDirectoryExists(destPath))
					{
						throw FileSystemExceptionHelper.NewDirectoryNotFoundException(destPath);
					}
					throw new UnauthorizedAccessException($"Cannot move to the special directory `{destPath}`");
				}
			}
			string text = ConvertPathToInternal(srcPath);
			string destDirName = ConvertPathToInternal(destPath);
			if (new FileInfo(text).Exists)
			{
				throw new IOException($"The source `{srcPath}` is not a directory");
			}
			Directory.Move(text, destDirName);
		}

		protected override void DeleteDirectoryImpl(UPath path, bool isRecursive)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				throw new UnauthorizedAccessException($"Cannot delete directory `{path}`");
			}
			Directory.Delete(ConvertPathToInternal(path), isRecursive);
		}

		protected override void CopyFileImpl(UPath srcPath, UPath destPath, bool overwrite)
		{
			if (IsWithinSpecialDirectory(srcPath))
			{
				throw new UnauthorizedAccessException($"The access to `{srcPath}` is denied");
			}
			if (IsWithinSpecialDirectory(destPath))
			{
				throw new UnauthorizedAccessException($"The access to `{destPath}` is denied");
			}
			File.Copy(ConvertPathToInternal(srcPath), ConvertPathToInternal(destPath), overwrite);
		}

		protected override void ReplaceFileImpl(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			if (IsWithinSpecialDirectory(srcPath))
			{
				throw new UnauthorizedAccessException($"The access to `{srcPath}` is denied");
			}
			if (IsWithinSpecialDirectory(destPath))
			{
				throw new UnauthorizedAccessException($"The access to `{destPath}` is denied");
			}
			if (!destBackupPath.IsNull && IsWithinSpecialDirectory(destBackupPath))
			{
				throw new UnauthorizedAccessException($"The access to `{destBackupPath}` is denied");
			}
			if (!destBackupPath.IsNull)
			{
				CopyFileImpl(destPath, destBackupPath, overwrite: true);
			}
			CopyFileImpl(srcPath, destPath, overwrite: true);
			DeleteFileImpl(srcPath);
		}

		protected override long GetFileLengthImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				throw new UnauthorizedAccessException($"The access to `{path}` is denied");
			}
			return new FileInfo(ConvertPathToInternal(path)).Length;
		}

		protected override bool FileExistsImpl(UPath path)
		{
			if (!IsWithinSpecialDirectory(path))
			{
				return File.Exists(ConvertPathToInternal(path));
			}
			return false;
		}

		protected override void MoveFileImpl(UPath srcPath, UPath destPath)
		{
			if (IsWithinSpecialDirectory(srcPath))
			{
				throw new UnauthorizedAccessException($"The access to `{srcPath}` is denied");
			}
			if (IsWithinSpecialDirectory(destPath))
			{
				throw new UnauthorizedAccessException($"The access to `{destPath}` is denied");
			}
			File.Move(ConvertPathToInternal(srcPath), ConvertPathToInternal(destPath));
		}

		protected override void DeleteFileImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				throw new UnauthorizedAccessException($"The access to `{path}` is denied");
			}
			File.Delete(ConvertPathToInternal(path));
		}

		protected override Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			if (IsWithinSpecialDirectory(path))
			{
				throw new UnauthorizedAccessException($"The access to `{path}` is denied");
			}
			return File.Open(ConvertPathToInternal(path), mode, access, share);
		}

		protected override FileAttributes GetAttributesImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				if (path == PathDrivePrefixOnWindows || path == UPath.Root)
				{
					return FileAttributes.Directory | FileAttributes.ReadOnly | FileAttributes.System;
				}
			}
			return File.GetAttributes(ConvertPathToInternal(path));
		}

		protected override void SetAttributesImpl(UPath path, FileAttributes attributes)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				throw new UnauthorizedAccessException($"Cannot set attributes on system directory `{path}`");
			}
			File.SetAttributes(ConvertPathToInternal(path), attributes);
		}

		protected override DateTime GetCreationTimeImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				if (path == PathDrivePrefixOnWindows || path == UPath.Root)
				{
					DateTime dateTime = DateTime.MaxValue;
					DriveInfo[] drives = DriveInfo.GetDrives();
					foreach (DriveInfo driveInfo in drives)
					{
						if (driveInfo.IsReady)
						{
							DateTime creationTime = driveInfo.RootDirectory.CreationTime;
							if (creationTime < dateTime)
							{
								dateTime = creationTime;
							}
						}
					}
					return dateTime;
				}
			}
			return File.GetCreationTime(ConvertPathToInternal(path));
		}

		protected override void SetCreationTimeImpl(UPath path, DateTime time)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				throw new UnauthorizedAccessException($"Cannot set creation time on system directory `{path}`");
			}
			File.SetCreationTime(ConvertPathToInternal(path), time);
		}

		protected override DateTime GetLastAccessTimeImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				if (path == PathDrivePrefixOnWindows || path == UPath.Root)
				{
					DateTime dateTime = DateTime.MaxValue;
					DriveInfo[] drives = DriveInfo.GetDrives();
					foreach (DriveInfo driveInfo in drives)
					{
						if (driveInfo.IsReady)
						{
							DateTime lastAccessTime = driveInfo.RootDirectory.LastAccessTime;
							if (lastAccessTime < dateTime)
							{
								dateTime = lastAccessTime;
							}
						}
					}
					return dateTime;
				}
			}
			return File.GetLastAccessTime(ConvertPathToInternal(path));
		}

		protected override void SetLastAccessTimeImpl(UPath path, DateTime time)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				throw new UnauthorizedAccessException($"Cannot set last access time on system directory `{path}`");
			}
			File.SetLastAccessTime(ConvertPathToInternal(path), time);
		}

		protected override DateTime GetLastWriteTimeImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				if (path == PathDrivePrefixOnWindows || path == UPath.Root)
				{
					DateTime dateTime = DateTime.MaxValue;
					DriveInfo[] drives = DriveInfo.GetDrives();
					foreach (DriveInfo driveInfo in drives)
					{
						if (driveInfo.IsReady)
						{
							DateTime lastWriteTime = driveInfo.RootDirectory.LastWriteTime;
							if (lastWriteTime < dateTime)
							{
								dateTime = lastWriteTime;
							}
						}
					}
					return dateTime;
				}
			}
			return File.GetLastWriteTime(ConvertPathToInternal(path));
		}

		protected override void SetLastWriteTimeImpl(UPath path, DateTime time)
		{
			if (IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				throw new UnauthorizedAccessException($"Cannot set last write time on system directory `{path}`");
			}
			File.SetLastWriteTime(ConvertPathToInternal(path), time);
		}

		protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
		{
			SearchPattern search = SearchPattern.Parse(ref path, ref searchPattern);
			if (IsOnWindows && IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				bool searchForDirectory = searchTarget == SearchTarget.Both || searchTarget == SearchTarget.Directory;
				if (path == UPath.Root)
				{
					if (!searchForDirectory)
					{
						yield break;
					}
					yield return PathDrivePrefixOnWindows;
					if (searchOption != SearchOption.AllDirectories)
					{
						yield break;
					}
					foreach (UPath item in EnumeratePathsImpl(PathDrivePrefixOnWindows, searchPattern, searchOption, searchTarget))
					{
						yield return item;
					}
					yield break;
				}
				if (path == PathDrivePrefixOnWindows)
				{
					List<UPath> pathDrives = new List<UPath>();
					DriveInfo[] drives = DriveInfo.GetDrives();
					foreach (DriveInfo driveInfo in drives)
					{
						if (driveInfo.Name.Length < 2 || driveInfo.Name[1] != ':')
						{
							continue;
						}
						UPath uPath = PathDrivePrefixOnWindows / char.ToLowerInvariant(driveInfo.Name[0]).ToString();
						if (search.Match(uPath))
						{
							pathDrives.Add(uPath);
							if (searchForDirectory)
							{
								yield return uPath;
							}
						}
					}
					if (searchOption != SearchOption.AllDirectories)
					{
						yield break;
					}
					foreach (UPath item2 in pathDrives)
					{
						foreach (UPath item3 in EnumeratePathsImpl(item2, searchPattern, searchOption, searchTarget))
						{
							yield return item3;
						}
					}
					yield break;
				}
			}
			IEnumerable<string> enumerable;
			switch (searchTarget)
			{
			default:
				yield break;
			case SearchTarget.File:
				enumerable = Directory.EnumerateFiles(ConvertPathToInternal(path), searchPattern, searchOption);
				break;
			case SearchTarget.Directory:
				enumerable = Directory.EnumerateDirectories(ConvertPathToInternal(path), searchPattern, searchOption);
				break;
			case SearchTarget.Both:
				enumerable = Directory.EnumerateFileSystemEntries(ConvertPathToInternal(path), searchPattern, searchOption);
				break;
			}
			foreach (string item4 in enumerable)
			{
				if (!IsOnWindows || search.Match(Path.GetFileName(item4)))
				{
					yield return ConvertPathFromInternal(item4);
				}
			}
		}

		protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
		{
			if (IsOnWindows && IsWithinSpecialDirectory(path))
			{
				if (!SpecialDirectoryExists(path))
				{
					throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
				}
				if (path == UPath.Root)
				{
					FileSystemItem item = new FileSystemItem(this, PathDrivePrefixOnWindows, directory: true);
					if (searchPredicate == null || searchPredicate(ref item))
					{
						yield return item;
					}
					if (searchOption != SearchOption.AllDirectories)
					{
						yield break;
					}
					foreach (FileSystemItem item4 in EnumerateItemsImpl(PathDrivePrefixOnWindows, searchOption, searchPredicate))
					{
						yield return item4;
					}
					yield break;
				}
				if (path == PathDrivePrefixOnWindows)
				{
					List<UPath> pathDrives = new List<UPath>();
					DriveInfo[] drives = DriveInfo.GetDrives();
					foreach (DriveInfo driveInfo in drives)
					{
						if (driveInfo.Name.Length >= 2 && driveInfo.Name[1] == ':')
						{
							UPath uPath = PathDrivePrefixOnWindows / char.ToLowerInvariant(driveInfo.Name[0]).ToString();
							pathDrives.Add(uPath);
							FileSystemItem item2 = new FileSystemItem(this, uPath, directory: true);
							if (searchPredicate == null || searchPredicate(ref item2))
							{
								yield return item2;
							}
						}
					}
					if (searchOption != SearchOption.AllDirectories)
					{
						yield break;
					}
					foreach (UPath item5 in pathDrives)
					{
						foreach (FileSystemItem item6 in EnumerateItemsImpl(item5, searchOption, searchPredicate))
						{
							yield return item6;
						}
					}
					yield break;
				}
			}
			string path2 = ConvertPathToInternal(path);
			if (!Directory.Exists(path2))
			{
				yield break;
			}
			IEnumerable<string> enumerable = Directory.EnumerateFileSystemEntries(path2, "*", searchOption);
			foreach (string item7 in enumerable)
			{
				FileInfo fileInfo = new FileInfo(item7);
				UPath uPath2 = ConvertPathFromInternal(item7);
				FileSystemItem item3 = new FileSystemItem
				{
					FileSystem = this,
					AbsolutePath = uPath2,
					Path = uPath2,
					Attributes = fileInfo.Attributes,
					CreationTime = fileInfo.CreationTimeUtc.ToLocalTime(),
					LastAccessTime = fileInfo.LastAccessTimeUtc.ToLocalTime(),
					LastWriteTime = fileInfo.LastWriteTimeUtc.ToLocalTime(),
					Length = fileInfo.Length
				};
				if (searchPredicate == null || searchPredicate(ref item3))
				{
					yield return item3;
				}
			}
		}

		protected override bool CanWatchImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				return SpecialDirectoryExists(path);
			}
			return Directory.Exists(ConvertPathToInternal(path));
		}

		protected override IFileSystemWatcher WatchImpl(UPath path)
		{
			if (IsWithinSpecialDirectory(path))
			{
				throw new UnauthorizedAccessException($"The access to `{path}` is denied");
			}
			return new Watcher(this, path);
		}

		protected override string ConvertPathToInternalImpl(UPath path)
		{
			string fullName = path.FullName;
			if (IsOnWindows)
			{
				if (!fullName.StartsWith("/mnt/") || fullName.Length == "/mnt/".Length || !IsDriveLetter(fullName["/mnt/".Length]))
				{
					throw new ArgumentException("A path on Windows must start by `/mnt/` followed by the drive letter");
				}
				char value = char.ToUpper(fullName["/mnt/".Length]);
				if (fullName.Length != "/mnt/".Length + 1 && fullName["/mnt/".Length + 1] != '/')
				{
					throw new ArgumentException(string.Format("The driver letter `/{0}{1}` must be followed by a `/` or nothing in the path -> `{2}`", "/mnt/", fullName["/mnt/".Length], fullName));
				}
				StringBuilder sharedStringBuilder = UPath.GetSharedStringBuilder();
				sharedStringBuilder.Append(value).Append(":\\");
				if (fullName.Length > "/mnt/".Length + 1)
				{
					sharedStringBuilder.Append(fullName.Replace('/', '\\').Substring("/mnt/".Length + 2));
				}
				string result = sharedStringBuilder.ToString();
				sharedStringBuilder.Length = 0;
				return result;
			}
			return fullName;
		}

		protected override UPath ConvertPathFromInternalImpl(string innerPath)
		{
			if (IsOnWindows)
			{
				if (innerPath.StartsWith("\\\\") || innerPath.StartsWith("\\?"))
				{
					throw new NotSupportedException("Path starting with `\\\\` or `\\?` are not supported -> `" + innerPath + "` ");
				}
				string fullPath = Path.GetFullPath(innerPath);
				if (fullPath.IndexOf(":\\", StringComparison.Ordinal) != 1)
				{
					throw new ArgumentException("Expecting a drive for the path `" + fullPath + "`");
				}
				StringBuilder sharedStringBuilder = UPath.GetSharedStringBuilder();
				sharedStringBuilder.Append("/mnt/").Append(char.ToLowerInvariant(fullPath[0])).Append('/');
				if (fullPath.Length > 2)
				{
					sharedStringBuilder.Append(fullPath.Substring(2));
				}
				string path = sharedStringBuilder.ToString();
				sharedStringBuilder.Length = 0;
				return new UPath(path);
			}
			return innerPath;
		}

		private static bool IsWithinSpecialDirectory(UPath path)
		{
			if (!IsOnWindows)
			{
				return false;
			}
			UPath directory = path.GetDirectory();
			if (!(path == PathDrivePrefixOnWindows) && !(path == UPath.Root) && !(directory == PathDrivePrefixOnWindows))
			{
				return directory == UPath.Root;
			}
			return true;
		}

		private static bool SpecialDirectoryExists(UPath path)
		{
			if (path == PathDrivePrefixOnWindows || path == UPath.Root)
			{
				return true;
			}
			UPath directory = path.GetDirectory();
			if (directory == UPath.Root)
			{
				return false;
			}
			string dirName = path.GetName();
			if (directory == PathDrivePrefixOnWindows && dirName.Length == 1)
			{
				return DriveInfo.GetDrives().Any((DriveInfo p) => char.ToLowerInvariant(p.Name[0]) == dirName[0]);
			}
			return false;
		}

		private static bool IsDriveLetter(char c)
		{
			if (c < 'a' || c > 'z')
			{
				if (c >= 'A')
				{
					return c <= 'Z';
				}
				return false;
			}
			return true;
		}
	}
}
