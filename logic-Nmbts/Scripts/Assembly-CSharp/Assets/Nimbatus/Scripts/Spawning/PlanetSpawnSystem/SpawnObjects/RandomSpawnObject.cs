using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnObjects
{
	public class RandomSpawnObject : SpawnObject
	{
		public List<InteractiveWorldObject> Objects = new List<InteractiveWorldObject>();

		public int MaxCount = 5;

		public override void TryToSpawn(ESpawnSectorType sector, ESpawnRegion region)
		{
			int num = 0;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < MaxCount * 5; i++)
			{
				InteractiveWorldObject objectToSpawn = Objects.RandomItem(RandomGenerator);
				InteractiveWorldObject interactiveWorldObject = Method.TryToSpawn(objectToSpawn, sector, region);
				if (interactiveWorldObject != null)
				{
					zero += interactiveWorldObject.transform.position;
					num++;
				}
				if (num >= MaxCount)
				{
					break;
				}
			}
		}
	}
}
