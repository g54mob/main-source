using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class NPCTradingStateEntry
	{
		public string npcId;

		public float reputation;

		public List<TradeCompletionEntry> tradeCompletions;
	}
}
