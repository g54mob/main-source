using System;
using System.Reflection;
using Microsoft.Extensions.Logging;
using ZLogger.Entries;

namespace ZLogger
{
	public class AsyncProcessZLogger : ILogger
	{
		private static class StateTypeDetector<TState>
		{
			public static readonly bool IsInternalFormattedLogValues;

			static StateTypeDetector()
			{
				IsInternalFormattedLogValues = typeof(TState).FullName == "Microsoft.Extensions.Logging.FormattedLogValues";
			}
		}

		private class NullDisposable : IDisposable
		{
			public static IDisposable Instance = new NullDisposable();

			private NullDisposable()
			{
			}

			public void Dispose()
			{
			}
		}

		private static class CreateLogEntry<T>
		{
			public static readonly Func<T, LogInfo, IZLoggerEntry>? factory;

			static CreateLogEntry()
			{
				if (typeof(IZLoggerState).IsAssignableFrom(typeof(T)))
				{
					try
					{
						FieldInfo field = typeof(T).GetField("Factory", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						LogForUnity(field);
						if (field != null)
						{
							factory = field.GetValue(null) as Func<T, LogInfo, IZLoggerEntry>;
						}
						return;
					}
					catch (Exception ex)
					{
						LogForUnity(ex);
						return;
					}
				}
				factory = null;
			}

			private static void LogForUnity(FieldInfo? fieldInfo)
			{
			}

			private static void LogForUnity(Exception ex)
			{
			}
		}

		private readonly Func<string, Exception?, string> ReturnStringStateFormatter = (string state, Exception? _) => state;

		private readonly string categoryName;

		private readonly IAsyncLogProcessor logProcessor;

		public AsyncProcessZLogger(string categoryName, IAsyncLogProcessor logProcessor)
		{
			this.categoryName = categoryName;
			this.logProcessor = logProcessor;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			Func<TState, LogInfo, IZLoggerEntry> factory = CreateLogEntry<TState>.factory;
			if (factory != null)
			{
				LogInfo arg = new LogInfo(categoryName, DateTimeOffset.UtcNow, logLevel, eventId, exception);
				IZLoggerEntry log = factory(state, arg);
				logProcessor.Post(log);
				return;
			}
			LogInfo info = new LogInfo(categoryName, DateTimeOffset.UtcNow, logLevel, eventId, exception);
			if (StateTypeDetector<TState>.IsInternalFormattedLogValues || state == null)
			{
				logProcessor.Post(StringFormatterEntry<TState>.Create(info, state, exception, formatter));
				return;
			}
			string state2 = formatter(state, exception);
			logProcessor.Post(StringFormatterEntry<string>.Create(info, state2, exception, ReturnStringStateFormatter));
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return NullDisposable.Instance;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return logLevel != LogLevel.None;
		}
	}
}
