using Photon.Pun;
using Photon.Realtime;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkFurniture : MonoBehaviourPun, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
	{
		private PhotonView m_PhotonView;

		private Furniture m_Furniture;

		public bool IsNetworkOccupied;

		public int ViewId => 0;

		public string UserId => null;

		public Furniture Furniture => null;

		public void SetTransformViewClassic()
		{
		}

		public void StartPlacingMode_Request()
		{
		}

		[PunRPC]
		public void StartPlacingModeFurniture_Response(string userId)
		{
		}

		[PunRPC]
		public void StartPlacingModeFurniture_Order()
		{
		}

		[PunRPC]
		public void StartPlacingModeFurniture_Rejected()
		{
		}

		public void StartPlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void StartPlacingMode_RPC(string userId)
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
	}
}
