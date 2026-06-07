using System.Collections.Generic;
using Brewery.Shelf;
using Brewery.Stations;

namespace Brewery.Employee.AI
{
	public static class BreweryRecipes
	{
		public static StationRole? GetStationRole(BaseBreweryStation station)
		{
			return null;
		}

		public static Recipe GetRecipe(StationRole role)
		{
			return default(Recipe);
		}

		public static bool HasIngredientsOnShelves(Recipe recipe, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return false;
		}

		public static bool HasRemainingIngredientsOnShelves(Recipe recipe, BaseBreweryStation station, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return false;
		}

		public static int GetIngredientCountOnShelves(RecipeInput input, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return 0;
		}

		public static ShelfInventoryManager FindShelfWithIngredient(RecipeInput input, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		public static RecipeInput? FindNextAvailableOptionalInput(Recipe recipe, BaseBreweryStation station, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		public static int CountLoadedOptionalInputs(Recipe recipe, BaseBreweryStation station)
		{
			return 0;
		}
	}
}
