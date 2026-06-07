using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.ExtrasCore
{
	public abstract class NativeUtilityInterfaceBase : NativeFeatureInterfaceBase, INativeUtilityInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		protected NativeUtilityInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract void OpenAppStorePage(string applicationId);

		public abstract void OpenApplicationSettings();
	}
}
