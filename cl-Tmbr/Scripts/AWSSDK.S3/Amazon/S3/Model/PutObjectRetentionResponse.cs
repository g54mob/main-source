using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutObjectRetentionResponse : AmazonWebServiceResponse
	{
		private RequestCharged _requestCharged;

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

		internal bool IsSetRequestCharged()
		{
			return _requestCharged != null;
		}
	}
}
