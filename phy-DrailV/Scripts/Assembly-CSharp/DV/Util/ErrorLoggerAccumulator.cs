using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Util
{
	public class ErrorLoggerAccumulator
	{
		public struct LogEntry
		{
			public LogType type;

			public string message;

			public UnityEngine.Object context;

			public Exception exception;

			public static LogEntry Error(string message, UnityEngine.Object context = null)
			{
				return new LogEntry
				{
					type = LogType.Error,
					message = message,
					context = context
				};
			}

			public static LogEntry Warning(string message, UnityEngine.Object context = null)
			{
				return new LogEntry
				{
					type = LogType.Warning,
					message = message,
					context = context
				};
			}

			public static LogEntry Message(string message, UnityEngine.Object context = null)
			{
				return new LogEntry
				{
					type = LogType.Log,
					message = message,
					context = context
				};
			}

			public static LogEntry Exception(Exception exception, UnityEngine.Object context = null)
			{
				return new LogEntry
				{
					type = LogType.Exception,
					exception = exception,
					context = context
				};
			}

			public void Log()
			{
				if (type == LogType.Error)
				{
					Debug.LogError(message, context);
					return;
				}
				if (type == LogType.Warning)
				{
					Debug.LogWarning(message, context);
					return;
				}
				if (type == LogType.Exception)
				{
					Debug.LogException(exception, context);
					return;
				}
				if (type == LogType.Log)
				{
					Debug.Log(message, context);
					return;
				}
				throw new NotImplementedException($"Unsupported log type {type} for message: '{message}'");
			}
		}

		public readonly List<LogEntry> entries = new List<LogEntry>();

		private string errorPrefix;

		private UnityEngine.Object defaultContext;

		public ErrorLoggerAccumulator(string errorPrefix, UnityEngine.Object defaultContext)
		{
			this.errorPrefix = errorPrefix;
			this.defaultContext = defaultContext;
		}

		public LogEntry Error(string message, UnityEngine.Object context = null)
		{
			if (context == null)
			{
				context = defaultContext;
			}
			LogEntry logEntry = LogEntry.Error("[" + errorPrefix + "] " + message, context);
			entries.Add(logEntry);
			return logEntry;
		}

		public LogEntry Warning(string message, UnityEngine.Object context = null)
		{
			if (context == null)
			{
				context = defaultContext;
			}
			LogEntry logEntry = LogEntry.Warning("[" + errorPrefix + "] " + message, context);
			entries.Add(logEntry);
			return logEntry;
		}

		public LogEntry Log(string message, UnityEngine.Object context = null)
		{
			return Info(message, context);
		}

		public LogEntry Info(string message, UnityEngine.Object context = null)
		{
			if (context == null)
			{
				context = defaultContext;
			}
			LogEntry logEntry = LogEntry.Message("[" + errorPrefix + "] " + message, context);
			entries.Add(logEntry);
			return logEntry;
		}

		public LogEntry Exception(Exception exception, UnityEngine.Object context = null)
		{
			if (context == null)
			{
				context = defaultContext;
			}
			LogEntry logEntry = LogEntry.Exception(exception, context);
			entries.Add(logEntry);
			return logEntry;
		}
	}
}
