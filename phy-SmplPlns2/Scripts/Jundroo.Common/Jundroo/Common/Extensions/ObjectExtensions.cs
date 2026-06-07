using System;
using System.Diagnostics;
using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class ObjectExtensions
	{
		public static void Log(this UnityEngine.Object obj, string message, params object[] args)
		{
			if (args == null || args.Length == 0)
			{
				UnityEngine.Debug.Log(message, obj);
			}
			else
			{
				UnityEngine.Debug.LogFormat(obj, message, args);
			}
		}

		public static void LogError(this UnityEngine.Object obj, string message, params object[] args)
		{
			if (args == null || args.Length == 0)
			{
				UnityEngine.Debug.LogError(message, obj);
			}
			else
			{
				UnityEngine.Debug.LogErrorFormat(obj, message, args);
			}
		}

		public static void LogException(this UnityEngine.Object obj, string message, params object[] args)
		{
			if (args != null && args.Length != 0)
			{
				message = string.Format(message, args);
			}
			UnityEngine.Debug.LogException(new Exception(message), obj);
		}

		public static void LogException(this UnityEngine.Object obj, Exception innerException, string message, params object[] args)
		{
			if (args != null && args.Length != 0)
			{
				message = string.Format(message, args);
			}
			UnityEngine.Debug.LogException(new Exception(message, innerException), obj);
		}

		public static void LogException(this UnityEngine.Object obj, Exception exception)
		{
			UnityEngine.Debug.LogException(exception, obj);
		}

		[Conditional("DEBUG")]
		[Conditional("UNITY_EDITOR")]
		public static void LogVerbose(this UnityEngine.Object obj, string message, params object[] args)
		{
			if (args != null && args.Length != 0)
			{
				message = string.Format(message, args);
			}
			UnityEngine.Debug.Log("<color=grey>[VERBOSE]</color> " + message, obj);
		}

		public static void LogWarning(this UnityEngine.Object obj, string message, params object[] args)
		{
			if (args == null || args.Length == 0)
			{
				UnityEngine.Debug.LogWarning(message, obj);
			}
			else
			{
				UnityEngine.Debug.LogWarningFormat(obj, message, args);
			}
		}
	}
}
