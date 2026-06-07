using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class ScheduledRevengeRaidEntry
	{
		public int targetBarId;

		public int scheduledDay;

		public float scheduledHour;

		public int thugCount;

		public string attackerSteamId;
	}
}
