using System;
using System.Diagnostics;

namespace Zio.FileSystems
{
	[DebuggerDisplay("{DebuggerDisplay(),nq}")]
	public class SubFileSystem : ComposeFileSystem
	{
		private class Watcher : WrapFileSystemWatcher
		{
			private readonly SubFileSystem _fileSystem;

			public Watcher(SubFileSystem fileSystem, UPath path, IFileSystemWatcher watcher)
				: base(fileSystem, path, watcher)
			{
				_fileSystem = fileSystem;
			}

			protected override UPath? TryConvertPath(UPath pathFromEvent)
			{
				if (!pathFromEvent.IsInDirectory(_fileSystem.SubPath, recursive: true))
				{
					return null;
				}
				return _fileSystem.ConvertPathFromDelegate(pathFromEvent);
			}
		}

		public UPath SubPath { get; }

		public SubFileSystem(IFileSystem fileSystem, UPath subPath, bool owned = true)
			: base(fileSystem, owned)
		{
			SubPath = subPath.AssertAbsolute("subPath");
			if (!fileSystem.DirectoryExists(SubPath))
			{
				throw FileSystemExceptionHelper.NewDirectoryNotFoundException(SubPath);
			}
		}

		protected override string DebuggerDisplay()
		{
			return $"{base.DebuggerDisplay()} Path: {SubPath}";
		}

		protected override IFileSystemWatcher WatchImpl(UPath path)
		{
			IFileSystemWatcher watcher = base.WatchImpl(path);
			return new Watcher(this, path, watcher);
		}

		protected override UPath ConvertPathToDelegate(UPath path)
		{
			UPath uPath = path.ToRelative();
			return SubPath / uPath;
		}

		protected override UPath ConvertPathFromDelegate(UPath path)
		{
			string fullName = path.FullName;
			if (!fullName.StartsWith(SubPath.FullName) || (fullName.Length > SubPath.FullName.Length && fullName[SubPath.FullName.Length] != '/'))
			{
				throw new InvalidOperationException($"The path `{path}` returned by the delegate filesystem is not rooted to the subpath `{SubPath}`");
			}
			string text = fullName.Substring(SubPath.FullName.Length);
			if (!(text == string.Empty))
			{
				return new UPath(text, safe: true);
			}
			return UPath.Root;
		}
	}
}
