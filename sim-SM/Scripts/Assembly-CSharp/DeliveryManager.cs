using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : NoktaSingleton<DeliveryManager>
{
	public Action<List<GameObject>> OnDeliveryCompleted;

	[Header("Test Settings")]
	public float space;

	[Header("Copmponents")]
	[SerializeField]
	private Transform m_DeliveryPosition;

	public void Delivery(CartData cartData)
	{
	}

	public VendingData VendingMachineDelivery(VendingMachineSO vendingMachineSo)
	{
		return null;
	}
}
