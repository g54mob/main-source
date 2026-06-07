using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnObjects;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem
{
	public class SpaceSpawnSetting
	{
		[OdinSerialize]
		protected List<SpaceSpawnObject> Spawns = new List<SpaceSpawnObject>();

		public void Init(Random random)
		{
			foreach (SpaceSpawnObject spawn in Spawns)
			{
				spawn.Init(random);
			}
		}

		public bool TryToSpawn()
		{
			EMissionComplexity activeMissionComplexity = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetActiveMissionComplexity();
			foreach (SpaceSpawnObject spawn in Spawns)
			{
				if (spawn.MinimumRequiredComplexity == EMissionComplexity.None || activeMissionComplexity >= spawn.MinimumRequiredComplexity)
				{
					spawn.TryToSpawn();
				}
			}
			return true;
		}
	}
}
