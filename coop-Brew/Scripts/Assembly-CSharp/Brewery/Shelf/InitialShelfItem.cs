using System;
using InventorySystem;
using UnityEngine;

namespace Brewery.Shelf
{
	[Serializable]
	public class InitialShelfItem
	{
		[Tooltip("Item to place on shelf")]
		public Item item;

		[Tooltip("Quantity to place (respects stack limits)")]
		public int quantity;
	}
}
