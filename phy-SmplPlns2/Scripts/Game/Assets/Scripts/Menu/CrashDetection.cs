using UnityEngine;

namespace Assets.Scripts.Menu
{
	internal class CrashDetection
	{
		private const string PlayerPrefKeyName = "CrashDetection";

		public static bool FlagStatus => PlayerPrefs.GetInt("CrashDetection", 0) > 0;

		public static void ClearFlag()
		{
			PlayerPrefs.SetInt("CrashDetection", 0);
		}

		public static void SetFlag()
		{
			PlayerPrefs.SetInt("CrashDetection", 1);
		}
	}
}
