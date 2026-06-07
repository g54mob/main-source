using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace CraftingSystem
{
	[CreateAssetMenu(fileName = "NewCraftingRecipe", menuName = "Crafting/Recipe", order = 0)]
	public class CraftingRecipe : ScriptableObject
	{
		[Header("Recipe Information")]
		public string recipeName;

		[TextArea]
		public string description;

		[Header("Localization")]
		[SerializeField]
		private string recipeNameKey;

		[SerializeField]
		private string recipeDescKey;

		public Sprite icon;

		[Header("Requirements")]
		public CraftingTableType requiredTable;

		[Min(0f)]
		public int requiredTier;

		[Header("Inputs")]
		public RecipeIngredient[] inputs;

		[Header("Outputs")]
		public RecipeResult[] outputs;

		[Header("Crafting")]
		[Min(0f)]
		public float craftingTime;

		public bool isUnlocked;

		public string GetDisplayName()
		{
			return null;
		}

		public string GetLocalizedDescription()
		{
			return null;
		}

		private void OnValidate()
		{
		}

		public bool CanCraft(InventoryManager playerInventory, VehicleInventoryManager vehicleInventory = null)
		{
			return false;
		}

		public bool HasRequiredIngredients(Dictionary<Item, int> availableItems)
		{
			return false;
		}

		public Dictionary<Item, int> GetIngredientTotals()
		{
			return null;
		}

		private static void AggregateInventory(IEnumerable<InventorySlot> slots, Dictionary<Item, int> accumulator)
		{
		}
	}
}
