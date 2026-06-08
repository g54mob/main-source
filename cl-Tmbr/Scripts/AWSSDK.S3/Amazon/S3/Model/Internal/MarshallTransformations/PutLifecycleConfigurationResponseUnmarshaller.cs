using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutLifecycleConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutLifecycleConfigurationResponseUnmarshaller _instance;

		public static PutLifecycleConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutLifecycleConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutLifecycleConfigurationResponse putLifecycleConfigurationResponse = new PutLifecycleConfigurationResponse();
			if (context.ResponseData.IsHeaderPresent("x-amz-transition-default-minimum-object-size"))
			{
				putLifecycleConfigurationResponse.TransitionDefaultMinimumObjectSize = context.ResponseData.GetHeaderValue("x-amz-transition-default-minimum-object-size");
			}
			return putLifecycleConfigurationResponse;
		}
	}
}
