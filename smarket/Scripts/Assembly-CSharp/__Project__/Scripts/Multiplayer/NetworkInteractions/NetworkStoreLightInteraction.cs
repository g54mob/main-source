using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkStoreLightInteraction : NetworkInteraction
	{
		private StoreLightInteraction m_StoreLightInteraction;

		public StoreLightInteraction StoreLightInteraction => null;

		protected override void Initialize()
		{
		}

		public void PlaceStoreLight_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceStoreLight_RequestMaster()
		{
		}

		[PunRPC]
		public void PlaceStoreLight_RPC(Vector3 pos)
		{
		}

		private void SyncStoreLightState_Broadcast(string newPlayerUserId)
		{
		}

		[PunRPC]
		public void SyncStoreLightState_RPC(string newPlayerUserId, string senderUserId, int storeLightViewId)
		{
		}
	}
}
