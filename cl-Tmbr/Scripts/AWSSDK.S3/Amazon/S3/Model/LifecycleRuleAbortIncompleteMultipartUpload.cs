namespace Amazon.S3.Model
{
	public class LifecycleRuleAbortIncompleteMultipartUpload
	{
		private int? daysAfterInitiation;

		public int? DaysAfterInitiation
		{
			get
			{
				return daysAfterInitiation;
			}
			set
			{
				daysAfterInitiation = value;
			}
		}

		internal bool IsSetDaysAfterInitiation()
		{
			return daysAfterInitiation.HasValue;
		}
	}
}
