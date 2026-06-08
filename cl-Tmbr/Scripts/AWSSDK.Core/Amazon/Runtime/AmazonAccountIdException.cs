using System;

namespace Amazon.Runtime
{
	public class AmazonAccountIdException : AmazonClientException
	{
		public AmazonAccountIdException()
			: base("AccountId is invalid. The AccountId length should be 12 and only contain numeric characters with no spaces or periods.")
		{
		}

		public AmazonAccountIdException(string message)
			: base(message)
		{
		}

		public AmazonAccountIdException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
