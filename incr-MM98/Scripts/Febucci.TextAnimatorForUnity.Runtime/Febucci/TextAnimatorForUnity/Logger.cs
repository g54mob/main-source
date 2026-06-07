using System.Diagnostics;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	public static class Logger
	{
		private const string PREFIX = "[TextAnimatorForUnity] ";

		[Conditional("FEBUCCI_TEXT_ANIMATOR_DEBUG")]
		public static void Debug(string text, Object context = null)
		{
			UnityEngine.Debug.Log("[TextAnimatorForUnity] " + text, context);
		}

		[Conditional("FEBUCCI_TEXT_ANIMATOR_DEBUG")]
		public static void DebugError(string text, Object context = null)
		{
			UnityEngine.Debug.LogError("[TextAnimatorForUnity] " + text, context);
		}

		public static void Log(string text, Object context = null)
		{
			UnityEngine.Debug.Log("[TextAnimatorForUnity] " + text, context);
		}

		public static void Warning(string text, Object context = null)
		{
			UnityEngine.Debug.LogWarning("[TextAnimatorForUnity] " + text, context);
		}

		public static void Error(string text, Object context = null)
		{
			UnityEngine.Debug.LogError("[TextAnimatorForUnity] " + text, context);
		}
	}
}
