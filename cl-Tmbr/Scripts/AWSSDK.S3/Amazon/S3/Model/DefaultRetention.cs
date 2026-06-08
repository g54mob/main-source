namespace Amazon.S3.Model
{
	public class DefaultRetention
	{
		private int? _days;

		private ObjectLockRetentionMode _mode;

		private int? _years;

		public int? Days
		{
			get
			{
				return _days;
			}
			set
			{
				_days = value;
			}
		}

		public ObjectLockRetentionMode Mode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
			}
		}

		public int? Years
		{
			get
			{
				return _years;
			}
			set
			{
				_years = value;
			}
		}

		internal bool IsSetDays()
		{
			return _days.HasValue;
		}

		internal bool IsSetMode()
		{
			return _mode != null;
		}

		internal bool IsSetYears()
		{
			return _years.HasValue;
		}
	}
}
