using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketLoggingRequest : AmazonWebServiceRequest
	{
		private ChecksumAlgorithm _checksumAlgorithm;

		private string expectedBucketOwner;

		public string BucketName { get; set; }

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return _checksumAlgorithm;
			}
			set
			{
				_checksumAlgorithm = value;
			}
		}

		public S3BucketLoggingConfig LoggingConfig { get; set; }

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return BucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetLoggingConfig()
		{
			return LoggingConfig != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
