using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkCategorySignInteraction : NetworkInteraction
{
	private CategorySignInteraction m_CategorySignInteraction;

	protected override void Initialize()
	{
	}

	private void SyncBoxState_Broadcast(string newPlayerUserId)
	{
	}

	public void PlaceCategorySign_Broadcast()
	{
	}

	[PunRPC]
	public void PlaceCategorySign_RPC(Vector3 playSoundPosition)
	{
	}

	public void BoxUpCategorySign_Broadcast()
	{
	}

	public void BoxUpCategorySignRequest()
	{
	}

	[PunRPC]
	public void BoxUpCategorySignRequest_RPC()
	{
	}
}
