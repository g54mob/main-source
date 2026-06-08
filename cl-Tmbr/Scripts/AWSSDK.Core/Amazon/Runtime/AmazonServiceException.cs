using System;
using System.Globalization;
using System.Net;

namespace Amazon.Runtime
{
	public class AmazonServiceException : Exception
	{
		private ErrorType errorType;

		private string errorCode;

		private string requestId;

		private HttpStatusCode statusCode;

		public ErrorType ErrorType
		{
			get
			{
				return errorType;
			}
			set
			{
				errorType = value;
			}
		}

		public string ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				errorCode = value;
			}
		}

		public string RequestId
		{
			get
			{
				return requestId;
			}
			set
			{
				requestId = value;
			}
		}

		public HttpStatusCode StatusCode
		{
			get
			{
				return statusCode;
			}
			set
			{
				statusCode = value;
			}
		}

		public virtual RetryableDetails Retryable => null;

		public AmazonServiceException()
		{
		}

		public AmazonServiceException(string message)
			: base(message)
		{
		}

		public AmazonServiceException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public AmazonServiceException(string message, Exception innerException, HttpStatusCode statusCode)
			: base(message, innerException)
		{
			this.statusCode = statusCode;
		}

		public AmazonServiceException(Exception innerException)
			: base(innerException.Message, innerException)
		{
		}

		public AmazonServiceException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message ?? BuildGenericErrorMessage(errorCode, statusCode))
		{
			this.errorCode = errorCode;
			this.errorType = errorType;
			this.requestId = requestId;
			this.statusCode = statusCode;
		}

		public AmazonServiceException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message ?? BuildGenericErrorMessage(errorCode, statusCode), innerException)
		{
			this.errorCode = errorCode;
			this.errorType = errorType;
			this.requestId = requestId;
			this.statusCode = statusCode;
		}

		private static string BuildGenericErrorMessage(string errorCode, HttpStatusCode statusCode)
		{
			return string.Format(CultureInfo.InvariantCulture, "Error making request with Error Code {0} and Http Status Code {1}. No further error information was returned by the service.", errorCode, statusCode);
		}
	}
}
