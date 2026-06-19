using System;

namespace Sentry.Extensibility
{
	public interface ISentryStackTraceFactory
	{
		SentryStackTrace? Create(Exception? exception = null);
	}
}
