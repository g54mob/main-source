using System.Collections.Generic;
using Brewery.Data;

namespace Brewery.Core
{
	public static class BrewingCalculator
	{
		public static BrewingResult CalculateBrew(BaseType baseType, List<CatalystData> catalysts, List<FactionData> factions, List<LegendaryRecipe> legendaryRecipes)
		{
			return null;
		}

		public static BrewingResult.PriceInfo CalculatePriceForFaction(BrewingResult brew, FactionData faction)
		{
			return null;
		}

		private static float GetBaseValue(BaseType baseType)
		{
			return 0f;
		}

		private static int GetBatchUnits(BaseType baseType)
		{
			return 0;
		}

		private static int GetShelfLife(BaseType baseType, BrewTag tags)
		{
			return 0;
		}

		private static float CalculateBrewingCost(List<CatalystData> catalysts)
		{
			return 0f;
		}

		private static string GetRefusalReason(BrewTag tags, FactionData faction)
		{
			return null;
		}

		public static Dictionary<FactionType, List<BrewingResult>> FindBestCombinationsForFactions(List<CatalystData> availableCatalysts, List<FactionData> factions, List<LegendaryRecipe> legendaryRecipes, int topCount = 3)
		{
			return null;
		}

		private static List<List<CatalystData>> GetAllCatalystCombinations(List<CatalystData> catalysts, int maxSize)
		{
			return null;
		}

		private static void GenerateCombinations(List<CatalystData> catalysts, int size, int start, List<CatalystData> current, List<List<CatalystData>> result)
		{
		}
	}
}
