using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutObjectLegalHoldRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string _contentMD5;

		private string expectedBucketOwner;

		private string _key;

		private ObjectLockLegalHold _legalHold;

		private RequestPayer _requestPayer;

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

		public ObjectLockLegalHold LegalHold
		{
			get
			{
				return _legalHold;
			}
			set
			{
				_legalHold = value;
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

		internal bool IsSetLegalHold()
		{
			return _legalHold != null;
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
		}

		internal bool IsSetVersionId()
		{
			return !string.IsNullOrEmpty(_versionId);
		}
	}
}
