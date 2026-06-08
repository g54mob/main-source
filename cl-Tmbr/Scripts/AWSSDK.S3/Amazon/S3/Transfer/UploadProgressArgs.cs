using Amazon.S3.Model;

namespace Amazon.S3.Transfer
{
	public class UploadProgressArgs : TransferProgressArgs
	{
		public string FilePath { get; private set; }

		internal long CompensationForRetry { get; set; }

		public UploadProgressArgs(long incrementTransferred, long transferred, long total)
			: base(incrementTransferred, transferred, total)
		{
		}

		public UploadProgressArgs(long incrementTransferred, long transferred, long total, string filePath)
			: this(incrementTransferred, transferred, total, 0L, filePath)
		{
		}

		internal UploadProgressArgs(long incrementTransferred, long transferred, long total, long compensationForRetry, string filePath)
			: base(incrementTransferred, transferred, total)
		{
			FilePath = filePath;
			CompensationForRetry = compensationForRetry;
		}
	}
}
