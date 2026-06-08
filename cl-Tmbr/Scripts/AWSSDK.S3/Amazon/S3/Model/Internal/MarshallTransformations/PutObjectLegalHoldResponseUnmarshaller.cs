using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectLegalHoldResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutObjectLegalHoldResponseUnmarshaller _instance;

		public static PutObjectLegalHoldResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectLegalHoldResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutObjectLegalHoldResponse putObjectLegalHoldResponse = new PutObjectLegalHoldResponse();
			if (context.ResponseData.IsHeaderPresent("x-amz-request-charged"))
			{
				putObjectLegalHoldResponse.RequestCharged = context.ResponseData.GetHeaderValue("x-amz-request-charged");
			}
			return putObjectLegalHoldResponse;
		}
	}
}
