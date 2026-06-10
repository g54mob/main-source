using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Microsoft.Extensions.Logging;
using UnityEngine;
using ZLogger;

namespace FoxyVoxel.Logging
{
	public class FVLogger
	{
		public static LoggerConfig Config = new LoggerConfig();

		private readonly Microsoft.Extensions.Logging.ILogger _internalLogger;

		private readonly string _categoryName;

		private static HashSet<string> uniqueLoggerNames = new HashSet<string>();

		public static Action<string> OnNewLoggerCreated;

		internal bool ShouldHideCategory => !Config.ShouldShowCategory(_categoryName);

		public static IReadOnlyCollection<string> UniqueLoggerNames => uniqueLoggerNames;

		private FVLogger(Microsoft.Extensions.Logging.ILogger internalLogger, string categoryName)
		{
			_internalLogger = internalLogger;
			_categoryName = categoryName;
			if (Application.isEditor)
			{
				AddUniqueLoggerName(categoryName);
			}
		}

		public static FVLogger New(string categoryName)
		{
			return new FVLogger(LoggerFactory.Create(categoryName), categoryName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldHideLog(LogLevel level)
		{
			if (level >= Config.MinimumLevel)
			{
				return ShouldHideCategory;
			}
			return true;
		}

		public void Info(string message)
		{
			Log(LogLevel.Information, message);
		}

		public void Trace(string message)
		{
			Log(LogLevel.Trace, message);
		}

		public void Debug(string message)
		{
			Log(LogLevel.Debug, message);
		}

		public void Warning(string message)
		{
			Log(LogLevel.Warning, message);
		}

		public void Error(string message)
		{
			Log(LogLevel.Error, message);
		}

		public void Critical(string message)
		{
			Log(LogLevel.Critical, message);
		}

		public void Info(in FVLogInfoInterpolationHandler messageBuilder)
		{
			if (messageBuilder.IsEnabled)
			{
				_internalLogger.ZLog(LogLevel.Information, messageBuilder.GetFormattedText());
			}
		}

		public void Trace(in FVLogTraceInterpolationHandler messageBuilder)
		{
			if (messageBuilder.IsEnabled)
			{
				_internalLogger.ZLog(LogLevel.Trace, messageBuilder.GetFormattedText());
			}
		}

		public void Debug(in FVLogDebugInterpolationHandler messageBuilder)
		{
			if (messageBuilder.IsEnabled)
			{
				_internalLogger.ZLog(LogLevel.Debug, messageBuilder.GetFormattedText());
			}
		}

		public void Warning(in FVLogWarningInterpolationHandler messageBuilder)
		{
			if (messageBuilder.IsEnabled)
			{
				_internalLogger.ZLog(LogLevel.Warning, messageBuilder.GetFormattedText());
			}
		}

		public void Error(in FVLogErrorInterpolationHandler messageBuilder)
		{
			if (messageBuilder.IsEnabled)
			{
				_internalLogger.ZLog(LogLevel.Error, messageBuilder.GetFormattedText());
			}
		}

		public void Critical(in FVLogCriticalInterpolationHandler messageBuilder)
		{
			if (messageBuilder.IsEnabled)
			{
				_internalLogger.ZLog(LogLevel.Critical, messageBuilder.GetFormattedText());
			}
		}

		internal void Log(LogLevel level, string message)
		{
			if (!ShouldHideLog(level))
			{
				_internalLogger.ZLog(level, message);
			}
		}

		internal void LogNoCheck(LogLevel level, string message)
		{
			_internalLogger.ZLog(level, message);
		}

		internal void LogOnlyCheckCategory(LogLevel level, string message)
		{
			if (!ShouldHideCategory)
			{
				_internalLogger.ZLog(level, message);
			}
		}

		private static void AddUniqueLoggerName(string name)
		{
			if (Application.isEditor)
			{
				uniqueLoggerNames.Add(name);
				OnNewLoggerCreated?.Invoke(name);
			}
		}
	}
}
