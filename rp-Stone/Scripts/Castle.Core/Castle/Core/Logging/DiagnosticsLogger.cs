using System;
using System.Diagnostics;
using System.Globalization;

namespace Castle.Core.Logging
{
	[Serializable]
	public class DiagnosticsLogger : LevelFilteredLogger, IDisposable
	{
		[NonSerialized]
		private EventLog eventLog;

		public DiagnosticsLogger(string logName)
			: this(logName, "default")
		{
		}

		public DiagnosticsLogger(string logName, string source)
			: base(LoggerLevel.Trace)
		{
			if (!EventLog.SourceExists(source))
			{
				EventLog.CreateEventSource(source, logName);
			}
			eventLog = new EventLog(logName);
			eventLog.Source = source;
		}

		public DiagnosticsLogger(string logName, string machineName, string source)
		{
			if (!EventLog.SourceExists(source, machineName))
			{
				EventLog.CreateEventSource(new EventSourceCreationData(source, logName)
				{
					MachineName = machineName
				});
			}
			eventLog = new EventLog(logName, machineName, source);
		}

		public override ILogger CreateChildLogger(string loggerName)
		{
			return new DiagnosticsLogger(eventLog.Log, eventLog.MachineName, eventLog.Source);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && eventLog != null)
			{
				eventLog.Close();
				eventLog = null;
			}
		}

		protected override void Log(LoggerLevel loggerLevel, string loggerName, string message, Exception exception)
		{
			if (eventLog != null)
			{
				EventLogEntryType type = TranslateLevel(loggerLevel);
				string message2 = ((exception != null) ? string.Format(CultureInfo.CurrentCulture, "[{0}] '{1}' message: {2} exception: {3} {4} {5}", loggerLevel, loggerName, message, exception.GetType(), exception.Message, exception.StackTrace) : string.Format(CultureInfo.CurrentCulture, "[{0}] '{1}' message: {2}", new object[3] { loggerLevel, loggerName, message }));
				eventLog.WriteEntry(message2, type);
			}
		}

		~DiagnosticsLogger()
		{
			Dispose(disposing: false);
		}

		private static EventLogEntryType TranslateLevel(LoggerLevel level)
		{
			switch (level)
			{
			case LoggerLevel.Fatal:
			case LoggerLevel.Error:
				return EventLogEntryType.Error;
			case LoggerLevel.Warn:
				return EventLogEntryType.Warning;
			default:
				return EventLogEntryType.Information;
			}
		}
	}
}
