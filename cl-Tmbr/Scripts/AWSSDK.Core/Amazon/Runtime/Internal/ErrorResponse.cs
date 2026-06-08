using System;
using System.Net;

namespace Amazon.Runtime.Internal
{
	public class ErrorResponse
	{
		public ErrorType Type { get; set; }

		public string Code { get; set; }

		public string Message { get; set; }

		public string RequestId { get; set; }

		public Exception InnerException { get; set; }

		public HttpStatusCode StatusCode { get; set; }
	}
}
