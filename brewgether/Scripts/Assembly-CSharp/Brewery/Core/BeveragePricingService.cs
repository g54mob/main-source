using System.Collections.Generic;
using Brewery.Calendar;
using Brewery.Data;
using Brewery.Items;

namespace Brewery.Core
{
	public static class BeveragePricingService
	{
		public struct PriceRequest
		{
			public BeverageItem beverage;

			public FactionData faction;

			public BrewTag tags;

			public BeerDataSnapshot? metadata;

			public bool includeSkills;

			public ulong sellerClientId;

			public bool includeTips;

			public float standPriceMultiplier;

			public float repBonus;

			public DayModifierSet overrideDayModifiers;
		}

		public struct PriceResult
		{
			public float finalPrice;

			public float baseValue;

			public float effectiveBaseValue;

			public float baseTypeMultiplier;

			public float combinedTagMultiplier;

			public float factionSellBonusMultiplier;

			public float tipMultiplier;

			public float standMultiplier;

			public float repMultiplier;

			public bool isRefused;

			public int baseValueSkillBonus;

			public float factionSellBonusPercent;

			public float barMood;

			public float tipPercent;

			public float priceBeforeTips;

			public float tipAmount;

			public string factionName;

			public Dictionary<string, TagBreakdown> tagBreakdowns;

			public CalendarPricingContribution calendarContribution;

			public string[] calendarActiveEventIds;
		}

		public struct TagBreakdown
		{
			public string tagName;

			public float factionMultiplier;

			public float catalystSkillBonus;

			public float finalMultiplier;

			public string catalystName;

			public bool usedGlobalFallback;
		}

		public static PriceResult Calculate(PriceRequest request)
		{
			return default(PriceResult);
		}

		public static float CalculatePrice(PriceRequest request)
		{
			return 0f;
		}

		public static BrewTag GetBeverageTags(BeverageItem beverage, BeerDataSnapshot? snapshot = null)
		{
			return default(BrewTag);
		}

		public static float GetGlobalTagMultiplier(BrewTag tag)
		{
			return 0f;
		}

		public static bool WouldRefuse(FactionData faction, BrewTag tags)
		{
			return false;
		}

		public static float CalculateFactionMultiplier(FactionData faction, BaseType baseType, BrewTag tags)
		{
			return 0f;
		}

		public static float GetBaseValue(BaseType baseType)
		{
			return 0f;
		}

		private static List<string> GetCatalystsFromMetadata(BeerDataSnapshot? snapshot)
		{
			return null;
		}

		private static string FormatCatalystIdToName(string catalystId)
		{
			return null;
		}

		private static bool CatalystHasTag(string catalystName, BrewTag tag)
		{
			return false;
		}

		private static CatalystData FindCatalystByName(BreweryDatabase database, string name)
		{
			return null;
		}
	}
}
