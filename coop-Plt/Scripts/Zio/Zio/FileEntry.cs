using System;
using System.IO;
using System.Text;

namespace Zio
{
	public class FileEntry : FileSystemEntry
	{
		public DirectoryEntry Directory => base.Parent;

		public bool IsReadOnly => (base.FileSystem.GetAttributes(base.Path) & FileAttributes.ReadOnly) != 0;

		public long Length => base.FileSystem.GetFileLength(base.Path);

		public override bool Exists => base.FileSystem.FileExists(base.Path);

		public FileEntry(IFileSystem fileSystem, UPath path)
			: base(fileSystem, path)
		{
		}

		public FileEntry CopyTo(UPath destFileName, bool overwrite)
		{
			base.FileSystem.CopyFile(base.Path, destFileName, overwrite);
			return new FileEntry(base.FileSystem, destFileName);
		}

		public FileEntry CopyTo(FileEntry destFile, bool overwrite)
		{
			if ((object)destFile == null)
			{
				throw new ArgumentNullException("destFile");
			}
			base.FileSystem.CopyFileCross(base.Path, destFile.FileSystem, destFile.Path, overwrite);
			return destFile;
		}

		public Stream Create()
		{
			return base.FileSystem.CreateFile(base.Path);
		}

		public void MoveTo(UPath destFileName)
		{
			base.FileSystem.MoveFile(base.Path, destFileName);
		}

		public Stream Open(FileMode mode, FileAccess access, FileShare share = FileShare.None)
		{
			return base.FileSystem.OpenFile(base.Path, mode, access, share);
		}

		public void ReplaceTo(UPath destPath, UPath destBackupPath, bool ignoreMetadataErrors)
		{
			base.FileSystem.ReplaceFile(base.Path, destPath, destBackupPath, ignoreMetadataErrors);
		}

		public string ReadAllText()
		{
			return base.FileSystem.ReadAllText(base.Path);
		}

		public string ReadAllText(Encoding encoding)
		{
			return base.FileSystem.ReadAllText(base.Path, encoding);
		}

		public void WriteAllText(string content)
		{
			base.FileSystem.WriteAllText(base.Path, content);
		}

		public void WriteAllText(string content, Encoding encoding)
		{
			base.FileSystem.WriteAllText(base.Path, content, encoding);
		}

		public void AppendAllText(string content)
		{
			base.FileSystem.AppendAllText(base.Path, content);
		}

		public void AppendAllText(string content, Encoding encoding)
		{
			base.FileSystem.AppendAllText(base.Path, content, encoding);
		}

		public string[] ReadAllLines()
		{
			return base.FileSystem.ReadAllLines(base.Path);
		}

		public string[] ReadAllLines(Encoding encoding)
		{
			return base.FileSystem.ReadAllLines(base.Path, encoding);
		}

		public byte[] ReadAllBytes()
		{
			return base.FileSystem.ReadAllBytes(base.Path);
		}

		public void WriteAllBytes(byte[] content)
		{
			base.FileSystem.WriteAllBytes(base.Path, content);
		}

		public override void Delete()
		{
			base.FileSystem.DeleteFile(base.Path);
		}
	}
}
