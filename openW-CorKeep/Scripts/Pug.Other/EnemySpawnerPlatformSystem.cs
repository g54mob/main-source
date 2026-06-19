using System;
using System.Runtime.CompilerServices;
using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class EnemySpawnerPlatformSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_0_Job : IJobChunk
	{
		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public EntityCommandBuffer ecb;

		public double time;

		public Unity.Mathematics.Random rnd;

		[ReadOnly]
		public TileAccessor tileLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> dontDropLookLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ElectricityCD> __electricityTypeHandle;

		public BufferTypeHandle<ContainedObjectsBuffer> __inventoryTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DistanceToPlayerCD> __distanceToPlayerCDTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnemySpawnerPlatformCD> __EnemySpawnerPlatformCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TrophyCD> __TrophyCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsCloneCD> __IsCloneCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RandomWalkStateCD> __RandomWalkStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BushStateCD> __BushStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ChaseStateCD> __ChaseStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AttackCooldownTimerCD> __AttackCooldownTimerCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ScaleHealthByPlayerCountCD> __ScaleHealthByPlayerCountCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in LocalTransform transform, [NoAlias] in ElectricityCD electricity, DynamicBuffer<ContainedObjectsBuffer> inventory, [NoAlias] in DistanceToPlayerCD distanceToPlayerCD)
		{
			EnemySpawnerPlatformCD component = __EnemySpawnerPlatformCD_ComponentLookup[entity];
			if (component.spawnedEntity == Entity.Null || (entityDestroyedLookup.HasComponent(component.spawnedEntity) && entityDestroyedLookup.IsComponentEnabled(component.spawnedEntity)) || !__ObjectDataCD_ComponentLookup.HasComponent(component.spawnedEntity))
			{
				if (!electricity.hasEnoughElectricityToPowerStuff && !component.timer.isRunning)
				{
					return;
				}
				bool flag = component.isCustomSceneSpawner && tileLookup.HasType(transform.Position.RoundToInt2(), TileType.immune);
				if (flag && distanceToPlayerCD.minDistanceSq > 1600f)
				{
					return;
				}
				ObjectID objectID = component.enemyToSpawn;
				if (!flag)
				{
					objectID = ObjectID.None;
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(inventory[0].objectData.objectID, databaseLocal);
					if (__TrophyCD_ComponentLookup.HasComponent(primaryPrefabEntity))
					{
						objectID = __TrophyCD_ComponentLookup[primaryPrefabEntity].enemyToSpawnFromSpawnerPlatform;
					}
				}
				if (objectID == ObjectID.None)
				{
					if (component.isSpawning)
					{
						component.isSpawning = false;
						component.timer.Stop();
						ecb.SetComponent(entity, component);
					}
				}
				else if (electricity.hasEnoughElectricityToPowerStuff && !component.timer.isRunning)
				{
					component.timer.Start(time, 2f);
					component.isSpawning = true;
					ecb.SetComponent(entity, component);
				}
				else
				{
					if (!component.timer.isRunning || !component.timer.IsTimerElapsed(time))
					{
						return;
					}
					Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseLocal);
					Entity e = (component.spawnedEntity = EntityUtility.CreateEntity(ecb, transform.Position, objectID, 1, databaseLocal));
					ecb.AddComponent<DontSerializeCD>(e);
					if (dontDropLookLookup.HasComponent(primaryPrefabEntity2))
					{
						ecb.SetComponentEnabled<DontDropLootCD>(e, value: true);
					}
					Entity primaryPrefabEntity3 = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseLocal);
					if (__IsCloneCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
					{
						ecb.SetComponentEnabled<IsCloneCD>(e, value: true);
					}
					if (__RandomWalkStateCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
					{
						RandomWalkStateCD component2 = __RandomWalkStateCD_ComponentLookup[primaryPrefabEntity3];
						component2.cooldownTimer.Start(time, 1f);
						ecb.SetComponent(e, component2);
					}
					if (__BushStateCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
					{
						BushStateCD component3 = __BushStateCD_ComponentLookup[primaryPrefabEntity3];
						component3.cooldownTimer.Start(time, 3f);
						ecb.SetComponent(e, component3);
					}
					if (flag)
					{
						if (__NearbyEntitiesTrackerCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
						{
							NearbyEntitiesTrackerCD component4 = __NearbyEntitiesTrackerCD_ComponentLookup[primaryPrefabEntity3];
							component4.radius = 20f;
							ecb.SetComponent(e, component4);
						}
						if (__ChaseStateCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
						{
							ChaseStateCD component5 = __ChaseStateCD_ComponentLookup[primaryPrefabEntity3];
							component5.chaseAtDistanceSq = 400f;
							component5.neverTimeoutChasing = true;
							component5.cooldownTimer.Start(time, 1f);
							ecb.SetComponent(e, component5);
						}
						if (__AttackCooldownTimerCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
						{
							AttackCooldownTimerCD component6 = __AttackCooldownTimerCD_ComponentLookup[primaryPrefabEntity3];
							component6.Value.Start(time, rnd.NextFloat(1f, 2f));
							ecb.SetComponent(e, component6);
						}
						if (!__ScaleHealthByPlayerCountCD_ComponentLookup.HasComponent(primaryPrefabEntity3))
						{
							ecb.AddComponent(e, new ScaleHealthByPlayerCountCD
							{
								scalingFactor = 0.3f
							});
						}
						ecb.AddComponent(e, new DestroyEntityWhenNoNearbyPlayerCD
						{
							distanceSq = 1600f
						});
					}
					ecb.SetComponent(entity, component);
				}
			}
			else
			{
				component.isSpawning = false;
				component.timer.Stop();
				ecb.SetComponent(entity, component);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __electricityTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __inventoryTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __distanceToPlayerCDTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr3, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_1_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public Entity healthChangeBufferEntity;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentTypeHandle<EnemySpawnerPlatformCD> __platformTypeHandle;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in EnemySpawnerPlatformCD platform)
		{
			if (platform.spawnedEntity != Entity.Null && (!entityDestroyedLookup.HasComponent(platform.spawnedEntity) || !entityDestroyedLookup.IsComponentEnabled(platform.spawnedEntity)) && __HealthCD_ComponentLookup.HasComponent(platform.spawnedEntity))
			{
				HealthCD healthCD = __HealthCD_ComponentLookup[platform.spawnedEntity];
				ecb.AppendToBuffer(healthChangeBufferEntity, new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = platform.spawnedEntity,
						amount = -healthCD.health,
						wasKilled = true
					}
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __platformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_2_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public Entity healthChangeBufferEntity;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EnemySpawnerPlatformCD> __platformTypeHandle;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in EnemySpawnerPlatformCD platform)
		{
			if (platform.spawnedEntity != Entity.Null && (!entityDestroyedLookup.HasComponent(platform.spawnedEntity) || !entityDestroyedLookup.IsComponentEnabled(platform.spawnedEntity)) && __HealthCD_ComponentLookup.HasComponent(platform.spawnedEntity) && __Unity_Transforms_LocalTransform_ComponentLookup.HasComponent(platform.spawnedEntity) && !(math.distancesq(__Unity_Transforms_LocalTransform_ComponentLookup[entity].Position, __Unity_Transforms_LocalTransform_ComponentLookup[platform.spawnedEntity].Position) < 1600f))
			{
				HealthCD healthCD = __HealthCD_ComponentLookup[platform.spawnedEntity];
				ecb.AppendToBuffer(healthChangeBufferEntity, new HealthChangeBuffer
				{
					healthChange = new HealthChange
					{
						entity = platform.spawnedEntity,
						amount = -healthCD.health,
						wasKilled = true
					}
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __platformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemySpawnerPlatformCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnemySpawnerPlatformCD> __EnemySpawnerPlatformCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<TrophyCD> __TrophyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsCloneCD> __IsCloneCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RandomWalkStateCD> __RandomWalkStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BushStateCD> __BushStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ChaseStateCD> __ChaseStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AttackCooldownTimerCD> __AttackCooldownTimerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ScaleHealthByPlayerCountCD> __ScaleHealthByPlayerCountCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentTypeHandle<EnemySpawnerPlatformCD> __EnemySpawnerPlatformCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
			__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
			__EnemySpawnerPlatformCD_RO_ComponentLookup = state.GetComponentLookup<EnemySpawnerPlatformCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__TrophyCD_RO_ComponentLookup = state.GetComponentLookup<TrophyCD>(isReadOnly: true);
			__IsCloneCD_RO_ComponentLookup = state.GetComponentLookup<IsCloneCD>(isReadOnly: true);
			__RandomWalkStateCD_RO_ComponentLookup = state.GetComponentLookup<RandomWalkStateCD>(isReadOnly: true);
			__BushStateCD_RO_ComponentLookup = state.GetComponentLookup<BushStateCD>(isReadOnly: true);
			__NearbyEntitiesTrackerCD_RO_ComponentLookup = state.GetComponentLookup<NearbyEntitiesTrackerCD>(isReadOnly: true);
			__ChaseStateCD_RO_ComponentLookup = state.GetComponentLookup<ChaseStateCD>(isReadOnly: true);
			__AttackCooldownTimerCD_RO_ComponentLookup = state.GetComponentLookup<AttackCooldownTimerCD>(isReadOnly: true);
			__ScaleHealthByPlayerCountCD_RO_ComponentLookup = state.GetComponentLookup<ScaleHealthByPlayerCountCD>(isReadOnly: true);
			__EnemySpawnerPlatformCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnemySpawnerPlatformCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__DontDropLootCD_RO_ComponentLookup = state.GetComponentLookup<DontDropLootCD>(isReadOnly: true);
		}
	}

	private const float DISTANCE_SQ_FROM_PLAYER_TO_DESTROY_SPAWNED_ENTITY = 1600f;

	private const float DISTANCE_SQ_FROM_PLATFORM_TO_DESTROY_SPAWNED_ENTITY = 1600f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_697243137_0;

	private EntityQuery __query_697243137_1;

	private EntityQuery __query_697243137_2;

	private EntityQuery __query_697243137_3;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		RequireForUpdate<EffectEventBuffer>();
		RequireForUpdate<EnemySpawnerPlatformCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		TileAccessor tileLookup = CreateTileAccessor();
		Entity singletonEntity = __query_697243137_3.GetSingletonEntity();
		ComponentLookup<EntityDestroyedCD> componentLookup = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		ComponentLookup<DontDropLootCD> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RO_ComponentLookup, ref base.CheckedStateRef);
		EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_0_Execute(databaseLocal, ecb, elapsedTime, rng, tileLookup, componentLookup, componentLookup2);
		EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_1_Execute(ecb, singletonEntity, componentLookup);
		EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_2_Execute(ecb, singletonEntity, componentLookup);
		base.OnUpdate();
	}

	private void EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_0_Execute(BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, EntityCommandBuffer ecb, double time, Unity.Mathematics.Random rnd, TileAccessor tileLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, ComponentLookup<DontDropLootCD> dontDropLookLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__TrophyCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__IsCloneCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__RandomWalkStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__BushStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__NearbyEntitiesTrackerCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ChaseStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__AttackCooldownTimerCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ScaleHealthByPlayerCountCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_0_Job jobData = new EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_0_Job
		{
			databaseLocal = databaseLocal,
			ecb = ecb,
			time = time,
			rnd = rnd,
			tileLookup = tileLookup,
			entityDestroyedLookup = entityDestroyedLookup,
			dontDropLookLookup = dontDropLookLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__electricityTypeHandle = __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle,
			__inventoryTypeHandle = __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle,
			__distanceToPlayerCDTypeHandle = __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle,
			__EnemySpawnerPlatformCD_ComponentLookup = __TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup,
			__TrophyCD_ComponentLookup = __TypeHandle.__TrophyCD_RO_ComponentLookup,
			__IsCloneCD_ComponentLookup = __TypeHandle.__IsCloneCD_RO_ComponentLookup,
			__RandomWalkStateCD_ComponentLookup = __TypeHandle.__RandomWalkStateCD_RO_ComponentLookup,
			__BushStateCD_ComponentLookup = __TypeHandle.__BushStateCD_RO_ComponentLookup,
			__NearbyEntitiesTrackerCD_ComponentLookup = __TypeHandle.__NearbyEntitiesTrackerCD_RO_ComponentLookup,
			__ChaseStateCD_ComponentLookup = __TypeHandle.__ChaseStateCD_RO_ComponentLookup,
			__AttackCooldownTimerCD_ComponentLookup = __TypeHandle.__AttackCooldownTimerCD_RO_ComponentLookup,
			__ScaleHealthByPlayerCountCD_ComponentLookup = __TypeHandle.__ScaleHealthByPlayerCountCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_697243137_0, base.CheckedStateRef.Dependency);
	}

	private void EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_1_Execute(EntityCommandBuffer ecb, Entity healthChangeBufferEntity, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup)
	{
		__TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_1_Job jobData = new EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_1_Job
		{
			ecb = ecb,
			healthChangeBufferEntity = healthChangeBufferEntity,
			entityDestroyedLookup = entityDestroyedLookup,
			__platformTypeHandle = __TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentTypeHandle,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_697243137_1, base.CheckedStateRef.Dependency);
	}

	private void EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_2_Execute(EntityCommandBuffer ecb, Entity healthChangeBufferEntity, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_2_Job jobData = new EnemySpawnerPlatformSystem_FCA3E27_LambdaJob_2_Job
		{
			ecb = ecb,
			healthChangeBufferEntity = healthChangeBufferEntity,
			entityDestroyedLookup = entityDestroyedLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__platformTypeHandle = __TypeHandle.__EnemySpawnerPlatformCD_RO_ComponentTypeHandle,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_697243137_2, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnemySpawnerPlatformCD>();
		__query_697243137_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EnemySpawnerPlatformCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
		__query_697243137_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EnemySpawnerPlatformCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		__query_697243137_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_697243137_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public EnemySpawnerPlatformSystem()
	{
	}
}
