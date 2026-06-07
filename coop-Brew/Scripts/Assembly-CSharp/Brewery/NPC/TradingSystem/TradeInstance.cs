using System.Collections.Generic;

namespace Brewery.NPC.TradingSystem
{
	public class TradeInstance
	{
		public TradeOffer tradeOffer;

		public string tradeId;

		public int completionsToday;

		public float dailyMultiplier;

		public int currentMoneyRequired;

		public int currentMoneyReward;

		public Dictionary<string, int> currentItemQuantities;

		public List<string> dailyCatalystRequirements;

		public void RecalculateValues(string profileName = null, ulong? clientId = null)
		{
		}

		public float GetSkillDiscountPercent(string profileName, ulong clientId)
		{
			return 0f;
		}

		public int GetUndiscountedMoneyRequired()
		{
			return 0;
		}

		public int GetDiscountedMoneyRequired(string profileName, ulong clientId)
		{
			return 0;
		}

		public bool HasReachedDailyLimit()
		{
			return false;
		}

		public int GetRemainingCompletions()
		{
			return 0;
		}
	}
}
