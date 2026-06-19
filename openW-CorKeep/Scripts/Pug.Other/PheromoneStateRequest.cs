using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public struct PheromoneStateRequest : IStateRequester
{
	private const float minGlobalTimer = 180f;

	private const float maxGlobalTimer = 360f;

	private const float keepFollowingTime = 60f;

	private float globalTimer;

	private EntityArchetype spawnGroupArchetype;

	private NativeArray<bool> didSpawnGroup;

	private bool didSpawnGroupLastFrame;

	private bool couldHaveStartedFollowLastFrame;

	private bool canSpawnGroup;

	private NativeList<ObjectDataCD> lastKilledEnemies;

	private Entity killedEnemiesBufferEntity;

	public void OnCreate(ref SystemState state)
	{
		didSpawnGroup = new NativeArray<bool>(1, Allocator.Persistent);
		didSpawnGroup[0] = false;
		NativeArray<ComponentType> types = new NativeArray<ComponentType>(1, Allocator.Temp);
		types[0] = ComponentType.ReadOnly<SpawnGroupCD>();
		spawnGroupArchetype = state.EntityManager.CreateArchetype(types);
		globalTimer = 180f;
		lastKilledEnemies = new NativeList<ObjectDataCD>(128, Allocator.Persistent);
	}

	public void OnDestroy(ref SystemState state)
	{
		didSpawnGroup.Dispose();
		lastKilledEnemies.Dispose();
	}

	public void OnBeforeUpdate(EntityManager entityManager, float deltaTime, EntityQuery killedEnemiesBufferQ, PugDatabase.DatabaseBankCD databaseBankCD)
	{
		if (killedEnemiesBufferEntity == Entity.Null)
		{
			if (killedEnemiesBufferQ.IsEmpty)
			{
				return;
			}
			killedEnemiesBufferEntity = killedEnemiesBufferQ.GetSingletonEntity();
			DynamicBuffer<KilledEnemiesBuffer> buffer = entityManager.GetBuffer<KilledEnemiesBuffer>(killedEnemiesBufferEntity);
			for (int i = 0; i < buffer.Length; i++)
			{
				ref NativeList<ObjectDataCD> reference = ref lastKilledEnemies;
				KilledEnemiesBuffer killedEnemiesBuffer = buffer[i];
				reference.Add(in killedEnemiesBuffer.objectData);
			}
		}
		didSpawnGroupLastFrame = didSpawnGroup[0];
		didSpawnGroup[0] = false;
		if (couldHaveStartedFollowLastFrame)
		{
			DynamicBuffer<KilledEnemiesBuffer> buffer2 = entityManager.GetBuffer<KilledEnemiesBuffer>(killedEnemiesBufferEntity);
			for (int j = 0; j < buffer2.Length; j++)
			{
				int k;
				for (k = 0; k < lastKilledEnemies.Length; k++)
				{
					if (lastKilledEnemies[k].Equals(buffer2[j].objectData))
					{
						lastKilledEnemies[k] = buffer2[j].objectData;
						break;
					}
				}
				if (k == lastKilledEnemies.Length && PugDatabase.GetEntityObjectInfo(buffer2[j].objectData.objectID, databaseBankCD.databaseBankBlob, buffer2[j].objectData.variation).objectType == ObjectType.Creature)
				{
					ref NativeList<ObjectDataCD> reference2 = ref lastKilledEnemies;
					KilledEnemiesBuffer killedEnemiesBuffer = buffer2[j];
					reference2.Add(in killedEnemiesBuffer.objectData);
				}
			}
		}
		couldHaveStartedFollowLastFrame = canSpawnGroup;
		globalTimer -= deltaTime;
		canSpawnGroup = false;
		if (globalTimer <= 0f)
		{
			canSpawnGroup = true;
			globalTimer = Random.Range(180f, 360f);
		}
	}

	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (killedEnemiesBufferEntity == Entity.Null)
		{
			return false;
		}
		if (c._followPheromoneGroup.HasComponent(entity) && c._followPheromoneGroup.HasComponent(entity) && c._pheromoneSensorGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity) && c._objectDataGroup.HasComponent(entity))
		{
			return c._distanceToPlayerGroup.HasComponent(entity);
		}
		return false;
	}

	public unsafe void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		FollowPheromoneStateCD followPheromoneStateCD = c._followPheromoneGroup[entity];
		PheromoneSensorCD pheromoneSensorCD = c._pheromoneSensorGroup[entity];
		ObjectDataCD objectDataCD = c._objectDataGroup[entity];
		DistanceToPlayerCD distanceToPlayerCD = c._distanceToPlayerGroup[entity];
		if (stateInfo.HasState(StateID.FollowPheromone) || !followPheromoneStateCD.cooldownTimer.IsTimerElapsed(d._elapsedTime) || didSpawnGroup[0])
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < 2; i++)
		{
			if (followPheromoneStateCD.mask.HasType((PheromoneType)i) && pheromoneSensorCD.direction.dirs[i] != 0)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		if (followPheromoneStateCD.keepFollowingTimer.isRunning && !followPheromoneStateCD.keepFollowingTimer.IsTimerElapsed(d._elapsedTime))
		{
			stateInfo.EnterState(StateID.FollowPheromone);
			return;
		}
		bool flag2 = didSpawnGroupLastFrame;
		bool flag3 = canSpawnGroup && !distanceToPlayerCD.isVisible;
		if (!flag2 && !flag3)
		{
			return;
		}
		DynamicBuffer<KilledEnemiesBuffer> buffer = c._killedEnemiesBufferGroup[killedEnemiesBufferEntity];
		bool exists;
		int index = EntityUtility.FindSorted(ref buffer, new KilledEnemiesBuffer
		{
			objectData = objectDataCD
		}, default(KilledEnemiesBufferComparer), out exists);
		if (!exists)
		{
			return;
		}
		for (int j = 0; j < lastKilledEnemies.Length; j++)
		{
			if (lastKilledEnemies[j].Equals(objectDataCD) && lastKilledEnemies[j].amount >= buffer[index].objectData.amount)
			{
				return;
			}
		}
		if (flag2)
		{
			stateInfo.EnterState(StateID.FollowPheromone);
			followPheromoneStateCD.keepFollowingTimer.Start(d._elapsedTime, 60f);
			return;
		}
		Entity e = ecb.CreateEntity(spawnGroupArchetype);
		ecb.SetComponent(e, new SpawnGroupCD
		{
			spawner = entity,
			spawnSize = 1f
		});
		didSpawnGroup[0] = true;
	}
}
