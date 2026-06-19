using System;

namespace Sentry.Extensibility
{
	public abstract class SentryEventExceptionProcessor<TException> : ISentryEventExceptionProcessor where TException : Exception
	{
		public void Process(Exception? exception, SentryEvent sentryEvent)
		{
			if (exception is TException exception2)
			{
				ProcessException(exception2, sentryEvent);
			}
		}

		protected internal abstract void ProcessException(TException exception, SentryEvent sentryEvent);
	}
}
