using System;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class DebugLogger
	{
		public enum LogLevel
		{
			Info = 0,
			Warning = 1,
			Error = 2,
			Critical = 3,
			None = 4
		}

		private const string kDefaultTag = "VoxelBusters";

		private static Dictionary<string, LogLevel> TagLevelMap { get; set; }

		private static LogLevel DefaultLogLevel { get; set; }

		static DebugLogger()
		{
		}

		public static void SetLogLevel(LogLevel value, params string[] tags)
		{
		}

		public static void Log(string message, UnityEngine.Object context = null)
		{
		}

		public static void Log(string tag, string message, UnityEngine.Object context = null)
		{
		}

		public static void LogWarning(string message, UnityEngine.Object context = null)
		{
		}

		public static void LogWarning(string tag, string message, UnityEngine.Object context = null)
		{
		}

		public static void LogError(string message, UnityEngine.Object context = null)
		{
		}

		public static void LogError(string tag, string message, UnityEngine.Object context = null)
		{
		}

		public static void LogException(Exception exception, UnityEngine.Object context = null)
		{
		}

		public static void LogException(string tag, Exception exception, UnityEngine.Object context = null)
		{
		}

		[Obsolete("This method is deprecated. Use Log instead.", false)]
		public static void LogFormat(string format, params object[] arguments)
		{
		}

		[Obsolete("This method is deprecated. Use Log instead.", false)]
		public static void LogFormat(UnityEngine.Object context, string format, params object[] arguments)
		{
		}

		[Obsolete("This method is deprecated. Use LogWarning instead.", false)]
		public static void LogWarningFormat(string format, params object[] arguments)
		{
		}

		[Obsolete("This method is deprecated. Use LogWarning instead.", false)]
		public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] arguments)
		{
		}

		[Obsolete("This method is deprecated. Use LogError instead.", false)]
		public static void LogErrorFormat(string format, params object[] arguments)
		{
		}

		[Obsolete("This method is deprecated. Use LogError instead.", false)]
		public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] arguments)
		{
		}

		private static bool IgnoreLog(LogLevel level, string tag = null)
		{
			return false;
		}
	}
}
