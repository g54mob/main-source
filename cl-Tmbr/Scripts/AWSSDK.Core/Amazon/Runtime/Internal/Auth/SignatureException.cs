using System;

namespace Amazon.Runtime.Internal.Auth
{
	public class SignatureException : Exception
	{
		public SignatureException(string message)
			: base(message)
		{
		}

		public SignatureException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
