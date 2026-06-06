using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class CatalystDiscoverySaveData
	{
		public CatalystPlayerStatsSaveData stats;

		public List<CatalystBrewRecordEntry> history;

		public List<CatalystDiscoveryEntry> discoveries;

		public List<string> encounteredCatalysts;
	}
}
