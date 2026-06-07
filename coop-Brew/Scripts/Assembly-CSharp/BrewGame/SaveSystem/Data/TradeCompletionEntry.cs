using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class TradeCompletionEntry
	{
		public string tradeId;

		public int completionCount;

		public float dailyPriceMultiplier;
	}
}
