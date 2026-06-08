using System;

namespace Zio
{
	public class FileChangedEventArgs : EventArgs
	{
		public WatcherChangeTypes ChangeType { get; }

		public IFileSystem FileSystem { get; }

		public UPath FullPath { get; }

		public string Name { get; }

		public FileChangedEventArgs(IFileSystem fileSystem, WatcherChangeTypes changeType, UPath fullPath)
		{
			if (fileSystem == null)
			{
				throw new ArgumentNullException("fileSystem");
			}
			fullPath.AssertNotNull("fullPath");
			fullPath.AssertAbsolute("fullPath");
			FileSystem = fileSystem;
			ChangeType = changeType;
			FullPath = fullPath;
			Name = fullPath.GetName();
		}
	}
}
