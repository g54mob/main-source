using System;

namespace Amazon.Runtime
{
	public class ProcessAWSCredentialException : Exception
	{
		public ProcessAWSCredentialException(string message)
			: base(message)
		{
		}

		public ProcessAWSCredentialException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
