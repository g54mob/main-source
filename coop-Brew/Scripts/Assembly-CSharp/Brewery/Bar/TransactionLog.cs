using System;
using System.Collections.Generic;

namespace Brewery.Bar
{
	[Serializable]
	public class TransactionLog
	{
		public string timestamp;

		public string npcName;

		public string drinkName;

		public float baseValue;

		public float finalPrice;

		public string factionName;

		public float factionMultiplier;

		public Dictionary<string, float> tagMultipliers;

		public int baseType;

		public int tagsMask;

		public int baseValueSkillBonus;

		public float factionSellBonusPercent;

		public List<TagSkillEntry> tagSkillBonuses;

		public float factionBaseTypeMultiplier;

		public float combinedBaseTypeMultiplier;

		public List<FullTagBreakdownEntry> fullTagBreakdowns;

		public float barMood;

		public float tipPercent;

		public float tipAmount;

		public float priceBeforeTips;

		public float factionSellBonusMultiplier;

		public float calendarTagsMult;

		public float calendarBaseMult;

		public float calendarFactionMult;

		public float calendarCatalystMult;

		public float calendarTotalMult;

		public string calendarEventIdsCsv;
	}
}
