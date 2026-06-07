using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public class FileSystemScanner
	{
		public ProcessDirectoryHandler ProcessDirectory;

		public ProcessFileHandler ProcessFile;

		public CompletedFileHandler CompletedFile;

		public DirectoryFailureHandler DirectoryFailure;

		public FileFailureHandler FileFailure;

		private IScanFilter fileFilter_;

		private IScanFilter directoryFilter_;

		private bool alive_;

		public FileSystemScanner(string filter)
		{
		}

		public FileSystemScanner(string fileFilter, string directoryFilter)
		{
		}

		public FileSystemScanner(IScanFilter fileFilter)
		{
		}

		public FileSystemScanner(IScanFilter fileFilter, IScanFilter directoryFilter)
		{
		}

		private bool OnDirectoryFailure(string directory, Exception e)
		{
			return false;
		}

		private bool OnFileFailure(string file, Exception e)
		{
			return false;
		}

		private void OnProcessFile(string file)
		{
		}

		private void OnCompleteFile(string file)
		{
		}

		private void OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
		}

		public void Scan(string directory, bool recurse)
		{
		}

		private void ScanDir(string directory, bool recurse)
		{
		}
	}
}
