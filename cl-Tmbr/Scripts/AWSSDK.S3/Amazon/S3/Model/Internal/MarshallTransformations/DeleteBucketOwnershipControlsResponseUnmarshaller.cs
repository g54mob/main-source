using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketOwnershipControlsResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static DeleteBucketOwnershipControlsResponseUnmarshaller _instance;

		public static DeleteBucketOwnershipControlsResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketOwnershipControlsResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new DeleteBucketOwnershipControlsResponse();
		}
	}
}
