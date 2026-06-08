using System;

namespace Amazon.S3.Model
{
	public class RestoreStatus
	{
		private bool? _isRestoreInProgress;

		private DateTime? _restoreExpiryDate;

		public bool? IsRestoreInProgress
		{
			get
			{
				return _isRestoreInProgress;
			}
			set
			{
				_isRestoreInProgress = value;
			}
		}

		public DateTime? RestoreExpiryDate
		{
			get
			{
				return _restoreExpiryDate;
			}
			set
			{
				_restoreExpiryDate = value;
			}
		}

		internal bool IsSetIsRestoreInProgress()
		{
			return _isRestoreInProgress.HasValue;
		}

		internal bool IsSetRestoreExpiryDate()
		{
			return _restoreExpiryDate.HasValue;
		}
	}
}
