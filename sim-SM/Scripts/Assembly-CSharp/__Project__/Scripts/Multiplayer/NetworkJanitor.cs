using Photon.Pun;
using __Project__.Scripts.Janitor;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkJanitor : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
	{
		private __Project__.Scripts.Janitor.Janitor m_Janitor;

		public __Project__.Scripts.Janitor.Janitor Janitor => null;

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}

		private void Start()
		{
		}

		private void OnSyncRequest(string userID)
		{
		}

		[PunRPC]
		public void SyncJanitorData_RPC(float boostAmount)
		{
		}

		public void SwitchThrashBag_Broadcast(bool willEnable)
		{
		}

		[PunRPC]
		public void SwitchThrashBag_RPC(bool willEnable)
		{
		}

		public void FinishMopCleaning_Broadcast()
		{
		}

		[PunRPC]
		public void FinishMopCleaning_RPC()
		{
		}

		public void CleanDirt_Broadcast(Dirt dirt)
		{
		}

		[PunRPC]
		public void CleanDirt_RPC(int dirtID)
		{
		}

		public void CleanDust_Broadcast(Dust dust)
		{
		}

		[PunRPC]
		public void CleanDust_RPC(int dustId)
		{
		}

		public void FinishDustCleaning_Broadcast()
		{
		}

		[PunRPC]
		public void FinishDustCleaning_RPC()
		{
		}

		public void Boost_Broadcast()
		{
		}

		[PunRPC]
		public void BoostJanitor_RPC()
		{
		}
	}
}
