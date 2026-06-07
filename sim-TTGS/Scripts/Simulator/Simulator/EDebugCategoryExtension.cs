using Dhs5.Utility.Databases;
using Dhs5.Utility.Debuggers;
using UnityEngine;

namespace Simulator
{
	public static class EDebugCategoryExtension
	{
		public static DebuggerDatabaseElement GetValue(this EDebugCategory e)
		{
			return Database.Get<DebuggerDatabase>().GetDataAtIndex<DebuggerDatabaseElement>((int)e);
		}

		public static bool Contains(this EDebugCategoryFlags flag, EDebugCategory e)
		{
			return ((uint)flag & (uint)(1 << (int)e)) != 0;
		}

		public static bool Contains(this EDebugCategoryFlags flag, EDebugCategoryFlags other)
		{
			return (flag & other) != 0;
		}

		public static void Log(this EDebugCategory category, object message, int level = 2, bool onScreen = false, Object context = null)
		{
			Debugger<EDebugCategory>.Log(category, message, level, onScreen, context);
		}

		public static void LogWarning(this EDebugCategory category, object message, int level = 2, bool onScreen = false, Object context = null)
		{
			Debugger<EDebugCategory>.LogWarning(category, message, level, onScreen, context);
		}

		public static void LogError(this EDebugCategory category, object message, bool onScreen = true, Object context = null)
		{
			Debugger<EDebugCategory>.LogError(category, message, onScreen, context);
		}

		public static void LogAlways(this EDebugCategory category, object message, LogType logType = LogType.Error, bool onScreen = true, Object context = null)
		{
			Debugger<EDebugCategory>.LogAlways(category, message, logType, onScreen, context);
		}

		public static void LogOnScreen(this EDebugCategory category, object message, LogType logType = LogType.Log, int level = 2, float duration = 5f)
		{
			Debugger<EDebugCategory>.LogOnScreen(category, message, logType, level, duration);
		}
	}
}
