using System;

namespace Amazon.Runtime
{
	public class AmazonDateTimeUnmarshallingException : AmazonUnmarshallingException
	{
		public string InvalidDateTimeToken { get; private set; }

		public AmazonDateTimeUnmarshallingException(string requestId, string lastKnownLocation, string invalidDateTimeToken, Exception innerException)
			: base(requestId, lastKnownLocation, innerException)
		{
			InvalidDateTimeToken = invalidDateTimeToken;
		}

		public AmazonDateTimeUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, string invalidDateTimeToken, Exception innerException)
			: base(requestId, lastKnownLocation, responseBody, innerException)
		{
			InvalidDateTimeToken = invalidDateTimeToken;
		}

		public AmazonDateTimeUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, string invalidDateTimeToken, string message, Exception innerException)
			: base(requestId, lastKnownLocation, responseBody, message, innerException)
		{
			InvalidDateTimeToken = invalidDateTimeToken;
		}
	}
}
