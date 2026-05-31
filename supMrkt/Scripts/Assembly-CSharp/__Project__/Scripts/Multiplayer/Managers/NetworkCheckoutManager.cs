using Photon.Pun;

namespace __Project__.Scripts.Multiplayer.Managers
{
	public class NetworkCheckoutManager : NoktaSingletonPunCallbacks<NetworkCheckoutManager>
	{
		private void Start()
		{
		}

		public void OnSyncRequest_Broadcast(string userId)
		{
		}

		public void SyncCheckoutCount_Broadcast()
		{
		}

		[PunRPC]
		public void SyncCompletedCheckoutCount_RPC(int count)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
