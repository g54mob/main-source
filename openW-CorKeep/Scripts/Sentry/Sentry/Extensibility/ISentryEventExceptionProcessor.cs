using System;

namespace Sentry.Extensibility
{
	public interface ISentryEventExceptionProcessor
	{
		void Process(Exception exception, SentryEvent sentryEvent);
	}
}
