using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
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

[BurstCompile]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct HydraBossSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HydraVulnerableEntityCreatedCD : IComponentData, IQueryTypeParameter
	{
	}

	[BurstCompile]
	[WithNone(new Type[] { typeof(HydraVulnerableEntityCreatedCD) })]
	private struct SpawnVulnerableHydraJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HydraBossCD> __HydraBossCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HydraBossCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HydraBossCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HydraBossCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HydraVulnerableEntityCreatedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossCD>();
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
			public void Run(ref SpawnVulnerableHydraJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnVulnerableHydraJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnVulnerableHydraJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnVulnerableHydraJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnVulnerableHydraJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnVulnerableHydraJob job, EntityManager entityManager)
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

		private void Execute(Entity entity, in HydraBossCD hydraBoss, in LocalTransform transform)
		{
			Entity entity2 = ecb.Instantiate(hydraBoss.vulnerableEntityPrefab);
			ecb.SetComponent(entity, new EntityPartCD
			{
				mainEntity = entity
			});
			ecb.SetComponent(entity2, new EntityPartCD
			{
				mainEntity = entity
			});
			ecb.SetComponent(entity2, transform);
			ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity2);
			ecb.SetComponent(entity, new HydraBossVulnerableEntityCD
			{
				entity = entity2
			});
			ecb.SetComponentEnabled<DisablePhysicsCD>(entity2, value: true);
			ecb.AddComponent<HydraVulnerableEntityCreatedCD>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HydraBossCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
	[WithNone(new Type[] { typeof(MainHydraCD) })]
	private struct CleanupNonMainHydrasJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MainHydraRefCD> __MainHydraRefCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__MainHydraRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MainHydraRefCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__MainHydraRefCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<MainHydraCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MainHydraRefCD>();
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
			public void Run(ref CleanupNonMainHydrasJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CleanupNonMainHydrasJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CleanupNonMainHydrasJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CleanupNonMainHydrasJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CleanupNonMainHydrasJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CleanupNonMainHydrasJob job, EntityManager entityManager)
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

		private void Execute(Entity entity, in MainHydraRefCD mainHydraRef)
		{
			if (mainHydraRef.mainHydra == Entity.Null)
			{
				ecb.DestroyEntity(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MainHydraRefCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr2, k));
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
	[WithAll(new Type[] { typeof(MainHydraCD) })]
	private struct HydraBossStateUpdateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<HydraBossCD> __HydraBossCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<BaitableCD> __BaitableCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HydraBossBuriedCombatStateCD> __HydraBossBuriedCombatStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HydraBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HydraBossCD>();
					__BaitableCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BaitableCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__HydraBossBuriedCombatStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HydraBossBuriedCombatStateCD>();
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HydraBossCD_RW_ComponentTypeHandle.Update(ref state);
					__BaitableCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__HydraBossBuriedCombatStateCD_RW_ComponentTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MainHydraCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HydraBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<BaitableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HydraBossBuriedCombatStateCD>();
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
			public void Run(ref HydraBossStateUpdateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HydraBossStateUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HydraBossStateUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HydraBossStateUpdateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HydraBossStateUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HydraBossStateUpdateJob job, EntityManager entityManager)
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
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<HydraBossBaitCD> hydraBossBaitLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public NativeList<Entity> newHydraBaits;

		[ReadOnly]
		public ComponentLookup<ShootMortarProjectileStateCD> shootMortarProjectileStateLookup;

		[ReadOnly]
		public ComponentLookup<AttackCooldownTimerCD> attackCooldownTimerLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> movementSpeedLookup;

		[ReadOnly]
		public ComponentLookup<ForceInCombatCD> forceInCombatLookup;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		public Entity effectEventBufferSingleton;

		public Entity healthChangeBufferEntity;

		public Entity tileDamageBufferEntity;

		public NetworkTick currentTick;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref HydraBossCD hydraBoss, ref BaitableCD baitableCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref HydraBossBuriedCombatStateCD buriedCombat, in DistanceToPlayerCD distanceToPlayer)
		{
			bool flag = hydraBoss.internalState == -1;
			int num = ((!flag) ? hydraBoss.internalState : 0);
			if (hydraBoss.internalState == 0 || flag)
			{
				baitableCD.baitEntity = Entity.Null;
				if (flag && distanceToPlayer.minDistanceSq < 6400f)
				{
					if (healthLookup.TryGetComponent(entity, out var componentData) && !componentData.HasFullHealth)
					{
						num = 2;
					}
				}
				else
				{
					float3 position = localTransformLookup[entity].Position;
					for (int i = 0; i < newHydraBaits.Length; i++)
					{
						if (hydraBossBaitLookup[newHydraBaits[i]].attractsHydraType == hydraBoss.hydraType)
						{
							float3 position2 = localTransformLookup[newHydraBaits[i]].Position;
							Biome biome = hydraBoss.hydraType switch
							{
								HydraBossType.Nature => Biome.Nature, 
								HydraBossType.Sea => Biome.Sea, 
								HydraBossType.Desert => Biome.Desert, 
								HydraBossType.Void => Biome.Excavation, 
								_ => Biome.None, 
							};
							if (biomeLookup.GetBiome(position2.RoundToInt2()) == biome && math.distancesq(position, position2) < 90000f)
							{
								baitableCD.baitEntity = newHydraBaits[i];
								break;
							}
						}
					}
					if (baitableCD.baitEntity != Entity.Null)
					{
						if (localTransformLookup.TryGetComponent(baitableCD.baitEntity, out var componentData2))
						{
							EntityUtility.PlayEffectEventServer(ecb, effectEventBufferSingleton, new EffectEventCD
							{
								effectID = EffectID.SnakeBossEngage,
								position1 = componentData2.Position
							});
						}
						num = 1;
					}
				}
			}
			else if (hydraBoss.internalState == 1)
			{
				if (baitableCD.baitEntity == Entity.Null || (entityDestroyedLookup.HasComponent(baitableCD.baitEntity) && entityDestroyedLookup.IsComponentEnabled(baitableCD.baitEntity)) || !localTransformLookup.HasComponent(baitableCD.baitEntity))
				{
					num = 0;
				}
				else
				{
					float3 position3 = localTransformLookup[entity].Position;
					if (math.distancesq(localTransformLookup[baitableCD.baitEntity].Position, position3) < 1f)
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
			else if (hydraBoss.internalState == 2 && (distanceToPlayer.closestPlayer == Entity.Null || distanceToPlayer.minDistanceSq > 10000f))
			{
				num = 0;
			}
			if (hydraBoss.internalState != num && num == 2)
			{
				AnimationUtilities.TriggerAnimation(1819704882, currentTick, animationBuffer, ref animationBufferPointer);
				float3 position4 = localTransformLookup[entity].Position;
				DestroyTilesWithinRadius(3f, position4, ecb, tileDamageBufferEntity);
				ShootMortarProjectileStateCD component = shootMortarProjectileStateLookup[entity];
				component.cooldownTimer.Start(time, 6f);
				ecb.SetComponent(entity, component);
				AttackCooldownTimerCD component2 = attackCooldownTimerLookup[entity];
				component2.Value.Start(time, 6f);
				ecb.SetComponent(entity, component2);
				buriedCombat.cooldownTimer.Start(time, 4f);
			}
			hydraBoss.internalState = num;
			MovementSpeedCD component3 = movementSpeedLookup[entity];
			if (hydraBoss.internalState == 0 && hydraBoss.targetPlayerEntity == Entity.Null)
			{
				component3.speed = 5f;
			}
			else if (hydraBoss.internalState == 1 && baitableCD.baitEntity != Entity.Null && localTransformLookup.HasComponent(baitableCD.baitEntity))
			{
				float3 position5 = localTransformLookup[entity].Position;
				float num2 = math.distance(localTransformLookup[baitableCD.baitEntity].Position, position5);
				float t = math.min(1f, num2 / 60f);
				component3.speed = math.lerp(5f, 20f, t);
			}
			else
			{
				component3.speed = 7f;
			}
			ecb.SetComponent(entity, component3);
			if (hydraBoss.internalState == 2 && !forceInCombatLookup.HasComponent(entity))
			{
				ecb.AddComponent<ForceInCombatCD>(entity);
			}
			else if (hydraBoss.internalState != 2 && forceInCombatLookup.HasComponent(entity))
			{
				ecb.RemoveComponent<ForceInCombatCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HydraBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__BaitableCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HydraBossBuriedCombatStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref HydraBossCD hydraBoss = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, i);
					ref BaitableCD baitableCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref hydraBoss, ref baitableCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedCombatStateCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, i));
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
						ref HydraBossCD hydraBoss2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, nextRangeBegin);
						ref BaitableCD baitableCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref hydraBoss2, ref baitableCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedCombatStateCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, nextRangeBegin));
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
					ref HydraBossCD hydraBoss3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, j);
					ref BaitableCD baitableCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref hydraBoss3, ref baitableCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedCombatStateCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, j));
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
					ref HydraBossCD hydraBoss4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr2, k);
					ref BaitableCD baitableCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr3, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref hydraBoss4, ref baitableCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedCombatStateCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr6, k));
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
	[WithAll(new Type[] { typeof(HydraBossCD) })]
	[WithNone(new Type[] { typeof(MainHydraCD) })]
	private struct KillNonMainHydraJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MainHydraRefCD> __MainHydraRefCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
					__MainHydraRefCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MainHydraRefCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__HealthCD_RW_ComponentTypeHandle.Update(ref state);
					__MainHydraRefCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<MainHydraCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MainHydraRefCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossCD>();
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
			public void Run(ref KillNonMainHydraJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref KillNonMainHydraJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref KillNonMainHydraJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref KillNonMainHydraJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref KillNonMainHydraJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref KillNonMainHydraJob job, EntityManager entityManager)
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

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref HealthCD health, in MainHydraRefCD mainHydraRef)
		{
			if (entityDestroyedLookup.HasComponent(mainHydraRef.mainHydra) && entityDestroyedLookup.IsComponentEnabled(mainHydraRef.mainHydra))
			{
				health.health = 0;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HealthCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MainHydraRefCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, k));
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
		typeof(IsInCombatCD),
		typeof(LocalTransform),
		typeof(ObjectDataCD),
		typeof(ShootMortarProjectileStateCD)
	})]
	[WithAll(new Type[]
	{
		typeof(HydraBossVulnerableEntityCD),
		typeof(AnimationBuffer),
		typeof(AnimationBufferPointer),
		typeof(HydraBossCD)
	})]
	[WithAll(new Type[]
	{
		typeof(DistanceToPlayerCD),
		typeof(HydraBossBuriedCombatStateCD)
	})]
	private struct HydraBossUpdateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<MeleeAttackStateCD> __MeleeAttackStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MainHydraRefCD> __MainHydraRefCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<HydraBossBuriedRoamingStateCD> __HydraBossBuriedRoamingStateCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__MeleeAttackStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MeleeAttackStateCD>();
					__MainHydraRefCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MainHydraRefCD>();
					__HydraBossBuriedRoamingStateCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HydraBossBuriedRoamingStateCD>(isReadOnly: true);
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__MeleeAttackStateCD_RW_ComponentTypeHandle.Update(ref state);
					__MainHydraRefCD_RW_ComponentTypeHandle.Update(ref state);
					__HydraBossBuriedRoamingStateCD_RO_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HydraBossBuriedRoamingStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsInCombatCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ShootMortarProjectileStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossVulnerableEntityCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossBuriedCombatStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MeleeAttackStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MainHydraRefCD>();
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
			public void Run(ref HydraBossUpdateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HydraBossUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HydraBossUpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HydraBossUpdateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HydraBossUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HydraBossUpdateJob job, EntityManager entityManager)
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
		public ComponentLookup<MainHydraCD> mainHydraLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsLookUp;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> isInCombatLookup;

		[ReadOnly]
		public BufferLookup<HydraCombatAppearPositionsBuffer> appearPositionsLookUp;

		[ReadOnly]
		public BufferLookup<HydrasBuffer> hydrasLookUp;

		public ComponentLookup<ShootMortarProjectileStateCD> mortarStateLookUp;

		public ComponentLookup<HydraBossBuriedCombatStateCD> buriedCombatLookUp;

		[ReadOnly]
		public ComponentLookup<AttackCooldownTimerCD> attackCooldownTimerLookup;

		public ComponentLookup<HydraBossCD> hydraBossLookUp;

		[ReadOnly]
		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		[ReadOnly]
		public BufferLookup<AnimationBuffer> animationBufferLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> distanceToPlayerLookUp;

		[ReadOnly]
		public ComponentLookup<HydraVulnerableEntityCreatedCD> hydraVulnerableEntityCreatedLookup;

		[ReadOnly]
		public ComponentLookup<HydraBossVulnerableEntityCD> hydraBossVulnerableEntityLookup;

		[ReadOnly]
		public ComponentLookup<VulnerableStateCD> vulnerableStateLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> healthLookup;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public Entity tileDamageBufferEntity;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref MeleeAttackStateCD meleeAttackState, ref MainHydraRefCD mainHydra, in HydraBossBuriedRoamingStateCD buriedRoaming, in StateInfoCD stateInfo)
		{
			ref HydraBossCD valueRW = ref hydraBossLookUp.GetRefRW(entity).ValueRW;
			ref ShootMortarProjectileStateCD valueRW2 = ref mortarStateLookUp.GetRefRW(entity).ValueRW;
			ref HydraBossBuriedCombatStateCD valueRW3 = ref buriedCombatLookUp.GetRefRW(entity).ValueRW;
			bool flag = mainHydraLookup.HasComponent(entity);
			if (flag && mainHydra.mainHydra == Entity.Null)
			{
				ecb.AppendToBuffer(entity, new HydrasBuffer
				{
					hydra = entity
				});
				mainHydra.mainHydra = entity;
			}
			float3 position = localTransformLookup[entity].Position;
			ObjectPropertiesCD objectPropertiesCD = objectPropertiesLookup[entity];
			if (hydraVulnerableEntityCreatedLookup.HasComponent(entity))
			{
				Entity entity2 = hydraBossVulnerableEntityLookup[entity].entity;
				float3 float5 = math.normalizesafe(valueRW.pointToLookAt - position);
				ecb.SetComponent(entity2, LocalTransform.FromPosition(position + float5 * 0.5f));
				VulnerableStateCD vulnerableStateCD = vulnerableStateLookup[entity];
				bool flag2 = vulnerableStateCD.internalState != 3 || vulnerableStateCD.internalTimer.IsTimerElapsed(time);
				if ((disablePhysicsLookup.HasComponent(entity2) && disablePhysicsLookup.IsComponentEnabled(entity2)) != flag2)
				{
					disablePhysicsLookup.SetComponentEnabled(entity2, flag2);
				}
			}
			if (summarizedConditionsLookUp.HasComponent(entity) && summarizedConditionsLookUp[entity][98].value <= 0 && healthLookup.HasComponent(entity) && stateInfo.IsCurrentState(StateID.HydraBossBuriedRoaming))
			{
				EntityUtility.AddNewCondition(entity, ecb, new ConditionData
				{
					conditionID = ConditionID.ProtectiveArmor,
					duration = float.PositiveInfinity,
					value = (int)math.round((float)healthLookup[entity].maxHealth * 0.3f)
				});
			}
			ObjectDataCD objectDataCD = objectDataLookup[entity];
			IsInCombatCD isInCombatCD = isInCombatLookup[entity];
			int3 int5 = position.RoundToInt3();
			if (isInCombatCD.isInCombat)
			{
				meleeAttackState.isDisabled = false;
				if (flag && appearPositionsLookUp.HasComponent(entity) && hydrasLookUp.HasComponent(entity))
				{
					DynamicBuffer<HydraCombatAppearPositionsBuffer> dynamicBuffer = appearPositionsLookUp[entity];
					DynamicBuffer<HydrasBuffer> dynamicBuffer2 = hydrasLookUp[entity];
					if (dynamicBuffer.Length == 0)
					{
						valueRW3.midLocation = position;
						int num = 5;
						ecb.AppendToBuffer(entity, new HydraCombatAppearPositionsBuffer
						{
							pos = int5 + new float3(0f, 0f, num + 3)
						});
						ecb.AppendToBuffer(entity, new HydraCombatAppearPositionsBuffer
						{
							pos = int5 + new float3(num + 2, 0f, num)
						});
						ecb.AppendToBuffer(entity, new HydraCombatAppearPositionsBuffer
						{
							pos = int5 + new float3(num, 0f, -num + 1)
						});
						ecb.AppendToBuffer(entity, new HydraCombatAppearPositionsBuffer
						{
							pos = int5 + new float3(-num, 0f, -num + 1)
						});
						ecb.AppendToBuffer(entity, new HydraCombatAppearPositionsBuffer
						{
							pos = int5 + new float3(-num - 2, 0f, num)
						});
					}
					if (dynamicBuffer.Length > dynamicBuffer2.Length && ((objectDataCD.objectID == ObjectID.HydraBossSea && dynamicBuffer2.Length < 2) || (objectDataCD.objectID == ObjectID.HydraBossDesert && dynamicBuffer2.Length < 3) || (objectDataCD.objectID == ObjectID.HydraBossVoid && dynamicBuffer2.Length < 4)))
					{
						if (!valueRW.spawnOtherHydrasTimer.isRunning)
						{
							valueRW.spawnOtherHydrasTimer.Start(time, 1f);
						}
						if (!valueRW.spawnOtherHydrasTimer.IsTimerElapsed(time))
						{
							return;
						}
						valueRW.spawnOtherHydrasTimer.Start(time, 1f);
						float3 float6 = new float3(3 * ((dynamicBuffer2.Length % 2 == 0) ? 1 : (-1)), 0f, dynamicBuffer2.Length / 2 * 3);
						float3 float7 = position + float6;
						ObjectID objectID = ((objectDataCD.objectID == ObjectID.HydraBossSea) ? ObjectID.HydraBossNature : ((objectDataCD.objectID != ObjectID.HydraBossVoid) ? ((dynamicBuffer2.Length == 2) ? ObjectID.HydraBossSea : ObjectID.HydraBossNature) : ((dynamicBuffer2.Length == 3) ? ObjectID.HydraBossSea : ((dynamicBuffer2.Length == 2) ? ObjectID.HydraBossDesert : ObjectID.HydraBossNature))));
						Entity entity3 = EntityUtility.CreateEntity(ecb, float7, objectID, 1, databaseBankCD.databaseBankBlob);
						ecb.SetComponent(entity3, new MainHydraRefCD
						{
							mainHydra = entity
						});
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob);
						ecb.AppendToBuffer(entity, new HydrasBuffer
						{
							hydra = entity3
						});
						ecb.RemoveComponent<MainHydraCD>(entity3);
						ecb.RemoveComponent<HydrasBuffer>(entity3);
						ecb.RemoveComponent<HydraCombatAppearPositionsBuffer>(entity3);
						ecb.RemoveComponent<SpawnEntityOnDeathCD>(entity3);
						ecb.RemoveComponent<CompanionEntityBuffer>(entity3);
						ecb.SetComponent(entity3, new MusicAreaCD
						{
							isInactive = true
						});
						ecb.RemoveComponent<UpdateCompanionTranslationCD>(entity3);
						ecb.AddComponent<DontSerializeCD>(entity3);
						ecb.SetComponentEnabled<DontDropLootCD>(entity3, value: true);
						ecb.AddComponent<ForceInCombatCD>(entity3);
						ecb.RemoveComponent<TriggerAchievementOnDeathCD>(entity3);
						DestroyTilesWithinRadius(3f, float7, ecb, tileDamageBufferEntity);
						ecb.AddComponent(entity3, new SpawnStateCD
						{
							duration = 4f,
							animId = 1819704882
						});
						EntityUtility.AddNewCondition(entity3, ecb, new ConditionData
						{
							conditionID = ConditionID.ProtectiveArmor,
							duration = float.PositiveInfinity,
							value = (int)math.round((float)healthLookup[entity].maxHealth * 0.3f)
						});
						ShootMortarProjectileStateCD component = mortarStateLookUp[primaryPrefabEntity];
						component.cooldownTimer.Start(time, 8f);
						ecb.SetComponent(entity3, component);
						AttackCooldownTimerCD component2 = attackCooldownTimerLookup[primaryPrefabEntity];
						component2.Value.Start(time, 6f);
						ecb.SetComponent(entity3, component2);
						HydraBossBuriedCombatStateCD component3 = buriedCombatLookUp[primaryPrefabEntity];
						component3.midLocation = position;
						component3.cooldownTimer.Start(time, 4f);
						ecb.SetComponent(entity3, component3);
						HydraBossCD component4 = hydraBossLookUp[primaryPrefabEntity];
						component4.isGhost = true;
						component4.isVoid = objectDataCD.objectID == ObjectID.HydraBossVoid;
						ecb.SetComponent(entity3, component4);
					}
					else
					{
						valueRW.spawnOtherHydrasTimer.Stop();
					}
				}
				if (!stateInfo.IsCurrentState(StateID.ShootMortarProjectile))
				{
					if (!valueRW.hasPreparedNextMortarShots)
					{
						int num2 = ((!hydrasLookUp.HasComponent(mainHydra.mainHydra)) ? 1 : hydrasLookUp[mainHydra.mainHydra].Length);
						int num3 = (((float)healthLookup[entity].health < 0.5f) ? (-1) : 0);
						int num4 = 1 + num2 * 3;
						int num5 = 1 + num2 * 4;
						bool flag3 = false;
						if (hydrasLookUp.HasComponent(mainHydra.mainHydra))
						{
							DynamicBuffer<HydrasBuffer> dynamicBuffer3 = hydrasLookUp[mainHydra.mainHydra];
							for (int i = 0; i < dynamicBuffer3.Length; i++)
							{
								if (!(dynamicBuffer3[i].hydra == entity))
								{
									Entity hydra = dynamicBuffer3[i].hydra;
									if (mortarStateLookUp.HasComponent(hydra) && mortarStateLookUp[hydra].mortarProjectileID != ObjectID.HydraBossBeamMortarProjectile)
									{
										flag3 = true;
										break;
									}
								}
							}
						}
						if (objectDataCD.objectID == ObjectID.HydraBossDesert && (valueRW.patternCounter + 1) % (3 + num3) == 0)
						{
							if (!flag3)
							{
								valueRW2.mortarProjectileID = ObjectID.HydraBossLavaMortarProjectile;
								valueRW2.anticipationDuration = 1f;
								valueRW2.attackDuration = 3f;
								valueRW2.goUpTime = 0.5f;
								valueRW2.airTime = 0.2f;
								valueRW2.goDownTime = 0.85f;
								valueRW2.airTimeAdditionBetweenProjectiles = 0.2f;
								valueRW2.explodeTime = 1f;
								valueRW2.minAmountOfProjectiles = 9;
								valueRW2.maxAmountOfProjectiles = 9;
								valueRW2.maxProjectilesShotPerWave = 9;
								valueRW2.dontAllowOverlappingShots = false;
								valueRW2.timeBetweenProjectiles = 1f;
								valueRW2.minRandomSpreadDistance = 0f;
								valueRW2.maxRandomSpreadDistance = 0f;
								valueRW2.overridePositionToShootAt = false;
								valueRW2.lineFromShooterToTarget = true;
								valueRW2.lineBendTowardTarget = false;
								valueRW2.lineLengthMultiplier = 1.5f;
								valueRW2.lineLengthStartPositionPadding = 2f;
								valueRW2.lineScatterMultiplier = 2f;
								valueRW2.keepShootingUntilTakingDamageXTimes = 0;
								valueRW2.shootAtSelf = false;
								valueRW2.hitTiles = false;
								valueRW2.overrideAnimID = -1014102059;
								valueRW2.isDisabled = false;
								valueRW2.minCooldown = num4;
								valueRW2.maxCooldown = num5;
								valueRW2.mortarDamage = valueRW.lavaMortarDamage;
								valueRW2.canShootOnWaterAndPits = false;
								valueRW2.destroyProjectilesWhenNotInState = false;
								valueRW.hasPreparedNextMortarShots = true;
								valueRW.patternCounter++;
							}
						}
						else if (objectDataCD.objectID == ObjectID.HydraBossSea && (valueRW.patternCounter + 2) % (4 + num3) == 0)
						{
							if (!flag3)
							{
								int num6 = 1;
								int num7 = 0;
								NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
								if (collisionWorld.OverlapSphere(valueRW3.midLocation, 8f, ref outHits, CollisionFilter.Default))
								{
									for (int j = 0; j < outHits.Length; j++)
									{
										Entity entity4 = outHits[j].Entity;
										if (objectDataLookup.TryGetComponent(entity4, out var componentData) && componentData.objectID == ObjectID.HydraBossIceShard)
										{
											num7++;
											if (num7 >= num6)
											{
												break;
											}
										}
									}
								}
								outHits.Dispose();
								if (num7 < num6)
								{
									valueRW2.mortarProjectileID = ObjectID.HydraBossIceShardMortarProjectile;
									valueRW2.anticipationDuration = 2f;
									valueRW2.attackDuration = 2f;
									valueRW2.goUpTime = 0f;
									valueRW2.airTime = 0f;
									valueRW2.goDownTime = 1.5f;
									valueRW2.airTimeAdditionBetweenProjectiles = 0f;
									valueRW2.explodeTime = 0f;
									valueRW2.minAmountOfProjectiles = 1;
									valueRW2.maxAmountOfProjectiles = 1;
									valueRW2.maxProjectilesShotPerWave = 1;
									valueRW2.dontAllowOverlappingShots = true;
									valueRW2.timeBetweenProjectiles = 0f;
									valueRW2.minRandomSpreadDistance = 0f;
									valueRW2.maxRandomSpreadDistance = 5f;
									valueRW2.overridePositionToShootAt = true;
									valueRW2.overrideShootPosition = valueRW3.midLocation.RoundToInt3();
									valueRW2.lineFromShooterToTarget = false;
									valueRW2.lineBendTowardTarget = false;
									valueRW2.lineLengthMultiplier = 0f;
									valueRW2.keepShootingUntilTakingDamageXTimes = 0;
									valueRW2.shootAtSelf = false;
									valueRW2.hitTiles = false;
									valueRW2.overrideAnimID = -324069807;
									valueRW2.isDisabled = false;
									valueRW2.minCooldown = num4;
									valueRW2.maxCooldown = num5;
									valueRW2.mortarDamage = valueRW.iceShardMortarDamage;
									valueRW2.canShootOnWaterAndPits = true;
									valueRW2.destroyProjectilesWhenNotInState = false;
									valueRW.hasPreparedNextMortarShots = true;
								}
								valueRW.patternCounter++;
							}
						}
						else if (objectDataCD.objectID == ObjectID.HydraBossNature && (valueRW.patternCounter + 2) % (3 + num3) == 0)
						{
							if (!flag3)
							{
								valueRW2.mortarProjectileID = ObjectID.HydraBossStalactiteMortarProjectile;
								valueRW2.anticipationDuration = 0f;
								valueRW2.attackDuration = 4f;
								valueRW2.goUpTime = 0f;
								valueRW2.airTime = 0f;
								valueRW2.goDownTime = 3f;
								valueRW2.airTimeAdditionBetweenProjectiles = 0f;
								valueRW2.explodeTime = 0f;
								valueRW2.minAmountOfProjectiles = 5;
								valueRW2.maxAmountOfProjectiles = 5;
								valueRW2.maxProjectilesShotPerWave = 5;
								valueRW2.dontAllowOverlappingShots = true;
								valueRW2.timeBetweenProjectiles = 0f;
								valueRW2.minRandomSpreadDistance = 0f;
								valueRW2.maxRandomSpreadDistance = 7f;
								valueRW2.overridePositionToShootAt = false;
								valueRW2.lineFromShooterToTarget = false;
								valueRW2.lineBendTowardTarget = false;
								valueRW2.lineLengthMultiplier = 0f;
								valueRW2.keepShootingUntilTakingDamageXTimes = 0;
								valueRW2.shootAtSelf = false;
								valueRW2.hitTiles = false;
								valueRW2.overrideAnimID = 1743784265;
								valueRW2.isDisabled = false;
								valueRW2.minCooldown = 1f;
								valueRW2.maxCooldown = 1f;
								valueRW2.mortarDamage = valueRW.stalactiteMortarDamage;
								valueRW2.canShootOnWaterAndPits = true;
								valueRW2.destroyProjectilesWhenNotInState = false;
								valueRW.hasPreparedNextMortarShots = true;
								valueRW.patternCounter++;
							}
						}
						else if (objectDataCD.objectID == ObjectID.HydraBossNature && valueRW2.mortarProjectileID == ObjectID.HydraBossStalactiteMortarProjectile)
						{
							valueRW2.mortarProjectileID = ObjectID.HydraBossShockwaveMortarProjectile;
							valueRW2.anticipationDuration = 0f;
							valueRW2.attackDuration = 7f;
							valueRW2.goUpTime = 0f;
							valueRW2.airTime = 0f;
							valueRW2.goDownTime = 5f;
							valueRW2.airTimeAdditionBetweenProjectiles = 0f;
							valueRW2.explodeTime = 0f;
							valueRW2.minAmountOfProjectiles = 1;
							valueRW2.maxAmountOfProjectiles = 1;
							valueRW2.maxProjectilesShotPerWave = 1;
							valueRW2.dontAllowOverlappingShots = false;
							valueRW2.timeBetweenProjectiles = 0f;
							valueRW2.minRandomSpreadDistance = 0f;
							valueRW2.maxRandomSpreadDistance = 0f;
							valueRW2.overridePositionToShootAt = false;
							valueRW2.lineFromShooterToTarget = false;
							valueRW2.lineBendTowardTarget = false;
							valueRW2.lineLengthMultiplier = 0f;
							valueRW2.keepShootingUntilTakingDamageXTimes = 0;
							valueRW2.shootAtSelf = true;
							valueRW2.hitTiles = true;
							valueRW2.overrideAnimID = 284637663;
							valueRW2.isDisabled = false;
							valueRW2.minCooldown = num4;
							valueRW2.maxCooldown = num5;
							valueRW2.mortarDamage = valueRW.shockwaveDamage;
							valueRW2.mortarTileDamage = 10000;
							valueRW2.canShootOnWaterAndPits = true;
							valueRW2.destroyProjectilesWhenNotInState = true;
							valueRW.hasPreparedNextMortarShots = true;
						}
						else if (objectDataCD.objectID == ObjectID.HydraBossNature && num2 == 1 && (valueRW.patternCounter + 1) % 3 == 0)
						{
							valueRW2.mortarProjectileID = ObjectID.HydraBossSpawnNilipedeMortarProjectile;
							valueRW2.anticipationDuration = 0f;
							valueRW2.attackDuration = 4f;
							valueRW2.goUpTime = 0f;
							valueRW2.airTime = 0f;
							valueRW2.goDownTime = 2f;
							valueRW2.airTimeAdditionBetweenProjectiles = 0f;
							valueRW2.explodeTime = 0f;
							valueRW2.minAmountOfProjectiles = 1;
							valueRW2.maxAmountOfProjectiles = 1;
							valueRW2.maxProjectilesShotPerWave = 1;
							valueRW2.dontAllowOverlappingShots = false;
							valueRW2.timeBetweenProjectiles = 0f;
							valueRW2.minRandomSpreadDistance = 0f;
							valueRW2.maxRandomSpreadDistance = 0f;
							valueRW2.overridePositionToShootAt = false;
							valueRW2.lineFromShooterToTarget = false;
							valueRW2.lineBendTowardTarget = false;
							valueRW2.lineLengthMultiplier = 0f;
							valueRW2.keepShootingUntilTakingDamageXTimes = 0;
							valueRW2.shootAtSelf = false;
							valueRW2.hitTiles = false;
							valueRW2.overrideAnimID = 1743784265;
							valueRW2.isDisabled = false;
							valueRW2.minCooldown = num4;
							valueRW2.maxCooldown = num5;
							valueRW2.mortarDamage = valueRW.nilipedeMortarDamage;
							valueRW2.mortarTileDamage = 0;
							valueRW2.canShootOnWaterAndPits = false;
							valueRW2.destroyProjectilesWhenNotInState = true;
							valueRW.hasPreparedNextMortarShots = true;
							valueRW.patternCounter++;
						}
						else if (objectDataCD.objectID == ObjectID.HydraBossVoid && (valueRW.patternCounter + 1) % 2 == 0)
						{
							valueRW2.mortarProjectileID = ObjectID.MovingVoidTrapMortarProjectile;
							valueRW2.anticipationDuration = 0f;
							valueRW2.attackDuration = 4f;
							valueRW2.goUpTime = 0f;
							valueRW2.airTime = 0f;
							valueRW2.goDownTime = 2f;
							valueRW2.airTimeAdditionBetweenProjectiles = 0f;
							valueRW2.explodeTime = 0f;
							valueRW2.minAmountOfProjectiles = 2;
							valueRW2.maxAmountOfProjectiles = 3;
							valueRW2.maxProjectilesShotPerWave = 3;
							valueRW2.dontAllowOverlappingShots = false;
							valueRW2.timeBetweenProjectiles = 0f;
							valueRW2.minRandomSpreadDistance = 0f;
							valueRW2.maxRandomSpreadDistance = 0f;
							valueRW2.overridePositionToShootAt = false;
							valueRW2.lineFromShooterToTarget = false;
							valueRW2.lineBendTowardTarget = false;
							valueRW2.lineLengthMultiplier = 0f;
							valueRW2.keepShootingUntilTakingDamageXTimes = 0;
							valueRW2.shootAtSelf = false;
							valueRW2.hitTiles = false;
							valueRW2.overrideAnimID = 1743784265;
							valueRW2.isDisabled = false;
							valueRW2.minCooldown = num4;
							valueRW2.maxCooldown = num5;
							valueRW2.mortarDamage = valueRW.nilipedeMortarDamage;
							valueRW2.mortarTileDamage = 0;
							valueRW2.canShootOnWaterAndPits = true;
							valueRW2.destroyProjectilesWhenNotInState = true;
							valueRW.hasPreparedNextMortarShots = true;
							valueRW.patternCounter++;
						}
						else
						{
							valueRW2.mortarProjectileID = ObjectID.HydraBossBeamMortarProjectile;
							valueRW2.anticipationDuration = 3f;
							valueRW2.attackDuration = 2f;
							valueRW2.goUpTime = 0f;
							valueRW2.airTime = 0f;
							valueRW2.goDownTime = 0f;
							valueRW2.airTimeAdditionBetweenProjectiles = 0f;
							valueRW2.explodeTime = 0f;
							valueRW2.minAmountOfProjectiles = 35 - num2 * 5;
							valueRW2.maxAmountOfProjectiles = 35 - num2 * 5;
							valueRW2.maxProjectilesShotPerWave = 1;
							valueRW2.dontAllowOverlappingShots = false;
							valueRW2.timeBetweenProjectiles = 0.2f;
							valueRW2.minRandomSpreadDistance = 0f;
							valueRW2.maxRandomSpreadDistance = 0f;
							valueRW2.overridePositionToShootAt = true;
							valueRW2.lineFromShooterToTarget = false;
							valueRW2.lineBendTowardTarget = false;
							valueRW2.lineLengthMultiplier = 0f;
							valueRW2.keepShootingUntilTakingDamageXTimes = 0;
							valueRW2.shootAtSelf = false;
							valueRW2.hitTiles = true;
							valueRW2.overrideAnimID = 669154430;
							valueRW2.isDisabled = false;
							valueRW2.minCooldown = num4;
							valueRW2.maxCooldown = num5;
							valueRW2.mortarDamage = valueRW.beamDamage;
							valueRW2.canShootOnWaterAndPits = true;
							valueRW2.destroyProjectilesWhenNotInState = false;
							valueRW.hasPreparedNextMortarShots = true;
							valueRW.patternCounter++;
						}
					}
				}
				else if (stateInfo.IsCurrentState(StateID.ShootMortarProjectile))
				{
					valueRW.hasPreparedNextMortarShots = false;
				}
			}
			else
			{
				if (flag)
				{
					if (appearPositionsLookUp.HasComponent(entity) && appearPositionsLookUp[entity].Length > 0)
					{
						ecb.SetBuffer<HydraCombatAppearPositionsBuffer>(entity);
					}
					if (hydrasLookUp.HasComponent(entity) && hydrasLookUp[entity].Length > 0)
					{
						for (int k = 0; k < hydrasLookUp[entity].Length; k++)
						{
							if (hydrasLookUp[entity][k].hydra != entity)
							{
								ecb.DestroyEntity(hydrasLookUp[entity][k].hydra);
							}
						}
						ecb.SetBuffer<HydrasBuffer>(entity);
						ecb.AppendToBuffer(entity, new HydrasBuffer
						{
							hydra = entity
						});
					}
				}
				valueRW2.isDisabled = true;
				meleeAttackState.isDisabled = true;
				valueRW.hasPreparedNextMortarShots = false;
				valueRW.patternCounter = 0;
			}
			float3 position2 = localTransformLookup[entity].Position;
			if (math.all(valueRW.pointToLookAt == float3.zero))
			{
				valueRW.pointToLookAt = position2 + new float3(0f, 0f, -5f);
			}
			float3 float8 = valueRW.pointToLookAt;
			LocalTransform componentData3;
			if (animationBufferLookup[entity].GetLastAddedElement<AnimationBuffer, AnimationBufferPointer>(animationBufferPointerLookup[entity]).animID == 1819704882)
			{
				valueRW.pointToLookAt = position2 + new float3(0f, 0f, -5f);
			}
			else if (stateInfo.IsCurrentState(StateID.MeleeAttack))
			{
				float8 = position2 + meleeAttackState.hitDirection * objectPropertiesCD.Get<float>(-1904742027);
			}
			else if (stateInfo.IsCurrentState(StateID.ShootMortarProjectile))
			{
				if (valueRW2.mortarProjectileID == ObjectID.HydraBossBeamMortarProjectile)
				{
					Entity aimingAtEntity = valueRW2.aimingAtEntity;
					if (aimingAtEntity != Entity.Null && localTransformLookup.TryGetComponent(aimingAtEntity, out var componentData2))
					{
						float8 = componentData2.Position;
					}
				}
				else if (valueRW2.mortarProjectileID == ObjectID.HydraBossIceShardMortarProjectile)
				{
					float8 = valueRW2.overrideShootPosition;
				}
				else if (valueRW2.mortarProjectileID == ObjectID.HydraBossLavaMortarProjectile)
				{
					float8 = valueRW2.initialShootPosition;
				}
			}
			else if (stateInfo.IsCurrentState(StateID.HydraBossBuriedCombat))
			{
				if (math.distancesq(valueRW3.targetLocation, position2) > 4f)
				{
					float8 = valueRW3.targetLocation;
				}
			}
			else if (stateInfo.IsCurrentState(StateID.HydraBossBuriedRoaming))
			{
				if (math.distancesq(valueRW3.targetLocation, position2) > 4f)
				{
					float8 = buriedRoaming.targetLocation;
				}
			}
			else if (System.Math.Abs(valueRW3.cooldownTimer.lifespan - 4f) > 1.1920929E-07f && distanceToPlayerLookUp[entity].minDistanceSq < 900f && localTransformLookup.TryGetComponent(distanceToPlayerLookUp[entity].closestPlayer, out componentData3))
			{
				float8 = componentData3.Position;
			}
			if (math.any(float8 != float3.zero) && !stateInfo.IsCurrentState(StateID.Vulnerable) && !stateInfo.IsCurrentState(StateID.Death))
			{
				float3 x = float8 - valueRW.pointToLookAt;
				float num8 = math.length(x);
				float3 float9 = math.normalizesafe(x);
				valueRW.pointToLookAt += float9 * deltaTime * num8 * 2f;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MeleeAttackStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MainHydraRefCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__HydraBossBuriedRoamingStateCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MeleeAttackStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MainHydraRefCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr5, k));
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
		typeof(IsInCombatCD),
		typeof(LocalTransform)
	})]
	private struct HydraBossBeamAttackJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HydraBossCD> __HydraBossCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ShootMortarProjectileStateCD>();
					__HydraBossCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HydraBossCD>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ShootMortarProjectileStateCD_RW_ComponentTypeHandle.Update(ref state);
					__HydraBossCD_RW_ComponentTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<IsInCombatCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ShootMortarProjectileStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HydraBossCD>();
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
			public void Run(ref HydraBossBeamAttackJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HydraBossBeamAttackJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HydraBossBeamAttackJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HydraBossBeamAttackJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HydraBossBeamAttackJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HydraBossBeamAttackJob job, EntityManager entityManager)
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
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> playerGhostExtrapolatedLookup;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref ShootMortarProjectileStateCD mortarState, ref HydraBossCD hydra, in StateInfoCD stateInfo)
		{
			if (stateInfo.IsCurrentState(StateID.ShootMortarProjectile) && mortarState.mortarProjectileID == ObjectID.HydraBossBeamMortarProjectile && localTransformLookup.HasComponent(mortarState.aimingAtEntity))
			{
				Entity entity2 = mortarState.aimingAtEntity;
				if (playerGhostExtrapolatedLookup.TryGetComponent(mortarState.aimingAtEntity, out var componentData))
				{
					Entity playerGhost = componentData.playerGhost;
					if (localTransformLookup.HasComponent(playerGhost))
					{
						entity2 = playerGhost;
					}
				}
				float3 position = localTransformLookup[entity].Position;
				bool isShootingBeam = false;
				if (mortarState.internalState == 1 && mortarState.waveCount == 0)
				{
					float3 float5 = math.normalizesafe(localTransformLookup[entity2].Position - position);
					mortarState.overrideShootPosition = position + float5 * 2f;
					isShootingBeam = true;
				}
				else if (mortarState.internalState == 1 && mortarState.waveCount > 0)
				{
					float3 x = localTransformLookup[entity2].Position - mortarState.overrideShootPosition;
					float valueToClamp = math.length(x);
					float3 float6 = math.normalizesafe(x);
					mortarState.overrideShootPosition += float6 * deltaTime * 2f * math.pow(1.1f, mortarState.waveCount) * math.clamp(valueToClamp, 0f, 1f);
					isShootingBeam = true;
				}
				hydra.beamTargetPoint = mortarState.overrideShootPosition;
				hydra.isShootingBeam = isShootingBeam;
			}
			else
			{
				hydra.isShootingBeam = false;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HydraBossCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ShootMortarProjectileStateCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k));
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
		typeof(BehaviourTagsCD),
		typeof(AnimationBuffer),
		typeof(AnimationBufferPointer),
		typeof(LocalTransform),
		typeof(HydraBossBuriedCombatStateCD)
	})]
	private struct HydraBossBuriedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossBuriedCombatStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
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
			public void Run(ref HydraBossBuriedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HydraBossBuriedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HydraBossBuriedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HydraBossBuriedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HydraBossBuriedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HydraBossBuriedJob job, EntityManager entityManager)
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

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> isInCombatLookup;

		[ReadOnly]
		public ComponentLookup<MainHydraRefCD> mainHydraRefLookup;

		[ReadOnly]
		public BufferLookup<HydraCombatAppearPositionsBuffer> appearPositionsLookUp;

		[ReadOnly]
		public BufferLookup<HydrasBuffer> hydrasLookUp;

		public ComponentLookup<HydraBossBuriedCombatStateCD> hydraBossBuriedStateLookUp;

		public EntityCommandBuffer ecb;

		public Entity tileDamageBufferEntity;

		public Entity effectEventBufferSingleton;

		public NetworkTick currentTick;

		public double time;

		public Unity.Mathematics.Random rng;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, in MovementSpeedCD movementSpeed)
		{
			BehaviourTagsCD behaviourTags = attackHelper.behaviourTagsLookup[entity];
			DynamicBuffer<AnimationBuffer> animationBuffer = attackHelper.animationBufferLookup[entity];
			ref AnimationBufferPointer valueRW = ref attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			ref LocalTransform valueRW2 = ref attackHelper.localTransformLookup.GetRefRW(entity).ValueRW;
			ref HydraBossBuriedCombatStateCD valueRW3 = ref hydraBossBuriedStateLookUp.GetRefRW(entity).ValueRW;
			if (!stateInfo.IsCurrentState(StateID.HydraBossBuriedCombat))
			{
				valueRW3.internalState = 0;
				if (isInCombatLookup.TryGetComponent(entity, out var componentData) && !componentData.isInCombat && !valueRW3.cooldownTimer.isRunning)
				{
					valueRW3.cooldownTimer.Start(time, rng.NextFloat(valueRW3.minCooldown, valueRW3.maxCooldown));
				}
			}
			else if (valueRW3.internalState == 0)
			{
				valueRW3.internalState = 1;
				AnimationUtilities.TriggerAnimation(-696149821, currentTick, animationBuffer, ref valueRW);
				valueRW3.timer.Start(time, valueRW3.buryDuration);
			}
			else if (valueRW3.internalState == 1 && valueRW3.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(296338006, currentTick, animationBuffer, ref valueRW);
				valueRW3.internalState = 2;
				MainHydraRefCD mainHydraRefCD = mainHydraRefLookup[entity];
				if (appearPositionsLookUp.HasComponent(mainHydraRefCD.mainHydra) && appearPositionsLookUp[mainHydraRefCD.mainHydra].Length > 0 && hydrasLookUp.HasComponent(mainHydraRefCD.mainHydra))
				{
					DynamicBuffer<HydraCombatAppearPositionsBuffer> dynamicBuffer = appearPositionsLookUp[mainHydraRefCD.mainHydra];
					DynamicBuffer<HydrasBuffer> dynamicBuffer2 = hydrasLookUp[mainHydraRefCD.mainHydra];
					int num = rng.NextInt(0, dynamicBuffer.Length);
					for (int i = 0; i < dynamicBuffer.Length; i++)
					{
						num = (num + 1) % dynamicBuffer.Length;
						bool flag = true;
						for (int j = 0; j < dynamicBuffer2.Length; j++)
						{
							if (hydraBossBuriedStateLookUp.HasComponent(dynamicBuffer2[j].hydra) && num == hydraBossBuriedStateLookUp[dynamicBuffer2[j].hydra].currentLocationIndex)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					valueRW3.currentLocationIndex = num;
					valueRW3.targetLocation = dynamicBuffer[valueRW3.currentLocationIndex].pos;
				}
				else
				{
					valueRW3.targetLocation = valueRW2.Position;
				}
				valueRW3.startLocation = valueRW2.Position;
			}
			else if (valueRW3.internalState == 2)
			{
				if (math.distance(valueRW3.targetLocation, valueRW2.Position) < 0.5f)
				{
					valueRW3.internalState = 3;
					return;
				}
				float3 float5 = math.normalizesafe(valueRW3.targetLocation - valueRW2.Position);
				float num2 = 1f;
				valueRW2.Position += float5 * deltaTime * num2 * movementSpeed.speed;
				float num3 = math.distance(valueRW2.Position, valueRW3.startLocation);
				float num4 = math.distance(valueRW2.Position, valueRW3.targetLocation);
				if (!(num3 > 3.5f) || !(num4 > 3.5f))
				{
					return;
				}
				float2 float6 = new float2(valueRW2.Position.x, valueRW2.Position.z);
				int2 int5 = new int2((int)math.round(float6.x), (int)math.round(float6.y));
				int num5 = 2;
				for (int k = -num5; k <= num5; k++)
				{
					for (int l = -num5; l <= num5; l++)
					{
						int2 int6 = new int2(k, l) + int5;
						if (math.distance(int6, int5) <= 2f)
						{
							ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
							{
								damage = 10000,
								position = int6,
								skipWallAndRootsLootDropOnDestroy = true,
								canHitLowColliders = true,
								bypassDamageReduction = true
							});
						}
					}
				}
			}
			else if (valueRW3.internalState == 3)
			{
				valueRW3.internalState = 4;
				if (math.distancesq(valueRW2.Position, valueRW3.targetLocation) < 10f)
				{
					valueRW2.Position = valueRW3.targetLocation;
				}
				AnimationUtilities.TriggerAnimation(-1664757979, currentTick, animationBuffer, ref valueRW);
				valueRW3.timer.Start(time, valueRW3.unearthDuration);
				float2 float7 = new float2(valueRW2.Position.x, valueRW2.Position.z);
				int2 int7 = new int2((int)math.round(float7.x), (int)math.round(float7.y));
				int num6 = 3;
				for (int m = -num6; m <= num6; m++)
				{
					for (int n = -num6; n <= num6; n++)
					{
						int2 int8 = new int2(m, n) + int7;
						if (math.distance(int8, int7) <= 3f)
						{
							ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
							{
								damage = 10000,
								position = int8,
								skipWallAndRootsLootDropOnDestroy = true,
								canHitLowColliders = true,
								bypassDamageReduction = true
							});
						}
					}
				}
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBufferSingleton,
					attacker = entity,
					isRanged = false,
					attackOffset = new float3(0.5f, 0f, 1f),
					canHitLowTriggers = true,
					radius = 2f,
					damage = valueRW3.buriedAppearDamage,
					playerDamage = valueRW3.buriedAppearDamage,
					pushback = 2f,
					bypassMaxDamagePerHit = true,
					skipWallAndRootsLootDropOnDestroy = true,
					skipLootDropOnDestroy = true,
					behaviourTags = behaviourTags
				};
				attackHelper.Attack(ecb, in p);
			}
			else if (valueRW3.internalState == 4 && valueRW3.timer.IsTimerElapsed(time))
			{
				stateInfo.LeaveState();
				valueRW3.cooldownTimer.Start(time, rng.NextFloat(valueRW3.minCooldown, valueRW3.maxCooldown));
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, k));
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
		typeof(MovementSpeedCD),
		typeof(HydraBossCD)
	})]
	private struct HydraBossRoamingJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BaitableCD> __BaitableCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<HydraBossBuriedRoamingStateCD> __HydraBossBuriedRoamingStateCD_RW_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BehaviourTagsCD> __BehaviourTagsCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<RoamingPathBuffer> __RoamingPathBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__BaitableCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BaitableCD>(isReadOnly: true);
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__HydraBossBuriedRoamingStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HydraBossBuriedRoamingStateCD>();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
					__RoamingPathBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<RoamingPathBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__BaitableCD_RO_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__HydraBossBuriedRoamingStateCD_RW_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
					__RoamingPathBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BaitableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RoamingPathBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<HydraBossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HydraBossBuriedRoamingStateCD>();
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
			public void Run(ref HydraBossRoamingJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HydraBossRoamingJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HydraBossRoamingJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HydraBossRoamingJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HydraBossRoamingJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HydraBossRoamingJob job, EntityManager entityManager)
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
		public ComponentLookup<ForceInCombatCD> forceInCombatLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> summarizedConditionsLookUp;

		public ComponentLookup<LocalTransform> translationLookUp;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> movementSpeedLookup;

		public NetworkTick currentTick;

		public EntityCommandBuffer ecb;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in BaitableCD baitableCD, ref StateInfoCD stateInfo, ref HydraBossBuriedRoamingStateCD buriedState, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in BehaviourTagsCD attackTags, in DynamicBuffer<RoamingPathBuffer> roamingPath)
		{
			ref LocalTransform valueRW = ref translationLookUp.GetRefRW(entity).ValueRW;
			if (!stateInfo.IsCurrentState(StateID.HydraBossBuriedRoaming) || roamingPath.Length == 0)
			{
				buriedState.internalState = 0;
				return;
			}
			if ((healthLookup.TryGetComponent(entity, out var componentData) && !componentData.HasFullHealth) || forceInCombatLookup.HasComponent(entity))
			{
				stateInfo.LeaveState();
				return;
			}
			int num = (int)math.round((float)healthLookup[entity].maxHealth * 0.3f);
			if (summarizedConditionsLookUp.HasComponent(entity) && summarizedConditionsLookUp[entity][98].value < num)
			{
				EntityUtility.AddNewCondition(entity, ecb, new ConditionData
				{
					conditionID = ConditionID.ProtectiveArmor,
					duration = float.PositiveInfinity,
					value = num
				});
			}
			if (buriedState.internalState == 0)
			{
				buriedState.internalState = 1;
				AnimationUtilities.TriggerAnimation(-696149821, currentTick, animationBuffer, ref animationBufferPointer);
				buriedState.timer.Start(time, buriedState.buryDuration);
			}
			if (buriedState.internalState == 1 && buriedState.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(296338006, currentTick, animationBuffer, ref animationBufferPointer);
				buriedState.internalState = 2;
				buriedState.currentLocationIndex++;
				if (buriedState.currentLocationIndex >= roamingPath.Length)
				{
					buriedState.currentLocationIndex = 0;
				}
				float3 targetLocation = roamingPath[buriedState.currentLocationIndex].Value;
				if (baitableCD.baitEntity != Entity.Null && translationLookUp.HasComponent(baitableCD.baitEntity))
				{
					targetLocation = translationLookUp[baitableCD.baitEntity].Position;
				}
				buriedState.targetLocation = targetLocation;
				buriedState.startLocation = valueRW.Position;
			}
			if (buriedState.internalState == 2)
			{
				float3 float5 = buriedState.targetLocation;
				if (baitableCD.baitEntity != Entity.Null && translationLookUp.HasComponent(baitableCD.baitEntity))
				{
					float5 = translationLookUp[baitableCD.baitEntity].Position;
				}
				float speed = movementSpeedLookup[entity].speed;
				float3 float6 = math.normalizesafe(float5 - valueRW.Position);
				valueRW.Position += float6 * deltaTime * speed;
				if (math.distance(float5, valueRW.Position) < 1f)
				{
					buriedState.internalState = 1;
				}
			}
			if (buriedState.internalState == 4 && buriedState.timer.IsTimerElapsed(time))
			{
				stateInfo.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BaitableCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__HydraBossBuriedRoamingStateCD_RW_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			BufferAccessor<RoamingPathBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__RoamingPathBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref BaitableCD baitableCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr2, i);
					ref StateInfoCD stateInfo = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, i);
					ref HydraBossBuriedRoamingStateCD buriedState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, in baitableCD, ref stateInfo, ref buriedState, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, i), bufferAccessor2[i]);
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
						ref BaitableCD baitableCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr2, nextRangeBegin);
						ref StateInfoCD stateInfo2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, nextRangeBegin);
						ref HydraBossBuriedRoamingStateCD buriedState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, in baitableCD2, ref stateInfo2, ref buriedState2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, nextRangeBegin), bufferAccessor2[nextRangeBegin]);
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
					ref BaitableCD baitableCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr2, j);
					ref StateInfoCD stateInfo3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, j);
					ref HydraBossBuriedRoamingStateCD buriedState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, in baitableCD3, ref stateInfo3, ref buriedState3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, j), bufferAccessor2[j]);
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
					ref BaitableCD baitableCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BaitableCD>(nativeArrayPtr2, k);
					ref StateInfoCD stateInfo4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, k);
					ref HydraBossBuriedRoamingStateCD buriedState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HydraBossBuriedRoamingStateCD>(nativeArrayPtr4, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, in baitableCD4, ref stateInfo4, ref buriedState4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr6, k), bufferAccessor2[k]);
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
		public SpawnVulnerableHydraJob.InternalCompilerQueryAndHandleData __HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle;

		public CleanupNonMainHydrasJob.InternalCompilerQueryAndHandleData __HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HydraBossBaitCD> __HydraBossBaitCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AttackCooldownTimerCD> __AttackCooldownTimerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MovementSpeedCD> __MovementSpeedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ForceInCombatCD> __ForceInCombatCD_RO_ComponentLookup;

		public HydraBossStateUpdateJob.InternalCompilerQueryAndHandleData __HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

		public KillNonMainHydraJob.InternalCompilerQueryAndHandleData __HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<MainHydraCD> __MainHydraCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<HydraCombatAppearPositionsBuffer> __HydraCombatAppearPositionsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<HydrasBuffer> __HydrasBuffer_RO_BufferLookup;

		public ComponentLookup<ShootMortarProjectileStateCD> __ShootMortarProjectileStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossBuriedCombatStateCD> __HydraBossBuriedCombatStateCD_RW_ComponentLookup;

		public ComponentLookup<HydraBossCD> __HydraBossCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<AnimationBuffer> __AnimationBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HydraVulnerableEntityCreatedCD> __HydraBossSystem_HydraVulnerableEntityCreatedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HydraBossVulnerableEntityCD> __HydraBossVulnerableEntityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<VulnerableStateCD> __VulnerableStateCD_RO_ComponentLookup;

		public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

		public HydraBossUpdateJob.InternalCompilerQueryAndHandleData __HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<PlayerGhostExtrapolated> __PlayerGhostExtrapolated_RO_ComponentLookup;

		public HydraBossBeamAttackJob.InternalCompilerQueryAndHandleData __HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<MainHydraRefCD> __MainHydraRefCD_RO_ComponentLookup;

		public HydraBossBuriedJob.InternalCompilerQueryAndHandleData __HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

		public HydraBossRoamingJob.InternalCompilerQueryAndHandleData __HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__HydraBossBaitCD_RO_ComponentLookup = state.GetComponentLookup<HydraBossBaitCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__ShootMortarProjectileStateCD_RO_ComponentLookup = state.GetComponentLookup<ShootMortarProjectileStateCD>(isReadOnly: true);
			__AttackCooldownTimerCD_RO_ComponentLookup = state.GetComponentLookup<AttackCooldownTimerCD>(isReadOnly: true);
			__MovementSpeedCD_RO_ComponentLookup = state.GetComponentLookup<MovementSpeedCD>(isReadOnly: true);
			__ForceInCombatCD_RO_ComponentLookup = state.GetComponentLookup<ForceInCombatCD>(isReadOnly: true);
			__HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__MainHydraCD_RO_ComponentLookup = state.GetComponentLookup<MainHydraCD>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__IsInCombatCD_RO_ComponentLookup = state.GetComponentLookup<IsInCombatCD>(isReadOnly: true);
			__HydraCombatAppearPositionsBuffer_RO_BufferLookup = state.GetBufferLookup<HydraCombatAppearPositionsBuffer>(isReadOnly: true);
			__HydrasBuffer_RO_BufferLookup = state.GetBufferLookup<HydrasBuffer>(isReadOnly: true);
			__ShootMortarProjectileStateCD_RW_ComponentLookup = state.GetComponentLookup<ShootMortarProjectileStateCD>();
			__HydraBossBuriedCombatStateCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossBuriedCombatStateCD>();
			__HydraBossCD_RW_ComponentLookup = state.GetComponentLookup<HydraBossCD>();
			__AnimationBufferPointer_RO_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>(isReadOnly: true);
			__AnimationBuffer_RO_BufferLookup = state.GetBufferLookup<AnimationBuffer>(isReadOnly: true);
			__DistanceToPlayerCD_RO_ComponentLookup = state.GetComponentLookup<DistanceToPlayerCD>(isReadOnly: true);
			__HydraBossSystem_HydraVulnerableEntityCreatedCD_RO_ComponentLookup = state.GetComponentLookup<HydraVulnerableEntityCreatedCD>(isReadOnly: true);
			__HydraBossVulnerableEntityCD_RO_ComponentLookup = state.GetComponentLookup<HydraBossVulnerableEntityCD>(isReadOnly: true);
			__VulnerableStateCD_RO_ComponentLookup = state.GetComponentLookup<VulnerableStateCD>(isReadOnly: true);
			__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
			__HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__PlayerGhostExtrapolated_RO_ComponentLookup = state.GetComponentLookup<PlayerGhostExtrapolated>(isReadOnly: true);
			__HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__MainHydraRefCD_RO_ComponentLookup = state.GetComponentLookup<MainHydraRefCD>(isReadOnly: true);
			__HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
			__HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000928_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000928_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000928_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000929_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000929_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000929_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_0000092A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_0000092A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000092A_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_0000092B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_0000092B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000092B_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private const int HYDRA_DISTANCE_SQ_TO_PLAYER_TO_RESET_AND_LEAVE_COMBAT = 10000;

	private const int HYDRA_DISTANCE_TO_PLAYER_TO_ENTER_COMBAT = 80;

	private const int HYDRA_DISTANCE_SQ_TO_PLAYER_TO_ENTER_COMBAT = 6400;

	private const int HYDRA_DISTANCE_SQ_TO_MOVE_TO_BAIT = 90000;

	private const int HYDRA_DISTANCE_SQ_TO_BAIT_TO_EAT_IT = 1;

	private EntityQuery _hydraBaitQuery;

	private BiomeLookup _biomeLookup;

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_356319590_0;

	private EntityQuery __query_356319590_1;

	private EntityQuery __query_356319590_2;

	private EntityQuery __query_356319590_3;

	private EntityQuery __query_356319590_4;

	private EntityQuery __query_356319590_5;

	private EntityQuery __query_356319590_6;

	private EntityQuery __query_356319590_7;

	private EntityQuery __query_356319590_8;

	private EntityQuery __query_356319590_9;

	private EntityQuery __query_356319590_10;

	private EntityQuery __query_356319590_11;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate(__query_356319590_0);
		_hydraBaitQuery = __query_356319590_1;
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_biomeLookup = (__query_356319590_2.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_356319590_3.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
		int simulationTickRate = __query_356319590_4.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper = new AttackSystem.Helper(ref state, simulationTickRate);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_356319590_5.TryGetSingleton<NetworkTime>(out var value);
		int simulationTickRate = __query_356319590_4.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper.Update(ref state, value.ServerTick, (uint)simulationTickRate);
		EntityCommandBuffer ecb = __query_356319590_6.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		ecb.AddComponent<BaitCheckedCD>(_hydraBaitQuery, EntityQueryCaptureMode.AtRecord);
		JobHandle outJobHandle;
		NativeList<Entity> newHydraBaits = _hydraBaitQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new SpawnVulnerableHydraJob
		{
			ecb = ecb
		}, __TypeHandle.__HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new CleanupNonMainHydrasJob
		{
			ecb = ecb
		}, __TypeHandle.__HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		JobHandle dependency = JobHandle.CombineDependencies(state.Dependency, outJobHandle);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new HydraBossStateUpdateJob
		{
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			hydraBossBaitLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBaitCD_RO_ComponentLookup, ref state),
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
			newHydraBaits = newHydraBaits,
			shootMortarProjectileStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShootMortarProjectileStateCD_RO_ComponentLookup, ref state),
			attackCooldownTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AttackCooldownTimerCD_RO_ComponentLookup, ref state),
			movementSpeedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MovementSpeedCD_RO_ComponentLookup, ref state),
			forceInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ForceInCombatCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			biomeLookup = _biomeLookup,
			effectEventBufferSingleton = __query_356319590_7.GetSingletonEntity(),
			healthChangeBufferEntity = __query_356319590_8.GetSingletonEntity(),
			tileDamageBufferEntity = __query_356319590_9.GetSingletonEntity(),
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime
		}, __TypeHandle.__HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new KillNonMainHydraJob
		{
			entityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state)
		}, __TypeHandle.__HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new HydraBossUpdateJob
		{
			mainHydraLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MainHydraCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
			summarizedConditionsLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			isInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsInCombatCD_RO_ComponentLookup, ref state),
			appearPositionsLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HydraCombatAppearPositionsBuffer_RO_BufferLookup, ref state),
			hydrasLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HydrasBuffer_RO_BufferLookup, ref state),
			mortarStateLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ShootMortarProjectileStateCD_RW_ComponentLookup, ref state),
			buriedCombatLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBuriedCombatStateCD_RW_ComponentLookup, ref state),
			attackCooldownTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AttackCooldownTimerCD_RO_ComponentLookup, ref state),
			hydraBossLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossCD_RW_ComponentLookup, ref state),
			animationBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RO_ComponentLookup, ref state),
			animationBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AnimationBuffer_RO_BufferLookup, ref state),
			distanceToPlayerLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup, ref state),
			hydraVulnerableEntityCreatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossSystem_HydraVulnerableEntityCreatedCD_RO_ComponentLookup, ref state),
			hydraBossVulnerableEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossVulnerableEntityCD_RO_ComponentLookup, ref state),
			vulnerableStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VulnerableStateCD_RO_ComponentLookup, ref state),
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			collisionWorld = __query_356319590_10.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			databaseBankCD = __query_356319590_11.GetSingleton<PugDatabase.DatabaseBankCD>(),
			tileDamageBufferEntity = __query_356319590_9.GetSingletonEntity(),
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_5(new HydraBossBeamAttackJob
		{
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			playerGhostExtrapolatedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhostExtrapolated_RO_ComponentLookup, ref state),
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_6(new HydraBossBuriedJob
		{
			attackHelper = _attackHelper,
			isInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsInCombatCD_RO_ComponentLookup, ref state),
			mainHydraRefLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MainHydraRefCD_RO_ComponentLookup, ref state),
			appearPositionsLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HydraCombatAppearPositionsBuffer_RO_BufferLookup, ref state),
			hydrasLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__HydrasBuffer_RO_BufferLookup, ref state),
			hydraBossBuriedStateLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HydraBossBuriedCombatStateCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			tileDamageBufferEntity = __query_356319590_9.GetSingletonEntity(),
			effectEventBufferSingleton = __query_356319590_7.GetSingletonEntity(),
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			rng = PugRandom.GetRng(),
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_7(new HydraBossRoamingJob
		{
			healthLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__HealthCD_RO_ComponentLookup, ref state),
			forceInCombatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ForceInCombatCD_RO_ComponentLookup, ref state),
			summarizedConditionsLookUp = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			translationLookUp = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
			movementSpeedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MovementSpeedCD_RO_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			ecb = ecb,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	public static void DestroyTilesWithinRadius(float radius, float3 pos, EntityCommandBuffer ecb, Entity tileDamageBufferEntity)
	{
		int num = (int)math.round(radius);
		int2 int5 = pos.RoundToInt2();
		for (int i = -num; i <= num; i++)
		{
			for (int j = -num; j <= num; j++)
			{
				int2 int6 = new int2(i, j) + int5;
				if (math.distance(int6.ToFloat3(), pos) <= radius)
				{
					ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
					{
						damage = 10000,
						position = int6,
						skipWallAndRootsLootDropOnDestroy = true,
						canHitLowColliders = true,
						bypassDamageReduction = true,
						dontHitGroundSlime = true,
						dontHitWalkableTiles = true
					});
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(SpawnVulnerableHydraJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_SpawnVulnerableHydraJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(CleanupNonMainHydrasJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_CleanupNonMainHydrasJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(HydraBossStateUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_HydraBossStateUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(KillNonMainHydraJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_KillNonMainHydraJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(HydraBossUpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_HydraBossUpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_5(HydraBossBeamAttackJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_HydraBossBeamAttackJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_6(HydraBossBuriedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_HydraBossBuriedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_7(HydraBossRoamingJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__HydraBossSystem_HydraBossRoamingJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_356319590_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HydraBossBaitCD, OwnerReferenceCD, LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<BaitCheckedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_356319590_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_356319590_11 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000928_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000929_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_0000092A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_0000092B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((HydraBossSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HydraBossSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HydraBossSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HydraBossSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((HydraBossSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
