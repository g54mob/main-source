using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.Store
{
	[RequireComponent(typeof(PhotonView))]
	public class NetworkSectionManager : NoktaSingletonPunCallbacks<NetworkSectionManager>
	{
		private void Awake()
		{
		}

		private void OnSyncRequest(string userId)
		{
		}

		[PunRPC]
		public void StoreLevelDataSync_RPC(int storePoint, int storeLevel)
		{
		}

		private void UpdateStore(PlayerInstance obj)
		{
		}

		public void UpgradeStore_Broadcast(int storeUpgradeLevel)
		{
		}

		[PunRPC]
		public void UpgradeStore_RPC(int storeUpgradeLevel)
		{
		}

		public void AskUpgradeStore()
		{
		}

		[PunRPC]
		public void AskUpgradeStore_RPC()
		{
		}

		public void SetUpgradeStoreLevel(int storeUpgradeLevel)
		{
		}

		public int GetStoreUpgradeLevel()
		{
			return 0;
		}

		private void UpdateStorage(PlayerInstance obj)
		{
		}

		public void UpgradeStorage_Broadcast(int storageUpgradeLevel)
		{
		}

		[PunRPC]
		public void UpgradeStorage_RPC(int storageUpgradeLevel)
		{
		}

		public void AskUpgradeStorage()
		{
		}

		[PunRPC]
		public void AskUpgradeStorage_RPC()
		{
		}

		public void SetUpgradeStorageLevel(int storageUpgradeLevel)
		{
		}

		public int GetUpgradeStorageLevel()
		{
			return 0;
		}

		public void OpenStorage_Broadcast()
		{
		}

		[PunRPC]
		public void OpenStorage_RPC()
		{
		}

		public void AskOpenStorage()
		{
		}

		[PunRPC]
		public void AskOpenStorage_RPC()
		{
		}

		public void StorePointChange_Broadcast(int currentPoint, bool isIncreased)
		{
		}

		[PunRPC]
		public void StorePointChange_RPC(int currentPoint, bool isIncreased)
		{
		}
	}
}
