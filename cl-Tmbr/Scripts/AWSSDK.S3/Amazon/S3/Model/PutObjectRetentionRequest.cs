using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutObjectRetentionRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private bool? _bypassGovernanceRetention;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string _contentMD5;

		private string expectedBucketOwner;

		private string _key;

		private RequestPayer _requestPayer;

		private ObjectLockRetention _retention;

		private string _versionId;

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

		public bool? BypassGovernanceRetention
		{
			get
			{
				return _bypassGovernanceRetention;
			}
			set
			{
				_bypassGovernanceRetention = value;
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

		public string Key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
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

		public ObjectLockRetention Retention
		{
			get
			{
				return _retention;
			}
			set
			{
				_retention = value;
			}
		}

		public string VersionId
		{
			get
			{
				return _versionId;
			}
			set
			{
				_versionId = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(_bucketName);
		}

		internal bool IsSetBypassGovernanceRetention()
		{
			return _bypassGovernanceRetention.HasValue;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetContentMD5()
		{
			return !string.IsNullOrEmpty(_contentMD5);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return !string.IsNullOrEmpty(_key);
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
		}

		internal bool IsSetRetention()
		{
			return _retention != null;
		}

		internal bool IsSetVersionId()
		{
			return !string.IsNullOrEmpty(_versionId);
		}
	}
}
