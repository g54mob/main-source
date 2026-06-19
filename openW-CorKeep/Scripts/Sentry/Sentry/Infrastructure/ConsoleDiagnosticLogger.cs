using System;

namespace Sentry.Infrastructure
{
	public class ConsoleDiagnosticLogger : DiagnosticLogger
	{
		public ConsoleDiagnosticLogger(SentryLevel minimalLevel)
			: base(minimalLevel)
		{
		}

		protected override void LogMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}
