using System;
using System.Globalization;
using System.IO;
using System.Net;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public abstract class ResponseUnmarshaller : IResponseUnmarshaller<AmazonWebServiceResponse, UnmarshallerContext>
	{
		public virtual bool HasStreamingProperty => false;

		public virtual UnmarshallerContext CreateContext(IWebResponseData response, bool readEntireResponse, Stream stream, RequestMetrics metrics, bool isException)
		{
			return CreateContext(response, readEntireResponse, stream, metrics, isException, null);
		}

		public virtual UnmarshallerContext CreateContext(IWebResponseData response, bool readEntireResponse, Stream stream, RequestMetrics metrics, bool isException, IRequestContext requestContext)
		{
			if (response == null)
			{
				throw new AmazonServiceException("The Web Response for a successful request is null!");
			}
			if (requestContext == null || requestContext.OriginalRequest?.CoreChecksumMode != CoreChecksumResponseBehavior.DISABLED)
			{
				return ConstructUnmarshallerContext(stream, ShouldReadEntireResponse(response, readEntireResponse), response, isException, requestContext);
			}
			return ConstructUnmarshallerContext(stream, ShouldReadEntireResponse(response, readEntireResponse), response, isException);
		}

		public virtual AmazonServiceException UnmarshallException(UnmarshallerContext input, Exception innerException, HttpStatusCode statusCode)
		{
			throw new NotImplementedException();
		}

		public AmazonWebServiceResponse UnmarshallResponse(UnmarshallerContext context)
		{
			AmazonWebServiceResponse amazonWebServiceResponse = Unmarshall(context);
			amazonWebServiceResponse.ContentLength = context.ResponseData.ContentLength;
			amazonWebServiceResponse.HttpStatusCode = context.ResponseData.StatusCode;
			return amazonWebServiceResponse;
		}

		public abstract AmazonWebServiceResponse Unmarshall(UnmarshallerContext input);

		public static string GetDefaultErrorMessage<T>() where T : Exception
		{
			return string.Format(CultureInfo.InvariantCulture, "An exception of type {0}, please check the error log for mode details.", typeof(T).Name);
		}

		protected abstract UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException);

		protected abstract UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException, IRequestContext requestContext);

		protected virtual bool ShouldReadEntireResponse(IWebResponseData response, bool readEntireResponse)
		{
			return readEntireResponse;
		}
	}
}
