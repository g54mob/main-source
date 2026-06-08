using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketAccelerateConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private AccelerateConfiguration accelerateConfiguration;

		private string expectedBucketOwner;

		public string BucketName
		{
			get
			{
				return bucketName;
			}
			set
			{
				bucketName = value;
			}
		}

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

		public AccelerateConfiguration AccelerateConfiguration
		{
			get
			{
				return accelerateConfiguration;
			}
			set
			{
				accelerateConfiguration = value;
			}
		}

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

		internal bool IsSetAccelerateConfiguration()
		{
			return AccelerateConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
