using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class ManagerSaveData
	{
		public QuestSaveData quests;

		public TimeSaveData time;

		public ReputationSaveData reputation;

		public CrimeSaveData crime;

		public RaidSaveData raids;

		public TradingSaveData trading;

		public List<EmployeeSaveData> employees;

		public CatalystDiscoverySaveData catalystDiscovery;
	}
}
