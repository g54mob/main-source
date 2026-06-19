using UnityEngine;

namespace OpenBLive.Runtime.Utilities
{
	public static class Logger
	{
		public static void LogError(string logInfo)
		{
			Debug.LogError(logInfo);
		}

		public static void Log(string logInfo)
		{
			Debug.Log(logInfo);
		}
	}
}
