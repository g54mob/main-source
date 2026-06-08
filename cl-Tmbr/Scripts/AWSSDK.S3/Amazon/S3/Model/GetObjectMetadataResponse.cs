using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class GetObjectMetadataResponse : AmazonWebServiceResponse
	{
		private string deleteMarker;

		private string acceptRanges;

		private string contentRange;

		private Expiration expiration;

		private DateTime? restoreExpiration;

		private bool? restoreInProgress;

		private DateTime? lastModified;

		private string eTag;

		private int? missingMeta;

		private string versionId;

		private string websiteRedirectLocation;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private ServerSideEncryptionMethod serverSideEncryption;

		private ServerSideEncryptionCustomerMethod serverSideEncryptionCustomerMethod;

		private HeadersCollection headersCollection = new HeadersCollection();

		private MetadataCollection metadataCollection = new MetadataCollection();

		private ReplicationStatus replicationStatus;

		private ArchiveStatus archiveStatus;

		private int? partsCount;

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private ObjectLockMode objectLockMode;

		private DateTime? objectLockRetainUntilDate;

		private S3StorageClass storageClass;

		private RequestCharged requestCharged;

		private bool? bucketKeyEnabled;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private ChecksumType _checksumType;

		public string ExpiresString { get; set; }

		public HeadersCollection Headers
		{
			get
			{
				if (headersCollection == null)
				{
					headersCollection = new HeadersCollection();
				}
				return headersCollection;
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

		public string DeleteMarker
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

		public DateTime? RestoreExpiration
		{
			get
			{
				return restoreExpiration;
			}
			set
			{
				restoreExpiration = value;
			}
		}

		public bool? RestoreInProgress
		{
			get
			{
				return restoreInProgress;
			}
			set
			{
				restoreInProgress = value;
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

		public string WebsiteRedirectLocation
		{
			get
			{
				return websiteRedirectLocation;
			}
			set
			{
				websiteRedirectLocation = value;
			}
		}

		public ServerSideEncryptionMethod ServerSideEncryptionMethod
		{
			get
			{
				if (serverSideEncryption == null)
				{
					return ServerSideEncryptionMethod.None;
				}
				return serverSideEncryption;
			}
			set
			{
				serverSideEncryption = value;
			}
		}

		public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod
		{
			get
			{
				if (serverSideEncryptionCustomerMethod == null)
				{
					return ServerSideEncryptionCustomerMethod.None;
				}
				return serverSideEncryptionCustomerMethod;
			}
			set
			{
				serverSideEncryptionCustomerMethod = value;
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

		public ArchiveStatus ArchiveStatus
		{
			get
			{
				return archiveStatus;
			}
			set
			{
				archiveStatus = value;
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

		internal bool IsSetDeleteMarker()
		{
			return deleteMarker != null;
		}

		internal bool IsSetAcceptRanges()
		{
			return acceptRanges != null;
		}

		internal bool IsSetContentRange()
		{
			return contentRange != null;
		}

		internal bool IsSetExpiration()
		{
			return expiration != null;
		}

		internal bool IsSetLastModified()
		{
			return lastModified.HasValue;
		}

		internal bool IsSetETag()
		{
			return eTag != null;
		}

		internal bool IsSetMissingMeta()
		{
			return missingMeta.HasValue;
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}

		internal bool IsSetWebsiteRedirectLocation()
		{
			return websiteRedirectLocation != null;
		}

		internal bool IsSetServerSideEncryptionMethod()
		{
			return serverSideEncryptionCustomerMethod != null;
		}

		internal bool IsSetServerSideEncryptionCustomerMethod()
		{
			return serverSideEncryptionCustomerMethod != null;
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetReplicationStatus()
		{
			return ReplicationStatus != null;
		}

		internal bool IsSetPartsCount()
		{
			return partsCount.HasValue;
		}

		internal bool IsSetObjectLockLegalHoldStatus()
		{
			return objectLockLegalHoldStatus != null;
		}

		internal bool IsSetObjectLockMode()
		{
			return objectLockMode != null;
		}

		internal bool IsSetObjectLockRetainUntilDate()
		{
			return objectLockRetainUntilDate.HasValue;
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
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

		internal bool IsSetChecksumType()
		{
			return _checksumType != null;
		}
	}
}
