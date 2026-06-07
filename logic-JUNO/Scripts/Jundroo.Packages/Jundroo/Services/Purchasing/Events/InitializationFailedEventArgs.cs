using System;

namespace Jundroo.Services.Purchasing.Events
{
	public class InitializationFailedEventArgs : EventArgs
	{
		public InitializationFailureReason FailureReason { get; }

		public string Message { get; }

		public InitializationFailedEventArgs(InitializationFailureReason failureReason, string message)
		{
			FailureReason = failureReason;
			Message = message;
		}
	}
}
