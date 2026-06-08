using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketReplicationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string expectedBucketOwner;

		private ReplicationConfiguration configuration;

		private string token;

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

		public ReplicationConfiguration Configuration
		{
			get
			{
				return configuration;
			}
			set
			{
				configuration = value;
			}
		}

		public string Token
		{
			get
			{
				return token;
			}
			set
			{
				token = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetConfiguration()
		{
			return configuration != null;
		}

		internal bool IsSetToken()
		{
			return token != null;
		}
	}
}
