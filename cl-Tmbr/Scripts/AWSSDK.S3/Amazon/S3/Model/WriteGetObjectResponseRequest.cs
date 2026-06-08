using System;
using System.IO;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class WriteGetObjectResponseRequest : AmazonWebServiceRequest
	{
		private string requestRoute;

		private string requestToken;

		private int? statusCode;

		private string errorCode;

		private string errorMessage;

		private string acceptRanges;

		private string cacheControl;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private string contentDisposition;

		private string contentEncoding;

		private string contentLanguage;

		private long? contentLength;

		private string contentRange;

		private string contentType;

		private bool? deleteMarker;

		private string eTag;

		private DateTime? expires;

		private string expiration;

		private DateTime? lastModified;

		private int? missingMeta;

		private MetadataCollection metadataCollection = new MetadataCollection();

		private ObjectLockMode objectLockMode;

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private DateTime? objectLockRetainUntilDate;

		private int? partsCount;

		private ReplicationStatus replicationStatus;

		private RequestCharged requestCharged;

		private string restore;

		private ServerSideEncryptionMethod serverSideEncryption;

		private ServerSideEncryptionCustomerMethod sSECustomerAlgorithm;

		private string sSEKMSKeyId;

		private string sSECustomerKeyMD5;

		private S3StorageClass storageClass;

		private int? tagCount;

		private string versionId;

		private bool? bucketKeyEnabled;

		private Stream inputStream;

		public string RequestRoute
		{
			get
			{
				return requestRoute;
			}
			set
			{
				requestRoute = value;
			}
		}

		public string RequestToken
		{
			get
			{
				return requestToken;
			}
			set
			{
				requestToken = value;
			}
		}

		public int? StatusCode
		{
			get
			{
				return statusCode;
			}
			set
			{
				statusCode = value;
			}
		}

		public string ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				errorCode = value;
			}
		}

		public string ErrorMessage
		{
			get
			{
				return errorMessage;
			}
			set
			{
				errorMessage = value;
			}
		}

		public string AcceptRanges
		{
			get
			{
				return acceptRanges;
			}
			set
			{
				acceptRanges = value;
			}
		}

		public string CacheControl
		{
			get
			{
				return cacheControl;
			}
			set
			{
				cacheControl = value;
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

		public string ContentDisposition
		{
			get
			{
				return contentDisposition;
			}
			set
			{
				contentDisposition = value;
			}
		}

		public string ContentEncoding
		{
			get
			{
				return contentEncoding;
			}
			set
			{
				contentEncoding = value;
			}
		}

		public string ContentLanguage
		{
			get
			{
				return contentLanguage;
			}
			set
			{
				contentLanguage = value;
			}
		}

		public long? ContentLength
		{
			get
			{
				return contentLength;
			}
			set
			{
				contentLength = value;
			}
		}

		public string ContentRange
		{
			get
			{
				return contentRange;
			}
			set
			{
				contentRange = value;
			}
		}

		public string ContentType
		{
			get
			{
				return contentType;
			}
			set
			{
				contentType = value;
			}
		}

		public bool? DeleteMarker
		{
			get
			{
				return deleteMarker;
			}
			set
			{
				deleteMarker = value;
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

		public DateTime? Expires
		{
			get
			{
				return expires;
			}
			set
			{
				expires = value;
			}
		}

		public string Expiration
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

		public DateTime? LastModified
		{
			get
			{
				return lastModified;
			}
			set
			{
				lastModified = value;
			}
		}

		public int? MissingMeta
		{
			get
			{
				return missingMeta;
			}
			set
			{
				missingMeta = value;
			}
		}

		public MetadataCollection Metadata
		{
			get
			{
				if (metadataCollection == null)
				{
					metadataCollection = new MetadataCollection();
				}
				return metadataCollection;
			}
		}

		public ObjectLockMode ObjectLockMode
		{
			get
			{
				return objectLockMode;
			}
			set
			{
				objectLockMode = value;
			}
		}

		public ObjectLockLegalHoldStatus ObjectLockLegalHoldStatus
		{
			get
			{
				return objectLockLegalHoldStatus;
			}
			set
			{
				objectLockLegalHoldStatus = value;
			}
		}

		public DateTime? ObjectLockRetainUntilDate
		{
			get
			{
				return objectLockRetainUntilDate;
			}
			set
			{
				objectLockRetainUntilDate = value;
			}
		}

		public int? PartsCount
		{
			get
			{
				return partsCount;
			}
			set
			{
				partsCount = value;
			}
		}

		public ReplicationStatus ReplicationStatus
		{
			get
			{
				return replicationStatus;
			}
			set
			{
				replicationStatus = value;
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

		public string Restore
		{
			get
			{
				return restore;
			}
			set
			{
				restore = value;
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

		public ServerSideEncryptionCustomerMethod SSECustomerAlgorithm
		{
			get
			{
				return sSECustomerAlgorithm;
			}
			set
			{
				sSECustomerAlgorithm = value;
			}
		}

		public string SSEKMSKeyId
		{
			get
			{
				return sSEKMSKeyId;
			}
			set
			{
				sSEKMSKeyId = value;
			}
		}

		public string SSECustomerKeyMD5
		{
			get
			{
				return sSECustomerKeyMD5;
			}
			set
			{
				sSECustomerKeyMD5 = value;
			}
		}

		public S3StorageClass StorageClass
		{
			get
			{
				return storageClass;
			}
			set
			{
				storageClass = value;
			}
		}

		public int? TagCount
		{
			get
			{
				return tagCount;
			}
			set
			{
				tagCount = value;
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

		public Stream Body
		{
			get
			{
				return inputStream;
			}
			set
			{
				inputStream = value;
			}
		}

		internal bool IsSetRequestRoute()
		{
			return !string.IsNullOrEmpty(requestRoute);
		}

		internal bool IsSetRequestToken()
		{
			return !string.IsNullOrEmpty(requestToken);
		}

		internal bool IsSetStatusCode()
		{
			return statusCode.HasValue;
		}

		internal bool IsSetErrorCode()
		{
			return !string.IsNullOrEmpty(errorCode);
		}

		internal bool IsSetErrorMessage()
		{
			return !string.IsNullOrEmpty(errorMessage);
		}

		internal bool IsSetAcceptRanges()
		{
			return acceptRanges != null;
		}

		internal bool IsSetCacheControl()
		{
			return !string.IsNullOrEmpty(cacheControl);
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

		internal bool IsSetContentDisposition()
		{
			return !string.IsNullOrEmpty(contentDisposition);
		}

		internal bool IsSetContentEncoding()
		{
			return !string.IsNullOrEmpty(contentEncoding);
		}

		internal bool IsSetContentLanguage()
		{
			return !string.IsNullOrEmpty(contentLanguage);
		}

		internal bool IsSetContentLength()
		{
			return contentLength.HasValue;
		}

		internal bool IsSetContentRange()
		{
			return !string.IsNullOrEmpty(contentRange);
		}

		internal bool IsSetContentType()
		{
			return !string.IsNullOrEmpty(contentType);
		}

		internal bool IsSetDeleteMarker()
		{
			return deleteMarker.HasValue;
		}

		internal bool IsSetETag()
		{
			return eTag != null;
		}

		internal bool IsSetExpires()
		{
			return expires.HasValue;
		}

		internal bool IsSetExpiration()
		{
			return !string.IsNullOrEmpty(expiration);
		}

		internal bool IsSetLastModified()
		{
			return lastModified.HasValue;
		}

		internal bool IsSetMissingMeta()
		{
			return missingMeta.HasValue;
		}

		internal bool IsSetObjectLockMode()
		{
			return objectLockMode != null;
		}

		internal bool IsSetObjectLockLegalHoldStatus()
		{
			return objectLockLegalHoldStatus != null;
		}

		internal bool IsSetObjectLockRetainUntilDate()
		{
			return objectLockRetainUntilDate.HasValue;
		}

		internal bool IsSetPartsCount()
		{
			return partsCount.HasValue;
		}

		internal bool IsSetReplicationStatus()
		{
			return ReplicationStatus != null;
		}

		internal bool IsSetRequestCharged()
		{
			return requestCharged != null;
		}

		internal bool IsSetRestore()
		{
			return !string.IsNullOrEmpty(restore);
		}

		internal bool IsSetServerSideEncryptionMethod()
		{
			if (serverSideEncryption != null)
			{
				return serverSideEncryption != ServerSideEncryptionMethod.None;
			}
			return false;
		}

		internal bool IsSetSSECustomerAlgorithm()
		{
			if (sSECustomerAlgorithm != null)
			{
				return sSECustomerAlgorithm != ServerSideEncryptionCustomerMethod.None;
			}
			return false;
		}

		internal bool IsSetSSEKMSKeyId()
		{
			return !string.IsNullOrEmpty(sSEKMSKeyId);
		}

		internal bool IsSetSSECustomerKeyMD5()
		{
			return !string.IsNullOrEmpty(sSECustomerKeyMD5);
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
		}

		internal bool IsSetTagCount()
		{
			return tagCount.HasValue;
		}

		internal bool IsSetVersionId()
		{
			return !string.IsNullOrEmpty(versionId);
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}

		internal bool IsSetInputStream()
		{
			return inputStream != null;
		}
	}
}
