using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using InventorySystem;

namespace CraftingSystem
{
	public static class RecipeRegistry
	{
		private static readonly Dictionary<string, CraftingRecipe> recipesByName;

		private static readonly Dictionary<CraftingTableType, List<CraftingRecipe>> recipesByTable;

		private static bool isInitialized;

		public static event Action RegistryUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void ClearAll()
		{
		}

		public static void Warmup()
		{
		}

		public static void Initialize(bool forceReload = false)
		{
		}

		public static void RegisterRecipe(CraftingRecipe recipe)
		{
		}

		public static CraftingRecipe GetRecipe(string recipeName)
		{
			return null;
		}

		public static IReadOnlyList<CraftingRecipe> GetRecipesForTable(CraftingTableType tableType)
		{
			return null;
		}

		public static List<CraftingRecipe> GetRecipesForItem(Item item)
		{
			return null;
		}

		public static CraftingRecipe FindRecipeByInputs(CraftingTableType tableType, Dictionary<Item, int> inputs)
		{
			return null;
		}

		private static void EnsureInitialized()
		{
		}

		private static void InternalRegister(CraftingRecipe recipe, bool notify)
		{
		}
	}
}
