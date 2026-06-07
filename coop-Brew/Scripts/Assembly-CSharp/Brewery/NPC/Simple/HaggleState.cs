using System;

namespace Brewery.NPC.Simple
{
	[Serializable]
	public class HaggleState
	{
		public string npcId;

		public int refusalCount;

		public float returnGameHour;

		public float currentBonusMultiplier;

		public HaggleState(string npcId)
		{
		}
	}
}
