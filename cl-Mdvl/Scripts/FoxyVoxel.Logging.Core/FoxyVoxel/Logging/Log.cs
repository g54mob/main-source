using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Microsoft.Extensions.Logging;

namespace FoxyVoxel.Logging
{
	public static class Log
	{
		private static readonly ConcurrentDictionary<string, FVLogger> filePathToLogger = new ConcurrentDictionary<string, FVLogger>();

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static FVLogger GetLogger(string filePath)
		{
			if (filePathToLogger.TryGetValue(filePath, out FVLogger value))
			{
				return value;
			}
			value = FVLogger.New(Path.GetFileNameWithoutExtension(filePath));
			filePathToLogger[filePath] = value;
			return value;
		}

		public static void Info(string message, [CallerFilePath] string fileName = "?")
		{
			if (LogLevel.Information >= FVLogger.Config.MinimumLevel)
			{
				GetLogger(fileName).LogOnlyCheckCategory(LogLevel.Information, message);
			}
		}

		public static void Trace(string message, [CallerFilePath] string fileName = "?")
		{
			if (LogLevel.Trace >= FVLogger.Config.MinimumLevel)
			{
				GetLogger(fileName).LogOnlyCheckCategory(LogLevel.Trace, message);
			}
		}

		public static void Debug(string message, [CallerFilePath] string fileName = "?")
		{
			if (LogLevel.Debug >= FVLogger.Config.MinimumLevel)
			{
				GetLogger(fileName).LogOnlyCheckCategory(LogLevel.Debug, message);
			}
		}

		public static void Warning(string message, [CallerFilePath] string fileName = "?")
		{
			if (LogLevel.Warning >= FVLogger.Config.MinimumLevel)
			{
				GetLogger(fileName).LogOnlyCheckCategory(LogLevel.Warning, message);
			}
		}

		public static void Error(string message, [CallerFilePath] string fileName = "?")
		{
			if (LogLevel.Error >= FVLogger.Config.MinimumLevel)
			{
				GetLogger(fileName).LogNoCheck(LogLevel.Error, message);
			}
		}

		public static void Critical(string message, [CallerFilePath] string fileName = "?")
		{
			if (LogLevel.Critical >= FVLogger.Config.MinimumLevel)
			{
				GetLogger(fileName).LogNoCheck(LogLevel.Critical, message);
			}
		}

		public static void Info(FVLogInfoInterpolationHandler messageBuilder)
		{
			messageBuilder.LogMessage();
		}

		public static void Trace(FVLogTraceInterpolationHandler messageBuilder)
		{
			messageBuilder.LogMessage();
		}

		public static void Debug(FVLogDebugInterpolationHandler messageBuilder)
		{
			messageBuilder.LogMessage();
		}

		public static void Warning(FVLogWarningInterpolationHandler messageBuilder)
		{
			messageBuilder.LogMessage();
		}

		public static void Error(FVLogErrorInterpolationHandler messageBuilder)
		{
			messageBuilder.LogMessage();
		}

		public static void Critical(FVLogCriticalInterpolationHandler messageBuilder)
		{
			messageBuilder.LogMessage();
		}
	}
}
