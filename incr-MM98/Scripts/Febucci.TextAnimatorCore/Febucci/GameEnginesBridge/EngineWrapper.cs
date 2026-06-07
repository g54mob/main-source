using UnityEngine;

namespace Febucci.GameEnginesBridge
{
	public static class EngineWrapper
	{
		public static bool IsPlaying => Application.isPlaying;

		public static void Log(string text)
		{
			Debug.Log(text);
		}

		public static void LogWarning(string text)
		{
			Debug.LogWarning(text);
		}

		public static void LogError(string text)
		{
			Debug.LogError(text);
		}
	}
}
