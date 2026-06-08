using System;
using System.IO;

namespace Zio
{
	public struct FileSystemItem
	{
		public IFileSystem? FileSystem;

		public UPath Path;

		public DateTimeOffset CreationTime;

		public DateTimeOffset LastAccessTime;

		public DateTimeOffset LastWriteTime;

		public FileAttributes Attributes;

		public long Length;

		public readonly bool IsEmpty => FileSystem == null;

		public UPath AbsolutePath { get; set; }

		public readonly string FullName => Path.FullName;

		public readonly bool IsDirectory => (Attributes & FileAttributes.Directory) != 0;

		public readonly bool IsHidden => (Attributes & FileAttributes.Hidden) != 0;

		public FileSystemItem(IFileSystem fileSystem, UPath path, bool directory)
		{
			this = default(FileSystemItem);
			FileSystem = fileSystem;
			AbsolutePath = path;
			Path = path;
			Attributes = (directory ? FileAttributes.Directory : FileAttributes.Normal);
		}

		public readonly string GetName()
		{
			return Path.GetName();
		}

		public readonly Stream Open(FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			if (FileSystem == null)
			{
				throw NewThrowNotInitialized();
			}
			return FileSystem.OpenFile(AbsolutePath, mode, access, share);
		}

		public readonly bool Exists()
		{
			if (FileSystem != null)
			{
				if (!IsDirectory)
				{
					return FileSystem.FileExists(AbsolutePath);
				}
				return FileSystem.DirectoryExists(AbsolutePath);
			}
			return false;
		}

		public readonly string ReadAllText()
		{
			if (FileSystem == null)
			{
				throw NewThrowNotInitialized();
			}
			return FileSystem.ReadAllText(AbsolutePath);
		}

		private readonly InvalidOperationException NewThrowNotInitialized()
		{
			throw new InvalidOperationException("This instance is not initialized");
		}

		public override string ToString()
		{
			return AbsolutePath.FullName;
		}
	}
}
