using System;
using System.Collections.Generic;
using UnityEngine;

namespace FractureField
{
	public static class Logger
	{
		[HideInCallstack]
		public static void Log(List<object> parts, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void Log(object message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogDebug(object message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogWarning(object message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogError(object message, LoggerOptions options = null)
		{
		}

		[HideInCallstack]
		public static void LogException(Exception ex, LoggerOptions options = null)
		{
		}

		public static string FormatMessage(object message, LoggerOptions options = null)
		{
			return null;
		}
	}
}
