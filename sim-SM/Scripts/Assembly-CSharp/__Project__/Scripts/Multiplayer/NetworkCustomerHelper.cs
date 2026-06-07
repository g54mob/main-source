using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkCustomerHelper : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
	{
		private CustomerHelper m_CustomerHelper;

		public CustomerHelper CustomerHelper => null;

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}

		private void OnSyncRequest(string userId)
		{
		}

		public void BoostHelper_Broadcast()
		{
		}

		[PunRPC]
		public void BoostHelper_RPC()
		{
		}

		public void HelperHelp_Broadcast(ICustomerHelperControllable controllable)
		{
		}

		[PunRPC]
		public void HelperHelp_RPC(int controllableId)
		{
		}

		public void HelperAssign_Broadcast(ICustomerHelperControllable controllable)
		{
		}

		[PunRPC]
		public void HelperAssign_RPC(int controllableId)
		{
		}

		public void HelperReserve_Broadcast()
		{
		}

		[PunRPC]
		public void HelperReserve_RPC()
		{
		}

		public void UnReserve_Broadcast()
		{
		}

		[PunRPC]
		public void UnReserve_RPC()
		{
		}

		[PunRPC]
		public void SyncHelperData_RPC(float boostAmount)
		{
		}
	}
}
