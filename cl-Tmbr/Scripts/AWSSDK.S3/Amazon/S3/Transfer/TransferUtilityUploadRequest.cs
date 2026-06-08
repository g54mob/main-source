using System;
using System.Collections.Generic;
using System.IO;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using Amazon.Util;

namespace Amazon.S3.Transfer
{
	public class TransferUtilityUploadRequest : BaseUploadRequest
	{
		private string bucketName;

		private string key;

		private S3CannedACL cannedACL;

		private string contentType;

		private S3StorageClass storageClass;

		private long? partSize;

		private bool autoCloseStream = true;

		private bool autoResetStreamPosition = true;

		private ServerSideEncryptionMethod encryption;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKey;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private ChecksumAlgorithm checksumAlgorithm;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private string _ifNoneMatch;

		private string _ifMatch;

		private long? _mpuObjectSize;

		private HeadersCollection headersCollection = new HeadersCollection();

		private MetadataCollection metadataCollection = new MetadataCollection();

		private List<Tag> tagset;

		private Stream inputStream;

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private ObjectLockMode objectLockMode;

		private DateTime? objectLockRetainUntilDate;

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

		public ServerSideEncryptionMethod ServerSideEncryptionMethod
		{
			get
			{
				return encryption;
			}
			set
			{
				encryption = value;
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

		public string FilePath { get; set; }

		public long PartSize
		{
			get
			{
				return partSize.GetValueOrDefault();
			}
			set
			{
				partSize = value;
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
			internal set
			{
				headersCollection = value;
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

		internal long ContentLength
		{
			get
			{
				try
				{
					if (IsSetFilePath())
					{
						return new FileInfo(FilePath).Length;
					}
					return InputStream.Length - InputStream.Position;
				}
				catch (NotSupportedException)
				{
					return -1L;
				}
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

		public bool? DisablePayloadSigning { get; set; }

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

		public DateTime ObjectLockRetainUntilDate
		{
			get
			{
				return objectLockRetainUntilDate.GetValueOrDefault();
			}
			set
			{
				objectLockRetainUntilDate = value;
			}
		}

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return checksumAlgorithm;
			}
			set
			{
				checksumAlgorithm = value;
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

		public long MpuObjectSize
		{
			get
			{
				return _mpuObjectSize.GetValueOrDefault();
			}
			set
			{
				_mpuObjectSize = value;
			}
		}

		public event EventHandler<UploadProgressArgs> UploadProgressEvent;

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(bucketName);
		}

		internal bool IsSetKey()
		{
			return !string.IsNullOrEmpty(key);
		}

		internal bool IsSetCannedACL()
		{
			return cannedACL != null;
		}

		public void RemoveCannedACL()
		{
			cannedACL = null;
		}

		internal bool IsSetContentType()
		{
			return !string.IsNullOrEmpty(contentType);
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetInputStream()
		{
			return inputStream != null;
		}

		internal bool IsSetFilePath()
		{
			return !string.IsNullOrEmpty(FilePath);
		}

		internal bool IsSetPartSize()
		{
			return partSize.HasValue;
		}

		internal void OnRaiseProgressEvent(UploadProgressArgs progressArgs)
		{
			AWSSDKUtils.InvokeInBackground(this.UploadProgressEvent, progressArgs, this);
		}

		public TransferUtilityUploadRequest WithAutoCloseStream(bool autoCloseStream)
		{
			this.autoCloseStream = autoCloseStream;
			return this;
		}

		internal bool IsSetObjectLockRetainUntilDate()
		{
			return objectLockRetainUntilDate.HasValue;
		}

		internal bool IsSetChecksumCRC32()
		{
			return !string.IsNullOrEmpty(_checksumCRC32);
		}

		internal bool IsSetChecksumCRC32C()
		{
			return !string.IsNullOrEmpty(_checksumCRC32C);
		}

		internal bool IsSetChecksumCRC64NVME()
		{
			return !string.IsNullOrEmpty(_checksumCRC64NVME);
		}

		internal bool IsSetChecksumSHA1()
		{
			return !string.IsNullOrEmpty(_checksumSHA1);
		}

		internal bool IsSetChecksumSHA256()
		{
			return !string.IsNullOrEmpty(_checksumSHA256);
		}

		internal bool IsSetIfNoneMatch()
		{
			return !string.IsNullOrEmpty(_ifNoneMatch);
		}

		internal bool IsSetIfMatch()
		{
			return !string.IsNullOrEmpty(_ifMatch);
		}

		internal bool IsSetMpuObjectSize()
		{
			return _mpuObjectSize.HasValue;
		}
	}
}
