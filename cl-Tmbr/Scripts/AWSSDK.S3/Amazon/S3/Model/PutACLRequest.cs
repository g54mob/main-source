using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutACLRequest : AmazonWebServiceRequest
	{
		private S3AccessControlList accessControlPolicy;

		private S3CannedACL cannedACL;

		private string bucket;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string expectedBucketOwner;

		private string key;

		private string versionId;

		public S3AccessControlList AccessControlList
		{
			get
			{
				return accessControlPolicy;
			}
			set
			{
				accessControlPolicy = value;
			}
		}

		public S3CannedACL CannedACL
		{
			get
			{
				return cannedACL;
			}
			set
			{
				cannedACL = value;
			}
		}

		public string BucketName
		{
			get
			{
				return bucket;
			}
			set
			{
				bucket = value;
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

		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		public string VersionId
		{
			get
			{
				return versionId;
			}
			set
			{
				versionId = value;
			}
		}

		internal bool IsSetAccessControlPolicy()
		{
			return accessControlPolicy != null;
		}

		internal bool IsSetCannedACL()
		{
			return cannedACL != null;
		}

		internal bool IsSetBucketName()
		{
			return bucket != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}
	}
}
