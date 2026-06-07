using System;

namespace BestHTTP.Logger
{
	public class DefaultLogger : ILogger
	{
		private ILogOutput _output;

		public Loglevels Level { get; set; }

		public ILogOutput Output
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string FormatVerbose { get; set; }

		public string FormatInfo { get; set; }

		public string FormatWarn { get; set; }

		public string FormatErr { get; set; }

		public string FormatEx { get; set; }

		public void Verbose(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Information(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Warning(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Error(string division, string msg, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		public void Exception(string division, string msg, Exception ex, LoggingContext context1 = null, LoggingContext context2 = null, LoggingContext context3 = null)
		{
		}

		private string GetFormattedTime()
		{
			return null;
		}
	}
}
