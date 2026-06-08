using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class SelectObjectContentResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static SelectObjectContentResponseUnmarshaller _instance;

		public static SelectObjectContentResponseUnmarshaller Instance => _instance ?? (_instance = new SelectObjectContentResponseUnmarshaller());

		public override bool HasStreamingProperty => true;

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			SelectObjectContentResponse selectObjectContentResponse = new SelectObjectContentResponse();
			UnmarshallResult(context, selectObjectContentResponse);
			return selectObjectContentResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, SelectObjectContentResponse response)
		{
			response.Payload = new SelectObjectContentEventStream(context.Stream);
		}

		protected override bool ShouldReadEntireResponse(IWebResponseData response, bool readEntireResponse)
		{
			return false;
		}
	}
}
