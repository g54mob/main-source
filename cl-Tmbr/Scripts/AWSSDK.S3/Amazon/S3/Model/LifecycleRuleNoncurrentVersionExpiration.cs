namespace Amazon.S3.Model
{
	public class LifecycleRuleNoncurrentVersionExpiration
	{
		private int? _newerNoncurrentVersions;

		private int? _noncurrentDays;

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
				return _noncurrentDays;
			}
			set
			{
				_noncurrentDays = value;
			}
		}

		internal bool IsSetNewerNoncurrentVersions()
		{
			return _newerNoncurrentVersions.HasValue;
		}

		internal bool IsSetNoncurrentDays()
		{
			return _noncurrentDays.HasValue;
		}
	}
}
