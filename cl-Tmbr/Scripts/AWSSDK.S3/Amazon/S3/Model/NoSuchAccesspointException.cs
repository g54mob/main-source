using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class NoSuchAccesspointException : AmazonS3Exception
	{
		public NoSuchAccesspointException(string message)
			: base(message)
		{
		}

		public NoSuchAccesspointException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public NoSuchAccesspointException(Exception innerException)
			: base(innerException)
		{
		}

		public NoSuchAccesspointException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public NoSuchAccesspointException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}
	}
}
