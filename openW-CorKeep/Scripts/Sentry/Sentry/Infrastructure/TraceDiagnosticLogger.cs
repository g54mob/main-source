#define TRACE
using System.Diagnostics;

namespace Sentry.Infrastructure
{
	public class TraceDiagnosticLogger : DiagnosticLogger
	{
		public TraceDiagnosticLogger(SentryLevel minimalLevel)
			: base(minimalLevel)
		{
		}

		protected override void LogMessage(string message)
		{
			Trace.WriteLine(message);
		}
	}
}
