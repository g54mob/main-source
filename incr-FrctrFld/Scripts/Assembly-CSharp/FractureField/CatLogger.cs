using System;
using System.Collections.Generic;
using UnityEngine;

namespace FractureField
{
	public class CatLogger
	{
		private static Dictionary<LogCategory, CatLogger> _catLoggers;

		private LogCategory _logCategory;

		private string _context;

		private LogLevel _logLevel;

		public void SetLogLevel(LogLevel logLevel)
		{
		}

		public static void SetLogLevelForCategory(LogCategory logCategory, LogLevel logLevel)
		{
		}

		public static LogLevel GetLogLevel(LogCategory logCategory)
		{
			return default(LogLevel);
		}

		public CatLogger(LogCategory logCategory, string context = null)
		{
		}

		private static CatLogger LoggerForCat(LogCategory logCategory)
		{
			return null;
		}

		[HideInCallstack]
		public void Log(Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void Log(LogCategory logCategory, Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public void Trace(Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void Trace(LogCategory logCategory, List<object> pieces, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void Trace(LogCategory logCategory, Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public void LogWarning(Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogWarning(LogCategory logCategory, Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public void LogError(Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogError(LogCategory logCategory, Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public void LogException(Exception ex, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public void LogException(Exception ex, Func<object> message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogException(LogCategory logCategory, Exception ex, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogException(LogCategory logCategory, Exception ex, Func<object> message, LoggerOptions options = null)
		{
		}
	}
}
