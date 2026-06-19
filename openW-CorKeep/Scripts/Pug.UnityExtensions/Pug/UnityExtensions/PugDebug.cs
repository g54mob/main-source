using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class PugDebug
	{
		public static void Log(params object[] objects)
		{
			Debug.Log(string.Join(" ", objects));
		}

		public static void LogError(params object[] objects)
		{
			Debug.LogError(string.Join(" ", objects));
		}

		public static void LogWarning(params object[] objects)
		{
			Debug.LogWarning(string.Join(" ", objects));
		}
	}
}
