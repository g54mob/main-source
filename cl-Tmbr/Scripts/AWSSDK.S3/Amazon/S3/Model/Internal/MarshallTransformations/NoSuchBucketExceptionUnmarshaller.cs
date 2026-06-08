using System;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class NoSuchBucketExceptionUnmarshaller : IXmlErrorResponseUnmarshaller<NoSuchBucketException, XmlUnmarshallerContext>, IXmlUnmarshaller<NoSuchBucketException, XmlUnmarshallerContext>
	{
		private static NoSuchBucketExceptionUnmarshaller _instance = new NoSuchBucketExceptionUnmarshaller();

		public static NoSuchBucketExceptionUnmarshaller Instance => _instance;

		public NoSuchBucketException Unmarshall(XmlUnmarshallerContext context)
		{
			throw new NotImplementedException();
		}

		public NoSuchBucketException Unmarshall(XmlUnmarshallerContext context, ErrorResponse errorResponse)
		{
			string amazonId = null;
			string amazonCfId = null;
			if (errorResponse is S3ErrorResponse s3ErrorResponse)
			{
				amazonId = s3ErrorResponse.Id2;
				amazonCfId = s3ErrorResponse.AmzCfId;
			}
			NoSuchBucketException result = new NoSuchBucketException(errorResponse.Message, errorResponse.InnerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, errorResponse.StatusCode, amazonId, amazonCfId);
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
