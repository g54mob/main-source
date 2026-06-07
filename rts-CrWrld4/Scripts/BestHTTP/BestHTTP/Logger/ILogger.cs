using System;

namespace BestHTTP.Logger
{
	public interface ILogger
	{
		Loglevels Level { get; set; }

		ILogOutput Output { get; set; }

		void Verbose(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null);

		void Information(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null);

		void Warning(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null);

		void Error(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null);

		void Exception(string division, string msg, Exception ex, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null);
	}
}
