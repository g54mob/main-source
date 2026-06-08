using System;

namespace Amazon.S3.Model
{
	public class ObjectLockRetention
	{
		private ObjectLockRetentionMode _mode;

		private DateTime? _retainUntilDate;

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

		public DateTime? RetainUntilDate
		{
			get
			{
				return _retainUntilDate;
			}
			set
			{
				_retainUntilDate = value;
			}
		}

		internal bool IsSetMode()
		{
			return _mode != null;
		}

		internal bool IsSetRetainUntilDate()
		{
			return _retainUntilDate.HasValue;
		}
	}
}
