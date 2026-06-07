using System.Diagnostics;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class AssertUtility
	{
		public static bool DisableFrameCount { get; set; }

		[Conditional("DEBUG")]
		[Conditional("UNITY_EDITOR")]
		public static void LogAssert(string messageFormat, params object[] args)
		{
			UnityEngine.Debug.LogError(string.Format("(frame: " + GetFrameCount() + ") - " + messageFormat, args));
		}

		private static string GetFrameCount()
		{
			if (!DisableFrameCount)
			{
				return GetUnityFrameCount();
			}
			return "n/a";
		}

		private static string GetUnityFrameCount()
		{
			return Time.frameCount.ToString();
		}
	}
}
