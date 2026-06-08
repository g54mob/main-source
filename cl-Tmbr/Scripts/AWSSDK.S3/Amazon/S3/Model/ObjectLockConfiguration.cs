namespace Amazon.S3.Model
{
	public class ObjectLockConfiguration
	{
		private ObjectLockEnabled _objectLockEnabled;

		private ObjectLockRule _rule;

		public ObjectLockEnabled ObjectLockEnabled
		{
			get
			{
				return _objectLockEnabled;
			}
			set
			{
				_objectLockEnabled = value;
			}
		}

		public ObjectLockRule Rule
		{
			get
			{
				return _rule;
			}
			set
			{
				_rule = value;
			}
		}

		internal bool IsSetObjectLockEnabled()
		{
			return _objectLockEnabled != null;
		}

		internal bool IsSetRule()
		{
			return _rule != null;
		}
	}
}
