using System;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class FastZipEvents
	{
		public ProcessDirectoryHandler ProcessDirectory;

		public ProcessFileHandler ProcessFile;

		public ProgressHandler Progress;

		public CompletedFileHandler CompletedFile;

		public DirectoryFailureHandler DirectoryFailure;

		public FileFailureHandler FileFailure;

		private TimeSpan progressInterval_;

		public TimeSpan ProgressInterval
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public bool OnDirectoryFailure(string directory, Exception e)
		{
			return false;
		}

		public bool OnFileFailure(string file, Exception e)
		{
			return false;
		}

		public bool OnProcessFile(string file)
		{
			return false;
		}

		public bool OnCompletedFile(string file)
		{
			return false;
		}

		public bool OnProcessDirectory(string directory, bool hasMatchingFiles)
		{
			return false;
		}
	}
}
