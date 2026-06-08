using System;
using System.Collections.Generic;
using System.IO;
using Amazon.Runtime.Internal;
using Amazon.S3.Model;
using Amazon.Util;

namespace Amazon.S3.Transfer
{
	public class TransferUtilityUploadDirectoryRequest : BaseUploadRequest
	{
		private string _directory;

		private string _bucketname;

		private string _searchPattern = "*";

		private string _keyPrefix;

		private string contentType;

		private bool _uploadFilesConcurrently;

		private SearchOption _searchOption;

		private S3CannedACL _cannedACL;

		private S3StorageClass _storageClass;

		private MetadataCollection metadataCollection;

		private ServerSideEncryptionMethod encryption;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKey;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private List<Tag> tagset;

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private ObjectLockMode objectLockMode;

		private bool disablePayloadSigning;

		private DateTime? objectLockRetainUntilDate;

		private ChecksumAlgorithm checksumAlgorithm;

		public bool DisablePayloadSigning
		{
			get
			{
				return disablePayloadSigning;
			}
			set
			{
				disablePayloadSigning = value;
			}
		}

		public string Directory
		{
			get
			{
				return _directory;
			}
			set
			{
				_directory = value;
			}
		}

		public string KeyPrefix
		{
			get
			{
				return _keyPrefix;
			}
			set
			{
				_keyPrefix = value;
			}
		}

		public string SearchPattern
		{
			get
			{
				if (!string.IsNullOrEmpty(_searchPattern))
				{
					return _searchPattern;
				}
				return "*";
			}
			set
			{
				_searchPattern = value;
			}
		}

		public SearchOption SearchOption
		{
			get
			{
				return _searchOption;
			}
			set
			{
				_searchOption = value;
			}
		}

		public string BucketName
		{
			get
			{
				return _bucketname;
			}
			set
			{
				_bucketname = value;
			}
		}

		public S3CannedACL CannedACL
		{
			get
			{
				return _cannedACL;
			}
			set
			{
				_cannedACL = value;
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
				return _storageClass;
			}
			set
			{
				_storageClass = value;
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

		public bool UploadFilesConcurrently
		{
			get
			{
				return _uploadFilesConcurrently;
			}
			set
			{
				_uploadFilesConcurrently = value;
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

		public bool? DisableDefaultChecksumValidation { get; set; }

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

		public event EventHandler<UploadDirectoryProgressArgs> UploadDirectoryProgressEvent;

		public event EventHandler<UploadDirectoryFileRequestArgs> UploadDirectoryFileRequestEvent;

		internal bool IsSetDirectory()
		{
			return !string.IsNullOrEmpty(_directory);
		}

		internal bool IsSetKeyPrefix()
		{
			return !string.IsNullOrEmpty(_keyPrefix);
		}

		internal bool IsSetSearchPattern()
		{
			return !string.IsNullOrEmpty(_searchPattern);
		}

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(_bucketname);
		}

		internal bool IsSetCannedACL()
		{
			if (_cannedACL != null)
			{
				return _cannedACL != S3CannedACL.NoACL;
			}
			return false;
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetObjectLockRetainUntilDate()
		{
			return objectLockRetainUntilDate.HasValue;
		}

		internal void OnRaiseProgressEvent(UploadDirectoryProgressArgs uploadDirectoryProgress)
		{
			AWSSDKUtils.InvokeInBackground(this.UploadDirectoryProgressEvent, uploadDirectoryProgress, this);
		}

		internal void RaiseUploadDirectoryFileRequestEvent(TransferUtilityUploadRequest request)
		{
			EventHandler<UploadDirectoryFileRequestArgs> eventHandler = this.UploadDirectoryFileRequestEvent;
			if (eventHandler != null)
			{
				UploadDirectoryFileRequestArgs e = new UploadDirectoryFileRequestArgs(request);
				eventHandler(this, e);
			}
		}
	}
}
