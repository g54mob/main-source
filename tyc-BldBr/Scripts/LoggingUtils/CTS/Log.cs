using System.Diagnostics;
using UnityEngine;

namespace CTS
{
	public static class Log
	{
		private static ELogType _enabledLogs = (ELogType)(-1);

		private static bool _enabled = true;

		public const string STG_LOGS_NAME = "LogTypes";

		public const string STG_ENABLED_NAME = "LoggingEnabled";

		public const string MENU_PATH = "CTS/Logging/";

		public static ELogType EnabledLogs
		{
			get
			{
				return _enabledLogs;
			}
			set
			{
				_enabledLogs = value;
				PlayerPrefs.SetInt("LogTypes", (int)value);
			}
		}

		public static bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
				PlayerPrefs.SetInt("LoggingEnabled", value ? 1 : 0);
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		public static void Init()
		{
			Enabled = PlayerPrefs.GetInt("LoggingEnabled", 1) > 0;
			EnabledLogs = (ELogType)PlayerPrefs.GetInt("LogTypes", -1);
		}

		public static void ToggleLogging()
		{
			Enabled = !Enabled;
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Print(object p_message, bool p_enabled = true)
		{
			if (Enabled && p_enabled && EnabledLogs.HasFlag(ELogType.General))
			{
				Debug.Log($"[{ELogType.General}] {p_message}");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Print(object p_message, ELogType p_logType, bool p_enabled = true)
		{
			if (Enabled && p_enabled && EnabledLogs.HasFlag(p_logType))
			{
				Debug.Log($"[{p_logType}] {p_message}");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Warning(object p_message, bool p_enabled = true)
		{
			if (Enabled && p_enabled && EnabledLogs.HasFlag(ELogType.General))
			{
				Debug.LogWarning($"[{ELogType.General}] {p_message}");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Warning(object p_message, ELogType p_logType, bool p_enabled = true)
		{
			if (Enabled && p_enabled && EnabledLogs.HasFlag(p_logType))
			{
				Debug.LogWarning($"[{p_logType}] {p_message}");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Error(object p_message, bool p_enabled = true)
		{
			if (Enabled && p_enabled && EnabledLogs.HasFlag(ELogType.General))
			{
				Debug.LogError($"[{ELogType.General}] {p_message}");
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void Error(object p_message, ELogType p_logType, bool p_enabled = true)
		{
			if (Enabled && p_enabled && EnabledLogs.HasFlag(p_logType))
			{
				Debug.LogError($"[{p_logType}] {p_message}");
			}
		}
	}
}
