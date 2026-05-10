using Photon.Pun;
using UnityEngine;

public class NetworkAutomatedCheckout : MonoBehaviour
{
	private AutomatedCheckout m_AutomatedCheckout;

	private PhotonView m_PhotonView;

	public AutomatedCheckout AutomatedCheckout => null;

	public PhotonView PhotonView => null;

	public void CashierProductScanned_Broadcast(Product product)
	{
	}

	[PunRPC]
	public void CashierProductScanned_RPC()
	{
	}

	public void CashierTookPayment_Broadcast(bool paymentViaCreditCard)
	{
	}

	[PunRPC]
	public void CashierTookPayment_RPC(bool paymentViaCreditCard)
	{
	}

	public void CashierCompletedCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void CashierCompletedCheckout_RPC()
	{
	}
}
