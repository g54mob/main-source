using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class CompleteMultipartUploadResponse : AmazonWebServiceResponse
	{
		private string location;

		private string bucketName;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private string key;

		private string eTag;

		private string versionId;

		private ChecksumType checksumType;

		private Expiration expiration;

		private ServerSideEncryptionMethod serverSideEncryption;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private RequestCharged requestCharged;

		private bool? bucketKeyEnabled;

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

		public string Location
		{
			get
			{
				return location;
			}
			set
			{
				location = value;
			}
		}

		public ChecksumType ChecksumType
		{
			get
			{
				return checksumType;
			}
			set
			{
				checksumType = value;
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

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
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

		internal bool IsSetETag()
		{
			return eTag != null;
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetLocation()
		{
			return location != null;
		}

		internal bool IsSetRequestCharged()
		{
			return requestCharged != null;
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}
	}
}
