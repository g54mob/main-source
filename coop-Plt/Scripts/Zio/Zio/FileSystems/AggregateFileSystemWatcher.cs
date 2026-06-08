using System;
using System.Collections.Generic;

namespace Zio.FileSystems
{
	public class AggregateFileSystemWatcher : FileSystemWatcher
	{
		private readonly List<IFileSystemWatcher> _children;

		private int _internalBufferSize;

		private NotifyFilters _notifyFilter;

		private bool _enableRaisingEvents;

		private bool _includeSubdirectories;

		private string _filter;

		public override int InternalBufferSize
		{
			get
			{
				return _internalBufferSize;
			}
			set
			{
				if (value == _internalBufferSize)
				{
					return;
				}
				foreach (IFileSystemWatcher child in _children)
				{
					child.InternalBufferSize = value;
				}
				_internalBufferSize = value;
			}
		}

		public override NotifyFilters NotifyFilter
		{
			get
			{
				return _notifyFilter;
			}
			set
			{
				if (value == _notifyFilter)
				{
					return;
				}
				foreach (IFileSystemWatcher child in _children)
				{
					child.NotifyFilter = value;
				}
				_notifyFilter = value;
			}
		}

		public override bool EnableRaisingEvents
		{
			get
			{
				return _enableRaisingEvents;
			}
			set
			{
				if (value == _enableRaisingEvents)
				{
					return;
				}
				foreach (IFileSystemWatcher child in _children)
				{
					child.EnableRaisingEvents = value;
				}
				_enableRaisingEvents = value;
			}
		}

		public override bool IncludeSubdirectories
		{
			get
			{
				return _includeSubdirectories;
			}
			set
			{
				if (value == _includeSubdirectories)
				{
					return;
				}
				foreach (IFileSystemWatcher child in _children)
				{
					child.IncludeSubdirectories = value;
				}
				_includeSubdirectories = value;
			}
		}

		public override string Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				if (value == _filter)
				{
					return;
				}
				foreach (IFileSystemWatcher child in _children)
				{
					child.Filter = value;
				}
				_filter = value;
			}
		}

		public AggregateFileSystemWatcher(IFileSystem fileSystem, UPath path)
			: base(fileSystem, path)
		{
			_children = new List<IFileSystemWatcher>();
			_internalBufferSize = 0;
			_notifyFilter = NotifyFilters.Default;
			_enableRaisingEvents = false;
			_includeSubdirectories = false;
			_filter = "*.*";
		}

		public void Add(IFileSystemWatcher watcher)
		{
			if (watcher == null)
			{
				throw new ArgumentNullException("watcher");
			}
			if (_children.Contains(watcher))
			{
				throw new ArgumentException("The filesystem watcher is already added", "watcher");
			}
			watcher.InternalBufferSize = InternalBufferSize;
			watcher.NotifyFilter = NotifyFilter;
			watcher.EnableRaisingEvents = EnableRaisingEvents;
			watcher.IncludeSubdirectories = IncludeSubdirectories;
			watcher.Filter = Filter;
			RegisterEvents(watcher);
			_children.Add(watcher);
		}

		public void RemoveFrom(IFileSystem fileSystem)
		{
			if (fileSystem == null)
			{
				throw new ArgumentNullException("fileSystem");
			}
			lock (_children)
			{
				for (int num = _children.Count - 1; num >= 0; num--)
				{
					IFileSystemWatcher fileSystemWatcher = _children[num];
					if (fileSystemWatcher.FileSystem == fileSystem)
					{
						UnregisterEvents(fileSystemWatcher);
						_children.RemoveAt(num);
						fileSystemWatcher.Dispose();
					}
				}
			}
		}

		public void Clear(IFileSystem? excludeFileSystem = null)
		{
			for (int num = _children.Count - 1; num >= 0; num--)
			{
				IFileSystemWatcher fileSystemWatcher = _children[num];
				if (fileSystemWatcher.FileSystem != excludeFileSystem)
				{
					UnregisterEvents(fileSystemWatcher);
					_children.RemoveAt(num);
					fileSystemWatcher.Dispose();
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Clear();
			}
		}
	}
}
