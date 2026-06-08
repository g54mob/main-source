namespace Amazon.S3.Model
{
	public class Metrics
	{
		private MetricsStatus status;

		private ReplicationTimeValue eventThreshold;

		public MetricsStatus Status
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

		public ReplicationTimeValue EventThreshold
		{
			get
			{
				return eventThreshold;
			}
			set
			{
				eventThreshold = value;
			}
		}

		internal bool IsSetStatus()
		{
			return status != null;
		}

		internal bool IsSetEventThreshold()
		{
			return eventThreshold != null;
		}
	}
}
