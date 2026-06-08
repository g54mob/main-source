using System;
using System.Net;
using System.Text;

namespace Amazon.Runtime
{
	public class AmazonUnmarshallingException : AmazonServiceException
	{
		public string LastKnownLocation { get; private set; }

		public string ResponseBody { get; private set; }

		public override string Message
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				AppendFormat(stringBuilder, "Request ID: {0}", base.RequestId);
				AppendFormat(stringBuilder, "Response Body: {0}", ResponseBody);
				AppendFormat(stringBuilder, "Last Parsed Path: {0}", LastKnownLocation);
				AppendFormat(stringBuilder, "HTTP Status Code: {0}", (int)base.StatusCode + " " + base.StatusCode);
				string text = stringBuilder.ToString();
				return base.Message + " " + text;
			}
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, Exception innerException)
			: base("Error unmarshalling response back from AWS.", innerException)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, Exception innerException)
			: base("Error unmarshalling response back from AWS.", innerException)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
			ResponseBody = responseBody;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, string message, Exception innerException)
			: base("Error unmarshalling response back from AWS. " + message, innerException)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
			ResponseBody = responseBody;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, Exception innerException, HttpStatusCode statusCode)
			: base("Error unmarshalling response back from AWS.", innerException, statusCode)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, Exception innerException, HttpStatusCode statusCode)
			: base("Error unmarshalling response back from AWS.", innerException, statusCode)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
			ResponseBody = responseBody;
		}

		private static void AppendFormat(StringBuilder sb, string format, string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (sb.Length > 0)
				{
					sb.Append(", ");
				}
				sb.AppendFormat(format, value);
			}
		}
	}
}
