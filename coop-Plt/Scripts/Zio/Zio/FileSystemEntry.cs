using System;
using System.IO;

namespace Zio
{
	public abstract class FileSystemEntry : IEquatable<FileSystemEntry>
	{
		public UPath Path { get; }

		public IFileSystem FileSystem { get; }

		public string FullName => Path.FullName;

		public string Name => Path.GetName();

		public string NameWithoutExtension => Path.GetNameWithoutExtension();

		public string? ExtensionWithDot => Path.GetExtensionWithDot();

		public FileAttributes Attributes
		{
			get
			{
				return FileSystem.GetAttributes(Path);
			}
			set
			{
				FileSystem.SetAttributes(Path, value);
			}
		}

		public abstract bool Exists { get; }

		public DateTime CreationTime
		{
			get
			{
				return FileSystem.GetCreationTime(Path);
			}
			set
			{
				FileSystem.SetCreationTime(Path, value);
			}
		}

		public DateTime LastAccessTime
		{
			get
			{
				return FileSystem.GetLastAccessTime(Path);
			}
			set
			{
				FileSystem.SetLastAccessTime(Path, value);
			}
		}

		public DateTime LastWriteTime
		{
			get
			{
				return FileSystem.GetLastWriteTime(Path);
			}
			set
			{
				FileSystem.SetLastWriteTime(Path, value);
			}
		}

		public DirectoryEntry? Parent
		{
			get
			{
				if (!(Path == UPath.Root))
				{
					return new DirectoryEntry(FileSystem, Path / "..");
				}
				return null;
			}
		}

		protected FileSystemEntry(IFileSystem fileSystem, UPath path)
		{
			FileSystem = fileSystem ?? throw new ArgumentNullException("fileSystem");
			path.AssertAbsolute();
			Path = path;
		}

		public abstract void Delete();

		public override string ToString()
		{
			return Path.FullName;
		}

		public bool Equals(FileSystemEntry other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			if (Path.Equals(other.Path))
			{
				return FileSystem.Equals(other.FileSystem);
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((FileSystemEntry)obj);
		}

		public override int GetHashCode()
		{
			return (Path.GetHashCode() * 397) ^ FileSystem.GetHashCode();
		}

		public static bool operator ==(FileSystemEntry left, FileSystemEntry right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(FileSystemEntry left, FileSystemEntry right)
		{
			return !object.Equals(left, right);
		}
	}
}
