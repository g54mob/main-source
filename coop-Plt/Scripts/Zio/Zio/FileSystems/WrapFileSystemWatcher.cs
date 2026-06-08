using System;

namespace Zio.FileSystems
{
	public class WrapFileSystemWatcher : FileSystemWatcher
	{
		private readonly IFileSystemWatcher _watcher;

		public override int InternalBufferSize
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

		public override NotifyFilters NotifyFilter
		{
			get
			{
				return _watcher.NotifyFilter;
			}
			set
			{
				_watcher.NotifyFilter = value;
			}
		}

		public override bool EnableRaisingEvents
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

		public override string Filter
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

		public override bool IncludeSubdirectories
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

		public WrapFileSystemWatcher(IFileSystem fileSystem, UPath path, IFileSystemWatcher watcher)
			: base(fileSystem, path)
		{
			if (watcher == null)
			{
				throw new ArgumentNullException("watcher");
			}
			_watcher = watcher;
			RegisterEvents(_watcher);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				UnregisterEvents(_watcher);
				_watcher.Dispose();
			}
		}
	}
}
