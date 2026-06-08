using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutObjectLockConfigurationRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string _contentMD5;

		private ObjectLockConfiguration _objectLockConfiguration;

		private RequestPayer _requestPayer;

		private string _token;

		private string expectedBucketOwner;

		public string BucketName
		{
			get
			{
				return _bucketName;
			}
			set
			{
				_bucketName = value;
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
				return _contentMD5;
			}
			set
			{
				_contentMD5 = value;
			}
		}

		public ObjectLockConfiguration ObjectLockConfiguration
		{
			get
			{
				return _objectLockConfiguration;
			}
			set
			{
				_objectLockConfiguration = value;
			}
		}

		public RequestPayer RequestPayer
		{
			get
			{
				return _requestPayer;
			}
			set
			{
				_requestPayer = value;
			}
		}

		public string Token
		{
			get
			{
				return _token;
			}
			set
			{
				_token = value;
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
			return !string.IsNullOrEmpty(_bucketName);
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetContentMD5()
		{
			return !string.IsNullOrEmpty(_contentMD5);
		}

		internal bool IsSetObjectLockConfiguration()
		{
			return _objectLockConfiguration != null;
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
		}

		internal bool IsSetToken()
		{
			return !string.IsNullOrEmpty(_token);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
