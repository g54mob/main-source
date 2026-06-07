using System;
using System.Collections.Generic;
using Brewery.Core;
using Brewery.Items;
using InventorySystem;

namespace Brewery.Quest
{
	[Serializable]
	public class CatalyzedItemRequirement
	{
		public string BaseItemId;

		public BaseType BaseType;

		public List<string> CatalystIds;

		public int Quantity;

		private string cachedDisplayName;

		private string cachedCatalystNames;

		private BrewTag cachedCombinedTags;

		public static CatalyzedItemRequirement Parse(string requirementString)
		{
			return null;
		}

		public static bool IsCatalyzedFormat(string requirementString)
		{
			return false;
		}

		private void ComputeDisplayInfo()
		{
		}

		private string FormatCatalystName(string catalystId)
		{
			return null;
		}

		public string GetDisplayName()
		{
			return null;
		}

		public string GetCatalystNames()
		{
			return null;
		}

		public BrewTag GetCombinedTags()
		{
			return default(BrewTag);
		}

		public bool MatchesBeerDataSnapshot(BeerDataSnapshot snapshot)
		{
			return false;
		}

		public bool MatchesItem(Item item)
		{
			return false;
		}

		public string GetRegistryItemId()
		{
			return null;
		}

		public int CountMatchingItems(InventoryManager inventory)
		{
			return 0;
		}
	}
}
