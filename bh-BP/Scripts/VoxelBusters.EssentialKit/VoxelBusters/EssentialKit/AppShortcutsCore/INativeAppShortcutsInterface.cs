using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AppShortcutsCore
{
	public interface INativeAppShortcutsInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		event ShortcutClickedInternalCallback OnShortcutClicked;

		void Add(AppShortcutItem item);

		void Remove(string shortcutItemId);
	}
}
