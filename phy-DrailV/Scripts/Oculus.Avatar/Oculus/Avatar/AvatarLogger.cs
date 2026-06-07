using System.Diagnostics;
using UnityEngine;

namespace Oculus.Avatar
{
	public static class AvatarLogger
	{
		public const string LogAvatar = "[Avatars] - ";

		public const string Tab = "    ";

		[Conditional("ENABLE_AVATAR_LOGS")]
		[Conditional("ENABLE_AVATAR_LOG_BASIC")]
		public static void Log(string logMsg)
		{
			UnityEngine.Debug.Log("[Avatars] - " + logMsg);
		}

		[Conditional("ENABLE_AVATAR_LOGS")]
		[Conditional("ENABLE_AVATAR_LOG_BASIC")]
		public static void Log(string logMsg, Object context)
		{
			UnityEngine.Debug.Log("[Avatars] - " + logMsg, context);
		}

		[Conditional("ENABLE_AVATAR_LOGS")]
		[Conditional("ENABLE_AVATAR_LOG_WARNING")]
		public static void LogWarning(string logMsg)
		{
			UnityEngine.Debug.LogWarning("[Avatars] - " + logMsg);
		}

		[Conditional("ENABLE_AVATAR_LOGS")]
		[Conditional("ENABLE_AVATAR_LOG_ERROR")]
		public static void LogError(string logMsg)
		{
			UnityEngine.Debug.LogError("[Avatars] - " + logMsg);
		}

		[Conditional("ENABLE_AVATAR_LOGS")]
		[Conditional("ENABLE_AVATAR_LOG_ERROR")]
		public static void LogError(string logMsg, Object context)
		{
			UnityEngine.Debug.LogError("[Avatars] - " + logMsg, context);
		}
	}
}
