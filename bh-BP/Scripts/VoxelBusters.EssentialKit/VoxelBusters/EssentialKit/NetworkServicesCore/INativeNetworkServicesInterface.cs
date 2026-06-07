using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NetworkServicesCore
{
	public interface INativeNetworkServicesInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		event InternetConnectivityChangeInternalCallback OnInternetConnectivityChange;

		event HostReachabilityChangeInternalCallback OnHostReachabilityChange;

		void StartNotifier();

		void StopNotifier();
	}
}
