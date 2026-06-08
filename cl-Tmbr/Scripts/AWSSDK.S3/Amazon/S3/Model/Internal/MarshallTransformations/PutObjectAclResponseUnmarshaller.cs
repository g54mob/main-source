using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectAclResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutObjectAclResponseUnmarshaller _instance = new PutObjectAclResponseUnmarshaller();

		public static PutObjectAclResponseUnmarshaller Instance => _instance;

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutObjectAclResponse putObjectAclResponse = new PutObjectAclResponse();
			if (context.ResponseData.IsHeaderPresent("x-amz-request-charged"))
			{
				putObjectAclResponse.RequestCharged = context.ResponseData.GetHeaderValue("x-amz-request-charged");
			}
			return putObjectAclResponse;
		}
	}
}
