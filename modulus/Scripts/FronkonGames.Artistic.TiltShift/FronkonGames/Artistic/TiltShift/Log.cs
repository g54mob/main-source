using UnityEngine;

namespace FronkonGames.Artistic.TiltShift
{
	internal static class Log
	{
		public static void Info(string message)
		{
			Debug.Log("[FronkonGames.Artistic.TiltShift] " + message + ".");
		}

		public static void Warning(string message)
		{
			Debug.LogWarning("[FronkonGames.Artistic.TiltShift] " + message + ".");
		}

		public static void Error(string message)
		{
			Debug.LogError("[FronkonGames.Artistic.TiltShift] " + message + " Please contact with 'fronkongames@gmail.com' and send the log file.");
		}
	}
}
