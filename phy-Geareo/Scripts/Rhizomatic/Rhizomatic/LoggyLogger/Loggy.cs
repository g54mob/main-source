using System;

namespace Rhizomatic.LoggyLogger
{
	public static class Loggy
	{
		public static Logger _logger;

		public static Logger logger => null;

		public static void Init()
		{
		}

		public static void Dispose()
		{
		}

		public static void Log(string message, object data = null)
		{
		}

		public static void LogInfo(string message, object data = null)
		{
		}

		public static void LogWarn(string message, object data = null)
		{
		}

		public static void LogError(string message, object data = null)
		{
		}

		public static void LogError(Exception exception, object data = null)
		{
		}

		public static void LogFatal(string message, object data = null)
		{
		}

		public static void LogFatal(Exception exception, object data = null)
		{
		}
	}
}
