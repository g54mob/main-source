using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class NoSuchBucketException : AmazonS3Exception
	{
		public NoSuchBucketException(string message)
			: base(message)
		{
		}

		public NoSuchBucketException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public NoSuchBucketException(Exception innerException)
			: base(innerException)
		{
		}

		public NoSuchBucketException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public NoSuchBucketException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}

		public NoSuchBucketException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string amazonId2, string amazonCfId)
			: base(message, innerException, errorType, errorCode, requestId, statusCode, amazonId2, amazonCfId)
		{
		}
	}
}
