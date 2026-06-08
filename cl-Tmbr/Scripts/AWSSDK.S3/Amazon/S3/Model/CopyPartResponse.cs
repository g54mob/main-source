using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class CopyPartResponse : AmazonWebServiceResponse
	{
		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private DateTime? lastModified;

		private string eTag;

		private string copySourceVersionId;

		private int? partNumber;

		private ServerSideEncryptionMethod serverSideEncryption;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private bool? bucketKeyEnabled;

		public string CopySourceVersionId
		{
			get
			{
				return copySourceVersionId;
			}
			set
			{
				copySourceVersionId = value;
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

		public int? PartNumber
		{
			get
			{
				return partNumber;
			}
			set
			{
				partNumber = value;
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

		public bool BucketKeyEnabled
		{
			get
			{
				return bucketKeyEnabled == true;
			}
			set
			{
				bucketKeyEnabled = value;
			}
		}

		internal bool IsSetCopySourceVersionId()
		{
			return copySourceVersionId != null;
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

		internal bool IsSetLastModified()
		{
			return lastModified.HasValue;
		}

		internal bool IsSetServerSideEncryptionMethod()
		{
			return serverSideEncryption != null;
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}
	}
}
