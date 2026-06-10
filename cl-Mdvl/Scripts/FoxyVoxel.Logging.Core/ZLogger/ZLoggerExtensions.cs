using System;
using Cysharp.Text;
using Microsoft.Extensions.Logging;
using ZLogger.Entries;

namespace ZLogger
{
	public static class ZLoggerExtensions
	{
		public static void ZLog<T1>(this ILogger logger, LogLevel logLevel, string format, T1 arg1)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLog<T1>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLog<T1>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1);
		}

		public static void ZLog<T1>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1>(null, format, arg1), exception, (FormatLogState<object, T1> state, Exception? ex) => ZString.Format(state.Format, state.Arg1));
		}

		public static void ZLogWithPayload<TPayload, T1>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogWithPayload<TPayload, T1>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogWithPayload<TPayload, T1>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogWithPayload<TPayload, T1>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1>(payload, format, arg1), exception, (FormatLogState<TPayload, T1> state, Exception? ex) => ZString.Format(state.Format, state.Arg1));
		}

		public static void ZLogTrace<T1>(this ILogger logger, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLogTrace<T1>(this ILogger logger, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLogTrace<T1>(this ILogger logger, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1);
		}

		public static void ZLogTrace<T1>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1);
		}

		public static void ZLogTraceWithPayload<TPayload, T1>(this ILogger logger, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogTraceWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogTraceWithPayload<TPayload, T1>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogTraceWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1);
		}

		public static void ZLogDebug<T1>(this ILogger logger, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLogDebug<T1>(this ILogger logger, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLogDebug<T1>(this ILogger logger, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1);
		}

		public static void ZLogDebug<T1>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1);
		}

		public static void ZLogDebugWithPayload<TPayload, T1>(this ILogger logger, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogDebugWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogDebugWithPayload<TPayload, T1>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogDebugWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1);
		}

		public static void ZLogInformation<T1>(this ILogger logger, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLogInformation<T1>(this ILogger logger, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLogInformation<T1>(this ILogger logger, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1);
		}

		public static void ZLogInformation<T1>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1);
		}

		public static void ZLogInformationWithPayload<TPayload, T1>(this ILogger logger, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogInformationWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogInformationWithPayload<TPayload, T1>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogInformationWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1);
		}

		public static void ZLogWarning<T1>(this ILogger logger, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLogWarning<T1>(this ILogger logger, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLogWarning<T1>(this ILogger logger, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1);
		}

		public static void ZLogWarning<T1>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1);
		}

		public static void ZLogWarningWithPayload<TPayload, T1>(this ILogger logger, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogWarningWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogWarningWithPayload<TPayload, T1>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogWarningWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1);
		}

		public static void ZLogError<T1>(this ILogger logger, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLogError<T1>(this ILogger logger, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLogError<T1>(this ILogger logger, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1);
		}

		public static void ZLogError<T1>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1);
		}

		public static void ZLogErrorWithPayload<TPayload, T1>(this ILogger logger, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogErrorWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogErrorWithPayload<TPayload, T1>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogErrorWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1);
		}

		public static void ZLogCritical<T1>(this ILogger logger, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1);
		}

		public static void ZLogCritical<T1>(this ILogger logger, EventId eventId, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1);
		}

		public static void ZLogCritical<T1>(this ILogger logger, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1);
		}

		public static void ZLogCritical<T1>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1>(this ILogger logger, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1);
		}

		public static void ZLog<T1, T2>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLog<T1, T2>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLog<T1, T2>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLog<T1, T2>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2>(null, format, arg1, arg2), exception, (FormatLogState<object, T1, T2> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2));
		}

		public static void ZLogWithPayload<TPayload, T1, T2>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogWithPayload<TPayload, T1, T2>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogWithPayload<TPayload, T1, T2>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogWithPayload<TPayload, T1, T2>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2>(payload, format, arg1, arg2), exception, (FormatLogState<TPayload, T1, T2> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2));
		}

		public static void ZLogTrace<T1, T2>(this ILogger logger, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogTrace<T1, T2>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogTrace<T1, T2>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLogTrace<T1, T2>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2);
		}

		public static void ZLogDebug<T1, T2>(this ILogger logger, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogDebug<T1, T2>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogDebug<T1, T2>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLogDebug<T1, T2>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2);
		}

		public static void ZLogInformation<T1, T2>(this ILogger logger, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogInformation<T1, T2>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogInformation<T1, T2>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLogInformation<T1, T2>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2);
		}

		public static void ZLogWarning<T1, T2>(this ILogger logger, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogWarning<T1, T2>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogWarning<T1, T2>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLogWarning<T1, T2>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2);
		}

		public static void ZLogError<T1, T2>(this ILogger logger, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogError<T1, T2>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogError<T1, T2>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLogError<T1, T2>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2);
		}

		public static void ZLogCritical<T1, T2>(this ILogger logger, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogCritical<T1, T2>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2);
		}

		public static void ZLogCritical<T1, T2>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2);
		}

		public static void ZLogCritical<T1, T2>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2);
		}

		public static void ZLog<T1, T2, T3>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLog<T1, T2, T3>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLog<T1, T2, T3>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLog<T1, T2, T3>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3>(null, format, arg1, arg2, arg3), exception, (FormatLogState<object, T1, T2, T3> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3>(payload, format, arg1, arg2, arg3), exception, (FormatLogState<TPayload, T1, T2, T3> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3));
		}

		public static void ZLogTrace<T1, T2, T3>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogTrace<T1, T2, T3>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogTrace<T1, T2, T3>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLogTrace<T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogDebug<T1, T2, T3>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogDebug<T1, T2, T3>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogDebug<T1, T2, T3>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLogDebug<T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogInformation<T1, T2, T3>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogInformation<T1, T2, T3>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogInformation<T1, T2, T3>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLogInformation<T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWarning<T1, T2, T3>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogWarning<T1, T2, T3>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogWarning<T1, T2, T3>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLogWarning<T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogError<T1, T2, T3>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogError<T1, T2, T3>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogError<T1, T2, T3>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLogError<T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogCritical<T1, T2, T3>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogCritical<T1, T2, T3>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3);
		}

		public static void ZLogCritical<T1, T2, T3>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3);
		}

		public static void ZLogCritical<T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3);
		}

		public static void ZLog<T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLog<T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLog<T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLog<T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4>(null, format, arg1, arg2, arg3, arg4), exception, (FormatLogState<object, T1, T2, T3, T4> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4>(payload, format, arg1, arg2, arg3, arg4), exception, (FormatLogState<TPayload, T1, T2, T3, T4> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4));
		}

		public static void ZLogTrace<T1, T2, T3, T4>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTrace<T1, T2, T3, T4>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTrace<T1, T2, T3, T4>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTrace<T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebug<T1, T2, T3, T4>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebug<T1, T2, T3, T4>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebug<T1, T2, T3, T4>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebug<T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformation<T1, T2, T3, T4>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformation<T1, T2, T3, T4>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformation<T1, T2, T3, T4>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformation<T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarning<T1, T2, T3, T4>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarning<T1, T2, T3, T4>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarning<T1, T2, T3, T4>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarning<T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogError<T1, T2, T3, T4>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogError<T1, T2, T3, T4>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogError<T1, T2, T3, T4>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogError<T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCritical<T1, T2, T3, T4>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCritical<T1, T2, T3, T4>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCritical<T1, T2, T3, T4>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCritical<T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4);
		}

		public static void ZLog<T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLog<T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLog<T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLog<T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5>(null, format, arg1, arg2, arg3, arg4, arg5), exception, (FormatLogState<object, T1, T2, T3, T4, T5> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5>(payload, format, arg1, arg2, arg3, arg4, arg5), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogError<T1, T2, T3, T4, T5>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogError<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogError<T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogError<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6>(null, format, arg1, arg2, arg3, arg4, arg5, arg6), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, (Exception?)null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(logLevel, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Trace, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Debug, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Information, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Information, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Warning, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Error, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Error, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Critical, eventId, (Exception?)null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(logLevel, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(logLevel, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(logLevel, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLog<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.Log(logLevel, eventId, new FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), exception, (FormatLogState<object, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13, state.Arg14));
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(logLevel, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.Log(logLevel, eventId, new FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14), exception, (FormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> state, Exception? ex) => ZString.Format(state.Format, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13, state.Arg14));
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Trace, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Trace, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTrace<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Trace, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Trace, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogTraceWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Trace, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Debug, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Debug, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebug<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Debug, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Debug, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogDebugWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Debug, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Information, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Information, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Information, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformation<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Information, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Information, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogInformationWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Information, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Warning, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Warning, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarning<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Warning, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Warning, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogWarningWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Warning, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Error, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Error, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Error, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogError<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Error, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Error, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogErrorWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Error, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Critical, eventId, null, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Critical, default(EventId), exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCritical<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLog(LogLevel.Critical, eventId, exception, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, null, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Critical, default(EventId), exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLogCriticalWithPayload<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
		{
			logger.ZLogWithPayload(LogLevel.Critical, eventId, exception, payload, format, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
		}

		public static void ZLog(this ILogger logger, LogLevel logLevel, string message)
		{
			logger.ZLog(logLevel, default(EventId), (Exception?)null, message);
		}

		public static void ZLog(this ILogger logger, LogLevel logLevel, EventId eventId, string message)
		{
			logger.ZLog(logLevel, eventId, (Exception?)null, message);
		}

		public static void ZLog(this ILogger logger, LogLevel logLevel, Exception? exception, string message)
		{
			logger.ZLog(logLevel, default(EventId), exception, message);
		}

		public static void ZLog(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, string message)
		{
			logger.Log(logLevel, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogWithPayload<TPayload>(this ILogger logger, LogLevel logLevel, TPayload payload, string message)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogWithPayload<TPayload>(this ILogger logger, LogLevel logLevel, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogWithPayload(logLevel, eventId, (Exception?)null, payload, message);
		}

		public static void ZLogWithPayload<TPayload>(this ILogger logger, LogLevel logLevel, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogWithPayload(logLevel, default(EventId), exception, payload, message);
		}

		public static void ZLogWithPayload<TPayload>(this ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(logLevel, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}

		public static void ZLogTrace(this ILogger logger, string message)
		{
			logger.ZLogTrace(default(EventId), (Exception?)null, message);
		}

		public static void ZLogTrace(this ILogger logger, EventId eventId, string message)
		{
			logger.ZLogTrace(eventId, (Exception?)null, message);
		}

		public static void ZLogTrace(this ILogger logger, Exception? exception, string message)
		{
			logger.ZLogTrace(default(EventId), exception, message);
		}

		public static void ZLogTrace(this ILogger logger, EventId eventId, Exception? exception, string message)
		{
			logger.Log(LogLevel.Trace, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogTraceWithPayload<TPayload>(this ILogger logger, TPayload payload, string message)
		{
			logger.ZLogTraceWithPayload(default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogTraceWithPayload<TPayload>(this ILogger logger, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogTraceWithPayload(eventId, (Exception?)null, payload, message);
		}

		public static void ZLogTraceWithPayload<TPayload>(this ILogger logger, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogTraceWithPayload(default(EventId), exception, payload, message);
		}

		public static void ZLogTraceWithPayload<TPayload>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(LogLevel.Trace, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}

		public static void ZLogDebug(this ILogger logger, string message)
		{
			logger.ZLogDebug(default(EventId), (Exception?)null, message);
		}

		public static void ZLogDebug(this ILogger logger, EventId eventId, string message)
		{
			logger.ZLogDebug(eventId, (Exception?)null, message);
		}

		public static void ZLogDebug(this ILogger logger, Exception? exception, string message)
		{
			logger.ZLogDebug(default(EventId), exception, message);
		}

		public static void ZLogDebug(this ILogger logger, EventId eventId, Exception? exception, string message)
		{
			logger.Log(LogLevel.Debug, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogDebugWithPayload<TPayload>(this ILogger logger, TPayload payload, string message)
		{
			logger.ZLogDebugWithPayload(default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogDebugWithPayload<TPayload>(this ILogger logger, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogDebugWithPayload(eventId, (Exception?)null, payload, message);
		}

		public static void ZLogDebugWithPayload<TPayload>(this ILogger logger, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogDebugWithPayload(default(EventId), exception, payload, message);
		}

		public static void ZLogDebugWithPayload<TPayload>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(LogLevel.Debug, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}

		public static void ZLogInformation(this ILogger logger, string message)
		{
			logger.ZLogInformation(default(EventId), (Exception?)null, message);
		}

		public static void ZLogInformation(this ILogger logger, EventId eventId, string message)
		{
			logger.ZLogInformation(eventId, (Exception?)null, message);
		}

		public static void ZLogInformation(this ILogger logger, Exception? exception, string message)
		{
			logger.ZLogInformation(default(EventId), exception, message);
		}

		public static void ZLogInformation(this ILogger logger, EventId eventId, Exception? exception, string message)
		{
			logger.Log(LogLevel.Information, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogInformationWithPayload<TPayload>(this ILogger logger, TPayload payload, string message)
		{
			logger.ZLogInformationWithPayload(default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogInformationWithPayload<TPayload>(this ILogger logger, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogInformationWithPayload(eventId, (Exception?)null, payload, message);
		}

		public static void ZLogInformationWithPayload<TPayload>(this ILogger logger, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogInformationWithPayload(default(EventId), exception, payload, message);
		}

		public static void ZLogInformationWithPayload<TPayload>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(LogLevel.Information, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}

		public static void ZLogWarning(this ILogger logger, string message)
		{
			logger.ZLogWarning(default(EventId), (Exception?)null, message);
		}

		public static void ZLogWarning(this ILogger logger, EventId eventId, string message)
		{
			logger.ZLogWarning(eventId, (Exception?)null, message);
		}

		public static void ZLogWarning(this ILogger logger, Exception? exception, string message)
		{
			logger.ZLogWarning(default(EventId), exception, message);
		}

		public static void ZLogWarning(this ILogger logger, EventId eventId, Exception? exception, string message)
		{
			logger.Log(LogLevel.Warning, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogWarningWithPayload<TPayload>(this ILogger logger, TPayload payload, string message)
		{
			logger.ZLogWarningWithPayload(default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogWarningWithPayload<TPayload>(this ILogger logger, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogWarningWithPayload(eventId, (Exception?)null, payload, message);
		}

		public static void ZLogWarningWithPayload<TPayload>(this ILogger logger, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogWarningWithPayload(default(EventId), exception, payload, message);
		}

		public static void ZLogWarningWithPayload<TPayload>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(LogLevel.Warning, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}

		public static void ZLogError(this ILogger logger, string message)
		{
			logger.ZLogError(default(EventId), (Exception?)null, message);
		}

		public static void ZLogError(this ILogger logger, EventId eventId, string message)
		{
			logger.ZLogError(eventId, (Exception?)null, message);
		}

		public static void ZLogError(this ILogger logger, Exception? exception, string message)
		{
			logger.ZLogError(default(EventId), exception, message);
		}

		public static void ZLogError(this ILogger logger, EventId eventId, Exception? exception, string message)
		{
			logger.Log(LogLevel.Error, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogErrorWithPayload<TPayload>(this ILogger logger, TPayload payload, string message)
		{
			logger.ZLogErrorWithPayload(default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogErrorWithPayload<TPayload>(this ILogger logger, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogErrorWithPayload(eventId, (Exception?)null, payload, message);
		}

		public static void ZLogErrorWithPayload<TPayload>(this ILogger logger, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogErrorWithPayload(default(EventId), exception, payload, message);
		}

		public static void ZLogErrorWithPayload<TPayload>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(LogLevel.Error, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}

		public static void ZLogCritical(this ILogger logger, string message)
		{
			logger.ZLogCritical(default(EventId), (Exception?)null, message);
		}

		public static void ZLogCritical(this ILogger logger, EventId eventId, string message)
		{
			logger.ZLogCritical(eventId, (Exception?)null, message);
		}

		public static void ZLogCritical(this ILogger logger, Exception? exception, string message)
		{
			logger.ZLogCritical(default(EventId), exception, message);
		}

		public static void ZLogCritical(this ILogger logger, EventId eventId, Exception? exception, string message)
		{
			logger.Log(LogLevel.Critical, eventId, new MessageLogState<object>(null, message), exception, (MessageLogState<object> state, Exception? ex) => state.Message);
		}

		public static void ZLogCriticalWithPayload<TPayload>(this ILogger logger, TPayload payload, string message)
		{
			logger.ZLogCriticalWithPayload(default(EventId), (Exception?)null, payload, message);
		}

		public static void ZLogCriticalWithPayload<TPayload>(this ILogger logger, EventId eventId, TPayload payload, string message)
		{
			logger.ZLogCriticalWithPayload(eventId, (Exception?)null, payload, message);
		}

		public static void ZLogCriticalWithPayload<TPayload>(this ILogger logger, Exception? exception, TPayload payload, string message)
		{
			logger.ZLogCriticalWithPayload(default(EventId), exception, payload, message);
		}

		public static void ZLogCriticalWithPayload<TPayload>(this ILogger logger, EventId eventId, Exception? exception, TPayload payload, string message)
		{
			logger.Log(LogLevel.Critical, eventId, new MessageLogState<TPayload>(payload, message), exception, (MessageLogState<TPayload> state, Exception? ex) => state.Message);
		}
	}
}
