using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class ServerSideEncryptionByDefault
	{
		private string serverSideEncryptionKeyManagementServiceKeyId;

		private ServerSideEncryptionMethod serverSideEncryptionAlgorithm;

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

		public ServerSideEncryptionMethod ServerSideEncryptionAlgorithm
		{
			get
			{
				return serverSideEncryptionAlgorithm;
			}
			set
			{
				serverSideEncryptionAlgorithm = value;
			}
		}

		internal bool IsSetServerSideEncryptionKeyManagementServiceKeyId()
		{
			return serverSideEncryptionKeyManagementServiceKeyId != null;
		}

		internal bool IsSetServerSideEncryptionAlgorithm()
		{
			return serverSideEncryptionAlgorithm != null;
		}
	}
}
