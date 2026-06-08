using System;

namespace Amazon.Util.Internal.PlatformServices
{
	public class NetworkReachability : INetworkReachability
	{
		public NetworkStatus NetworkStatus
		{
			get
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
		}

		public event EventHandler<NetworkStatusEventArgs> NetworkReachabilityChanged
		{
			add
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
			remove
			{
				throw new NotImplementedException("This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.");
			}
		}
	}
}
