using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class CreateSessionRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private SessionMode _sessionMode;

		private ServerSideEncryptionMethod _serverSideEncryption;

		private string _serverSideEncryptionKeyManagementServiceKeyId;

		private string _serverSideEncryptionKeyManagementServiceEncryptionContext;

		private bool? _bucketKeyEnabled;

		public string BucketName
		{
			get
			{
				return _bucketName;
			}
			set
			{
				_bucketName = value;
			}
		}

		public SessionMode SessionMode
		{
			get
			{
				return _sessionMode;
			}
			set
			{
				_sessionMode = value;
			}
		}

		public ServerSideEncryptionMethod ServerSideEncryption
		{
			get
			{
				return _serverSideEncryption;
			}
			set
			{
				_serverSideEncryption = value;
			}
		}

		[AWSProperty(Sensitive = true)]
		public string SSEKMSKeyId
		{
			get
			{
				return _serverSideEncryptionKeyManagementServiceKeyId;
			}
			set
			{
				_serverSideEncryptionKeyManagementServiceKeyId = value;
			}
		}

		[AWSProperty(Sensitive = true)]
		public string SSEKMSEncryptionContext
		{
			get
			{
				return _serverSideEncryptionKeyManagementServiceEncryptionContext;
			}
			set
			{
				_serverSideEncryptionKeyManagementServiceEncryptionContext = value;
			}
		}

		public bool? BucketKeyEnabled
		{
			get
			{
				return _bucketKeyEnabled;
			}
			set
			{
				_bucketKeyEnabled = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return _bucketName != null;
		}

		internal bool IsSetSessionMode()
		{
			return _sessionMode != null;
		}

		internal bool IsSetServerSideEncryptionMethod()
		{
			if (_serverSideEncryption != null)
			{
				return _serverSideEncryption != ServerSideEncryptionMethod.None;
			}
			return false;
		}

		internal bool IsSetSSEKMSKeyId()
		{
			return !string.IsNullOrEmpty(_serverSideEncryptionKeyManagementServiceKeyId);
		}

		internal bool IsSetSSEKMSEncryptionContext()
		{
			return !string.IsNullOrEmpty(_serverSideEncryptionKeyManagementServiceEncryptionContext);
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return _bucketKeyEnabled.HasValue;
		}
	}
}
