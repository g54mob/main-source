using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit
{
	public interface INativeRateMyAppInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		void RequestStoreReview(string storeId = null);
	}
}
