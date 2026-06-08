using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketMetadataTableConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetBucketMetadataTableConfigurationResponseUnmarshaller _instance;

		public static GetBucketMetadataTableConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketMetadataTableConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetBucketMetadataTableConfigurationResponse getBucketMetadataTableConfigurationResponse = new GetBucketMetadataTableConfigurationResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, getBucketMetadataTableConfigurationResponse);
				}
			}
			return getBucketMetadataTableConfigurationResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetBucketMetadataTableConfigurationResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			response.GetBucketMetadataTableConfigurationResult = new GetBucketMetadataTableConfigurationResult();
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("MetadataTableConfigurationResult", num))
					{
						response.GetBucketMetadataTableConfigurationResult.MetadataTableConfigurationResult = MetadataTableConfigurationResultUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("Status", num))
					{
						response.GetBucketMetadataTableConfigurationResult.Status = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Error", num))
					{
						response.GetBucketMetadataTableConfigurationResult.Error = ErrorUnmarshaller.Instance.Unmarshall(context);
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
