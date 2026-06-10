namespace ModIO.Implementation
{
	internal static class Logger
	{
		internal const string ModioLogPrefix = "[mod.io]";

		private static LogMessageDelegate LogDelegate;

		internal static void SetLoggingDelegate(LogMessageDelegate loggingDelegate)
		{
		}

		internal static void ResetLoggingDelegate()
		{
		}

		internal static void UnityLogDelegate(LogLevel logLevel, string logMessage)
		{
		}

		private static bool IsThisLogAboveMaxLogLevelSetting(LogLevel level)
		{
			return false;
		}

		internal static void Log(LogLevel logLevel, string logMessage)
		{
		}
	}
}
