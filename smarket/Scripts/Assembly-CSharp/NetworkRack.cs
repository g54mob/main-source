using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkRack : MonoBehaviour, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
{
	private PhotonView m_PhotonView;

	private Rack m_Rack;

	public bool IsNetworkOccupied;

	public int ViewId => 0;

	public string UserId => null;

	public PhotonView PhotonView => null;

	public Rack Rack => null;

	private void Awake()
	{
	}

	public void RequestRackData_Broadcast(string UserId)
	{
	}

	[PunRPC]
	public void SendRackData_RPC(string UserId)
	{
	}

	[PunRPC]
	public void ReceiveRackData_RPC(string TargetUserId, string RackDataJson)
	{
	}

	public void TakeBoxFromRack_Request(int rackSlotIndex)
	{
	}

	[PunRPC]
	public void TakeBoxFromRack_Broadcast(string _userId, int rackSlotIndex)
	{
	}

	[PunRPC]
	public void TakeBoxFromRack_Rejected()
	{
	}

	[PunRPC]
	public void TakeBoxFromRack_RPC(string userId, int rackSlotIndex)
	{
	}

	public void ClearLabel_Broadcast(string userID, int rackSlotIndex)
	{
	}

	[PunRPC]
	public void ClearRackLabel_RPC(string userID, int rackSlotIndex)
	{
	}

	public void StartPlacingMode_Request()
	{
	}

	[PunRPC]
	public void StartRackPlacingMode_Response(string userId)
	{
	}

	[PunRPC]
	public void StartRackPlacingMode_Accepted()
	{
	}

	[PunRPC]
	public void StartRackPlacingMode_Rejected()
	{
	}

	public void StartPlacingMode_Broadcast()
	{
	}

	[PunRPC]
	public void StartRackPlacingMode_RPC(string userId)
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

	public void RemoveBoxFromRack_Broadcast(int slotIndex, int removeCount)
	{
	}

	[PunRPC]
	public void RemoveBoxFromRack_RPC(int slotIndex, int removeCount)
	{
	}
}
