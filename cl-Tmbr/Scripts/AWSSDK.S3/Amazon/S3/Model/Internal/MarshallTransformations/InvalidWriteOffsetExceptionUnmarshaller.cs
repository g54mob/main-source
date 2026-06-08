using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class InvalidWriteOffsetExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<InvalidWriteOffsetException, XmlUnmarshallerContext>, IXmlUnmarshaller<InvalidWriteOffsetException, XmlUnmarshallerContext>
	{
		private static InvalidWriteOffsetExceptionUnmarshaller _instance = new InvalidWriteOffsetExceptionUnmarshaller();

		public static InvalidWriteOffsetExceptionUnmarshaller Instance => _instance;

		public InvalidWriteOffsetException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public InvalidWriteOffsetException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			InvalidWriteOffsetException result = new InvalidWriteOffsetException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
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
