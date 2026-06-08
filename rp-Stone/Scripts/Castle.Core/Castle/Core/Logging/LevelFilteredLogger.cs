using System;
using System.Globalization;
using System.Security;

namespace Castle.Core.Logging
{
	[Serializable]
	public abstract class LevelFilteredLogger : MarshalByRefObject, ILogger
	{
		private LoggerLevel level;

		private string name = "unnamed";

		public LoggerLevel Level
		{
			get
			{
				return level;
			}
			set
			{
				level = value;
			}
		}

		public string Name => name;

		public bool IsTraceEnabled => Level >= LoggerLevel.Trace;

		public bool IsDebugEnabled => Level >= LoggerLevel.Debug;

		public bool IsInfoEnabled => Level >= LoggerLevel.Info;

		public bool IsWarnEnabled => Level >= LoggerLevel.Warn;

		public bool IsErrorEnabled => Level >= LoggerLevel.Error;

		public bool IsFatalEnabled => Level >= LoggerLevel.Fatal;

		protected LevelFilteredLogger()
		{
		}

		protected LevelFilteredLogger(string name)
		{
			ChangeName(name);
		}

		protected LevelFilteredLogger(LoggerLevel loggerLevel)
		{
			level = loggerLevel;
		}

		protected LevelFilteredLogger(string loggerName, LoggerLevel loggerLevel)
			: this(loggerLevel)
		{
			ChangeName(loggerName);
		}

		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			return null;
		}

		public abstract ILogger CreateChildLogger(string loggerName);

		public void Trace(string message)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, message, null);
			}
		}

		public void Trace(Func<string> messageFactory)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, messageFactory(), null);
			}
		}

		public void Trace(string message, Exception exception)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, message, exception);
			}
		}

		public void TraceFormat(string format, params object[] args)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, string.Format(CultureInfo.CurrentCulture, format, args), null);
			}
		}

		public void TraceFormat(Exception exception, string format, params object[] args)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, string.Format(CultureInfo.CurrentCulture, format, args), exception);
			}
		}

		public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, string.Format(formatProvider, format, args), null);
			}
		}

		public void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsTraceEnabled)
			{
				Log(LoggerLevel.Trace, string.Format(formatProvider, format, args), exception);
			}
		}

		public void Debug(string message)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, message, null);
			}
		}

		public void Debug(Func<string> messageFactory)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, messageFactory(), null);
			}
		}

		public void Debug(string message, Exception exception)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, message, exception);
			}
		}

		public void DebugFormat(string format, params object[] args)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, string.Format(CultureInfo.CurrentCulture, format, args), null);
			}
		}

		public void DebugFormat(Exception exception, string format, params object[] args)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, string.Format(CultureInfo.CurrentCulture, format, args), exception);
			}
		}

		public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, string.Format(formatProvider, format, args), null);
			}
		}

		public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsDebugEnabled)
			{
				Log(LoggerLevel.Debug, string.Format(formatProvider, format, args), exception);
			}
		}

		public void Info(string message)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, message, null);
			}
		}

		public void Info(Func<string> messageFactory)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, messageFactory(), null);
			}
		}

		public void Info(string message, Exception exception)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, message, exception);
			}
		}

		public void InfoFormat(string format, params object[] args)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, string.Format(CultureInfo.CurrentCulture, format, args), null);
			}
		}

		public void InfoFormat(Exception exception, string format, params object[] args)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, string.Format(CultureInfo.CurrentCulture, format, args), exception);
			}
		}

		public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, string.Format(formatProvider, format, args), null);
			}
		}

		public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsInfoEnabled)
			{
				Log(LoggerLevel.Info, string.Format(formatProvider, format, args), exception);
			}
		}

		public void Warn(string message)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, message, null);
			}
		}

		public void Warn(Func<string> messageFactory)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, messageFactory(), null);
			}
		}

		public void Warn(string message, Exception exception)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, message, exception);
			}
		}

		public void WarnFormat(string format, params object[] args)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, string.Format(CultureInfo.CurrentCulture, format, args), null);
			}
		}

		public void WarnFormat(Exception exception, string format, params object[] args)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, string.Format(CultureInfo.CurrentCulture, format, args), exception);
			}
		}

		public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, string.Format(formatProvider, format, args), null);
			}
		}

		public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsWarnEnabled)
			{
				Log(LoggerLevel.Warn, string.Format(formatProvider, format, args), exception);
			}
		}

		public void Error(string message)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, message, null);
			}
		}

		public void Error(Func<string> messageFactory)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, messageFactory(), null);
			}
		}

		public void Error(string message, Exception exception)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, message, exception);
			}
		}

		public void ErrorFormat(string format, params object[] args)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, string.Format(CultureInfo.CurrentCulture, format, args), null);
			}
		}

		public void ErrorFormat(Exception exception, string format, params object[] args)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, string.Format(CultureInfo.CurrentCulture, format, args), exception);
			}
		}

		public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, string.Format(formatProvider, format, args), null);
			}
		}

		public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsErrorEnabled)
			{
				Log(LoggerLevel.Error, string.Format(formatProvider, format, args), exception);
			}
		}

		public void Fatal(string message)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, message, null);
			}
		}

		public void Fatal(Func<string> messageFactory)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, messageFactory(), null);
			}
		}

		public void Fatal(string message, Exception exception)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, message, exception);
			}
		}

		public void FatalFormat(string format, params object[] args)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, string.Format(CultureInfo.CurrentCulture, format, args), null);
			}
		}

		public void FatalFormat(Exception exception, string format, params object[] args)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, string.Format(CultureInfo.CurrentCulture, format, args), exception);
			}
		}

		public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, string.Format(formatProvider, format, args), null);
			}
		}

		public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
			if (IsFatalEnabled)
			{
				Log(LoggerLevel.Fatal, string.Format(formatProvider, format, args), exception);
			}
		}

		protected abstract void Log(LoggerLevel loggerLevel, string loggerName, string message, Exception exception);

		protected void ChangeName(string newName)
		{
			if (newName == null)
			{
				throw new ArgumentNullException("newName");
			}
			name = newName;
		}

		private void Log(LoggerLevel loggerLevel, string message, Exception exception)
		{
			Log(loggerLevel, Name, message, exception);
		}
	}
}
