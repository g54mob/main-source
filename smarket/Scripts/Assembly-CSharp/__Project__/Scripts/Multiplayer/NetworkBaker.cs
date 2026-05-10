using Photon.Pun;
using UnityEngine.AI;
using Workbench.Wolfsbane.Multiplayer;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkBaker : MonoBehaviourPun, IPunInstantiateMagicCallback
	{
		private PhotonView m_PhotonView;

		private NetworkedAnimation m_NetworkedAnimation;

		private Baker m_Baker;

		private NavMeshAgent m_NavMeshAgent;

		public PhotonView PhotonView => null;

		public Baker Baker => null;

		public NetworkedAnimation NetworkedAnimation => null;

		public NavMeshAgent NavMeshAgent => null;

		public int ViewId => 0;

		private void Start()
		{
		}

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}

		private void OnSyncRequest(string userID)
		{
		}

		[PunRPC]
		public void SyncBakerData_RPC(bool isCarrying, int currentBoxViewId, float boostAmount, bool isCrarryingCrate, int[] itemIdsInCrate)
		{
		}

		public void ToggleBakerCrate_Broadcast(bool isActive)
		{
		}

		[PunRPC]
		public void ToggleBakerCrate_RPC(bool isActive)
		{
		}

		public void PickupGround_Broadcast(Box box)
		{
		}

		[PunRPC]
		public void BakerPickupGround_RPC(int boxPhotonViewId)
		{
		}

		public void PickupRack_Broadcast(RackSlot targetRackSlot, Box box)
		{
		}

		[PunRPC]
		public void BakerPickupRack_RPC(int rackViewId, int rackSlotIndex, int boxViewId)
		{
		}

		public void Boost_Broadcast()
		{
		}

		[PunRPC]
		public void BoostBaker_RPC()
		{
		}

		public void DropCurrentBox_Broadcast()
		{
		}

		[PunRPC]
		public void DropCurrentBox_RPC()
		{
		}

		public void BakerPlaceProducts_Broadcast(DisplaySlot displaySlot, Box box, Product product)
		{
		}

		[PunRPC]
		public void BakerPlaceProducts_RPC(int displayViewId, int displaySlotIndex, int boxViewId, int productId)
		{
		}

		public void TakeProductFromOven_Broadcast(Product product, DisplaySlot displaySlot)
		{
		}

		[PunRPC]
		public void TakeProductFromOven_RPC(int displayViewId, int displaySlotIndex)
		{
		}

		public void PlaceProductToDisplay_Broadcast(DisplaySlot displaySlot, Product product)
		{
		}

		[PunRPC]
		public void BakerPlaceProductToDisplay_RPC(int displayViewId, int displaySlotIndex, int productId)
		{
		}

		public void PlaceBoxToRack_Broadcast(RackSlot targetRackSlot, Box box)
		{
		}

		[PunRPC]
		public void BakerPlaceBoxToRack_RPC(int rackViewId, int rackSlotIndex, int boxViewId)
		{
		}
	}
}
