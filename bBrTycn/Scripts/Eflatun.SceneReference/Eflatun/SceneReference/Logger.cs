using UnityEngine;

namespace Eflatun.SceneReference
{
	internal static class Logger
	{
		internal static void Debug(string msg)
		{
			UnityEngine.Debug.Log("[Eflatun.SceneReference] " + msg);
		}

		internal static void Warn(string msg)
		{
			UnityEngine.Debug.LogWarning("[Eflatun.SceneReference] " + msg);
		}

		internal static void Error(string msg)
		{
			UnityEngine.Debug.LogError("[Eflatun.SceneReference] " + msg);
		}
	}
}
