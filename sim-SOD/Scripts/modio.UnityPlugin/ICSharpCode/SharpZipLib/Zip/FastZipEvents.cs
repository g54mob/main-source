using System;
using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class FastZipEvents
	{
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

		public event EventHandler<DirectoryEventArgs> ProcessDirectory
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
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
