using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class EncryptionTypeMismatchExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<EncryptionTypeMismatchException, XmlUnmarshallerContext>, IXmlUnmarshaller<EncryptionTypeMismatchException, XmlUnmarshallerContext>
	{
		private static EncryptionTypeMismatchExceptionUnmarshaller _instance = new EncryptionTypeMismatchExceptionUnmarshaller();

		public static EncryptionTypeMismatchExceptionUnmarshaller Instance => _instance;

		public EncryptionTypeMismatchException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public EncryptionTypeMismatchException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			EncryptionTypeMismatchException result = new EncryptionTypeMismatchException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
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
