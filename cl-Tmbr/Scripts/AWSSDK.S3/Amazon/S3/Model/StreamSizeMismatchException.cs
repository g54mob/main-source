using System;
using System.Net;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class StreamSizeMismatchException : AmazonS3Exception
	{
		public long ExpectedSize { get; set; }

		public long ActualSize { get; set; }

		public StreamSizeMismatchException(string message)
			: base(message)
		{
		}

		public StreamSizeMismatchException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public StreamSizeMismatchException(string message, long expectedSize, long actualSize, string requestId, string amazonId2)
			: base(message)
		{
			ExpectedSize = expectedSize;
			ActualSize = actualSize;
			base.RequestId = requestId;
			base.AmazonId2 = amazonId2;
		}

		public StreamSizeMismatchException(string message, long expectedSize, long actualSize, string requestId, string amazonId2, string amazonCfId)
			: base(message)
		{
			ExpectedSize = expectedSize;
			ActualSize = actualSize;
			base.RequestId = requestId;
			base.AmazonId2 = amazonId2;
			base.AmazonCloudFrontId = amazonCfId;
		}

		public StreamSizeMismatchException(string message, Exception innerException, long expectedSize, long actualSize, string requestId, string amazonId2)
			: base(message, innerException)
		{
			ExpectedSize = expectedSize;
			ActualSize = actualSize;
			base.RequestId = requestId;
			base.AmazonId2 = amazonId2;
		}

		public StreamSizeMismatchException(Exception innerException)
			: base(innerException.Message, innerException)
		{
		}

		public StreamSizeMismatchException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, errorType, errorCode, requestId, statusCode)
		{
		}

		public StreamSizeMismatchException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message, innerException, errorType, errorCode, requestId, statusCode)
		{
		}

		public StreamSizeMismatchException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode, string amazonId2)
			: base(message, innerException, errorType, errorCode, requestId, statusCode, amazonId2)
		{
		}
	}
}
