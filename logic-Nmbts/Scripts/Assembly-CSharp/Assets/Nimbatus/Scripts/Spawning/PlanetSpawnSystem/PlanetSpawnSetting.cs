using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnObjects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem
{
	public class PlanetSpawnSetting
	{
		[PropertyRange(1.0, 8.0)]
		public int NumberOfSectors = 1;

		public bool IgnoreBlockedSectors;

		public List<ESpawnSectorType> PossibleSpawnSectors = new List<ESpawnSectorType> { ESpawnSectorType.All };

		public ESpawnRegion PossibleSpawnRegion = ESpawnRegion.Surface;

		[OdinSerialize]
		protected List<SpawnObject> Spawns = new List<SpawnObject>();

		[NonSerialized]
		[HideInInspector]
		public List<ESpawnSectorType> UsedSpawnSectors;

		public void Init(System.Random random)
		{
			foreach (SpawnObject spawn in Spawns)
			{
				spawn.Init(random);
			}
			UsedSpawnSectors = new List<ESpawnSectorType>();
		}

		public bool TryToSpawn(ESpawnSectorType sector)
		{
			EMissionComplexity activeMissionComplexity = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetActiveMissionComplexity();
			foreach (SpawnObject spawn in Spawns)
			{
				if (spawn.MinimumRequiredComplexity == EMissionComplexity.None || activeMissionComplexity >= spawn.MinimumRequiredComplexity)
				{
					spawn.TryToSpawn(sector, PossibleSpawnRegion);
				}
			}
			return true;
		}
	}
}
