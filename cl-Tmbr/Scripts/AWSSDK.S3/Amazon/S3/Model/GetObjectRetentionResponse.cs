using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectRetentionResponse : AmazonWebServiceResponse
	{
		private ObjectLockRetention _retention;

		public ObjectLockRetention Retention
		{
			get
			{
				return _retention;
			}
			set
			{
				_retention = value;
			}
		}

		internal bool IsSetRetention()
		{
			return _retention != null;
		}
	}
}
