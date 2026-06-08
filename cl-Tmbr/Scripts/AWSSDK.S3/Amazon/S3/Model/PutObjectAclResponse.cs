using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutObjectAclResponse : AmazonWebServiceResponse
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
			return !string.IsNullOrEmpty(_requestCharged);
		}
	}
}
