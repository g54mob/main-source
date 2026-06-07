using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.ExtrasCore;

namespace VoxelBusters.EssentialKit
{
	public static class Utilities
	{
		[ClearOnReload]
		private static INativeUtilityInterface s_nativeInterface;

		public static void Initialize(UtilityUnitySettings settings)
		{
		}

		public static void OpenAppStorePage()
		{
		}

		public static void OpenAppStorePage(params RuntimePlatformConstant[] applicationIds)
		{
		}

		public static void OpenAppStorePage(string applicationId)
		{
		}

		public static void OpenApplicationSettings()
		{
		}
	}
}
