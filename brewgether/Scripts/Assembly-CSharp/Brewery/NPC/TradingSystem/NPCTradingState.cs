using System.Collections.Generic;

namespace Brewery.NPC.TradingSystem
{
	public class NPCTradingState
	{
		public string npcId;

		public Dictionary<string, TradeInstance> trades;

		public TradeInstance GetTrade(string tradeId)
		{
			return null;
		}

		public bool HasAvailableTrades()
		{
			return false;
		}

		public int GetAvailableTradeCount()
		{
			return 0;
		}
	}
}
