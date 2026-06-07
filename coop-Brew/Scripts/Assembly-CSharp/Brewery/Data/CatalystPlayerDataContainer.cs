using System;
using System.Collections.Generic;
using Brewery.Core;
using Brewery.Items;

namespace Brewery.Data
{
	[Serializable]
	public class CatalystPlayerDataContainer
	{
		public ulong playerId;

		public List<CatalystBrewRecord> history;

		public Dictionary<int, CatalystDiscoveryEntry> discoveries;

		public List<int> favoriteRecordIds;

		public CatalystPlayerStats stats;

		public HashSet<string> encounteredCatalysts;

		private int nextRecordId;

		private Dictionary<string, int> catalystUsageCounts;

		private Dictionary<int, int> brewCreationCounts;

		public CatalystPlayerDataContainer(ulong playerId)
		{
		}

		public CatalystBrewRecord AddBrewRecord(BeerDataSnapshot snapshot, int quantity = 1)
		{
			return default(CatalystBrewRecord);
		}

		private void UpdateStatsForNewBrew(CatalystBrewRecord record)
		{
		}

		private void UpdateCatalystUsage(string catalystId, int quantity = 1)
		{
		}

		private void RebuildTopCatalysts()
		{
		}

		private void UpdateDiscoveriesForNewBrew(CatalystBrewRecord record)
		{
		}

		private void TrackEncounteredCatalysts(CatalystBrewRecord record)
		{
		}

		public bool ToggleFavorite(int recordId)
		{
			return false;
		}

		public List<CatalystBrewRecord> GetFavorites()
		{
			return null;
		}

		public CatalystBrewRecord? GetRecordById(int recordId)
		{
			return null;
		}

		public bool IsDiscovered(BaseType baseType, string cat1, string cat2, string cat3)
		{
			return false;
		}
	}
}
