using System;
using UnityEngine;

namespace Dhs5.Utility.Debuggers
{
	public class Debugger<DebugEnum> where DebugEnum : Enum
	{
		public static void ComplexLog(DebugEnum e, object message, LogType logType, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			BaseDebugger.ComplexLog(e, message, logType, level, onScreen, context);
		}

		public static void Log(DebugEnum e, object message, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			BaseDebugger.Log(e, message, level, onScreen, context);
		}

		public static void LogWarning(DebugEnum e, object message, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			BaseDebugger.LogWarning(e, message, level, onScreen, context);
		}

		public static void LogError(DebugEnum e, object message, bool onScreen = true, UnityEngine.Object context = null)
		{
			BaseDebugger.LogError(e, message, onScreen, context);
		}

		public static void LogAlways(DebugEnum e, object message, LogType logType = LogType.Error, bool onScreen = true, UnityEngine.Object context = null)
		{
			BaseDebugger.LogAlways(e, message, logType, onScreen, context);
		}

		public static void LogOnScreen(DebugEnum e, object message, LogType logType = LogType.Log, int level = 2, float duration = 5f)
		{
			BaseDebugger.LogOnScreen(e, message, logType, level, duration);
		}
	}
}
