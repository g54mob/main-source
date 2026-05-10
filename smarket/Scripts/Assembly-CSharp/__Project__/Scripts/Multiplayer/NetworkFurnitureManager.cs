using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkFurnitureManager : NoktaSingletonPunCallbacks<NetworkFurnitureManager>
	{
		[SerializeField]
		private FurnitureManager m_FurnitureManager;

		private void Start()
		{
		}

		private void OnSyncRequest(string invokerUserID)
		{
		}

		private void RequestCurrentLightData_Broadcast(bool isStoreLightsOpen, bool isStorageLightsOpen)
		{
		}

		[PunRPC]
		public void SyncLights_RPC(bool isStoreLightsOpen, bool isStorageLightsOpen)
		{
		}

		public void SyncSecurityCameraSaveData_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void SyncSecurityCameraSaveData_RPC()
		{
		}
	}
}
