using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectLockConfigurationResponse : AmazonWebServiceResponse
	{
		private ObjectLockConfiguration _objectLockConfiguration;

		public ObjectLockConfiguration ObjectLockConfiguration
		{
			get
			{
				return _objectLockConfiguration;
			}
			set
			{
				_objectLockConfiguration = value;
			}
		}

		internal bool IsSetObjectLockConfiguration()
		{
			return _objectLockConfiguration != null;
		}
	}
}
