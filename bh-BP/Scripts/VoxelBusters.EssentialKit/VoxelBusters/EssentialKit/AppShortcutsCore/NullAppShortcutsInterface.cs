using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AppShortcutsCore
{
	internal class NullAppShortcutsInterface : NativeFeatureInterfaceBase, INativeAppShortcutsInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public event ShortcutClickedInternalCallback OnShortcutClicked
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

		public NullAppShortcutsInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public void Add(AppShortcutItem item)
		{
		}

		public void Remove(string shortcutId)
		{
		}
	}
}
