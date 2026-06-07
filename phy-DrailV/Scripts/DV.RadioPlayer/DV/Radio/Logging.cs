using System;
using System.Diagnostics;
using UnityEngine;

namespace DV.Radio
{
	public static class Logging
	{
		[Conditional("ENABLE_LOGGING_RADIO")]
		public static void Log(string message, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.Log(message, context);
		}

		[Conditional("ENABLE_LOGGING_RADIO")]
		public static void LogWarning(string message, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogWarning(message, context);
		}

		[Conditional("ENABLE_LOGGING_RADIO")]
		public static void LogError(string message, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogError(message, context);
		}

		[Conditional("ENABLE_LOGGING_RADIO")]
		public static void LogException(Exception ex, UnityEngine.Object context = null)
		{
			UnityEngine.Debug.LogException(ex, context);
		}
	}
}
