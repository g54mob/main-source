using System;
using System.Collections.Generic;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class CopyObjectRequest : PutWithACLRequest
	{
		private S3CannedACL cannedACL;

		private bool? bucketKeyEnabled;

		private string srcBucket;

		private string srcKey;

		private string srcVersionId;

		private string dstBucket;

		private string dstKey;

		private RequestPayer requestPayer;

		private string expectedBucketOwner;

		private string expectedSourceBucketOwner;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string etagToMatch;

		private string etagToNotMatch;

		private DateTime? modifiedSinceDate;

		private DateTime? unmodifiedSinceDate;

		private List<Tag> tagset = (AWSConfigs.InitializeCollections ? new List<Tag>() : null);

		private S3MetadataDirective metadataDirective;

		private S3StorageClass storageClass;

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private ObjectLockMode objectLockMode;

		private DateTime? objectLockRetainUntilDate;

		private string websiteRedirectLocation;

		private HeadersCollection headersCollection = new HeadersCollection();

		private MetadataCollection metadataCollection = new MetadataCollection();

		private ServerSideEncryptionMethod serverSideEncryption;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKey;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private string serverSideEncryptionKeyManagementServiceEncryptionContext;

		private ServerSideEncryptionCustomerMethod copySourceServerSideCustomerEncryption;

		private string copySourceServerSideEncryptionCustomerProvidedKey;

		private string copySourceServerSideEncryptionCustomerProvidedKeyMD5;

		private TaggingDirective taggingDirective;

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

		public string ContentType
		{
			get
			{
				return Headers.ContentType;
			}
			set
			{
				Headers.ContentType = value;
			}
		}

		public DateTime? ModifiedSinceDate
		{
			get
			{
				return modifiedSinceDate ?? DateTime.SpecifyKind(default(DateTime), DateTimeKind.Utc);
			}
			set
			{
				if (!value.HasValue)
				{
					modifiedSinceDate = null;
				}
				else
				{
					modifiedSinceDate = value;
				}
			}
		}

		public DateTime? UnmodifiedSinceDate
		{
			get
			{
				return unmodifiedSinceDate ?? DateTime.SpecifyKind(default(DateTime), DateTimeKind.Utc);
			}
			set
			{
				if (!value.HasValue)
				{
					unmodifiedSinceDate = null;
				}
				else
				{
					unmodifiedSinceDate = value;
				}
			}
		}

		public ServerSideEncryptionCustomerMethod CopySourceServerSideEncryptionCustomerMethod
		{
			get
			{
				return copySourceServerSideCustomerEncryption;
			}
			set
			{
				copySourceServerSideCustomerEncryption = value;
			}
		}

		[AWSProperty(Sensitive = true)]
		public string CopySourceServerSideEncryptionCustomerProvidedKey
		{
			get
			{
				return copySourceServerSideEncryptionCustomerProvidedKey;
			}
			set
			{
				copySourceServerSideEncryptionCustomerProvidedKey = value;
			}
		}

		public string CopySourceServerSideEncryptionCustomerProvidedKeyMD5
		{
			get
			{
				return copySourceServerSideEncryptionCustomerProvidedKeyMD5;
			}
			set
			{
				copySourceServerSideEncryptionCustomerProvidedKeyMD5 = value;
			}
		}

		public string DestinationBucket
		{
			get
			{
				return dstBucket;
			}
			set
			{
				dstBucket = value;
			}
		}

		public string DestinationKey
		{
			get
			{
				return dstKey;
			}
			set
			{
				dstKey = value;
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

		public string ExpectedSourceBucketOwner
		{
			get
			{
				return expectedSourceBucketOwner;
			}
			set
			{
				expectedSourceBucketOwner = value;
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

		public S3MetadataDirective MetadataDirective
		{
			get
			{
				return metadataDirective;
			}
			set
			{
				metadataDirective = value;
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

		public RequestPayer RequestPayer
		{
			get
			{
				return requestPayer;
			}
			set
			{
				requestPayer = value;
			}
		}

		public string SourceBucket
		{
			get
			{
				return srcBucket;
			}
			set
			{
				srcBucket = value;
			}
		}

		public string SourceKey
		{
			get
			{
				return srcKey;
			}
			set
			{
				srcKey = value;
			}
		}

		public string SourceVersionId
		{
			get
			{
				return srcVersionId;
			}
			set
			{
				srcVersionId = value;
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

		[AWSProperty(Sensitive = true)]
		public string ServerSideEncryptionCustomerProvidedKey
		{
			get
			{
				return serverSideEncryptionCustomerProvidedKey;
			}
			set
			{
				serverSideEncryptionCustomerProvidedKey = value;
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

		public List<Tag> TagSet
		{
			get
			{
				return tagset;
			}
			set
			{
				tagset = value;
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

		public string ETagToMatch
		{
			get
			{
				return etagToMatch;
			}
			set
			{
				etagToMatch = value;
			}
		}

		public string ETagToNotMatch
		{
			get
			{
				return etagToNotMatch;
			}
			set
			{
				etagToNotMatch = value;
			}
		}

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

		public TaggingDirective TaggingDirective
		{
			get
			{
				return taggingDirective;
			}
			set
			{
				taggingDirective = value;
			}
		}

		internal bool IsSetCannedACL()
		{
			if (cannedACL != null)
			{
				return cannedACL != S3CannedACL.NoACL;
			}
			return false;
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}

		internal bool IsSetModifiedSinceDate()
		{
			return modifiedSinceDate.HasValue;
		}

		internal bool IsSetUnmodifiedSinceDate()
		{
			return unmodifiedSinceDate.HasValue;
		}

		internal bool IsSetCopySourceServerSideEncryptionCustomerMethod()
		{
			if (copySourceServerSideCustomerEncryption != null)
			{
				return copySourceServerSideCustomerEncryption != ServerSideEncryptionCustomerMethod.None;
			}
			return false;
		}

		internal bool IsSetCopySourceServerSideEncryptionCustomerProvidedKey()
		{
			return !string.IsNullOrEmpty(copySourceServerSideEncryptionCustomerProvidedKey);
		}

		internal bool IsSetCopySourceServerSideEncryptionCustomerProvidedKeyMD5()
		{
			return !string.IsNullOrEmpty(copySourceServerSideEncryptionCustomerProvidedKeyMD5);
		}

		internal bool IsSetDestinationBucket()
		{
			return !string.IsNullOrEmpty(dstBucket);
		}

		internal bool IsSetDestinationKey()
		{
			return !string.IsNullOrEmpty(dstKey);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetExpectedSourceBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedSourceBucketOwner);
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

		internal bool IsSetRequestPayer()
		{
			return requestPayer != null;
		}

		internal bool IsSetSourceBucket()
		{
			return !string.IsNullOrEmpty(srcBucket);
		}

		internal bool IsSetSourceKey()
		{
			return !string.IsNullOrEmpty(srcKey);
		}

		internal bool IsSetSourceVersionId()
		{
			return !string.IsNullOrEmpty(srcVersionId);
		}

		internal bool IsSetServerSideEncryptionMethod()
		{
			if (serverSideEncryption != null)
			{
				return serverSideEncryption != ServerSideEncryptionMethod.None;
			}
			return false;
		}

		internal bool IsSetServerSideEncryptionCustomerMethod()
		{
			if (serverSideCustomerEncryption != null)
			{
				return serverSideCustomerEncryption != ServerSideEncryptionCustomerMethod.None;
			}
			return false;
		}

		internal bool IsSetServerSideEncryptionCustomerProvidedKey()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionCustomerProvidedKey);
		}

		internal bool IsSetServerSideEncryptionCustomerProvidedKeyMD5()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionCustomerProvidedKeyMD5);
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceEncryptionContext()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceEncryptionContext);
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
		}

		internal bool IsSetTagSet()
		{
			if (tagset != null)
			{
				if (tagset.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetWebsiteRedirectLocation()
		{
			return websiteRedirectLocation != null;
		}

		internal bool IsSetETagToMatch()
		{
			return !string.IsNullOrEmpty(etagToMatch);
		}

		internal bool IsSetETagToNotMatch()
		{
			return !string.IsNullOrEmpty(etagToNotMatch);
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetTaggingDirective()
		{
			return taggingDirective != null;
		}
	}
}
