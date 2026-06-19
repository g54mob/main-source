using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[UpdateBefore(typeof(TileDamageSystem))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct ExplosionDamageSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(ExplosionCD),
		typeof(Simulate),
		typeof(LocalTransform),
		typeof(ObjectDataCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct ExplosionDamageJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostInstance>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ExplosionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref ExplosionDamageJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ExplosionDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ExplosionDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ExplosionDamageJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ExplosionDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ExplosionDamageJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> indesctructibleLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> levelLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> levelEntitiesBufferLookup;

		public ComponentLookup<IsSpawningTilesFromExplosionCD> isSpawningTileOnExplosionLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public BufferLookup<TileDamageBuffer> tileDamageBufferLookup;

		public Entity tileUpdateBufferEntity;

		public Entity tileDamageBufferEntity;

		public uint tickRate;

		public NetworkTick currentTick;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public AttackSystem.Helper attackHelper;

		public Entity effectEventBufferSingleton;

		public NativeList<int2> tileHitPositions;

		public bool isServer;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in BehaviourTagsCD attackTags, in GhostInstance ghostInstance)
		{
			_ = attackHelper.objectDataLookup[entity];
			LocalTransform localTransform = attackHelper.localTransformLookup[entity];
			ref ExplosionCD valueRW = ref attackHelper.explosionLookup.GetRefRW(entity).ValueRW;
			if (valueRW.hasDealtDamage)
			{
				return;
			}
			if (!valueRW.delayTimer.isRunning)
			{
				valueRW.delayTimer.Start(currentTick, 0.1f, tickRate);
			}
			if (!valueRW.delayTimer.IsTimerElapsed(currentTick))
			{
				return;
			}
			int increasedBurningDamagePercentage = 0;
			float num = 1f;
			if (!valueRW.cameFromExplosive)
			{
				if (attackHelper.summarizedConditionEffectsBufferLookup.TryGetBuffer(entity, out var bufferData))
				{
					num += (float)bufferData[46].value / 100f;
					float num2 = (float)bufferData[120].value / 100f;
					valueRW.radius += valueRW.radius * num2;
				}
			}
			else
			{
				increasedBurningDamagePercentage = valueRW.napalmIncreasedBurningDamagePercentage;
			}
			if (valueRW.spawnNapalmObjectID != ObjectID.None)
			{
				EntityUtility.SpawnFireTrapOrNapalm(valueRW.spawnNapalmObjectID, valueRW.spawnNapalmVariation, localTransform.Position, valueRW.level, increasedBurningDamagePercentage, ecb, attackHelper.propertiesLookup, attackHelper.attackContinuouslyLookup, levelEntitiesBufferLookup, levelLookup, attackHelper.conditionsBufferLookup, attackHelper.databaseBank, attackHelper.isFirstTimeFullyPredictingTick);
			}
			if (isSpawningTileOnExplosionLookup.HasComponent(entity))
			{
				isSpawningTileOnExplosionLookup.SetComponentEnabled(entity, value: true);
			}
			valueRW.hasDealtDamage = true;
			tileHitPositions.Clear();
			int num3 = (int)((float)valueRW.damage * num);
			int tileDamage = valueRW.tileDamage;
			float radius = valueRW.radius;
			bool flag = false;
			Entity causedByEntity = entity;
			if (ownerLookup.TryGetComponent(entity, out var componentData))
			{
				causedByEntity = componentData.owner;
				flag = playerGhostLookup.HasComponent(componentData.owner);
			}
			if (!flag && !isServer)
			{
				return;
			}
			float pushback = valueRW.explosionPushback switch
			{
				ExplosionPushbackLevel.Small => 0.5f, 
				ExplosionPushbackLevel.Normal => 2f, 
				_ => 0f, 
			};
			AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
			{
				effectEventBufferSingleton = effectEventBufferSingleton,
				attacker = entity,
				radius = radius,
				damage = num3,
				playerDamage = num3,
				pushback = pushback,
				bypassMaxDamagePerHit = true,
				canHitLowTriggers = true,
				behaviourTags = attackTags,
				canAttackOwner = true,
				isExplosive = true,
				isExplosiveDamageFromBomb = valueRW.cameFromBomb,
				isPredicted = flag,
				skipHitsOnEntity = ((valueRW.triggerEntityToIgnoreExplosionDamage != Entity.Null) ? valueRW.triggerEntityToIgnoreExplosionDamage : valueRW.nonSyncedTriggerEntityToIgnoreExplosionDamage)
			};
			attackHelper.Attack(ecb, ref tileHitPositions, in p);
			bool flag2 = false;
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			if (attackHelper.physicsWorld.CollisionWorld.OverlapSphere(localTransform.Position, radius, ref outHits, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 1024u
			}))
			{
				for (int i = 0; i < outHits.Length; i++)
				{
					if (indesctructibleLookup.HasAndIsComponentEnabled(outHits[i].Entity))
					{
						flag2 = true;
						break;
					}
				}
			}
			outHits.Dispose();
			_ = ref attackHelper.randomLookup.GetRefRW(entity).ValueRW;
			float2 y = new float2(localTransform.Position.x, localTransform.Position.z);
			int2 int5 = new int2((int)math.round(y.x), (int)math.round(y.y));
			DynamicBuffer<TileDamageBuffer> dynamicBuffer = tileDamageBufferLookup[tileDamageBufferEntity];
			DynamicBuffer<TileUpdateBuffer> dynamicBuffer2 = tileUpdateBufferLookup[tileUpdateBufferEntity];
			for (int j = -4; j <= 4; j++)
			{
				for (int k = -4; k <= 4; k++)
				{
					int2 int6 = new int2(j, k) + int5;
					if (math.distance(int6, y) > radius)
					{
						continue;
					}
					if (tileDamage > 0)
					{
						dynamicBuffer.Add(new TileDamageBuffer
						{
							damage = tileDamage,
							position = int6,
							canHitLowColliders = true,
							bypassMaxDamagePerHit = true,
							damagedByExplosion = true,
							dontHitGroundSlime = true,
							causedByEntity = causedByEntity
						});
					}
					if (!flag2 && !tileHitPositions.Contains(int6))
					{
						TileCD top = attackHelper.tileAccessor.GetTop(int6);
						if (top.tileType == TileType.ground && tileDamage > 0 && PugDatabase.TileExists(top.tileset, TileType.dugUpGround, databaseBankCD.databaseBankBlob))
						{
							dynamicBuffer2.Add(new TileUpdateBuffer
							{
								command = TileUpdateBuffer.Command.Add,
								position = int6,
								tile = new TileCD
								{
									tileset = top.tileset,
									tileType = TileType.dugUpGround
								}
							});
						}
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GhostInstance>(nativeArrayPtr3, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SpawnTileOnExplosionJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<SpawnTileOnExplosionCD> __SpawnTileOnExplosionCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ExplosionCD> __ExplosionCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public ComponentTypeHandle<IsSpawningTilesFromExplosionCD> __IsSpawningTilesFromExplosionCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__SpawnTileOnExplosionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnTileOnExplosionCD>();
					__ExplosionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ExplosionCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__IsSpawningTilesFromExplosionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<IsSpawningTilesFromExplosionCD>();
				}

				public void Update(ref SystemState state)
				{
					__SpawnTileOnExplosionCD_RW_ComponentTypeHandle.Update(ref state);
					__ExplosionCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__IsSpawningTilesFromExplosionCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ExplosionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SpawnTileOnExplosionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<IsSpawningTilesFromExplosionCD>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref SpawnTileOnExplosionJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnTileOnExplosionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnTileOnExplosionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnTileOnExplosionJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnTileOnExplosionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnTileOnExplosionJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> indesctructibleLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public Entity tileUpdateBufferEntity;

		public CollisionWorld collisionWorld;

		public TileAccessor tileAccessor;

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref SpawnTileOnExplosionCD spawnTileOnExplosionCD, in ExplosionCD explosionCD, ref RandomCD randomCD, in LocalTransform transform, EnabledRefRW<IsSpawningTilesFromExplosionCD> isSpawningTilesFromExplosionEnabled)
		{
			if (!spawnTileOnExplosionCD.spawnTimer.isRunning)
			{
				spawnTileOnExplosionCD.spawnTimer.Start(currentTick);
				spawnTileOnExplosionCD.random = new Unity.Mathematics.Random(randomCD.Value.NextUInt(1u, uint.MaxValue));
				return;
			}
			if (spawnTileOnExplosionCD.spawnTimer.IsTimerElapsed(currentTick))
			{
				isSpawningTilesFromExplosionEnabled.ValueRW = false;
			}
			float radius = explosionCD.radius;
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			NetworkTick networkTick = currentTick;
			networkTick.Decrement();
			float elapsedRatio = spawnTileOnExplosionCD.spawnTimer.GetElapsedRatio(networkTick);
			float elapsedRatio2 = spawnTileOnExplosionCD.spawnTimer.GetElapsedRatio(currentTick);
			float num = radius * math.sqrt(elapsedRatio);
			float num2 = radius * math.sqrt(elapsedRatio2);
			float2 y = new float2(transform.Position.x, transform.Position.z);
			int2 int5 = new int2((int)math.round(y.x), (int)math.round(y.y));
			DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer = tileUpdateBufferLookup[tileUpdateBufferEntity];
			for (int i = -4; i <= 4; i++)
			{
				for (int j = -4; j <= 4; j++)
				{
					int2 int6 = new int2(i, j) + int5;
					float num3 = math.distance(int6, y);
					if (num3 < num || num3 >= num2)
					{
						continue;
					}
					float num4 = radius - num3;
					if (spawnTileOnExplosionCD.random.NextFloat() > num4)
					{
						continue;
					}
					outHits.Clear();
					bool flag = false;
					if (collisionWorld.OverlapSphere(int6.ToFloat3(), 0.45f, ref outHits, new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 131329u
					}))
					{
						for (int k = 0; k < outHits.Length; k++)
						{
							if (indesctructibleLookup.HasAndIsComponentEnabled(outHits[k].Entity))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						TileCD top = tileAccessor.GetTop(int6);
						if (!spawnTileOnExplosionCD.spawnRequiresWalkable || top.tileType.IsWalkableTile())
						{
							TryAddTileAtPos(int6, tileAccessor, tileUpdateBuffer, spawnTileOnExplosionCD.tileType, spawnTileOnExplosionCD.tileset);
						}
					}
				}
			}
			outHits.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void TryAddTileAtPos(int2 tilePos, TileAccessor tileAccessor, DynamicBuffer<TileUpdateBuffer> tileUpdateBuffer, TileType tileType, Tileset tileset)
		{
			if (!tileAccessor.HasType(tilePos, TileType.immune))
			{
				tileUpdateBuffer.Add(new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Add,
					position = tilePos,
					tile = new TileCD
					{
						tileType = tileType,
						tileset = (int)tileset
					}
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SpawnTileOnExplosionCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ExplosionCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			EnabledMask enabledMask = chunk.GetEnabledMask(ref __TypeHandle.__IsSpawningTilesFromExplosionCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnExplosionCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplosionCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, i), enabledMask.GetEnabledRefRW<IsSpawningTilesFromExplosionCD>(i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnExplosionCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplosionCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, nextRangeBegin), enabledMask.GetEnabledRefRW<IsSpawningTilesFromExplosionCD>(nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnExplosionCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplosionCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, j), enabledMask.GetEnabledRefRW<IsSpawningTilesFromExplosionCD>(j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnExplosionCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ExplosionCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr4, k), enabledMask.GetEnabledRefRW<IsSpawningTilesFromExplosionCD>(k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> __IndestructibleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LevelCD> __LevelCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<LevelEntitiesBuffer> __LevelEntitiesBuffer_RO_BufferLookup;

		public ComponentLookup<IsSpawningTilesFromExplosionCD> __IsSpawningTilesFromExplosionCD_RW_ComponentLookup;

		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		public BufferLookup<TileDamageBuffer> __TileDamageBuffer_RW_BufferLookup;

		public ExplosionDamageJob.InternalCompilerQueryAndHandleData __ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle;

		public SpawnTileOnExplosionJob.InternalCompilerQueryAndHandleData __ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__IndestructibleCD_RO_ComponentLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
			__LevelCD_RO_ComponentLookup = state.GetComponentLookup<LevelCD>(isReadOnly: true);
			__LevelEntitiesBuffer_RO_BufferLookup = state.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
			__IsSpawningTilesFromExplosionCD_RW_ComponentLookup = state.GetComponentLookup<IsSpawningTilesFromExplosionCD>();
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__TileDamageBuffer_RW_BufferLookup = state.GetBufferLookup<TileDamageBuffer>();
			__ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00001DE7_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00001DE7_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00001DE7_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00001DE8_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001DE8_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001DE8_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	public const float DEFAULT_EXPLOSION_DELAY = 0.1f;

	private NativeList<int2> _tileHitPositions;

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1675154163_0;

	private EntityQuery __query_1675154163_1;

	private EntityQuery __query_1675154163_2;

	private EntityQuery __query_1675154163_3;

	private EntityQuery __query_1675154163_4;

	private EntityQuery __query_1675154163_5;

	private EntityQuery __query_1675154163_6;

	private EntityQuery __query_1675154163_7;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<WorldInfoCD>();
		_tileHitPositions = new NativeList<int2>(16, Allocator.Persistent);
		state.RequireForUpdate<ExplosionCD>();
	}

	public void OnDestroy(ref SystemState state)
	{
		_tileHitPositions.Dispose();
	}

	public void OnStartRunning(ref SystemState state)
	{
		if (!_attackHelper.isCreated)
		{
			_attackHelper = new AttackSystem.Helper(ref state, __query_1675154163_0.GetSingleton<ClientServerTickRate>().SimulationTickRate);
		}
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_1675154163_1.TryGetSingleton<NetworkTime>(out var value);
		_attackHelper.Update(ref state, value.ServerTick, (uint)__query_1675154163_0.GetSingleton<ClientServerTickRate>().SimulationTickRate);
		BeginSimulationEntityCommandBufferSystem.Singleton singleton = __query_1675154163_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
		ExplosionDamageJob job = new ExplosionDamageJob
		{
			ownerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
			indesctructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state),
			levelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LevelCD_RO_ComponentLookup, ref state),
			levelEntitiesBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__LevelEntitiesBuffer_RO_BufferLookup, ref state),
			isSpawningTileOnExplosionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsSpawningTilesFromExplosionCD_RW_ComponentLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			tileDamageBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileDamageBuffer_RW_BufferLookup, ref state),
			tileUpdateBufferEntity = __query_1675154163_3.GetSingletonEntity(),
			tileDamageBufferEntity = __query_1675154163_4.GetSingletonEntity(),
			tickRate = (uint)__query_1675154163_0.GetSingleton<ClientServerTickRate>().SimulationTickRate,
			currentTick = value.ServerTick,
			ecb = singleton.CreateCommandBuffer(state.WorldUnmanaged),
			databaseBankCD = __query_1675154163_5.GetSingleton<PugDatabase.DatabaseBankCD>(),
			attackHelper = _attackHelper,
			effectEventBufferSingleton = __query_1675154163_6.GetSingletonEntity(),
			tileHitPositions = _tileHitPositions,
			isServer = state.WorldUnmanaged.IsServer()
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new SpawnTileOnExplosionJob
		{
			indesctructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			tileUpdateBufferEntity = __query_1675154163_3.GetSingletonEntity(),
			collisionWorld = __query_1675154163_7.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			tileAccessor = _attackHelper.tileAccessor,
			currentTick = value.ServerTick
		}, __TypeHandle.__ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ref ExplosionDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosionDamageSystem_ExplosionDamageJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(SpawnTileOnExplosionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__ExplosionDamageSystem_SpawnTileOnExplosionJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1675154163_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__OnCreate_00001DE7_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001DE8_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		((ExplosionDamageSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((ExplosionDamageSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((ExplosionDamageSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ExplosionDamageSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ExplosionDamageSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ExplosionDamageSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
