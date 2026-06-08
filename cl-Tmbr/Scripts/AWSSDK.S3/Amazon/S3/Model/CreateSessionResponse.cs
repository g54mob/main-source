using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class CreateSessionResponse : AmazonWebServiceResponse
	{
		private SessionCredentials _credentials;

		private ServerSideEncryptionMethod _serverSideEncryption;

		private string _serverSideEncryptionKeyManagementServiceKeyId;

		private string _serverSideEncryptionKeyManagementServiceEncryptionContext;

		private bool? _bucketKeyEnabled;

		[AWSProperty(Required = true)]
		public SessionCredentials Credentials
		{
			get
			{
				return _credentials;
			}
			set
			{
				_credentials = value;
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

		internal bool IsSetCredentials()
		{
			return _credentials != null;
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
