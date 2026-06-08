using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class BucketAlreadyOwnedByYouExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<BucketAlreadyOwnedByYouException, XmlUnmarshallerContext>, IXmlUnmarshaller<BucketAlreadyOwnedByYouException, XmlUnmarshallerContext>
	{
		private static BucketAlreadyOwnedByYouExceptionUnmarshaller _instance = new BucketAlreadyOwnedByYouExceptionUnmarshaller();

		public static BucketAlreadyOwnedByYouExceptionUnmarshaller Instance => _instance;

		public BucketAlreadyOwnedByYouException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public BucketAlreadyOwnedByYouException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			BucketAlreadyOwnedByYouException result = new BucketAlreadyOwnedByYouException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
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
