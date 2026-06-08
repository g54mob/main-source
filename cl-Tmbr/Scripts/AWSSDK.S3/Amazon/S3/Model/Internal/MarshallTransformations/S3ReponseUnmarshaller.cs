using System;
using System.IO;
using System.Net;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public abstract class S3ReponseUnmarshaller : XmlResponseUnmarshaller
	{
		public override UnmarshallerContext CreateContext(IWebResponseData response, bool readEntireResponse, Stream stream, RequestMetrics metrics, bool isException)
		{
			return CreateContext(response, readEntireResponse, stream, metrics, isException, null);
		}

		public override UnmarshallerContext CreateContext(IWebResponseData response, bool readEntireResponse, Stream stream, RequestMetrics metrics, bool isException, IRequestContext context)
		{
			if (response.IsHeaderPresent("x-amz-id-2"))
			{
				metrics.AddProperty(Metric.AmzId2, response.GetHeaderValue("x-amz-id-2"));
			}
			if (response.IsHeaderPresent("X-Amz-Cf-Id"))
			{
				metrics.AddProperty(Metric.AmzCfId, response.GetHeaderValue("X-Amz-Cf-Id"));
			}
			return base.CreateContext(response, readEntireResponse, stream, metrics, isException, context);
		}

		public override AmazonWebServiceResponse Unmarshall(UnmarshallerContext input)
		{
			AmazonWebServiceResponse amazonWebServiceResponse = base.Unmarshall(input);
			if (amazonWebServiceResponse.ResponseMetadata == null)
			{
				amazonWebServiceResponse.ResponseMetadata = new ResponseMetadata();
			}
			amazonWebServiceResponse.ResponseMetadata.Metadata.Add("x-amz-id-2", input.ResponseData.GetHeaderValue("x-amz-id-2"));
			if (input.ResponseData.IsHeaderPresent("X-Amz-Cf-Id"))
			{
				amazonWebServiceResponse.ResponseMetadata.Metadata.Add("X-Amz-Cf-Id", input.ResponseData.GetHeaderValue("X-Amz-Cf-Id"));
			}
			return amazonWebServiceResponse;
		}

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException)
		{
			return new S3UnmarshallerContext(responseStream, maintainResponseBody, response, isException);
		}

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException, IRequestContext requestContext)
		{
			return new S3UnmarshallerContext(responseStream, maintainResponseBody, response, isException, requestContext);
		}

		public override AmazonServiceException UnmarshallException(XmlUnmarshallerContext context, Exception innerException, HttpStatusCode statusCode)
		{
			S3ErrorResponse errorResponse = S3ErrorResponseUnmarshaller.Instance.Unmarshall(context);
			return ConstructS3Exception(context, errorResponse, innerException, statusCode);
		}

		private protected AmazonS3Exception ConstructS3Exception(XmlUnmarshallerContext context, S3ErrorResponse errorResponse, Exception innerException, HttpStatusCode statusCode)
		{
			AmazonS3Exception ex = new AmazonS3Exception(errorResponse.Message, innerException, errorResponse.Type, errorResponse.Code, errorResponse.RequestId, statusCode, errorResponse.Id2, errorResponse.AmzCfId);
			ex.Region = errorResponse.Region;
			if (errorResponse.ParsingException != null)
			{
				string responseBody = context.ResponseBody;
				if (!string.IsNullOrEmpty(responseBody))
				{
					ex.ResponseBody = responseBody;
				}
			}
			return ex;
		}
	}
}
