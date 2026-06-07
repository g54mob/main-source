using Coherence.Common;
using Coherence.Log;

namespace Coherence.Cloud
{
	public sealed class PlayerAccountOperationError : CoherenceError<PlayerAccountErrorType>
	{
		internal PlayerAccountOperationError(PlayerAccountErrorType errorType, Error error, string message, bool hasBeenObserved = false)
		{
		}

		internal PlayerAccountOperationError(PlayerAccountOperationException exception, bool hasBeenObserved = false)
		{
		}
	}
}
