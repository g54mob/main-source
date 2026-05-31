using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkBox : MonoBehaviour, IPunInstantiateMagicCallback, IPunOwnershipCallbacks
{
	[SerializeField]
	private BoxData m_BoxData;

	private PhotonView m_PhotonView;

	private Box m_Box;

	private PhotonTransformViewOptimized m_PhotonTransformView;

	public bool IsNetworkOccupied;

	private Rigidbody m_Rigidbody;

	public int ViewId => 0;

	public Box Box => null;

	public PhotonView PhotonView => null;

	public Rigidbody Rigidbody => null;

	public PhotonTransformViewOptimized PhotonTransformView => null;

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnSyncRequest(string UserId)
	{
	}

	public void DisableNetworkTransformSync(bool isActive)
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	public void PickUp_Broadcast(PlayerInstance player)
	{
	}

	[PunRPC]
	public void PickUP_RPC(string userID)
	{
	}

	public void AskAvailability()
	{
	}

	[PunRPC]
	public bool AvailabilityCallback_RPC(string userID)
	{
		return false;
	}

	[PunRPC]
	public void AvailabilityRejected_Response()
	{
	}

	public void OpenBox_Broadcast()
	{
	}

	[PunRPC]
	public void OpenBox_RPC(string senderUserId)
	{
	}

	public void CloseBox_Broadcast()
	{
	}

	[PunRPC]
	public void CloseBox_RPC()
	{
	}

	private void SyncBox_Broadcast(string userID)
	{
	}

	[PunRPC]
	public void SyncBoxData_RPC(string userID, object[] boxData)
	{
	}

	public void SyncBoxContent_Request()
	{
	}

	[PunRPC]
	public void SyncBoxContent_Broadcast()
	{
	}

	[PunRPC]
	public void SyncBoxContent_RPC(int productCount)
	{
	}

	public void Setup_Broadcast(int id, bool newBox)
	{
	}

	[PunRPC]
	public void Setup_RPC(int id, bool newBox)
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

	public void RemoveProductFromStreetBox_Broadcast(int removeCount)
	{
	}

	[PunRPC]
	public void RemoveProductFromStreetBox_RPC(int removeCount)
	{
	}
}
