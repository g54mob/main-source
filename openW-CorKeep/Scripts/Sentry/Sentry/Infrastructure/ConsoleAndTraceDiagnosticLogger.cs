#define TRACE
using System;
using System.Diagnostics;

namespace Sentry.Infrastructure
{
	public class ConsoleAndTraceDiagnosticLogger : DiagnosticLogger
	{
		public ConsoleAndTraceDiagnosticLogger(SentryLevel minimalLevel)
			: base(minimalLevel)
		{
		}

		protected override void LogMessage(string message)
		{
			Console.WriteLine(message);
			Trace.WriteLine(message);
		}
	}
}
