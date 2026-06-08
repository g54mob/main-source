using System;

namespace Zio
{
	public interface IFileSystemWatcher : IDisposable
	{
		IFileSystem FileSystem { get; }

		UPath Path { get; }

		int InternalBufferSize { get; set; }

		NotifyFilters NotifyFilter { get; set; }

		bool EnableRaisingEvents { get; set; }

		string Filter { get; set; }

		bool IncludeSubdirectories { get; set; }

		event EventHandler<FileChangedEventArgs>? Changed;

		event EventHandler<FileChangedEventArgs>? Created;

		event EventHandler<FileChangedEventArgs>? Deleted;

		event EventHandler<FileSystemErrorEventArgs>? Error;

		event EventHandler<FileRenamedEventArgs>? Renamed;
	}
}
