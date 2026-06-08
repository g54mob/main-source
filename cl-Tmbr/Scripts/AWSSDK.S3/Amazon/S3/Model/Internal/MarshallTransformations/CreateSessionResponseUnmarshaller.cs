using System;
using System.IO;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CreateSessionResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static CreateSessionResponseUnmarshaller _instance = new CreateSessionResponseUnmarshaller();

		public static CreateSessionResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CreateSessionResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			CreateSessionResponse createSessionResponse = new CreateSessionResponse();
			UnmarshallResult(context, createSessionResponse);
			return createSessionResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, CreateSessionResponse response)
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
					if (context.TestExpression("Credentials", num))
					{
						SessionCredentialsUnmarshaller instance = SessionCredentialsUnmarshaller.Instance;
						response.Credentials = instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return;
				}
			}
			IWebResponseData responseData = context.ResponseData;
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption"))
			{
				response.ServerSideEncryption = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-aws-kms-key-id"))
			{
				response.SSEKMSKeyId = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-aws-kms-key-id"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-context"))
			{
				response.SSEKMSEncryptionContext = S3Transforms.ToString(responseData.GetHeaderValue("x-amz-server-side-encryption-context"));
			}
			if (responseData.IsHeaderPresent("x-amz-server-side-encryption-bucket-key-enabled"))
			{
				response.BucketKeyEnabled = S3Transforms.ToBool(responseData.GetHeaderValue("x-amz-server-side-encryption-bucket-key-enabled"));
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
				if (s3ErrorResponse.Code != null && s3ErrorResponse.Code.Equals("NoSuchBucket"))
				{
					return NoSuchBucketExceptionUnmarshaller.Instance.Unmarshall(context2, s3ErrorResponse);
				}
			}
			return ConstructS3Exception(context, s3ErrorResponse, innerException, statusCode);
		}

		internal static CreateSessionResponseUnmarshaller GetInstance()
		{
			return _instance;
		}
	}
}
