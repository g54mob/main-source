using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugEntitiesUtil;
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
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct CoreBossSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct BreakCrystalMeteorJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BreakCrystalMeteorRPC> __BreakCrystalMeteorRPC_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__BreakCrystalMeteorRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BreakCrystalMeteorRPC>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__BreakCrystalMeteorRPC_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<BreakCrystalMeteorRPC>().Build(ref state);
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
			public void Run(ref BreakCrystalMeteorJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref BreakCrystalMeteorJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref BreakCrystalMeteorJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref BreakCrystalMeteorJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref BreakCrystalMeteorJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref BreakCrystalMeteorJob job, EntityManager entityManager)
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
		public ComponentLookup<CoreBossSpawnCD> coreBossSpawnLookup;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in BreakCrystalMeteorRPC rpc)
		{
			ecb.DestroyEntity(entity);
			if (coreBossSpawnLookup.TryGetComponent(rpc.entity, out var componentData))
			{
				componentData.triggerSpawn = true;
				componentData.introTimeDuration = rpc.introTimeDuration;
				ecb.SetComponent(rpc.entity, componentData);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BreakCrystalMeteorRPC_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BreakCrystalMeteorRPC>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BreakCrystalMeteorRPC>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BreakCrystalMeteorRPC>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BreakCrystalMeteorRPC>(nativeArrayPtr2, k));
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
	private struct SpawnCoreBossJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<CoreBossSpawnCD> __CoreBossSpawnCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<CompanionEntityBuffer> __CompanionEntityBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<CompanionInstantiatedEntityBuffer> __PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__CoreBossSpawnCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnCD>();
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
					__CompanionEntityBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CompanionEntityBuffer>();
					__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CompanionInstantiatedEntityBuffer>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__CoreBossSpawnCD_RW_ComponentTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
					__CompanionEntityBuffer_RW_BufferTypeHandle.Update(ref state);
					__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RW_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CompanionEntityBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CompanionInstantiatedEntityBuffer>();
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
			public void Run(ref SpawnCoreBossJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnCoreBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnCoreBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnCoreBossJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnCoreBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnCoreBossJob job, EntityManager entityManager)
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
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBuffers;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public BufferLookup<CollectedSoulsBuffer> collectedSoulsBuffers;

		[ReadOnly]
		public ComponentLookup<CoreBossCD> coreBossGroup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		public EntityCommandBuffer ecb;

		public WorldInfoCD worldInfo;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public bool coreBossExists;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref CoreBossSpawnCD coreBossSpawnCD, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer, ref DynamicBuffer<CompanionEntityBuffer> companionEntityBuffer, ref DynamicBuffer<CompanionInstantiatedEntityBuffer> companionInstantiatedEntityBuffer, in LocalTransform transform, in DistanceToPlayerCD distanceToPlayerCD)
		{
			if (!summarizedConditionsBuffers.HasBuffer(entity))
			{
				return;
			}
			DynamicBuffer<SummarizedConditionsBuffer> dynamicBuffer = summarizedConditionsBuffers[entity];
			if (worldInfo.coreBossHasBeenKilled || coreBossExists)
			{
				if (disablePhysicsLookup.HasComponent(entity))
				{
					disablePhysicsLookup.SetComponentEnabled(entity, value: true);
				}
				coreBossSpawnCD.state = CoreBossSpawnState.Hidden;
				if (dynamicBuffer[206].value > 0)
				{
					EntityUtility.RemoveCondition(ConditionID.AuraApplyRadioactiveDamageOverTime, conditionsBuffer);
				}
				int num = 0;
				while (num < companionEntityBuffer.Length)
				{
					if (objectDataLookup.TryGetComponent(companionEntityBuffer[num].Value, out var componentData) && componentData.objectID == ObjectID.MapMarker)
					{
						companionEntityBuffer.RemoveAt(num);
					}
					else
					{
						num++;
					}
				}
				int num2 = 0;
				while (num2 < companionInstantiatedEntityBuffer.Length)
				{
					if (objectDataLookup.TryGetComponent(companionInstantiatedEntityBuffer[num2].Value, out var componentData2) && componentData2.objectID == ObjectID.MapMarker)
					{
						ecb.DestroyEntity(companionInstantiatedEntityBuffer[num2].Value);
						companionInstantiatedEntityBuffer.RemoveAt(num2);
					}
					else
					{
						num2++;
					}
				}
				return;
			}
			switch (coreBossSpawnCD.state)
			{
			case CoreBossSpawnState.None:
				if (distanceToPlayerCD.minDistanceSq < coreBossSpawnCD.distanceSqToPlayerToActivate && PlayerHasCollectedAllSouls(distanceToPlayerCD.closestPlayer, collectedSoulsBuffers))
				{
					coreBossSpawnCD.state = CoreBossSpawnState.Activated;
				}
				break;
			case CoreBossSpawnState.Activated:
				if (coreBossSpawnCD.triggerSpawn && PlayerHasCollectedAllSouls(distanceToPlayerCD.closestPlayer, collectedSoulsBuffers))
				{
					coreBossSpawnCD.timer.Start(time, coreBossSpawnCD.spawnTime);
					coreBossSpawnCD.state = CoreBossSpawnState.Spawning;
				}
				break;
			case CoreBossSpawnState.Spawning:
			{
				if (!coreBossSpawnCD.timer.isRunning || !coreBossSpawnCD.timer.IsTimerElapsed(time))
				{
					break;
				}
				coreBossSpawnCD.state = CoreBossSpawnState.Hidden;
				Entity e = EntityUtility.CreateEntity(ecb, transform.Position + new float3(0f, 0f, coreBossSpawnCD.spawnZOffset), ObjectID.CoreBoss, 1, databaseBankCD.databaseBankBlob);
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.CoreBoss, databaseBankCD.databaseBankBlob);
				CoreBossCD component = coreBossGroup[primaryPrefabEntity];
				component.hasObtainedSouls = false;
				component.introTimeDuration = coreBossSpawnCD.introTimeDuration;
				ecb.SetComponent(e, component);
				NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
				if (collisionWorld.SphereCastAll(transform.Position, 15f, float3.zero, 0f, ref outHits, new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u
				}))
				{
					foreach (ColliderCastHit item in outHits)
					{
						if (healthLookup.TryGetComponent(item.Entity, out var componentData3) && objectDataLookup.TryGetComponent(item.Entity, out var componentData4) && componentData4.objectID == ObjectID.CrystalMeteorBoulder)
						{
							componentData3.health = 0;
							ecb.SetComponent(item.Entity, componentData3);
						}
					}
				}
				outHits.Dispose();
				break;
			}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnCD_RW_ComponentTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			BufferAccessor<CompanionEntityBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__CompanionEntityBuffer_RW_BufferTypeHandle);
			BufferAccessor<CompanionInstantiatedEntityBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__PugEntitiesUtil_CompanionInstantiatedEntityBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref CoreBossSpawnCD coreBossSpawnCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnCD>(nativeArrayPtr2, i);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor[i];
					DynamicBuffer<CompanionEntityBuffer> companionEntityBuffer = bufferAccessor2[i];
					DynamicBuffer<CompanionInstantiatedEntityBuffer> companionInstantiatedEntityBuffer = bufferAccessor3[i];
					Execute(entity, ref coreBossSpawnCD, ref conditionsBuffer, ref companionEntityBuffer, ref companionInstantiatedEntityBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, i));
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
						ref CoreBossSpawnCD coreBossSpawnCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<CompanionEntityBuffer> companionEntityBuffer2 = bufferAccessor2[nextRangeBegin];
						DynamicBuffer<CompanionInstantiatedEntityBuffer> companionInstantiatedEntityBuffer2 = bufferAccessor3[nextRangeBegin];
						Execute(entity2, ref coreBossSpawnCD2, ref conditionsBuffer2, ref companionEntityBuffer2, ref companionInstantiatedEntityBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, nextRangeBegin));
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
					ref CoreBossSpawnCD coreBossSpawnCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnCD>(nativeArrayPtr2, j);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor[j];
					DynamicBuffer<CompanionEntityBuffer> companionEntityBuffer3 = bufferAccessor2[j];
					DynamicBuffer<CompanionInstantiatedEntityBuffer> companionInstantiatedEntityBuffer3 = bufferAccessor3[j];
					Execute(entity3, ref coreBossSpawnCD3, ref conditionsBuffer3, ref companionEntityBuffer3, ref companionInstantiatedEntityBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, j));
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
					ref CoreBossSpawnCD coreBossSpawnCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnCD>(nativeArrayPtr2, k);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor[k];
					DynamicBuffer<CompanionEntityBuffer> companionEntityBuffer4 = bufferAccessor2[k];
					DynamicBuffer<CompanionInstantiatedEntityBuffer> companionInstantiatedEntityBuffer4 = bufferAccessor3[k];
					Execute(entity4, ref coreBossSpawnCD4, ref conditionsBuffer4, ref companionEntityBuffer4, ref companionInstantiatedEntityBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, k));
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
	[WithNone(new Type[]
	{
		typeof(InitializedCoreBossCD),
		typeof(EntityDestroyedCD)
	})]
	private struct InitializeCoreBossJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<CoreBossCD> __CoreBossCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<VulnerableStateCD> __VulnerableStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<ConditionsBuffer> __ConditionsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__CoreBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__VulnerableStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<VulnerableStateCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
					__ConditionsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ConditionsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__CoreBossCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__VulnerableStateCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__HealthCD_RO_ComponentTypeHandle.Update(ref state);
					__ConditionsBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<InitializedCoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<VulnerableStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ConditionsBuffer>();
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
			public void Run(ref InitializeCoreBossJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref InitializeCoreBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref InitializeCoreBossJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref InitializeCoreBossJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref InitializeCoreBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref InitializeCoreBossJob job, EntityManager entityManager)
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
		public ComponentLookup<InitializedCoreBossCD> initializedCoreBossLookup;

		[ReadOnly]
		public ComponentLookup<CoreBossOrbCD> coreBossOrbGroup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref CoreBossCD coreBossCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref VulnerableStateCD vulnerableState, in LocalTransform transform, in HealthCD healthCD, ref DynamicBuffer<ConditionsBuffer> conditionsBuffer)
		{
			EntityUtility.RemoveCondition(ConditionID.AuraApplyVoidDamagePercentageOverTime, conditionsBuffer);
			if (!coreBossCD.hasObtainedSouls)
			{
				float num = 9f;
				if (coreBossCD.obtainSoulOrbsState == 0)
				{
					vulnerableState.cooldownTimer.Start(time, coreBossCD.introTimeDuration + 5f);
					coreBossCD.obtainSoulOrbsState = 1;
					coreBossCD.obtainSoulOrbsTimer.Start(time, num);
				}
				else if (coreBossCD.obtainSoulOrbsState == 1 && coreBossCD.obtainSoulOrbsTimer.isRunning && coreBossCD.obtainSoulOrbsTimer.IsTimerElapsed(time))
				{
					coreBossCD.obtainSoulOrbsState = 2;
					AnimationUtilities.TriggerAnimation(-643905814, currentTick, animationBuffer, ref animationBufferPointer);
					coreBossCD.obtainSoulOrbsTimer.Start(time, coreBossCD.introTimeDuration - num);
				}
				else if (coreBossCD.obtainSoulOrbsState == 2 && coreBossCD.obtainSoulOrbsTimer.isRunning && coreBossCD.obtainSoulOrbsTimer.IsTimerElapsed(time))
				{
					AnimationUtilities.TriggerAnimation(-174538030, currentTick, animationBuffer, ref animationBufferPointer);
					coreBossCD.obtainSoulOrbsState = 3;
					coreBossCD.obtainSoulOrbsTimer.Start(time, 1.2f);
				}
				else if (coreBossCD.obtainSoulOrbsState == 3 && coreBossCD.obtainSoulOrbsTimer.isRunning && coreBossCD.obtainSoulOrbsTimer.IsTimerElapsed(time))
				{
					coreBossCD.hasObtainedSouls = true;
				}
			}
			if (coreBossCD.hasObtainedSouls && !initializedCoreBossLookup.HasComponent(entity))
			{
				int value = (int)math.round((float)healthCD.maxHealth * 0.3f);
				EntityUtility.AddNewCondition(entity, ecb, new ConditionData
				{
					conditionID = ConditionID.ProtectiveArmor,
					duration = float.PositiveInfinity,
					value = value
				});
				DynamicBuffer<CoreBossOrbsBuffer> dynamicBuffer = ecb.SetBuffer<CoreBossOrbsBuffer>(entity);
				dynamicBuffer.Clear();
				float num2 = 0f;
				float num3 = 360f / (float)coreBossCD.orbCount;
				float num4 = coreBossCD.orbMaxDistance - coreBossCD.orbMinDistance;
				for (int i = 0; i < coreBossCD.orbCount; i++)
				{
					float num5 = (float)((double)num4 / 2.0 * math.sin(time) + (double)num4 + (double)coreBossCD.orbMinDistance);
					float3 float5 = math.mul(quaternion.RotateY(math.radians(num2 + coreBossCD.orbRotation)), MathUtilities.Float3.forward);
					float5 *= num5;
					float3 position = transform.Position + float5;
					Entity entity2 = EntityUtility.CreateEntity(ecb, position, ObjectID.CoreBossOrb, 1, databaseBankCD.databaseBankBlob);
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.CoreBossOrb, databaseBankCD.databaseBankBlob);
					CoreBossOrbCD component = coreBossOrbGroup[primaryPrefabEntity];
					component.boss = entity;
					ecb.SetComponent(entity2, component);
					ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity2);
					dynamicBuffer.Add(new CoreBossOrbsBuffer
					{
						orb = entity2
					});
					num2 += num3;
				}
				ecb.AddComponent<InitializedCoreBossCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__VulnerableStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle);
			BufferAccessor<ConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__ConditionsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref CoreBossCD coreBossCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					ref AnimationBufferPointer animationBufferPointer = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, i);
					ref VulnerableStateCD vulnerableState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr4, i);
					ref LocalTransform transform = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i);
					ref HealthCD healthCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, i);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer = bufferAccessor2[i];
					Execute(entity, ref coreBossCD, ref animationBuffer, ref animationBufferPointer, ref vulnerableState, in transform, in healthCD, ref conditionsBuffer);
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
						ref CoreBossCD coreBossCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						ref AnimationBufferPointer animationBufferPointer2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, nextRangeBegin);
						ref VulnerableStateCD vulnerableState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr4, nextRangeBegin);
						ref LocalTransform transform2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin);
						ref HealthCD healthCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, nextRangeBegin);
						DynamicBuffer<ConditionsBuffer> conditionsBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref coreBossCD2, ref animationBuffer2, ref animationBufferPointer2, ref vulnerableState2, in transform2, in healthCD2, ref conditionsBuffer2);
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
					ref CoreBossCD coreBossCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					ref AnimationBufferPointer animationBufferPointer3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, j);
					ref VulnerableStateCD vulnerableState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr4, j);
					ref LocalTransform transform3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j);
					ref HealthCD healthCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, j);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref coreBossCD3, ref animationBuffer3, ref animationBufferPointer3, ref vulnerableState3, in transform3, in healthCD3, ref conditionsBuffer3);
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
					ref CoreBossCD coreBossCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					ref AnimationBufferPointer animationBufferPointer4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, k);
					ref VulnerableStateCD vulnerableState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr4, k);
					ref LocalTransform transform4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k);
					ref HealthCD healthCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr6, k);
					DynamicBuffer<ConditionsBuffer> conditionsBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref coreBossCD4, ref animationBuffer4, ref animationBufferPointer4, ref vulnerableState4, in transform4, in healthCD4, ref conditionsBuffer4);
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
	private struct CoreBossOrbJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<CoreBossCD> __CoreBossCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<CoreBossOrbsBuffer> __CoreBossOrbsBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<VulnerableStateCD> __VulnerableStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<IsInCombatCD> __IsInCombatCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__CoreBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossCD>();
					__CoreBossOrbsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossOrbsBuffer>();
					__VulnerableStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<VulnerableStateCD>();
					__IsInCombatCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<IsInCombatCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__CoreBossCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossOrbsBuffer_RW_BufferTypeHandle.Update(ref state);
					__VulnerableStateCD_RW_ComponentTypeHandle.Update(ref state);
					__IsInCombatCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<IsInCombatCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossOrbsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<VulnerableStateCD>();
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
			public void Run(ref CoreBossOrbJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CoreBossOrbJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CoreBossOrbJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CoreBossOrbJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CoreBossOrbJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CoreBossOrbJob job, EntityManager entityManager)
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
		public ComponentLookup<HealthCD> healthGroup;

		[ReadOnly]
		public ComponentLookup<RangeAttackStateCD> rangeAttackStateLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> transformGroup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsGroup;

		[ReadOnly]
		public ComponentLookup<DontDestroyOnZeroHealthCD> dontDestroyOnZeroHealthLookup;

		public EntityCommandBuffer ecb;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref CoreBossCD coreBossCD, ref DynamicBuffer<CoreBossOrbsBuffer> coreBossOrbsBuffer, ref VulnerableStateCD vulnerableStateCD, in IsInCombatCD isInCombatCD, in LocalTransform transform, in StateInfoCD stateInfo)
		{
			if (!coreBossCD.hasObtainedSouls)
			{
				return;
			}
			if (entityDestroyedLookup.HasAndIsComponentEnabled(entity))
			{
				if (coreBossOrbsBuffer.Length <= 0)
				{
					return;
				}
				for (int i = 0; i < coreBossOrbsBuffer.Length; i++)
				{
					Entity orb = coreBossOrbsBuffer[i].orb;
					if (dontDestroyOnZeroHealthLookup.HasComponent(orb))
					{
						ecb.SetComponent(orb, new DontDestroyOnZeroHealthCD
						{
							disabled = true
						});
					}
				}
				coreBossOrbsBuffer.Clear();
				return;
			}
			int length = coreBossOrbsBuffer.Length;
			float num = 0f;
			float num2 = 360f / (float)length;
			float num3 = coreBossCD.orbMaxDistance - coreBossCD.orbMinDistance;
			float num4 = (float)((double)num3 / 2.0 * math.sin(time) + (double)num3 + (double)coreBossCD.orbMinDistance);
			bool flag = true;
			for (int j = 0; j < length; j++)
			{
				Entity orb2 = coreBossOrbsBuffer[j].orb;
				if (healthGroup.TryGetComponent(orb2, out var componentData) && componentData.health > 0)
				{
					flag = false;
					break;
				}
			}
			if (flag && !stateInfo.IsCurrentState(StateID.Vulnerable) && !stateInfo.IsCurrentState(StateID.PhaseTransition))
			{
				if (!coreBossCD.resetOrbsHealthTimer.isRunning)
				{
					coreBossCD.resetOrbsHealthTimer.Start(time, 0.5f);
				}
				if (coreBossCD.resetOrbsHealthTimer.isRunning && coreBossCD.resetOrbsHealthTimer.IsTimerElapsed(time))
				{
					for (int k = 0; k < length; k++)
					{
						Entity orb3 = coreBossOrbsBuffer[k].orb;
						if (healthGroup.TryGetComponent(orb3, out var componentData2) && componentData2.health < componentData2.maxHealth)
						{
							componentData2.health = componentData2.maxHealth;
							ecb.SetComponent(orb3, componentData2);
							coreBossCD.reviveOrbMovementCooldownTimer.Start(time, 2f);
						}
					}
				}
			}
			else if (coreBossCD.resetOrbsHealthTimer.isRunning)
			{
				coreBossCD.resetOrbsHealthTimer.Stop();
			}
			bool flag2 = !stateInfo.IsCurrentState(StateID.PhaseTransition);
			for (int l = 0; l < coreBossOrbsBuffer.Length; l++)
			{
				Entity orb4 = coreBossOrbsBuffer[l].orb;
				if (rangeAttackStateLookup.TryGetComponent(orb4, out var componentData3) && healthGroup.TryGetComponent(orb4, out var componentData4))
				{
					bool flag3 = componentData4.health > 0 || !flag2;
					if (componentData3.isDisabled != flag3)
					{
						componentData3.isDisabled = flag3;
						ecb.SetComponent(orb4, componentData3);
					}
				}
			}
			if (vulnerableStateCD.isVulnerable)
			{
				return;
			}
			int num5 = 0;
			int num6 = 0;
			coreBossCD.orbsAlive = 0;
			for (int m = 0; m < length; m++)
			{
				Entity orb5 = coreBossOrbsBuffer[m].orb;
				HealthCD componentData5;
				bool flag4 = healthGroup.TryGetComponent(orb5, out componentData5);
				num6 += componentData5.maxHealth;
				if (transformGroup.TryGetComponent(orb5, out var componentData6) && flag4 && componentData5.health > 0)
				{
					num5 += componentData5.health;
					coreBossCD.orbsAlive++;
					if (!coreBossCD.reviveOrbMovementCooldownTimer.isRunning || coreBossCD.reviveOrbMovementCooldownTimer.IsTimerElapsed(time))
					{
						float3 float5 = math.mul(quaternion.RotateY(math.radians(num + coreBossCD.orbRotation)), MathUtilities.Float3.forward);
						float5 *= num4;
						float3 x = transform.Position + float5 - componentData6.Position;
						float3 float6 = math.normalizesafe(x, float3.zero);
						ecb.SetComponent(orb5, LocalTransform.FromPosition(componentData6.Position + float6 * deltaTime * math.min(4f, math.length(x))));
					}
				}
				num += num2;
			}
			if (!stateInfo.IsCurrentState(StateID.Vulnerable) && summarizedConditionsGroup.TryGetBuffer(entity, out var bufferData))
			{
				int num7 = (int)math.round((float)healthGroup[entity].maxHealth * 0.3f);
				int value = bufferData[98].value;
				int num8 = (int)math.round((float)num7 * ((float)num5 / (float)math.max(1, num6)));
				if (value != num8)
				{
					EntityUtility.AddNewCondition(entity, ecb, new ConditionData
					{
						conditionID = ConditionID.ProtectiveArmor,
						duration = float.PositiveInfinity,
						value = num8
					});
				}
			}
			if (num5 > 0 && (!coreBossCD.reviveOrbMovementCooldownTimer.isRunning || coreBossCD.reviveOrbMovementCooldownTimer.IsTimerElapsed(time)))
			{
				float num9 = 1f + (float)coreBossCD.phase / 2f;
				coreBossCD.orbRotation += coreBossCD.orbRotationSpeed * deltaTime * num9;
				coreBossCD.orbRotation %= 360f;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossCD_RW_ComponentTypeHandle);
			BufferAccessor<CoreBossOrbsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossOrbsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__VulnerableStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__IsInCombatCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref CoreBossCD coreBossCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, i);
					DynamicBuffer<CoreBossOrbsBuffer> coreBossOrbsBuffer = bufferAccessor[i];
					Execute(entity, ref coreBossCD, ref coreBossOrbsBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, i));
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
						ref CoreBossCD coreBossCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<CoreBossOrbsBuffer> coreBossOrbsBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref coreBossCD2, ref coreBossOrbsBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref CoreBossCD coreBossCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, j);
					DynamicBuffer<CoreBossOrbsBuffer> coreBossOrbsBuffer3 = bufferAccessor[j];
					Execute(entity3, ref coreBossCD3, ref coreBossOrbsBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, j));
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
					ref CoreBossCD coreBossCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, k);
					DynamicBuffer<CoreBossOrbsBuffer> coreBossOrbsBuffer4 = bufferAccessor[k];
					Execute(entity4, ref coreBossCD4, ref coreBossOrbsBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<IsInCombatCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr6, k));
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
		typeof(InitializedCoreBossCD),
		typeof(PhaseTransitionStateCD),
		typeof(HealthCD)
	})]
	private struct CoreBossPhaseAndAttacksJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<RangeAttackStateCD> __RangeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossCD> __CoreBossCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnVoidStateCD> __CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnBeamsStateCD> __CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MusicAreaCD> __MusicAreaCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<VulnerableStateCD> __VulnerableStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__RangeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RangeAttackStateCD>();
					__CoreBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossCD>();
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnVoidStateCD>();
					__CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnBeamsStateCD>();
					__MusicAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MusicAreaCD>();
					__VulnerableStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<VulnerableStateCD>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__RangeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle.Update(ref state);
					__MusicAreaCD_RW_ComponentTypeHandle.Update(ref state);
					__VulnerableStateCD_RW_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedCoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhaseTransitionStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RangeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnVoidStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnBeamsStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MusicAreaCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<VulnerableStateCD>();
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
			public void Run(ref CoreBossPhaseAndAttacksJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CoreBossPhaseAndAttacksJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CoreBossPhaseAndAttacksJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CoreBossPhaseAndAttacksJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CoreBossPhaseAndAttacksJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CoreBossPhaseAndAttacksJob job, EntityManager entityManager)
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
		public ComponentLookup<HealthCD> healthLookup;

		[ReadOnly]
		public ComponentLookup<ManuallyTriggerDestroyNearbyEntitiesCD> manuallyTriggerDestroyNearbyEntitiesLookup;

		[ReadOnly]
		public ComponentLookup<PhaseTransitionStateCD> phaseTransitionLookup;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref RangeAttackStateCD rangeState, ref CoreBossCD coreBossCD, ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD, ref CoreBossSpawnBeamsStateCD coreBossSpawnBeamStateCD, ref MusicAreaCD music, ref VulnerableStateCD vulnerableState, in StateInfoCD stateInfoCD)
		{
			if (!coreBossCD.hasObtainedSouls)
			{
				return;
			}
			HealthCD healthCD = healthLookup[entity];
			if (healthCD.health > healthCD.maxHealth * 3 / 4)
			{
				coreBossCD.phase = CoreBossPhase.First;
			}
			else if (healthCD.health > healthCD.maxHealth * 2 / 4)
			{
				coreBossCD.phase = CoreBossPhase.Second;
			}
			else if (healthCD.health > healthCD.maxHealth / 4)
			{
				coreBossCD.phase = CoreBossPhase.Third;
			}
			else
			{
				coreBossCD.phase = CoreBossPhase.Fourth;
			}
			if (coreBossCD.currentState != stateInfoCD.currentState)
			{
				coreBossCD.previousState = coreBossCD.currentState;
				coreBossCD.currentState = stateInfoCD.currentState;
			}
			if (!rangeState.isDisabled && coreBossCD.previousState == StateID.RangeAttack)
			{
				coreBossCD.lastAttackTime = time;
				coreBossCD.lastRangeAttackTime = time;
				rangeState.isDisabled = true;
				if (rangeState.projectileID == ObjectID.CoreBossWhirlwindProjectile)
				{
					coreBossCD.lastWhirlwindRangeAttackTime = time;
				}
				if (rangeState.projectileID == ObjectID.CoreBossScarabProjectile)
				{
					coreBossCD.lastHomingTriangleRangeAttackTime = time;
				}
			}
			if (!coreBossSpawnBeamStateCD.isDisabled && coreBossCD.previousState == StateID.CoreBossSpawnBeams)
			{
				coreBossCD.lastAttackTime = time;
				coreBossCD.lastBeamAttackTime = time;
				coreBossSpawnBeamStateCD.isDisabled = true;
			}
			if (!coreBossSpawnVoidStateCD.isDisabled && coreBossCD.previousState == StateID.CoreBossSpawnVoid)
			{
				coreBossCD.lastAttackTime = time;
				coreBossCD.lastVoidZoneAttackTime = time;
				coreBossSpawnVoidStateCD.isDisabled = true;
			}
			if (coreBossCD.phase < CoreBossPhase.Third)
			{
				coreBossSpawnVoidStateCD.isDisabled = true;
			}
			float num = 1f;
			double num2 = time - coreBossCD.lastVoidZoneAttackTime;
			double num3 = time - coreBossCD.lastWhirlwindRangeAttackTime;
			double num4 = time - coreBossCD.lastAttackTime;
			if (coreBossSpawnVoidStateCD.isDisabled && coreBossSpawnBeamStateCD.isDisabled && rangeState.isDisabled && (coreBossCD.lastAttackTime == 0.0 || num4 > (double)(3f / num)))
			{
				if (coreBossCD.phase >= CoreBossPhase.Third && num2 > 30.0)
				{
					coreBossSpawnVoidStateCD.isDisabled = false;
				}
				else
				{
					if ((coreBossCD.attackCounter + 1) % 4 == 0)
					{
						if (coreBossCD.phase >= CoreBossPhase.Second && num3 > 20.0)
						{
							rangeState.projectileID = ObjectID.CoreBossWhirlwindProjectile;
							rangeState.anticipationDuration = 1.2f;
							rangeState.endDuration = 0.5f;
							rangeState.attackDuration = 3f;
							rangeState.minDistanceFromTargetToAllowAttack = 0f;
							rangeState.maxDistanceFromTargetToAllowAttack = 0f;
							rangeState.timeBetweenShots = 0.2f;
							rangeState.speedMultiplier = 0.9f;
							float num5 = rangeState.attackDuration / rangeState.timeBetweenShots;
							rangeState.spreadAngle = 360f / num5;
							rangeState.spreadType = ProjectileSpreadType.Spiral;
							rangeState.projectileFollowsTarget = false;
							rangeState.skipVisibilityCheck = false;
							rangeState.shootNewRandomTargetsPerProjectile = false;
							rangeState.rangeDamage = coreBossCD.whirlwindProjectileDamage;
							rangeState.spawnOffset = new float3(0f, 0f, -1f);
							rangeState.spawnAtDistanceInfront = 8f;
							rangeState.spawnAtDistanceInfrontDeviation = 4f;
							rangeState.isDisabled = false;
						}
						else
						{
							rangeState.projectileID = ObjectID.CoreBossScarabProjectile;
							rangeState.anticipationDuration = 1.2f;
							rangeState.endDuration = 2f;
							rangeState.attackDuration = 3f;
							rangeState.minDistanceFromTargetToAllowAttack = 1f;
							rangeState.maxDistanceFromTargetToAllowAttack = 30f;
							rangeState.timeBetweenShots = 1f;
							rangeState.speedMultiplier = 1f;
							rangeState.spreadAngle = 0f;
							rangeState.spreadType = ProjectileSpreadType.None;
							rangeState.projectileFollowsTarget = true;
							rangeState.skipVisibilityCheck = true;
							rangeState.shootNewRandomTargetsPerProjectile = true;
							rangeState.rangeDamage = coreBossCD.homingTriangleProjectileDamage;
							rangeState.spawnOffset = new float3(0f, 0f, -1f);
							rangeState.spawnAtDistanceInfront = 0f;
							rangeState.spawnAtDistanceInfrontDeviation = 0f;
							rangeState.isDisabled = false;
						}
					}
					else
					{
						coreBossSpawnBeamStateCD.isDisabled = false;
					}
					coreBossCD.attackCounter++;
				}
			}
			if (stateInfoCD.IsCurrentState(StateID.PhaseTransition) || stateInfoCD.IsCurrentState(StateID.Vulnerable))
			{
				vulnerableState.cooldownTimer.Start(time, 1f);
			}
			bool flag = stateInfoCD.IsCurrentState(StateID.PhaseTransition);
			if (!coreBossCD.wasInPhaseTransitionPrevFrame && flag && !manuallyTriggerDestroyNearbyEntitiesLookup.HasComponent(entity))
			{
				ecb.AddComponent<ManuallyTriggerDestroyNearbyEntitiesCD>(entity);
			}
			coreBossCD.wasInPhaseTransitionPrevFrame = flag;
			music.musicRosterType = ((stateInfoCD.IsCurrentState(StateID.PhaseTransition) || healthCD.health <= 0) ? MusicRosterType.DONT_PLAY_MUSIC : ((phaseTransitionLookup[entity].currentPhase == 0) ? MusicRosterType.CORE_COMMANDER_PHASE1 : MusicRosterType.CORE_COMMANDER_PHASE2));
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RangeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MusicAreaCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__VulnerableStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr8, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr5, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr8, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr8, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RangeAttackStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<VulnerableStateCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr8, k));
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
	[WithAny(new Type[]
	{
		typeof(CoreBossOrbCD),
		typeof(CoreBossCD)
	})]
	private struct DestroyTilesWithinRadiusJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<CoreBossOrbCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAny<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
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
			public void Run(ref DestroyTilesWithinRadiusJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DestroyTilesWithinRadiusJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DestroyTilesWithinRadiusJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DestroyTilesWithinRadiusJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DestroyTilesWithinRadiusJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DestroyTilesWithinRadiusJob job, EntityManager entityManager)
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
		public ComponentLookup<CoreBossCD> coreBossLookup;

		public EntityCommandBuffer ecb;

		public Entity tileDamageBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform)
		{
			HydraBossSystem.DestroyTilesWithinRadius(coreBossLookup.HasComponent(entity) ? 2.5f : 1.5f, transform.Position, ecb, tileDamageBufferEntity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k));
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
	[WithAny(new Type[] { typeof(CoreBossCD) })]
	private struct SpawnVoidJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnVoidStateCD> __CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<CoreBossVoidImmuneZoneBuffer> __CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnVoidStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossVoidImmuneZoneBuffer>(isReadOnly: true);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CoreBossVoidImmuneZoneBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnVoidStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
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
			public void Run(ref SpawnVoidJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnVoidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnVoidJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnVoidJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnVoidJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnVoidJob job, EntityManager entityManager)
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
		public ComponentLookup<AuraDistanceOverrideCD> auraDistanceOverrideLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public NetworkTick currentTick;

		public uint tickRate;

		public EntityCommandBuffer ecb;

		public double time;

		public Unity.Mathematics.Random rng;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfoCD, ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in DynamicBuffer<CoreBossVoidImmuneZoneBuffer> immunityZones, in DynamicBuffer<SummarizedConditionsBuffer> conditions)
		{
			for (int i = 0; i < immunityZones.Length; i++)
			{
				Entity zone = immunityZones[i].zone;
				if (auraDistanceOverrideLookup.TryGetComponent(zone, out var componentData) && destroyTimerLookup.TryGetComponent(zone, out var componentData2))
				{
					float elapsedSeconds = componentData2.timer.GetElapsedSeconds(currentTick, tickRate);
					float num = (float)componentData2.timer.targetTicks / (float)tickRate;
					float num2 = num / 2f;
					float num3 = 0.3f;
					if (elapsedSeconds < num * num3)
					{
						float x = math.clamp(elapsedSeconds / (num * num3), 0f, 1f);
						x = math.smoothstep(0f, 1f, x);
						componentData.distance = math.lerp(10f, 4f, x);
					}
					else if (elapsedSeconds > num2)
					{
						float t = math.clamp((elapsedSeconds - num2) / num2, 0f, 1f);
						componentData.distance = math.lerp(4f, 2f, t);
					}
					else
					{
						componentData.distance = 4f;
					}
					ecb.SetComponent(zone, componentData);
				}
			}
			if (!stateInfoCD.IsCurrentState(StateID.CoreBossSpawnVoid))
			{
				if (conditions[248].value < 0 && (stateInfoCD.IsCurrentState(StateID.Death) || stateInfoCD.IsCurrentState(StateID.Vulnerable)))
				{
					EntityUtility.RemoveCondition(entity, ecb, ConditionID.AuraApplyVoidDamagePercentageOverTime);
				}
				return;
			}
			coreBossSpawnVoidStateCD.cooldownTimer.Start(time, rng.NextFloat(coreBossSpawnVoidStateCD.minCooldown, coreBossSpawnVoidStateCD.maxCooldown));
			if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.None)
			{
				AnimationUtilities.TriggerAnimation(-621508332, currentTick, animationBuffer, ref animationBufferPointer);
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.Anticipating;
				coreBossSpawnVoidStateCD.timer.Start(time, coreBossSpawnVoidStateCD.durationUntilSpawn);
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.Anticipating && coreBossSpawnVoidStateCD.timer.IsTimerElapsed(time))
			{
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.Spawning;
				coreBossSpawnVoidStateCD.timer.Start(time, coreBossSpawnVoidStateCD.durationAfterSpawn);
				float3 position = localTransformLookup[entity].Position;
				float3 x2 = rng.NextFloat3(-1f, 1f);
				x2.y = 0f;
				x2 = math.normalizesafe(x2, new float3(1f, 0f, 0f));
				DynamicBuffer<CoreBossVoidImmuneZoneBuffer> dynamicBuffer = ecb.SetBuffer<CoreBossVoidImmuneZoneBuffer>(entity);
				dynamicBuffer.Clear();
				for (int j = 0; j < 360; j += 120)
				{
					float3 float5 = math.mul(quaternion.AxisAngle(MathUtilities.Float3.up, math.radians(j)), x2);
					float3 position2 = position + float5 * rng.NextFloat(8f, 12f);
					Entity prefabEntity;
					Entity entity2 = EntityUtility.CreateEntity(ecb, position2, ObjectID.CoreBossVoidImmuneZone, 1, databaseBankCD.databaseBankBlob, out prefabEntity);
					ecb.SetComponent(entity2, new OwnerReferenceCD
					{
						owner = entity
					});
					dynamicBuffer.Add(new CoreBossVoidImmuneZoneBuffer
					{
						zone = entity2
					});
					DestroyTimerCD component = destroyTimerLookup[prefabEntity];
					component.timer.SetTargetTicks(coreBossSpawnVoidStateCD.duration, tickRate);
					ecb.SetComponent(entity2, component);
				}
				EntityUtility.AddNewCondition(entity, ecb, new ConditionData
				{
					conditionID = ConditionID.AuraApplyVoidDamagePercentageOverTime,
					duration = coreBossSpawnVoidStateCD.duration,
					value = -20
				});
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.Spawning && coreBossSpawnVoidStateCD.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(-601574123, currentTick, animationBuffer, ref animationBufferPointer);
				coreBossSpawnVoidStateCD.internalState = CoreBossSpawnVoidInternalState.Ending;
			}
			else if (coreBossSpawnVoidStateCD.internalState == CoreBossSpawnVoidInternalState.Ending)
			{
				stateInfoCD.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnVoidStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			BufferAccessor<CoreBossVoidImmuneZoneBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossVoidImmuneZoneBuffer_RO_BufferTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref StateInfoCD stateInfoCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i);
					ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref stateInfoCD, ref coreBossSpawnVoidStateCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), bufferAccessor2[i], bufferAccessor3[i]);
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
						ref StateInfoCD stateInfoCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin);
						ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref stateInfoCD2, ref coreBossSpawnVoidStateCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), bufferAccessor2[nextRangeBegin], bufferAccessor3[nextRangeBegin]);
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
					ref StateInfoCD stateInfoCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j);
					ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref stateInfoCD3, ref coreBossSpawnVoidStateCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), bufferAccessor2[j], bufferAccessor3[j]);
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
					ref StateInfoCD stateInfoCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k);
					ref CoreBossSpawnVoidStateCD coreBossSpawnVoidStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnVoidStateCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref stateInfoCD4, ref coreBossSpawnVoidStateCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), bufferAccessor2[k], bufferAccessor3[k]);
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
	private struct SpawnBirdBossBeamsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<CoreBossSpawnBeamsStateCD> __CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<AttackedNearbyEntitiesBufferCD> __AttackedNearbyEntitiesBufferCD_RW_BufferTypeHandle;

				public ComponentTypeHandle<CoreBossCD> __CoreBossCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<CoreBossBeamMovementInstructionBuffer> __CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<BeamQueueBuffer> __BeamQueueBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossSpawnBeamsStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AttackedNearbyEntitiesBufferCD_RW_BufferTypeHandle = state.GetBufferTypeHandle<AttackedNearbyEntitiesBufferCD>();
					__CoreBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossCD>();
					__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossBeamMovementInstructionBuffer>();
					__BeamQueueBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<BeamQueueBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AttackedNearbyEntitiesBufferCD_RW_BufferTypeHandle.Update(ref state);
					__CoreBossCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle.Update(ref state);
					__BeamQueueBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossSpawnBeamsStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AttackedNearbyEntitiesBufferCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossBeamMovementInstructionBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BeamQueueBuffer>();
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
			public void Run(ref SpawnBirdBossBeamsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnBirdBossBeamsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnBirdBossBeamsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnBirdBossBeamsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnBirdBossBeamsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnBirdBossBeamsJob job, EntityManager entityManager)
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
		public BufferLookup<NearbyEntitiesBufferCD> nearbyEntitiesBufferGroup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferGroup;

		[ReadOnly]
		public BufferLookup<CoreBossVoidImmuneZoneBuffer> coreBossVoidImmuneZoneBufferGroup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> transformGroup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedGroup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		public NetworkTick currentTick;

		public double time;

		public Unity.Mathematics.Random rng;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfoCD, ref CoreBossSpawnBeamsStateCD coreBossSpawnBeamsStateCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref DynamicBuffer<AttackedNearbyEntitiesBufferCD> attackedNearbyEntitiesBuffer, ref CoreBossCD coreBoss, ref DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer, ref DynamicBuffer<BeamQueueBuffer> beamQueueBuffer)
		{
			if (!summarizedConditionsBufferGroup.TryGetBuffer(entity, out var bufferData) || !coreBossVoidImmuneZoneBufferGroup.TryGetBuffer(entity, out var bufferData2) || !nearbyEntitiesBufferGroup.TryGetBuffer(entity, out var bufferData3) || !stateInfoCD.IsCurrentState(StateID.CoreBossSpawnBeams))
			{
				return;
			}
			coreBossSpawnBeamsStateCD.cooldownTimer.Start(time, rng.NextFloat(coreBossSpawnBeamsStateCD.minCooldown, coreBossSpawnBeamsStateCD.maxCooldown));
			ref AnimationBufferPointer valueRW = ref animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			if (coreBossSpawnBeamsStateCD.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(1494526215, currentTick, animationBuffer, ref valueRW);
				coreBossSpawnBeamsStateCD.internalState = 1;
				coreBossSpawnBeamsStateCD.timer.Start(time, coreBossSpawnBeamsStateCD.durationUntilBeamSpawn);
			}
			else if (coreBossSpawnBeamsStateCD.internalState == 1 && coreBossSpawnBeamsStateCD.timer.IsTimerElapsed(time))
			{
				float num = 4f * ((coreBoss.phase >= CoreBossPhase.Second) ? 1.5f : ((coreBoss.phase >= CoreBossPhase.Fourth) ? 2f : 1f));
				float num2 = num / 2f;
				bool flag = bufferData[248].value < 0 && bufferData2.Length > 0;
				int num3 = (int)math.round(rng.NextFloat(3f));
				bool flag2 = coreBossSpawnBeamsStateCD.attackType == 3;
				int num4 = ((!flag2) ? 1 : bufferData3.Length);
				int num5 = (flag ? bufferData2.Length : num4);
				attackedNearbyEntitiesBuffer.Clear();
				for (int i = 0; i < num5; i++)
				{
					float3 position = transformGroup[entity].Position;
					if (flag)
					{
						if (flag2)
						{
							coreBossSpawnBeamsStateCD.attackType = (coreBossSpawnBeamsStateCD.attackType + 1) % 4;
						}
						int index = (num3 + i) % bufferData2.Length;
						if (!transformGroup.HasComponent(bufferData2[index].zone))
						{
							continue;
						}
						position = transformGroup[bufferData2[index].zone].Position;
					}
					else
					{
						if (bufferData3.Length == 0)
						{
							continue;
						}
						int index2 = (flag2 ? i : rng.NextInt(0, bufferData3.Length));
						Entity entity2 = bufferData3[index2].entity;
						if (playerGhostExtrapolatedGroup.HasComponent(entity2))
						{
							entity2 = playerGhostExtrapolatedGroup[entity2].playerGhost;
						}
						bool flag3 = false;
						for (int j = 0; j < attackedNearbyEntitiesBuffer.Length; j++)
						{
							flag3 = attackedNearbyEntitiesBuffer[j].entity == entity2;
							if (flag3)
							{
								break;
							}
						}
						if (flag3)
						{
							continue;
						}
						attackedNearbyEntitiesBuffer.Add(new AttackedNearbyEntitiesBufferCD
						{
							entity = entity2
						});
						position = transformGroup[entity2].Position;
					}
					switch (coreBossSpawnBeamsStateCD.attackType)
					{
					case 0:
					{
						float3 x3 = rng.NextFloat3(-1f, 1f);
						x3.y = 0f;
						x3 = math.normalizesafe(x3, new float3(1f, 0f, 0f));
						int num15 = 20;
						for (int m = 0; m < 360; m += 360 / num15)
						{
							if (m < 0 || m > 45)
							{
								int beamId3 = ++coreBoss.beamIdCounter;
								float3 float11 = math.mul(quaternion.AxisAngle(MathUtilities.Float3.up, math.radians(m)), x3);
								float3 float12 = position + float11 * 5f;
								float num16 = math.distance(float12, position);
								coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
								{
									beamId = beamId3,
									duration = 2f,
									speed = num,
									target = position,
									rotationAroundTargetSign = 1
								});
								coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
								{
									beamId = beamId3,
									duration = 0.5f,
									target = position
								});
								coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
								{
									beamId = beamId3,
									duration = num16 / num,
									speed = num,
									target = position,
									forwardMovementSign = 1
								});
								beamQueueBuffer.Add(new BeamQueueBuffer
								{
									beamId = beamId3,
									spawnPos = float12
								});
							}
						}
						break;
					}
					case 1:
					{
						int2 int5 = position.RoundToInt2();
						int num17 = 4;
						int num18 = 2;
						int num19 = 4;
						int num20 = rng.NextInt(-num19 + 1, num19 - num18);
						for (int n = 1; n <= 2; n++)
						{
							for (int num21 = -num19; num21 <= num19; num21++)
							{
								if (num21 < num20 || num21 >= num20 + num18)
								{
									int beamId4 = ++coreBoss.beamIdCounter;
									int num22 = ((n != 1) ? 1 : (-1));
									float3 float13 = new float3(int5.x + num21, 0f, int5.y + num22 * num17);
									float3 float14 = float13 + new float3(0f, 0f, num17 * -num22);
									float num23 = math.distance(float13, float14);
									coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
									{
										beamId = beamId4,
										duration = 0.5f,
										target = position
									});
									coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
									{
										beamId = beamId4,
										duration = num23 / num,
										speed = num,
										target = float14,
										forwardMovementSign = 1
									});
									beamQueueBuffer.Add(new BeamQueueBuffer
									{
										beamId = beamId4,
										spawnPos = float13
									});
								}
							}
						}
						break;
					}
					case 2:
					{
						float3 x2 = rng.NextFloat3(-1f, 1f);
						x2.y = 0f;
						x2 = math.normalizesafe(x2, new float3(1f, 0f, 0f));
						int num9 = 3;
						double num10 = time;
						for (int k = 0; k < num9; k++)
						{
							int num11 = 360 / num9 * k;
							float3 float6 = math.mul(quaternion.AxisAngle(MathUtilities.Float3.up, math.radians(num11)), x2);
							float3 float7 = position + float6 * rng.NextFloat(5f, 10f);
							for (int l = -1; l <= 1; l++)
							{
								int beamId2 = ++coreBoss.beamIdCounter;
								float3 float8 = math.normalizesafe(math.cross(float6, MathUtilities.Float3.up));
								float3 float9 = float7 + float8 * l;
								float3 float10 = position + float8 * l;
								float num12 = math.distance(float9, float10);
								coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
								{
									beamId = beamId2,
									duration = 1f,
									target = float10
								});
								float num13 = 0.3f;
								float num14 = num13 * num2;
								coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
								{
									beamId = beamId2,
									duration = num13,
									speed = num2,
									target = float10,
									forwardMovementSign = -1
								});
								coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
								{
									beamId = beamId2,
									duration = (num14 + num12) / (num * 2f) * 2f,
									speed = num * 2f,
									target = float10,
									forwardMovementSign = 1
								});
								beamQueueBuffer.Add(new BeamQueueBuffer
								{
									beamId = beamId2,
									spawnTime = num10,
									spawnPos = float9
								});
							}
							num10 += 1.0;
						}
						break;
					}
					case 3:
					{
						int beamId = ++coreBoss.beamIdCounter;
						float3 x = rng.NextFloat3(-1f, 1f);
						x.y = 0f;
						x = math.normalizesafe(x, new float3(1f, 0f, 0f));
						float3 float5 = position + x * rng.NextFloat(3f, 6f);
						float num6 = math.distance(float5, position);
						float num7 = 0.8f;
						float num8 = num7 * num2;
						coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
						{
							beamId = beamId,
							duration = num7,
							speed = num2,
							target = position,
							forwardMovementSign = -1
						});
						coreBossBeamMovementInstructionBuffer.Add(new CoreBossBeamMovementInstructionBuffer
						{
							beamId = beamId,
							duration = (num8 + num6) / (num * 3f) * 2f,
							speed = num * 3f,
							target = position,
							forwardMovementSign = 1
						});
						beamQueueBuffer.Add(new BeamQueueBuffer
						{
							beamId = beamId,
							spawnPos = float5,
							startDuration = 0.5f
						});
						break;
					}
					}
					if (flag)
					{
						coreBossSpawnBeamsStateCD.attackType = (coreBossSpawnBeamsStateCD.attackType + 1) % 3;
					}
				}
				if (!flag)
				{
					coreBossSpawnBeamsStateCD.attackType = (coreBossSpawnBeamsStateCD.attackType + 1) % 4;
				}
				coreBossSpawnBeamsStateCD.internalState = 2;
				coreBossSpawnBeamsStateCD.timer.Start(time, coreBossSpawnBeamsStateCD.durationAfterBeamSpawn);
			}
			else if (coreBossSpawnBeamsStateCD.internalState == 2 && coreBossSpawnBeamsStateCD.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(-601574123, currentTick, animationBuffer, ref valueRW);
				coreBossSpawnBeamsStateCD.internalState = 3;
			}
			else if (coreBossSpawnBeamsStateCD.internalState == 3)
			{
				stateInfoCD.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossSpawnBeamsStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			BufferAccessor<AttackedNearbyEntitiesBufferCD> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__AttackedNearbyEntitiesBufferCD_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossCD_RW_ComponentTypeHandle);
			BufferAccessor<CoreBossBeamMovementInstructionBuffer> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle);
			BufferAccessor<BeamQueueBuffer> bufferAccessor4 = chunk.GetBufferAccessor(ref __TypeHandle.__BeamQueueBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref StateInfoCD stateInfoCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i);
					ref CoreBossSpawnBeamsStateCD coreBossSpawnBeamsStateCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					DynamicBuffer<AttackedNearbyEntitiesBufferCD> attackedNearbyEntitiesBuffer = bufferAccessor2[i];
					ref CoreBossCD coreBoss = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr4, i);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer = bufferAccessor3[i];
					DynamicBuffer<BeamQueueBuffer> beamQueueBuffer = bufferAccessor4[i];
					Execute(entity, ref stateInfoCD, ref coreBossSpawnBeamsStateCD, ref animationBuffer, ref attackedNearbyEntitiesBuffer, ref coreBoss, ref coreBossBeamMovementInstructionBuffer, ref beamQueueBuffer);
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
						ref StateInfoCD stateInfoCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin);
						ref CoreBossSpawnBeamsStateCD coreBossSpawnBeamsStateCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<AttackedNearbyEntitiesBufferCD> attackedNearbyEntitiesBuffer2 = bufferAccessor2[nextRangeBegin];
						ref CoreBossCD coreBoss2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer2 = bufferAccessor3[nextRangeBegin];
						DynamicBuffer<BeamQueueBuffer> beamQueueBuffer2 = bufferAccessor4[nextRangeBegin];
						Execute(entity2, ref stateInfoCD2, ref coreBossSpawnBeamsStateCD2, ref animationBuffer2, ref attackedNearbyEntitiesBuffer2, ref coreBoss2, ref coreBossBeamMovementInstructionBuffer2, ref beamQueueBuffer2);
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
					ref StateInfoCD stateInfoCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j);
					ref CoreBossSpawnBeamsStateCD coreBossSpawnBeamsStateCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					DynamicBuffer<AttackedNearbyEntitiesBufferCD> attackedNearbyEntitiesBuffer3 = bufferAccessor2[j];
					ref CoreBossCD coreBoss3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr4, j);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer3 = bufferAccessor3[j];
					DynamicBuffer<BeamQueueBuffer> beamQueueBuffer3 = bufferAccessor4[j];
					Execute(entity3, ref stateInfoCD3, ref coreBossSpawnBeamsStateCD3, ref animationBuffer3, ref attackedNearbyEntitiesBuffer3, ref coreBoss3, ref coreBossBeamMovementInstructionBuffer3, ref beamQueueBuffer3);
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
					ref StateInfoCD stateInfoCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k);
					ref CoreBossSpawnBeamsStateCD coreBossSpawnBeamsStateCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossSpawnBeamsStateCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					DynamicBuffer<AttackedNearbyEntitiesBufferCD> attackedNearbyEntitiesBuffer4 = bufferAccessor2[k];
					ref CoreBossCD coreBoss4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr4, k);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer4 = bufferAccessor3[k];
					DynamicBuffer<BeamQueueBuffer> beamQueueBuffer4 = bufferAccessor4[k];
					Execute(entity4, ref stateInfoCD4, ref coreBossSpawnBeamsStateCD4, ref animationBuffer4, ref attackedNearbyEntitiesBuffer4, ref coreBoss4, ref coreBossBeamMovementInstructionBuffer4, ref beamQueueBuffer4);
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
	private struct CoreBossMovementInstructionJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<CoreBossCD> __CoreBossCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<CoreBossBeamMovementInstructionBuffer> __CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle;

				public BufferTypeHandle<BeamQueueBuffer> __BeamQueueBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__CoreBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossCD>();
					__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossBeamMovementInstructionBuffer>();
					__BeamQueueBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<BeamQueueBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__CoreBossCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle.Update(ref state);
					__BeamQueueBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<CoreBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossBeamMovementInstructionBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BeamQueueBuffer>();
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
			public void Run(ref CoreBossMovementInstructionJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CoreBossMovementInstructionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CoreBossMovementInstructionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CoreBossMovementInstructionJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CoreBossMovementInstructionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CoreBossMovementInstructionJob job, EntityManager entityManager)
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
		public ComponentLookup<CoreBossBeamCD> coreBossBeamLookup;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref CoreBossCD coreBoss, ref DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer, ref DynamicBuffer<BeamQueueBuffer> beamQueueBuffer)
		{
			if (beamQueueBuffer.Length == 0)
			{
				return;
			}
			int num = 0;
			while (num < beamQueueBuffer.Length)
			{
				BeamQueueBuffer beamQueueBuffer2 = beamQueueBuffer[num];
				if (time < beamQueueBuffer2.spawnTime)
				{
					num++;
					continue;
				}
				Entity prefabEntity;
				Entity entity2 = EntityUtility.CreateEntity(ecb, beamQueueBuffer2.spawnPos, ObjectID.CoreBossBeam, 1, databaseBankCD.databaseBankBlob, out prefabEntity);
				DynamicBuffer<CoreBossBeamMovementInstructionBuffer> dynamicBuffer = ecb.SetBuffer<CoreBossBeamMovementInstructionBuffer>(entity2);
				int num2 = 0;
				while (num2 < coreBossBeamMovementInstructionBuffer.Length)
				{
					if (coreBossBeamMovementInstructionBuffer[num2].beamId != beamQueueBuffer2.beamId)
					{
						num2++;
						continue;
					}
					dynamicBuffer.Add(coreBossBeamMovementInstructionBuffer[num2]);
					coreBossBeamMovementInstructionBuffer.RemoveAt(num2);
				}
				CoreBossBeamCD component = coreBossBeamLookup[prefabEntity];
				float num3 = 0f;
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					num3 += dynamicBuffer[i].duration;
				}
				component.loopDuration = num3;
				component.startDuration = beamQueueBuffer2.startDuration;
				ecb.SetComponent(entity2, component);
				ecb.SetComponent(entity2, new OwnerReferenceCD
				{
					owner = entity
				});
				beamQueueBuffer.RemoveAt(num);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossCD_RW_ComponentTypeHandle);
			BufferAccessor<CoreBossBeamMovementInstructionBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle);
			BufferAccessor<BeamQueueBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__BeamQueueBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref CoreBossCD coreBoss = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, i);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer = bufferAccessor[i];
					DynamicBuffer<BeamQueueBuffer> beamQueueBuffer = bufferAccessor2[i];
					Execute(entity, ref coreBoss, ref coreBossBeamMovementInstructionBuffer, ref beamQueueBuffer);
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
						ref CoreBossCD coreBoss2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<BeamQueueBuffer> beamQueueBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref coreBoss2, ref coreBossBeamMovementInstructionBuffer2, ref beamQueueBuffer2);
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
					ref CoreBossCD coreBoss3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, j);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer3 = bufferAccessor[j];
					DynamicBuffer<BeamQueueBuffer> beamQueueBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref coreBoss3, ref coreBossBeamMovementInstructionBuffer3, ref beamQueueBuffer3);
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
					ref CoreBossCD coreBoss4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossCD>(nativeArrayPtr2, k);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> coreBossBeamMovementInstructionBuffer4 = bufferAccessor[k];
					DynamicBuffer<BeamQueueBuffer> beamQueueBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref coreBoss4, ref coreBossBeamMovementInstructionBuffer4, ref beamQueueBuffer4);
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
	private struct CoreBossStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<CoreBossBeamCD> __CoreBossBeamCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<CoreBossBeamMovementInstructionBuffer> __CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__CoreBossBeamCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CoreBossBeamCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<CoreBossBeamMovementInstructionBuffer>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__CoreBossBeamCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossBeamCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<CoreBossBeamMovementInstructionBuffer>();
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
			public void Run(ref CoreBossStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CoreBossStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CoreBossStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CoreBossStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CoreBossStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CoreBossStateJob job, EntityManager entityManager)
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

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public Entity tileDamageBufferEntity;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref CoreBossBeamCD beam, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref HealthCD health, ref DynamicBuffer<CoreBossBeamMovementInstructionBuffer> movementInstructionBuffer, in LocalTransform transform)
		{
			if (beam.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(-1619438193, currentTick, animationBuffer, ref animationBufferPointer);
				beam.internalState = 1;
				beam.timer.Start(time, beam.startDuration);
			}
			else if (beam.internalState == 1 && beam.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(-1587601938, currentTick, animationBuffer, ref animationBufferPointer);
				beam.instructionIndex = -1;
				beam.internalState = 2;
				beam.timer.Start(time, beam.loopDuration);
			}
			else if (beam.internalState == 2 && beam.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(16528305, currentTick, animationBuffer, ref animationBufferPointer);
				beam.internalState = 3;
				beam.timer.Start(time, beam.endDuration);
			}
			else if (beam.internalState == 3 && beam.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(-2007111235, currentTick, animationBuffer, ref animationBufferPointer);
				beam.internalState = 4;
				beam.timer.Start(time, beam.hiddenEndDuration);
				health.health = 0;
			}
			if (beam.internalState != 2)
			{
				return;
			}
			bool num = beam.instructionIndex == -1 || beam.instructionTimer.IsTimerElapsed(time);
			bool flag = false;
			if (num)
			{
				if (beam.instructionIndex >= movementInstructionBuffer.Length - 1)
				{
					return;
				}
				beam.instructionIndex++;
				flag = true;
			}
			CoreBossBeamMovementInstructionBuffer coreBossBeamMovementInstructionBuffer = movementInstructionBuffer[beam.instructionIndex];
			if (flag)
			{
				beam.instructionTimer.Start(time, coreBossBeamMovementInstructionBuffer.duration);
				beam.direction = default(float3);
			}
			if (coreBossBeamMovementInstructionBuffer.forwardMovementSign != 0 || coreBossBeamMovementInstructionBuffer.rotationAroundTargetSign != 0)
			{
				if (beam.direction.Equals(default(float3)))
				{
					beam.direction = math.normalizesafe(coreBossBeamMovementInstructionBuffer.target - transform.Position, new float3(1f, 0f, 0f));
				}
				float3 float5 = default(float3);
				if (coreBossBeamMovementInstructionBuffer.forwardMovementSign != 0)
				{
					float5 = beam.direction * coreBossBeamMovementInstructionBuffer.speed * deltaTime * coreBossBeamMovementInstructionBuffer.forwardMovementSign;
				}
				else if (coreBossBeamMovementInstructionBuffer.rotationAroundTargetSign != 0)
				{
					float3 float6 = transform.Position - coreBossBeamMovementInstructionBuffer.target;
					float num2 = coreBossBeamMovementInstructionBuffer.speed / math.length(float6) * (float)coreBossBeamMovementInstructionBuffer.rotationAroundTargetSign;
					float3 axis = new float3(0f, 1f, 0f);
					quaternion q = quaternion.AxisAngle(axis, num2 * deltaTime);
					quaternion q2 = quaternion.AxisAngle(axis, (0f - num2) * deltaTime);
					float3 float7 = math.mul(q, float6);
					beam.direction = math.mul(q2, beam.direction);
					float5 += float7 - float6;
				}
				LocalTransform component = LocalTransform.FromPosition(transform.Position + float5);
				ecb.SetComponent(entity, component);
			}
			if (beam.dealDamageTimer.isRunning && !beam.dealDamageTimer.IsTimerElapsed(time))
			{
				return;
			}
			float3 position = transform.Position;
			for (int i = -1; i < 1; i++)
			{
				for (int j = -1; j < 1; j++)
				{
					int2 position2 = (position + new float3((float)i * 0.55f, 0f, (float)j * 0.55f)).RoundToInt2();
					ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
					{
						damage = 1000,
						position = position2,
						skipWallAndRootsLootDropOnDestroy = true,
						dontHitBridges = true,
						canHitLowColliders = true
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__CoreBossBeamCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			BufferAccessor<CoreBossBeamMovementInstructionBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__CoreBossBeamMovementInstructionBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref CoreBossBeamCD beam = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossBeamCD>(nativeArrayPtr2, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					ref AnimationBufferPointer animationBufferPointer = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, i);
					ref HealthCD health = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, i);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> movementInstructionBuffer = bufferAccessor2[i];
					Execute(entity, ref beam, ref animationBuffer, ref animationBufferPointer, ref health, ref movementInstructionBuffer, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i));
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
						ref CoreBossBeamCD beam2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossBeamCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						ref AnimationBufferPointer animationBufferPointer2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, nextRangeBegin);
						ref HealthCD health2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<CoreBossBeamMovementInstructionBuffer> movementInstructionBuffer2 = bufferAccessor2[nextRangeBegin];
						Execute(entity2, ref beam2, ref animationBuffer2, ref animationBufferPointer2, ref health2, ref movementInstructionBuffer2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, nextRangeBegin));
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
					ref CoreBossBeamCD beam3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossBeamCD>(nativeArrayPtr2, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					ref AnimationBufferPointer animationBufferPointer3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, j);
					ref HealthCD health3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, j);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> movementInstructionBuffer3 = bufferAccessor2[j];
					Execute(entity3, ref beam3, ref animationBuffer3, ref animationBufferPointer3, ref health3, ref movementInstructionBuffer3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j));
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
					ref CoreBossBeamCD beam4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<CoreBossBeamCD>(nativeArrayPtr2, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					ref AnimationBufferPointer animationBufferPointer4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, k);
					ref HealthCD health4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, k);
					DynamicBuffer<CoreBossBeamMovementInstructionBuffer> movementInstructionBuffer4 = bufferAccessor2[k];
					Execute(entity4, ref beam4, ref animationBuffer4, ref animationBufferPointer4, ref health4, ref movementInstructionBuffer4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k));
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
	[WithAll(new Type[] { typeof(CoreBossCD) })]
	private struct ForceInCombatJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<CoreBossCD>();
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
			public void Run(ref ForceInCombatJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ForceInCombatJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ForceInCombatJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ForceInCombatJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ForceInCombatJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ForceInCombatJob job, EntityManager entityManager)
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
		public ComponentLookup<ForceInCombatCD> forceInCombatLookup;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in DistanceToPlayerCD distanceToPlayerCD)
		{
			bool flag = forceInCombatLookup.HasComponent(entity);
			bool flag2 = distanceToPlayerCD.minDistanceSq < 400f;
			if (flag && !flag2)
			{
				ecb.RemoveComponent<ForceInCombatCD>(entity);
			}
			else if (!flag && flag2)
			{
				ecb.AddComponent<ForceInCombatCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr2, k));
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
	public struct InitializedCoreBossCD : IComponentData, IQueryTypeParameter
	{
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<CoreBossSpawnCD> __CoreBossSpawnCD_RO_ComponentLookup;

		public BreakCrystalMeteorJob.InternalCompilerQueryAndHandleData __CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<CollectedSoulsBuffer> __CollectedSoulsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<CoreBossCD> __CoreBossCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

		public SpawnCoreBossJob.InternalCompilerQueryAndHandleData __CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<InitializedCoreBossCD> __CoreBossSystem_InitializedCoreBossCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CoreBossOrbCD> __CoreBossOrbCD_RO_ComponentLookup;

		public InitializeCoreBossJob.InternalCompilerQueryAndHandleData __CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RangeAttackStateCD> __RangeAttackStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DontDestroyOnZeroHealthCD> __DontDestroyOnZeroHealthCD_RO_ComponentLookup;

		public CoreBossOrbJob.InternalCompilerQueryAndHandleData __CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ManuallyTriggerDestroyNearbyEntitiesCD> __ManuallyTriggerDestroyNearbyEntitiesCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PhaseTransitionStateCD> __PhaseTransitionStateCD_RO_ComponentLookup;

		public CoreBossPhaseAndAttacksJob.InternalCompilerQueryAndHandleData __CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle;

		public DestroyTilesWithinRadiusJob.InternalCompilerQueryAndHandleData __CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<AuraDistanceOverrideCD> __AuraDistanceOverrideCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> __DestroyTimerCD_RO_ComponentLookup;

		public SpawnVoidJob.InternalCompilerQueryAndHandleData __CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<CoreBossVoidImmuneZoneBuffer> __CoreBossVoidImmuneZoneBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		public SpawnBirdBossBeamsJob.InternalCompilerQueryAndHandleData __CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<CoreBossBeamCD> __CoreBossBeamCD_RO_ComponentLookup;

		public CoreBossMovementInstructionJob.InternalCompilerQueryAndHandleData __CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle;

		public CoreBossStateJob.InternalCompilerQueryAndHandleData __CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ForceInCombatCD> __ForceInCombatCD_RO_ComponentLookup;

		public ForceInCombatJob.InternalCompilerQueryAndHandleData __CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__CoreBossSpawnCD_RO_ComponentLookup = state.GetComponentLookup<CoreBossSpawnCD>(isReadOnly: true);
			__CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__CollectedSoulsBuffer_RO_BufferLookup = state.GetBufferLookup<CollectedSoulsBuffer>(isReadOnly: true);
			__CoreBossCD_RO_ComponentLookup = state.GetComponentLookup<CoreBossCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
			__CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__CoreBossSystem_InitializedCoreBossCD_RO_ComponentLookup = state.GetComponentLookup<InitializedCoreBossCD>(isReadOnly: true);
			__CoreBossOrbCD_RO_ComponentLookup = state.GetComponentLookup<CoreBossOrbCD>(isReadOnly: true);
			__CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__RangeAttackStateCD_RO_ComponentLookup = state.GetComponentLookup<RangeAttackStateCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__DontDestroyOnZeroHealthCD_RO_ComponentLookup = state.GetComponentLookup<DontDestroyOnZeroHealthCD>(isReadOnly: true);
			__CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ManuallyTriggerDestroyNearbyEntitiesCD_RO_ComponentLookup = state.GetComponentLookup<ManuallyTriggerDestroyNearbyEntitiesCD>(isReadOnly: true);
			__PhaseTransitionStateCD_RO_ComponentLookup = state.GetComponentLookup<PhaseTransitionStateCD>(isReadOnly: true);
			__CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__AuraDistanceOverrideCD_RO_ComponentLookup = state.GetComponentLookup<AuraDistanceOverrideCD>(isReadOnly: true);
			__DestroyTimerCD_RO_ComponentLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			__CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__NearbyEntitiesBufferCD_RO_BufferLookup = state.GetBufferLookup<NearbyEntitiesBufferCD>(isReadOnly: true);
			__CoreBossVoidImmuneZoneBuffer_RO_BufferLookup = state.GetBufferLookup<CoreBossVoidImmuneZoneBuffer>(isReadOnly: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
			__CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__CoreBossBeamCD_RO_ComponentLookup = state.GetComponentLookup<CoreBossBeamCD>(isReadOnly: true);
			__CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ForceInCombatCD_RO_ComponentLookup = state.GetComponentLookup<ForceInCombatCD>(isReadOnly: true);
			__CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_0000077E_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_0000077E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_0000077E_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_0000077F_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000077F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000077F_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery _coreBossQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_829545944_0;

	private EntityQuery __query_829545944_1;

	private EntityQuery __query_829545944_2;

	private EntityQuery __query_829545944_3;

	private EntityQuery __query_829545944_4;

	private EntityQuery __query_829545944_5;

	private EntityQuery __query_829545944_6;

	private EntityQuery __query_829545944_7;

	private static bool PlayerHasCollectedAllSouls(Entity closestPlayer, BufferLookup<CollectedSoulsBuffer> collectedSoulsBuffers)
	{
		if (closestPlayer == Entity.Null || !collectedSoulsBuffers.HasComponent(closestPlayer))
		{
			return false;
		}
		DynamicBuffer<CollectedSoulsBuffer> dynamicBuffer = collectedSoulsBuffers[closestPlayer];
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		for (int i = 0; i < dynamicBuffer.Length; i++)
		{
			flag |= dynamicBuffer[i].soulId == SoulID.SoulOfAzeos;
			flag2 |= dynamicBuffer[i].soulId == SoulID.SoulOfOmoroth;
			flag3 |= dynamicBuffer[i].soulId == SoulID.SoulOfScarab;
			flag4 |= dynamicBuffer[i].soulId == SoulID.SoulOfNatureHydra;
			flag5 |= dynamicBuffer[i].soulId == SoulID.SoulOfSeaHydra;
			flag6 |= dynamicBuffer[i].soulId == SoulID.SoulOfDesertHydra;
		}
		return flag && flag2 && flag3 && flag4 && flag5 && flag6;
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<WorldInfoCD>();
		_coreBossQuery = __query_829545944_0;
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_829545944_1.TryGetSingleton<NetworkTime>(out var value);
		EntityCommandBuffer ecb = __query_829545944_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new BreakCrystalMeteorJob
		{
			coreBossSpawnLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossSpawnCD_RO_ComponentLookup, ref state),
			ecb = ecb
		}, __TypeHandle.__CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new SpawnCoreBossJob
		{
			summarizedConditionsBuffers = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			collectedSoulsBuffers = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CollectedSoulsBuffer_RO_BufferLookup, ref state),
			coreBossGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossCD_RO_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			worldInfo = __query_829545944_3.GetSingleton<WorldInfoCD>(),
			databaseBankCD = __query_829545944_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			collisionWorld = __query_829545944_5.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			coreBossExists = !_coreBossQuery.IsEmpty,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new InitializeCoreBossJob
		{
			initializedCoreBossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossSystem_InitializedCoreBossCD_RO_ComponentLookup, ref state),
			coreBossOrbGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossOrbCD_RO_ComponentLookup, ref state),
			databaseBankCD = __query_829545944_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new CoreBossOrbJob
		{
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			healthGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			rangeAttackStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RangeAttackStateCD_RO_ComponentLookup, ref state),
			transformGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			summarizedConditionsGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			dontDestroyOnZeroHealthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDestroyOnZeroHealthCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new CoreBossPhaseAndAttacksJob
		{
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			manuallyTriggerDestroyNearbyEntitiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ManuallyTriggerDestroyNearbyEntitiesCD_RO_ComponentLookup, ref state),
			phaseTransitionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PhaseTransitionStateCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_5(new DestroyTilesWithinRadiusJob
		{
			coreBossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			tileDamageBufferEntity = __query_829545944_6.GetSingletonEntity()
		}, __TypeHandle.__CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_6(new SpawnVoidJob
		{
			auraDistanceOverrideLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AuraDistanceOverrideCD_RO_ComponentLookup, ref state),
			destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			databaseBankCD = __query_829545944_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			currentTick = value.ServerTick,
			tickRate = (uint)__query_829545944_7.GetSingleton<ClientServerTickRate>().SimulationTickRate,
			ecb = ecb,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			rng = PugRandom.GetRng()
		}, __TypeHandle.__CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_7(new SpawnBirdBossBeamsJob
		{
			nearbyEntitiesBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferLookup, ref state),
			summarizedConditionsBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			coreBossVoidImmuneZoneBufferGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__CoreBossVoidImmuneZoneBuffer_RO_BufferLookup, ref state),
			transformGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			playerGhostExtrapolatedGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			animationBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			rng = PugRandom.GetRng()
		}, __TypeHandle.__CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_8(new CoreBossMovementInstructionJob
		{
			coreBossBeamLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CoreBossBeamCD_RO_ComponentLookup, ref state),
			databaseBankCD = __query_829545944_4.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_9(new CoreBossStateJob
		{
			ecb = ecb,
			currentTick = value.ServerTick,
			tileDamageBufferEntity = __query_829545944_6.GetSingletonEntity(),
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_10(new ForceInCombatJob
		{
			forceInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ForceInCombatCD_RO_ComponentLookup, ref state),
			ecb = ecb
		}, __TypeHandle.__CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(BreakCrystalMeteorJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_BreakCrystalMeteorJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(SpawnCoreBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_SpawnCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(InitializeCoreBossJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_InitializeCoreBossJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(CoreBossOrbJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_CoreBossOrbJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(CoreBossPhaseAndAttacksJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_CoreBossPhaseAndAttacksJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_5(DestroyTilesWithinRadiusJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_DestroyTilesWithinRadiusJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_6(SpawnVoidJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_SpawnVoidJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_7(SpawnBirdBossBeamsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_SpawnBirdBossBeamsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_8(CoreBossMovementInstructionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_CoreBossMovementInstructionJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_9(CoreBossStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_CoreBossStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_10(ForceInCombatJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__CoreBossSystem_ForceInCombatJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CoreBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_829545944_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_829545944_7 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_0000077E_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_0000077F_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((CoreBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CoreBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((CoreBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
