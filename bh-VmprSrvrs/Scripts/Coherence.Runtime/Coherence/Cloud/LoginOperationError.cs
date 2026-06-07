using Coherence.Common;
using Coherence.Log;

namespace Coherence.Cloud
{
	public sealed class LoginOperationError : CoherenceError<LoginErrorType>
	{
		internal LoginOperationError(LoginErrorType type, Error error = Error.UnobservedError, bool hasBeenObserved = false)
		{
		}

		internal LoginOperationError(LoginErrorType type, string message, Error error = Error.UnobservedError, bool hasBeenObserved = false)
		{
		}
	}
}
