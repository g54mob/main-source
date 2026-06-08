using System;
using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public class S3Object
	{
		private List<string> _checksumAlgorithm = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private string eTag;

		private string key;

		private DateTime? lastModified;

		private Owner owner;

		private RestoreStatus _restoreStatus;

		private long? size;

		private S3StorageClass storageClass;

		private string bucketName;

		private ChecksumType checksumType;

		public List<string> ChecksumAlgorithm
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

		public Owner Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		public RestoreStatus RestoreStatus
		{
			get
			{
				return _restoreStatus;
			}
			set
			{
				_restoreStatus = value;
			}
		}

		public long? Size
		{
			get
			{
				return size;
			}
			set
			{
				size = value;
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

		internal bool IsSetChecksumAlgorithm()
		{
			if (_checksumAlgorithm != null)
			{
				if (_checksumAlgorithm.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetETag()
		{
			return eTag != null;
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetLastModified()
		{
			return lastModified.HasValue;
		}

		internal bool IsSetOwner()
		{
			return owner != null;
		}

		internal bool IsSetRestoreStatus()
		{
			return _restoreStatus != null;
		}

		internal bool IsSetSize()
		{
			return size.HasValue;
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
		}

		internal bool IsSetChecksumType()
		{
			return checksumType != null;
		}
	}
}
