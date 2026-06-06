using Brewery.Data;
using InventorySystem;

namespace Brewery.Core
{
	public static class BeverageItemFactory
	{
		private const string META_BREW_NAME = "BrewName";

		private const string META_BASE_TYPE = "BaseType";

		private const string META_COMBINED_TAGS = "CombinedTags";

		private const string META_IS_LEGENDARY = "IsLegendary";

		private const string META_LEGENDARY_NAME = "LegendaryName";

		private const string META_BEST_PRICE = "BestPrice";

		private const string META_BEST_FACTION = "BestFaction";

		public static Item CreateBeverageItem(BrewingResult brewingResult)
		{
			return null;
		}

		private static string GetBeverageDescription(BrewingResult brewingResult)
		{
			return null;
		}

		private static void CustomizeBeverageItem(Item item, BrewingResult brewingResult)
		{
		}

		private static void StoreBrewingDataInComponent(Item item, BrewingResult brewingResult)
		{
		}

		private static void StoreBrewingDataInDescription(Item item, BrewingResult brewingResult)
		{
		}

		public static BrewingResult ExtractBrewingResult(Item item)
		{
			return null;
		}

		public static InventoryItemBrewingData GetBrewingData(Item item)
		{
			return null;
		}

		private static BaseType GuessBaseTypeFromItem(Item item)
		{
			return default(BaseType);
		}

		private static void SetMetadata(Item item, string key, string value)
		{
		}

		private static string GetMetadataString(Item item, string key, string defaultValue)
		{
			return null;
		}

		private static float GetMetadataFloat(Item item, string key, float defaultValue)
		{
			return 0f;
		}

		private static int GetMetadataInt(Item item, string key, int defaultValue)
		{
			return 0;
		}

		private static bool GetMetadataBool(Item item, string key, bool defaultValue)
		{
			return false;
		}
	}
}
