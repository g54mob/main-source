using System;
using System.IO;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutBucketResponseUnmarshaller _instance;

		public static PutBucketResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			PutBucketResponse putBucketResponse = new PutBucketResponse();
			UnmarshallResult(context, putBucketResponse);
			return putBucketResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, PutBucketResponse response)
		{
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("Location"))
			{
				response.Location = BucketLocationConstraint.FindValue(responseData.GetHeaderValue("Location"));
			}
		}

		public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
		{
			S3ErrorResponse s3ErrorResponse = S3ErrorResponseUnmarshaller.Instance.Unmarshall(context);
			s3ErrorResponse.InnerException = innerException;
			s3ErrorResponse.StatusCode = statusCode;
			using (MemoryStream responseStream = new MemoryStream(context.GetResponseBodyBytes()))
			{
				using XmlUnmarshallerContext context2 = new XmlUnmarshallerContext(responseStream, maintainResponseBody: false, null);
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("BucketAlreadyExists"))
				{
					return BucketAlreadyExistsExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("BucketAlreadyOwnedByYou"))
				{
					return BucketAlreadyOwnedByYouExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
			}
			return ConstructS3Exception(context, s3ErrorResponse, innerException, statusCode);
		}
	}
}
