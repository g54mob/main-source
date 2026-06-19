using UnityEngine;

namespace ModIO.Implementation
{
	internal static class Logger
	{
		internal const string ModioLogPrefix = "[mod.io]";

		private static LogMessageDelegate LogDelegate = UnityLogDelegate;

		internal static void SetLoggingDelegate(LogMessageDelegate loggingDelegate)
		{
			LogDelegate = loggingDelegate ?? new LogMessageDelegate(UnityLogDelegate);
		}

		internal static void ResetLoggingDelegate()
		{
			LogDelegate = UnityLogDelegate;
		}

		internal static void UnityLogDelegate(LogLevel logLevel, string logMessage)
		{
			if (!IsThisLogAboveMaxLogLevelSetting(logLevel))
			{
				switch (logLevel)
				{
				case LogLevel.Error:
					Debug.LogWarning(logMessage);
					break;
				case LogLevel.Warning:
					Debug.LogWarning(logMessage);
					break;
				case LogLevel.Message:
				case LogLevel.Verbose:
					Debug.Log(logMessage);
					break;
				}
			}
		}

		private static bool IsThisLogAboveMaxLogLevelSetting(LogLevel level)
		{
			if (Settings.build != null)
			{
				return level > Settings.build.logLevel;
			}
			return true;
		}

		internal static void Log(LogLevel logLevel, string logMessage)
		{
			logMessage = "[mod.io] " + logMessage;
			LogDelegate?.Invoke(logLevel, logMessage);
		}
	}
}
