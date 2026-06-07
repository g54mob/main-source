using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NetworkServicesCore
{
	internal sealed class NullNetworkServicesInterface : NativeNetworkServicesInterfaceBase, INativeNetworkServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullNetworkServicesInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override void StartNotifier()
		{
		}

		public override void StopNotifier()
		{
		}
	}
}
