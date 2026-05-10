using Photon.Pun;
using Photon.Realtime;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkCategorySign : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
	{
		private PhotonView m_PhotonView;

		private CategorySign m_CategorySign;

		private PlayerInstance m_PlayerInstance;

		public int ViewId => 0;

		public string UserId => null;

		public PhotonView PhotonView => null;

		public CategorySign CategorySign => null;

		public PlayerInstance PlayerInstance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void StartPlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void StartPlacingModeCategorySign_RPC(string userId)
		{
		}

		public void SetTransformViewClassic()
		{
		}

		public void RequestCategorySignData_Broadcast(string UserId)
		{
		}

		[PunRPC]
		public void SendCategorySignData_RPC(string UserId)
		{
		}

		[PunRPC]
		public void ReceiveCategorySignData_RPC(string CategorySignDataJson, bool isOccupied)
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

		public void OccupyCategorySign_Broadcast(bool isOccupied)
		{
		}

		[PunRPC]
		public void OccupyCategorySign_RPC(bool isOccupied)
		{
		}

		public void StartPlacingMode_Request()
		{
		}

		[PunRPC]
		public void StartPlacingModeCategorySign_Response(string userId)
		{
		}

		[PunRPC]
		public void StartPlacingModeCategorySign_Order()
		{
		}

		[PunRPC]
		public void StartPlacingModeCategorySign_Rejected()
		{
		}
	}
}
