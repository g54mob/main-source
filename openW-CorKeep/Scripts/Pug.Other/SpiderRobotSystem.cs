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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
public struct SpiderRobotSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(RobotBossCD) })]
	[WithNone(new Type[] { typeof(InitializedRobotBossCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct SpawnBossMainBodyJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ChaseStateCD> __ChaseStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RoamingStateCD> __RoamingStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RobotBossCD> __RobotBossCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ChaseStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ChaseStateCD>();
					__RoamingStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingStateCD>();
					__RobotBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RobotBossCD>();
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ChaseStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RoamingStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RobotBossCD_RW_ComponentTypeHandle.Update(ref state);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<InitializedRobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChaseStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ObjectDataCD>();
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
			public void Run(ref SpawnBossMainBodyJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnBossMainBodyJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnBossMainBodyJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnBossMainBodyJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnBossMainBodyJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnBossMainBodyJob job, EntityManager entityManager)
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

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookUp;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref ChaseStateCD chaseStateRef, ref RoamingStateCD roamingPathStateCD, ref RobotBossCD robotBossRef, ref ShootMortarProjectileStateCD shootMortarStateCD, ref RangeAttackStateCD rangeAttackStateCD, in LocalTransform transformRef, in HealthCD healthCD, ref ObjectDataCD objectDataCD)
		{
			disablePhysicsLookUp.SetComponentEnabled(entity, value: false);
			ecb.SetComponent(entity, new ImmuneToDamageCD
			{
				Value = ImmuneToDamageState.Immune
			});
			ecb.AddComponent(entity, default(RobotBossTrackerCD));
			ecb.AddComponent<InitializedRobotBossCD>(entity);
			if (objectDataCD.variation == 0)
			{
				robotBossRef.internalState = RobotBossInternalState.StartedAggressive;
			}
			else if (objectDataCD.variation == 1)
			{
				robotBossRef.internalState = RobotBossInternalState.SpawnedInSitting;
			}
			else if (objectDataCD.variation == 2)
			{
				robotBossRef.hasDisabledAttacks = true;
				robotBossRef.internalState = RobotBossInternalState.StartedAggressive;
			}
			for (int i = 0; i < 4; i++)
			{
				RobotBossLegPosition legPosition;
				float3 position = CalculateLegPosition(transformRef.Position, i, out legPosition, robotBossRef.internalState == RobotBossInternalState.StartedAggressive);
				Entity entity2 = EntityUtility.CreateEntity(ecb, position, ObjectID.RobotBossLeg, 1, databaseBankCD.databaseBankBlob);
				ecb.AddComponent<DontSerializeCD>(entity2);
				ecb.AddComponent<DisablePhysicsCD>(entity2);
				ecb.SetComponent(entity2, new ImmuneToDamageCD
				{
					Value = ImmuneToDamageState.Immune
				});
				ecb.AddComponent(entity2, new RobotBossLegLocalState
				{
					prevDistSq = 999999f,
					stepTimer = 0f
				});
				ecb.AppendToBuffer(entity, new RobotBossLegsBuffer
				{
					leg = entity2,
					hasPlannedTarget = false,
					plannedTargetPosition = float3.zero,
					legPosition = legPosition
				});
				ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity2);
			}
			chaseStateRef.isDisabled = true;
			roamingPathStateCD.isDisabled = true;
			shootMortarStateCD.isDisabled = true;
			rangeAttackStateCD.isDisabled = true;
			robotBossRef.animateTheLegs = false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ChaseStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RoamingStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RobotBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr8, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr8, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr8, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr8, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, k));
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
	[WithAll(new Type[] { typeof(RobotBossCD) })]
	[WithAll(new Type[] { typeof(InitializedRobotBossCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct HandlePhasesAndEnterWalkingStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<RobotBossCD> __RobotBossCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public BufferTypeHandle<RobotBossLegsBuffer> __RobotBossLegsBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<RoamingStateCD> __RoamingStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MusicAreaCD> __MusicAreaCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ChaseStateCD> __ChaseStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<NearbyEntitiesTrackerCD> __NearbyEntitiesTrackerCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnrageStateCD> __EnrageStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__RobotBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RobotBossCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__RobotBossLegsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RobotBossLegsBuffer>();
					__RoamingStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingStateCD>();
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
					__MusicAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MusicAreaCD>();
					__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
					__ChaseStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ChaseStateCD>();
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<NearbyEntitiesTrackerCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__EnrageStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__RobotBossCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__RobotBossLegsBuffer_RW_BufferTypeHandle.Update(ref state);
					__RoamingStateCD_RW_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref state);
					__MusicAreaCD_RW_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RW_ComponentTypeHandle.Update(ref state);
					__ChaseStateCD_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__EnrageStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnrageStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedRobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossLegsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MusicAreaCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChaseStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<NearbyEntitiesTrackerCD>();
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
			public void Run(ref HandlePhasesAndEnterWalkingStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HandlePhasesAndEnterWalkingStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HandlePhasesAndEnterWalkingStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HandlePhasesAndEnterWalkingStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HandlePhasesAndEnterWalkingStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HandlePhasesAndEnterWalkingStateJob job, EntityManager entityManager)
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

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookUp;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref RobotBossCD robotBossRef, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, DynamicBuffer<RobotBossLegsBuffer> legsBuffer, ref RoamingStateCD roamingPathStateCD, in DistanceToPlayerCD distanceToPlayerCD, ref RangeAttackStateCD rangeAttackStateCD, ref ShootMortarProjectileStateCD shootMortarStateCD, ref MusicAreaCD musicAreaCD, ref ObjectDataCD objectDataCD, ref ChaseStateCD chaseStateCD, in HealthCD healthCD, ref NearbyEntitiesTrackerCD nearbyEntitiesTrackerCD, in LocalTransform localTransform, in EnrageStateCD enrageStateCD)
		{
			if (enrageStateCD.isEnraged && !robotBossRef.triggeredPhase2)
			{
				robotBossRef.triggeredPhase2 = true;
				musicAreaCD.musicRosterType = MusicRosterType.ROBOT_BOSS_PHASE2;
				robotBossRef.hasSetFiringPatternForNextAttack = false;
				EntityUtility.CreateEntity(ecb, localTransform.Position, ObjectID.RobotBossAttackPushback, 1, databaseBankCD.databaseBankBlob);
			}
			RobotBossInternalState internalState = robotBossRef.internalState;
			if (internalState == RobotBossInternalState.SpawnedInSitting || internalState == RobotBossInternalState.StartedAggressive || internalState == RobotBossInternalState.Phase1TransitioningToPhase2)
			{
				bool currentlySitting = objectDataCD.variation == 1;
				switch (robotBossRef.internalState)
				{
				case RobotBossInternalState.SpawnedInSitting:
					HandleSpawnedInSitting(ref robotBossRef, currentlySitting, ref animationBuffer, ref animationBufferPointer, ref nearbyEntitiesTrackerCD, ref musicAreaCD);
					break;
				case RobotBossInternalState.StartedAggressive:
					HandleStartedAggressive(entity, ref robotBossRef, ref animationBuffer, ref animationBufferPointer, ref roamingPathStateCD, ref rangeAttackStateCD, ref shootMortarStateCD, ref musicAreaCD, ref chaseStateCD, legsBuffer, ref nearbyEntitiesTrackerCD);
					break;
				case RobotBossInternalState.Phase1TransitioningToPhase2:
					HandlePhaseTransition(entity, ref robotBossRef, ref roamingPathStateCD, ref rangeAttackStateCD, ref shootMortarStateCD, ref musicAreaCD, ref chaseStateCD, legsBuffer);
					break;
				}
			}
		}

		private void HandleSpawnedInSitting(ref RobotBossCD robotBossRef, bool currentlySitting, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref NearbyEntitiesTrackerCD nearbyEntitiesTrackerCD, ref MusicAreaCD musicAreaCD)
		{
			if (!currentlySitting)
			{
				nearbyEntitiesTrackerCD.detectsLayer = 2u;
				robotBossRef.internalState = RobotBossInternalState.Phase1TransitioningToPhase2;
				robotBossRef.phase1ToPhase2Timer.Start(time, 17f);
				AnimationUtilities.TriggerAnimation(436585760, currentTick, animationBuffer, ref animationBufferPointer);
				musicAreaCD.musicRosterType = MusicRosterType.DONT_PLAY_MUSIC;
				musicAreaCD.isInactive = false;
				robotBossRef.partsDropsRemaining = 4;
			}
		}

		private void HandleStartedAggressive(Entity entity, ref RobotBossCD robotBossRef, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref RoamingStateCD roamingPathStateCD, ref RangeAttackStateCD rangeAttackStateCD, ref ShootMortarProjectileStateCD shootMortarStateCD, ref MusicAreaCD musicAreaCD, ref ChaseStateCD chaseStateCD, DynamicBuffer<RobotBossLegsBuffer> legsBuffer, ref NearbyEntitiesTrackerCD nearbyEntitiesTrackerCD)
		{
			nearbyEntitiesTrackerCD.detectsLayer = 2u;
			AnimationUtilities.TriggerAnimation(910517187, currentTick, animationBuffer, ref animationBufferPointer);
			StartWalkingAndAttacking(entity, ref robotBossRef, ref roamingPathStateCD, ref rangeAttackStateCD, ref shootMortarStateCD, ref musicAreaCD, ref chaseStateCD, legsBuffer);
			if (robotBossRef.hasDisabledAttacks)
			{
				chaseStateCD.isDisabled = false;
			}
			robotBossRef.partsDropsRemaining = 2;
		}

		private void HandlePhaseTransition(Entity entity, ref RobotBossCD robotBossRef, ref RoamingStateCD roamingPathStateCD, ref RangeAttackStateCD rangeAttackStateCD, ref ShootMortarProjectileStateCD shootMortarStateCD, ref MusicAreaCD musicAreaCD, ref ChaseStateCD chaseStateCD, DynamicBuffer<RobotBossLegsBuffer> legsBuffer)
		{
			if (robotBossRef.phase1ToPhase2Timer.GetElapsedTime(time) > 10.5f)
			{
				robotBossRef.animateTheLegs = true;
			}
			if (robotBossRef.phase1ToPhase2Timer.isRunning && robotBossRef.phase1ToPhase2Timer.IsTimerElapsed(time))
			{
				disablePhysicsLookUp.SetComponentEnabled(entity, value: true);
				robotBossRef.internalState = RobotBossInternalState.Phase2Walking;
				robotBossRef.phase1ToPhase2Timer.Stop();
				StartWalkingAndAttacking(entity, ref robotBossRef, ref roamingPathStateCD, ref rangeAttackStateCD, ref shootMortarStateCD, ref musicAreaCD, ref chaseStateCD, legsBuffer);
			}
		}

		private void StartWalkingAndAttacking(Entity entity, ref RobotBossCD robotBossRef, ref RoamingStateCD roamingPathStateCD, ref RangeAttackStateCD rangeAttackStateCD, ref ShootMortarProjectileStateCD shootMortarStateCD, ref MusicAreaCD musicAreaCD, ref ChaseStateCD chaseStateRef, DynamicBuffer<RobotBossLegsBuffer> legsBuffer)
		{
			disablePhysicsLookUp.SetComponentEnabled(entity, value: true);
			musicAreaCD.isInactive = false;
			musicAreaCD.musicRosterType = MusicRosterType.ROBOT_BOSS_PHASE1;
			robotBossRef.phase1ToPhase2Timer.Stop();
			robotBossRef.internalState = RobotBossInternalState.Phase2Walking;
			robotBossRef.animateTheLegs = true;
			if (!robotBossRef.hasDisabledAttacks)
			{
				roamingPathStateCD.isDisabled = false;
				shootMortarStateCD.isDisabled = false;
				rangeAttackStateCD.isDisabled = false;
			}
			else
			{
				roamingPathStateCD.isDisabled = false;
				shootMortarStateCD.isDisabled = true;
				rangeAttackStateCD.isDisabled = true;
			}
			rangeAttackStateCD.minCooldown = 13f;
			rangeAttackStateCD.maxCooldown = 17f;
			for (int i = 0; i < legsBuffer.Length; i++)
			{
				Entity leg = legsBuffer[i].leg;
				disablePhysicsLookUp.SetComponentEnabled(leg, value: false);
				ecb.SetComponent(leg, new ImmuneToDamageCD
				{
					Value = ImmuneToDamageState.Vulnerable
				});
			}
			robotBossRef.legsAreVulnerable = true;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RobotBossCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			BufferAccessor<RobotBossLegsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__RobotBossLegsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RoamingStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MusicAreaCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ChaseStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr11 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr12 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__NearbyEntitiesTrackerCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr13 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr14 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnrageStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref RobotBossCD robotBossRef = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					ref AnimationBufferPointer animationBufferPointer = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, i);
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer = bufferAccessor2[i];
					Execute(entity, ref robotBossRef, ref animationBuffer, ref animationBufferPointer, legsBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr7, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr8, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr10, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr11, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr12, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr13, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr14, i));
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
						ref RobotBossCD robotBossRef2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						ref AnimationBufferPointer animationBufferPointer2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<RobotBossLegsBuffer> legsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref robotBossRef2, ref animationBuffer2, ref animationBufferPointer2, legsBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr7, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr8, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr10, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr11, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr12, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr13, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr14, nextRangeBegin));
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
					ref RobotBossCD robotBossRef3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					ref AnimationBufferPointer animationBufferPointer3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, j);
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref robotBossRef3, ref animationBuffer3, ref animationBufferPointer3, legsBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr7, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr8, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr10, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr11, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr12, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr13, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr14, j));
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
					ref RobotBossCD robotBossRef4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					ref AnimationBufferPointer animationBufferPointer4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, k);
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref robotBossRef4, ref animationBuffer4, ref animationBufferPointer4, legsBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr7, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr8, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr9, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr10, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr11, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<NearbyEntitiesTrackerCD>(nativeArrayPtr12, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr13, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr14, k));
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
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	[WithAll(new Type[] { typeof(RobotBossCD) })]
	[WithAll(new Type[] { typeof(InitializedRobotBossCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct ControlRangeAttackPatternsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<RobotBossCD> __RobotBossCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RoamingStateCD> __RoamingStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnrageStateCD> __EnrageStateCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__RobotBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RobotBossCD>();
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
					__RoamingStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingStateCD>();
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__EnrageStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__RobotBossCD_RW_ComponentTypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RoamingStateCD_RW_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__EnrageStateCD_RO_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnrageStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedRobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingStateCD>();
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
			public void Run(ref ControlRangeAttackPatternsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ControlRangeAttackPatternsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ControlRangeAttackPatternsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ControlRangeAttackPatternsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ControlRangeAttackPatternsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ControlRangeAttackPatternsJob job, EntityManager entityManager)
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
		public ComponentLookup<LocalTransform> localTransformLookUp;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref RobotBossCD robotBossRef, ref RangeAttackStateCD rangeStateRef, in StateInfoCD stateInfo, ref ShootMortarProjectileStateCD shootMortarStateRef, ref RoamingStateCD roamingPathStateCD, in DistanceToPlayerCD distanceToPlayerCD, in LocalTransform localTransform, in EnrageStateCD enrageStateCD, in HealthCD healthCD)
		{
			if (robotBossRef.internalState != RobotBossInternalState.Phase2Walking || robotBossRef.hasDisabledAttacks)
			{
				return;
			}
			if (rangeStateRef.aimingAtEntity != Entity.Null)
			{
				float3 x = localTransformLookUp[rangeStateRef.aimingAtEntity].Position - localTransform.Position;
				x.y = 0f;
				if (math.lengthsq(x) < 1E-06f)
				{
					x = new float3(1f, 0f, -1f);
				}
				float3 float5 = math.normalizesafe(x);
				robotBossRef.rangeAttackDirection = new float3(float5.x, 0f, float5.z);
			}
			if (!robotBossRef.pauseWalkDuringShootingimer.isRunning && stateInfo.IsCurrentState(StateID.RangeAttack) && rangeStateRef.internalState == RangeAttackInternalState.Shooting)
			{
				roamingPathStateCD.isDisabled = true;
				robotBossRef.pauseWalkDuringShootingimer.Start(time, 1f);
			}
			if (robotBossRef.pauseWalkDuringShootingimer.isRunning && robotBossRef.pauseWalkDuringShootingimer.IsTimerElapsed(time))
			{
				robotBossRef.pauseWalkDuringShootingimer.Stop();
				roamingPathStateCD.isDisabled = false;
			}
			if (stateInfo.IsCurrentState(StateID.RangeAttack) && rangeStateRef.internalState == RangeAttackInternalState.CeasingToShoot)
			{
				if (robotBossRef.hasSetFiringPatternForNextAttack)
				{
					robotBossRef.hasSetFiringPatternForNextAttack = false;
					robotBossRef.rangeAttackIndex++;
				}
				return;
			}
			bool isEnraged = enrageStateCD.isEnraged;
			bool flag = isEnraged && (float)healthCD.health < (float)healthCD.maxHealth * 0.2f;
			if (robotBossRef.fireLargeProjectile)
			{
				if (distanceToPlayerCD.closestPlayer == Entity.Null)
				{
					robotBossRef.fireLargeProjectile = false;
					return;
				}
				robotBossRef.fireLargeProjectile = false;
				robotBossRef.hasSetFiringPatternForNextAttack = true;
				rangeStateRef.projectileID = ObjectID.RobotBossLargeProjectile;
				rangeStateRef.animPerShotID = 120187574;
				if (isEnraged)
				{
					rangeStateRef.projectileVariation = 1;
					rangeStateRef.anticipationDuration = (flag ? 1.5f : 2f);
					rangeStateRef.endDuration = 0.5f;
					rangeStateRef.attackDuration = (flag ? 1.8f : 3f);
				}
				else
				{
					rangeStateRef.projectileVariation = 0;
					rangeStateRef.anticipationDuration = 2.4f;
					rangeStateRef.endDuration = 1f;
					rangeStateRef.attackDuration = 2f;
				}
				rangeStateRef.minCooldown = 6f;
				rangeStateRef.maxCooldown = 6f;
				rangeStateRef.timeBetweenShots = 0.35f;
				rangeStateRef.minExtrapolatedAimDistanceSq = 3f;
				rangeStateRef.maxExtrapolatedAimDistanceSq = 4f;
				robotBossRef.rangeAttackPattern = RobotBossAttackPattern.swirlAttack;
				rangeStateRef.projectileTargetsSelf = false;
				rangeStateRef.dontAllowReAimingDuringAntipation = true;
				rangeStateRef.allowReAimingWhileShooting = true;
				rangeStateRef.projectilesPerShot = 1;
				rangeStateRef.spawnDirectionType = ProjectileSpawnDirectionType.Free;
				rangeStateRef.spreadType = ProjectileSpreadType.None;
			}
			else if (!robotBossRef.hasSetFiringPatternForNextAttack)
			{
				if ((isEnraged && robotBossRef.rangeAttackIndex % 2 == 0) || (isEnraged && robotBossRef.rangeAttackIndex % 3 == 0))
				{
					shootMortarStateRef.mortarProjectileID = ObjectID.RobotBossVoidMortarProjectile;
					shootMortarStateRef.minAmountOfProjectiles = 4;
					shootMortarStateRef.maxAmountOfProjectiles = 6;
				}
				else
				{
					shootMortarStateRef.mortarProjectileID = ObjectID.RobotBossFireRocketMortarProjectile;
					shootMortarStateRef.airTimeAdditionBetweenProjectiles = 0.1f;
					shootMortarStateRef.minAmountOfProjectiles = 6;
					shootMortarStateRef.maxAmountOfProjectiles = 10;
				}
				robotBossRef.hasSetFiringPatternForNextAttack = true;
				robotBossRef.chainedAttackCounter++;
				float num = 0.3f;
				float anticipationDuration = robotBossRef.chainedDelayBetweenAttacks / 2f;
				float endDuration = robotBossRef.chainedDelayBetweenAttacks / 3f;
				float attackDuration = 1f;
				if (robotBossRef.chainedAttackCounter == 1)
				{
					anticipationDuration = 1.2f;
				}
				if (isEnraged ? (robotBossRef.chainedAttackCounter < robotBossRef.numberOfAttacksInChain * 2) : (robotBossRef.chainedAttackCounter < robotBossRef.numberOfAttacksInChain))
				{
					attackDuration = robotBossRef.chainedDelayBetweenAttacks / 3f;
				}
				else
				{
					EntityUtility.CreateEntity(ecb, localTransform.Position, ObjectID.RobotBossAttackPushback, 1, databaseBankCD.databaseBankBlob);
					robotBossRef.fireLargeProjectile = true;
					robotBossRef.chainedAttackCounter = 0;
					endDuration = 1f;
					num = 4f;
				}
				rangeStateRef.projectileTargetsSelf = true;
				rangeStateRef.projectileID = ObjectID.BulletHellProjectile;
				rangeStateRef.animPerShotID = 1262804752;
				rangeStateRef.projectileVariation = (enrageStateCD.isEnraged ? 2 : 0);
				rangeStateRef.dontAllowReAimingDuringAntipation = false;
				rangeStateRef.spawnDirectionType = ProjectileSpawnDirectionType.Free;
				rangeStateRef.allowReAimingWhileShooting = false;
				rangeStateRef.startSpreadAngleOffset = 0f;
				rangeStateRef.timeBetweenShots = 0f;
				switch (robotBossRef.rangeAttackIndex % 6)
				{
				case 0:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.all;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.projectilesPerShot = 8;
					rangeStateRef.spreadAngle = 45f;
					break;
				case 1:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.Cardinal;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.projectilesPerShot = 4;
					rangeStateRef.spreadAngle = 90f;
					break;
				case 2:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.Diagonal;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.startSpreadAngleOffset = 45f;
					rangeStateRef.projectilesPerShot = 4;
					rangeStateRef.spreadAngle = 90f;
					break;
				case 3:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.Diagonal30;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.startSpreadAngleOffset = 30f;
					rangeStateRef.projectilesPerShot = 4;
					rangeStateRef.spreadAngle = 90f;
					break;
				case 4:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.Diagonal60;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.startSpreadAngleOffset = 60f;
					rangeStateRef.projectilesPerShot = 4;
					rangeStateRef.spreadAngle = 90f;
					break;
				case 5:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.all;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.projectilesPerShot = 8;
					rangeStateRef.spreadAngle = 45f;
					break;
				case 6:
					robotBossRef.rangeAttackPattern = RobotBossAttackPattern.Rotate;
					rangeStateRef.anticipationDuration = anticipationDuration;
					rangeStateRef.endDuration = endDuration;
					rangeStateRef.attackDuration = attackDuration;
					rangeStateRef.minCooldown = num;
					rangeStateRef.maxCooldown = num;
					rangeStateRef.timeBetweenShots = 0f;
					rangeStateRef.spreadType = ProjectileSpreadType.Spiral;
					rangeStateRef.projectilesPerShot = 8;
					rangeStateRef.spreadAngle = 45f;
					break;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RobotBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RoamingStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnrageStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr9, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr10, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr6, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr9, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr10, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr9, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr10, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr9, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr10, k));
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
	[WithAll(new Type[] { typeof(InitializedRobotBossCD) })]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct MoveLegsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ChaseStateCD> __ChaseStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RobotBossCD> __RobotBossCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<RobotBossLegsBuffer> __RobotBossLegsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnrageStateCD> __EnrageStateCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ChaseStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ChaseStateCD>();
					__RobotBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RobotBossCD>();
					__RobotBossLegsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RobotBossLegsBuffer>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
					__EnrageStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ChaseStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RobotBossCD_RW_ComponentTypeHandle.Update(ref state);
					__RobotBossLegsBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref state);
					__EnrageStateCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EnrageStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedRobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChaseStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossLegsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
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
			public void Run(ref MoveLegsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref MoveLegsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref MoveLegsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref MoveLegsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref MoveLegsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref MoveLegsJob job, EntityManager entityManager)
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
		public ComponentLookup<LocalTransform> localTransformLookUp;

		public ComponentLookup<RobotBossLegLocalState> legLocalLookup;

		public Entity tileDamageBufferEntity;

		public EntityCommandBuffer ecb;

		public float deltaTime;

		public double time;

		public bool updateLegs;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref ChaseStateCD chaseStateCD, ref RobotBossCD robotBossRef, DynamicBuffer<RobotBossLegsBuffer> legsBuffer, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref PhysicsVelocity velocity, in EnrageStateCD enrageStateCD)
		{
			if (!updateLegs)
			{
				return;
			}
			if (robotBossRef.animateTheLegs && legsBuffer.Length != 0)
			{
				RobotBossInternalState internalState = robotBossRef.internalState;
				if (internalState == RobotBossInternalState.Phase2Walking || internalState == RobotBossInternalState.Phase2WalkingButDown || internalState == RobotBossInternalState.Phase1TransitioningToPhase2)
				{
					float3 x = velocity.Linear;
					if (math.lengthsq(x) < 0.0001f)
					{
						x = new float3(1f, 0f, 0f);
					}
					x = math.normalizesafe(x);
					if (robotBossRef.legStepCooldownTimer > 0f)
					{
						robotBossRef.legStepCooldownTimer -= deltaTime;
					}
					bool isActuallyMoving = math.lengthsq(velocity.Linear) > 0.001f;
					robotBossRef.isActuallyMoving = isActuallyMoving;
					LocalTransform localTransform = localTransformLookUp[entity];
					float num = math.max(0.0001f, enrageStateCD.isEnraged ? (robotBossRef.distanceToTriggerLegMovement * 0.9f) : robotBossRef.distanceToTriggerLegMovement);
					float num2 = num * num;
					float num3 = math.max(0.0001f, enrageStateCD.isEnraged ? (robotBossRef.startDistance * 0.9f) : robotBossRef.startDistance);
					float num4 = num3 * num3;
					bool flag = false;
					for (int i = 0; i < legsBuffer.Length; i++)
					{
						flag |= legsBuffer[i].hasPlannedTarget;
					}
					if (!flag)
					{
						robotBossRef.legStepCooldownTimer = 0f;
					}
					int currentLegPairWalking = robotBossRef.currentLegPairWalking;
					int num5 = PairIndexA(currentLegPairWalking);
					int num6 = PairIndexB(currentLegPairWalking);
					if (!legsBuffer[num5].hasPlannedTarget && !legsBuffer[num6].hasPlannedTarget && robotBossRef.legStepCooldownTimer <= 0f)
					{
						robotBossRef.legStepCooldownTimer = robotBossRef.legStepCooldownDuration;
						int num7 = 1 - currentLegPairWalking;
						int num8 = PairIndexA(num7);
						int num9 = PairIndexB(num7);
						float num10 = (enrageStateCD.isEnraged ? 3.2f : robotBossRef.legXOffset);
						float num11 = (enrageStateCD.isEnraged ? 2.2f : robotBossRef.legZOffset);
						for (int j = 0; j < 2; j++)
						{
							int num12 = ((j == 0) ? num8 : num9);
							RobotBossLegsBuffer value = legsBuffer[num12];
							LocalTransform localTransform2 = localTransformLookUp[value.leg];
							RobotBossLegLocalState value2 = legLocalLookup[value.leg];
							float3 float5 = num12 switch
							{
								0 => new float3(0f - num10, 0f, num11), 
								1 => new float3(num10, 0f, num11), 
								2 => new float3(num10, 0f, 0f - num11), 
								3 => new float3(0f - num10, 0f, 0f - num11), 
								_ => float3.zero, 
							};
							if (value.brokenTimer.isRunning)
							{
								float5 *= 0.8f;
							}
							float num13 = math.sin((float)time * 6f + (float)num12 * 1.37f) * 0.08f;
							float3 float6 = x * num13;
							if (value.brokenTimer.isRunning)
							{
								float6 *= 1.4f;
							}
							float3 float7 = localTransform.Position + float5 + float6 + x * robotBossRef.stepForwardDistance;
							float3 x2 = float7 - localTransform2.Position;
							x2.y = 0f;
							float num14 = math.lengthsq(x2);
							if (!value.hasPlannedTarget && num14 >= num2)
							{
								value.plannedTargetPosition = float7;
								value.hasPlannedTarget = true;
								value2.prevDistSq = math.lengthsq(float7 - localTransform2.Position);
								value2.stepTimer = 0f;
								legsBuffer[num12] = value;
								legLocalLookup[value.leg] = value2;
							}
						}
						robotBossRef.currentLegPairWalking = num7;
						currentLegPairWalking = num7;
						num5 = PairIndexA(currentLegPairWalking);
						num6 = PairIndexB(currentLegPairWalking);
					}
					for (int k = 0; k < 2; k++)
					{
						int index = ((k == 0) ? num5 : num6);
						RobotBossLegsBuffer value3 = legsBuffer[index];
						LocalTransform localTransform3 = localTransformLookUp[value3.leg];
						float3 x3 = value3.plannedTargetPosition - localTransform3.Position;
						float num15 = math.lengthsq(x3);
						RobotBossLegLocalState value4 = legLocalLookup[value3.leg];
						if (value3.hasPlannedTarget)
						{
							if (num15 < robotBossRef.stepForwardDistance * robotBossRef.stepForwardDistance && num15 > value4.prevDistSq * 1.05f)
							{
								float3 plannedTargetPosition = value3.plannedTargetPosition;
								plannedTargetPosition.y = 0f;
								value3.hasPlannedTarget = false;
								ecb.SetComponent(value3.leg, LocalTransform.FromPosition(plannedTargetPosition));
								legsBuffer[index] = value3;
								HydraBossSystem.DestroyTilesWithinRadius(2f, plannedTargetPosition, ecb, tileDamageBufferEntity);
								continue;
							}
							value4.stepTimer += deltaTime;
							if (value4.stepTimer > 2f)
							{
								float3 plannedTargetPosition2 = value3.plannedTargetPosition;
								plannedTargetPosition2.y = 0f;
								value3.hasPlannedTarget = false;
								ecb.SetComponent(value3.leg, LocalTransform.FromPosition(plannedTargetPosition2));
								legsBuffer[index] = value3;
								HydraBossSystem.DestroyTilesWithinRadius(2f, plannedTargetPosition2, ecb, tileDamageBufferEntity);
								continue;
							}
							value4.prevDistSq = num15;
							legsBuffer[index] = value3;
							legLocalLookup[value3.leg] = value4;
						}
						if (value3.hasPlannedTarget && num15 > num4)
						{
							float3 float8 = math.normalizesafe(x3);
							float num16 = math.sqrt(num15);
							float num17 = math.max(0.0001f, robotBossRef.stepForwardDistance);
							float num18 = math.max(0.0001f, robotBossRef.stepHeightProgressMultiplier);
							float t = math.saturate(num16 / num17);
							float num19 = math.lerp(0.15f, 1f, t);
							float y = math.sin((1f - math.saturate(num16 / num18)) * MathF.PI) * robotBossRef.maxStepHeight;
							float num20 = robotBossRef.legMovementSpeed * num19;
							if (value3.brokenTimer.isRunning)
							{
								num20 *= 1.5f;
							}
							float3 position = localTransform3.Position + float8 * num20 * deltaTime;
							position.y = y;
							ecb.SetComponent(value3.leg, LocalTransform.FromPosition(position));
						}
						else if (value3.hasPlannedTarget)
						{
							float3 plannedTargetPosition3 = value3.plannedTargetPosition;
							plannedTargetPosition3.y = 0f;
							value3.hasPlannedTarget = false;
							ecb.SetComponent(value3.leg, LocalTransform.FromPosition(plannedTargetPosition3));
							legsBuffer[index] = value3;
							HydraBossSystem.DestroyTilesWithinRadius(2f, plannedTargetPosition3, ecb, tileDamageBufferEntity);
						}
					}
					return;
				}
			}
			if (robotBossRef.isActuallyMoving)
			{
				robotBossRef.isActuallyMoving = false;
			}
			static int PairIndexA(int pair)
			{
				if (pair != 0)
				{
					return 1;
				}
				return 0;
			}
			static int PairIndexB(int pair)
			{
				if (pair != 0)
				{
					return 3;
				}
				return 2;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ChaseStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RobotBossCD_RW_ComponentTypeHandle);
			BufferAccessor<RobotBossLegsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__RobotBossLegsBuffer_RW_BufferTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnrageStateCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref ChaseStateCD chaseStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, i);
					ref RobotBossCD robotBossRef = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr3, i);
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer = bufferAccessor[i];
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor2[i];
					Execute(entity, ref chaseStateCD, ref robotBossRef, legsBuffer, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr6, i));
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
						ref ChaseStateCD chaseStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, nextRangeBegin);
						ref RobotBossCD robotBossRef2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<RobotBossLegsBuffer> legsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref chaseStateCD2, ref robotBossRef2, legsBuffer2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref ChaseStateCD chaseStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, j);
					ref RobotBossCD robotBossRef3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr3, j);
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer3 = bufferAccessor[j];
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref chaseStateCD3, ref robotBossRef3, legsBuffer3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr6, j));
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
					ref ChaseStateCD chaseStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr2, k);
					ref RobotBossCD robotBossRef4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr3, k);
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer4 = bufferAccessor[k];
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref chaseStateCD4, ref robotBossRef4, legsBuffer4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr6, k));
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
		typeof(RobotBossCD),
		typeof(HealthCD)
	})]
	[WithAll(new Type[] { typeof(InitializedRobotBossCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct CheckLegsHealthJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<RoamingStateCD> __RoamingStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RoamingPathCD> __RoamingPathCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MusicAreaCD> __MusicAreaCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RobotBossCD> __RobotBossCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ChaseStateCD> __ChaseStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<RobotBossLegsBuffer> __RobotBossLegsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EnrageStateCD> __EnrageStateCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__RoamingStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingStateCD>();
					__RoamingPathCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingPathCD>();
					__MusicAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MusicAreaCD>();
					__RobotBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RobotBossCD>();
					__MovementSpeedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>();
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__ChaseStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ChaseStateCD>();
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__RobotBossLegsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<RobotBossLegsBuffer>();
					__EnrageStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EnrageStateCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__RoamingStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RoamingPathCD_RW_ComponentTypeHandle.Update(ref state);
					__MusicAreaCD_RW_ComponentTypeHandle.Update(ref state);
					__RobotBossCD_RW_ComponentTypeHandle.Update(ref state);
					__MovementSpeedCD_RW_ComponentTypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__ChaseStateCD_RW_ComponentTypeHandle.Update(ref state);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__RobotBossLegsBuffer_RW_BufferTypeHandle.Update(ref state);
					__EnrageStateCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EnrageStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedRobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingPathCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MusicAreaCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ChaseStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RobotBossLegsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
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
			public void Run(ref CheckLegsHealthJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CheckLegsHealthJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CheckLegsHealthJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CheckLegsHealthJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CheckLegsHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CheckLegsHealthJob job, EntityManager entityManager)
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

		public ComponentLookup<HealthCD> healthGroup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public TileAccessor tileAccessor;

		public NetworkTick currentTick;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookUp;

		public EntityCommandBuffer ecb;

		public Unity.Mathematics.Random rng;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref RoamingStateCD roamingStateCD, ref RoamingPathCD roamingPathCD, ref MusicAreaCD musicAreaCD, ref RobotBossCD robotBossRef, ref MovementSpeedCD movementSpeedCD, ref RangeAttackStateCD rangeAttackStateCD, ref ChaseStateCD chaseStateCD, ref ShootMortarProjectileStateCD shootMortarStateCD, ref AnimationBufferPointer animationBufferPointer, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref DynamicBuffer<RobotBossLegsBuffer> legsBuffer, in EnrageStateCD enrageStateCD, LocalTransform transform)
		{
			ref HealthCD valueRW = ref healthGroup.GetRefRW(entity).ValueRW;
			RobotBossInternalState internalState = robotBossRef.internalState;
			if (internalState != RobotBossInternalState.Phase2Walking && internalState != RobotBossInternalState.Phase2WalkingButDown)
			{
				return;
			}
			if (entityDestroyedLookup.HasAndIsComponentEnabled(entity))
			{
				musicAreaCD.isInactive = true;
				return;
			}
			if (robotBossRef.fellInLava)
			{
				robotBossRef.lavaHealthDrainTimer -= deltaTime;
				if (robotBossRef.lavaHealthDrainTimer <= 0f)
				{
					robotBossRef.lavaHealthDrainTimer = 1f;
					valueRW.health -= 2000;
				}
			}
			bool flag = true;
			for (int i = 0; i < legsBuffer.Length; i++)
			{
				Entity leg = legsBuffer[i].leg;
				if (entityDestroyedLookup.HasComponent(leg))
				{
					entityDestroyedLookup.IsComponentEnabled(leg);
				}
				if (!healthGroup.TryGetComponent(leg, out var componentData))
				{
					flag = false;
					continue;
				}
				RobotBossLegsBuffer value = legsBuffer[i];
				bool flag2 = (float)componentData.health <= 0f;
				value.brokenTimerValue = (value.brokenTimer.isRunning ? ((int)math.ceil(value.brokenTimer.GetElapsedTime(time))) : 0);
				if (flag2)
				{
					if (!value.brokenTimer.isRunning)
					{
						value.brokenTimerValue = 0;
						value.brokenTimer.Start(time, robotBossRef.legBrokenTime);
					}
					if (value.brokenTimer.IsTimerElapsed(time))
					{
						value.brokenTimerValue = 0;
						componentData.health = componentData.maxHealth;
						ecb.SetComponent(leg, componentData);
						value.brokenTimer.Stop();
						flag2 = false;
					}
				}
				else if (value.brokenTimer.isRunning)
				{
					value.brokenTimer.Stop();
					value.brokenTimerValue = 0;
				}
				if (!flag2)
				{
					flag = false;
				}
				legsBuffer[i] = value;
			}
			if (flag && robotBossRef.internalState != RobotBossInternalState.Phase2WalkingButDown)
			{
				robotBossRef.internalState = RobotBossInternalState.Phase2WalkingButDown;
				robotBossRef.downLifeCheckBuffer = valueRW.health;
				roamingStateCD.isDisabled = true;
				rangeAttackStateCD.isDisabled = true;
				shootMortarStateCD.isDisabled = true;
				for (int j = 0; j < legsBuffer.Length; j++)
				{
					Entity leg2 = legsBuffer[j].leg;
					disablePhysicsLookUp.SetComponentEnabled(leg2, value: true);
					ecb.SetComponent(leg2, new ImmuneToDamageCD
					{
						Value = ImmuneToDamageState.Immune
					});
				}
				robotBossRef.legsAreVulnerable = false;
				AnimationUtilities.TriggerAnimation(-78586100, currentTick, animationBuffer, ref animationBufferPointer);
				robotBossRef.walkingButDownTimer.Start(time, 10f);
			}
			else if (robotBossRef.walkingButDownTimer.isRunning && robotBossRef.walkingButDownTimer.GetElapsedTime(time) > 1.8f && disablePhysicsLookUp.IsComponentEnabled(entity))
			{
				disablePhysicsLookUp.SetComponentEnabled(entity, value: false);
				ecb.SetComponent(entity, new ImmuneToDamageCD
				{
					Value = ImmuneToDamageState.Vulnerable
				});
				int2 center = transform.Position.RoundToInt2();
				if (!robotBossRef.fellInLava && IsLavaWithinRadius(center, 2, tileAccessor))
				{
					robotBossRef.fellInLava = true;
				}
				EntityUtility.CreateEntity(ecb, transform.Position, ObjectID.RobotBossAttackPushback, 1, databaseBankCD.databaseBankBlob);
				if (robotBossRef.partsDropsRemaining > 0 && (float)valueRW.health < (float)valueRW.maxHealth * 0.65f)
				{
					robotBossRef.partsDropsRemaining--;
					int num = rng.NextInt(2, 4);
					for (int k = 0; k < num; k++)
					{
						int amount = rng.NextInt(1, 3);
						ObjectID objectID = ((rng.NextFloat() < 0.7f) ? ObjectID.MechanicalPart : ObjectID.ScrapPart);
						ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
						{
							objectData = new ObjectDataCD
							{
								objectID = objectID,
								variation = 0,
								amount = amount
							}
						};
						float3 float5 = new float3(rng.NextFloat(-4f, 4f), 0f, rng.NextFloat(-4f, 4f));
						EntityUtility.DropNewEntity(ecb, containedObject, transform.Position + float5, databaseBankCD.databaseBankBlob);
					}
				}
			}
			else if (!disablePhysicsLookUp.IsComponentEnabled(entity) && robotBossRef.internalState == RobotBossInternalState.Phase2WalkingButDown && robotBossRef.walkingButDownTimer.isRunning && (robotBossRef.walkingButDownTimer.IsTimerElapsed(time) || ((float)valueRW.health > (float)valueRW.maxHealth * 0.08f && robotBossRef.downLifeCheckBuffer - (float)valueRW.health >= (float)valueRW.maxHealth / 4f)))
			{
				robotBossRef.internalState = RobotBossInternalState.Phase2Walking;
				robotBossRef.walkingButDownTimer.Stop();
				robotBossRef.fellInLava = false;
				robotBossRef.walkingGetBackUpTimer.Start(time, 5f);
				AnimationUtilities.TriggerAnimation(910517187, currentTick, animationBuffer, ref animationBufferPointer);
				ecb.SetComponent(entity, new ImmuneToDamageCD
				{
					Value = ImmuneToDamageState.Immune
				});
				for (int l = 0; l < legsBuffer.Length; l++)
				{
					Entity leg3 = legsBuffer[l].leg;
					if (healthGroup.TryGetComponent(leg3, out var componentData2))
					{
						componentData2.health = componentData2.maxHealth;
						ecb.SetComponent(leg3, componentData2);
					}
				}
				disablePhysicsLookUp.SetComponentEnabled(entity, value: true);
			}
			else if (robotBossRef.internalState == RobotBossInternalState.Phase2Walking && robotBossRef.walkingGetBackUpTimer.isRunning && robotBossRef.walkingGetBackUpTimer.IsTimerElapsed(time))
			{
				robotBossRef.walkingGetBackUpTimer.Stop();
				if (!robotBossRef.hasDisabledAttacks)
				{
					shootMortarStateCD.isDisabled = false;
					rangeAttackStateCD.isDisabled = false;
				}
				roamingStateCD.isDisabled = false;
				robotBossRef.legsAreVulnerable = true;
				for (int m = 0; m < legsBuffer.Length; m++)
				{
					disablePhysicsLookUp.SetComponentEnabled(legsBuffer[m].leg, value: false);
					ecb.SetComponent(legsBuffer[m].leg, new ImmuneToDamageCD
					{
						Value = ImmuneToDamageState.Vulnerable
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RoamingStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RoamingPathCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MusicAreaCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RobotBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ChaseStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			BufferAccessor<RobotBossLegsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__RobotBossLegsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr11 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EnrageStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr12 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref RoamingStateCD roamingStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, i);
					ref RoamingPathCD roamingPathCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr3, i);
					ref MusicAreaCD musicAreaCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr4, i);
					ref RobotBossCD robotBossRef = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr5, i);
					ref MovementSpeedCD movementSpeedCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, i);
					ref RangeAttackStateCD rangeAttackStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr7, i);
					ref ChaseStateCD chaseStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr8, i);
					ref ShootMortarProjectileStateCD shootMortarStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr9, i);
					ref AnimationBufferPointer animationBufferPointer = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr10, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer = bufferAccessor2[i];
					Execute(entity, ref roamingStateCD, ref roamingPathCD, ref musicAreaCD, ref robotBossRef, ref movementSpeedCD, ref rangeAttackStateCD, ref chaseStateCD, ref shootMortarStateCD, ref animationBufferPointer, ref animationBuffer, ref legsBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr11, i), InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr12, i));
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
						ref RoamingStateCD roamingStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, nextRangeBegin);
						ref RoamingPathCD roamingPathCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr3, nextRangeBegin);
						ref MusicAreaCD musicAreaCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr4, nextRangeBegin);
						ref RobotBossCD robotBossRef2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr5, nextRangeBegin);
						ref MovementSpeedCD movementSpeedCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, nextRangeBegin);
						ref RangeAttackStateCD rangeAttackStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr7, nextRangeBegin);
						ref ChaseStateCD chaseStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr8, nextRangeBegin);
						ref ShootMortarProjectileStateCD shootMortarStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr9, nextRangeBegin);
						ref AnimationBufferPointer animationBufferPointer2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr10, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<RobotBossLegsBuffer> legsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref roamingStateCD2, ref roamingPathCD2, ref musicAreaCD2, ref robotBossRef2, ref movementSpeedCD2, ref rangeAttackStateCD2, ref chaseStateCD2, ref shootMortarStateCD2, ref animationBufferPointer2, ref animationBuffer2, ref legsBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr11, nextRangeBegin), InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr12, nextRangeBegin));
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
					ref RoamingStateCD roamingStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, j);
					ref RoamingPathCD roamingPathCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr3, j);
					ref MusicAreaCD musicAreaCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr4, j);
					ref RobotBossCD robotBossRef3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr5, j);
					ref MovementSpeedCD movementSpeedCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, j);
					ref RangeAttackStateCD rangeAttackStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr7, j);
					ref ChaseStateCD chaseStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr8, j);
					ref ShootMortarProjectileStateCD shootMortarStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr9, j);
					ref AnimationBufferPointer animationBufferPointer3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr10, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref roamingStateCD3, ref roamingPathCD3, ref musicAreaCD3, ref robotBossRef3, ref movementSpeedCD3, ref rangeAttackStateCD3, ref chaseStateCD3, ref shootMortarStateCD3, ref animationBufferPointer3, ref animationBuffer3, ref legsBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr11, j), InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr12, j));
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
					ref RoamingStateCD roamingStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, k);
					ref RoamingPathCD roamingPathCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingPathCD>(nativeArrayPtr3, k);
					ref MusicAreaCD musicAreaCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr4, k);
					ref RobotBossCD robotBossRef4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RobotBossCD>(nativeArrayPtr5, k);
					ref MovementSpeedCD movementSpeedCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, k);
					ref RangeAttackStateCD rangeAttackStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr7, k);
					ref ChaseStateCD chaseStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ChaseStateCD>(nativeArrayPtr8, k);
					ref ShootMortarProjectileStateCD shootMortarStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr9, k);
					ref AnimationBufferPointer animationBufferPointer4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr10, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					DynamicBuffer<RobotBossLegsBuffer> legsBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref roamingStateCD4, ref roamingPathCD4, ref musicAreaCD4, ref robotBossRef4, ref movementSpeedCD4, ref rangeAttackStateCD4, ref chaseStateCD4, ref shootMortarStateCD4, ref animationBufferPointer4, ref animationBuffer4, ref legsBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnrageStateCD>(nativeArrayPtr11, k), InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr12, k));
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

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RobotBossTrackerCD : IComponentData, IQueryTypeParameter
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct InitializedRobotBossCD : IComponentData, IQueryTypeParameter
	{
	}

	public struct RobotBossLegLocalState : IComponentData, IQueryTypeParameter
	{
		public float prevDistSq;

		public float stepTimer;
	}

	private struct TypeHandle
	{
		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

		public SpawnBossMainBodyJob.InternalCompilerQueryAndHandleData __SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle;

		public HandlePhasesAndEnterWalkingStateJob.InternalCompilerQueryAndHandleData __SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		public ControlRangeAttackPatternsJob.InternalCompilerQueryAndHandleData __SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<RobotBossLegLocalState> __SpiderRobotSystem_RobotBossLegLocalState_RW_ComponentLookup;

		public MoveLegsJob.InternalCompilerQueryAndHandleData __SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		public CheckLegsHealthJob.InternalCompilerQueryAndHandleData __SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
			__SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SpiderRobotSystem_RobotBossLegLocalState_RW_ComponentLookup = state.GetComponentLookup<RobotBossLegLocalState>();
			__SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000D13_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000D13_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000D13_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000D14_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000D14_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000D14_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00000D15_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000D15_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000D15_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnStopRunning_00000D16_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000D16_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000D16_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	private bool _legRefreshRate;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1660812079_0;

	private EntityQuery __query_1660812079_1;

	private EntityQuery __query_1660812079_2;

	private EntityQuery __query_1660812079_3;

	private EntityQuery __query_1660812079_4;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (!__query_1660812079_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_tileAccessor = new TileAccessor(ref state);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1660812079_1.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		_tileAccessor.Update(ref state);
		if (!__query_1660812079_0.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		__query_1660812079_2.TryGetSingleton<NetworkTime>(out var value2);
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		_legRefreshRate = (int)(elapsedTime * 8.0) != (int)((elapsedTime - (double)deltaTime) * 10.0);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new SpawnBossMainBodyJob
		{
			disablePhysicsLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			databaseBankCD = __query_1660812079_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb
		}, __TypeHandle.__SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new HandlePhasesAndEnterWalkingStateJob
		{
			disablePhysicsLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			databaseBankCD = __query_1660812079_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			currentTick = value2.ServerTick,
			time = elapsedTime
		}, __TypeHandle.__SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new ControlRangeAttackPatternsJob
		{
			localTransformLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			databaseBankCD = __query_1660812079_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			time = elapsedTime
		}, __TypeHandle.__SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new MoveLegsJob
		{
			localTransformLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			legLocalLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpiderRobotSystem_RobotBossLegLocalState_RW_ComponentLookup, ref state),
			tileDamageBufferEntity = __query_1660812079_4.GetSingletonEntity(),
			ecb = ecb,
			deltaTime = deltaTime,
			time = elapsedTime,
			updateLegs = _legRefreshRate
		}, __TypeHandle.__SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new CheckLegsHealthJob
		{
			healthGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
			databaseBankCD = __query_1660812079_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			disablePhysicsLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			tileAccessor = _tileAccessor,
			currentTick = value2.ServerTick,
			ecb = ecb,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = deltaTime,
			rng = PugRandom.GetRng()
		}, __TypeHandle.__SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	private static float3 CalculateLegPosition(float3 centerPosition, int legIndex, out RobotBossLegPosition legPosition, bool startAtGroundLevel = false)
	{
		centerPosition.y = 0f;
		float num = 2f;
		float num2 = 2f;
		float y = (startAtGroundLevel ? 0f : (-15f));
		float3 float5;
		switch (legIndex)
		{
		case 0:
			float5 = new float3(0f - num, y, 0f);
			legPosition = RobotBossLegPosition.FrontLeft;
			break;
		case 1:
			float5 = new float3(num, y, 0f);
			legPosition = RobotBossLegPosition.FrontRight;
			break;
		case 2:
			float5 = new float3(num, y, 0f - num2);
			legPosition = RobotBossLegPosition.BackRight;
			break;
		case 3:
			float5 = new float3(0f - num, y, 0f - num2);
			legPosition = RobotBossLegPosition.BackLeft;
			break;
		default:
			float5 = float3.zero;
			legPosition = RobotBossLegPosition.Unknown;
			break;
		}
		return centerPosition + float5;
	}

	public static bool IsLavaWithinRadius(int2 center, int radius, TileAccessor tileAccessor)
	{
		int num = radius * radius;
		for (int i = -radius; i <= radius; i++)
		{
			for (int j = -radius; j <= radius; j++)
			{
				if (i * i + j * j <= num)
				{
					int2 worldPosition = center + new int2(i, j);
					if (tileAccessor.HasTypeAndTileset(worldPosition, TileType.water, 3))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(SpawnBossMainBodyJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SpiderRobotSystem_SpawnBossMainBodyJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(HandlePhasesAndEnterWalkingStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SpiderRobotSystem_HandlePhasesAndEnterWalkingStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(ControlRangeAttackPatternsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SpiderRobotSystem_ControlRangeAttackPatternsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(MoveLegsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SpiderRobotSystem_MoveLegsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(CheckLegsHealthJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SpiderRobotSystem_CheckLegsHealthJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1660812079_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1660812079_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1660812079_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1660812079_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1660812079_4 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000D13_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000D14_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000D15_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000D16_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SpiderRobotSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SpiderRobotSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SpiderRobotSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SpiderRobotSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SpiderRobotSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
