using System;
using UnityEngine;

[Serializable]
public class CartItem
{
	public int itemId;

	public int unitPrice;

	public int amount;

	public GameObject instance;

	public CartItem(int itemId, int unitPrice, int amount)
	{
		this.itemId = itemId;
		this.unitPrice = unitPrice;
		this.amount = amount;
	}
}
