using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "OvernightSpawns", menuName = "Kitchen/Overnight Spawns")]
	public class GardenProfile : GameDataObject
	{
		[Serializable]
		public struct SpawnProbability
		{
			public Item Item;

			public float Chance;
		}

		public Appliance SpawnHolder;

		public List<SpawnProbability> Spawns;

		protected override void InitialiseDefaults()
		{
			Spawns = new List<SpawnProbability>();
		}

		public int GetSpawn()
		{
			foreach (SpawnProbability spawn in Spawns)
			{
				if (UnityEngine.Random.value < spawn.Chance)
				{
					return spawn.Item.ID;
				}
			}
			return Spawns.Last().Item.ID;
		}
	}
}
