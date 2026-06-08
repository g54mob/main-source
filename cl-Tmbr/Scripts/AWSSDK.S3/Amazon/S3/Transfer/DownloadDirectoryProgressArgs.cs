using System;
using System.Globalization;

namespace Amazon.S3.Transfer
{
	public class DownloadDirectoryProgressArgs : EventArgs
	{
		public int TotalNumberOfFiles { get; set; }

		public int NumberOfFilesDownloaded { get; set; }

		public long TotalBytes { get; set; }

		public long TransferredBytes { get; set; }

		public string CurrentFile { get; set; }

		public long TransferredBytesForCurrentFile { get; set; }

		public long TotalNumberOfBytesForCurrentFile { get; set; }

		public DownloadDirectoryProgressArgs(int numberOfFilesDownloaded, int totalNumberOfFiles, string currentFile, long transferredBytesForCurrentFile, long totalNumberOfBytesForCurrentFile)
		{
			NumberOfFilesDownloaded = numberOfFilesDownloaded;
			TotalNumberOfFiles = totalNumberOfFiles;
			CurrentFile = currentFile;
			TransferredBytesForCurrentFile = transferredBytesForCurrentFile;
			TotalNumberOfBytesForCurrentFile = totalNumberOfBytesForCurrentFile;
		}

		public DownloadDirectoryProgressArgs(int numberOfFilesDownloaded, int totalNumberOfFiles, long transferredBytes, long totalBytes, string currentFile, long transferredBytesForCurrentFile, long totalNumberOfBytesForCurrentFile)
		{
			NumberOfFilesDownloaded = numberOfFilesDownloaded;
			TotalNumberOfFiles = totalNumberOfFiles;
			TransferredBytes = transferredBytes;
			TotalBytes = totalBytes;
			CurrentFile = currentFile;
			TransferredBytesForCurrentFile = transferredBytesForCurrentFile;
			TotalNumberOfBytesForCurrentFile = totalNumberOfBytesForCurrentFile;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "Total Files: {0}, Downloaded Files {1}, Total Bytes: {2}, Transferred Bytes: {3}", TotalNumberOfFiles, NumberOfFilesDownloaded, TotalBytes, TransferredBytes);
		}
	}
}
