using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class PutObjectResponse : AmazonWebServiceResponse
	{
		private Expiration expiration;

		private ServerSideEncryptionMethod serverSideEncryption;

		private string eTag;

		private string versionId;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private string serverSideEncryptionKeyManagementServiceEncryptionContext;

		private RequestCharged requestCharged;

		private bool? bucketKeyEnabled;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private long? _size;

		private ChecksumType _checksumType;

		public Expiration Expiration
		{
			get
			{
				return expiration;
			}
			set
			{
				expiration = value;
			}
		}

		public ServerSideEncryptionMethod ServerSideEncryptionMethod
		{
			get
			{
				return serverSideEncryption;
			}
			set
			{
				serverSideEncryption = value;
			}
		}

		public string ETag
		{
			get
			{
				return eTag;
			}
			set
			{
				eTag = value;
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

		[AWSProperty(Sensitive = true)]
		public string ServerSideEncryptionKeyManagementServiceKeyId
		{
			get
			{
				return serverSideEncryptionKeyManagementServiceKeyId;
			}
			set
			{
				serverSideEncryptionKeyManagementServiceKeyId = value;
			}
		}

		public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod
		{
			get
			{
				return serverSideCustomerEncryption;
			}
			set
			{
				serverSideCustomerEncryption = value;
			}
		}

		public string ServerSideEncryptionCustomerProvidedKeyMD5
		{
			get
			{
				return serverSideEncryptionCustomerProvidedKeyMD5;
			}
			set
			{
				serverSideEncryptionCustomerProvidedKeyMD5 = value;
			}
		}

		[AWSProperty(Sensitive = true)]
		public string ServerSideEncryptionKeyManagementServiceEncryptionContext
		{
			get
			{
				return serverSideEncryptionKeyManagementServiceEncryptionContext;
			}
			set
			{
				serverSideEncryptionKeyManagementServiceEncryptionContext = value;
			}
		}

		public RequestCharged RequestCharged
		{
			get
			{
				return requestCharged;
			}
			set
			{
				requestCharged = value;
			}
		}

		public bool? BucketKeyEnabled
		{
			get
			{
				return bucketKeyEnabled;
			}
			set
			{
				bucketKeyEnabled = value;
			}
		}

		public string ChecksumCRC32
		{
			get
			{
				return _checksumCRC32;
			}
			set
			{
				_checksumCRC32 = value;
			}
		}

		public string ChecksumCRC32C
		{
			get
			{
				return _checksumCRC32C;
			}
			set
			{
				_checksumCRC32C = value;
			}
		}

		public string ChecksumCRC64NVME
		{
			get
			{
				return _checksumCRC64NVME;
			}
			set
			{
				_checksumCRC64NVME = value;
			}
		}

		public string ChecksumSHA1
		{
			get
			{
				return _checksumSHA1;
			}
			set
			{
				_checksumSHA1 = value;
			}
		}

		public string ChecksumSHA256
		{
			get
			{
				return _checksumSHA256;
			}
			set
			{
				_checksumSHA256 = value;
			}
		}

		public long? Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public ChecksumType ChecksumType
		{
			get
			{
				return _checksumType;
			}
			set
			{
				_checksumType = value;
			}
		}

		internal bool IsSetETag()
		{
			return eTag != null;
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetRequestCharged()
		{
			return requestCharged != null;
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}

		internal bool IsSetChecksumCRC32()
		{
			return _checksumCRC32 != null;
		}

		internal bool IsSetChecksumCRC32C()
		{
			return _checksumCRC32C != null;
		}

		internal bool IsSetChecksumCRC64NVME()
		{
			return _checksumCRC64NVME != null;
		}

		internal bool IsSetChecksumSHA1()
		{
			return _checksumSHA1 != null;
		}

		internal bool IsSetChecksumSHA256()
		{
			return _checksumSHA256 != null;
		}

		internal bool IsSetSize()
		{
			return _size.HasValue;
		}

		internal bool IsSetChecksumType()
		{
			return _checksumType != null;
		}
	}
}
