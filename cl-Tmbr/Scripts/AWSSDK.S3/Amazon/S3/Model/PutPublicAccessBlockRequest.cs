using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutPublicAccessBlockRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string contentMD5;

		private PublicAccessBlockConfiguration publicAccessBlockConfiguration;

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

		public string ContentMD5
		{
			get
			{
				return contentMD5;
			}
			set
			{
				contentMD5 = value;
			}
		}

		public PublicAccessBlockConfiguration PublicAccessBlockConfiguration
		{
			get
			{
				return publicAccessBlockConfiguration;
			}
			set
			{
				publicAccessBlockConfiguration = value;
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

		internal bool IsSetContentMD5()
		{
			return contentMD5 != null;
		}

		internal bool IsSetPublicAccessBlockConfiguration()
		{
			return PublicAccessBlockConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
