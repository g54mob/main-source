using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Zio.FileSystems;

namespace Zio
{
	public static class FileSystemExtensions
	{
		public static SubFileSystem GetOrCreateSubFileSystem(this IFileSystem fs, UPath subFolder)
		{
			if (!fs.DirectoryExists(subFolder))
			{
				fs.CreateDirectory(subFolder);
			}
			return new SubFileSystem(fs, subFolder);
		}

		public static void CopyTo(this IFileSystem fs, IFileSystem destFileSystem, UPath dstFolder, bool overwrite)
		{
			fs.CopyTo(destFileSystem, dstFolder, overwrite, copyAttributes: true);
		}

		public static void CopyTo(this IFileSystem fs, IFileSystem destFileSystem, UPath dstFolder, bool overwrite, bool copyAttributes)
		{
			if (destFileSystem == null)
			{
				throw new ArgumentNullException("destFileSystem");
			}
			fs.CopyDirectory(UPath.Root, destFileSystem, dstFolder, overwrite, copyAttributes);
		}

		public static void CopyDirectory(this IFileSystem fs, UPath srcFolder, IFileSystem destFileSystem, UPath dstFolder, bool overwrite)
		{
			fs.CopyDirectory(srcFolder, destFileSystem, dstFolder, overwrite, copyAttributes: true);
		}

		public static void CopyDirectory(this IFileSystem fs, UPath srcFolder, IFileSystem destFileSystem, UPath dstFolder, bool overwrite, bool copyAttributes)
		{
			if (destFileSystem == null)
			{
				throw new ArgumentNullException("destFileSystem");
			}
			if (!fs.DirectoryExists(srcFolder))
			{
				throw new DirectoryNotFoundException($"{srcFolder} folder not found from source file system.");
			}
			if (dstFolder != UPath.Root)
			{
				destFileSystem.CreateDirectory(dstFolder);
			}
			string fullName = srcFolder.FullName;
			int num = ((!(srcFolder == UPath.Root)) ? 1 : 0);
			foreach (UPath item in fs.EnumerateFiles(srcFolder))
			{
				string text = item.FullName.Substring(fullName.Length + num);
				UPath destPath = UPath.Combine(dstFolder, text);
				fs.CopyFileCross(item, destFileSystem, destPath, overwrite, copyAttributes);
			}
			foreach (UPath item2 in fs.EnumerateDirectories(srcFolder))
			{
				string text2 = item2.FullName.Substring(fullName.Length + num);
				UPath dstFolder2 = UPath.Combine(dstFolder, text2);
				fs.CopyDirectory(item2, destFileSystem, dstFolder2, overwrite, copyAttributes);
			}
		}

		public static void CopyFileCross(this IFileSystem fs, UPath srcPath, IFileSystem destFileSystem, UPath destPath, bool overwrite)
		{
			fs.CopyFileCross(srcPath, destFileSystem, destPath, overwrite, copyAttributes: true);
		}

		public static void CopyFileCross(this IFileSystem fs, UPath srcPath, IFileSystem destFileSystem, UPath destPath, bool overwrite, bool copyAttributes)
		{
			if (destFileSystem == null)
			{
				throw new ArgumentNullException("destFileSystem");
			}
			if (fs == destFileSystem)
			{
				fs.CopyFile(srcPath, destPath, overwrite);
				return;
			}
			srcPath.AssertAbsolute("srcPath");
			if (!fs.FileExists(srcPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
			destPath.AssertAbsolute("destPath");
			UPath directory = destPath.GetDirectory();
			if (!destFileSystem.DirectoryExists(directory))
			{
				throw FileSystemExceptionHelper.NewDirectoryNotFoundException(directory);
			}
			if (destFileSystem.FileExists(destPath) && !overwrite)
			{
				throw new IOException($"The destination file path `{destPath}` already exist and overwrite is false");
			}
			using Stream stream = fs.OpenFile(srcPath, FileMode.Open, FileAccess.Read, FileShare.Read);
			bool flag = false;
			try
			{
				using (Stream destination = destFileSystem.OpenFile(destPath, FileMode.Create, FileAccess.Write, FileShare.Read))
				{
					stream.CopyTo(destination);
				}
				if (copyAttributes)
				{
					destFileSystem.SetLastWriteTime(destPath, fs.GetLastWriteTime(srcPath));
					destFileSystem.SetAttributes(destPath, fs.GetAttributes(srcPath));
				}
				flag = true;
			}
			finally
			{
				if (!flag)
				{
					try
					{
						destFileSystem.DeleteFile(destPath);
					}
					catch
					{
					}
				}
			}
		}

		public static void MoveFileCross(this IFileSystem fs, UPath srcPath, IFileSystem destFileSystem, UPath destPath)
		{
			if (destFileSystem == null)
			{
				throw new ArgumentNullException("destFileSystem");
			}
			if (fs == destFileSystem)
			{
				fs.MoveFile(srcPath, destPath);
				return;
			}
			srcPath.AssertAbsolute("srcPath");
			if (!fs.FileExists(srcPath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(srcPath);
			}
			destPath.AssertAbsolute("destPath");
			UPath directory = destPath.GetDirectory();
			if (!destFileSystem.DirectoryExists(directory))
			{
				throw FileSystemExceptionHelper.NewDirectoryNotFoundException(destPath);
			}
			if (destFileSystem.DirectoryExists(destPath))
			{
				throw FileSystemExceptionHelper.NewDestinationDirectoryExistException(destPath);
			}
			if (destFileSystem.FileExists(destPath))
			{
				throw FileSystemExceptionHelper.NewDestinationFileExistException(destPath);
			}
			using (Stream stream = fs.OpenFile(srcPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				bool flag = false;
				try
				{
					using (Stream destination = destFileSystem.OpenFile(destPath, FileMode.Create, FileAccess.Write, FileShare.Read))
					{
						stream.CopyTo(destination);
					}
					destFileSystem.SetAttributes(destPath, fs.GetAttributes(srcPath));
					destFileSystem.SetCreationTime(destPath, fs.GetCreationTime(srcPath));
					destFileSystem.SetLastAccessTime(destPath, fs.GetLastAccessTime(srcPath));
					destFileSystem.SetLastWriteTime(destPath, fs.GetLastWriteTime(srcPath));
					flag = true;
				}
				finally
				{
					if (!flag)
					{
						try
						{
							destFileSystem.DeleteFile(destPath);
						}
						catch
						{
						}
					}
				}
			}
			bool flag2 = false;
			try
			{
				fs.DeleteFile(srcPath);
				flag2 = true;
			}
			finally
			{
				if (!flag2)
				{
					try
					{
						destFileSystem.DeleteFile(destPath);
					}
					catch
					{
					}
				}
			}
		}

		public static byte[] ReadAllBytes(this IFileSystem fs, UPath path)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (Stream stream = fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				stream.CopyTo(memoryStream);
			}
			return memoryStream.ToArray();
		}

		public static string ReadAllText(this IFileSystem fs, UPath path)
		{
			using StreamReader streamReader = new StreamReader(fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read));
			return streamReader.ReadToEnd();
		}

		public static string ReadAllText(this IFileSystem fs, UPath path, Encoding encoding)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			using StreamReader streamReader = new StreamReader(fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read), encoding);
			return streamReader.ReadToEnd();
		}

		public static void WriteAllBytes(this IFileSystem fs, UPath path, byte[] content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			using Stream stream = fs.OpenFile(path, FileMode.Create, FileAccess.Write, FileShare.Read);
			stream.Write(content, 0, content.Length);
		}

		public static string[] ReadAllLines(this IFileSystem fs, UPath path)
		{
			using StreamReader streamReader = new StreamReader(fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read));
			List<string> list = new List<string>();
			string item;
			while ((item = streamReader.ReadLine()) != null)
			{
				list.Add(item);
			}
			return list.ToArray();
		}

		public static string[] ReadAllLines(this IFileSystem fs, UPath path, Encoding encoding)
		{
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			using StreamReader streamReader = new StreamReader(fs.OpenFile(path, FileMode.Open, FileAccess.Read, FileShare.Read), encoding);
			List<string> list = new List<string>();
			string item;
			while ((item = streamReader.ReadLine()) != null)
			{
				list.Add(item);
			}
			return list.ToArray();
		}

		public static void WriteAllText(this IFileSystem fs, UPath path, string content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			using StreamWriter streamWriter = new StreamWriter(fs.OpenFile(path, FileMode.Create, FileAccess.Write, FileShare.Read));
			streamWriter.Write(content);
			streamWriter.Flush();
		}

		public static void WriteAllText(this IFileSystem fs, UPath path, string content, Encoding encoding)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			using StreamWriter streamWriter = new StreamWriter(fs.OpenFile(path, FileMode.Create, FileAccess.Write, FileShare.Read), encoding);
			streamWriter.Write(content);
			streamWriter.Flush();
		}

		public static void AppendAllText(this IFileSystem fs, UPath path, string content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			using StreamWriter streamWriter = new StreamWriter(fs.OpenFile(path, FileMode.Append, FileAccess.Write, FileShare.Read));
			streamWriter.Write(content);
			streamWriter.Flush();
		}

		public static void AppendAllText(this IFileSystem fs, UPath path, string content, Encoding encoding)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			using StreamWriter streamWriter = new StreamWriter(fs.OpenFile(path, FileMode.Append, FileAccess.Write, FileShare.Read), encoding);
			streamWriter.Write(content);
			streamWriter.Flush();
		}

		public static Stream CreateFile(this IFileSystem fileSystem, UPath path)
		{
			path.AssertAbsolute();
			return fileSystem.OpenFile(path, FileMode.Create, FileAccess.ReadWrite);
		}

		public static IEnumerable<UPath> EnumerateDirectories(this IFileSystem fileSystem, UPath path)
		{
			return fileSystem.EnumerateDirectories(path, "*");
		}

		public static IEnumerable<UPath> EnumerateDirectories(this IFileSystem fileSystem, UPath path, string searchPattern)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumerateDirectories(path, searchPattern, SearchOption.TopDirectoryOnly);
		}

		public static IEnumerable<UPath> EnumerateDirectories(this IFileSystem fileSystem, UPath path, string searchPattern, SearchOption searchOption)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			foreach (UPath item in fileSystem.EnumeratePaths(path, searchPattern, searchOption, SearchTarget.Directory))
			{
				yield return item;
			}
		}

		public static IEnumerable<UPath> EnumerateFiles(this IFileSystem fileSystem, UPath path)
		{
			return fileSystem.EnumerateFiles(path, "*");
		}

		public static IEnumerable<UPath> EnumerateFiles(this IFileSystem fileSystem, UPath path, string searchPattern)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumerateFiles(path, searchPattern, SearchOption.TopDirectoryOnly);
		}

		public static IEnumerable<UPath> EnumerateFiles(this IFileSystem fileSystem, UPath path, string searchPattern, SearchOption searchOption)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			foreach (UPath item in fileSystem.EnumeratePaths(path, searchPattern, searchOption, SearchTarget.File))
			{
				yield return item;
			}
		}

		public static IEnumerable<UPath> EnumeratePaths(this IFileSystem fileSystem, UPath path)
		{
			return fileSystem.EnumeratePaths(path, "*");
		}

		public static IEnumerable<UPath> EnumeratePaths(this IFileSystem fileSystem, UPath path, string searchPattern)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumeratePaths(path, searchPattern, SearchOption.TopDirectoryOnly);
		}

		public static IEnumerable<UPath> EnumeratePaths(this IFileSystem fileSystem, UPath path, string searchPattern, SearchOption searchOption)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumeratePaths(path, searchPattern, searchOption, SearchTarget.Both);
		}

		public static IEnumerable<FileEntry> EnumerateFileEntries(this IFileSystem fileSystem, UPath path)
		{
			return fileSystem.EnumerateFileEntries(path, "*");
		}

		public static IEnumerable<FileEntry> EnumerateFileEntries(this IFileSystem fileSystem, UPath path, string searchPattern)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumerateFileEntries(path, searchPattern, SearchOption.TopDirectoryOnly);
		}

		public static IEnumerable<FileEntry> EnumerateFileEntries(this IFileSystem fileSystem, UPath path, string searchPattern, SearchOption searchOption)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			foreach (UPath item in fileSystem.EnumerateFiles(path, searchPattern, searchOption))
			{
				yield return new FileEntry(fileSystem, item);
			}
		}

		public static IEnumerable<DirectoryEntry> EnumerateDirectoryEntries(this IFileSystem fileSystem, UPath path)
		{
			return fileSystem.EnumerateDirectoryEntries(path, "*");
		}

		public static IEnumerable<DirectoryEntry> EnumerateDirectoryEntries(this IFileSystem fileSystem, UPath path, string searchPattern)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumerateDirectoryEntries(path, searchPattern, SearchOption.TopDirectoryOnly);
		}

		public static IEnumerable<DirectoryEntry> EnumerateDirectoryEntries(this IFileSystem fileSystem, UPath path, string searchPattern, SearchOption searchOption)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			foreach (UPath item in fileSystem.EnumerateDirectories(path, searchPattern, searchOption))
			{
				yield return new DirectoryEntry(fileSystem, item);
			}
		}

		public static IEnumerable<FileSystemEntry> EnumerateFileSystemEntries(this IFileSystem fileSystem, UPath path)
		{
			return fileSystem.EnumerateFileSystemEntries(path, "*");
		}

		public static IEnumerable<FileSystemEntry> EnumerateFileSystemEntries(this IFileSystem fileSystem, UPath path, string searchPattern)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			return fileSystem.EnumerateFileSystemEntries(path, searchPattern, SearchOption.TopDirectoryOnly);
		}

		public static IEnumerable<FileSystemEntry> EnumerateFileSystemEntries(this IFileSystem fileSystem, UPath path, string searchPattern, SearchOption searchOption, SearchTarget searchTarget = SearchTarget.Both)
		{
			if (searchPattern == null)
			{
				throw new ArgumentNullException("searchPattern");
			}
			foreach (UPath item in fileSystem.EnumeratePaths(path, searchPattern, searchOption, searchTarget))
			{
				yield return fileSystem.DirectoryExists(item) ? ((FileSystemEntry)new DirectoryEntry(fileSystem, item)) : ((FileSystemEntry)new FileEntry(fileSystem, item));
			}
		}

		public static FileSystemEntry GetFileSystemEntry(this IFileSystem fileSystem, UPath path)
		{
			if (fileSystem.FileExists(path))
			{
				return new FileEntry(fileSystem, path);
			}
			if (fileSystem.DirectoryExists(path))
			{
				return new DirectoryEntry(fileSystem, path);
			}
			throw FileSystemExceptionHelper.NewFileNotFoundException(path);
		}

		public static FileSystemEntry? TryGetFileSystemEntry(this IFileSystem fileSystem, UPath path)
		{
			if (fileSystem.FileExists(path))
			{
				return new FileEntry(fileSystem, path);
			}
			if (fileSystem.DirectoryExists(path))
			{
				return new DirectoryEntry(fileSystem, path);
			}
			return null;
		}

		public static FileEntry GetFileEntry(this IFileSystem fileSystem, UPath filePath)
		{
			if (!fileSystem.FileExists(filePath))
			{
				throw FileSystemExceptionHelper.NewFileNotFoundException(filePath);
			}
			return new FileEntry(fileSystem, filePath);
		}

		public static DirectoryEntry GetDirectoryEntry(this IFileSystem fileSystem, UPath directoryPath)
		{
			if (!fileSystem.DirectoryExists(directoryPath))
			{
				throw FileSystemExceptionHelper.NewDirectoryNotFoundException(directoryPath);
			}
			return new DirectoryEntry(fileSystem, directoryPath);
		}

		public static IFileSystemWatcher? TryWatch(this IFileSystem fileSystem, UPath path)
		{
			if (!fileSystem.CanWatch(path))
			{
				return null;
			}
			return fileSystem.Watch(path);
		}
	}
}
