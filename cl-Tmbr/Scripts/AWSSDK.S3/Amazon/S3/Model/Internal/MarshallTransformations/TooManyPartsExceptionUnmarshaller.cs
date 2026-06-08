using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class TooManyPartsExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<TooManyPartsException, XmlUnmarshallerContext>, IXmlUnmarshaller<TooManyPartsException, XmlUnmarshallerContext>
	{
		private static TooManyPartsExceptionUnmarshaller _instance = new TooManyPartsExceptionUnmarshaller();

		public static TooManyPartsExceptionUnmarshaller Instance => _instance;

		public TooManyPartsException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public TooManyPartsException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			TooManyPartsException result = new TooManyPartsException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
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
