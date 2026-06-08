using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketAclResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutBucketAclResponseUnmarshaller _instance = new PutBucketAclResponseUnmarshaller();

		public static PutBucketAclResponseUnmarshaller Instance => _instance;

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new PutBucketAclResponse();
		}

		internal static PutBucketAclResponseUnmarshaller GetInstance()
		{
			return _instance;
		}
	}
}
