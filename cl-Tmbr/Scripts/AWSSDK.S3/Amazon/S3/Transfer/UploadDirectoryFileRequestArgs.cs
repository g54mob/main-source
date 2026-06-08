using System;

namespace Amazon.S3.Transfer
{
	public class UploadDirectoryFileRequestArgs : EventArgs
	{
		public TransferUtilityUploadRequest UploadRequest { get; set; }

		public UploadDirectoryFileRequestArgs(TransferUtilityUploadRequest request)
		{
			UploadRequest = request;
		}
	}
}
