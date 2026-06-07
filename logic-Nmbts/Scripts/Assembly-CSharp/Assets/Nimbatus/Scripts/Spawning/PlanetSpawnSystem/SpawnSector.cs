using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem
{
	public class SpawnSector
	{
		public ESpawnSectorType SectorType;

		public Dictionary<ESpawnRegion, bool> UnlockedRegions;

		public SpawnSector(ESpawnSectorType type, List<ESpawnRegion> allowedRegions)
		{
			SectorType = type;
			UnlockedRegions = new Dictionary<ESpawnRegion, bool>();
			IEnumerable<ESpawnRegion> enumerable = Enum.GetValues(typeof(ESpawnRegion)).Cast<ESpawnRegion>();
			bool flag = allowedRegions.Contains(ESpawnRegion.All);
			foreach (ESpawnRegion item in enumerable)
			{
				if (item != ESpawnRegion.All)
				{
					UnlockedRegions.Add(item, flag);
				}
			}
			if (flag)
			{
				return;
			}
			foreach (ESpawnRegion allowedRegion in allowedRegions)
			{
				UnlockedRegions[allowedRegion] = true;
			}
		}

		public void LockRegion(ESpawnRegion spawnRegion)
		{
			UnlockedRegions[spawnRegion] = false;
		}

		public bool CanSpawn(PlanetSpawnSetting spawn)
		{
			return UnlockedRegions[spawn.PossibleSpawnRegion];
		}
	}
}
