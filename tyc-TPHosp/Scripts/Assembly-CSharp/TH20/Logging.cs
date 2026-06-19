#define LOG_LEVEL_VERBOSE
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public static class Logging
	{
		public static Logger Logger { get; set; }

		static Logging()
		{
			Logger = new Logger();
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(Object obj, string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(Object obj, string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(LogChannel channel, string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(LogChannel channel, string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(Object obj, LogChannel channel, string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		public static void Verbose(Object obj, LogChannel channel, string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(Object obj, string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(Object obj, string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(LogChannel channel, string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(LogChannel channel, string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(Object obj, LogChannel channel, string message)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		public static void Debug(Object obj, LogChannel channel, string message, params object[] args)
		{
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(string message)
		{
			Logger.Info(message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(string message, params object[] args)
		{
			Logger.Info(message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(Object obj, string message)
		{
			Logger.Info(obj, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(Object obj, string message, params object[] args)
		{
			Logger.Info(obj, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(LogChannel channel, string message)
		{
			Logger.Info(channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(LogChannel channel, string message, params object[] args)
		{
			Logger.Info(channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(Object obj, LogChannel channel, string message)
		{
			Logger.Info(obj, channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		public static void Info(Object obj, LogChannel channel, string message, params object[] args)
		{
			Logger.Info(obj, channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(string message)
		{
			Logger.Warning(message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(string message, params object[] args)
		{
			Logger.Warning(message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(Object obj, string message)
		{
			Logger.Warning(obj, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(Object obj, string message, params object[] args)
		{
			Logger.Warning(obj, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(LogChannel channel, string message)
		{
			Logger.Warning(channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(LogChannel channel, string message, params object[] args)
		{
			Logger.Warning(channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(Object obj, LogChannel channel, string message)
		{
			Logger.Warning(obj, channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		public static void Warning(Object obj, LogChannel channel, string message, params object[] args)
		{
			Logger.Warning(obj, channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(string message)
		{
			Logger.Error(message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(string message, params object[] args)
		{
			Logger.Error(message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(Object obj, string message)
		{
			Logger.Error(obj, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(Object obj, string message, params object[] args)
		{
			Logger.Error(obj, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(LogChannel channel, string message)
		{
			Logger.Error(channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(LogChannel channel, string message, params object[] args)
		{
			Logger.Error(channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(Object obj, LogChannel channel, string message)
		{
			Logger.Error(obj, channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		public static void Error(Object obj, LogChannel channel, string message, params object[] args)
		{
			Logger.Error(obj, channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(string message)
		{
			Logger.AlwaysLog(message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(string message, params object[] args)
		{
			Logger.AlwaysLog(message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(Object obj, string message)
		{
			Logger.AlwaysLog(obj, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(Object obj, string message, params object[] args)
		{
			Logger.AlwaysLog(obj, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(LogChannel channel, string message)
		{
			Logger.AlwaysLog(channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(LogChannel channel, string message, params object[] args)
		{
			Logger.AlwaysLog(channel, message, args);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(Object obj, LogChannel channel, string message)
		{
			Logger.AlwaysLog(obj, channel, message);
		}

		[StackTraceIgnore]
		[StringFormatMethod("message")]
		[Conditional("LOG_LEVEL_VERBOSE")]
		[Conditional("LOG_LEVEL_DEBUG")]
		[Conditional("LOG_LEVEL_INFORMATION")]
		[Conditional("LOG_LEVEL_WARNING")]
		[Conditional("LOG_LEVEL_ERROR")]
		[Conditional("LOG_LEVEL_ALWAYSLOG")]
		public static void AlwaysLog(Object obj, LogChannel channel, string message, params object[] args)
		{
			Logger.AlwaysLog(obj, channel, message, args);
		}
	}
}
