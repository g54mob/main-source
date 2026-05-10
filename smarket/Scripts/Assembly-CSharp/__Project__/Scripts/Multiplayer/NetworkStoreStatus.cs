using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkStoreStatus : NoktaSingletonPunCallbacks<NetworkStoreStatus>
	{
		public void OnStatusChanged_RequestMaster(bool value)
		{
		}

		public void StartDayCycle_RPC()
		{
		}

		[PunRPC]
		private void RPC_StartDayCycle()
		{
		}

		[PunRPC]
		public void OnStatusChanged_Broadcast(bool value)
		{
		}

		[PunRPC]
		public void OnStatusChangedInvoke(bool value)
		{
		}

		public void OnStoreOpened_Broadcast()
		{
		}

		public void OnStoreClosed_Broadcast()
		{
		}

		[PunRPC]
		public void OnStoreStatus_RPC(bool stat)
		{
		}
	}
}
