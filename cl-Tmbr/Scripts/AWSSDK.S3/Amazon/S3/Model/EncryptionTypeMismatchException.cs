using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class EncryptionTypeMismatchException : AmazonS3Exception
	{
		public EncryptionTypeMismatchException(string message)
			: base(message)
		{
		}

		public EncryptionTypeMismatchException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public EncryptionTypeMismatchException(Exception innerException)
			: base(innerException)
		{
		}

		public EncryptionTypeMismatchException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public EncryptionTypeMismatchException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}

		public EncryptionTypeMismatchException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string amazonId2, string amazonCfId)
			: base(message, innerException, errorType, errorCode, requestId, statusCode, amazonId2, amazonCfId)
		{
		}
	}
}
