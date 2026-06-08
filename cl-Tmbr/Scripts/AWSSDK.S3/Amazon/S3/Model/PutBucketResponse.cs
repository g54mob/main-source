using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketResponse : AmazonWebServiceResponse
	{
		private string _location;

		public string Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		internal bool IsSetLocation()
		{
			return _location != null;
		}
	}
}
