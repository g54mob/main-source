using UnityEngine;

public class AutomatedCheckout : MonoBehaviour
{
	[SerializeField]
	private Transform m_CashierPos;

	[SerializeField]
	private Checkout m_Checkout;

	[SerializeField]
	private GameObject m_ShoppingBag;

	[Header("Settings")]
	[SerializeField]
	private float m_IntervalAfterScanningAll;

	[SerializeField]
	private float m_TakingPaymentInterval;

	[SerializeField]
	private float m_FinishingPaymentDuration;

	[Header("SFX")]
	[SerializeField]
	private SFXInstance m_CashierSFX;

	private Cashier m_Cashier;

	private NetworkAutomatedCheckout m_NetworkAutomatedCheckout;

	public int CurrentCashierID => 0;

	public Cashier Cashier => null;

	public NetworkAutomatedCheckout NetworkAutomatedCheckout => null;

	public Checkout Checkout
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void OnDisable()
	{
	}

	public void Setup(Cashier cashier)
	{
	}

	public void RemoveCashier()
	{
	}

	public void StartCashierCheckout()
	{
	}

	public void FinishCheckout(bool paymentViaCreditCard)
	{
	}

	public void FinishCheckout_Order()
	{
	}

	public void UpdateCashiersPosition()
	{
	}
}
