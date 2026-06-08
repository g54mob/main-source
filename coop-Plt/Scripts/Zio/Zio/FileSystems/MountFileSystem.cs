using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Zio.FileSystems
{
	[DebuggerDisplay("{DebuggerDisplay(),nq} Count={_mounts.Count}")]
	[DebuggerTypeProxy(typeof(DebuggerProxy))]
	public class MountFileSystem : ComposeFileSystem
	{
		private class AggregateWatcher : AggregateFileSystemWatcher
		{
			private readonly MountFileSystem _fileSystem;

			public AggregateWatcher(MountFileSystem fileSystem, UPath path)
				: base(fileSystem, path)
			{
				_fileSystem = fileSystem;
			}

			protected override void Dispose(bool disposing)
			{
				if (disposing && !_fileSystem.IsDisposing)
				{
					_fileSystem._watchers.Remove(this);
				}
			}
		}

		private class WrapWatcher : WrapFileSystemWatcher
		{
			private readonly UPath _mountPath;

			public WrapWatcher(IFileSystem fileSystem, UPath mountPath, UPath path, IFileSystemWatcher watcher)
				: base(fileSystem, path, watcher)
			{
				_mountPath = mountPath;
			}

			protected override UPath? TryConvertPath(UPath pathFromEvent)
			{
				if (!_mountPath.IsNull)
				{
					return _mountPath / pathFromEvent.ToRelative();
				}
				return pathFromEvent;
			}
		}

		private class UPathLengthComparer : IComparer<UPath>
		{
			public int Compare(UPath x, UPath y)
			{
				int num = y.FullName.Length.CompareTo(x.FullName.Length);
				if (num != 0)
				{
					return num;
				}
				return string.CompareOrdinal(x.FullName, y.FullName);
			}
		}

		private readonly struct SearchLocation
		{
			public IFileSystem FileSystem { get; }

			public UPath Prefix { get; }

			public UPath Path { get; }

			public SearchLocation(IFileSystem fileSystem, UPath prefix, UPath path)
			{
				FileSystem = fileSystem;
				Prefix = prefix;
				Path = path;
			}
		}

		private sealed class DebuggerProxy
		{
			private readonly MountFileSystem _fs;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public KeyValuePair<string, IFileSystem>[] Mounts => _fs._mounts.Select<KeyValuePair<UPath, IFileSystem>, KeyValuePair<string, IFileSystem>>((KeyValuePair<UPath, IFileSystem> x) => new KeyValuePair<string, IFileSystem>(x.Key.ToString(), x.Value)).ToArray();

			public IFileSystem? Fallback => _fs.Fallback;

			public DebuggerProxy(MountFileSystem fs)
			{
				_fs = fs;
			}
		}

		private readonly SortedList<UPath, IFileSystem> _mounts;

		private readonly List<AggregateWatcher> _watchers;

		public MountFileSystem(bool owned = true)
			: this(null, owned)
		{
		}

		public MountFileSystem(IFileSystem? defaultBackupFileSystem, bool owned = true)
			: base(defaultBackupFileSystem, owned)
		{
			_mounts = new SortedList<UPath, IFileSystem>(new UPathLengthComparer());
			_watchers = new List<AggregateWatcher>();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			foreach (AggregateWatcher watcher in _watchers)
			{
				watcher.Dispose();
			}
			_watchers.Clear();
			if (base.Owned)
			{
				foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
				{
					mount.Value.Dispose();
				}
			}
			_mounts.Clear();
		}

		public void Mount(UPath name, IFileSystem fileSystem)
		{
			if (fileSystem == null)
			{
				throw new ArgumentNullException("fileSystem");
			}
			if (fileSystem == this)
			{
				throw new ArgumentException("Cannot recursively mount the filesystem to self", "fileSystem");
			}
			ValidateMountName(name);
			if (_mounts.ContainsKey(name))
			{
				throw new ArgumentException($"There is already a mount with the same name: `{name}`", "name");
			}
			_mounts.Add(name, fileSystem);
			foreach (AggregateWatcher watcher2 in _watchers)
			{
				if (IsMountIncludedInWatch(name, watcher2.Path, out var remainingPath) && fileSystem.CanWatch(remainingPath))
				{
					IFileSystemWatcher watcher = fileSystem.Watch(remainingPath);
					watcher2.Add(new WrapWatcher(fileSystem, name, remainingPath, watcher));
				}
			}
		}

		public bool IsMounted(UPath name)
		{
			ValidateMountName(name);
			return _mounts.ContainsKey(name);
		}

		public Dictionary<UPath, IFileSystem> GetMounts()
		{
			Dictionary<UPath, IFileSystem> dictionary = new Dictionary<UPath, IFileSystem>();
			foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
			{
				dictionary.Add(mount.Key, mount.Value);
			}
			return dictionary;
		}

		public IFileSystem Unmount(UPath name)
		{
			ValidateMountName(name);
			if (!_mounts.TryGetValue(name, out IFileSystem value))
			{
				throw new ArgumentException($"The mount with the name `{name}` was not found");
			}
			foreach (AggregateWatcher watcher in _watchers)
			{
				watcher.RemoveFrom(value);
			}
			_mounts.Remove(name);
			return value;
		}

		public bool TryGetMount(UPath path, out UPath name, out IFileSystem? fileSystem, out UPath? fileSystemPath)
		{
			path.AssertNotNull();
			path.AssertAbsolute();
			IFileSystem fileSystem2 = TryGetMountOrNext(ref path, out name);
			if (fileSystem2 == null || name.IsNull)
			{
				name = UPath.Null;
				fileSystem = null;
				fileSystemPath = null;
				return false;
			}
			fileSystem = fileSystem2;
			fileSystemPath = path;
			return true;
		}

		public bool TryGetMountName(IFileSystem fileSystem, out UPath name)
		{
			if (fileSystem == null)
			{
				throw new ArgumentNullException("fileSystem");
			}
			foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
			{
				if (mount.Value == fileSystem)
				{
					name = mount.Key;
					return true;
				}
			}
			name = UPath.Null;
			return false;
		}

		protected override void CreateDirectoryImpl(UPath path)
		{
			UPath uPath = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null && path != UPath.Root)
			{
				fileSystem.CreateDirectory(path);
				return;
			}
			throw new UnauthorizedAccessException($"The access to path `{uPath}` is denied");
		}

		protected override bool DirectoryExistsImpl(UPath path)
		{
			if (path == UPath.Root)
			{
				return true;
			}
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				if (!(path == UPath.Root))
				{
					return fileSystem.DirectoryExists(path);
				}
				return true;
			}
			foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
			{
				if (!GetRemaining(path, mount.Key).IsNull)
				{
					return true;
				}
			}
			return false;
		}

		protected override void MoveDirectoryImpl(UPath srcPath, UPath destPath)
		{
			UPath uPath = srcPath;
			UPath uPath2 = destPath;
			IFileSystem fileSystem = TryGetMountOrNext(ref srcPath);
			IFileSystem fileSystem2 = TryGetMountOrNext(ref destPath);
			if (fileSystem != null && srcPath == UPath.Root)
			{
				throw new UnauthorizedAccessException($"Cannot move a mount directory `{uPath}`");
			}
			if (fileSystem2 != null && destPath == UPath.Root)
			{
				throw new UnauthorizedAccessException($"Cannot move a mount directory `{uPath2}`");
			}
			if (fileSystem != null && fileSystem == fileSystem2)
			{
				fileSystem.MoveDirectory(srcPath, destPath);
				return;
			}
			throw new NotSupportedException($"Cannot move directory between mount `{uPath}` and `{uPath2}`");
		}

		protected override void DeleteDirectoryImpl(UPath path, bool isRecursive)
		{
			UPath uPath = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null && path == UPath.Root)
			{
				throw new UnauthorizedAccessException($"Cannot delete mount directory `{uPath}`. Use Unmount() instead");
			}
			if (fileSystem != null)
			{
				fileSystem.DeleteDirectory(path, isRecursive);
				return;
			}
			throw FileSystemExceptionHelper.NewDirectoryNotFoundException(uPath);
		}

		protected override void CopyFileImpl(UPath srcPath, UPath destPath, bool overwrite)
		{
			UPath path = srcPath;
			UPath path2 = destPath;
			IFileSystem fileSystem = TryGetMountOrNext(ref srcPath);
			IFileSystem fileSystem2 = TryGetMountOrNext(ref destPath);
			if (fileSystem != null && fileSystem2 != null)
			{
				if (fileSystem == fileSystem2)
				{
					fileSystem.CopyFile(srcPath, destPath, overwrite);
				}
				else
				{
					fileSystem.CopyFileCross(srcPath, fileSystem2, destPath, overwrite);
				}
				return;
			}
			if (fileSystem == null)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(path);
			}
			throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path2);
		}

		protected override void ReplaceFileImpl(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			UPath uPath = srcPath;
			UPath uPath2 = destPath;
			UPath uPath3 = destBackupPath;
			if (!FileExistsImpl(srcPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
			if (!FileExistsImpl(destPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(destPath);
			}
			IFileSystem fileSystem = TryGetMountOrNext(ref srcPath);
			IFileSystem fileSystem2 = TryGetMountOrNext(ref destPath);
			IFileSystem fileSystem3 = TryGetMountOrNext(ref destBackupPath);
			if (fileSystem != null && fileSystem == fileSystem2 && (destBackupPath.IsNull || fileSystem == fileSystem3))
			{
				fileSystem.ReplaceFile(srcPath, destPath, destBackupPath, ignoreMetadataErrors);
				return;
			}
			throw new NotSupportedException($"Cannot replace file between mount `{uPath}`, `{uPath2}` and `{uPath3}`");
		}

		protected override long GetFileLengthImpl(UPath path)
		{
			UPath path2 = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				return fileSystem.GetFileLength(path);
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path2);
		}

		protected override bool FileExistsImpl(UPath path)
		{
			return TryGetMountOrNext(ref path)?.FileExists(path) ?? false;
		}

		protected override void MoveFileImpl(UPath srcPath, UPath destPath)
		{
			UPath path = srcPath;
			UPath path2 = destPath;
			if (!FileExistsImpl(srcPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
			UPath directory = destPath.GetDirectory();
			if (!DirectoryExistsImpl(directory))
			{
				throw FileSystemExceptionHelper.NewDirectoryNotFoundException(directory);
			}
			if (FileExistsImpl(destPath))
			{
				throw new IOException($"The destination path `{destPath}` already exists");
			}
			IFileSystem fileSystem = TryGetMountOrNext(ref srcPath);
			IFileSystem fileSystem2 = TryGetMountOrNext(ref destPath);
			if (fileSystem != null && fileSystem == fileSystem2)
			{
				fileSystem.MoveFile(srcPath, destPath);
				return;
			}
			if (fileSystem != null && fileSystem2 != null)
			{
				fileSystem.MoveFileCross(srcPath, fileSystem2, destPath);
				return;
			}
			if (fileSystem == null)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(path);
			}
			throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path2);
		}

		protected override void DeleteFileImpl(UPath path)
		{
			TryGetMountOrNext(ref path)?.DeleteFile(path);
		}

		protected override Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			UPath uPath = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				return fileSystem.OpenFile(path, mode, access, share);
			}
			if (mode == FileMode.Open || mode == FileMode.Truncate)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(uPath);
			}
			throw new UnauthorizedAccessException($"The access to path `{uPath}` is denied");
		}

		protected override FileAttributes GetAttributesImpl(UPath path)
		{
			UPath path2 = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				return fileSystem.GetAttributes(path);
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path2);
		}

		protected override void SetAttributesImpl(UPath path, FileAttributes attributes)
		{
			UPath path2 = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				fileSystem.SetAttributes(path, attributes);
				return;
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path2);
		}

		protected override DateTime GetCreationTimeImpl(UPath path)
		{
			return TryGetMountOrNext(ref path)?.GetCreationTime(path) ?? FileSystem.DefaultFileTime;
		}

		protected override void SetCreationTimeImpl(UPath path, DateTime time)
		{
			UPath path2 = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				fileSystem.SetCreationTime(path, time);
				return;
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path2);
		}

		protected override DateTime GetLastAccessTimeImpl(UPath path)
		{
			return TryGetMountOrNext(ref path)?.GetLastAccessTime(path) ?? FileSystem.DefaultFileTime;
		}

		protected override void SetLastAccessTimeImpl(UPath path, DateTime time)
		{
			UPath path2 = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				fileSystem.SetLastAccessTime(path, time);
				return;
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path2);
		}

		protected override DateTime GetLastWriteTimeImpl(UPath path)
		{
			return TryGetMountOrNext(ref path)?.GetLastWriteTime(path) ?? FileSystem.DefaultFileTime;
		}

		protected override void SetLastWriteTimeImpl(UPath path, DateTime time)
		{
			UPath path2 = path;
			IFileSystem fileSystem = TryGetMountOrNext(ref path);
			if (fileSystem != null)
			{
				fileSystem.SetLastWriteTime(path, time);
				return;
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path2);
		}

		protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
		{
			SearchPattern search = SearchPattern.Parse(ref path, ref searchPattern);
			List<UPath> directoryToVisit = new List<UPath> { path };
			SortedSet<UPath> entries = new SortedSet<UPath>();
			SortedSet<UPath> sortedDirectories = new SortedSet<UPath>();
			bool first = true;
			while (directoryToVisit.Count > 0)
			{
				UPath basePath = directoryToVisit[0];
				directoryToVisit.RemoveAt(0);
				int dirIndex = 0;
				entries.Clear();
				sortedDirectories.Clear();
				List<SearchLocation> locations = GetSearchLocations(basePath);
				if (locations.Count == 1 && locations[0].FileSystem != this && (!first || searchOption == SearchOption.AllDirectories))
				{
					SearchLocation last = locations[0];
					foreach (UPath item in last.FileSystem.EnumeratePaths(last.Path, searchPattern, searchOption, searchTarget))
					{
						yield return CombinePrefix(last.Prefix, item);
					}
				}
				else
				{
					for (int num = locations.Count - 1; num >= 0; num--)
					{
						SearchLocation searchLocation = locations[num];
						IFileSystem fileSystem = searchLocation.FileSystem;
						UPath path2 = searchLocation.Path;
						if (fileSystem == this)
						{
							UPath remainingPath;
							UPath uPath = new UPath(path2.GetFirstDirectory(out remainingPath)).ToRelative();
							UPath uPath2 = searchLocation.Prefix / uPath;
							if (search.Match(uPath2) && searchTarget != SearchTarget.File)
							{
								entries.Add(uPath2);
							}
							if (searchOption == SearchOption.AllDirectories)
							{
								sortedDirectories.Add(uPath2);
							}
						}
						else
						{
							foreach (UPath item2 in fileSystem.EnumeratePaths(path2, "*", SearchOption.TopDirectoryOnly, SearchTarget.Both))
							{
								UPath uPath3 = CombinePrefix(searchLocation.Prefix, item2);
								if (!entries.Contains(uPath3))
								{
									bool flag = fileSystem.FileExists(item2);
									bool flag2 = fileSystem.DirectoryExists(item2);
									if (search.Match(uPath3) && ((flag && searchTarget != SearchTarget.Directory) || (flag2 && searchTarget != SearchTarget.File)))
									{
										entries.Add(uPath3);
									}
									if (searchOption == SearchOption.AllDirectories && flag2)
									{
										sortedDirectories.Add(uPath3);
									}
								}
							}
						}
					}
				}
				if (first)
				{
					if (locations.Count == 0 && path != UPath.Root)
					{
						throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
					}
					first = false;
				}
				foreach (UPath item3 in sortedDirectories)
				{
					directoryToVisit.Insert(dirIndex++, item3);
				}
				foreach (UPath item4 in entries)
				{
					yield return item4;
				}
			}
			List<SearchLocation> GetSearchLocations(UPath uPath4)
			{
				List<SearchLocation> list = new List<SearchLocation>();
				bool flag3 = false;
				foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
				{
					UPath remaining = GetRemaining(uPath4, mount.Key);
					if (!remaining.IsNull && remaining != UPath.Root)
					{
						list.Add(new SearchLocation(this, uPath4, remaining));
					}
					else if (!flag3)
					{
						remaining = GetRemaining(mount.Key, uPath4);
						if (!remaining.IsNull)
						{
							flag3 = true;
							if (mount.Value.DirectoryExists(remaining))
							{
								list.Add(new SearchLocation(mount.Value, mount.Key, remaining));
							}
						}
					}
				}
				if (!flag3 && base.Fallback != null && base.Fallback.DirectoryExists(uPath4))
				{
					list.Add(new SearchLocation(base.Fallback, UPath.Null, uPath4));
				}
				return list;
			}
		}

		protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
		{
			List<UPath> directoryToVisit = new List<UPath> { path };
			HashSet<UPath> entries = new HashSet<UPath>();
			SortedSet<UPath> sortedDirectories = new SortedSet<UPath>();
			bool first = true;
			while (directoryToVisit.Count > 0)
			{
				UPath basePath = directoryToVisit[0];
				directoryToVisit.RemoveAt(0);
				int dirIndex = 0;
				entries.Clear();
				sortedDirectories.Clear();
				List<SearchLocation> locations = GetSearchLocations(basePath);
				if (locations.Count == 1 && locations[0].FileSystem != this && (!first || searchOption == SearchOption.AllDirectories))
				{
					SearchLocation last = locations[0];
					foreach (FileSystemItem item3 in last.FileSystem.EnumerateItems(last.Path, searchOption, searchPredicate))
					{
						FileSystemItem fileSystemItem = item3;
						fileSystemItem.Path = CombinePrefix(last.Prefix, item3.Path);
						if (entries.Add(fileSystemItem.Path))
						{
							yield return fileSystemItem;
						}
					}
				}
				else
				{
					for (int i = locations.Count - 1; i >= 0; i--)
					{
						SearchLocation last = locations[i];
						IFileSystem fileSystem = last.FileSystem;
						UPath path2 = last.Path;
						if (fileSystem == this)
						{
							UPath remainingPath;
							UPath uPath = new UPath(path2.GetFirstDirectory(out remainingPath)).ToRelative();
							UPath mountPath = last.Prefix / uPath;
							FileSystemItem item = new FileSystemItem(this, mountPath, directory: true);
							if ((searchPredicate == null || searchPredicate(ref item)) && entries.Add(item.Path))
							{
								yield return item;
							}
							if (searchOption == SearchOption.AllDirectories)
							{
								sortedDirectories.Add(mountPath);
							}
						}
						else
						{
							foreach (FileSystemItem item2 in fileSystem.EnumerateItems(path2, SearchOption.TopDirectoryOnly, searchPredicate))
							{
								UPath mountPath = CombinePrefix(last.Prefix, item2.Path);
								if (entries.Add(mountPath))
								{
									FileSystemItem fileSystemItem2 = item2;
									fileSystemItem2.Path = mountPath;
									yield return fileSystemItem2;
									if (searchOption == SearchOption.AllDirectories && item2.IsDirectory)
									{
										sortedDirectories.Add(mountPath);
									}
								}
							}
						}
					}
				}
				if (first)
				{
					if (locations.Count == 0 && path != UPath.Root)
					{
						throw FileSystemExceptionHelper.NewDirectoryNotFoundException(path);
					}
					first = false;
				}
				foreach (UPath item4 in sortedDirectories)
				{
					directoryToVisit.Insert(dirIndex++, item4);
				}
			}
			List<SearchLocation> GetSearchLocations(UPath uPath2)
			{
				List<SearchLocation> list = new List<SearchLocation>();
				bool flag = false;
				foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
				{
					UPath remaining = GetRemaining(uPath2, mount.Key);
					if (!remaining.IsNull && remaining != UPath.Root)
					{
						list.Add(new SearchLocation(this, uPath2, remaining));
					}
					else if (!flag)
					{
						remaining = GetRemaining(mount.Key, uPath2);
						if (!remaining.IsNull)
						{
							flag = true;
							if (mount.Value.DirectoryExists(remaining))
							{
								list.Add(new SearchLocation(mount.Value, mount.Key, remaining));
							}
						}
					}
				}
				if (!flag && base.Fallback != null && base.Fallback.DirectoryExists(uPath2))
				{
					list.Add(new SearchLocation(base.Fallback, UPath.Null, uPath2));
				}
				return list;
			}
		}

		protected override bool CanWatchImpl(UPath path)
		{
			return true;
		}

		protected override IFileSystemWatcher WatchImpl(UPath path)
		{
			AggregateWatcher aggregateWatcher = new AggregateWatcher(this, path);
			foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
			{
				if (IsMountIncludedInWatch(mount.Key, path, out var remainingPath) && mount.Value.CanWatch(remainingPath))
				{
					IFileSystemWatcher watcher = mount.Value.Watch(remainingPath);
					aggregateWatcher.Add(new WrapWatcher(mount.Value, mount.Key, remainingPath, watcher));
				}
			}
			if (base.Fallback != null && base.Fallback.CanWatch(path))
			{
				IFileSystemWatcher watcher2 = base.Fallback.Watch(path);
				aggregateWatcher.Add(new WrapWatcher(base.Fallback, UPath.Null, path, watcher2));
			}
			_watchers.Add(aggregateWatcher);
			return aggregateWatcher;
		}

		protected override UPath ConvertPathToDelegate(UPath path)
		{
			return path;
		}

		protected override UPath ConvertPathFromDelegate(UPath path)
		{
			return path;
		}

		private IFileSystem? TryGetMountOrNext(ref UPath path)
		{
			UPath mountPath;
			return TryGetMountOrNext(ref path, out mountPath);
		}

		private IFileSystem? TryGetMountOrNext(ref UPath path, out UPath mountPath)
		{
			mountPath = UPath.Null;
			if (path.IsNull)
			{
				return null;
			}
			IFileSystem fileSystem = null;
			foreach (KeyValuePair<UPath, IFileSystem> mount in _mounts)
			{
				UPath remaining = GetRemaining(mount.Key, path);
				if (!remaining.IsNull)
				{
					mountPath = mount.Key;
					fileSystem = mount.Value;
					path = remaining;
					break;
				}
			}
			if (fileSystem != null)
			{
				return fileSystem;
			}
			mountPath = UPath.Null;
			return base.Fallback;
		}

		private static bool IsMountIncludedInWatch(UPath mountPrefix, UPath watchPath, out UPath remainingPath)
		{
			if (watchPath == UPath.Root)
			{
				remainingPath = UPath.Root;
				return true;
			}
			remainingPath = GetRemaining(mountPrefix, watchPath);
			return !remainingPath.IsNull;
		}

		private static UPath GetRemaining(UPath prefix, UPath path)
		{
			if (!path.IsInDirectory(prefix, recursive: true))
			{
				return null;
			}
			return new UPath(path.FullName.Substring(prefix.FullName.Length)).ToAbsolute();
		}

		private static UPath CombinePrefix(UPath prefix, UPath remaining)
		{
			if (!prefix.IsNull)
			{
				return prefix / remaining.ToRelative();
			}
			return remaining;
		}

		private void ValidateMountName(UPath name)
		{
			name.AssertAbsolute("name");
			if (name == UPath.Root)
			{
				throw new ArgumentException("The mount name cannot be a `/` root filesystem", "name");
			}
		}
	}
}
