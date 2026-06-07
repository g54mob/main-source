using System;
using UnityEngine;

namespace Gh
{
	public static class DebugX
	{
		private static bool _isCurrentErrorQuiet;

		private static readonly string[] IgnoredErrorMessageBeginnings;

		public static void LogEditorError(object message, UnityEngine.Object context = null)
		{
		}

		public static void LogExceptionQuietly(Exception e)
		{
		}

		public static void LogErrorQuietly(string error)
		{
		}

		public static bool IsCurrentErrorQuiet(string errorMessage = null)
		{
			return false;
		}
	}
}
