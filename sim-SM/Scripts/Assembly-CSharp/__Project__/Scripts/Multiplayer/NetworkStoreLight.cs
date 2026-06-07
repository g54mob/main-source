using Photon.Pun;
using Photon.Realtime;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkStoreLight : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
	{
		private StoreLight m_StoreLight;

		private PhotonView m_PhotonView;

		private bool m_IsOccupied;

		public PhotonView PhotonView => null;

		public StoreLight StoreLight => null;

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

		private void OnSyncStoreLightSwitchState(string newPlayerUserID)
		{
		}

		[PunRPC]
		public void SyncStoreLight(bool isOccupied)
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

		public void StartStoreLightPlacingMode_Request()
		{
		}

		[PunRPC]
		public void StartStoreLightPlacingModeFurniture_Response(string userId)
		{
		}

		[PunRPC]
		public void StartStoreLightPlacingModeFurniture_Order()
		{
		}

		[PunRPC]
		public void StartStoreLightPlacingModeFurniture_Rejected()
		{
		}

		public void StartStoreLightPlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void StartStoreLightPlacingMode_RPC(string userId)
		{
		}
	}
}
