using System;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public class Logger
	{
		public delegate void LogCallback(string msg, LogLevel logLevel);

		public enum LogLevel
		{
			Log = 0,
			Warning = 1,
			Error = 2,
			Message = 3,
			NoLogs = 99
		}

		public const string Prefix = "UGUIOutline: ";

		public static LogLevel CurrentLogLevel = LogLevel.Warning;

		public static Func<LogLevel> OnGetLogLevel = null;

		public static bool IsLogLevelVisible(LogLevel logLevel)
		{
			return logLevel >= CurrentLogLevel;
		}

		public static void UpdateCurrentLogLevel()
		{
			if (OnGetLogLevel != null)
			{
				CurrentLogLevel = OnGetLogLevel();
			}
		}

		public static void Log(string message)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Log))
			{
				Debug.Log("UGUIOutline: " + message);
			}
		}

		public static void LogWarning(string message)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Warning))
			{
				Debug.LogWarning("UGUIOutline: " + message);
			}
		}

		public static void LogError(string message)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Error))
			{
				Debug.LogError("UGUIOutline: " + message);
			}
		}

		public static void LogMessage(string message)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Message))
			{
				Debug.Log("UGUIOutline: " + message);
			}
		}
	}
}
