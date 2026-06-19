using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct TrackedCombatantsSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct RegisterNewCombatatsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<NewCombatantsBuffer> __NewCombatantsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__NewCombatantsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<NewCombatantsBuffer>();
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle = state.GetBufferTypeHandle<NearbyEntitiesBufferCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__NewCombatantsBuffer_RW_BufferTypeHandle.Update(ref state);
					__NearbyEntitiesBufferCD_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NearbyEntitiesBufferCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NewCombatantsBuffer>();
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
			public void Run(ref RegisterNewCombatatsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RegisterNewCombatatsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RegisterNewCombatatsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RegisterNewCombatatsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RegisterNewCombatatsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RegisterNewCombatatsJob job, EntityManager entityManager)
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
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> isInCombatLookup;

		[ReadOnly]
		public ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		public bool pvpEnabled;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<NewCombatantsBuffer> newCombatantTargets, in DynamicBuffer<NearbyEntitiesBufferCD> nearbyEntities)
		{
			for (int i = 0; i < nearbyEntities.Length; i++)
			{
				Entity entity2 = nearbyEntities[i].entity;
				Entity entity3 = entity2;
				if (entityPartLookup.HasComponent(entity2))
				{
					entity3 = entityPartLookup[entity2].mainEntity;
				}
				if (!(entity2 == entity))
				{
					IsInCombatCD componentData;
					bool num = bossLookup.HasComponent(entity3) && isInCombatLookup.TryGetComponent(entity3, out componentData) && componentData.isInCombat;
					bool flag = snakeMovementStateLookup.HasComponent(entity3);
					bool flag2 = pvpEnabled && playerGhostLookup.HasComponent(entity3);
					if ((num || flag || flag2) && !entityDestroyedLookup.IsComponentEnabled(entity3))
					{
						newCombatantTargets.Add(new NewCombatantsBuffer
						{
							Target = entity2
						});
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<NewCombatantsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NewCombatantsBuffer_RW_BufferTypeHandle);
			BufferAccessor<NearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<NewCombatantsBuffer> newCombatantTargets = bufferAccessor[i];
					Execute(entity, ref newCombatantTargets, bufferAccessor2[i]);
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
						DynamicBuffer<NewCombatantsBuffer> newCombatantTargets2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref newCombatantTargets2, bufferAccessor2[nextRangeBegin]);
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
					DynamicBuffer<NewCombatantsBuffer> newCombatantTargets3 = bufferAccessor[j];
					Execute(entity3, ref newCombatantTargets3, bufferAccessor2[j]);
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
					DynamicBuffer<NewCombatantsBuffer> newCombatantTargets4 = bufferAccessor[k];
					Execute(entity4, ref newCombatantTargets4, bufferAccessor2[k]);
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
	private struct ResolveCombatatsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public BufferTypeHandle<NewCombatantsBuffer> __NewCombatantsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<CombatantsTrackerBuffer> __CombatantsTrackerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__NewCombatantsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<NewCombatantsBuffer>();
					__CombatantsTrackerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CombatantsTrackerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__NewCombatantsBuffer_RW_BufferTypeHandle.Update(ref state);
					__CombatantsTrackerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<NewCombatantsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CombatantsTrackerBuffer>();
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
			public void Run(ref ResolveCombatatsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ResolveCombatatsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ResolveCombatatsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ResolveCombatatsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ResolveCombatatsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ResolveCombatatsJob job, EntityManager entityManager)
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
		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> cattleLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToDamageCD> immuneToDamageLookup;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(ref DynamicBuffer<NewCombatantsBuffer> newCombatantTargets, ref DynamicBuffer<CombatantsTrackerBuffer> combatantTargets)
		{
			for (int i = 0; i < newCombatantTargets.Length; i++)
			{
				Entity target = newCombatantTargets[i].Target;
				if (!TrackedCombatantsHelpers.IsValidTarget(target, disablePhysicsLookup, healthLookup, entityPartLookup, immuneToDamageLookup))
				{
					continue;
				}
				bool flag = false;
				for (int j = 0; j < combatantTargets.Length; j++)
				{
					if (combatantTargets[j].Target == target)
					{
						CombatantsTrackerBuffer value = combatantTargets[j];
						value.RemovalTimer = 0f;
						combatantTargets[j] = value;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Entity entity = target;
					if (entityPartLookup.TryGetComponent(target, out var componentData))
					{
						entity = componentData.mainEntity;
					}
					if ((enemyLookup.HasComponent(entity) && !cattleLookup.HasComponent(entity)) || playerGhostLookup.HasComponent(entity))
					{
						combatantTargets.Add(new CombatantsTrackerBuffer
						{
							Target = target
						});
					}
				}
			}
			newCombatantTargets.Clear();
			for (int num = combatantTargets.Length - 1; num >= 0; num--)
			{
				CombatantsTrackerBuffer value2 = combatantTargets[num];
				value2.RemovalTimer += deltaTime;
				combatantTargets[num] = value2;
				if (value2.RemovalTimer > 15f)
				{
					combatantTargets.RemoveAtSwapBack(num);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			BufferAccessor<NewCombatantsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__NewCombatantsBuffer_RW_BufferTypeHandle);
			BufferAccessor<CombatantsTrackerBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__CombatantsTrackerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					DynamicBuffer<NewCombatantsBuffer> newCombatantTargets = bufferAccessor[i];
					DynamicBuffer<CombatantsTrackerBuffer> combatantTargets = bufferAccessor2[i];
					Execute(ref newCombatantTargets, ref combatantTargets);
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
						DynamicBuffer<NewCombatantsBuffer> newCombatantTargets2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<CombatantsTrackerBuffer> combatantTargets2 = bufferAccessor2[nextRangeBegin];
						Execute(ref newCombatantTargets2, ref combatantTargets2);
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
					DynamicBuffer<NewCombatantsBuffer> newCombatantTargets3 = bufferAccessor[j];
					DynamicBuffer<CombatantsTrackerBuffer> combatantTargets3 = bufferAccessor2[j];
					Execute(ref newCombatantTargets3, ref combatantTargets3);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					DynamicBuffer<NewCombatantsBuffer> newCombatantTargets4 = bufferAccessor[k];
					DynamicBuffer<CombatantsTrackerBuffer> combatantTargets4 = bufferAccessor2[k];
					Execute(ref newCombatantTargets4, ref combatantTargets4);
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
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> __BossCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeMovementStateCD> __SnakeMovementStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		public RegisterNewCombatatsJob.InternalCompilerQueryAndHandleData __TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CattleCD> __CattleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ImmuneToDamageCD> __ImmuneToDamageCD_RO_ComponentLookup;

		public ResolveCombatatsJob.InternalCompilerQueryAndHandleData __TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			__BossCD_RO_ComponentLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
			__IsInCombatCD_RO_ComponentLookup = state.GetComponentLookup<IsInCombatCD>(isReadOnly: true);
			__SnakeMovementStateCD_RO_ComponentLookup = state.GetComponentLookup<SnakeMovementStateCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DisablePhysicsCD_RO_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__CattleCD_RO_ComponentLookup = state.GetComponentLookup<CattleCD>(isReadOnly: true);
			__ImmuneToDamageCD_RO_ComponentLookup = state.GetComponentLookup<ImmuneToDamageCD>(isReadOnly: true);
			__TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00004521_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00004521_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00004521_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00004522_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00004522_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00004522_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_309742109_0;

	private EntityQuery __query_309742109_1;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<WorldInfoCD>();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_309742109_0.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 3, 0.5f, out var ticksPerUpdate))
		{
			float deltaTime = state.WorldUnmanaged.Time.DeltaTime * (float)ticksPerUpdate;
			__ScheduleViaJobChunkExtension_0(new RegisterNewCombatatsJob
			{
				entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				entityPartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
				bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
				isInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsInCombatCD_RO_ComponentLookup, ref state),
				snakeMovementStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeMovementStateCD_RO_ComponentLookup, ref state),
				playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				pvpEnabled = __query_309742109_1.GetSingleton<WorldInfoCD>().pvpEnabled
			}, __TypeHandle.__TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			__ScheduleViaJobChunkExtension_1(new ResolveCombatatsJob
			{
				disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RO_ComponentLookup, ref state),
				healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
				entityPartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
				enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
				cattleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CattleCD_RO_ComponentLookup, ref state),
				playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				immuneToDamageLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ImmuneToDamageCD_RO_ComponentLookup, ref state),
				deltaTime = deltaTime
			}, __TypeHandle.__TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_0(RegisterNewCombatatsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__TrackedCombatantsSystem_RegisterNewCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __ScheduleViaJobChunkExtension_1(ResolveCombatatsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		__TypeHandle.__TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, ref state);
		__TypeHandle.__TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		__TypeHandle.__TrackedCombatantsSystem_ResolveCombatatsJob_WithDefaultQuery_JobEntityTypeHandle.Run(ref job, query);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_309742109_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_309742109_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00004521_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00004522_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((TrackedCombatantsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TrackedCombatantsSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((TrackedCombatantsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
