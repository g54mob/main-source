using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketPolicyStatusResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetBucketPolicyStatusResponseUnmarshaller _instance;

		public static GetBucketPolicyStatusResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketPolicyStatusResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetBucketPolicyStatusResponse getBucketPolicyStatusResponse = new GetBucketPolicyStatusResponse();
			UnmarshallResult(context, getBucketPolicyStatusResponse);
			return getBucketPolicyStatusResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetBucketPolicyStatusResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("PolicyStatus", startingStackDepth))
					{
						response.PolicyStatus = PolicyStatusUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					break;
				}
			}
		}
	}
}
