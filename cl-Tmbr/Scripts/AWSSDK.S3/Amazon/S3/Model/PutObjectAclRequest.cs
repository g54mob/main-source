using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class PutObjectAclRequest : AmazonWebServiceRequest
	{
		private S3AccessControlList _accessControlPolicy;

		private S3CannedACL _acl;

		private string _bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string _contentMD5;

		private string _expectedBucketOwner;

		private string _grantFullControl;

		private string _grantRead;

		private string _grantReadACP;

		private string _grantWrite;

		private string _grantWriteACP;

		private string _key;

		private RequestPayer _requestPayer;

		private string _versionId;

		public S3AccessControlList AccessControlPolicy
		{
			get
			{
				return _accessControlPolicy;
			}
			set
			{
				_accessControlPolicy = value;
			}
		}

		public S3CannedACL ACL
		{
			get
			{
				return _acl;
			}
			set
			{
				_acl = value;
			}
		}

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
				return _expectedBucketOwner;
			}
			set
			{
				_expectedBucketOwner = value;
			}
		}

		public string GrantFullControl
		{
			get
			{
				return _grantFullControl;
			}
			set
			{
				_grantFullControl = value;
			}
		}

		public string GrantRead
		{
			get
			{
				return _grantRead;
			}
			set
			{
				_grantRead = value;
			}
		}

		public string GrantReadACP
		{
			get
			{
				return _grantReadACP;
			}
			set
			{
				_grantReadACP = value;
			}
		}

		public string GrantWrite
		{
			get
			{
				return _grantWrite;
			}
			set
			{
				_grantWrite = value;
			}
		}

		public string GrantWriteACP
		{
			get
			{
				return _grantWriteACP;
			}
			set
			{
				_grantWriteACP = value;
			}
		}

		[AWSProperty(Required = true, Min = 1L)]
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

		internal bool IsSetAccessControlPolicy()
		{
			return _accessControlPolicy != null;
		}

		internal bool IsSetACL()
		{
			return _acl != null;
		}

		internal bool IsSetBucketName()
		{
			return _bucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return !string.IsNullOrEmpty(_checksumAlgorithm);
		}

		internal bool IsSetContentMD5()
		{
			return !string.IsNullOrEmpty(_contentMD5);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(_expectedBucketOwner);
		}

		internal bool IsSetGrantFullControl()
		{
			return !string.IsNullOrEmpty(_grantFullControl);
		}

		internal bool IsSetGrantRead()
		{
			return !string.IsNullOrEmpty(_grantRead);
		}

		internal bool IsSetGrantReadACP()
		{
			return !string.IsNullOrEmpty(_grantReadACP);
		}

		internal bool IsSetGrantWrite()
		{
			return !string.IsNullOrEmpty(_grantWrite);
		}

		internal bool IsSetGrantWriteACP()
		{
			return !string.IsNullOrEmpty(_grantWriteACP);
		}

		internal bool IsSetKey()
		{
			return _key != null;
		}

		internal bool IsSetRequestPayer()
		{
			return !string.IsNullOrEmpty(_requestPayer);
		}

		internal bool IsSetVersionId()
		{
			return _versionId != null;
		}
	}
}
