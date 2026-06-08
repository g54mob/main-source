using System;
using System.Diagnostics;
using System.IO;

namespace Zio.FileSystems
{
	[DebuggerDisplay("{DebuggerDisplay(),nq}")]
	public class ReadOnlyFileSystem : ComposeFileSystem
	{
		protected const string FileSystemIsReadOnly = "This filesystem is read-only";

		public ReadOnlyFileSystem(IFileSystem? fileSystem, bool owned = true)
			: base(fileSystem, owned)
		{
		}

		protected override void CreateDirectoryImpl(UPath path)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void MoveDirectoryImpl(UPath srcPath, UPath destPath)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void DeleteDirectoryImpl(UPath path, bool isRecursive)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void CopyFileImpl(UPath srcPath, UPath destPath, bool overwrite)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void ReplaceFileImpl(UPath srcPath, UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void MoveFileImpl(UPath srcPath, UPath destPath)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void DeleteFileImpl(UPath path)
		{
			throw new IOException("This filesystem is read-only");
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
			return base.OpenFileImpl(path, mode, access, share);
		}

		protected override FileAttributes GetAttributesImpl(UPath path)
		{
			return base.GetAttributesImpl(path) | FileAttributes.ReadOnly;
		}

		protected override void SetAttributesImpl(UPath path, FileAttributes attributes)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void SetCreationTimeImpl(UPath path, DateTime time)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void SetLastAccessTimeImpl(UPath path, DateTime time)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override void SetLastWriteTimeImpl(UPath path, DateTime time)
		{
			throw new IOException("This filesystem is read-only");
		}

		protected override UPath ConvertPathToDelegate(UPath path)
		{
			return path;
		}

		protected override UPath ConvertPathFromDelegate(UPath path)
		{
			return path;
		}
	}
}
