using System;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	[Serializable]
	public abstract class SpawnMethod
	{
		public ESpawnLayer ObjectPlacement;

		public bool IgnoreCollision;

		[HideIf("IgnoreCollision", true)]
		public float MinDistance = 10f;

		protected System.Random RandomGenerator;

		protected NimbatusTerrainClimateZone ClimateZone;

		public void Init(System.Random randomGenerator)
		{
			RandomGenerator = randomGenerator;
			ClimateZone = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone;
		}

		public abstract InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region);

		public InteractiveWorldObject InstantiateSpawnObject(InteractiveWorldObject objectToSpawn, Vector2 position, Quaternion rotation)
		{
			float z = 0f;
			switch (ObjectPlacement)
			{
			case ESpawnLayer.Background:
				z = 1f;
				break;
			case ESpawnLayer.Foreground:
				z = -0.5f;
				break;
			}
			Vector3 position2 = new Vector3(position.x, position.y, z);
			if (!Physics.CheckSphere(position, MinDistance, BaseSingleton<CollisionLayerManager>.Instance.SpawnCheckLayerStructures) || IgnoreCollision)
			{
				InteractiveWorldObject interactiveWorldObject = UnityEngine.Object.Instantiate(objectToSpawn, position2, rotation);
				int seed = RandomGenerator.Next(int.MinValue, int.MaxValue);
				interactiveWorldObject.InitSpawn(seed);
				return interactiveWorldObject;
			}
			return null;
		}

		protected Vector2 GetCenterPosition(ESpawnSectorType sector, ESpawnRegion region)
		{
			if (region == ESpawnRegion.Core)
			{
				return Vector2.zero;
			}
			if (sector == ESpawnSectorType.All)
			{
				return Vector2.zero;
			}
			float angle = SpawnTransformHelper.ConvertToGlobalAngle(22.5f, sector);
			int height = 50;
			return ConvertToCoordinates(region, angle, height);
		}

		protected Vector2 GetPosition(ESpawnSectorType sector, ESpawnRegion region, float angle, int height)
		{
			if (sector == ESpawnSectorType.All)
			{
				return Vector2.zero;
			}
			float angle2 = SpawnTransformHelper.ConvertToGlobalAngle(angle, sector);
			return ConvertToCoordinates(region, angle2, height);
		}

		protected Vector2 ConvertToCoordinates(ESpawnRegion region, float angle, int height)
		{
			float regionMin = SpawnTransformHelper.GetRegionMin(region, ClimateZone.SelectedSettings.PlanetSize);
			float regionMax = SpawnTransformHelper.GetRegionMax(region, ClimateZone.SelectedSettings.PlanetSize);
			float radius = Mathf.Lerp(regionMin, regionMax, 0.01f * (float)height);
			return SpawnTransformHelper.GetCoordinates(angle, radius);
		}
	}
}
