using System;
using InventorySystem;
using UnityEngine;

namespace CraftingSystem
{
	[Serializable]
	public class RecipeResult
	{
		public Item item;

		[Min(1f)]
		public int quantity;

		[Range(0f, 100f)]
		public float chancePercentage;
	}
}
