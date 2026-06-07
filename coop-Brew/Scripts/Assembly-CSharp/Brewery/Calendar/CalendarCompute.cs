using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Brewery.Calendar
{
	public static class CalendarCompute
	{
		public static DayModifierSet BuildDayModifierSet(int dayIndex, IEnumerable<CalendarEventDefinition> events, float minStackedMult, float maxStackedMult)
		{
			return null;
		}

		public static CalendarPricingContribution GetContribution(DayModifierSet set, BrewTag tags, BaseType baseType, FactionType? faction, string[] catalystIds)
		{
			return default(CalendarPricingContribution);
		}

		private static void ApplyEvent(CalendarEventDefinition def, DayModifierSet set, HashSet<FactionType> exclusiveFactions, ref bool anyExclusive)
		{
		}

		private static void MultiplyKey(Dictionary<string, float> dict, string key, float mult)
		{
		}

		private static void ClampDict(Dictionary<string, float> dict, float minM, float maxM)
		{
		}

		private static string GetAssetGuid(Object obj)
		{
			return null;
		}
	}
}
