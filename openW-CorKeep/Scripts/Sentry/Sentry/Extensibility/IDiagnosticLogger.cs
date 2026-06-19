using System;

namespace Sentry.Extensibility
{
	public interface IDiagnosticLogger
	{
		bool IsEnabled(SentryLevel level);

		void Log(SentryLevel logLevel, string message, Exception? exception = null, params object?[] args);
	}
}
