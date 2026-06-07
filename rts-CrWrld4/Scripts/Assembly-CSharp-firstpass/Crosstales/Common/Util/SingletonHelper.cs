using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crosstales.Common.Util
{
	public class SingletonHelper
	{
		private static bool isInitialized;

		public static bool isQuitting { get; set; }

		static SingletonHelper()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void initialize()
		{
		}

		private static void onSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private static void onSceneUnloaded(Scene scene)
		{
		}

		private static void onQuitting()
		{
		}
	}
}
