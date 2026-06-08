using System;
using System.Collections.Generic;
using System.IO;

namespace Zio
{
	public class DirectoryEntry : FileSystemEntry
	{
		public override bool Exists => base.FileSystem.DirectoryExists(base.Path);

		public DirectoryEntry(IFileSystem fileSystem, UPath path)
			: base(fileSystem, path)
		{
		}

		public void Create()
		{
			base.FileSystem.CreateDirectory(base.Path);
		}

		public DirectoryEntry CreateSubdirectory(UPath path)
		{
			if (!path.IsRelative)
			{
				throw new ArgumentException("The path must be relative", "path");
			}
			DirectoryEntry directoryEntry = new DirectoryEntry(base.FileSystem, base.Path / path);
			directoryEntry.Create();
			return directoryEntry;
		}

		public void Delete(bool recursive)
		{
			base.FileSystem.DeleteDirectory(base.Path, recursive);
		}

		public IEnumerable<DirectoryEntry> EnumerateDirectories(string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
		{
			return base.FileSystem.EnumerateDirectoryEntries(base.Path, searchPattern, searchOption);
		}

		public IEnumerable<FileEntry> EnumerateFiles(string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
		{
			return base.FileSystem.EnumerateFileEntries(base.Path, searchPattern, searchOption);
		}

		public IEnumerable<FileSystemEntry> EnumerateEntries(string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly, SearchTarget searchTarget = SearchTarget.Both)
		{
			return base.FileSystem.EnumerateFileSystemEntries(base.Path, searchPattern, searchOption, searchTarget);
		}

		public IEnumerable<FileSystemItem> EnumerateItems(SearchOption searchOption = SearchOption.TopDirectoryOnly, SearchPredicate? searchPredicate = null)
		{
			return base.FileSystem.EnumerateItems(base.Path, searchOption, searchPredicate);
		}

		public void MoveTo(UPath destDirName)
		{
			base.FileSystem.MoveDirectory(base.Path, destDirName);
		}

		public override void Delete()
		{
			Delete(recursive: true);
		}
	}
}
