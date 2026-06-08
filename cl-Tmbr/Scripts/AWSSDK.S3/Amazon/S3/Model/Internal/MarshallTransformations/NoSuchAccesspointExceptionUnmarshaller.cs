using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class NoSuchAccesspointExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<NoSuchAccesspointException, XmlUnmarshallerContext>, IXmlUnmarshaller<NoSuchAccesspointException, XmlUnmarshallerContext>
	{
		private static NoSuchAccesspointExceptionUnmarshaller _instance = new NoSuchAccesspointExceptionUnmarshaller();

		public static NoSuchAccesspointExceptionUnmarshaller Instance => _instance;

		public NoSuchAccesspointException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public NoSuchAccesspointException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			NoSuchAccesspointException result = new NoSuchAccesspointException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode);
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
