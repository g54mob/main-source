using System;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace Sentry.Internal
{
	internal class ExceptionHandlingSynchronizationContext : SynchronizationContext
	{
		public ExceptionHandlingSynchronizationContext(Action<Exception> exceptionHandler, SynchronizationContext? innerContext)
		{
			_003CexceptionHandler_003EP = exceptionHandler;
			_003CinnerContext_003EP = innerContext;
			base._002Ector();
		}

		public override void Post(SendOrPostCallback d, object? state)
		{
			if (state is ExceptionDispatchInfo exceptionDispatchInfo)
			{
				_003CexceptionHandler_003EP(exceptionDispatchInfo.SourceException);
			}
			else if (_003CinnerContext_003EP != null)
			{
				_003CinnerContext_003EP.Post(d, state);
			}
			else
			{
				base.Post(d, state);
			}
		}
	}
}
