using System.Collections.Generic;
using UnityEngine;

public class StandingPaymentUI : MonoBehaviour
{
	[SerializeField]
	private PaymentItemStackUI _uiPaymentStackPrefab;

	[SerializeField]
	private Transform _uiPaymentStackParent;

	private List<PaymentItemStackUI> _uiStacks;

	private PaymentGroup _standingPayment;

	public void Initiate(PaymentGroup standingPayment)
	{
	}

	public void Clear()
	{
	}
}
