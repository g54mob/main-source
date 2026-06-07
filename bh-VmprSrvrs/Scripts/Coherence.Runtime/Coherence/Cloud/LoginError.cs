using System;
using Coherence.Log;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	public sealed class LoginError : Exception
	{
		public ErrorType Type { get; }

		internal LoginErrorType LoginErrorType { get; }

		internal Error Error { get; }

		internal string ResponseBody { get; }

		internal LoginError(ErrorType errorType, LoginErrorType loginErrorType, Error error, string message = "", string responseBody = "")
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
