using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public static class DTLog
	{
		public static void Log(object message)
		{
		}

		public static void Log(object message, [CanBeNull] UnityEngine.Object context)
		{
		}

		public static void LogError(object message)
		{
		}

		public static void LogError(object message, [CanBeNull] UnityEngine.Object context)
		{
		}

		public static void LogErrorFormat(string format, params object[] args)
		{
		}

		public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args)
		{
		}

		public static void LogException(Exception exception)
		{
		}

		public static void LogException(Exception exception, [CanBeNull] UnityEngine.Object context)
		{
		}

		public static void LogFormat(string format, params object[] args)
		{
		}

		public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
		{
		}

		public static void LogWarning(object message)
		{
		}

		public static void LogWarning(object message, [CanBeNull] UnityEngine.Object context)
		{
		}

		public static void LogWarningFormat(string format, params object[] args)
		{
		}

		public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
		{
		}
	}
}
