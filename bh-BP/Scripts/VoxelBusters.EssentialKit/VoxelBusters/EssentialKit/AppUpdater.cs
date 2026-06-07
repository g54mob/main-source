using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.AppUpdaterCore;

namespace VoxelBusters.EssentialKit
{
	public static class AppUpdater
	{
		[ClearOnReload]
		private static INativeAppUpdaterInterface s_nativeInterface;

		public static AppUpdaterUnitySettings UnitySettings { get; private set; }

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(AppUpdaterUnitySettings settings)
		{
		}

		public static void RequestUpdateInfo(EventCallback<AppUpdaterUpdateInfo> callback)
		{
		}

		public static void PromptUpdate(PromptUpdateOptions options, EventCallback<float> callback)
		{
		}
	}
}
