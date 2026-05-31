using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkVendingInteraction : NetworkInteraction
{
	private VendingMachineInteraction m_VendingInteraction;

	protected override void Initialize()
	{
	}

	public void PlaceVending_Broadcast()
	{
	}

	[PunRPC]
	public void PlaceVending_RPC(Vector3 pos, Vector3 rot)
	{
	}

	public void SyncVendingState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncVendingState_RPC(string newPlayerUserId, string senderUserId, int VendingViewId)
	{
	}

	public void BoxUpVending_Broadcast()
	{
	}

	public void BoxUpVendingRequest()
	{
	}

	[PunRPC]
	public void BoxUpVendingRequest_RPC()
	{
	}
}
