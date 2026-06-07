using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.AppShortcutsCore;

namespace VoxelBusters.EssentialKit
{
	public static class AppShortcuts
	{
		[ClearOnReload]
		private static INativeAppShortcutsInterface s_nativeInterface;

		public static AppShortcutsUnitySettings UnitySettings { get; private set; }

		public static event Callback<string> OnShortcutClicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(AppShortcutsUnitySettings settings)
		{
		}

		public static void Add(AppShortcutItem item)
		{
		}

		public static void Remove(string shortcutItemId)
		{
		}
	}
}
