using System;

namespace Amazon.Runtime
{
	public class FederatedAuthenticationCancelledException : Exception
	{
		public FederatedAuthenticationCancelledException(string msg)
			: base(msg)
		{
		}

		public FederatedAuthenticationCancelledException(string msg, Exception inner)
			: base(msg, inner)
		{
		}
	}
}
