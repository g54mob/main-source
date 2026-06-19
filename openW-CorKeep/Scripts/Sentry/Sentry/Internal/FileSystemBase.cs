using System;
using System.Collections.Generic;
using System.IO;

namespace Sentry.Internal
{
	internal abstract class FileSystemBase : IFileSystem
	{
		public IEnumerable<string> EnumerateFiles(string path)
		{
			return Directory.EnumerateFiles(path);
		}

		public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
		{
			return Directory.EnumerateFiles(path, searchPattern);
		}

		public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
		{
			return Directory.EnumerateFiles(path, searchPattern, searchOption);
		}

		public bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
		}

		public bool FileExists(string path)
		{
			return File.Exists(path);
		}

		public DateTimeOffset GetFileCreationTime(string path)
		{
			return new FileInfo(path).CreationTimeUtc;
		}

		public string ReadAllTextFromFile(string path)
		{
			return File.ReadAllText(path);
		}

		public Stream OpenFileForReading(string path)
		{
			return File.OpenRead(path);
		}

		public abstract bool CreateDirectory(string path);

		public abstract bool DeleteDirectory(string path, bool recursive = false);

		public abstract bool CreateFileForWriting(string path, out Stream fileStream);

		public abstract bool WriteAllTextToFile(string path, string contents);

		public abstract bool MoveFile(string sourceFileName, string destFileName, bool overwrite = false);

		public abstract bool DeleteFile(string path);
	}
}
