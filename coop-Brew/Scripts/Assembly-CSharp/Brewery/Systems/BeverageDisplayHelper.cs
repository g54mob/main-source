using System.Collections.Generic;
using Brewery.Core;
using Brewery.Items;
using InventorySystem;

namespace Brewery.Systems
{
	public static class BeverageDisplayHelper
	{
		public static string GetDisplayName(InventorySlot slot)
		{
			return null;
		}

		public static string GetDisplayName(Item item, BeerDataSnapshot? metadata)
		{
			return null;
		}

		public static string GetTooltip(InventorySlot slot)
		{
			return null;
		}

		public static string GetTooltip(Item item, BeerDataSnapshot? metadata)
		{
			return null;
		}

		public static string BuildBeverageTooltip(BeerDataSnapshot snapshot)
		{
			return null;
		}

		public static List<string> GetCatalystList(BeerDataSnapshot snapshot)
		{
			return null;
		}

		public static string GetCatalystString(BeerDataSnapshot snapshot)
		{
			return null;
		}

		public static string FormatCatalystName(string catalystId)
		{
			return null;
		}

		public static string FormatTags(BrewTag tags)
		{
			return null;
		}

		private static string FormatEnumName(string enumName)
		{
			return null;
		}

		public static bool IsCatalyzedBeverage(Item item)
		{
			return false;
		}

		public static bool HasBeverageMetadata(InventorySlot slot)
		{
			return false;
		}

		public static bool TryGetBeverageData(InventorySlot slot, out BeerDataSnapshot snapshot)
		{
			snapshot = default(BeerDataSnapshot);
			return false;
		}
	}
}
