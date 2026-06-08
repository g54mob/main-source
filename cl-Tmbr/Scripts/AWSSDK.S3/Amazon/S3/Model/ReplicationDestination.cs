namespace Amazon.S3.Model
{
	public class ReplicationDestination
	{
		private AccessControlTranslation accessControlTranslation;

		private string accountId;

		private string bucketArn;

		private EncryptionConfiguration encryptionConfiguration;

		private Metrics metrics;

		private ReplicationTime replicationTime;

		private S3StorageClass storageClass;

		public AccessControlTranslation AccessControlTranslation
		{
			get
			{
				return accessControlTranslation;
			}
			set
			{
				accessControlTranslation = value;
			}
		}

		public string AccountId
		{
			get
			{
				return accountId;
			}
			set
			{
				accountId = value;
			}
		}

		public string BucketArn
		{
			get
			{
				return bucketArn;
			}
			set
			{
				bucketArn = value;
			}
		}

		public EncryptionConfiguration EncryptionConfiguration
		{
			get
			{
				return encryptionConfiguration;
			}
			set
			{
				encryptionConfiguration = value;
			}
		}

		public Metrics Metrics
		{
			get
			{
				return metrics;
			}
			set
			{
				metrics = value;
			}
		}

		public ReplicationTime ReplicationTime
		{
			get
			{
				return replicationTime;
			}
			set
			{
				replicationTime = value;
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

		public bool IsSetAccessControlTranslation()
		{
			return accessControlTranslation != null;
		}

		public bool IsSetAccountId()
		{
			return !string.IsNullOrEmpty(accountId);
		}

		internal bool IsSetBucketArn()
		{
			return !string.IsNullOrEmpty(bucketArn);
		}

		public bool IsSetEncryptionConfiguration()
		{
			return encryptionConfiguration != null;
		}

		internal bool IsSetMetrics()
		{
			return metrics != null;
		}

		internal bool IsSetReplicationTime()
		{
			return replicationTime != null;
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
		}
	}
}
