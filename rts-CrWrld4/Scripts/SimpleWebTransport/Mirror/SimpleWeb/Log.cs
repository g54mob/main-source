using System;

namespace Mirror.SimpleWeb
{
	public static class Log
	{
		public enum Levels
		{
			none = 0,
			error = 1,
			warn = 2,
			info = 3,
			verbose = 4
		}

		private const string SIMPLEWEB_LOG_ENABLED = "SIMPLEWEB_LOG_ENABLED";

		private const string DEBUG = "DEBUG";

		public static Levels level;

		public static string BufferToString(byte[] buffer, int offset = 0, int? length = null)
		{
			return null;
		}

		public static void DumpBuffer(string label, byte[] buffer, int offset, int length)
		{
		}

		public static void DumpBuffer(string label, ArrayBuffer arrayBuffer)
		{
		}

		public static void Verbose(string msg, bool showColor = true)
		{
		}

		public static void Info(string msg, bool showColor = true)
		{
		}

		public static void InfoException(Exception e)
		{
		}

		public static void Warn(string msg, bool showColor = true)
		{
		}

		public static void Error(string msg, bool showColor = true)
		{
		}

		public static void Exception(Exception e)
		{
		}
	}
}
