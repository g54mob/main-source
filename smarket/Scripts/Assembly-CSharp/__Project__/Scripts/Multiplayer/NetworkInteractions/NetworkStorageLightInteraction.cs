using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkStorageLightInteraction : NetworkInteraction
	{
		private StorageLightInteraction m_StorageLightInteraction;

		public StorageLightInteraction StorageLightInteraction => null;

		protected override void Initialize()
		{
		}

		public void PlaceStorageLight_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceStorageLight_RequestMaster()
		{
		}

		[PunRPC]
		public void PlaceStorageLight_RPC(Vector3 pos)
		{
		}

		private void SyncStorageLightState_Broadcast(string newPlayerUserId)
		{
		}

		[PunRPC]
		public void SyncStorageLightState_RPC(string newPlayerUserId, string senderUserId, int storageLightViewId)
		{
		}
	}
}
