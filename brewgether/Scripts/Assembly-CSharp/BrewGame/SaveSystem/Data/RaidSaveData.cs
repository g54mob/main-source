using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class RaidSaveData
	{
		public bool isRaidSystemActive;

		public int currentRaidState;

		public int daysUntilNextRaid;

		public int currentRaidTargetBarId;

		public List<ScheduledRevengeRaidEntry> scheduledRevengeRaids;
	}
}
