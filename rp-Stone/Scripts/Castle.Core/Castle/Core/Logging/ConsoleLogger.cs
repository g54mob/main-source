using System;
using System.Globalization;

namespace Castle.Core.Logging
{
	[Serializable]
	public class ConsoleLogger : LevelFilteredLogger
	{
		public ConsoleLogger()
			: this(string.Empty, LoggerLevel.Debug)
		{
		}

		public ConsoleLogger(LoggerLevel logLevel)
			: this(string.Empty, logLevel)
		{
		}

		public ConsoleLogger(string name)
			: this(name, LoggerLevel.Debug)
		{
		}

		public ConsoleLogger(string name, LoggerLevel logLevel)
			: base(name, logLevel)
		{
		}

		protected override void Log(LoggerLevel loggerLevel, string loggerName, string message, Exception exception)
		{
			Console.Out.WriteLine("[{0}] '{1}' {2}", loggerLevel, loggerName, message);
			if (exception != null)
			{
				Console.Out.WriteLine("[{0}] '{1}' {2}: {3} {4}", loggerLevel, loggerName, exception.GetType().FullName, exception.Message, exception.StackTrace);
			}
		}

		public override ILogger CreateChildLogger(string loggerName)
		{
			if (loggerName == null)
			{
				throw new ArgumentNullException("loggerName", "To create a child logger you must supply a non null name");
			}
			return new ConsoleLogger(string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[2] { base.Name, loggerName }), base.Level);
		}
	}
}
