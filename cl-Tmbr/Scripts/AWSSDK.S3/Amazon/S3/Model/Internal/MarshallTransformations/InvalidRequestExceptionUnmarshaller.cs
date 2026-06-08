using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class InvalidRequestExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<InvalidRequestException, XmlUnmarshallerContext>, IXmlUnmarshaller<InvalidRequestException, XmlUnmarshallerContext>
	{
		private static InvalidRequestExceptionUnmarshaller _instance = new InvalidRequestExceptionUnmarshaller();

		public static InvalidRequestExceptionUnmarshaller Instance => _instance;

		public InvalidRequestException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public InvalidRequestException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			InvalidRequestException result = new InvalidRequestException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
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
