using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkIceCreamInteraction : NetworkInteraction
{
	private IceCreamInteraction m_IceCreamInteraction;

	private IceCreamCone m_ReplicatedCone;

	[SerializeField]
	private IceCreamCone[] m_ConePrefab;

	[SerializeField]
	private IceCreamTopping[] m_Toppings;

	public IceCreamInteraction IceCreamInteraction => null;

	public void PlaceStandFurniture_Broadcast()
	{
	}

	[PunRPC]
	public void PlaceStandFurniture_RPC(Vector3 playSoundPosition)
	{
	}

	public void BoxUpStand_Broadcast()
	{
	}

	public void BoxUpStandRequest()
	{
	}

	public void CreateCone_Others(int coneId)
	{
	}

	private void ToggleSpoonInternal(string userId, bool value)
	{
	}

	[PunRPC]
	private void CreateCone_RPC(string userId, int coneId)
	{
	}

	public void ClearCone_Others()
	{
	}

	[PunRPC]
	private void ClearCone_RPC(string userId)
	{
	}

	public void AddFlavour_Others(int flavourId)
	{
	}

	[PunRPC]
	private void AddFlavour_RPC(string userId, int flavourId)
	{
	}

	public void AddTopping_Others(int toppingId)
	{
	}

	[PunRPC]
	private void AddTopping_RPC(string userId, int toppingId)
	{
	}

	[PunRPC]
	public void BoxUpStandRequest_RPC()
	{
	}

	public void ToggleSpoon_Broadcast(string userId, bool value)
	{
	}

	[PunRPC]
	private void ToggleSpoon_RPC(string userId, bool value)
	{
	}

	public void OnStandBack_Broadcast()
	{
	}

	[PunRPC]
	private void OnStandBack_RPC(string sender)
	{
	}

	public void DeliverIceCream_Master(int customerId, IceCreamStatus status, int standViewId, string senderId)
	{
	}

	[PunRPC]
	private void DeliverIceCream_RPC(int customerViewId, IceCreamStatus status, int standViewId, string senderId)
	{
	}

	[PunRPC]
	private void DeliverIceCream_Accept()
	{
	}
}
