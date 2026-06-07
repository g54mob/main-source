using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Shops
{
	[Serializable]
	public class ShopItemData
	{
		public InventoryItemSpec item;

		public ShelfItem shelfItem;

		[SerializeField]
		private int amount;

		public float basePrice;

		public bool isGlobal;

		public bool careerOnly;

		public GameObject posterPrefab;

		public List<Shop> soldOnlyAt;

		[NonSerialized]
		public bool unavailableDueToGameMode;

		[NonSerialized]
		public int initialAmount;

		[NonSerialized]
		public int purchasedItems;

		[NonSerialized]
		public int allowedToHaveAmount;

		public int ItemsInStock => Mathf.Max(allowedToHaveAmount - purchasedItems, 0);

		public void InitializeInitialAmount()
		{
			initialAmount = amount;
		}
	}
}
