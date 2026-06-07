using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.NativeUICore;

namespace VoxelBusters.EssentialKit
{
	public static class NativeUI
	{
		[ClearOnReload]
		private static INativeUIInterface s_nativeInterface;

		public static NativeUIUnitySettings UnitySettings { get; private set; }

		public static INativeUIInterface NativeInterface => null;

		public static void Initialize(NativeUIUnitySettings settings)
		{
		}

		public static void ShowAlertDialog(string title, string message, string preferredActionLabel, Callback preferredActionCallback = null, string cancelActionLabel = null, Callback cancelActionCallback = null)
		{
		}
	}
}
