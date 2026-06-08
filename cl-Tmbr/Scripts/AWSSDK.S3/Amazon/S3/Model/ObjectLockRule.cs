namespace Amazon.S3.Model
{
	public class ObjectLockRule
	{
		private DefaultRetention _defaultRetention;

		public DefaultRetention DefaultRetention
		{
			get
			{
				return _defaultRetention;
			}
			set
			{
				_defaultRetention = value;
			}
		}

		internal bool IsSetDefaultRetention()
		{
			return _defaultRetention != null;
		}
	}
}
