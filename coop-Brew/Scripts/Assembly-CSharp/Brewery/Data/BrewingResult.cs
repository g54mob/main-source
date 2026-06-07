using System;
using System.Collections.Generic;
using Brewery.Core;

namespace Brewery.Data
{
	[Serializable]
	public class BrewingResult
	{
		[Serializable]
		public class PriceInfo
		{
			public FactionType Faction { get; set; }

			public float BaseMultiplier { get; set; }

			public float TagMultiplier { get; set; }

			public float FinalMultiplier { get; set; }

			public float PricePerUnit { get; set; }

			public float TotalBatchValue { get; set; }

			public bool IsRefused { get; set; }

			public string RefusalReason { get; set; }

			public float ProfitMargin { get; set; }

			public Dictionary<BrewTag, float> TagMultiplierBreakdown { get; set; }
		}

		public BaseType BaseType { get; set; }

		public List<CatalystData> Catalysts { get; set; }

		public BrewTag CombinedTags { get; set; }

		public BrewTag OriginalTags { get; set; }

		public List<BrewTag> SuppressedTags { get; set; }

		public List<string> SuppressionReasons { get; set; }

		public List<BrewTag> SynthesizedTags { get; set; }

		public Dictionary<BrewTag, BrewTag> TransformedTags { get; set; }

		public List<string> SynthesisReactions { get; set; }

		public List<string> TransformationReactions { get; set; }

		public string GeneratedName { get; set; }

		public LegendaryRecipe MatchedLegendary { get; set; }

		public bool IsLegendary => false;

		public bool HasSuppressions => false;

		public bool HasSynthesis => false;

		public bool HasTransformations => false;

		public bool HasReactions => false;

		public Dictionary<FactionType, PriceInfo> FactionPrices { get; set; }

		public int BatchUnits { get; set; }

		public int ShelfLife { get; set; }

		public float TotalBrewingCost { get; set; }

		public float ItemManagerCatalystValue { get; set; }

		public float EnhancedEconomicValue { get; set; }

		public string GetTagsString()
		{
			return null;
		}

		public int GetTagCount()
		{
			return 0;
		}

		public string GetCatalystsString()
		{
			return null;
		}

		public float GetBestPrice()
		{
			return 0f;
		}

		public FactionType? GetBestFaction()
		{
			return null;
		}

		public float GetAveragePrice()
		{
			return 0f;
		}

		public int GetAcceptingFactionCount()
		{
			return 0;
		}

		public float GetHighestMultiplier()
		{
			return 0f;
		}

		public string GetSummary()
		{
			return null;
		}
	}
}
