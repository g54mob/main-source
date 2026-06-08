using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Zio.FileSystems
{
	[DebuggerDisplay("{DebuggerDisplay(),nq} Count={_fileSystems.Count}")]
	[DebuggerTypeProxy(typeof(DebuggerProxy))]
	public class AggregateFileSystem : ReadOnlyFileSystem
	{
		private sealed class Watcher : AggregateFileSystemWatcher
		{
			private readonly AggregateFileSystem _fileSystem;

			public Watcher(AggregateFileSystem fileSystem, UPath path)
				: base(fileSystem, path)
			{
				_fileSystem = fileSystem;
			}

			protected override void Dispose(bool disposing)
			{
				base.Dispose(disposing);
				if (disposing && !_fileSystem.IsDisposing)
				{
					_fileSystem._watchers.Remove(this);
				}
			}
		}

		private readonly struct FileSystemPath
		{
			public readonly IFileSystem FileSystem;

			public readonly UPath Path;

			public readonly bool IsFile;

			public FileSystemPath(IFileSystem fileSystem, UPath path, bool isFile)
			{
				FileSystem = fileSystem;
				Path = path;
				IsFile = isFile;
			}
		}

		private sealed class DebuggerProxy
		{
			private readonly AggregateFileSystem _fs;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public IFileSystem[] FileSystems => _fs._fileSystems.ToArray();

			public IFileSystem? Fallback => _fs.Fallback;

			public DebuggerProxy(AggregateFileSystem fs)
			{
				_fs = fs;
			}
		}

		private readonly List<IFileSystem> _fileSystems;

		private readonly List<Watcher> _watchers;

		public AggregateFileSystem(bool owned = true)
			: this(null, owned)
		{
		}

		public AggregateFileSystem(IFileSystem? fileSystem, bool owned = true)
			: base(fileSystem, owned)
		{
			_fileSystems = new List<IFileSystem>();
			_watchers = new List<Watcher>();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			if (base.Owned)
			{
				foreach (IFileSystem fileSystem in _fileSystems)
				{
					fileSystem.Dispose();
				}
			}
			_fileSystems.Clear();
			foreach (Watcher watcher in _watchers)
			{
				watcher.Dispose();
			}
			_watchers.Clear();
		}

		public List<IFileSystem> GetFileSystems()
		{
			return new List<IFileSystem>(_fileSystems);
		}

		public void ClearFileSystems()
		{
			_fileSystems.Clear();
			foreach (Watcher watcher in _watchers)
			{
				watcher.Clear(base.Fallback);
			}
		}

		public void SetFileSystems(IEnumerable<IFileSystem> fileSystems)
		{
			if (fileSystems == null)
			{
				throw new ArgumentNullException("fileSystems");
			}
			_fileSystems.Clear();
			foreach (Watcher watcher2 in _watchers)
			{
				watcher2.Clear(base.Fallback);
			}
			foreach (IFileSystem fileSystem in fileSystems)
			{
				if (fileSystem == null)
				{
					throw new ArgumentException("A null filesystem is invalid");
				}
				if (fileSystem == this)
				{
					throw new ArgumentException("Cannot add this instance as an aggregate delegate of itself");
				}
				_fileSystems.Add(fileSystem);
				foreach (Watcher watcher3 in _watchers)
				{
					if (fileSystem.CanWatch(watcher3.Path))
					{
						IFileSystemWatcher watcher = fileSystem.Watch(watcher3.Path);
						watcher3.Add(watcher);
					}
				}
			}
		}

		public virtual void AddFileSystem(IFileSystem fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (fs == this)
			{
				throw new ArgumentException("Cannot add this instance as an aggregate delegate of itself");
			}
			if (!_fileSystems.Contains(fs))
			{
				_fileSystems.Add(fs);
				{
					foreach (Watcher watcher2 in _watchers)
					{
						if (fs.CanWatch(watcher2.Path))
						{
							IFileSystemWatcher watcher = fs.Watch(watcher2.Path);
							watcher2.Add(watcher);
						}
					}
					return;
				}
			}
			throw new ArgumentException("The filesystem is already added");
		}

		public virtual void RemoveFileSystem(IFileSystem fs)
		{
			if (fs == null)
			{
				throw new ArgumentNullException("fs");
			}
			if (_fileSystems.Contains(fs))
			{
				_fileSystems.Remove(fs);
				{
					foreach (Watcher watcher in _watchers)
					{
						watcher.RemoveFrom(fs);
					}
					return;
				}
			}
			throw new ArgumentException("FileSystem was not found", "fs");
		}

		public FileSystemEntry? FindFirstFileSystemEntry(UPath path)
		{
			path.AssertAbsolute();
			FileSystemPath? fileSystemPath = TryGetPath(path);
			if (!fileSystemPath.HasValue)
			{
				return null;
			}
			FileSystemPath value = fileSystemPath.Value;
			if (!value.IsFile)
			{
				return new DirectoryEntry(value.FileSystem, value.Path);
			}
			return new FileEntry(value.FileSystem, value.Path);
		}

		public List<FileSystemEntry> FindFileSystemEntries(UPath path)
		{
			path.AssertAbsolute();
			List<FileSystemPath> list = new List<FileSystemPath>();
			FindPaths(path, SearchTarget.Both, list);
			List<FileSystemEntry> list2 = new List<FileSystemEntry>(list.Count);
			if (list.Count == 0)
			{
				return list2;
			}
			bool isFile = list[0].IsFile;
			foreach (FileSystemPath item in list)
			{
				if (item.IsFile == isFile)
				{
					if (isFile)
					{
						list2.Add(new FileEntry(item.FileSystem, item.Path));
					}
					else
					{
						list2.Add(new DirectoryEntry(item.FileSystem, item.Path));
					}
				}
			}
			return list2;
		}

		protected override bool DirectoryExistsImpl(UPath path)
		{
			return TryGetDirectory(path).HasValue;
		}

		protected override long GetFileLengthImpl(UPath path)
		{
			return GetFile(path).FileSystem.GetFileLength(path);
		}

		protected override bool FileExistsImpl(UPath path)
		{
			return TryGetFile(path).HasValue;
		}

		protected override Stream OpenFileImpl(UPath path, FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			if (mode != FileMode.Open)
			{
				throw new IOException("This filesystem is read-only");
			}
			if ((access & FileAccess.Write) != 0)
			{
				throw new IOException("This filesystem is read-only");
			}
			return GetFile(path).FileSystem.OpenFile(path, mode, access, share);
		}

		protected override FileAttributes GetAttributesImpl(UPath path)
		{
			return GetPath(path).FileSystem.GetAttributes(path) | FileAttributes.ReadOnly;
		}

		protected override DateTime GetCreationTimeImpl(UPath path)
		{
			FileSystemPath? fileSystemPath = TryGetPath(path);
			if (!fileSystemPath.HasValue)
			{
				return FileSystem.DefaultFileTime;
			}
			return fileSystemPath.Value.FileSystem.GetCreationTime(path);
		}

		protected override DateTime GetLastAccessTimeImpl(UPath path)
		{
			FileSystemPath? fileSystemPath = TryGetPath(path);
			if (!fileSystemPath.HasValue)
			{
				return FileSystem.DefaultFileTime;
			}
			return fileSystemPath.Value.FileSystem.GetLastWriteTime(path);
		}

		protected override DateTime GetLastWriteTimeImpl(UPath path)
		{
			FileSystemPath? fileSystemPath = TryGetPath(path);
			if (!fileSystemPath.HasValue)
			{
				return FileSystem.DefaultFileTime;
			}
			return fileSystemPath.Value.FileSystem.GetLastWriteTime(path);
		}

		protected override IEnumerable<UPath> EnumeratePathsImpl(UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget)
		{
			SearchPattern.Parse(ref path, ref searchPattern);
			SortedSet<UPath> sortedSet = new SortedSet<UPath>();
			List<IFileSystem> list = new List<IFileSystem>();
			if (base.Fallback != null)
			{
				list.Add(base.Fallback);
			}
			list.AddRange(_fileSystems);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				IFileSystem fileSystem = list[num];
				if (fileSystem.DirectoryExists(path))
				{
					foreach (UPath item in fileSystem.EnumeratePaths(path, searchPattern, searchOption, searchTarget))
					{
						if (!sortedSet.Contains(item))
						{
							sortedSet.Add(item);
						}
					}
				}
			}
			foreach (UPath item2 in sortedSet)
			{
				yield return item2;
			}
		}

		protected override IEnumerable<FileSystemItem> EnumerateItemsImpl(UPath path, SearchOption searchOption, SearchPredicate? searchPredicate)
		{
			HashSet<UPath> entries = new HashSet<UPath>();
			for (int i = _fileSystems.Count - 1; i >= 0; i--)
			{
				IFileSystem fileSystem = _fileSystems[i];
				foreach (FileSystemItem item in fileSystem.EnumerateItems(path, searchOption, searchPredicate))
				{
					if (entries.Add(item.Path))
					{
						yield return item;
					}
				}
			}
			IFileSystem fallback = base.Fallback;
			if (fallback == null)
			{
				yield break;
			}
			foreach (FileSystemItem item2 in fallback.EnumerateItems(path, searchOption, searchPredicate))
			{
				if (entries.Add(item2.Path))
				{
					yield return item2;
				}
			}
		}

		protected override UPath ConvertPathToDelegate(UPath path)
		{
			return path;
		}

		protected override UPath ConvertPathFromDelegate(UPath path)
		{
			return path;
		}

		protected override bool CanWatchImpl(UPath path)
		{
			return true;
		}

		protected override IFileSystemWatcher WatchImpl(UPath path)
		{
			Watcher watcher = new Watcher(this, path);
			if (base.Fallback != null && base.Fallback.CanWatch(path) && base.Fallback.DirectoryExists(path))
			{
				watcher.Add(base.Fallback.Watch(path));
			}
			foreach (IFileSystem fileSystem in _fileSystems)
			{
				if (fileSystem.CanWatch(path) && fileSystem.DirectoryExists(path))
				{
					watcher.Add(fileSystem.Watch(path));
				}
			}
			_watchers.Add(watcher);
			return watcher;
		}

		private FileSystemPath GetFile(UPath path)
		{
			FileSystemPath? fileSystemPath = TryGetFile(path);
			if (!fileSystemPath.HasValue)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(path);
			}
			return fileSystemPath.Value;
		}

		private FileSystemPath? TryGetFile(UPath path)
		{
			for (int num = _fileSystems.Count - 1; num >= -1; num--)
			{
				IFileSystem fileSystem = ((num < 0) ? base.Fallback : _fileSystems[num]);
				if (fileSystem is AggregateFileSystem aggregateFileSystem)
				{
					return aggregateFileSystem.TryGetFile(path);
				}
				if (fileSystem == null)
				{
					break;
				}
				if (fileSystem.FileExists(path))
				{
					return new FileSystemPath(fileSystem, path, isFile: true);
				}
			}
			return null;
		}

		private FileSystemPath? TryGetDirectory(UPath path)
		{
			for (int num = _fileSystems.Count - 1; num >= -1; num--)
			{
				IFileSystem fileSystem = ((num < 0) ? base.Fallback : _fileSystems[num]);
				if (fileSystem is AggregateFileSystem aggregateFileSystem)
				{
					return aggregateFileSystem.TryGetDirectory(path);
				}
				if (fileSystem == null)
				{
					break;
				}
				if (fileSystem.DirectoryExists(path))
				{
					return new FileSystemPath(fileSystem, path, isFile: false);
				}
			}
			return null;
		}

		private FileSystemPath GetPath(UPath path)
		{
			FileSystemPath? fileSystemPath = TryGetPath(path);
			if (!fileSystemPath.HasValue)
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(path);
			}
			return fileSystemPath.Value;
		}

		private FileSystemPath? TryGetPath(UPath path, SearchTarget searchTarget = SearchTarget.Both)
		{
			switch (searchTarget)
			{
			case SearchTarget.File:
				return TryGetFile(path);
			case SearchTarget.Directory:
				return TryGetDirectory(path);
			default:
			{
				for (int num = _fileSystems.Count - 1; num >= -1; num--)
				{
					IFileSystem fileSystem = ((num < 0) ? base.Fallback : _fileSystems[num]);
					if (fileSystem == null)
					{
						break;
					}
					if (fileSystem is AggregateFileSystem aggregateFileSystem)
					{
						return aggregateFileSystem.TryGetPath(path, searchTarget);
					}
					if (fileSystem.DirectoryExists(path))
					{
						return new FileSystemPath(fileSystem, path, isFile: false);
					}
					if (fileSystem.FileExists(path))
					{
						return new FileSystemPath(fileSystem, path, isFile: true);
					}
				}
				return null;
			}
			}
		}

		private void FindPaths(UPath path, SearchTarget searchTarget, List<FileSystemPath> paths)
		{
			bool flag = searchTarget == SearchTarget.Both || searchTarget == SearchTarget.Directory;
			bool flag2 = searchTarget == SearchTarget.Both || searchTarget == SearchTarget.File;
			List<IFileSystem> fileSystems = _fileSystems;
			for (int num = fileSystems.Count - 1; num >= -1; num--)
			{
				IFileSystem fileSystem = ((num < 0) ? base.Fallback : fileSystems[num]);
				if (fileSystem == null)
				{
					break;
				}
				if (fileSystem is AggregateFileSystem aggregateFileSystem)
				{
					aggregateFileSystem.FindPaths(path, searchTarget, paths);
				}
				else
				{
					bool isFile = false;
					if ((flag && fileSystem.DirectoryExists(path)) || (flag2 && (isFile = fileSystem.FileExists(path))))
					{
						paths.Add(new FileSystemPath(fileSystem, path, isFile));
					}
				}
			}
		}
	}
}
