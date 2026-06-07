using System;
using System.ComponentModel;
using System.Reflection;

namespace NGenerics.Threading
{
	public class AsyncCompletedEventArgs<TState> : EventArgs
	{
		[Description("Async_AsyncEventArgs_Cancelled")]
		public bool Cancelled { get; private set; }

		[Description("Async_AsyncEventArgs_Error")]
		public Exception Error { get; private set; }

		[Description("Async_AsyncEventArgs_UserState")]
		public virtual TState UserState { get; private set; }

		public AsyncCompletedEventArgs(Exception error, bool cancelled, TState userState)
		{
			Error = error;
			Cancelled = cancelled;
			UserState = userState;
		}

		protected void RaiseExceptionIfNecessary()
		{
			if (Error != null)
			{
				throw new TargetInvocationException("Async_ExceptionOccurred", Error);
			}
			if (Cancelled)
			{
				throw new InvalidOperationException("Async_OperationCancelled");
			}
		}
	}
}
