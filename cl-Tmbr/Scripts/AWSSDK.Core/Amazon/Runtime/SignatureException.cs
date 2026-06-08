using System;
using Amazon.Runtime.Internal.Auth;

namespace Amazon.Runtime
{
	public class SignatureException : Amazon.Runtime.Internal.Auth.SignatureException
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
