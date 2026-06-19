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
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
public struct WallBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[] { typeof(WallBossCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct DestroyWallBossInClassicJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WallBossCD>();
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
			public void Run(ref DestroyWallBossInClassicJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DestroyWallBossInClassicJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DestroyWallBossInClassicJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DestroyWallBossInClassicJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DestroyWallBossInClassicJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DestroyWallBossInClassicJob job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity)
		{
			ecb.DestroyEntity(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity);
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
						Execute(entity2);
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
					Execute(entity3);
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
					Execute(entity4);
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
	private struct SpawnJob : IJob
	{
		[ReadOnly]
		public ComponentLookup<WallBossCD> wallBossLookUp;

		public bool wallBossExists;

		public WorldInfoCD worldInfoCD;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		public float worldScale;

		public void Execute()
		{
			bool flag = worldInfoCD.IsWorldModeEnabled(WorldMode.Creative);
			if (!wallBossExists && !flag && !worldInfoCD.wallBossHasBeenKilled)
			{
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.WallBoss, databaseBankCD.databaseBankBlob);
				float3 float5 = new float3(0f, 0f, wallBossLookUp[primaryPrefabEntity].distanceFromCore * worldScale);
				EntityUtility.CreateEntity(ecb, float5, CalculateClockwiseAngleFromForward(float5), ObjectID.WallBoss, 1, databaseBankCD.databaseBankBlob);
			}
		}
	}

	[BurstCompile]
	[WithAll(new Type[] { typeof(WallBossCD) })]
	[WithNone(new Type[] { typeof(InitializedWallBossCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct SpawnSegmentsAndHeadJob : IJobEntity, IJobChunk
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<InitializedWallBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<WallBossCD>();
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
			public void Run(ref SpawnSegmentsAndHeadJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnSegmentsAndHeadJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnSegmentsAndHeadJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnSegmentsAndHeadJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnSegmentsAndHeadJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnSegmentsAndHeadJob job, EntityManager entityManager)
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

		public ComponentLookup<WallBossCD> wallBossLookUp;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> entityPartLookUp;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookUp;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public EntityCommandBuffer ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRO<LocalTransform> transformRef)
		{
			float3 position = transformRef.ValueRO.Position;
			quaternion angle = CalculateClockwiseAngleFromForward(position);
			RefRW<WallBossCD> refRW = wallBossLookUp.GetRefRW(entity);
			int num = (refRW.ValueRO.totalSegments - 1) / 2;
			refRW.ValueRW.isMainEntity = true;
			using NativeList<WallBossTempHandle> nativeList = new NativeList<WallBossTempHandle>(Allocator.TempJob);
			for (int i = -num; i <= num; i++)
			{
				float3 position2 = CalculatePositionFromCenter(position, i, refRW.ValueRO.totalSegments, refRW.ValueRO.totalWidth);
				Entity entity2 = EntityUtility.CreateEntity(ecb, position2, ObjectID.WallBoss, 1, databaseBankCD.databaseBankBlob);
				ecb.AddComponent<InitializedWallBossCD>(entity2);
				ecb.AddComponent<DontSerializeCD>(entity2);
				ecb.RemoveComponent<CompanionEntityBuffer>(entity2);
				ecb.RemoveComponent<UpdateCompanionTranslationCD>(entity2);
				ecb.SetComponentEnabled<DontDropLootCD>(entity2, value: true);
				nativeList.Add(new WallBossTempHandle
				{
					entity = entity2,
					segmentNumber = i
				});
				ecb.SetComponent(entity2, new EntityPartCD
				{
					mainEntity = entity,
					showHitFeedbackOnThisPart = true,
					handleImmuneToDamageOnThisPart = true
				});
				ecb.AppendToBuffer(entity, new WallBossBufferElement
				{
					wallBoss = entity2,
					segmentNumber = i
				});
				ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity2);
				if (math.abs(i) == num / 2 || i == 0)
				{
					Entity entity3 = EntityUtility.CreateEntity(ecb, CalculatePositionFromSegment(position2, angle, refRW.ValueRO.segmentRadius), ObjectID.WallBossBulb, 1, databaseBankCD.databaseBankBlob);
					ecb.AddComponent<DontSerializeCD>(entity3);
					ecb.AppendToBuffer(entity2, new WallBossBulbBufferElement
					{
						wallBossBulb = entity3
					});
					ecb.AppendToBuffer(entity, new WallBossBulbBufferElement
					{
						wallBossBulb = entity3
					});
					ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity3);
				}
			}
			Entity entity4 = EntityUtility.CreateEntity(ecb, position, ObjectID.WallBossHead, 1, databaseBankCD.databaseBankBlob);
			ecb.AddComponent<DontSerializeCD>(entity4);
			ecb.SetComponent(entity4, new EntityPartCD
			{
				mainEntity = entity,
				showHitFeedbackOnThisPart = true
			});
			ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity4);
			ecb.SetComponent(entity4, new WallBossHeadCD
			{
				mainEntity = entity
			});
			ecb.SetComponent(entity, new WallBossHeadRefCD
			{
				headEntity = entity4
			});
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.WallBoss, databaseBankCD.databaseBankBlob);
			WallBossCD component = wallBossLookUp[primaryPrefabEntity];
			for (int j = 0; j < nativeList.Length; j++)
			{
				component.rightEntity = ((j > 0) ? nativeList[j - 1].entity : Entity.Null);
				component.leftEntity = ((j < nativeList.Length - 1) ? nativeList[j + 1].entity : Entity.Null);
				component.mainEntity = entity;
				component.segmentNumber = nativeList[j].segmentNumber;
				ecb.SetComponent(nativeList[j].entity, component);
			}
			disablePhysicsLookUp.SetComponentEnabled(entity, value: true);
			ecb.SetComponent(entity, new ImmuneToDamageCD
			{
				Value = ImmuneToDamageState.Invalid
			});
			ecb.AddComponent(entity, default(WallBossCenterCD));
			ecb.AddComponent<InitializedWallBossCD>(entity);
			ecb.AddComponent<ForceInCombatCD>(entity);
			EntityPartCD component2 = entityPartLookUp[entity];
			component2.mainEntity = entity;
			ecb.SetComponent(entity, component2);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRO<LocalTransform> refRO = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr, i);
					Execute(entity, refRO);
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
						RefRO<LocalTransform> refRO2 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr, nextRangeBegin);
						Execute(entity2, refRO2);
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
					RefRO<LocalTransform> refRO3 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr, j);
					Execute(entity3, refRO3);
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
					RefRO<LocalTransform> refRO4 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr, k);
					Execute(entity4, refRO4);
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
	[WithAll(new Type[] { typeof(HealthCD) })]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct UpdateStateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<WallBossCD> __WallBossCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<WallBossCenterCD> __WallBossSystem_WallBossCenterCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<WallBossHeadRefCD> __WallBossHeadRefCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<WallBossBufferElement> __WallBossBufferElement_RW_BufferTypeHandle;

				public BufferTypeHandle<WallBossBulbBufferElement> __WallBossBulbBufferElement_RW_BufferTypeHandle;

				public BufferTypeHandle<WallBossMovementBufferElement> __WallBossMovementBufferElement_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__WallBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossCD>();
					__WallBossSystem_WallBossCenterCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossCenterCD>();
					__WallBossHeadRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossHeadRefCD>(isReadOnly: true);
					__WallBossBufferElement_RW_BufferTypeHandle = state.GetBufferTypeHandle<WallBossBufferElement>();
					__WallBossBulbBufferElement_RW_BufferTypeHandle = state.GetBufferTypeHandle<WallBossBulbBufferElement>();
					__WallBossMovementBufferElement_RW_BufferTypeHandle = state.GetBufferTypeHandle<WallBossMovementBufferElement>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__WallBossCD_RW_ComponentTypeHandle.Update(ref state);
					__WallBossSystem_WallBossCenterCD_RW_ComponentTypeHandle.Update(ref state);
					__WallBossHeadRefCD_RO_ComponentTypeHandle.Update(ref state);
					__WallBossBufferElement_RW_BufferTypeHandle.Update(ref state);
					__WallBossBulbBufferElement_RW_BufferTypeHandle.Update(ref state);
					__WallBossMovementBufferElement_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<WallBossHeadRefCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossCenterCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossBufferElement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossBulbBufferElement>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossMovementBufferElement>();
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
			public void Run(ref UpdateStateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateStateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateStateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateStateJob job, EntityManager entityManager)
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

		public ComponentLookup<HealthCD> healthLookUp;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookUp;

		[ReadOnly]
		public ComponentLookup<Disabled> disabledLookUp;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookUp;

		[ReadOnly]
		public ComponentLookup<LastAttackerCD> lastAttackerLookUp;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookUp;

		public EntityCommandBuffer ecb;

		public Entity tileDamageBufferEntity;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<WallBossCD> wallBossRef, RefRW<WallBossCenterCD> wallBossCenterRef, RefRO<WallBossHeadRefCD> wallBossHeadRef, DynamicBuffer<WallBossBufferElement> wallBossBuffer, DynamicBuffer<WallBossBulbBufferElement> wallBossTargetBuffer, DynamicBuffer<WallBossMovementBufferElement> wallBossMovementBuffer)
		{
			RefRW<HealthCD> refRW = healthLookUp.GetRefRW(entity);
			int health = refRW.ValueRO.health;
			float normalized = refRW.ValueRO.Normalized;
			wallBossRef.ValueRW.prevHealth = health;
			int num = 0;
			foreach (WallBossBulbBufferElement item in wallBossTargetBuffer)
			{
				if (healthLookUp.TryGetComponent(item.wallBossBulb, out var componentData))
				{
					if (componentData.health > 0)
					{
						disablePhysicsLookUp.SetComponentEnabled(item.wallBossBulb, value: false);
						num++;
						wallBossCenterRef.ValueRW.lastAliveBulbEntity = item.wallBossBulb;
					}
					else
					{
						disablePhysicsLookUp.SetComponentEnabled(item.wallBossBulb, value: true);
					}
				}
			}
			if (num == 0)
			{
				wallBossCenterRef.ValueRW.lastAliveBulbEntity = Entity.Null;
			}
			if (wallBossRef.ValueRO.internalState == WallBossInternalState.Roaming)
			{
				if (num == 0)
				{
					wallBossRef.ValueRW.pauseTimer.Start(time, wallBossRef.ValueRO.pauseBeforeHeadEmergesDuration);
					wallBossRef.ValueRW.internalState = WallBossInternalState.PausedPreVulnerable;
				}
			}
			else if (wallBossRef.ValueRO.internalState == WallBossInternalState.PausedPreVulnerable)
			{
				if (wallBossRef.ValueRW.pauseTimer.isRunning && wallBossRef.ValueRW.pauseTimer.IsTimerElapsed(time))
				{
					wallBossCenterRef.ValueRW.headSegmentNumberPosition = 0;
					if (wallBossCenterRef.ValueRW.lastAliveBulbEntity != Entity.Null && lastAttackerLookUp.TryGetComponent(wallBossCenterRef.ValueRW.lastAliveBulbEntity, out var componentData2) && componentData2.Value != Entity.Null && playerGhostLookUp.TryGetComponent(componentData2.Value, out var _))
					{
						float3 position = localTransformLookUp[componentData2.Value].Position;
						float num2 = float.MaxValue;
						for (int i = 0; i < wallBossBuffer.Length; i++)
						{
							Entity wallBoss = wallBossBuffer[i].wallBoss;
							if (!(wallBoss == Entity.Null) && localTransformLookUp.HasComponent(wallBoss))
							{
								float num3 = math.distancesq(position, localTransformLookUp[wallBoss].Position);
								if (num3 < num2)
								{
									num2 = num3;
									wallBossCenterRef.ValueRW.headSegmentNumberPosition = wallBossBuffer[i].segmentNumber;
								}
							}
						}
					}
					if (wallBossCenterRef.ValueRW.headSegmentNumberPosition != 0)
					{
						int num4 = math.sign(wallBossCenterRef.ValueRW.headSegmentNumberPosition);
						int num5 = num4 * -1;
						int num6 = wallBossCenterRef.ValueRW.headSegmentNumberPosition + num5;
						int num7 = math.sign(num6);
						wallBossCenterRef.ValueRW.headSegmentNumberPosition = ((num7 == num4) ? num6 : 0);
					}
					wallBossRef.ValueRW.vulnerableTimer.Start(time, wallBossRef.ValueRO.vulnerableDuration);
					wallBossRef.ValueRW.internalState = WallBossInternalState.Vulnerable;
					wallBossRef.ValueRW.healthRatioOnEnteringVulnerableState = normalized;
				}
			}
			else if (wallBossRef.ValueRO.internalState == WallBossInternalState.Vulnerable)
			{
				if (disablePhysicsLookUp.IsComponentEnabled(wallBossHeadRef.ValueRO.headEntity))
				{
					int2 int5 = localTransformLookUp[wallBossHeadRef.ValueRO.headEntity].Position.RoundToInt2();
					for (int j = -5; j <= 5; j++)
					{
						for (int k = -5; k <= 5; k++)
						{
							int2 position2 = new int2(j, k) + int5;
							ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
							{
								damage = 10000,
								position = position2,
								skipWallAndRootsLootDropOnDestroy = true,
								canHitLowColliders = true
							});
						}
					}
				}
				disablePhysicsLookUp.SetComponentEnabled(wallBossHeadRef.ValueRO.headEntity, value: false);
				if (wallBossRef.ValueRW.vulnerableTimer.isRunning && wallBossRef.ValueRW.vulnerableTimer.GetRemainingTime(time) > wallBossRef.ValueRO.vulnerableOnDamageMaxDuration && health < wallBossRef.ValueRW.prevHealth)
				{
					wallBossRef.ValueRW.vulnerableTimer.Start(time, wallBossRef.ValueRO.vulnerableOnDamageMaxDuration);
				}
				if ((wallBossRef.ValueRW.vulnerableTimer.isRunning && wallBossRef.ValueRW.vulnerableTimer.IsTimerElapsed(time)) || normalized < wallBossRef.ValueRW.healthRatioOnEnteringVulnerableState - 0.25f)
				{
					disablePhysicsLookUp.SetComponentEnabled(wallBossHeadRef.ValueRO.headEntity, value: true);
					wallBossRef.ValueRW.pauseTimer.Start(time, wallBossRef.ValueRO.pauseBeforeBulbsEmergeDuration);
					wallBossRef.ValueRW.internalState = WallBossInternalState.PausedPreRoaming;
				}
			}
			else if (wallBossRef.ValueRO.internalState == WallBossInternalState.PausedPreRoaming && wallBossRef.ValueRW.pauseTimer.isRunning && wallBossRef.ValueRW.pauseTimer.IsTimerElapsed(time))
			{
				foreach (WallBossBulbBufferElement item2 in wallBossTargetBuffer)
				{
					if (!(item2.wallBossBulb == Entity.Null) && healthLookUp.TryGetComponent(item2.wallBossBulb, out var componentData4) && disablePhysicsLookUp.HasComponent(item2.wallBossBulb))
					{
						componentData4.health = componentData4.maxHealth;
						ecb.SetComponent(item2.wallBossBulb, componentData4);
						disablePhysicsLookUp.SetComponentEnabled(item2.wallBossBulb, value: false);
					}
				}
				wallBossRef.ValueRW.internalState = WallBossInternalState.Roaming;
			}
			if (num != wallBossRef.ValueRO.currentAliveTargets)
			{
				foreach (WallBossMovementBufferElement item3 in wallBossMovementBuffer)
				{
					if (num == item3.onTotalAliveTargets)
					{
						wallBossRef.ValueRW.decelerationTimer.Start(time, item3.decelerationDurationOnEnter);
						wallBossRef.ValueRW.movementState = WallBossMovementState.Decelerating;
						wallBossRef.ValueRW.currentDecelerationSpeed = item3.decelerationSpeed;
						wallBossRef.ValueRW.currentAccelerationSpeed = item3.accelerationSpeed;
						wallBossRef.ValueRW.currentMaxSpeed = item3.maxSpeed;
						break;
					}
				}
				wallBossRef.ValueRW.currentAliveTargets = num;
			}
			if (wallBossRef.ValueRW.decelerationTimer.isRunning && wallBossRef.ValueRW.decelerationTimer.IsTimerElapsed(time))
			{
				wallBossRef.ValueRW.movementState = WallBossMovementState.Accelerating;
				wallBossRef.ValueRW.decelerationTimer.Stop();
			}
			if (wallBossRef.ValueRW.movementState == WallBossMovementState.Decelerating)
			{
				wallBossRef.ValueRW.currentSpeed = math.lerp(wallBossRef.ValueRW.currentSpeed, 0f, wallBossRef.ValueRW.currentDecelerationSpeed * deltaTime);
				return;
			}
			bool num8 = disabledLookUp.HasComponent(entity);
			int num9 = (num8 ? 5 : 0);
			float num10 = wallBossRef.ValueRW.currentMaxSpeed + (float)num9;
			wallBossRef.ValueRW.currentSpeed = math.lerp(wallBossRef.ValueRW.currentSpeed, num10 + (4f - 4f * normalized), wallBossRef.ValueRW.currentAccelerationSpeed * deltaTime);
			if (num8 && refRW.ValueRO.health < refRW.ValueRO.maxHealth)
			{
				if (!wallBossRef.ValueRO.healthRegenTimer.isRunning)
				{
					wallBossRef.ValueRW.healthRegenTimer.Start(time, 5f);
				}
				if (wallBossRef.ValueRO.healthRegenTimer.IsTimerElapsed(time))
				{
					refRW.ValueRW.health = (int)math.min((float)refRW.ValueRW.health + (float)refRW.ValueRO.maxHealth * 0.1f, refRW.ValueRO.maxHealth);
					wallBossRef.ValueRW.healthRegenTimer.Start(time, 5f);
				}
			}
			else
			{
				wallBossRef.ValueRW.healthRegenTimer.Stop();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__WallBossCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__WallBossSystem_WallBossCenterCD_RW_ComponentTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__WallBossHeadRefCD_RO_ComponentTypeHandle);
			BufferAccessor<WallBossBufferElement> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__WallBossBufferElement_RW_BufferTypeHandle);
			BufferAccessor<WallBossBulbBufferElement> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__WallBossBulbBufferElement_RW_BufferTypeHandle);
			BufferAccessor<WallBossMovementBufferElement> bufferAccessor3 = chunk.GetBufferAccessor(ref __TypeHandle.__WallBossMovementBufferElement_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<WallBossCD> refRW = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, i);
					RefRW<WallBossCenterCD> refRW2 = InternalCompilerInterface.GetRefRW<WallBossCenterCD>(ptr2, i);
					RefRO<WallBossHeadRefCD> refRO = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, i);
					DynamicBuffer<WallBossBufferElement> wallBossBuffer = bufferAccessor[i];
					DynamicBuffer<WallBossBulbBufferElement> wallBossTargetBuffer = bufferAccessor2[i];
					DynamicBuffer<WallBossMovementBufferElement> wallBossMovementBuffer = bufferAccessor3[i];
					Execute(entity, refRW, refRW2, refRO, wallBossBuffer, wallBossTargetBuffer, wallBossMovementBuffer);
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
						RefRW<WallBossCD> refRW3 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, nextRangeBegin);
						RefRW<WallBossCenterCD> refRW4 = InternalCompilerInterface.GetRefRW<WallBossCenterCD>(ptr2, nextRangeBegin);
						RefRO<WallBossHeadRefCD> refRO2 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, nextRangeBegin);
						DynamicBuffer<WallBossBufferElement> wallBossBuffer2 = bufferAccessor[nextRangeBegin];
						DynamicBuffer<WallBossBulbBufferElement> wallBossTargetBuffer2 = bufferAccessor2[nextRangeBegin];
						DynamicBuffer<WallBossMovementBufferElement> wallBossMovementBuffer2 = bufferAccessor3[nextRangeBegin];
						Execute(entity2, refRW3, refRW4, refRO2, wallBossBuffer2, wallBossTargetBuffer2, wallBossMovementBuffer2);
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
					RefRW<WallBossCD> refRW5 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, j);
					RefRW<WallBossCenterCD> refRW6 = InternalCompilerInterface.GetRefRW<WallBossCenterCD>(ptr2, j);
					RefRO<WallBossHeadRefCD> refRO3 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, j);
					DynamicBuffer<WallBossBufferElement> wallBossBuffer3 = bufferAccessor[j];
					DynamicBuffer<WallBossBulbBufferElement> wallBossTargetBuffer3 = bufferAccessor2[j];
					DynamicBuffer<WallBossMovementBufferElement> wallBossMovementBuffer3 = bufferAccessor3[j];
					Execute(entity3, refRW5, refRW6, refRO3, wallBossBuffer3, wallBossTargetBuffer3, wallBossMovementBuffer3);
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
					RefRW<WallBossCD> refRW7 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, k);
					RefRW<WallBossCenterCD> refRW8 = InternalCompilerInterface.GetRefRW<WallBossCenterCD>(ptr2, k);
					RefRO<WallBossHeadRefCD> refRO4 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, k);
					DynamicBuffer<WallBossBufferElement> wallBossBuffer4 = bufferAccessor[k];
					DynamicBuffer<WallBossBulbBufferElement> wallBossTargetBuffer4 = bufferAccessor2[k];
					DynamicBuffer<WallBossMovementBufferElement> wallBossMovementBuffer4 = bufferAccessor3[k];
					Execute(entity4, refRW7, refRW8, refRO4, wallBossBuffer4, wallBossTargetBuffer4, wallBossMovementBuffer4);
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
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
	private struct UpdatePositionJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<WallBossCD> __WallBossCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<WallBossCenterCD> __WallBossSystem_WallBossCenterCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<WallBossHeadRefCD> __WallBossHeadRefCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<BossCD> __BossCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				public BufferTypeHandle<WallBossBufferElement> __WallBossBufferElement_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__WallBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossCD>();
					__WallBossSystem_WallBossCenterCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossCenterCD>(isReadOnly: true);
					__WallBossHeadRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossHeadRefCD>(isReadOnly: true);
					__BossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BossCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__WallBossBufferElement_RW_BufferTypeHandle = state.GetBufferTypeHandle<WallBossBufferElement>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__WallBossCD_RW_ComponentTypeHandle.Update(ref state);
					__WallBossSystem_WallBossCenterCD_RO_ComponentTypeHandle.Update(ref state);
					__WallBossHeadRefCD_RO_ComponentTypeHandle.Update(ref state);
					__BossCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__WallBossBufferElement_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<WallBossCenterCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<WallBossHeadRefCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossBufferElement>();
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
			public void Run(ref UpdatePositionJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdatePositionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdatePositionJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdatePositionJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdatePositionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdatePositionJob job, EntityManager entityManager)
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
		public BufferLookup<WallBossBulbBufferElement> wallBossTargetBufferLookUp;

		public float worldScale;

		public EntityCommandBuffer ecb;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<WallBossCD> wallBossRef, RefRO<WallBossCenterCD> wallBossCenterRO, RefRO<WallBossHeadRefCD> wallBossHeadRef, RefRW<BossCD> bossRef, RefRO<LocalTransform> transformRef, DynamicBuffer<WallBossBufferElement> wallBossBuffer)
		{
			float3 float5 = MovePosition(transformRef.ValueRO.Position, CalculateClockwiseAngleFromForward(transformRef.ValueRO.Position), wallBossRef.ValueRO.currentSpeed * deltaTime, wallBossRef.ValueRO.distanceFromCore * worldScale);
			quaternion quaternion2 = CalculateClockwiseAngleFromForward(float5);
			wallBossRef.ValueRW.slitherElapsedTime += deltaTime * wallBossRef.ValueRO.slitheringFrequencyMultiplier * (wallBossRef.ValueRO.currentSpeed / 3.5f);
			foreach (WallBossBufferElement item in wallBossBuffer)
			{
				float3 position = ShiftPosition(CalculatePositionFromCenter(float5, item.segmentNumber, wallBossRef.ValueRO.totalSegments, wallBossRef.ValueRO.totalWidth), quaternion2, item.segmentNumber, wallBossRef.ValueRO.slitherElapsedTime, wallBossRef.ValueRO.slitheringWavelengthMultiplier, wallBossRef.ValueRO.slitheringWaveHeightMultiplier);
				if (item.wallBoss == Entity.Null)
				{
					continue;
				}
				ecb.SetComponent(item.wallBoss, LocalTransform.FromPosition(position));
				if (!wallBossTargetBufferLookUp.TryGetBuffer(item.wallBoss, out var bufferData))
				{
					continue;
				}
				foreach (WallBossBulbBufferElement item2 in bufferData)
				{
					if (!(item2.wallBossBulb == Entity.Null))
					{
						ecb.SetComponent(item2.wallBossBulb, LocalTransform.FromPosition(CalculatePositionFromSegment(position, quaternion2, wallBossRef.ValueRO.segmentRadius + wallBossRef.ValueRO.bulbOffset)));
					}
				}
				if (item.segmentNumber == wallBossCenterRO.ValueRO.headSegmentNumberPosition)
				{
					float3 float6 = CalculatePositionFromSegment(position, quaternion2, wallBossRef.ValueRO.segmentRadius + wallBossRef.ValueRO.headOffset);
					if (!(wallBossHeadRef.ValueRO.headEntity == Entity.Null))
					{
						ecb.SetComponent(wallBossHeadRef.ValueRO.headEntity, LocalTransform.FromPositionRotation(float6, quaternion2));
						bossRef.ValueRW.chestSpawnPositionOverride = float6;
					}
				}
			}
			ecb.SetComponent(entity, LocalTransform.FromPosition(float5));
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__WallBossCD_RW_ComponentTypeHandle);
			IntPtr ptr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__WallBossSystem_WallBossCenterCD_RO_ComponentTypeHandle);
			IntPtr ptr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__WallBossHeadRefCD_RO_ComponentTypeHandle);
			IntPtr ptr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BossCD_RW_ComponentTypeHandle);
			IntPtr ptr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<WallBossBufferElement> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__WallBossBufferElement_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<WallBossCD> refRW = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, i);
					RefRO<WallBossCenterCD> refRO = InternalCompilerInterface.GetRefRO<WallBossCenterCD>(ptr2, i);
					RefRO<WallBossHeadRefCD> refRO2 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, i);
					RefRW<BossCD> refRW2 = InternalCompilerInterface.GetRefRW<BossCD>(ptr4, i);
					RefRO<LocalTransform> refRO3 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr5, i);
					DynamicBuffer<WallBossBufferElement> wallBossBuffer = bufferAccessor[i];
					Execute(entity, refRW, refRO, refRO2, refRW2, refRO3, wallBossBuffer);
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
						RefRW<WallBossCD> refRW3 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, nextRangeBegin);
						RefRO<WallBossCenterCD> refRO4 = InternalCompilerInterface.GetRefRO<WallBossCenterCD>(ptr2, nextRangeBegin);
						RefRO<WallBossHeadRefCD> refRO5 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, nextRangeBegin);
						RefRW<BossCD> refRW4 = InternalCompilerInterface.GetRefRW<BossCD>(ptr4, nextRangeBegin);
						RefRO<LocalTransform> refRO6 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr5, nextRangeBegin);
						DynamicBuffer<WallBossBufferElement> wallBossBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, refRW3, refRO4, refRO5, refRW4, refRO6, wallBossBuffer2);
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
					RefRW<WallBossCD> refRW5 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, j);
					RefRO<WallBossCenterCD> refRO7 = InternalCompilerInterface.GetRefRO<WallBossCenterCD>(ptr2, j);
					RefRO<WallBossHeadRefCD> refRO8 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, j);
					RefRW<BossCD> refRW6 = InternalCompilerInterface.GetRefRW<BossCD>(ptr4, j);
					RefRO<LocalTransform> refRO9 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr5, j);
					DynamicBuffer<WallBossBufferElement> wallBossBuffer3 = bufferAccessor[j];
					Execute(entity3, refRW5, refRO7, refRO8, refRW6, refRO9, wallBossBuffer3);
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
					RefRW<WallBossCD> refRW7 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, k);
					RefRO<WallBossCenterCD> refRO10 = InternalCompilerInterface.GetRefRO<WallBossCenterCD>(ptr2, k);
					RefRO<WallBossHeadRefCD> refRO11 = InternalCompilerInterface.GetRefRO<WallBossHeadRefCD>(ptr3, k);
					RefRW<BossCD> refRW8 = InternalCompilerInterface.GetRefRW<BossCD>(ptr4, k);
					RefRO<LocalTransform> refRO12 = InternalCompilerInterface.GetRefRO<LocalTransform>(ptr5, k);
					DynamicBuffer<WallBossBufferElement> wallBossBuffer4 = bufferAccessor[k];
					Execute(entity4, refRW7, refRO10, refRO11, refRW8, refRO12, wallBossBuffer4);
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
		typeof(LocalTransform),
		typeof(BehaviourTagsCD)
	})]
	[WithDisabled(new Type[] { typeof(EntityDestroyedCD) })]
	private struct CollisionDamageJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<WallBossCD> __WallBossCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__WallBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<WallBossCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__WallBossCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<WallBossCD>();
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
			public void Run(ref CollisionDamageJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CollisionDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CollisionDamageJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CollisionDamageJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CollisionDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CollisionDamageJob job, EntityManager entityManager)
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

		public AttackSystem.Helper attackHelper;

		public float deltaTime;

		public EntityCommandBuffer ecb;

		public FixedList32Bytes<ObjectID> cantHitObjectIds;

		public Entity effectEventBuffer;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, RefRW<WallBossCD> wallBossRef)
		{
			wallBossRef.ValueRW.attackTimer -= deltaTime;
			if (!(wallBossRef.ValueRW.attackTimer > 0f))
			{
				RefRO<LocalTransform> refRO = attackHelper.localTransformLookup.GetRefRO(entity);
				RefRO<BehaviourTagsCD> refRO2 = attackHelper.behaviourTagsLookup.GetRefRO(entity);
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBuffer,
					attacker = entity,
					boxHalfHorizontalWidth = wallBossRef.ValueRO.segmentRadius,
					boxHalfVerticalWidth = 1f,
					damage = 20000,
					playerDamage = 20000,
					skipWallAndRootsLootDropOnDestroy = true,
					skipLootDropOnDestroy = true,
					bypassMaxDamagePerHit = true,
					cantHitObjectsHangingOnWalls = true,
					behaviourTags = refRO2.ValueRO,
					attackTime = wallBossRef.ValueRW.attackDuration,
					bypassDamageReduction = true,
					canOnlyAttackType = CanOnlyAttackType.EnemyAndPlayer,
					cantHitSpecificObjects = cantHitObjectIds,
					rotation = CalculateClockwiseAngleFromForward(refRO.ValueRO.Position)
				};
				if (attackHelper.Attack(ecb, in p))
				{
					wallBossRef.ValueRW.attackTimer = wallBossRef.ValueRW.attackDuration + wallBossRef.ValueRW.attackCooldown;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr ptr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__WallBossCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					RefRW<WallBossCD> refRW = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, i);
					Execute(entity, refRW);
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
						RefRW<WallBossCD> refRW2 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, nextRangeBegin);
						Execute(entity2, refRW2);
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
					RefRW<WallBossCD> refRW3 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, j);
					Execute(entity3, refRW3);
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
					RefRW<WallBossCD> refRW4 = InternalCompilerInterface.GetRefRW<WallBossCD>(ptr, k);
					Execute(entity4, refRW4);
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

	public struct WallBossCenterCD : IComponentData, IQueryTypeParameter
	{
		public int headSegmentNumberPosition;

		public Entity lastAliveBulbEntity;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct InitializedWallBossCD : IComponentData, IQueryTypeParameter
	{
	}

	private struct WallBossTempHandle
	{
		public Entity entity;

		public int segmentNumber;
	}

	private struct TypeHandle
	{
		public DestroyWallBossInClassicJob.InternalCompilerQueryAndHandleData __WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<WallBossCD> __WallBossCD_RO_ComponentLookup;

		public ComponentLookup<WallBossCD> __WallBossCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityPartCD> __EntityPartCD_RO_ComponentLookup;

		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

		public SpawnSegmentsAndHeadJob.InternalCompilerQueryAndHandleData __WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<HealthCD> __HealthCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<Disabled> __Unity_Entities_Disabled_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LastAttackerCD> __LastAttackerCD_RO_ComponentLookup;

		public UpdateStateJob.InternalCompilerQueryAndHandleData __WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public BufferLookup<WallBossBulbBufferElement> __WallBossBulbBufferElement_RO_BufferLookup;

		public UpdatePositionJob.InternalCompilerQueryAndHandleData __WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle;

		public CollisionDamageJob.InternalCompilerQueryAndHandleData __WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__WallBossCD_RO_ComponentLookup = state.GetComponentLookup<WallBossCD>(isReadOnly: true);
			__WallBossCD_RW_ComponentLookup = state.GetComponentLookup<WallBossCD>();
			__EntityPartCD_RO_ComponentLookup = state.GetComponentLookup<EntityPartCD>(isReadOnly: true);
			__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
			__WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HealthCD_RW_ComponentLookup = state.GetComponentLookup<HealthCD>();
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__Unity_Entities_Disabled_RO_ComponentLookup = state.GetComponentLookup<Disabled>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__LastAttackerCD_RO_ComponentLookup = state.GetComponentLookup<LastAttackerCD>(isReadOnly: true);
			__WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__WallBossBulbBufferElement_RO_BufferLookup = state.GetBufferLookup<WallBossBulbBufferElement>(isReadOnly: true);
			__WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000DE9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000DE9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000DE9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000DEA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000DEA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000DEA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_00000DEB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000DEB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000DEB_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00000DEC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000DEC_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000DEC_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private BlobAssetReference<PugDatabase.PugDatabaseBank> _database;

	private Entity _effectEventBuffer;

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1434247254_0;

	private EntityQuery __query_1434247254_1;

	private EntityQuery __query_1434247254_2;

	private EntityQuery __query_1434247254_3;

	private EntityQuery __query_1434247254_4;

	private EntityQuery __query_1434247254_5;

	private EntityQuery __query_1434247254_6;

	private EntityQuery __query_1434247254_7;

	private EntityQuery __query_1434247254_8;

	private EntityQuery __query_1434247254_9;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<InitialLoadingDoneCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldScaleCD>();
		state.RequireForUpdate<WorldGenerationTypeCD>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_database = __query_1434247254_1.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		_effectEventBuffer = __query_1434247254_2.GetSingletonEntity();
		if (!__query_1434247254_3.TryGetSingleton<ClientServerTickRate>(out var value))
		{
			value.ResolveDefaults();
		}
		_attackHelper = new AttackSystem.Helper(ref state, value.SimulationTickRate);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1434247254_4.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		if (__query_1434247254_5.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.Classic)
		{
			state.Dependency = __ScheduleViaJobChunkExtension_0(new DestroyWallBossInClassicJob
			{
				ecb = ecb
			}, __TypeHandle.__WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			return;
		}
		float value = __query_1434247254_6.GetSingleton<WorldScaleCD>().Value;
		Entity singletonEntity = __query_1434247254_7.GetSingletonEntity();
		if (!__query_1434247254_3.TryGetSingleton<ClientServerTickRate>(out var value2))
		{
			value2.ResolveDefaults();
		}
		__query_1434247254_8.TryGetSingleton<NetworkTime>(out var value3);
		_attackHelper.Update(ref state, value3.ServerTick, (uint)value2.SimulationTickRate);
		WorldInfoCD singleton = __query_1434247254_9.GetSingleton<WorldInfoCD>();
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		EntityQuery _query_1434247254_ = __query_1434247254_0;
		bool wallBossExists = !_query_1434247254_.IsEmptyIgnoreFilter;
		if (VariableSystemUpdate.ShouldUpdate(ref state, value3, 0, 1f))
		{
			state.Dependency = IJobExtensions.Schedule(new SpawnJob
			{
				wallBossLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WallBossCD_RO_ComponentLookup, ref state),
				wallBossExists = wallBossExists,
				worldInfoCD = singleton,
				databaseBankCD = __query_1434247254_1.GetSingleton<PugDatabase.DatabaseBankCD>(),
				ecb = ecb,
				worldScale = value
			}, state.Dependency);
		}
		state.Dependency = __ScheduleViaJobChunkExtension_1(new SpawnSegmentsAndHeadJob
		{
			wallBossLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WallBossCD_RW_ComponentLookup, ref state),
			entityPartLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityPartCD_RO_ComponentLookup, ref state),
			disablePhysicsLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			databaseBankCD = __query_1434247254_1.GetSingleton<PugDatabase.DatabaseBankCD>(),
			ecb = ecb
		}, __TypeHandle.__WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new UpdateStateJob
		{
			healthLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RW_ComponentLookup, ref state),
			playerGhostLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
			disabledLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Disabled_RO_ComponentLookup, ref state),
			localTransformLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			lastAttackerLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__LastAttackerCD_RO_ComponentLookup, ref state),
			disablePhysicsLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			tileDamageBufferEntity = singletonEntity,
			time = elapsedTime,
			deltaTime = deltaTime
		}, __TypeHandle.__WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new UpdatePositionJob
		{
			wallBossTargetBufferLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__WallBossBulbBufferElement_RO_BufferLookup, ref state),
			worldScale = value,
			ecb = ecb,
			deltaTime = deltaTime
		}, __TypeHandle.__WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		FixedList32Bytes<ObjectID> cantHitObjectIds = new FixedList32Bytes<ObjectID>
		{
			ObjectID.WallBoss,
			ObjectID.WallBossBulb,
			ObjectID.WallBossHead
		};
		state.Dependency = __ScheduleViaJobChunkExtension_4(new CollisionDamageJob
		{
			attackHelper = _attackHelper,
			deltaTime = deltaTime,
			ecb = ecb,
			cantHitObjectIds = cantHitObjectIds,
			effectEventBuffer = _effectEventBuffer
		}, __TypeHandle.__WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float3 ShiftPosition(float3 position, quaternion rotation, int segmentNumber, float elapsedTime, float wavelengthMultiplier, float waveHeightMultiplier)
	{
		float3 forwardNormalized = GetForwardNormalized(rotation);
		return position + forwardNormalized * math.sin(elapsedTime + (float)segmentNumber * MathF.PI / 2f * wavelengthMultiplier) * waveHeightMultiplier;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float3 GetForwardNormalized(quaternion rotation)
	{
		float3 v257 = new float3(0f, 0f, 1f);
		float3 x = math.mul(rotation, v257);
		x.y = 0f;
		return math.normalizesafe(x);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float3 MovePosition(float3 position, quaternion rotation, float distance, float distanceFromOrigin)
	{
		return math.normalizesafe(position + GetForwardNormalized(rotation) * distance) * distanceFromOrigin;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static quaternion CalculateClockwiseAngleFromForward(float3 pointA)
	{
		float num = Mathf.Atan2(pointA.x, pointA.z) * 57.29578f;
		return Quaternion.Euler(0f, 90f + num, 0f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float3 CalculatePositionFromCenter(float3 centerPosition, int segmentPosition, int totalSegments, float totalWidth)
	{
		float num = totalWidth / (float)(totalSegments - 1);
		centerPosition.y = 0f;
		float3 float5 = math.normalizesafe(centerPosition);
		float5.y = 0f;
		return centerPosition + float5 * num * segmentPosition;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float3 CalculatePositionFromSegment(float3 position, quaternion angle, float segmentRadius)
	{
		return position + GetForwardNormalized(angle) * segmentRadius;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(DestroyWallBossInClassicJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WallBossSystem_DestroyWallBossInClassicJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(SpawnSegmentsAndHeadJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WallBossSystem_SpawnSegmentsAndHeadJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(UpdateStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WallBossSystem_UpdateStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(UpdatePositionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WallBossSystem_UpdatePositionJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(CollisionDamageJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__WallBossSystem_CollisionDamageJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WallBossCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1434247254_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldScaleCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1434247254_9 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000DE9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000DEA_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000DEB_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000DEC_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((WallBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WallBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WallBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WallBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((WallBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
