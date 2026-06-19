using System;

namespace TH20
{
	public static class LogLevelHelpers
	{
		public static readonly string[] LogLevelNames = new string[6] { "Verbose", "Debug", "Information", "Warning", "Error", "Information" };

		public static readonly string[] LogLevel3CharStrings = new string[6] { "VER", "DBG", "INF", "WRN", "ERR", "INF" };

		public static readonly string[] LogLevel4CharStrings = new string[6] { "VERB", "DEBG", "INFO", "WARN", "ERRR", "INFO" };

		public static readonly LogLevel LowestLogLevelCompiledIn = LogLevel.Information;

		public static readonly bool[] LogLevelIsCompiledIn = new bool[6] { false, false, true, true, true, true };

		public static string ToString(LogLevel level)
		{
			if (level < LogLevel.Verbose || (int)level > LogLevelNames.Length)
			{
				throw new ArgumentOutOfRangeException("level", level, null);
			}
			return LogLevelNames[(int)level];
		}

		public static string To3CharString(LogLevel level)
		{
			if (level < LogLevel.Verbose || (int)level > LogLevelNames.Length)
			{
				throw new ArgumentOutOfRangeException("level", level, null);
			}
			return LogLevel3CharStrings[(int)level];
		}

		public static string To4CharString(LogLevel level)
		{
			if (level < LogLevel.Verbose || (int)level > LogLevelNames.Length)
			{
				throw new ArgumentOutOfRangeException("level", level, null);
			}
			return LogLevel4CharStrings[(int)level];
		}

		public static bool IsLogLevelCompiledIn(LogLevel level)
		{
			if (level < LogLevel.Verbose || (int)level > LogLevelNames.Length)
			{
				throw new ArgumentOutOfRangeException("level", level, null);
			}
			return LogLevelIsCompiledIn[(int)level];
		}
	}
}
