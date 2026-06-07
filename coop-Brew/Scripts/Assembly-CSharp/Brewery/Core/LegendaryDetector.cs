using System.Collections.Generic;
using Brewery.Data;

namespace Brewery.Core
{
	public static class LegendaryDetector
	{
		public static LegendaryRecipe DetectLegendary(BrewTag combinedTags, List<LegendaryRecipe> legendaryRecipes)
		{
			return null;
		}

		public static List<LegendaryRecipe> GetPossibleLegendaries(List<CatalystData> availableCatalysts, List<LegendaryRecipe> legendaryRecipes)
		{
			return null;
		}

		public static List<List<CatalystData>> FindCatalystCombinationsForLegendary(LegendaryRecipe legendary, List<CatalystData> availableCatalysts)
		{
			return null;
		}

		public static Dictionary<LegendaryRecipe, int> GetLegendaryDiscoveryDifficulty(List<LegendaryRecipe> legendaryRecipes, List<CatalystData> availableCatalysts)
		{
			return null;
		}

		public static List<CatalystData> GetMinimalCatalystsForLegendary(LegendaryRecipe legendary, List<CatalystData> availableCatalysts)
		{
			return null;
		}

		private static List<List<CatalystData>> GetAllCombinations(List<CatalystData> catalysts, int maxSize)
		{
			return null;
		}

		private static void GenerateCombinations(List<CatalystData> catalysts, int targetSize, int startIndex, List<CatalystData> current, List<List<CatalystData>> result)
		{
		}

		public static string GenerateLegendaryReport(List<LegendaryRecipe> legendaryRecipes, List<CatalystData> availableCatalysts)
		{
			return null;
		}
	}
}
