using System;

namespace MyBox.Internal
{
	public static class MyLogger
	{
		private static string LogFile;

		private static string TimeFormat;

		public static bool Disabled;

		public const string DefaultFilename = "customLog.txt";

		public const string DefaultTimeFormat = "MM-dd_HH-mm-ss";

		private const int MaxMessageLength = 4000;

		public static string Session { get; private set; }

		public static string Version { get; private set; }

		public static bool LogToConsole { get; set; }

		static MyLogger()
		{
		}

		public static void InitializeSession(string version = null, string filename = "customLog.txt", string timeFormat = "MM-dd_HH-mm-ss", bool logToConsole = false)
		{
		}

		public static void Log(string text, bool withStackTrace = false, bool logToConsole = true)
		{
		}

		private static void LogException(Exception ex)
		{
		}
	}
}
