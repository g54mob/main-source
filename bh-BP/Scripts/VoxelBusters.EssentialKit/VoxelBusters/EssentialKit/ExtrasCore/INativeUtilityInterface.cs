using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.ExtrasCore
{
	public interface INativeUtilityInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		void OpenAppStorePage(string applicationId);

		void OpenApplicationSettings();
	}
}
