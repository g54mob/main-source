using System;
using System.ComponentModel;

namespace Sentry.Extensibility
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class DiagnosticLoggerExtensions
	{
		internal static void Log(this SentryOptions options, SentryLevel logLevel, string message, Exception? exception = null, params object?[] args)
		{
			options.DiagnosticLogger?.Log(logLevel, message, exception, args);
		}

		public static void LogDebug<TArg>(this IDiagnosticLogger logger, string message, TArg arg)
		{
			logger.LogIfEnabled(SentryLevel.Debug, null, message, arg);
		}

		internal static void LogDebug<TArg>(this SentryOptions options, string message, TArg arg)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Debug, null, message, arg);
		}

		public static void LogDebug<TArg, TArg2>(this IDiagnosticLogger logger, string message, TArg arg, TArg2 arg2)
		{
			logger.LogIfEnabled(SentryLevel.Debug, null, message, arg, arg2);
		}

		internal static void LogDebug<TArg, TArg2>(this SentryOptions options, string message, TArg arg, TArg2 arg2)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Debug, null, message, arg, arg2);
		}

		internal static void LogDebug<TArg, TArg2, TArg3>(this SentryOptions options, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Debug, null, message, arg, arg2, arg3);
		}

		public static void LogDebug(this IDiagnosticLogger logger, string message)
		{
			logger.LogIfEnabled(SentryLevel.Debug, null, message);
		}

		internal static void LogDebug(this SentryOptions options, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Debug, null, message);
		}

		public static void LogInfo(this IDiagnosticLogger logger, string message)
		{
			logger.LogIfEnabled(SentryLevel.Info, null, message);
		}

		internal static void LogInfo(this SentryOptions options, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Info, null, message);
		}

		public static void LogInfo<TArg>(this IDiagnosticLogger logger, string message, TArg arg)
		{
			logger.LogIfEnabled(SentryLevel.Info, null, message, arg);
		}

		internal static void LogInfo<TArg>(this SentryOptions options, string message, TArg arg)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Info, null, message, arg);
		}

		public static void LogInfo<TArg, TArg2>(this IDiagnosticLogger logger, string message, TArg arg, TArg2 arg2)
		{
			logger.LogIfEnabled(SentryLevel.Info, null, message, arg, arg2);
		}

		internal static void LogInfo<TArg, TArg2>(this SentryOptions options, string message, TArg arg, TArg2 arg2)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Info, null, message, arg, arg2);
		}

		public static void LogInfo<TArg, TArg2, TArg3>(this IDiagnosticLogger logger, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			logger.LogIfEnabled(SentryLevel.Info, null, message, arg, arg2, arg3);
		}

		internal static void LogInfo<TArg, TArg2, TArg3>(this SentryOptions options, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Info, null, message, arg, arg2, arg3);
		}

		public static void LogWarning(this IDiagnosticLogger logger, string message)
		{
			logger.LogIfEnabled(SentryLevel.Warning, null, message);
		}

		internal static void LogWarning(this SentryOptions options, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Warning, null, message);
		}

		public static void LogWarning(this IDiagnosticLogger logger, Exception exception, string message)
		{
			logger.LogIfEnabled(SentryLevel.Warning, exception, message);
		}

		internal static void LogWarning(this SentryOptions options, Exception exception, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Warning, exception, message);
		}

		public static void LogWarning<TArg>(this IDiagnosticLogger logger, string message, TArg arg)
		{
			logger.LogIfEnabled(SentryLevel.Warning, null, message, arg);
		}

		internal static void LogWarning<TArg>(this SentryOptions options, string message, TArg arg)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Warning, null, message, arg);
		}

		public static void LogWarning<TArg, TArg2>(this IDiagnosticLogger logger, string message, TArg arg, TArg2 arg2)
		{
			logger.LogIfEnabled(SentryLevel.Warning, null, message, arg, arg2);
		}

		internal static void LogWarning<TArg, TArg2>(this SentryOptions options, string message, TArg arg, TArg2 arg2)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Warning, null, message, arg, arg2);
		}

		internal static void LogWarning<TArg, TArg2, TArg3>(this SentryOptions options, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Warning, null, message, arg, arg2, arg3);
		}

		public static void LogError(this IDiagnosticLogger logger, string message)
		{
			logger.LogIfEnabled(SentryLevel.Error, null, message);
		}

		public static void LogError<TArg>(this IDiagnosticLogger logger, string message, TArg arg)
		{
			logger.LogIfEnabled(SentryLevel.Error, null, message, arg);
		}

		public static void LogError(this IDiagnosticLogger logger, Exception exception, string message)
		{
			logger.LogIfEnabled(SentryLevel.Error, exception, message);
		}

		internal static void LogError(this SentryOptions options, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, null, message);
		}

		internal static void LogError(this SentryOptions options, Exception exception, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, exception, message);
		}

		public static void LogError<TArg>(this IDiagnosticLogger logger, Exception exception, string message, TArg arg)
		{
			logger.LogIfEnabled(SentryLevel.Error, exception, message, arg);
		}

		internal static void LogError<TArg>(this SentryOptions options, Exception exception, string message, TArg arg)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, exception, message, arg);
		}

		internal static void LogError<TArg>(this SentryOptions options, string message, TArg arg)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, null, message, arg);
		}

		public static void LogError<TArg, TArg2>(this IDiagnosticLogger logger, Exception exception, string message, TArg arg, TArg2 arg2)
		{
			logger.LogIfEnabled(SentryLevel.Error, exception, message, arg, arg2);
		}

		internal static void LogError<TArg, TArg2>(this SentryOptions options, Exception exception, string message, TArg arg, TArg2 arg2)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, exception, message, arg, arg2);
		}

		internal static void LogError<TArg, TArg2>(this SentryOptions options, string message, TArg arg, TArg2 arg2)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, null, message, arg, arg2);
		}

		public static void LogError<TArg, TArg2, TArg3>(this IDiagnosticLogger logger, Exception exception, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			logger.LogIfEnabled(SentryLevel.Error, exception, message, arg, arg2, arg3);
		}

		internal static void LogError<TArg, TArg2, TArg3>(this SentryOptions options, Exception exception, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, exception, message, arg, arg2, arg3);
		}

		internal static void LogError<TArg, TArg2, TArg3>(this SentryOptions options, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, null, message, arg, arg2, arg3);
		}

		public static void LogError<TArg, TArg2, TArg3, TArg4>(this IDiagnosticLogger logger, Exception exception, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			logger.LogIfEnabled(SentryLevel.Error, exception, message, arg, arg2, arg3, arg4);
		}

		internal static void LogError<TArg, TArg2, TArg3, TArg4>(this SentryOptions options, Exception exception, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, exception, message, arg, arg2, arg3, arg4);
		}

		internal static void LogError<TArg, TArg2, TArg3, TArg4>(this SentryOptions options, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, null, message, arg, arg2, arg3, arg4);
		}

		internal static void LogError<TArg, TArg2, TArg3, TArg4, TArg5>(this SentryOptions options, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Error, null, message, arg, arg2, arg3, arg4, arg5);
		}

		public static void LogFatal(this IDiagnosticLogger logger, string message)
		{
			logger.LogIfEnabled(SentryLevel.Fatal, null, message);
		}

		public static void LogFatal(this IDiagnosticLogger logger, Exception exception, string message)
		{
			logger.LogIfEnabled(SentryLevel.Fatal, exception, message);
		}

		internal static void LogFatal(this SentryOptions options, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Fatal, null, message);
		}

		internal static void LogFatal(this SentryOptions options, Exception exception, string message)
		{
			options.DiagnosticLogger?.LogIfEnabled(SentryLevel.Fatal, exception, message);
		}

		internal static void LogIfEnabled(this IDiagnosticLogger logger, SentryLevel level, Exception? exception, string message)
		{
			if (logger.IsEnabled(level))
			{
				logger.Log(level, message, exception);
			}
		}

		internal static void LogIfEnabled(this SentryOptions options, SentryLevel level, Exception? exception, string message)
		{
			IDiagnosticLogger diagnosticLogger = options.DiagnosticLogger;
			if (diagnosticLogger != null && diagnosticLogger.IsEnabled(level))
			{
				diagnosticLogger.Log(level, message, exception);
			}
		}

		internal static void LogIfEnabled<TArg>(this IDiagnosticLogger logger, SentryLevel level, Exception? exception, string message, TArg arg)
		{
			if (logger.IsEnabled(level))
			{
				logger.Log(level, message, exception, arg);
			}
		}

		internal static void LogIfEnabled<TArg>(this SentryOptions options, SentryLevel level, Exception? exception, string message, TArg arg)
		{
			IDiagnosticLogger diagnosticLogger = options.DiagnosticLogger;
			if (diagnosticLogger != null && diagnosticLogger.IsEnabled(level))
			{
				diagnosticLogger.Log(level, message, exception, arg);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2>(this IDiagnosticLogger logger, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2)
		{
			if (logger.IsEnabled(level))
			{
				logger.Log(level, message, exception, arg, arg2);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2>(this SentryOptions options, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2)
		{
			IDiagnosticLogger diagnosticLogger = options.DiagnosticLogger;
			if (diagnosticLogger != null && diagnosticLogger.IsEnabled(level))
			{
				diagnosticLogger.Log(level, message, exception, arg, arg2);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2, TArg3>(this IDiagnosticLogger logger, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			if (logger.IsEnabled(level))
			{
				logger.Log(level, message, exception, arg, arg2, arg3);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2, TArg3>(this SentryOptions options, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2, TArg3 arg3)
		{
			IDiagnosticLogger diagnosticLogger = options.DiagnosticLogger;
			if (diagnosticLogger != null && diagnosticLogger.IsEnabled(level))
			{
				diagnosticLogger.Log(level, message, exception, arg, arg2, arg3);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2, TArg3, TArg4>(this IDiagnosticLogger logger, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			if (logger.IsEnabled(level))
			{
				logger.Log(level, message, exception, arg, arg2, arg3, arg4);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2, TArg3, TArg4, TArg5>(this IDiagnosticLogger logger, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			if (logger.IsEnabled(level))
			{
				logger.Log(level, message, exception, arg, arg2, arg3, arg4, arg5);
			}
		}

		internal static void LogIfEnabled<TArg, TArg2, TArg3, TArg4>(this SentryOptions options, SentryLevel level, Exception? exception, string message, TArg arg, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			IDiagnosticLogger diagnosticLogger = options.DiagnosticLogger;
			if (diagnosticLogger != null && diagnosticLogger.IsEnabled(level))
			{
				diagnosticLogger.Log(level, message, exception, arg, arg2, arg3, arg4);
			}
		}
	}
}
