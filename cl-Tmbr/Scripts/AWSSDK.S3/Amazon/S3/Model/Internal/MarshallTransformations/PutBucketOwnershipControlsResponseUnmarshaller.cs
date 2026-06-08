using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketOwnershipControlsResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutBucketOwnershipControlsResponseUnmarshaller _instance;

		public static PutBucketOwnershipControlsResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketOwnershipControlsResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new PutBucketOwnershipControlsResponse();
		}
	}
}
