using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectLockConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutObjectLockConfigurationResponseUnmarshaller _instance;

		public static PutObjectLockConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectLockConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutObjectLockConfigurationResponse putObjectLockConfigurationResponse = new PutObjectLockConfigurationResponse();
			if (context.ResponseData.IsHeaderPresent("x-amz-request-charged"))
			{
				putObjectLockConfigurationResponse.RequestCharged = context.ResponseData.GetHeaderValue("x-amz-request-charged");
			}
			return putObjectLockConfigurationResponse;
		}
	}
}
