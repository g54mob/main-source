using System;

namespace Amazon.Runtime
{
	public class FederatedAuthenticationFailureException : Exception
	{
		public FederatedAuthenticationFailureException(string msg)
			: base(msg)
		{
		}

		public FederatedAuthenticationFailureException(string msg, Exception inner)
			: base(msg, inner)
		{
		}
	}
}
