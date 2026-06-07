using System;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnMethods;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnObjects
{
	public class SpaceSpawnObject
	{
		public EMissionComplexity MinimumRequiredComplexity;

		public InteractiveWorldObject Object;

		public int MaxCount = 5;

		[OdinSerialize]
		protected SpaceSpawnMethod Method;

		protected System.Random RandomGenerator;

		public void Init(System.Random random)
		{
			RandomGenerator = random;
			Method.Init(random);
		}

		public void TryToSpawn()
		{
			int num = 0;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < MaxCount * 5; i++)
			{
				InteractiveWorldObject interactiveWorldObject = Method.TryToSpawn(Object);
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
