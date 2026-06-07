using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.DeepLinkServicesCore
{
	public class NullDeepLinkServicesInterface : NativeDeepLinkServicesInterfaceBase, INativeDeepLinkServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullDeepLinkServicesInterface()
			: base(isAvailable: false)
		{
		}

		public override void Init()
		{
		}
	}
}
