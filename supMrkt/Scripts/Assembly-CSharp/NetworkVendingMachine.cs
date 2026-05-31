using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkVendingMachine : MonoBehaviour, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
{
	private PhotonView m_PhotonView;

	private VendingMachine m_Vending;

	public bool IsNetworkOccupied;

	public bool IsAvailableToPlace;

	public int ViewId => 0;

	public string UserId => null;

	public PhotonView PhotonView => null;

	public VendingMachine Vending => null;

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

	private void VendingPriceState_Broadcast(string newPlayerUserID)
	{
	}

	[PunRPC]
	public void VendingPriceState_RPC(string VendingData)
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

	public void ClearLabel_Broadcast(string userID, int VendingSlotIndex)
	{
	}

	[PunRPC]
	public void ClearVendingLabel_RPC(string userID, int VendingSlotIndex)
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

	public void OccupyVending_Broadcast(bool isOccupied)
	{
	}

	[PunRPC]
	public void OccupyVending_RPC(bool isOccupied)
	{
	}

	public void CollectMoney_Request()
	{
	}

	[PunRPC]
	public void CollectMoney_RPC()
	{
	}

	public void GetCollectedMoney_Request()
	{
	}

	[PunRPC]
	public void GetCollectedMoney_Broadcast(string userId)
	{
	}

	[PunRPC]
	public void GetCollectedMoney_RPC(float collectedMoney)
	{
	}

	public void ExchangeProductIdle_Broadcast(int slotId)
	{
	}

	[PunRPC]
	public void ExchangeProductIdle_RPC(int slotId)
	{
	}

	public void SetCollectedMoney_Broadcast(float money)
	{
	}

	[PunRPC]
	public void SetCollectedMoney_RPC(float money)
	{
	}
}
