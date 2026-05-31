using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkBoxInteraction : NetworkInteraction
	{
		private BoxInteraction m_BoxInteraction;

		public bool IsAvailableToPlace;

		public BoxInteraction BoxInteraction => null;

		protected override void Initialize()
		{
		}

		public void ThrowBoxInstant_Broadcast()
		{
		}

		public void ThrowBox_Broadcast()
		{
		}

		[PunRPC]
		public void ThrowBox_RPC(string userID)
		{
		}

		public void DropBox_Broadcast()
		{
		}

		[PunRPC]
		public void DropBox_RPC(string userID)
		{
		}

		public void SyncBoxState_Broadcast(string newPlayerUserId)
		{
		}

		[PunRPC]
		public void SyncBoxState_RPC(string newPlayerUserId, string senderUserId, int boxViewId)
		{
		}

		public void ThrowIntoTrashBin_Broadcast()
		{
		}

		[PunRPC]
		public void ThrowIntoTrashBin_RPC(string userID, Vector3 playSoundPosition)
		{
		}

		public void SetCooldownRackInteraction()
		{
		}

		public void AskPlaceBoxToRackAvailablity(int targetRackViewId, int targetRackSlotIndex)
		{
		}

		[PunRPC]
		public void ResponsePlaceBoxToRackAvailablity(string userID, int targetRackViewId, int targetRackSlotIndex, Vector3 playSoundPosition)
		{
		}

		public void PlaceBoxToRack_Broadcast(int targetRackViewId, int targetRackSlotIndex)
		{
		}

		[PunRPC]
		public void PlaceBoxToRack_RPC(string userID, int targetRackViewId, int targetRackIndex, Vector3 playSoundPosition)
		{
		}

		public void PlaceProduct_Broadcast(Box box, DisplaySlot displaySlot, Vector3 playSoundPosition)
		{
		}

		public void PlaceProduct_Broadcast(Box box, VendingSlot vendingSlot, Vector3 playSoundPosition)
		{
		}

		[PunRPC]
		public void PlaceProductVending_RPC(int vendingViewId, int vendingSlotIndex, int boxViewId, Vector3 playSoundPosition)
		{
		}

		[PunRPC]
		public void PlaceProduct_RPC(int displayViewId, int displaySlotIndex, int boxViewId, Vector3 playSoundPosition)
		{
		}

		public void AskPlaceProduct(DisplaySlot displaySlot)
		{
		}

		public void AskPlaceProduct(VendingSlot vendingSlot)
		{
		}

		[PunRPC]
		public void AskPlaceProductVending_RPC(int vendingViewId, int vendingSlotIndex, Vector3 playSoundPosition)
		{
		}

		[PunRPC]
		public void AskPlaceProduct_RPC(int displayViewId, int displaySlotIndex, Vector3 playSoundPosition)
		{
		}

		public void TakeProduct_Broadcast(Box box, DisplaySlot displaySlot)
		{
		}

		[PunRPC]
		public void TakeProduct_RPC(int displayViewId, int displaySlotIndex, int boxViewId)
		{
		}

		public void TakeProduct_Broadcast(Box box, VendingSlot vendingSlot)
		{
		}

		[PunRPC]
		public void TakeProductVending_RPC(int vendingViewId, int vendingSlotIndex, int boxViewId)
		{
		}

		public void AskTakeProduct(Box box, DisplaySlot displaySlot)
		{
		}

		[PunRPC]
		public void AskTakeProduct_RPC(int displayViewId, int displaySlotIndex, int boxViewId)
		{
		}

		public void AskTakeProduct(Box box, VendingSlot vendingSlot)
		{
		}

		[PunRPC]
		public void AskTakeProductVending_RPC(int vendingViewId, int vendingSlotIndex, int boxViewId)
		{
		}

		public void WholeSaleThrowBox_Broadcast()
		{
		}

		[PunRPC]
		public void WholeSaleThrowBox_RPC()
		{
		}
	}
}
