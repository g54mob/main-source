using System;

namespace Zio.FileSystems
{
	public class FileSystemWatcher : IFileSystemWatcher, IDisposable
	{
		private string _filter;

		private FilterPattern _filterPattern;

		public IFileSystem FileSystem { get; }

		public UPath Path { get; }

		public virtual int InternalBufferSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public virtual NotifyFilters NotifyFilter { get; set; } = NotifyFilters.Default;

		public virtual bool EnableRaisingEvents { get; set; }

		public virtual string Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					value = "*";
				}
				if (!(value == _filter))
				{
					_filterPattern = FilterPattern.Parse(value);
					_filter = value;
				}
			}
		}

		public virtual bool IncludeSubdirectories { get; set; }

		public event EventHandler<FileChangedEventArgs>? Changed;

		public event EventHandler<FileChangedEventArgs>? Created;

		public event EventHandler<FileChangedEventArgs>? Deleted;

		public event EventHandler<FileSystemErrorEventArgs>? Error;

		public event EventHandler<FileRenamedEventArgs>? Renamed;

		public FileSystemWatcher(IFileSystem fileSystem, UPath path)
		{
			path.AssertAbsolute();
			FileSystem = fileSystem ?? throw new ArgumentNullException("fileSystem");
			Path = path;
			_filter = "*.*";
		}

		~FileSystemWatcher()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void RaiseChanged(FileChangedEventArgs args)
		{
			if (ShouldRaiseEvent(args))
			{
				this.Changed?.Invoke(this, args);
			}
		}

		public void RaiseCreated(FileChangedEventArgs args)
		{
			if (ShouldRaiseEvent(args))
			{
				this.Created?.Invoke(this, args);
			}
		}

		public void RaiseDeleted(FileChangedEventArgs args)
		{
			if (ShouldRaiseEvent(args))
			{
				this.Deleted?.Invoke(this, args);
			}
		}

		public void RaiseError(FileSystemErrorEventArgs args)
		{
			if (EnableRaisingEvents)
			{
				this.Error?.Invoke(this, args);
			}
		}

		public void RaiseRenamed(FileRenamedEventArgs args)
		{
			if (ShouldRaiseEvent(args))
			{
				this.Renamed?.Invoke(this, args);
			}
		}

		private bool ShouldRaiseEvent(FileChangedEventArgs args)
		{
			if (EnableRaisingEvents && _filterPattern.Match(args.Name))
			{
				return ShouldRaiseEventImpl(args);
			}
			return false;
		}

		protected virtual bool ShouldRaiseEventImpl(FileChangedEventArgs args)
		{
			return args.FullPath.IsInDirectory(Path, IncludeSubdirectories);
		}

		protected void RegisterEvents(IFileSystemWatcher watcher)
		{
			if (watcher == null)
			{
				throw new ArgumentNullException("watcher");
			}
			watcher.Changed += OnChanged;
			watcher.Created += OnCreated;
			watcher.Deleted += OnDeleted;
			watcher.Error += OnError;
			watcher.Renamed += OnRenamed;
		}

		protected void UnregisterEvents(IFileSystemWatcher watcher)
		{
			if (watcher == null)
			{
				throw new ArgumentNullException("watcher");
			}
			watcher.Changed -= OnChanged;
			watcher.Created -= OnCreated;
			watcher.Deleted -= OnDeleted;
			watcher.Error -= OnError;
			watcher.Renamed -= OnRenamed;
		}

		protected virtual UPath? TryConvertPath(UPath pathFromEvent)
		{
			return pathFromEvent;
		}

		private void OnChanged(object sender, FileChangedEventArgs args)
		{
			UPath? uPath = TryConvertPath(args.FullPath);
			if (uPath.HasValue)
			{
				FileChangedEventArgs args2 = new FileChangedEventArgs(FileSystem, args.ChangeType, uPath.Value);
				RaiseChanged(args2);
			}
		}

		private void OnCreated(object sender, FileChangedEventArgs args)
		{
			UPath? uPath = TryConvertPath(args.FullPath);
			if (uPath.HasValue)
			{
				FileChangedEventArgs args2 = new FileChangedEventArgs(FileSystem, args.ChangeType, uPath.Value);
				RaiseCreated(args2);
			}
		}

		private void OnDeleted(object sender, FileChangedEventArgs args)
		{
			UPath? uPath = TryConvertPath(args.FullPath);
			if (uPath.HasValue)
			{
				FileChangedEventArgs args2 = new FileChangedEventArgs(FileSystem, args.ChangeType, uPath.Value);
				RaiseDeleted(args2);
			}
		}

		private void OnError(object sender, FileSystemErrorEventArgs args)
		{
			RaiseError(args);
		}

		private void OnRenamed(object sender, FileRenamedEventArgs args)
		{
			UPath? uPath = TryConvertPath(args.FullPath);
			if (uPath.HasValue)
			{
				UPath? uPath2 = TryConvertPath(args.OldFullPath);
				if (uPath2.HasValue)
				{
					FileRenamedEventArgs args2 = new FileRenamedEventArgs(FileSystem, args.ChangeType, uPath.Value, uPath2.Value);
					RaiseRenamed(args2);
				}
			}
		}
	}
}
