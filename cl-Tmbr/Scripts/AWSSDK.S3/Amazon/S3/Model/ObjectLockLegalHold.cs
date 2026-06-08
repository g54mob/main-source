namespace Amazon.S3.Model
{
	public class ObjectLockLegalHold
	{
		private ObjectLockLegalHoldStatus _status;

		public ObjectLockLegalHoldStatus Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
			}
		}

		internal bool IsSetStatus()
		{
			return _status != null;
		}
	}
}
