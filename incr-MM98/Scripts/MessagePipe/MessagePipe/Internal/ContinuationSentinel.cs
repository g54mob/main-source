using System;

namespace MessagePipe.Internal
{
	internal static class ContinuationSentinel
	{
		public static readonly Action AvailableContinuation = delegate
		{
		};

		public static readonly Action CompletedContinuation = delegate
		{
		};
	}
}
