using UnityEngine;

namespace Brewery.Steam
{
	public static class SteamInitializer
	{
		public static bool Initialized { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void AutoInitialize()
		{
		}
	}
}
