using System;

namespace Amazon.Runtime
{
	public class AWSCommonRuntimeException : AmazonClientException
	{
		public AWSCommonRuntimeException(string message)
			: base(message)
		{
		}

		public AWSCommonRuntimeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
