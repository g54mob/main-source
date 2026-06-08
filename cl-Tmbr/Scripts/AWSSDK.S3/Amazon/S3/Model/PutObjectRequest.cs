using System;
using System.Collections.Generic;
using System.IO;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class PutObjectRequest : PutWithACLRequest
	{
		private S3CannedACL cannedACL;

		private bool? bucketKeyEnabled;

		private string bucketName;

		private string contentBody;

		private string expectedBucketOwner;

		private string key;

		private long? _writeOffsetBytes;

		private Stream inputStream;

		private string filePath;

		private bool autoCloseStream = true;

		private bool autoResetStreamPosition = true;

		private bool useChunkEncoding = true;

		private HeadersCollection headersCollection = new HeadersCollection();

		private MetadataCollection metadataCollection = new MetadataCollection();

		private string md5Digest;

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private ObjectLockMode objectLockMode;

		private DateTime? objectLockRetainUntilDate;

		private RequestPayer requestPayer;

		private ServerSideEncryptionMethod serverSideEncryption;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKey;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private string serverSideEncryptionKeyManagementServiceEncryptionContext;

		private S3StorageClass storageClass;

		private List<Tag> tagset = (AWSConfigs.InitializeCollections ? new List<Tag>() : null);

		private string websiteRedirectLocation;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private string _ifNoneMatch;

		private string _ifMatch;

		protected override bool IncludeSHA256Header => false;

		protected override bool Expect100Continue => true;

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

		public string MD5Digest
		{
			get
			{
				return md5Digest;
			}
			set
			{
				md5Digest = value;
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

		public string IfNoneMatch
		{
			get
			{
				return _ifNoneMatch;
			}
			set
			{
				_ifNoneMatch = value;
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

		public long WriteOffsetBytes
		{
			get
			{
				return _writeOffsetBytes.GetValueOrDefault();
			}
			set
			{
				_writeOffsetBytes = value;
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
			internal set
			{
				metadataCollection = value;
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

		public Stream InputStream
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

		public string FilePath
		{
			get
			{
				return filePath;
			}
			set
			{
				filePath = value;
			}
		}

		public string ContentBody
		{
			get
			{
				return contentBody;
			}
			set
			{
				contentBody = value;
			}
		}

		public bool AutoCloseStream
		{
			get
			{
				return autoCloseStream;
			}
			set
			{
				autoCloseStream = value;
			}
		}

		public bool AutoResetStreamPosition
		{
			get
			{
				return autoResetStreamPosition;
			}
			set
			{
				autoResetStreamPosition = value;
			}
		}

		public bool? DisableDefaultChecksumValidation { get; set; }

		public bool UseChunkEncoding
		{
			get
			{
				return useChunkEncoding;
			}
			set
			{
				useChunkEncoding = value;
			}
		}

		public bool? DisablePayloadSigning { get; set; }

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
			internal set
			{
				headersCollection = value;
			}
		}

		public EventHandler<StreamTransferProgressArgs> StreamTransferProgress
		{
			get
			{
				return ((IAmazonWebServiceRequest)this).StreamUploadProgressCallback;
			}
			set
			{
				((IAmazonWebServiceRequest)this).StreamUploadProgressCallback = value;
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

		public string IfMatch
		{
			get
			{
				return _ifMatch;
			}
			set
			{
				_ifMatch = value;
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

		internal bool IsSetBucket()
		{
			return bucketName != null;
		}

		internal bool IsSetMD5Digest()
		{
			return !string.IsNullOrEmpty(md5Digest);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetIfNoneMatch()
		{
			return !string.IsNullOrEmpty(_ifNoneMatch);
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetWriteOffsetBytes()
		{
			return _writeOffsetBytes.HasValue;
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

		internal bool IsSetInputStream()
		{
			return inputStream != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
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

		internal bool IsSetIfMatch()
		{
			return !string.IsNullOrEmpty(_ifMatch);
		}

		internal void SetupForFilePath()
		{
			InputStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
			if (string.IsNullOrEmpty(Key))
			{
				Key = Path.GetFileName(FilePath);
			}
		}
	}
}
