using Photon.Pun;
using UnityEngine;
using Workbench.Wolfsbane.Multiplayer;

public class NetworkCashier : MonoBehaviourPun
{
	private Cashier m_Cashier;

	[SerializeField]
	private NetworkedAnimation m_NetworkedAnimation;

	public Cashier Cashier => null;

	private void Start()
	{
	}

	private void OnSyncRequest(string userID)
	{
	}

	[PunRPC]
	public void SyncCashierData_RPC(float boostAmount, Vector3 position)
	{
	}

	public void ScanAnimation()
	{
	}

	public void TakePaymentAnimation()
	{
	}

	public void BoostCashier_Broadcast()
	{
	}

	[PunRPC]
	public void BoostCashier_RPC()
	{
	}
}
