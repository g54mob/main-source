using Photon.Pun;
using Photon.Realtime;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkStorageLight : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
	{
		private StorageLight m_StorageLight;

		private PhotonView m_PhotonView;

		private bool m_IsOccupied;

		public PhotonView PhotonView => null;

		public StorageLight StorageLight => null;

		public PlayerInstance OccupiedOwner { get; set; }

		public bool IsOccupied
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[PunRPC]
		public void SyncIsOccupiedValue(bool value)
		{
		}

		private void Start()
		{
		}

		private void OnSyncStorageLightSwitchState(string newPlayerUserID)
		{
		}

		[PunRPC]
		public void SyncStorageLight(bool isOccupied)
		{
		}

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}

		public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
		{
		}

		public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
		{
		}

		public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public void StartStorageLightPlacingMode_Request()
		{
		}

		[PunRPC]
		public void StartStorageLightPlacingModeFurniture_Response(string userId)
		{
		}

		[PunRPC]
		public void StartStorageLightPlacingModeFurniture_Order()
		{
		}

		[PunRPC]
		public void StartStorageLightPlacingModeFurniture_Rejected()
		{
		}

		public void StartStorageLightPlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void StartStorageLightPlacingMode_RPC(string userId)
		{
		}
	}
}
