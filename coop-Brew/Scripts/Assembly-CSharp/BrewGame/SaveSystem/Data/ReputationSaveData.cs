using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class ReputationSaveData
	{
		public float globalReputation;

		public List<NPCReputationEntry> npcReputations;
	}
}
