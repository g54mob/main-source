using System;
using System.Collections.Generic;
using System.Threading;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class FileWritingHandler : IDisposable
	{
		public enum CompletionStatus
		{
			BusyFileWriting = 0,
			BusyPostProcessing = 1,
			CompletedDeleted = 2,
			Completed = 3
		}

		private string _path;

		private int _handle;

		private bool _deleteFile;

		private OutputTarget _outputTarget;

		private MP4FileProcessing.Options _postOptions;

		private ManualResetEvent _postProcessEvent;

		private CompletionStatus _completionStatus;

		private string _finalFilePath;

		private bool _updateMediaGallery;

		public CompletionStatus Status => default(CompletionStatus);

		public string Path => null;

		public string FinalPath => null;

		internal Action<FileWritingHandler> CompletedFileWritingAction { get; set; }

		internal FileWritingHandler(OutputTarget outputTarget, string path, int handle, bool deleteFile, string finalFilePath, bool updateMediaGallery)
		{
		}

		internal void SetFilePostProcess(MP4FileProcessing.Options postOptions)
		{
		}

		private bool StartPostProcess()
		{
			return false;
		}

		public bool IsFileReady()
		{
			return false;
		}

		public void Dispose()
		{
		}

		public static bool Cleanup(List<FileWritingHandler> list)
		{
			return false;
		}
	}
}
