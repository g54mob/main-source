namespace Amazon.S3.Model
{
	public class ServerSideEncryptionRule
	{
		private ServerSideEncryptionByDefault serverSideEncryptionByDefault;

		private bool? bucketKeyEnabled;

		public ServerSideEncryptionByDefault ServerSideEncryptionByDefault
		{
			get
			{
				return serverSideEncryptionByDefault;
			}
			set
			{
				serverSideEncryptionByDefault = value;
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

		internal bool IsSetServerSideEncryptionByDefault()
		{
			return serverSideEncryptionByDefault != null;
		}

		internal bool IsSetBucketKeyEnabled()
		{
			return bucketKeyEnabled.HasValue;
		}
	}
}
