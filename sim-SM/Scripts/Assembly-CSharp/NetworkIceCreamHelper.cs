using Photon.Pun;
using UnityEngine;

public class NetworkIceCreamHelper : MonoBehaviourPun
{
	private IceCreamHelper m_Helper;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnSyncRequest(string userID)
	{
	}

	[PunRPC]
	public void SyncHelperData_RPC(float boostAmount, Vector3 position)
	{
	}

	public void CreateCone_Others(int coneIdx)
	{
	}

	[PunRPC]
	private void CreateCone_RPC(int coneIdx)
	{
	}

	public void DestroyCone_Others()
	{
	}

	[PunRPC]
	private void DestroyCone_RPC()
	{
	}

	public void AddFlavour_Others(IceCreamFlavour flavour)
	{
	}

	[PunRPC]
	private void AddFlavour_RPC(int flavourId)
	{
	}

	public void AddTopping_Others(IceCreamTopping topping)
	{
	}

	[PunRPC]
	private void AddTopping_RPC(int toppingId)
	{
	}

	public void BoostHelper_Broadcast()
	{
	}

	[PunRPC]
	public void BoostIceCreamHelper_RPC()
	{
	}
}
