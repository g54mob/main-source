using Pug.Automation;
using Pug.Conversion;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using UnityEngine;

public class GhostConfigFromIMonoBehaviourData : IGhostConfigOverride
{
	public void OverrideGhostConfig(GameObject authoring, EntityManager entityManager, Entity entity, ref GhostPrefabCreation.Config config)
	{
		if (authoring.GetComponent(typeof(IEntityMonoBehaviourData)) is IEntityMonoBehaviourData entityMonoBehaviourData)
		{
			ObjectInfo objectInfo = entityMonoBehaviourData.ObjectInfo;
			ObjectID objectID = objectInfo.objectID;
			ObjectType objectType = objectInfo.objectType;
			int num = 1;
			GhostMode defaultGhostMode = config.DefaultGhostMode;
			GhostOptimizationMode optimizationMode = GhostOptimizationMode.Static;
			switch (objectType)
			{
			case ObjectType.Creature:
			{
				bool flag = entityManager.HasComponent<MovementSpeedCD>(entity) && entityManager.GetComponentData<MovementSpeedCD>(entity).speed > 20f;
				bool num2 = objectID == ObjectID.OrbitingMinion || entityManager.HasComponent<PhysicsVelocity>(entity);
				num = (flag ? 5 : 3);
				optimizationMode = ((!num2) ? GhostOptimizationMode.Static : GhostOptimizationMode.Dynamic);
				break;
			}
			case ObjectType.Critter:
				num = 2;
				optimizationMode = GhostOptimizationMode.Dynamic;
				break;
			case ObjectType.Pet:
				num = 15;
				optimizationMode = GhostOptimizationMode.Dynamic;
				break;
			case ObjectType.PlaceablePrefab:
				num = ((!entityManager.HasComponent<ContainedObjectsBuffer>(entity)) ? 1 : 2);
				optimizationMode = GhostOptimizationMode.Static;
				break;
			}
			if (entityManager.HasComponent<ProjectileCD>(entity) || entityManager.HasComponent<MortarProjectileCD>(entity))
			{
				num = math.max(7, num);
				optimizationMode = GhostOptimizationMode.Dynamic;
			}
			if (entityManager.HasComponent<BossCD>(entity))
			{
				num = 10;
				optimizationMode = GhostOptimizationMode.Dynamic;
			}
			else if (entityManager.HasComponent<SnakeMovementStateCD>(entity))
			{
				num = 5;
				optimizationMode = GhostOptimizationMode.Dynamic;
			}
			else if (entityManager.HasComponent<ElectricityCD>(entity))
			{
				num = math.max(num, 5);
			}
			switch (entityManager.GetComponentData<ObjectDataCD>(entity).objectID)
			{
			case ObjectID.Player:
				num = 25;
				optimizationMode = GhostOptimizationMode.Dynamic;
				break;
			case ObjectID.BirdBossBeam:
			case ObjectID.CoreBossBeam:
				num = 7;
				optimizationMode = GhostOptimizationMode.Dynamic;
				break;
			}
			config.Importance = num;
			config.DefaultGhostMode = defaultGhostMode;
			config.OptimizationMode = optimizationMode;
		}
	}
}
