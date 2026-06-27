using System;

namespace Castle.Core.Logging
{
	public class NullLogger : IExtendedLogger, ILogger
	{
		private class NullContextProperties : IContextProperties
		{
			public static readonly NullContextProperties Instance = new NullContextProperties();

			public object this[string key]
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		private class NullContextStack : IContextStack, IDisposable
		{
			public static readonly NullContextStack Instance = new NullContextStack();

			public int Count => 0;

			public void Clear()
			{
			}

			public string Pop()
			{
				return null;
			}

			public IDisposable Push(string message)
			{
				return this;
			}

			public void Dispose()
			{
				GC.SuppressFinalize(this);
			}
		}

		private class NullContextStacks : IContextStacks
		{
			public static readonly NullContextStacks Instance = new NullContextStacks();

			public IContextStack this[string key] => NullContextStack.Instance;
		}

		public static readonly NullLogger Instance = new NullLogger();

		public IContextProperties GlobalProperties => NullContextProperties.Instance;

		public IContextProperties ThreadProperties => NullContextProperties.Instance;

		public IContextStacks ThreadStacks => NullContextStacks.Instance;

		public bool IsTraceEnabled => false;

		public bool IsDebugEnabled => false;

		public bool IsErrorEnabled => false;

		public bool IsFatalEnabled => false;

		public bool IsInfoEnabled => false;

		public bool IsWarnEnabled => false;

		public ILogger CreateChildLogger(string loggerName)
		{
			return this;
		}

		public void Trace(string message)
		{
		}

		public void Trace(Func<string> messageFactory)
		{
		}

		public void Trace(string message, Exception exception)
		{
		}

		public void TraceFormat(string format, params object[] args)
		{
		}

		public void TraceFormat(Exception exception, string format, params object[] args)
		{
		}

		public void TraceFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void TraceFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void Debug(string message)
		{
		}

		public void Debug(Func<string> messageFactory)
		{
		}

		public void Debug(string message, Exception exception)
		{
		}

		public void DebugFormat(string format, params object[] args)
		{
		}

		public void DebugFormat(Exception exception, string format, params object[] args)
		{
		}

		public void DebugFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void DebugFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void Error(string message)
		{
		}

		public void Error(Func<string> messageFactory)
		{
		}

		public void Error(string message, Exception exception)
		{
		}

		public void ErrorFormat(string format, params object[] args)
		{
		}

		public void ErrorFormat(Exception exception, string format, params object[] args)
		{
		}

		public void ErrorFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void ErrorFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void Fatal(string message)
		{
		}

		public void Fatal(Func<string> messageFactory)
		{
		}

		public void Fatal(string message, Exception exception)
		{
		}

		public void FatalFormat(string format, params object[] args)
		{
		}

		public void FatalFormat(Exception exception, string format, params object[] args)
		{
		}

		public void FatalFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void FatalFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void Info(string message)
		{
		}

		public void Info(Func<string> messageFactory)
		{
		}

		public void Info(string message, Exception exception)
		{
		}

		public void InfoFormat(string format, params object[] args)
		{
		}

		public void InfoFormat(Exception exception, string format, params object[] args)
		{
		}

		public void InfoFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void InfoFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void Warn(string message)
		{
		}

		public void Warn(Func<string> messageFactory)
		{
		}

		public void Warn(string message, Exception exception)
		{
		}

		public void WarnFormat(string format, params object[] args)
		{
		}

		public void WarnFormat(Exception exception, string format, params object[] args)
		{
		}

		public void WarnFormat(IFormatProvider formatProvider, string format, params object[] args)
		{
		}

		public void WarnFormat(Exception exception, IFormatProvider formatProvider, string format, params object[] args)
		{
		}
	}
}
