namespace VoxelBusters.EssentialKit
{
	public class NetworkServicesInternetConnectivityStatusChangeResult
	{
		public bool IsConnected { get; private set; }

		internal NetworkServicesInternetConnectivityStatusChangeResult(bool isConnected)
		{
		}
	}
}
