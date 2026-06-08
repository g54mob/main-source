namespace Amazon.S3.Model
{
	public class LifecycleRuleNoncurrentVersionTransition
	{
		private int? _newerNoncurrentVersions;

		private int? noncurrentDays;

		private S3StorageClass storageClass;

		public int? NewerNoncurrentVersions
		{
			get
			{
				return _newerNoncurrentVersions;
			}
			set
			{
				_newerNoncurrentVersions = value;
			}
		}

		public int? NoncurrentDays
		{
			get
			{
				return noncurrentDays;
			}
			set
			{
				noncurrentDays = value;
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

		internal bool IsSetNewerNoncurrentVersions()
		{
			return _newerNoncurrentVersions.HasValue;
		}

		internal bool IsSetNoncurrentDays()
		{
			return noncurrentDays.HasValue;
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
		}
	}
}
