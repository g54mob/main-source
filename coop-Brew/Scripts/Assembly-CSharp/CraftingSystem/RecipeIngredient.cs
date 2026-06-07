using System;
using InventorySystem;
using UnityEngine;

namespace CraftingSystem
{
	[Serializable]
	public class RecipeIngredient
	{
		public Item item;

		[Min(1f)]
		public int quantity;

		public bool consumeOnCraft;
	}
}
