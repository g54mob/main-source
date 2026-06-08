using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketAccelerateConfigurationResponse : AmazonWebServiceResponse
	{
		private RequestCharged _requestCharged;

		private BucketAccelerateStatus _status;

		public RequestCharged RequestCharged
		{
			get
			{
				return _requestCharged;
			}
			set
			{
				_requestCharged = value;
			}
		}

		public BucketAccelerateStatus Status
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

		internal bool IsSetRequestCharged()
		{
			return _requestCharged != null;
		}

		internal bool IsSetStatus()
		{
			return _status != null;
		}
	}
}
