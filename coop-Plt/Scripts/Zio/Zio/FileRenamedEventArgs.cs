namespace Zio
{
	public class FileRenamedEventArgs : FileChangedEventArgs
	{
		public UPath OldFullPath { get; }

		public string OldName { get; }

		public FileRenamedEventArgs(IFileSystem fileSystem, WatcherChangeTypes changeType, UPath fullPath, UPath oldFullPath)
			: base(fileSystem, changeType, fullPath)
		{
			fullPath.AssertNotNull("oldFullPath");
			fullPath.AssertAbsolute("oldFullPath");
			OldFullPath = oldFullPath;
			OldName = oldFullPath.GetName();
		}
	}
}
