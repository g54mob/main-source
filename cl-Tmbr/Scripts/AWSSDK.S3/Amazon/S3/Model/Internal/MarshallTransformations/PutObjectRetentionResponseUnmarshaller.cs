using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectRetentionResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutObjectRetentionResponseUnmarshaller _instance;

		public static PutObjectRetentionResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectRetentionResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutObjectRetentionResponse putObjectRetentionResponse = new PutObjectRetentionResponse();
			if (context.ResponseData.IsHeaderPresent("x-amz-request-charged"))
			{
				putObjectRetentionResponse.RequestCharged = context.ResponseData.GetHeaderValue("x-amz-request-charged");
			}
			return putObjectRetentionResponse;
		}
	}
}
