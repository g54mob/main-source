using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckoutScreen : MonoBehaviour
{
	[SerializeField]
	private CheckoutItem m_CheckoutItemPrefab;

	[SerializeField]
	private Transform m_ContentParent;

	[SerializeField]
	private TMP_Text m_TotalPriceText;

	[SerializeField]
	private Checkout m_Checkout;

	private List<CheckoutItem> m_CheckoutItems;

	private void Start()
	{
	}

	public void AddProduct(Product product, int quantity = 0)
	{
	}

	public void Clear()
	{
	}

	private void UpdateTotalPrice()
	{
	}
}
