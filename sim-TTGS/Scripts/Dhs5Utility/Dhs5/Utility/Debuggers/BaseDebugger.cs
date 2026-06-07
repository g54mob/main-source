using System;
using System.Text;
using UnityEngine;

namespace Dhs5.Utility.Debuggers
{
	public static class BaseDebugger
	{
		public const int MAX_DEBUGGER_LEVEL = 2;

		public const float DEFAULT_SCREEN_LOG_DURATION = 5f;

		private static DebuggerDatabaseElement GetElement(Enum e)
		{
			return DebuggerDatabase.GetAtIndex(Convert.ToInt32(e));
		}

		private static DebuggerDatabaseElement GetElement(int index)
		{
			return DebuggerDatabase.GetAtIndex(index);
		}

		private static bool CanLog(Enum e, LogType logType, int level, out DebuggerDatabaseElement element)
		{
			element = GetElement(e);
			if (element != null)
			{
				return element.CanLog(logType, level);
			}
			return false;
		}

		private static bool CanLog(int index, LogType logType, int level, out DebuggerDatabaseElement element)
		{
			element = GetElement(index);
			if (element != null)
			{
				return element.CanLog(logType, level);
			}
			return false;
		}

		private static string CategorizeMessage(object message, int level, DebuggerDatabaseElement element, bool onScreen = false)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int value = (onScreen ? DebuggerSettings.GetScreenLogSize(level) : DebuggerSettings.GetConsoleLogSize(level));
			stringBuilder.Append("<size=");
			stringBuilder.Append(value);
			stringBuilder.Append(">");
			stringBuilder.Append("<color=#");
			stringBuilder.Append(element.ColorString);
			stringBuilder.Append("><b>");
			stringBuilder.Append(element.name);
			stringBuilder.Append(" ");
			for (int i = 0; i < 3 - level; i++)
			{
				stringBuilder.Append(">");
			}
			stringBuilder.Append("</b></color> ");
			stringBuilder.Append(message);
			stringBuilder.Append("</size>");
			return stringBuilder.ToString();
		}

		internal static void ComplexLog(Enum e, object message, LogType logType, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			if (CanLog(e, logType, level, out var element))
			{
				Internal_Log(message, logType, element, level, onScreen, context);
			}
		}

		internal static void ComplexLog(int index, object message, LogType logType, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			if (CanLog(index, logType, level, out var element))
			{
				Internal_Log(message, logType, element, level, onScreen, context);
			}
		}

		internal static void Log(Enum e, object message, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			LogType logType = LogType.Log;
			if (CanLog(e, logType, level, out var element))
			{
				Internal_Log(message, logType, element, level, onScreen, context);
			}
		}

		internal static void LogWarning(Enum e, object message, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			LogType logType = LogType.Warning;
			if (CanLog(e, logType, level, out var element))
			{
				Internal_Log(message, logType, element, level, onScreen, context);
			}
		}

		internal static void LogError(Enum e, object message, bool onScreen = true, UnityEngine.Object context = null)
		{
			LogType logType = LogType.Error;
			int level = 0;
			if (CanLog(e, logType, level, out var element))
			{
				Internal_Log(message, logType, element, level, onScreen, context);
			}
		}

		internal static void LogAlways(Enum e, object message, LogType logType = LogType.Error, bool onScreen = true, UnityEngine.Object context = null)
		{
			DebuggerDatabaseElement element = GetElement(e);
			if (element != null)
			{
				Internal_Log(message, logType, element, 0, onScreen, context);
			}
		}

		internal static void LogOnScreen(Enum e, object message, LogType logType = LogType.Log, int level = 2, float duration = 5f)
		{
			DebuggerDatabaseElement element = GetElement(e);
			if (element != null)
			{
				Internal_LogOnScreen(message, element, logType, level, DebuggerSettings.DefaultScreenLogDuration);
			}
		}

		private static void Internal_Log(object message, LogType logType, DebuggerDatabaseElement element, int level, bool onScreen, UnityEngine.Object context)
		{
			string message2 = CategorizeMessage(message, level, element);
			if (element.ShowInConsole)
			{
				switch (logType)
				{
				case LogType.Log:
					Debug.Log(message2, context);
					break;
				case LogType.Warning:
					Debug.LogWarning(message2, context);
					break;
				case LogType.Error:
				case LogType.Assert:
				case LogType.Exception:
					Debug.LogError(message2, context);
					break;
				}
			}
			if (onScreen)
			{
				Internal_LogOnScreen(message, element, logType, level, DebuggerSettings.DefaultScreenLogDuration);
			}
		}

		private static void Internal_LogOnScreen(object message, DebuggerDatabaseElement element, LogType logType, int level, float duration)
		{
			if (element.ShowOnScreen && Application.isPlaying)
			{
				OnScreenDebugger.Log(CategorizeMessage(message, level, element, onScreen: true), logType, duration);
			}
		}
	}
}
