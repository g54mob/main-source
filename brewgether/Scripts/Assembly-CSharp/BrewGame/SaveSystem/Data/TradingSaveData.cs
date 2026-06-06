using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class TradingSaveData
	{
		public List<string> purchasedLockedTrades;

		public List<NPCTradingStateEntry> npcStates;

		public int lastKnownDayIndex;
	}
}
