using System;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnObjects
{
	[Serializable]
	public abstract class SpawnObject
	{
		public EMissionComplexity MinimumRequiredComplexity;

		protected Random RandomGenerator;

		[OdinSerialize]
		protected SpawnMethod Method;

		public void Init(Random random)
		{
			RandomGenerator = random;
			Method.Init(random);
		}

		public abstract void TryToSpawn(ESpawnSectorType sector, ESpawnRegion region);
	}
}
