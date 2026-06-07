using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class ApplicationServices
	{
		private static float s_originalTimeScale;

		static ApplicationServices()
		{
		}

		[ExecuteOnReload]
		private static void Initialize()
		{
		}

		public static void SetApplicationPaused(bool pause)
		{
		}

		public static RuntimePlatform GetActivePlatform()
		{
			return default(RuntimePlatform);
		}

		public static RuntimePlatform GetActiveOrSimulationPlatform()
		{
			return default(RuntimePlatform);
		}

		public static bool IsPlayingOrSimulatingMobilePlatform()
		{
			return false;
		}
	}
}
