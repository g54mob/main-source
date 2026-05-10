using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkScale : MonoBehaviour, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
	{
		private PhotonView m_PhotonView;

		private Scale m_Scale;

		public Action<bool> NetworkQueueUpdated;

		public PhotonView PhotonView => null;

		public Scale Scale => null;

		public int ViewId => 0;

		public string UserId => null;

		public PlayerInstance PlayerInstance => null;

		[PunRPC]
		public void SetScaleState_Broadcast(int state, string interactedPlayerUserId)
		{
		}

		[PunRPC]
		public void SetScaleState_RPC(int state, string interactedPlayerUserId)
		{
		}

		public void SetScaleState_Request(Scale.ScaleInteractionState state, PlayerInstance interactedPlayer)
		{
		}

		[PunRPC]
		public void StartScalePlacingMode_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void StartScalePlacingMode_RPC(string userId)
		{
		}

		public void StartScalePlacingMode_Request(string userId)
		{
		}

		public void AttachBarcode_Broadcast(RaycastHit hit)
		{
		}

		[PunRPC]
		public void AttachBarcode_RPC(Vector3 hitPoint, Vector3 hitNormal)
		{
		}

		public void CreateBarcode_Broadcast(string numpadValue)
		{
		}

		[PunRPC]
		public void CreateBarcode_RPC(string numpadValue)
		{
		}

		public void CreateProduct_Broadcast(ProductCountPair productCountPair)
		{
		}

		[PunRPC]
		public void CreateProduct_RPC(int productId, int count)
		{
		}

		public void RemoveExistingProduct_Broadcast()
		{
		}

		[PunRPC]
		public void RemoveExistingProduct_RPC()
		{
		}

		public void UpdateQueueEvent_Broadcast(bool value)
		{
		}

		[PunRPC]
		public void UpdateQueueEvent_RPC(bool value)
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

		public void SetCustomerHelperController_Broadcast(HelperScaleController controller)
		{
		}

		[PunRPC]
		public void SetCustomerHelperController_RPC(int controllerViewId)
		{
		}

		public void InteractScale_Request()
		{
		}

		[PunRPC]
		public void InteractScale_Response(string userId)
		{
		}

		[PunRPC]
		public void InteractScale_Rejected()
		{
		}

		[PunRPC]
		public void InteractScale_Broadcast(string userId)
		{
		}
	}
}
