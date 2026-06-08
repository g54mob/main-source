using System;

namespace Amazon.Runtime
{
	public class AmazonClientException : Exception
	{
		public AmazonClientException(string message)
			: base(message)
		{
		}

		public AmazonClientException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
