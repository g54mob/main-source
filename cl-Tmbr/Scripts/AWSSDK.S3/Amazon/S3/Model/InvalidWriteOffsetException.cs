using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class InvalidWriteOffsetException : AmazonS3Exception
	{
		public InvalidWriteOffsetException(string message)
			: base(message)
		{
		}

		public InvalidWriteOffsetException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public InvalidWriteOffsetException(Exception innerException)
			: base(innerException)
		{
		}

		public InvalidWriteOffsetException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public InvalidWriteOffsetException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}

		public InvalidWriteOffsetException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string amazonId2, string amazonCfId)
			: base(message, innerException, errorType, errorCode, requestId, statusCode, amazonId2, amazonCfId)
		{
		}
	}
}
