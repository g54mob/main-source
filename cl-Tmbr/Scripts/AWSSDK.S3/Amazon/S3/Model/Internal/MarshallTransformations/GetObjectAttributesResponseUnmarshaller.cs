using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectAttributesResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetObjectAttributesResponseUnmarshaller _instance = new GetObjectAttributesResponseUnmarshaller();

		public static GetObjectAttributesResponseUnmarshaller Instance => _instance;

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetObjectAttributesResponse getObjectAttributesResponse = new GetObjectAttributesResponse();
			UnmarshallResult(context, getObjectAttributesResponse);
			if (context.ResponseData.IsHeaderPresent("x-amz-delete-marker"))
			{
				getObjectAttributesResponse.DeleteMarker = S3Transforms.ToBool(context.ResponseData.GetHeaderValue("x-amz-delete-marker"));
			}
			if (context.ResponseData.IsHeaderPresent("Last-Modified"))
			{
				getObjectAttributesResponse.LastModified = S3Transforms.ToDateTime(context.ResponseData.GetHeaderValue("Last-Modified"));
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-request-charged"))
			{
				getObjectAttributesResponse.RequestCharged = context.ResponseData.GetHeaderValue("x-amz-request-charged");
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-version-id"))
			{
				getObjectAttributesResponse.VersionId = context.ResponseData.GetHeaderValue("x-amz-version-id");
			}
			return getObjectAttributesResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetObjectAttributesResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num++;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("Checksum", num))
					{
						ChecksumUnmarshaller instance = ChecksumUnmarshaller.Instance;
						response.Checksum = instance.Unmarshall(context);
					}
					else if (context.TestExpression("ETag", num))
					{
						StringUnmarshaller instance2 = StringUnmarshaller.Instance;
						response.ETag = instance2.Unmarshall(context);
					}
					else if (context.TestExpression("ObjectParts", num))
					{
						GetObjectAttributesPartsUnmarshaller instance3 = GetObjectAttributesPartsUnmarshaller.Instance;
						response.ObjectParts = instance3.Unmarshall(context);
					}
					else if (context.TestExpression("ObjectSize", num))
					{
						LongUnmarshaller instance4 = LongUnmarshaller.Instance;
						response.ObjectSize = instance4.Unmarshall(context);
					}
					else if (context.TestExpression("StorageClass", num))
					{
						StringUnmarshaller instance5 = StringUnmarshaller.Instance;
						response.StorageClass = instance5.Unmarshall(context);
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
