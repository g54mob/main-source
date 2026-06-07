using System;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class RuntimePrefabRule
	{
		public GameObject RuntimePrefab;

		public float DistanceFactor = 0.15f;

		public float SpawnFrequency = 1f;

		public int Seed;

		public bool UsePool = true;

		public Vector3 PrefabOffset = new Vector3(0f, 0f, 0f);

		public Vector3 PrefabRotation = new Vector3(0f, 0f, 0f);

		public Vector3 PrefabScale = new Vector3(1f, 1f, 1f);

		public LayerMask PrefabLayer = 0;

		public bool UseVegetationItemScale;

		public void SetSeed()
		{
			Seed = UnityEngine.Random.Range(0, 99);
		}

		public RuntimePrefabRule(RuntimePrefabRule sourceItem)
		{
			RuntimePrefab = sourceItem.RuntimePrefab;
			SpawnFrequency = sourceItem.SpawnFrequency;
			Seed = sourceItem.Seed;
			PrefabOffset = sourceItem.PrefabOffset;
			PrefabRotation = sourceItem.PrefabRotation;
			PrefabScale = sourceItem.PrefabScale;
			PrefabLayer = sourceItem.PrefabLayer;
			UseVegetationItemScale = sourceItem.UseVegetationItemScale;
			UsePool = sourceItem.UsePool;
		}

		public RuntimePrefabRule()
		{
		}
	}
}
