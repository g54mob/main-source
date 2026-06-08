using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class BucketAlreadyExistsException : AmazonS3Exception
	{
		public BucketAlreadyExistsException(string message)
			: base(message)
		{
		}

		public BucketAlreadyExistsException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public BucketAlreadyExistsException(Exception innerException)
			: base(innerException)
		{
		}

		public BucketAlreadyExistsException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public BucketAlreadyExistsException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}

		public BucketAlreadyExistsException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string amazonId2, string amazonCfId)
			: base(message, innerException, errorType, errorCode, requestId, statusCode, amazonId2, amazonCfId)
		{
		}
	}
}
