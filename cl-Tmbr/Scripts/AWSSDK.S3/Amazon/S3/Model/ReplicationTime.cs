namespace Amazon.S3.Model
{
	public class ReplicationTime
	{
		private ReplicationTimeStatus status;

		private ReplicationTimeValue time;

		public ReplicationTimeStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		public ReplicationTimeValue Time
		{
			get
			{
				return time;
			}
			set
			{
				time = value;
			}
		}

		internal bool IsSetStatus()
		{
			return status != null;
		}

		internal bool IsSetTime()
		{
			return time != null;
		}
	}
}
