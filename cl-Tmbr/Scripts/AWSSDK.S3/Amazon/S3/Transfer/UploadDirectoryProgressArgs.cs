using System;
using System.Globalization;

namespace Amazon.S3.Transfer
{
	public class UploadDirectoryProgressArgs : EventArgs
	{
		public int TotalNumberOfFiles { get; set; }

		public int NumberOfFilesUploaded { get; set; }

		public long TotalBytes { get; set; }

		public long TransferredBytes { get; set; }

		public string CurrentFile { get; set; }

		public long TransferredBytesForCurrentFile { get; set; }

		public long TotalNumberOfBytesForCurrentFile { get; set; }

		public UploadDirectoryProgressArgs(int numberOfFilesUploaded, int totalNumberOfFiles, string currentFile, long transferredBytesForCurrentFile, long totalNumberOfBytesForCurrentFile)
		{
			NumberOfFilesUploaded = numberOfFilesUploaded;
			TotalNumberOfFiles = totalNumberOfFiles;
			CurrentFile = currentFile;
			TransferredBytesForCurrentFile = transferredBytesForCurrentFile;
			TotalNumberOfBytesForCurrentFile = totalNumberOfBytesForCurrentFile;
		}

		public UploadDirectoryProgressArgs(int numberOfFilesUploaded, int totalNumberOfFiles, long transferredBytes, long totalBytes, string currentFile, long transferredBytesForCurrentFile, long totalNumberOfBytesForCurrentFile)
		{
			NumberOfFilesUploaded = numberOfFilesUploaded;
			TotalNumberOfFiles = totalNumberOfFiles;
			TransferredBytes = transferredBytes;
			TotalBytes = totalBytes;
			CurrentFile = currentFile;
			TransferredBytesForCurrentFile = transferredBytesForCurrentFile;
			TotalNumberOfBytesForCurrentFile = totalNumberOfBytesForCurrentFile;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "Total Files: {0}, Uploaded Files {1}, Total Bytes: {2}, Transferred Bytes: {3}", TotalNumberOfFiles, NumberOfFilesUploaded, TotalBytes, TransferredBytes);
		}
	}
}
