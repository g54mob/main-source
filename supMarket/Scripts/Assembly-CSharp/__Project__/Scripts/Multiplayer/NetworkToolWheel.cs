using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkToolWheel : NoktaSingletonPunCallbacks<NetworkToolWheel>
	{
		public void OnToolSelected_Broadcast(string toolName)
		{
		}

		[PunRPC]
		public void OnToolSelected_RPC(string userId, string toolName)
		{
		}

		private void Start()
		{
		}

		private void OnSyncRequest(string userId)
		{
		}

		[PunRPC]
		public void SyncToolWheelStatus_RPC(bool isCrateAvailable, bool isBatAvailable, bool isTabletAvailable)
		{
		}

		public void BuyBat_Broadcast()
		{
		}

		[PunRPC]
		public void BuyBat_RPC()
		{
		}

		public void BuyCrate_Broadcast()
		{
		}

		[PunRPC]
		public void BuyCrate_RPC()
		{
		}
	}
}
