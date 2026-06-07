using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
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

		public const string Prefix = "SettingsGenerator: ";

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

		public static void Log(string message, UnityEngine.Object context = null)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Log))
			{
				Debug.Log("SettingsGenerator: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > Settings Generator > Settings : LogLevel", context);
			}
		}

		public static void LogWarning(string message, UnityEngine.Object context = null)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Warning))
			{
				Debug.LogWarning("SettingsGenerator: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > Settings Generator > Settings : LogLevel", context);
			}
		}

		public static void LogError(string message, UnityEngine.Object context = null)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Error))
			{
				Debug.LogError("SettingsGenerator: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > Settings Generator > Settings : LogLevel", context);
			}
		}

		public static void LogMessage(string message, UnityEngine.Object context = null)
		{
			UpdateCurrentLogLevel();
			if (IsLogLevelVisible(LogLevel.Message))
			{
				Debug.Log("SettingsGenerator: " + message + "\nYou can change the verbosity of logs in the Settings under Tools > Settings Generator > Settings : LogLevel", context);
			}
		}
	}
}
