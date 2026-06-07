using System.Collections.Generic;
using Brewery.Core;

namespace Brewery.Calendar
{
	public sealed class DayModifierSet
	{
		public int DayIndex;

		public List<string> ActiveEventIds;

		public EnumMap<BrewTag, float> TagMult;

		public EnumMap<BaseType, float> BaseTypeMult;

		public EnumMap<FactionType, float> FactionSaleMult;

		public EnumMap<FactionType, bool> FactionCanEnterBar;

		public Dictionary<string, float> CatalystSaleMult;

		public Dictionary<string, float> CatalystCostMult;

		public Dictionary<string, float> CatalystLimitMult;

		public HashSet<string> DisabledTradeOfferGuids;

		public uint CompiledHash;

		public static DayModifierSet Neutral(int dayIndex)
		{
			return null;
		}

		public uint ComputeHash()
		{
			return 0u;
		}

		private static void HashDict(ref uint h, Dictionary<string, float> dict, uint prime)
		{
		}

		private static uint MixInt(uint h, int v, uint prime)
		{
			return 0u;
		}

		private static uint MixFloat(uint h, float v, uint prime)
		{
			return 0u;
		}

		private static uint MixString(uint h, string s, uint prime)
		{
			return 0u;
		}

		public string DescribeVerbose()
		{
			return null;
		}
	}
}
