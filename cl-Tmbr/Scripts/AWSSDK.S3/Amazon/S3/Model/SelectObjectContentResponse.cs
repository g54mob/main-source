using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class SelectObjectContentResponse : AmazonWebServiceResponse
	{
		public ISelectObjectContentEventStream Payload { get; set; }

		internal bool IsSetPayload()
		{
			return Payload != null;
		}
	}
}
