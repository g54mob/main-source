using System;
using Coherence.Log;

namespace Coherence.Cloud
{
	internal sealed class PlayerAccountOperationException : Exception
	{
		public PlayerAccountErrorType Type { get; }

		public Error Error { get; }

		internal PlayerAccountOperationException(PlayerAccountErrorType type, Error error, string message = "")
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
