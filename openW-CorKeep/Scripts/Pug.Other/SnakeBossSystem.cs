using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct SnakeBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	[WithAll(new Type[] { typeof(SnakeBossCD) })]
	private struct FindAvailableSnakeGroupIndexJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
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
			public void Run(ref FindAvailableSnakeGroupIndexJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FindAvailableSnakeGroupIndexJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FindAvailableSnakeGroupIndexJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FindAvailableSnakeGroupIndexJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FindAvailableSnakeGroupIndexJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FindAvailableSnakeGroupIndexJob job, EntityManager entityManager)
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

		public NativeReference<Entity> lowestSegmentEntity;

		public NativeReference<int> lowestSegmentEntityGroupIndex;

		public NativeReference<int> lowestSegmentEntityIndex;

		public NativeParallelHashSet<int> anyRemainingLivingSegments;

		public NativeParallelHashMap<int, int> lowestIndices;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in SnakeSegmentCD snakeSegment)
		{
			if (snakeSegment.groupIndex != -1 && snakeSegment.index != -1 && (snakeSegment.groupIndex < lowestSegmentEntityGroupIndex.Value || (snakeSegment.groupIndex == lowestSegmentEntityGroupIndex.Value && snakeSegment.index < lowestSegmentEntityIndex.Value)))
			{
				lowestSegmentEntity.Value = entity;
				lowestSegmentEntityGroupIndex.Value = snakeSegment.groupIndex;
				lowestSegmentEntityIndex.Value = snakeSegment.index;
			}
			if (snakeSegment.groupIndex >= 0 && snakeSegment.index >= 0)
			{
				if (!anyRemainingLivingSegments.Contains(snakeSegment.groupIndex))
				{
					anyRemainingLivingSegments.Add(snakeSegment.groupIndex);
				}
				if (!lowestIndices.ContainsKey(snakeSegment.groupIndex))
				{
					lowestIndices.Add(snakeSegment.groupIndex, snakeSegment.index);
				}
				if (snakeSegment.index < lowestIndices[snakeSegment.groupIndex])
				{
					lowestIndices[snakeSegment.groupIndex] = snakeSegment.index;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, k));
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
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	[WithAll(new Type[]
	{
		typeof(SnakeBossCD),
		typeof(LocalTransform),
		typeof(MovementSpeedCD)
	})]
	private struct SnakeBossStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<SnakeMovementStateCD> __SnakeMovementStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BaitableCD> __BaitableCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<IsInCombatCD> __IsInCombatCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeMovementStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementStateCD>();
					__BaitableCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BaitableCD>();
					__IsInCombatCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsInCombatCD>(isReadOnly: true);
					__SnakeSegmentsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>(isReadOnly: true);
					__SnakeSegmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeMovementStateCD_RW_ComponentTypeHandle.Update(ref state);
					__BaitableCD_RW_ComponentTypeHandle.Update(ref state);
					__IsInCombatCD_RO_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RO_BufferTypeHandle.Update(ref state);
					__SnakeSegmentCD_RO_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsInCombatCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BaitableCD>();
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
			public void Run(ref SnakeBossStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SnakeBossStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SnakeBossStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SnakeBossStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SnakeBossStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SnakeBossStateJob job, EntityManager entityManager)
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
		public BiomeLookup biomeLookup;

		[ReadOnly]
		public NativeList<Entity> newBaitsOnAPole;

		[ReadOnly]
		public ComponentLookup<SnakeBossCD> snakeBossLookUp;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> movementSpeedLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> behaviourTagsLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> factionLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> conditionsBufferLookUp;

		[ReadOnly]
		public ComponentLookup<PiercingProjectileCD> piercingProjectileLookup;

		public ComponentLookup<RandomCD> randomLookup;

		public ConditionsTableCD conditionsTable;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public Entity effectEventBufferSingleton;

		public Entity healthChangeBufferEntity;

		public double time;

		public float deltaTime;

		public Unity.Mathematics.Random rand;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref SnakeMovementStateCD snakeMovement, ref BaitableCD baitableCD, in IsInCombatCD inCombat, in DynamicBuffer<SnakeSegmentsBuffer> segments, in SnakeSegmentCD snakeSegment, in DistanceToPlayerCD distanceToPlayer)
		{
			if (snakeSegment.groupIndex == -1 || snakeSegment.index == -1 || distanceToPlayer.closestPlayer == Entity.Null)
			{
				return;
			}
			SnakeBossCD component = snakeBossLookUp[entity];
			bool isAboveWater = snakeBossLookUp[entity].isAboveWater;
			snakeMovement.dontDealDamage = !isAboveWater;
			snakeMovement.tilePlacementType = (isAboveWater ? SnakeMovementTilePlacementType.SeaWater : SnakeMovementTilePlacementType.None);
			if (!snakeMovement.IsHead(entity))
			{
				return;
			}
			bool flag = component.internalState == -1;
			int num = ((!flag) ? component.internalState : 0);
			snakeMovement.externallyRequestedTargetPoint = float3.zero;
			if (component.internalState == 0 || flag)
			{
				baitableCD.baitEntity = Entity.Null;
				if (flag && distanceToPlayer.minDistanceSq < 6400f)
				{
					if (segments.Length < snakeMovement.initialLength)
					{
						num = 2;
					}
					else
					{
						for (int i = 0; i < segments.Length; i++)
						{
							if (healthLookup.TryGetComponent(segments[i].segment, out var componentData) && !componentData.HasFullHealth)
							{
								num = 2;
								break;
							}
						}
					}
				}
				else
				{
					float3 position = localTransformLookup[entity].Position;
					for (int j = 0; j < newBaitsOnAPole.Length; j++)
					{
						if (localTransformLookup.TryGetComponent(newBaitsOnAPole[j], out var componentData2))
						{
							float3 position2 = componentData2.Position;
							if (biomeLookup.GetBiome(position2.RoundToInt2()) == Biome.Sea && math.distancesq(position, position2) < 90000f)
							{
								baitableCD.baitEntity = newBaitsOnAPole[j];
								break;
							}
						}
					}
					if (baitableCD.baitEntity != Entity.Null)
					{
						if (localTransformLookup.TryGetComponent(baitableCD.baitEntity, out var componentData3))
						{
							EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
							{
								effectID = EffectID.SnakeBossEngage,
								position1 = componentData3.Position
							});
						}
						num = 1;
					}
				}
				if (num == 0)
				{
					if (component.targetPlayerEntity == Entity.Null)
					{
						if (!component.goingToPlayerCooldownTimer.isRunning)
						{
							component.goingToPlayerCooldownTimer.Start(time, rand.NextFloat(900f, 3600f));
						}
						else if (component.goingToPlayerCooldownTimer.IsTimerElapsed(time))
						{
							component.goingToPlayerCooldownTimer.Start(time, rand.NextFloat(900f, 3600f));
							component.targetPlayerEntity = distanceToPlayer.closestPlayer;
							component.startPointWhenMovingToPlayer = localTransformLookup[entity].Position;
							component.goingToPlayerCooldownTimer.Stop();
						}
					}
					bool flag2 = false;
					if (component.targetPlayerEntity != Entity.Null && localTransformLookup.TryGetComponent(component.targetPlayerEntity, out var componentData4))
					{
						float3 position3 = localTransformLookup[entity].Position;
						float3 position4 = componentData4.Position;
						Biome biome = biomeLookup.GetBiome(position4.RoundToInt2());
						if (math.distancesq(position3, position4) < 250000f && math.distancesq(component.startPointWhenMovingToPlayer, position4) < 160000f && !entityDestroyedLookup.IsComponentEnabled(component.targetPlayerEntity) && biome == Biome.Sea)
						{
							flag2 = true;
						}
					}
					if (!flag2)
					{
						component.targetPlayerEntity = Entity.Null;
						component.pointsAroundPlayerCount = 0;
					}
					else
					{
						float3 position5 = localTransformLookup[component.targetPlayerEntity].Position;
						float3 position6 = localTransformLookup[entity].Position;
						float num2 = math.distancesq(component.targetPointAroundPlayer, position5);
						bool flag3 = math.distancesq(component.targetPointAroundPlayer, position6) < 3f;
						if (num2 > 400f || flag3)
						{
							component.targetPointAroundPlayer = position5 + new float3(rand.NextFloat(-15f, 15f), 0f, rand.NextFloat(-15f, 15f));
						}
						snakeMovement.externallyRequestedTargetPoint = component.targetPointAroundPlayer;
						if (flag3)
						{
							component.pointsAroundPlayerCount++;
							if (component.pointsAroundPlayerCount > 5)
							{
								component.targetPlayerEntity = Entity.Null;
								snakeMovement.externallyRequestedTargetPoint = float3.zero;
								component.goingToPlayerCooldownTimer.Start(time, rand.NextFloat(2700f, 3600f));
							}
						}
					}
				}
			}
			else if (component.internalState == 1)
			{
				if (baitableCD.baitEntity == Entity.Null || (entityDestroyedLookup.HasComponent(baitableCD.baitEntity) && entityDestroyedLookup.IsComponentEnabled(baitableCD.baitEntity)) || !localTransformLookup.HasComponent(baitableCD.baitEntity))
				{
					num = 0;
				}
				else
				{
					float3 position7 = localTransformLookup[entity].Position;
					if (math.distancesq(localTransformLookup[baitableCD.baitEntity].Position, position7) < 4f)
					{
						ecb.AppendToBuffer(healthChangeBufferEntity, new HealthChangeBuffer
						{
							healthChange = new HealthChange
							{
								entity = baitableCD.baitEntity,
								amount = 100,
								wasKilled = true,
								bypassDamageReduction = true,
								bypassMaxDamagePerHit = true,
								skipLootDropOnDestroy = true
							}
						});
						baitableCD.baitEntity = Entity.Null;
						num = 2;
					}
				}
			}
			else if (component.internalState == 2 && (distanceToPlayer.closestPlayer == Entity.Null || distanceToPlayer.minDistanceSq > 10000f))
			{
				num = 0;
			}
			MovementSpeedCD component2 = movementSpeedLookup[entity];
			if (component.internalState == 0 && component.targetPlayerEntity == Entity.Null)
			{
				component2.speed = 40f;
			}
			else if (component.internalState == 1 && baitableCD.baitEntity != Entity.Null && localTransformLookup.HasComponent(baitableCD.baitEntity))
			{
				float3 position8 = localTransformLookup[entity].Position;
				float num3 = math.distance(localTransformLookup[baitableCD.baitEntity].Position, position8);
				float t = math.min(1f, num3 / 60f);
				component2.speed = math.lerp(60f, 150f, t);
			}
			else if (segments.Length > 0 && segments.Length <= component.amountOfSegmentsRemainingToEnrage)
			{
				component2.speed = 40f;
			}
			else
			{
				component2.speed = 60f;
			}
			ecb.SetComponent(entity, component2);
			bool flag4 = num == 0;
			if (num == 1 && baitableCD.baitEntity != Entity.Null && localTransformLookup.HasComponent(baitableCD.baitEntity))
			{
				flag4 = math.distancesq(localTransformLookup[baitableCD.baitEntity].Position, localTransformLookup[entity].Position) > 64f;
			}
			component.isAboveWater = !flag4;
			snakeMovement.externallyRequestedPhase = ((!flag4) ? SnakeMovementPhaseType.COMBAT : SnakeMovementPhaseType.PATROL);
			if (baitableCD.baitEntity != Entity.Null && localTransformLookup.HasComponent(baitableCD.baitEntity))
			{
				snakeMovement.externallyRequestedTargetPoint = localTransformLookup[baitableCD.baitEntity].Position;
			}
			if (num != component.internalState && (num == 0 || component.internalState == 0))
			{
				component.appearTimer = 0f;
			}
			component.appearTimer += deltaTime;
			component.internalState = num;
			float num4 = ((component.internalState != 0) ? 5f : 15f);
			for (int k = 0; k < segments.Length; k++)
			{
				Entity segment = segments[k].segment;
				if ((float)k <= component.appearTimer * num4 && segment != entity && snakeBossLookUp.HasComponent(segment))
				{
					SnakeBossCD component3 = snakeBossLookUp[segment];
					component3.internalState = num;
					component3.isAboveWater = component.isAboveWater;
					ecb.SetComponent(segment, component3);
				}
				if (component.internalState == 0 && (!entityDestroyedLookup.HasComponent(segment) || !entityDestroyedLookup.IsComponentEnabled(segment)) && healthLookup.TryGetComponent(segment, out var componentData5) && !componentData5.HasFullHealth)
				{
					componentData5.health = componentData5.maxHealth;
					ecb.SetComponent(segment, componentData5);
				}
			}
			if (segments.Length > 0 && segments.Length <= component.amountOfSegmentsRemainingToEnrage)
			{
				component.projectileCooldownTimer -= deltaTime;
				if (component.projectileCooldownTimer <= 0f)
				{
					component.projectileCooldownTimer = rand.NextFloat(6f, 10f);
					behaviourTagsLookup.TryGetComponent(entity, out var componentData6);
					factionLookup.TryGetComponent(entity, out var componentData7);
					RefRW<RandomCD> refRWOptional = randomLookup.GetRefRWOptional(entity);
					for (int l = 0; l < 1; l++)
					{
						Entity segment2 = segments[l].segment;
						float3 position9 = localTransformLookup[segment2].Position;
						for (int m = 0; m < 20; m++)
						{
							float3 facingDirection = snakeMovement.facingDirection;
							facingDirection = math.mul(quaternion.RotateY(math.radians((float)m * 18f)), facingDirection);
							float3 position10 = position9 + snakeMovement.facingDirection * 4f;
							EntityUtility.SpawnProjectile(ecb, position10, databaseBankCD.databaseBankBlob, ObjectID.ElectricProjectile, snakeMovement.damage, 0f, facingDirection, 0f, segment2, componentData6, conditionsBufferLookUp, componentData7, conditionsTable, refRWOptional, piercingProjectileLookup);
						}
					}
				}
			}
			else
			{
				component.projectileCooldownTimer = 8f;
			}
			ecb.SetComponent(entity, component);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeMovementStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BaitableCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__IsInCombatCD_RO_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, k));
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
	private struct UpdateLowestSegmentJob : IJob
	{
		[ReadOnly]
		public NativeParallelHashMap<int, int> lowestIndices;

		public NativeParallelHashMap<int, int> lowestLivingSegments;

		public void Execute()
		{
			NativeArray<int> keyArray = lowestIndices.GetKeyArray(Allocator.Temp);
			foreach (int item in keyArray)
			{
				if (!lowestLivingSegments.ContainsKey(item))
				{
					lowestLivingSegments.Add(item, lowestIndices[item]);
				}
				else
				{
					lowestLivingSegments[item] = lowestIndices[item];
				}
			}
			keyArray.Dispose();
		}
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(SnakeBossCD) })]
	private struct MarkHeadDropLootJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
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
			public void Run(ref MarkHeadDropLootJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MarkHeadDropLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MarkHeadDropLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MarkHeadDropLootJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MarkHeadDropLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MarkHeadDropLootJob job, EntityManager entityManager)
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

		public NativeParallelHashSet<int> existingSegmentGroups;

		[ReadOnly]
		public NativeParallelHashSet<int> anyRemainingLivingSegments;

		[ReadOnly]
		public NativeParallelHashMap<int, int> lowestLivingSegmentsLocal;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> dontDropLootLookup;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in SnakeSegmentCD snakeSegment)
		{
			if (snakeSegment.groupIndex > -1 && !existingSegmentGroups.Contains(snakeSegment.groupIndex))
			{
				existingSegmentGroups.Add(snakeSegment.groupIndex);
			}
			if (!dontDropLootLookup.HasComponent(entity))
			{
				UnityEngine.Debug.LogError($"Missing dontDropOnLoot on entity with id: {entity}, check if this is intended or remove this message");
			}
			else if (!anyRemainingLivingSegments.Contains(snakeSegment.groupIndex) && lowestLivingSegmentsLocal.ContainsKey(snakeSegment.groupIndex) && snakeSegment.index == lowestLivingSegmentsLocal[snakeSegment.groupIndex])
			{
				if (dontDropLootLookup.IsComponentEnabled(entity))
				{
					ecb.SetComponentEnabled<DontDropLootCD>(entity, value: false);
				}
			}
			else if (!dontDropLootLookup.IsComponentEnabled(entity))
			{
				ecb.SetComponentEnabled<DontDropLootCD>(entity, value: true);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, k));
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
	[WithAll(new Type[]
	{
		typeof(SnakeBossCD),
		typeof(InitializedSnakeSegmentCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct KillOffSmallSegmentsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeMovementStateCD> __SnakeMovementStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>();
					__SnakeSegmentsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>();
					__SnakeMovementStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SnakeMovementStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentsBuffer>();
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
			public void Run(ref KillOffSmallSegmentsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref KillOffSmallSegmentsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref KillOffSmallSegmentsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref KillOffSmallSegmentsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref KillOffSmallSegmentsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref KillOffSmallSegmentsJob job, EntityManager entityManager)
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

		public ComponentLookup<HealthCD> healthLookup;

		public Entity healthChangeBufferEntity;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref SnakeSegmentCD snakeSegment, ref DynamicBuffer<SnakeSegmentsBuffer> segments, in SnakeMovementStateCD snakeMovement)
		{
			if (snakeSegment.groupIndex == -1 || snakeSegment.index == -1 || !snakeMovement.IsHead(entity))
			{
				return;
			}
			int num = 0;
			NativeList<int> nativeList = new NativeList<int>(Allocator.Temp);
			for (int i = 0; i < segments.Length; i++)
			{
				if (!healthLookup.TryGetComponent(segments[i].segment, out var componentData))
				{
					continue;
				}
				bool flag = i == segments.Length - 1;
				if (componentData.health > 0 && flag)
				{
					num++;
				}
				if (componentData.health <= 0 || flag)
				{
					if (num < 3)
					{
						for (int j = math.max(0, i - num); j <= i; j++)
						{
							nativeList.Add(in j);
						}
					}
					num = 0;
				}
				if (componentData.health > 0 && !flag)
				{
					num++;
				}
			}
			for (int k = 0; k < nativeList.Length; k++)
			{
				int index = nativeList[k];
				if (healthLookup.TryGetComponent(segments[index].segment, out var componentData2) && componentData2.health > 0)
				{
					ecb.AppendToBuffer(healthChangeBufferEntity, new HealthChangeBuffer
					{
						healthChange = new HealthChange
						{
							entity = segments[index].segment,
							amount = -componentData2.health,
							wasKilled = true
						}
					});
				}
			}
			nativeList.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RW_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeMovementStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref SnakeSegmentCD snakeSegment = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, i);
					DynamicBuffer<SnakeSegmentsBuffer> segments = bufferAccessor[i];
					Execute(entity, ref snakeSegment, ref segments, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, i));
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
						ref SnakeSegmentCD snakeSegment2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<SnakeSegmentsBuffer> segments2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref snakeSegment2, ref segments2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, nextRangeBegin));
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
					ref SnakeSegmentCD snakeSegment3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, j);
					DynamicBuffer<SnakeSegmentsBuffer> segments3 = bufferAccessor[j];
					Execute(entity3, ref snakeSegment3, ref segments3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, j));
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
					ref SnakeSegmentCD snakeSegment4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, k);
					DynamicBuffer<SnakeSegmentsBuffer> segments4 = bufferAccessor[k];
					Execute(entity4, ref snakeSegment4, ref segments4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, k));
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
	[WithAll(new Type[]
	{
		typeof(SnakeBossCD),
		typeof(InitializedSnakeSegmentCD)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct SetSegmentsInvulnerableJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeMovementStateCD> __SnakeMovementStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>();
					__SnakeSegmentsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>();
					__SnakeMovementStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SnakeMovementStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentsBuffer>();
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
			public void Run(ref SetSegmentsInvulnerableJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetSegmentsInvulnerableJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetSegmentsInvulnerableJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetSegmentsInvulnerableJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetSegmentsInvulnerableJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetSegmentsInvulnerableJob job, EntityManager entityManager)
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

		public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

		public EntityCommandBuffer ecb;

		public Unity.Mathematics.Random rand;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref SnakeSegmentCD snakeSegment, ref DynamicBuffer<SnakeSegmentsBuffer> segments, in SnakeMovementStateCD snakeMovement)
		{
			if (snakeSegment.groupIndex == -1 || snakeSegment.index == -1 || !snakeMovement.IsHead(entity) || segments.Length < 3)
			{
				return;
			}
			for (int i = 1; i < segments.Length - 1; i++)
			{
				if (SegmentIsVulnerable(segments[i].segment, immuneToDamageLookup))
				{
					return;
				}
			}
			SetImmuneToDamageValue(ecb, immuneToDamageLookup, segments[0], ImmuneToDamageState.Immune);
			SetImmuneToDamageValue(ecb, immuneToDamageLookup, segments[segments.Length - 1], ImmuneToDamageState.Immune);
			int num = math.max(1, (int)((float)(segments.Length - 2) * 0.15f));
			NativeList<int> nativeList = new NativeList<int>(Allocator.Temp);
			for (int j = 1; j < segments.Length - 1; j++)
			{
				nativeList.Add(in j);
			}
			for (int k = 0; k < num; k++)
			{
				int index = rand.NextInt(0, nativeList.Length);
				int index2 = nativeList[index];
				SetImmuneToDamageValue(ecb, immuneToDamageLookup, segments[index2], ImmuneToDamageState.Vulnerable);
				nativeList.RemoveAt(index);
			}
			for (int l = 0; l < nativeList.Length; l++)
			{
				int index3 = nativeList[l];
				SetImmuneToDamageValue(ecb, immuneToDamageLookup, segments[index3], ImmuneToDamageState.Immune);
			}
			nativeList.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RW_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeMovementStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref SnakeSegmentCD snakeSegment = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, i);
					DynamicBuffer<SnakeSegmentsBuffer> segments = bufferAccessor[i];
					Execute(entity, ref snakeSegment, ref segments, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, i));
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
						ref SnakeSegmentCD snakeSegment2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<SnakeSegmentsBuffer> segments2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref snakeSegment2, ref segments2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, nextRangeBegin));
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
					ref SnakeSegmentCD snakeSegment3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, j);
					DynamicBuffer<SnakeSegmentsBuffer> segments3 = bufferAccessor[j];
					Execute(entity3, ref snakeSegment3, ref segments3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, j));
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
					ref SnakeSegmentCD snakeSegment4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, k);
					DynamicBuffer<SnakeSegmentsBuffer> segments4 = bufferAccessor[k];
					Execute(entity4, ref snakeSegment4, ref segments4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, k));
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
	[WithAll(new Type[] { typeof(SnakeBossCD) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct DisableCollidersNearVulnerableJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeMovementStateCD> __SnakeMovementStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>();
					__SnakeSegmentsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>();
					__SnakeMovementStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SnakeMovementStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentsBuffer>();
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
			public void Run(ref DisableCollidersNearVulnerableJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DisableCollidersNearVulnerableJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DisableCollidersNearVulnerableJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DisableCollidersNearVulnerableJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DisableCollidersNearVulnerableJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DisableCollidersNearVulnerableJob job, EntityManager entityManager)
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
		public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref SnakeSegmentCD snakeSegment, ref DynamicBuffer<SnakeSegmentsBuffer> segments, in SnakeMovementStateCD snakeMovement)
		{
			if (snakeSegment.groupIndex == -1 || snakeSegment.index == -1 || !snakeMovement.IsHead(entity))
			{
				return;
			}
			for (int i = 0; i < segments.Length; i++)
			{
				bool flag = i == 0 || i == segments.Length - 1 || (!SegmentIsVulnerable(segments[i].segment, immuneToDamageLookup) && (SegmentIsVulnerable(segments[i - 1].segment, immuneToDamageLookup) || SegmentIsVulnerable(segments[i + 1].segment, immuneToDamageLookup)));
				if (disablePhysicsLookup.HasComponent(segments[i].segment))
				{
					bool flag2 = disablePhysicsLookup.IsComponentEnabled(segments[i].segment);
					if (flag != flag2)
					{
						disablePhysicsLookup.SetComponentEnabled(segments[i].segment, flag);
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RW_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeMovementStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref SnakeSegmentCD snakeSegment = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, i);
					DynamicBuffer<SnakeSegmentsBuffer> segments = bufferAccessor[i];
					Execute(entity, ref snakeSegment, ref segments, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, i));
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
						ref SnakeSegmentCD snakeSegment2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<SnakeSegmentsBuffer> segments2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref snakeSegment2, ref segments2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, nextRangeBegin));
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
					ref SnakeSegmentCD snakeSegment3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, j);
					DynamicBuffer<SnakeSegmentsBuffer> segments3 = bufferAccessor[j];
					Execute(entity3, ref snakeSegment3, ref segments3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, j));
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
					ref SnakeSegmentCD snakeSegment4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, k);
					DynamicBuffer<SnakeSegmentsBuffer> segments4 = bufferAccessor[k];
					Execute(entity4, ref snakeSegment4, ref segments4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr3, k));
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
	[WithAll(new Type[] { typeof(SnakeBossCD) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct MarkToResetSnakeBossJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SnakeMovementStateCD> __SnakeMovementStateCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__SnakeSegmentCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>();
					__SnakeSegmentsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>();
					__SnakeMovementStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementStateCD>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__SnakeSegmentCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RW_BufferTypeHandle.Update(ref state);
					__SnakeMovementStateCD_RO_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentsBuffer>();
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
			public void Run(ref MarkToResetSnakeBossJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MarkToResetSnakeBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MarkToResetSnakeBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MarkToResetSnakeBossJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MarkToResetSnakeBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MarkToResetSnakeBossJob job, EntityManager entityManager)
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
		public NativeParallelHashMap<int, int> lowestLivingSegmentsLocal;

		public NativeParallelHashSet<int> snakeGroupsToReset;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref SnakeSegmentCD snakeSegment, ref DynamicBuffer<SnakeSegmentsBuffer> segments, in SnakeMovementStateCD snakeMovement, in DistanceToPlayerCD distanceToPlayerCD)
		{
			if (snakeSegment.groupIndex != -1 && snakeSegment.index != -1 && snakeMovement.initialLength != segments.Length && lowestLivingSegmentsLocal.ContainsKey(snakeSegment.groupIndex) && snakeSegment.index == lowestLivingSegmentsLocal[snakeSegment.groupIndex] && distanceToPlayerCD.closestPlayer != Entity.Null && distanceToPlayerCD.minDistanceSq > 10000f)
			{
				snakeGroupsToReset.Add(snakeSegment.groupIndex);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RW_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SnakeMovementStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					ref SnakeSegmentCD snakeSegment = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr, i);
					DynamicBuffer<SnakeSegmentsBuffer> segments = bufferAccessor[i];
					Execute(ref snakeSegment, ref segments, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, i));
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
						ref SnakeSegmentCD snakeSegment2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr, nextRangeBegin);
						DynamicBuffer<SnakeSegmentsBuffer> segments2 = bufferAccessor[nextRangeBegin];
						Execute(ref snakeSegment2, ref segments2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, nextRangeBegin));
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
					ref SnakeSegmentCD snakeSegment3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr, j);
					DynamicBuffer<SnakeSegmentsBuffer> segments3 = bufferAccessor[j];
					Execute(ref snakeSegment3, ref segments3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					ref SnakeSegmentCD snakeSegment4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr, k);
					DynamicBuffer<SnakeSegmentsBuffer> segments4 = bufferAccessor[k];
					Execute(ref snakeSegment4, ref segments4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementStateCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, k));
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
	[WithAll(new Type[] { typeof(SnakeBossCD) })]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct ResetSnakeBossJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<SnakeSegmentCD> __SnakeSegmentCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeSegmentCD>();
					__SnakeSegmentsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RW_BufferTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeSegmentsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
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
			public void Run(ref ResetSnakeBossJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ResetSnakeBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ResetSnakeBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ResetSnakeBossJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ResetSnakeBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ResetSnakeBossJob job, EntityManager entityManager)
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
		public NativeParallelHashSet<int> snakeGroupsToReset;

		[ReadOnly]
		public NativeParallelHashMap<int, int> lowestLivingSegmentsLocal;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref SnakeSegmentCD snakeSegment, ref DynamicBuffer<SnakeSegmentsBuffer> segments, ref HealthCD health)
		{
			if (snakeGroupsToReset.Contains(snakeSegment.groupIndex))
			{
				if (lowestLivingSegmentsLocal.ContainsKey(snakeSegment.groupIndex) && snakeSegment.index == lowestLivingSegmentsLocal[snakeSegment.groupIndex])
				{
					snakeSegment.groupIndex = -1;
					snakeSegment.index = -1;
					segments.Clear();
					health.health = health.maxHealth;
					ecb.RemoveComponent<InitializedSnakeSegmentCD>(entity);
				}
				else
				{
					ecb.DestroyEntity(entity);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeSegmentCD_RW_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref SnakeSegmentCD snakeSegment = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, i);
					DynamicBuffer<SnakeSegmentsBuffer> segments = bufferAccessor[i];
					Execute(entity, ref snakeSegment, ref segments, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i));
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
						ref SnakeSegmentCD snakeSegment2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<SnakeSegmentsBuffer> segments2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref snakeSegment2, ref segments2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, nextRangeBegin));
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
					ref SnakeSegmentCD snakeSegment3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, j);
					DynamicBuffer<SnakeSegmentsBuffer> segments3 = bufferAccessor[j];
					Execute(entity3, ref snakeSegment3, ref segments3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j));
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
					ref SnakeSegmentCD snakeSegment4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeSegmentCD>(nativeArrayPtr2, k);
					DynamicBuffer<SnakeSegmentsBuffer> segments4 = bufferAccessor[k];
					Execute(entity4, ref snakeSegment4, ref segments4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k));
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
	[WithNone(new Type[] { typeof(DontDropLootCD) })]
	private struct PlayEffectJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<SnakeBossCD> __SnakeBossCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__SnakeBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeBossCD>();
					__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__SnakeBossCD_RW_ComponentTypeHandle.Update(ref state);
					__EntityDestroyedCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeBossCD>();
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
			public void Run(ref PlayEffectJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref PlayEffectJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref PlayEffectJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref PlayEffectJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref PlayEffectJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref PlayEffectJob job, EntityManager entityManager)
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

		public uint tickRate;

		public NetworkTick currentTick;

		public Entity effectEventBufferSingleton;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref SnakeBossCD snakeBoss, in EntityDestroyedCD destroyed, in LocalTransform transform)
		{
			if (!snakeBoss.hasPlayedDefeatSoundEffect && destroyed.destroyTimer.GetElapsedSeconds(currentTick, tickRate) > snakeBoss.defeatSoundEffectDelay)
			{
				EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
				{
					effectID = EffectID.BossDefeated,
					position1 = transform.Position
				});
				snakeBoss.hasPlayedDefeatSoundEffect = true;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeBossCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeBossCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeBossCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeBossCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
	public struct RemoveSegmentForDeadGroupsJob : IJob
	{
		public NativeParallelHashMap<int, int> lowestLivingSegments;

		[ReadOnly]
		public NativeParallelHashSet<int> existingSegmentGroups;

		public void Execute()
		{
			NativeArray<int> keyArray = lowestLivingSegments.GetKeyArray(Allocator.Temp);
			foreach (int item in keyArray)
			{
				if (!existingSegmentGroups.Contains(item))
				{
					lowestLivingSegments.Remove(item);
				}
			}
			keyArray.Dispose();
		}
	}

	[BurstCompile]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct FindMapMarkerJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MapMarkerCD> __MapMarkerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__MapMarkerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MapMarkerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__MapMarkerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MapMarkerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
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
			public void Run(ref FindMapMarkerJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FindMapMarkerJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FindMapMarkerJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FindMapMarkerJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FindMapMarkerJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FindMapMarkerJob job, EntityManager entityManager)
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

		public NativeReference<Entity> mapMarkerEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, in MapMarkerCD mapMarker)
		{
			if (mapMarker.mapMarkerType == MapMarkerType.UniqueBoss && mapMarker.uniqueMarkerId == ObjectID.SnakeBossSegment)
			{
				mapMarkerEntity.Value = entity;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MapMarkerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MapMarkerCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MapMarkerCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MapMarkerCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MapMarkerCD>(nativeArrayPtr2, k));
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
	private struct UpdateMapMarkerJob : IJob
	{
		public NativeReference<Entity> mapMarkerEntity;

		public NativeReference<float> destroyMapMarkerDelayTimer;

		public NativeReference<Entity> lowestSegmentEntity;

		public ComponentLookup<LocalTransform> localTransformLookup;

		public float deltaTime;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public void Execute()
		{
			if (mapMarkerEntity.Value == Entity.Null && lowestSegmentEntity.Value != Entity.Null)
			{
				EntityUtility.CreateEntity(ecb, localTransformLookup[lowestSegmentEntity.Value].Position, ObjectID.MapMarker, 1, databaseBankCD.databaseBankBlob, 14);
			}
			else if (mapMarkerEntity.Value != Entity.Null && lowestSegmentEntity.Value == Entity.Null)
			{
				if (destroyMapMarkerDelayTimer.Value > 3f)
				{
					ecb.DestroyEntity(mapMarkerEntity.Value);
					mapMarkerEntity.Value = Entity.Null;
				}
				destroyMapMarkerDelayTimer.Value += deltaTime;
			}
			if (mapMarkerEntity.Value != Entity.Null && lowestSegmentEntity.Value != Entity.Null && localTransformLookup.TryGetComponent(lowestSegmentEntity.Value, out var componentData))
			{
				localTransformLookup[mapMarkerEntity.Value] = componentData;
				destroyMapMarkerDelayTimer.Value = 0f;
			}
		}
	}

	private struct TypeHandle
	{
		public FindAvailableSnakeGroupIndexJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<SnakeBossCD> __SnakeBossCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PiercingProjectileCD> __PiercingProjectileCD_RO_ComponentLookup;

		public ComponentLookup<RandomCD> __RandomCD_RW_ComponentLookup;

		public SnakeBossStateJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RO_ComponentLookup;

		public MarkHeadDropLootJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		public KillOffSmallSegmentsJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<ImmuneToDamageCD> __ImmuneToDamageCD_RW_ComponentLookup;

		public SetSegmentsInvulnerableJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ImmuneToDamageCD> __ImmuneToDamageCD_RO_ComponentLookup;

		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

		public DisableCollidersNearVulnerableJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle;

		public MarkToResetSnakeBossJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle;

		public ResetSnakeBossJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle;

		public PlayEffectJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle;

		public FindMapMarkerJob.InternalCompilerQueryAndHandleData __SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeBossCD_RO_ComponentLookup = state.GetComponentLookup<SnakeBossCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__MovementSpeedCD_RO_ComponentLookup = state.GetComponentLookup<MovementSpeedCD>(isReadOnly: true);
			__BehaviourTagsCD_RO_ComponentLookup = state.GetComponentLookup<BehaviourTagsCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__PiercingProjectileCD_RO_ComponentLookup = state.GetComponentLookup<PiercingProjectileCD>(isReadOnly: true);
			__RandomCD_RW_ComponentLookup = state.GetComponentLookup<RandomCD>();
			__SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DontDropLootCD_RO_ComponentLookup = state.GetComponentLookup<DontDropLootCD>(isReadOnly: true);
			__SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ImmuneToDamageCD_RW_ComponentLookup = state.GetComponentLookup<ImmuneToDamageCD>();
			__SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ImmuneToDamageCD_RO_ComponentLookup = state.GetComponentLookup<ImmuneToDamageCD>(isReadOnly: true);
			__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
			__SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000B77_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000B77_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000B77_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000B78_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000B78_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000B78_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_00000B79_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00000B79_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00000B79_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
			__codegen__OnDestroy_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStartRunning_00000B7A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000B7A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000B7A_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
			__codegen__OnStartRunning_0024BurstManaged(self, state);
		}
	}

	private const int DISTANCE_SQ_TO_PLAYER_TO_RESET_AND_LEAVE_COMBAT = 10000;

	private const int DISTANCE_TO_PLAYER_TO_ENTER_COMBAT = 80;

	private const int DISTANCE_SQ_TO_PLAYER_TO_ENTER_COMBAT = 6400;

	private const int DISTANCE_SQ_TO_MOVE_TO_BAIT = 90000;

	private const int DISTANCE_TO_BAIT_TO_BE_ABOVE_WATER = 8;

	private const int DISTANCE_SQ_TO_BAIT_TO_BE_ABOVE_WATER = 64;

	private const int DISTANCE_SQ_TO_BAIT_TO_EAT_IT = 4;

	private const float MIN_TIME_TO_GO_TO_PLAYER_WHEN_UNDER_WATER_SHORT = 900f;

	private const float MAX_TIME_TO_GO_TO_PLAYER_WHEN_UNDER_WATER_SHORT = 3600f;

	private const float MIN_TIME_TO_GO_TO_PLAYER_WHEN_UNDER_WATER = 2700f;

	private const float MAX_TIME_TO_GO_TO_PLAYER_WHEN_UNDER_WATER = 3600f;

	private const int DISTANCE_SQ_TO_MOVE_TO_PLAYER_WHEN_UNDER_WATER = 250000;

	private const int DISTANCE_FROM_STARTING_POINT_SQ_TO_MOVE_TO_PLAYER_WHEN_UNDER_WATER = 160000;

	private const int DISTANCE_SQ_BETWEEN_PLAYER_AND_TARGET_POINT = 400;

	private NativeParallelHashMap<int, int> lowestLivingSegments;

	private EntityQuery mapMarkerQuery;

	private NativeReference<Entity> mapMarkerEntity;

	private NativeReference<float> destroyMapMarkerDelayTimer;

	private EntityQuery baitOnAPoleQuery;

	private BiomeLookup _biomeLookup;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1095632806_0;

	private EntityQuery __query_1095632806_1;

	private EntityQuery __query_1095632806_2;

	private EntityQuery __query_1095632806_3;

	private EntityQuery __query_1095632806_4;

	private EntityQuery __query_1095632806_5;

	private EntityQuery __query_1095632806_6;

	private EntityQuery __query_1095632806_7;

	private EntityQuery __query_1095632806_8;

	private EntityQuery __query_1095632806_9;

	private EntityQuery __query_1095632806_10;

	private EntityQuery __query_1095632806_11;

	private static void SetImmuneToDamageValue(EntityCommandBuffer ecb, ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup, SnakeSegmentsBuffer segment, ImmuneToDamageState value)
	{
		ImmuneToDamageCD component = immuneToDamageLookup[segment.segment];
		component.Value = value;
		ecb.SetComponent(segment.segment, component);
	}

	private static bool SegmentIsVulnerable(Entity segment, ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup)
	{
		if (immuneToDamageLookup.TryGetComponent(segment, out var componentData))
		{
			return componentData.Value == ImmuneToDamageState.Vulnerable;
		}
		return true;
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<BiomeRangesCD>();
		state.RequireForUpdate(__query_1095632806_0);
		mapMarkerQuery = __query_1095632806_1;
		baitOnAPoleQuery = __query_1095632806_2;
		lowestLivingSegments = new NativeParallelHashMap<int, int>(1, Allocator.Persistent);
		mapMarkerEntity = new NativeReference<Entity>(Allocator.Persistent);
		destroyMapMarkerDelayTimer = new NativeReference<float>(Allocator.Persistent);
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		if (lowestLivingSegments.IsCreated)
		{
			lowestLivingSegments.Dispose();
		}
		if (mapMarkerEntity.IsCreated)
		{
			mapMarkerEntity.Dispose();
		}
		if (destroyMapMarkerDelayTimer.IsCreated)
		{
			destroyMapMarkerDelayTimer.Dispose();
		}
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_biomeLookup = (__query_1095632806_3.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_1095632806_4.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
	}

	public void OnStopRunning(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1095632806_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		Entity singletonEntity = __query_1095632806_6.GetSingletonEntity();
		Entity singletonEntity2 = __query_1095632806_7.GetSingletonEntity();
		__query_1095632806_8.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		uint simulationTickRate = (uint)__query_1095632806_9.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		NativeParallelHashSet<int> existingSegmentGroups = new NativeParallelHashSet<int>(1, state.WorldUpdateAllocator);
		NativeParallelHashSet<int> anyRemainingLivingSegments = new NativeParallelHashSet<int>(1, state.WorldUpdateAllocator);
		NativeParallelHashMap<int, int> lowestIndices = new NativeParallelHashMap<int, int>(1, state.WorldUpdateAllocator);
		NativeReference<Entity> lowestSegmentEntity = new NativeReference<Entity>(state.WorldUpdateAllocator);
		NativeReference<int> lowestSegmentEntityGroupIndex = new NativeReference<int>(state.WorldUpdateAllocator);
		NativeReference<int> lowestSegmentEntityIndex = new NativeReference<int>(state.WorldUpdateAllocator);
		lowestSegmentEntityGroupIndex.Value = int.MaxValue;
		lowestSegmentEntityIndex.Value = int.MaxValue;
		ecb.AddComponent<BaitCheckedCD>(baitOnAPoleQuery, EntityQueryCaptureMode.AtRecord);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new FindAvailableSnakeGroupIndexJob
		{
			lowestSegmentEntity = lowestSegmentEntity,
			lowestSegmentEntityGroupIndex = lowestSegmentEntityGroupIndex,
			lowestSegmentEntityIndex = lowestSegmentEntityIndex,
			anyRemainingLivingSegments = anyRemainingLivingSegments,
			lowestIndices = lowestIndices
		}, __TypeHandle.__SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		JobHandle outJobHandle;
		NativeList<Entity> newBaitsOnAPole = baitOnAPoleQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new SnakeBossStateJob
		{
			biomeLookup = _biomeLookup,
			newBaitsOnAPole = newBaitsOnAPole,
			snakeBossLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeBossCD_RO_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			movementSpeedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MovementSpeedCD_RO_ComponentLookup, ref state),
			behaviourTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BehaviourTagsCD_RO_ComponentLookup, ref state),
			factionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FactionCD_RO_ComponentLookup, ref state),
			conditionsBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			piercingProjectileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PiercingProjectileCD_RO_ComponentLookup, ref state),
			randomLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomCD_RW_ComponentLookup, ref state),
			conditionsTable = __query_1095632806_10.GetSingleton<ConditionsTableCD>(),
			databaseBankCD = __query_1095632806_11.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			effectEventBufferSingleton = singletonEntity2,
			healthChangeBufferEntity = singletonEntity,
			time = elapsedTime,
			deltaTime = deltaTime,
			rand = PugRandom.GetRng()
		}, __TypeHandle.__SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, outJobHandle, ref state, hasUserDefinedQuery: false);
		state.Dependency = IJobExtensions.Schedule(new UpdateLowestSegmentJob
		{
			lowestIndices = lowestIndices,
			lowestLivingSegments = lowestLivingSegments
		}, state.Dependency);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new MarkHeadDropLootJob
		{
			existingSegmentGroups = existingSegmentGroups,
			anyRemainingLivingSegments = anyRemainingLivingSegments,
			lowestLivingSegmentsLocal = lowestLivingSegments,
			dontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RO_ComponentLookup, ref state),
			ecb = ecb
		}, __TypeHandle.__SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new KillOffSmallSegmentsJob
		{
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
			healthChangeBufferEntity = singletonEntity,
			ecb = ecb
		}, __TypeHandle.__SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new SetSegmentsInvulnerableJob
		{
			immuneToDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToDamageCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			rand = PugRandom.GetRng()
		}, __TypeHandle.__SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_5(new DisableCollidersNearVulnerableJob
		{
			immuneToDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToDamageCD_RO_ComponentLookup, ref state),
			disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state)
		}, __TypeHandle.__SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		NativeParallelHashSet<int> snakeGroupsToReset = new NativeParallelHashSet<int>(0, state.WorldUpdateAllocator);
		state.Dependency = __ScheduleViaJobChunkExtension_6(new MarkToResetSnakeBossJob
		{
			lowestLivingSegmentsLocal = lowestLivingSegments,
			snakeGroupsToReset = snakeGroupsToReset
		}, __TypeHandle.__SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_7(new ResetSnakeBossJob
		{
			snakeGroupsToReset = snakeGroupsToReset,
			lowestLivingSegmentsLocal = lowestLivingSegments,
			ecb = ecb
		}, __TypeHandle.__SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_8(new PlayEffectJob
		{
			tickRate = simulationTickRate,
			currentTick = serverTick,
			effectEventBufferSingleton = singletonEntity2,
			ecb = ecb
		}, __TypeHandle.__SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = IJobExtensions.Schedule(new RemoveSegmentForDeadGroupsJob
		{
			lowestLivingSegments = lowestLivingSegments,
			existingSegmentGroups = existingSegmentGroups
		}, state.Dependency);
		if (mapMarkerEntity.Value == Entity.Null)
		{
			FindMapMarkerJob job = new FindMapMarkerJob
			{
				mapMarkerEntity = mapMarkerEntity
			};
			state.Dependency = __ScheduleViaJobChunkExtension_9(job, __TypeHandle.__SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
		state.Dependency = IJobExtensions.Schedule(new UpdateMapMarkerJob
		{
			mapMarkerEntity = mapMarkerEntity,
			destroyMapMarkerDelayTimer = destroyMapMarkerDelayTimer,
			lowestSegmentEntity = lowestSegmentEntity,
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
			deltaTime = deltaTime,
			ecb = ecb,
			databaseBankCD = __query_1095632806_11.GetSingleton<PugDatabase.DatabaseBankCD>()
		}, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(FindAvailableSnakeGroupIndexJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(SnakeBossStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_SnakeBossStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(MarkHeadDropLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_MarkHeadDropLootJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(KillOffSmallSegmentsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_KillOffSmallSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(SetSegmentsInvulnerableJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_SetSegmentsInvulnerableJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_5(DisableCollidersNearVulnerableJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_DisableCollidersNearVulnerableJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_6(MarkToResetSnakeBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_MarkToResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_7(ResetSnakeBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_ResetSnakeBossJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_8(PlayEffectJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_PlayEffectJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_9(FindMapMarkerJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeBossSystem_FindMapMarkerJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_1095632806_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<MapMarkerCD>();
		__query_1095632806_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BaitOnAPoleCD, OwnerReferenceCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<BaitCheckedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1095632806_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1095632806_11 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000B77_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000B78_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00000B79_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000B7A_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((SnakeBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SnakeBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeBossSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
