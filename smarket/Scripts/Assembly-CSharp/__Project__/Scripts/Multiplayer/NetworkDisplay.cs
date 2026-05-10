using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkDisplay : MonoBehaviour, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
	{
		private PhotonView m_PhotonView;

		private Display m_Display;

		public bool IsNetworkOccupied;

		public bool IsAvailableToPlace;

		public int ViewId => 0;

		public string UserId => null;

		public PhotonView PhotonView => null;

		public Display Display => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void DisplayPriceState_Broadcast(string newPlayerUserID)
		{
		}

		[PunRPC]
		public void DisplayPriceState_RPC(string displayData)
		{
		}

		public void SetTransformViewClassic()
		{
		}

		public void RequestDisplayData_Broadcast(string UserId)
		{
		}

		[PunRPC]
		public void SendDisplayData_RPC(string UserId)
		{
		}

		[PunRPC]
		public void ReceiveDisplayData_RPC(string TargetUserId, string DisplayDataJson)
		{
		}

		public void StartPlacingMode_Request()
		{
		}

		[PunRPC]
		public void StartPlacingMode_Response(string userId)
		{
		}

		[PunRPC]
		public void StartPlacingMode_Order()
		{
		}

		[PunRPC]
		public void StartPlacingMode_Rejected()
		{
		}

		public void StartPlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void StartPlacingMode_RPC(string userId)
		{
		}

		public void ClearLabel_Broadcast(string userID, int displaySlotIndex)
		{
		}

		[PunRPC]
		public void ClearDisplayLabel_RPC(string userID, int displaySlotIndex)
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

		public void OccupyDisplay_Broadcast(bool isOccupied)
		{
		}

		[PunRPC]
		public void OccupyDisplay_RPC(bool isOccupied)
		{
		}

		public void RemoveProductFromDisplaySlot_Broadcast(int slotIndex, int removeCount)
		{
		}

		[PunRPC]
		public void RemoveProductFromDisplaySlot_RPC(int slotIndex, int removeCount)
		{
		}
	}
}
