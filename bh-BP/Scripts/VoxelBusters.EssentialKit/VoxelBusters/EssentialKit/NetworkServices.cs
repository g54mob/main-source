using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.NetworkServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class NetworkServices
	{
		[ClearOnReload]
		private static INativeNetworkServicesInterface s_nativeInterface;

		public static NetworkServicesUnitySettings UnitySettings { get; private set; }

		public static bool IsInternetActive { get; private set; }

		public static bool IsHostReachable { get; private set; }

		public static bool IsNotifierActive { get; private set; }

		public static event Callback<NetworkServicesInternetConnectivityStatusChangeResult> OnInternetConnectivityChange
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

		public static event Callback<NetworkServicesHostReachabilityStatusChangeResult> OnHostReachabilityChange
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

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(NetworkServicesUnitySettings settings)
		{
		}

		public static void StartNotifier()
		{
		}

		public static void StopNotifier()
		{
		}

		private static void RegisterForEvents()
		{
		}

		private static void UnregisterFromEvents()
		{
		}

		private static void HandleInternetConnectivityChangeInternalCallback(bool isConnected)
		{
		}

		private static void HandleHostReachabilityChangeInternalCallback(bool isReachable)
		{
		}
	}
}
