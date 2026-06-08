using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutLifecycleConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private LifecycleConfiguration lifecycleConfiguration;

		private string expectedBucketOwner;

		private TransitionDefaultMinimumObjectSize _transitionDefaultMinimumObjectSize;

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

		public LifecycleConfiguration Configuration
		{
			get
			{
				return lifecycleConfiguration;
			}
			set
			{
				lifecycleConfiguration = value;
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

		public TransitionDefaultMinimumObjectSize TransitionDefaultMinimumObjectSize
		{
			get
			{
				return _transitionDefaultMinimumObjectSize;
			}
			set
			{
				_transitionDefaultMinimumObjectSize = value;
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

		internal bool IsSetConfiguration()
		{
			return lifecycleConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetTransitionDefaultMinimumObjectSize()
		{
			return !string.IsNullOrEmpty(_transitionDefaultMinimumObjectSize);
		}
	}
}
