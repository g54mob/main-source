using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.S3.Model
{
	public class GetObjectResponse : StreamResponse
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

		private ObjectLockLegalHoldStatus objectLockLegalHoldStatus;

		private ObjectLockMode objectLockMode;

		private DateTime? objectLockRetainUntilDate;

		private string websiteRedirectLocation;

		private ServerSideEncryptionMethod serverSideEncryption;

		private ServerSideEncryptionCustomerMethod serverSideEncryptionCustomerMethod;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private HeadersCollection headersCollection = new HeadersCollection();

		private MetadataCollection metadataCollection = new MetadataCollection();

		private ReplicationStatus replicationStatus;

		private int? partsCount;

		private S3StorageClass storageClass;

		private RequestCharged requestCharged;

		private int? tagCount;

		private string bucketName;

		private string key;

		private bool? bucketKeyEnabled;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private ChecksumType _checksumType;

		public string ExpiresString { get; set; }

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
				return serverSideEncryption;
			}
			set
			{
				serverSideEncryption = value;
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

		public int TagCount
		{
			get
			{
				return tagCount.GetValueOrDefault();
			}
			set
			{
				tagCount = value;
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

		public event EventHandler<WriteObjectProgressArgs> WriteObjectProgressEvent;

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

		internal bool IsSetWebsiteRedirectLocation()
		{
			return websiteRedirectLocation != null;
		}

		internal bool IsSetServerSideEncryptionMethod()
		{
			return serverSideEncryption != null;
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
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

		internal void OnRaiseProgressEvent(string file, long incrementTransferred, long transferred, long total, bool completed)
		{
			AWSSDKUtils.InvokeInBackground(this.WriteObjectProgressEvent, new WriteObjectProgressArgs(BucketName, Key, file, VersionId, incrementTransferred, transferred, total, completed), this);
		}

		private void ValidateWrittenStreamSize(long bytesWritten)
		{
			if (WrapperStream.SearchWrappedStream(base.ResponseStream, (Stream s) => s is DecryptStream) != null || bytesWritten == base.ContentLength)
			{
				return;
			}
			if (!base.ResponseMetadata.Metadata.TryGetValue("x-amz-id-2", out var value))
			{
				value = string.Empty;
			}
			if (!base.ResponseMetadata.Metadata.TryGetValue("X-Amz-Cf-Id", out var value2))
			{
				value2 = string.Empty;
			}
			string text = null;
			text = ((!string.IsNullOrEmpty(value2)) ? string.Format(CultureInfo.InvariantCulture, "The total bytes read {0} from response stream is not equal to the Content-Length {1} for the object {2} in bucket {3}. Request ID = {4} , AmzId2 = {5} , AmzCfId = {6}.", bytesWritten, base.ContentLength, Key, BucketName, base.ResponseMetadata.RequestId, value, value2) : string.Format(CultureInfo.InvariantCulture, "The total bytes read {0} from response stream is not equal to the Content-Length {1} for the object {2} in bucket {3}. Request ID = {4} , AmzId2 = {5}.", bytesWritten, base.ContentLength, Key, BucketName, base.ResponseMetadata.RequestId, value));
			throw new StreamSizeMismatchException(text, base.ContentLength, bytesWritten, base.ResponseMetadata.RequestId, value, value2);
		}

		public async Task WriteResponseStreamToFileAsync(string filePath, bool append, CancellationToken cancellationToken)
		{
			Directory.CreateDirectory(new FileInfo(filePath).DirectoryName);
			Stream downloadStream = ((!append || !File.Exists(filePath)) ? new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 8192) : new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read, 8192));
			try
			{
				long current = 0L;
				Stream stream = base.ResponseStream;
				byte[] buffer = new byte[8192];
				long totalIncrementTransferred = 0L;
				while (true)
				{
					int num;
					int bytesRead = (num = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(continueOnCapturedContext: false));
					if (num <= 0)
					{
						break;
					}
					cancellationToken.ThrowIfCancellationRequested();
					await downloadStream.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					current += bytesRead;
					totalIncrementTransferred += bytesRead;
					if (totalIncrementTransferred >= 102400)
					{
						OnRaiseProgressEvent(filePath, totalIncrementTransferred, current, base.ContentLength, completed: false);
						totalIncrementTransferred = 0L;
					}
				}
				ValidateWrittenStreamSize(current);
				OnRaiseProgressEvent(filePath, totalIncrementTransferred, current, base.ContentLength, completed: true);
			}
			finally
			{
				downloadStream.Dispose();
			}
		}
	}
}
