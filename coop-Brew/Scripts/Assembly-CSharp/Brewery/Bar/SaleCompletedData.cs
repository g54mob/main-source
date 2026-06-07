using System;
using Unity.Netcode;

namespace Brewery.Bar
{
	[Serializable]
	public struct SaleCompletedData : INetworkSerializable
	{
		public string npcName;

		public string drinkName;

		public float baseValue;

		public float finalPrice;

		public string factionName;

		public float factionMultiplier;

		public string tagMultipliersJson;

		public int baseType;

		public int tagsMask;

		public int baseValueSkillBonus;

		public float factionSellBonusPercent;

		public string tagSkillBreakdownJson;

		public float factionBaseTypeMultiplier;

		public float combinedBaseTypeMultiplier;

		public string fullTagBreakdownJson;

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

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
