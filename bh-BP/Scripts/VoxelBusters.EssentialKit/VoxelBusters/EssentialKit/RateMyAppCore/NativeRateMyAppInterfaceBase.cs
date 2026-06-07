using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.RateMyAppCore
{
	public abstract class NativeRateMyAppInterfaceBase : NativeFeatureInterfaceBase, INativeRateMyAppInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		protected NativeRateMyAppInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract void RequestStoreReview(string storeId = null);
	}
}
