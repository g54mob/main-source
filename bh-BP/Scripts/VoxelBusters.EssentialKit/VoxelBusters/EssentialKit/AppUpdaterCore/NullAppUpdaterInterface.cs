using System;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.AppUpdaterCore
{
	internal class NullAppUpdaterInterface : NativeFeatureInterfaceBase, INativeAppUpdaterInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullAppUpdaterInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public void RequestUpdateInfo(EventCallback<AppUpdaterUpdateInfo> callback)
		{
		}

		public void PromptUpdate(PromptUpdateOptions options, EventCallback<float> callback)
		{
		}
	}
}
