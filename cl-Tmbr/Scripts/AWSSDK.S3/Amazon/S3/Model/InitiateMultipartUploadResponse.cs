using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class InitiateMultipartUploadResponse : AmazonWebServiceResponse
	{
		private DateTime? abortDate;

		private string abortRuleId;

		private bool? bucketKeyEnabled;

		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private ChecksumType _checksumType;

		private string key;

		private RequestCharged requestCharged;

		private ServerSideEncryptionMethod serverSideEncryption;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private string serverSideEncryptionKeyManagementServiceKeyId;

		private string serverSideEncryptionKeyManagementServiceEncryptionContext;

		private string uploadId;

		public DateTime? AbortDate
		{
			get
			{
				return abortDate;
			}
			set
			{
				abortDate = value;
			}
		}

		public string AbortRuleId
		{
			get
			{
				return abortRuleId;
			}
			set
			{
				abortRuleId = value;
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

		public string UploadId
		{
			get
			{
				return uploadId;
			}
			set
			{
				uploadId = value;
			}
		}

		internal bool IsSetAbortDate()
		{
			return abortDate.HasValue;
		}

		internal bool IsSetAbortRuleId()
		{
			return abortRuleId != null;
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetChecksumType()
		{
			return _checksumType != null;
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetRequestCharged()
		{
			return requestCharged != null;
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetUploadId()
		{
			return uploadId != null;
		}
	}
}
