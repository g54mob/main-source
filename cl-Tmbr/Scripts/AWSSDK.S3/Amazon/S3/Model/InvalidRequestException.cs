using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class InvalidRequestException : AmazonS3Exception
	{
		public InvalidRequestException(string message)
			: base(message)
		{
		}

		public InvalidRequestException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public InvalidRequestException(Exception innerException)
			: base(innerException)
		{
		}

		public InvalidRequestException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public InvalidRequestException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}

		public InvalidRequestException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string amazonId2, string amazonCfId)
			: base(message, innerException, errorType, errorCode, requestId, statusCode, amazonId2, amazonCfId)
		{
		}
	}
}
