namespace Amazon.S3.Model
{
	public class ReplicationTimeValue
	{
		private int? minutes;

		public int? Minutes
		{
			get
			{
				return minutes;
			}
			set
			{
				minutes = value;
			}
		}

		internal bool IsSetMinutes()
		{
			return minutes.HasValue;
		}
	}
}
