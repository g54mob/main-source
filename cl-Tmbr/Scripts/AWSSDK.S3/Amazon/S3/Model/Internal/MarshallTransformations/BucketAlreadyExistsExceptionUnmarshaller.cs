using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class BucketAlreadyExistsExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<BucketAlreadyExistsException, XmlUnmarshallerContext>, IXmlUnmarshaller<BucketAlreadyExistsException, XmlUnmarshallerContext>
	{
		private static BucketAlreadyExistsExceptionUnmarshaller _instance = new BucketAlreadyExistsExceptionUnmarshaller();

		public static BucketAlreadyExistsExceptionUnmarshaller Instance => _instance;

		public BucketAlreadyExistsException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public BucketAlreadyExistsException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			BucketAlreadyExistsException result = new BucketAlreadyExistsException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
			while (context.Read())
			{
				if (!context.IsStartElement)
				{
					_ = context.IsAttribute;
				}
			}
			return result;
		}
	}
}
