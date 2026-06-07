using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NetworkServicesCore
{
	public abstract class NativeNetworkServicesInterfaceBase : NativeFeatureInterfaceBase, INativeNetworkServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public event InternetConnectivityChangeInternalCallback OnInternetConnectivityChange
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

		public event HostReachabilityChangeInternalCallback OnHostReachabilityChange
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

		protected NativeNetworkServicesInterfaceBase(bool isAvailable)
			: base(isAvailable: false)
		{
		}

		public abstract void StartNotifier();

		public abstract void StopNotifier();

		protected void SendInternetConnectivityChangeEvent(bool isConnected)
		{
		}

		protected void SendHostReachabilityChangeEvent(bool isReachable)
		{
		}
	}
}
