using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
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
using UnityEngine.Scripting;

[BurstCompile]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct SnakeMovementStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(InitializedSnakeSegmentCD),
		typeof(EntityDestroyedCD),
		typeof(SnakeMovementStateCD)
	})]
	[WithNone(new Type[]
	{
		typeof(DeadSnakeSegmentCD),
		typeof(SkipSnakeSegmentInitializationCD)
	})]
	private struct HandleSnakePartDeathsJob : IJobEntity, IJobChunk
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<SkipSnakeSegmentInitializationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<InitializedSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
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
			public void Run(ref HandleSnakePartDeathsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref HandleSnakePartDeathsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref HandleSnakePartDeathsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref HandleSnakePartDeathsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref HandleSnakePartDeathsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref HandleSnakePartDeathsJob job, EntityManager entityManager)
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
		public BufferLookup<SnakeSegmentsBuffer> segmentsGroup;

		public EntityCommandBuffer ecb;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity)
		{
			ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup = attackHelper.snakeMovementStateLookup;
			SnakeMovementStateCD snakeMovementStateCD = snakeMovementStateLookup[entity];
			if (segmentsGroup.HasComponent(snakeMovementStateCD.headRef))
			{
				DynamicBuffer<SnakeSegmentsBuffer> dynamicBuffer = segmentsGroup[snakeMovementStateCD.headRef];
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					ecb.RemoveComponent<InitializedSnakeSegmentCD>(dynamicBuffer[i].segment);
					if (snakeMovementStateLookup.HasComponent(dynamicBuffer[i].segment))
					{
						SnakeMovementStateCD value = snakeMovementStateLookup[dynamicBuffer[i].segment];
						value.pauseMovementTimer.Start(time, 2f);
						snakeMovementStateLookup[dynamicBuffer[i].segment] = value;
					}
				}
			}
			ecb.AddComponent<DeadSnakeSegmentCD>(entity);
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
	[WithNone(new Type[]
	{
		typeof(InitializedSnakeSegmentCD),
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithNone(new Type[] { typeof(SkipSnakeSegmentInitializationCD) })]
	[WithOptions(EntityQueryOptions.IncludeDisabledEntities)]
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<InitializedSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<SkipSnakeSegmentInitializationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentCD>();
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

		public NativeReference<int> availableGroupIndexLocal;

		public NativeList<Entity> uninitializedSnakeSegments;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in SnakeSegmentCD segment)
		{
			if (availableGroupIndexLocal.Value <= segment.groupIndex)
			{
				availableGroupIndexLocal.Value = segment.groupIndex + 1;
			}
			uninitializedSnakeSegments.Add(in entity);
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
	[WithNone(new Type[]
	{
		typeof(InitializedSnakeSegmentCD),
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithNone(new Type[] { typeof(SkipSnakeSegmentInitializationCD) })]
	[WithAll(new Type[]
	{
		typeof(SnakeSegmentCD),
		typeof(SnakeMovementStateCD),
		typeof(LocalTransform),
		typeof(ObjectDataCD)
	})]
	private struct SetUpHeadsAndSegmentsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SnakeSegmentsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<InitializedSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<SkipSnakeSegmentInitializationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
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
			public void Run(ref SetUpHeadsAndSegmentsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetUpHeadsAndSegmentsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetUpHeadsAndSegmentsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetUpHeadsAndSegmentsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetUpHeadsAndSegmentsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetUpHeadsAndSegmentsJob job, EntityManager entityManager)
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

		public ComponentLookup<SnakeSegmentCD> snakeSegmentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeMovementAttackCooldownCD> snakeMovementAttackCooldownLookup;

		[ReadOnly]
		public ComponentLookup<SpawnPointCD> spawnPointLookup;

		[ReadOnly]
		public BufferLookup<RoamingPathBuffer> roamingPathLookup;

		public EntityCommandBuffer ecb;

		public NativeReference<int> availableGroupIndexLocal;

		public NativeList<Entity> uninitializedSnakeSegments;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public Unity.Mathematics.Random rnd;

		public double time;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<SnakeSegmentsBuffer> segmentsBuffer)
		{
			ObjectDataCD objectDataCD = attackHelper.objectDataLookup[entity];
			ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup = attackHelper.snakeMovementStateLookup;
			ComponentLookup<LocalTransform> localTransformLookup = attackHelper.localTransformLookup;
			ComponentLookup<EntityPartCD> entityPartLookup = attackHelper.entityPartLookup;
			SnakeMovementStateCD snakeMovementStateCD = snakeMovementStateLookup[entity];
			SnakeSegmentCD snakeSegmentCD = snakeSegmentLookup[entity];
			EntityPartCD componentData;
			bool flag = entityPartLookup.TryGetComponent(entity, out componentData);
			if (snakeSegmentCD.groupIndex == -1)
			{
				int num = 0;
				snakeSegmentLookup[entity] = new SnakeSegmentCD
				{
					index = num,
					groupIndex = availableGroupIndexLocal.Value
				};
				if (flag)
				{
					componentData.mainEntity = entity;
					ecb.SetComponent(entity, componentData);
				}
				snakeMovementStateCD.headRef = entity;
				snakeMovementStateLookup[entity] = snakeMovementStateCD;
				ecb.AppendToBuffer(entity, new SnakeSegmentsBuffer
				{
					segment = entity
				});
				for (int i = 0; i < snakeMovementStateCD.initialLength - 1; i++)
				{
					num++;
					float3 position = localTransformLookup[entity].Position;
					position.z -= 0.25f * (float)num;
					ObjectID objectID = ((snakeMovementStateCD.tailObjectId != ObjectID.None) ? snakeMovementStateCD.tailObjectId : objectDataCD.objectID);
					Entity entity2 = EntityUtility.CreateEntity(ecb, position, objectID, 1, databaseBankCD.databaseBankBlob);
					ecb.SetComponent(entity2, new SnakeSegmentCD
					{
						index = num,
						groupIndex = availableGroupIndexLocal.Value
					});
					snakeMovementStateCD.headRef = entity;
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, databaseBankCD.databaseBankBlob);
					snakeMovementStateCD.disableDamage = snakeMovementStateLookup.TryGetComponent(primaryPrefabEntity, out var componentData2) && componentData2.disableDamage;
					ecb.SetComponent(entity2, snakeMovementStateCD);
					SnakeMovementAttackCooldownCD component = snakeMovementAttackCooldownLookup[entity];
					component.attackCooldown = rnd.NextFloat(1f, 2f);
					ecb.SetComponent(entity2, component);
					ecb.AddComponent<InitializedSnakeSegmentCD>(entity2);
					ecb.AppendToBuffer(entity, new SnakeSegmentsBuffer
					{
						segment = entity2
					});
					if (flag)
					{
						ecb.SetComponent(entity2, new EntityPartCD
						{
							mainEntity = entity
						});
						ecb.AppendToBuffer(entity, (LinkedEntityGroup)entity2);
					}
					ecb.SetComponentEnabled<DontDropLootCD>(entity2, value: true);
					if (!spawnPointLookup.TryGetComponent(entity, out var componentData3))
					{
						continue;
					}
					ecb.AddComponent(entity2, componentData3);
					if (!roamingPathLookup.HasComponent(entity))
					{
						continue;
					}
					foreach (RoamingPathBuffer item in roamingPathLookup[entity])
					{
						ecb.AppendToBuffer(entity2, item);
					}
				}
				ecb.AddComponent<InitializedSnakeSegmentCD>(entity);
				availableGroupIndexLocal.Value++;
				return;
			}
			segmentsBuffer.Clear();
			if (snakeMovementStateCD.pauseMovementTimer.isRunning && !snakeMovementStateCD.pauseMovementTimer.IsTimerElapsed(time))
			{
				return;
			}
			bool flag2 = true;
			int index = snakeSegmentCD.index;
			for (int j = 0; j < uninitializedSnakeSegments.Length; j++)
			{
				Entity entity3 = uninitializedSnakeSegments[j];
				SnakeSegmentCD snakeSegmentCD2 = snakeSegmentLookup[entity3];
				if (snakeSegmentCD2.groupIndex == snakeSegmentCD.groupIndex)
				{
					if (snakeSegmentCD2.index == index - 1)
					{
						flag2 = false;
						break;
					}
					segmentsBuffer.Add(new SnakeSegmentsBuffer
					{
						segment = entity3
					});
				}
			}
			if (!flag2)
			{
				return;
			}
			ecb.SetComponentEnabled<DontDropLootCD>(entity, value: true);
			for (int k = 0; k < segmentsBuffer.Length; k++)
			{
				for (int l = k + 1; l < segmentsBuffer.Length; l++)
				{
					if (snakeSegmentLookup[segmentsBuffer[k].segment].index > snakeSegmentLookup[segmentsBuffer[l].segment].index)
					{
						int index2 = k;
						int index3 = l;
						SnakeSegmentsBuffer snakeSegmentsBuffer = segmentsBuffer[l];
						SnakeSegmentsBuffer snakeSegmentsBuffer2 = segmentsBuffer[k];
						SnakeSegmentsBuffer snakeSegmentsBuffer3 = (segmentsBuffer[index2] = snakeSegmentsBuffer);
						snakeSegmentsBuffer3 = (segmentsBuffer[index3] = snakeSegmentsBuffer2);
					}
				}
			}
			for (int num2 = segmentsBuffer.Length - 1; num2 >= 0; num2--)
			{
				if (snakeSegmentLookup[segmentsBuffer[num2].segment].index < index)
				{
					segmentsBuffer.RemoveAt(num2);
				}
			}
			bool flag3 = entityPartLookup.HasComponent(entity);
			int num3 = index;
			int m;
			for (m = 0; m < segmentsBuffer.Length && snakeSegmentLookup[segmentsBuffer[m].segment].index == num3; m++)
			{
				SnakeMovementStateCD component2 = snakeMovementStateLookup[segmentsBuffer[m].segment];
				component2.headRef = entity;
				ecb.SetComponent(segmentsBuffer[m].segment, component2);
				ecb.SetComponentEnabled<DontDropLootCD>(segmentsBuffer[m].segment, value: true);
				if (flag3)
				{
					ecb.SetComponent(segmentsBuffer[m].segment, new EntityPartCD
					{
						mainEntity = entity
					});
					ecb.AppendToBuffer(entity, (LinkedEntityGroup)segmentsBuffer[m].segment);
				}
				num3++;
			}
			int num4 = m;
			for (int num5 = segmentsBuffer.Length - 1; num5 >= num4; num5--)
			{
				segmentsBuffer.RemoveAt(num5);
			}
			for (int n = 0; n < segmentsBuffer.Length; n++)
			{
				ecb.AddComponent<InitializedSnakeSegmentCD>(segmentsBuffer[n].segment);
			}
			ecb.AddComponent<InitializedSnakeSegmentCD>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<SnakeSegmentsBuffer> segmentsBuffer = bufferAccessor[i];
					Execute(entity, ref segmentsBuffer);
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
						DynamicBuffer<SnakeSegmentsBuffer> segmentsBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref segmentsBuffer2);
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
					DynamicBuffer<SnakeSegmentsBuffer> segmentsBuffer3 = bufferAccessor[j];
					Execute(entity3, ref segmentsBuffer3);
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
					DynamicBuffer<SnakeSegmentsBuffer> segmentsBuffer4 = bufferAccessor[k];
					Execute(entity4, ref segmentsBuffer4);
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
		typeof(SnakeMovementPathUpdateDoneCD),
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithAll(new Type[] { typeof(SnakeSegmentCD) })]
	private struct SetUpRoamingJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<TargetPointsBuffer> __TargetPointsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<RoamingPathBuffer> __RoamingPathBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__TargetPointsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<TargetPointsBuffer>();
					__RoamingPathBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<RoamingPathBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__TargetPointsBuffer_RW_BufferTypeHandle.Update(ref state);
					__RoamingPathBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<SnakeMovementPathUpdateDoneCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RoamingPathBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TargetPointsBuffer>();
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
			public void Run(ref SetUpRoamingJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetUpRoamingJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetUpRoamingJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetUpRoamingJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetUpRoamingJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetUpRoamingJob job, EntityManager entityManager)
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

		private void Execute(Entity entity, ref DynamicBuffer<TargetPointsBuffer> targetPoints, in DynamicBuffer<RoamingPathBuffer> roamingPath)
		{
			if (roamingPath.Length > 0)
			{
				for (int i = 0; i < roamingPath.Length; i++)
				{
					targetPoints.Add(new TargetPointsBuffer
					{
						targetPoint = roamingPath[i].Value
					});
				}
				ecb.AddComponent<SnakeMovementPathUpdateDoneCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<TargetPointsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__TargetPointsBuffer_RW_BufferTypeHandle);
			BufferAccessor<RoamingPathBuffer> bufferAccessor2 = chunk.GetBufferAccessor(ref __TypeHandle.__RoamingPathBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<TargetPointsBuffer> targetPoints = bufferAccessor[i];
					Execute(entity, ref targetPoints, bufferAccessor2[i]);
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
						DynamicBuffer<TargetPointsBuffer> targetPoints2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref targetPoints2, bufferAccessor2[nextRangeBegin]);
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
					DynamicBuffer<TargetPointsBuffer> targetPoints3 = bufferAccessor[j];
					Execute(entity3, ref targetPoints3, bufferAccessor2[j]);
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
					DynamicBuffer<TargetPointsBuffer> targetPoints4 = bufferAccessor[k];
					Execute(entity4, ref targetPoints4, bufferAccessor2[k]);
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
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithAll(new Type[]
	{
		typeof(SnakeMovementStateCD),
		typeof(LocalTransform),
		typeof(PhysicsVelocity)
	})]
	private struct SnakeBossMovementJob : IJobEntity, IJobChunk
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

				[ReadOnly]
				public BufferTypeHandle<TargetPointsBuffer> __TargetPointsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
					__TargetPointsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<TargetPointsBuffer>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref state);
					__TargetPointsBuffer_RO_BufferTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TargetPointsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity>();
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
			public void Run(ref SnakeBossMovementJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SnakeBossMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SnakeBossMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SnakeBossMovementJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SnakeBossMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SnakeBossMovementJob job, EntityManager entityManager)
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
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public BufferLookup<SnakeSegmentsBuffer> segmentsGroup;

		[ReadOnly]
		public ComponentLookup<MusicAreaCD> musicGroup;

		[ReadOnly]
		public ComponentLookup<SnakeCombatMovement> snakeCombatMovementLookup;

		public EntityCommandBuffer ecb;

		public Unity.Mathematics.Random rnd;

		public double time;

		public float fixedDeltaTime;

		public float2 snakeBossMoveDirection;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, in MovementSpeedCD movementSpeed, in DynamicBuffer<TargetPointsBuffer> targetPointsBuffer, in DistanceToPlayerCD distanceToPlayerCD)
		{
			ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup = attackHelper.snakeMovementStateLookup;
			ComponentLookup<LocalTransform> localTransformLookup = attackHelper.localTransformLookup;
			ref LocalTransform valueRW = ref localTransformLookup.GetRefRW(entity).ValueRW;
			ref SnakeMovementStateCD valueRW2 = ref snakeMovementStateLookup.GetRefRW(entity).ValueRW;
			bool flag = bossLookup.HasComponent(entity);
			if (!stateInfo.IsCurrentState(StateID.SnakeMovement) || !localTransformLookup.HasComponent(entity) || !valueRW2.IsHead(entity) || !flag || !segmentsGroup.HasBuffer(entity))
			{
				return;
			}
			float3 position = valueRW.Position;
			SnakeMovementPhaseType currentPhase = valueRW2.currentPhase;
			if (valueRW2.externallyRequestedPhase != SnakeMovementPhaseType.NONE)
			{
				valueRW2.currentPhase = valueRW2.externallyRequestedPhase;
			}
			else
			{
				valueRW2.currentPhase = ((distanceToPlayerCD.closestPlayer != Entity.Null && distanceToPlayerCD.minDistanceSq < valueRW2.distanceSqToAttackPlayer) ? SnakeMovementPhaseType.COMBAT : SnakeMovementPhaseType.PATROL);
			}
			switch (valueRW2.currentPhase)
			{
			case SnakeMovementPhaseType.COMBAT:
				if (!snakeCombatMovementLookup.HasComponent(entity))
				{
					ecb.AddComponent<SnakeCombatMovement>(entity);
				}
				break;
			case SnakeMovementPhaseType.PATROL:
				if (snakeCombatMovementLookup.HasComponent(entity))
				{
					ecb.RemoveComponent<SnakeCombatMovement>(entity);
				}
				break;
			}
			if (musicGroup.HasComponent(entity))
			{
				MusicAreaCD component = musicGroup[entity];
				component.isInactive = valueRW2.currentPhase == SnakeMovementPhaseType.PATROL;
				ecb.SetComponent(entity, component);
			}
			bool flag2 = currentPhase != valueRW2.currentPhase;
			if (flag2 && valueRW2.currentPhase == SnakeMovementPhaseType.COMBAT)
			{
				if (targetPointsBuffer.Length == 0)
				{
					valueRW2.phase2Position = position;
				}
				else
				{
					int index = ((valueRW2.targetPointIndex == 0) ? (targetPointsBuffer.Length - 1) : (valueRW2.targetPointIndex - 1));
					valueRW2.phase2Position = FindNearestPointOnLine(targetPointsBuffer[index].targetPoint, targetPointsBuffer[valueRW2.targetPointIndex].targetPoint, position);
					if (math.distance(position, valueRW2.phase2Position) > 30f)
					{
						valueRW2.phase2Position = position;
					}
				}
			}
			bool flag3 = math.distance(position, valueRW2.targetPoint) < valueRW2.distanceToTargetToChangeTarget;
			bool flag4 = valueRW2.changeDirectionTimer.IsTimerElapsed(time);
			bool flag5 = math.lengthsq(valueRW2.externallyRequestedTargetPoint) > 0.1f;
			bool flag6 = flag5 && math.distancesq(valueRW2.externallyRequestedTargetPoint, valueRW2.targetPoint) > 0.1f;
			if (flag3 || flag4 || flag2 || flag6)
			{
				if (flag5)
				{
					valueRW2.targetPoint = valueRW2.externallyRequestedTargetPoint;
				}
				else if (valueRW2.currentPhase == SnakeMovementPhaseType.PATROL)
				{
					if (targetPointsBuffer.Length > 0)
					{
						if (flag3)
						{
							valueRW2.targetPointIndex = (valueRW2.targetPointIndex + 1) % targetPointsBuffer.Length;
						}
						valueRW2.targetPoint = targetPointsBuffer[valueRW2.targetPointIndex].targetPoint;
					}
				}
				else
				{
					valueRW2.targetEntity = Entity.Null;
					if (valueRW2.targetingType == SnakeTargetingType.LastAttacker)
					{
						ComponentLookup<LastAttackerCD> lastAttackerlookup = attackHelper.lastAttackerlookup;
						if (lastAttackerlookup.HasComponent(entity))
						{
							valueRW2.targetEntity = lastAttackerlookup[entity].Value;
							if (valueRW2.targetEntity == Entity.Null)
							{
								DynamicBuffer<SnakeSegmentsBuffer> dynamicBuffer = segmentsGroup[entity];
								for (int i = 0; i < dynamicBuffer.Length; i++)
								{
									if (lastAttackerlookup.HasComponent(dynamicBuffer[i].segment))
									{
										LastAttackerCD lastAttackerCD = lastAttackerlookup[dynamicBuffer[i].segment];
										if (lastAttackerCD.Value != Entity.Null)
										{
											valueRW2.targetEntity = lastAttackerCD.Value;
											break;
										}
									}
								}
							}
						}
					}
					else if (valueRW2.targetingType == SnakeTargetingType.ClosestPlayer)
					{
						valueRW2.targetEntity = distanceToPlayerCD.closestPlayer;
					}
					bool flag7 = false;
					if (valueRW2.playerTargetCooldownTimer.IsTimerElapsed(time) && valueRW2.targetEntity != Entity.Null && localTransformLookup.HasComponent(valueRW2.targetEntity))
					{
						float3 position2 = localTransformLookup[valueRW2.targetEntity].Position;
						float3 x = position2 - position;
						float num = math.length(x);
						float num2 = math.distancesq(position2, valueRW2.phase2Position);
						bool num3 = num <= (flag ? 12f : 2f);
						if (!num3 && num2 < valueRW2.distanceSqAllowedToMoveAwayFromCombatStartPosition)
						{
							float3 float5 = math.normalizesafe(x, new float3(1f, 0f, 0f));
							float num4 = math.max(num, flag ? 20f : 0f);
							valueRW2.targetPoint = position + float5 * num4;
							flag7 = true;
						}
						if (num3)
						{
							valueRW2.playerTargetCooldownTimer.Start(time, rnd.NextFloat(valueRW2.playerTargetCooldownMin, valueRW2.playerTargetCooldownMax));
						}
					}
					if (!flag7 && (flag3 || flag2))
					{
						if (valueRW2.phase2Position.x < valueRW2.targetPoint.x)
						{
							valueRW2.targetPoint = valueRW2.phase2Position + new float3(0f - rnd.NextFloat(15f, 20f), 0f, rnd.NextFloat(-10f, 10f));
						}
						else
						{
							valueRW2.targetPoint = valueRW2.phase2Position + new float3(rnd.NextFloat(15f, 20f), 0f, rnd.NextFloat(-10f, 10f));
						}
					}
				}
				valueRW2.previousRotation = valueRW2.targetRotation;
				valueRW2.changeDirectionTimer.Start(time, valueRW2.turnDuration);
				valueRW2.rotationLerpAlpha = 0f;
				float3 obj = math.normalizesafe(valueRW2.targetPoint - position, new float3(0f, 0f, 1f));
				float3 to = math.mul(valueRW2.previousRotation, new float3(0f, 0f, 1f));
				if (SignedAngle(obj, to, MathUtilities.Float3.up) > 0f)
				{
					valueRW2.currentTurnType = SnakeMovementTurnType.LEFT;
				}
				else
				{
					valueRW2.currentTurnType = SnakeMovementTurnType.RIGHT;
				}
			}
			if (valueRW2.currentPhase == SnakeMovementPhaseType.COMBAT && valueRW2.targetEntity != Entity.Null && localTransformLookup.HasComponent(valueRW2.targetEntity))
			{
				Entity targetEntity = valueRW2.targetEntity;
				float3 position3 = localTransformLookup[targetEntity].Position;
				float3 float6 = position3 - position;
				float3 to2 = math.mul(valueRW2.currentRotation, new float3(0f, 0f, 1f));
				float num5 = math.length(float6);
				float num6 = math.length(position3 - valueRW2.phase2Position);
				float num7 = math.abs(SignedAngle(float6, to2, MathUtilities.Float3.up));
				if (num5 > 8f && num7 < 70f && num6 < 30f)
				{
					float3 float7 = math.normalizesafe(float6, new float3(1f, 0f, 0f));
					float num8 = math.max(num5, 20f);
					valueRW2.targetPoint = position + float7 * num8;
				}
			}
			float3 float8 = math.normalizesafe(valueRW2.targetPoint - position, new float3(0f, 0f, 1f));
			if (math.any(snakeBossMoveDirection != float2.zero) && attackHelper.objectDataLookup.TryGetComponent(entity, out var componentData) && componentData.objectID == ObjectID.SnakeBossSegment)
			{
				float8 = snakeBossMoveDirection.ToFloat3();
			}
			valueRW2.targetRotation = quaternion.LookRotation(float8, MathUtilities.Float3.up);
			quaternion previousRotation = valueRW2.previousRotation;
			valueRW2.rotationLerpAlpha = math.clamp(valueRW2.rotationLerpAlpha + fixedDeltaTime * (1f / (valueRW2.turnDuration / valueRW2.movementSpeedMultiplier)), 0f, 1f);
			valueRW2.currentRotation = math.slerp(previousRotation, valueRW2.targetRotation, valueRW2.rotationLerpAlpha);
			valueRW2.currentDirection = math.mul(valueRW2.currentRotation, new float3(0f, 0f, 1f));
			float3 to3 = math.mul(valueRW2.previousRotation, new float3(0f, 0f, 1f));
			float num9 = SignedAngle(float8, to3, MathUtilities.Float3.up);
			if (valueRW2.chaoticMovement)
			{
				num9 += rnd.NextFloat(-0.3f, 0.3f);
			}
			SnakeMovementTurnType snakeMovementTurnType = SnakeMovementTurnType.LEFT;
			snakeMovementTurnType = ((!(num9 > 0f)) ? SnakeMovementTurnType.RIGHT : SnakeMovementTurnType.LEFT);
			if (snakeMovementTurnType != valueRW2.currentTurnType && math.length(valueRW2.currentDirection - float8) > 0.01f)
			{
				float num10 = math.radians(SignedAngle(valueRW2.currentDirection, float8, MathUtilities.Float3.up)) * 2f;
				if (math.abs(num10) > 1.1920929E-07f)
				{
					valueRW2.currentRotation = math.mul(valueRW2.currentRotation, quaternion.RotateY(num10));
					valueRW2.currentDirection = math.mul(valueRW2.currentRotation, new float3(0f, 0f, 1f));
				}
			}
			float3 float9 = valueRW2.currentDirection;
			if (valueRW2.wavinessTurnTime > 0f)
			{
				float wavinessTurnTime = valueRW2.wavinessTurnTime;
				float wavinessAmplitude = valueRW2.wavinessAmplitude;
				float2 xz = math.cross(valueRW2.currentDirection, math.up()).xz;
				float2 float10 = (float)math.sin(time / (double)(wavinessTurnTime / MathF.PI)) * wavinessAmplitude * xz;
				float9 += new float3(float10.x, 0f, float10.y);
				float9 = math.normalizesafe(float9);
			}
			valueRW2.facingDirection = float9;
			if (!valueRW2.pauseMovementTimer.isRunning || valueRW2.pauseMovementTimer.IsTimerElapsed(time))
			{
				float3 float11 = float9 * movementSpeed.speed * fixedDeltaTime * valueRW2.movementSpeedMultiplier;
				if (valueRW2.usePhysVelocity)
				{
					attackHelper.physicsVelocityAccessor.GetRefRW(entity).ValueRW.Linear += float11;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle);
			BufferAccessor<TargetPointsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__TargetPointsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, k));
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
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithAll(new Type[]
	{
		typeof(SnakeMovementStateCD),
		typeof(LocalTransform)
	})]
	private struct SnakeWormMovementJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<TargetPointsBuffer> __TargetPointsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__TargetPointsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<TargetPointsBuffer>(isReadOnly: true);
					__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__TargetPointsBuffer_RO_BufferTypeHandle.Update(ref state);
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
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TargetPointsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
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
			public void Run(ref SnakeWormMovementJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SnakeWormMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SnakeWormMovementJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SnakeWormMovementJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SnakeWormMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SnakeWormMovementJob job, EntityManager entityManager)
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
		public TileAccessor tileLookup;

		[ReadOnly]
		public BufferLookup<SnakeSegmentsBuffer> segmentsGroup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<SnakeCombatMovement> snakeCombatMovementLookup;

		public EntityCommandBuffer ecb;

		public Unity.Mathematics.Random rnd;

		public double time;

		public float fixedDeltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, in DynamicBuffer<TargetPointsBuffer> targetPointsBuffer, in DistanceToPlayerCD distanceToPlayerCD)
		{
			ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup = attackHelper.snakeMovementStateLookup;
			ComponentLookup<LocalTransform> localTransformLookup = attackHelper.localTransformLookup;
			ref LocalTransform valueRW = ref localTransformLookup.GetRefRW(entity).ValueRW;
			ref SnakeMovementStateCD valueRW2 = ref snakeMovementStateLookup.GetRefRW(entity).ValueRW;
			bool flag = bossLookup.HasComponent(entity);
			if (!stateInfo.IsCurrentState(StateID.SnakeMovement) || !localTransformLookup.HasComponent(entity) || !valueRW2.IsHead(entity) || flag || !segmentsGroup.HasBuffer(entity))
			{
				return;
			}
			DynamicBuffer<SnakeSegmentsBuffer> dynamicBuffer = segmentsGroup[entity];
			if (dynamicBuffer.IsEmpty)
			{
				return;
			}
			float3 position = valueRW.Position;
			if (attackHelper.animationOrientationLookup.HasComponent(entity))
			{
				attackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW.SetFacingDirectionFromVector(valueRW2.currentDirection);
			}
			SnakeMovementPhaseType currentPhase = valueRW2.currentPhase;
			if (valueRW2.externallyRequestedPhase != SnakeMovementPhaseType.NONE)
			{
				valueRW2.currentPhase = valueRW2.externallyRequestedPhase;
			}
			else
			{
				valueRW2.currentPhase = ((distanceToPlayerCD.closestPlayer != Entity.Null && distanceToPlayerCD.minDistanceSq < valueRW2.distanceSqToAttackPlayer) ? SnakeMovementPhaseType.COMBAT : SnakeMovementPhaseType.PATROL);
			}
			switch (valueRW2.currentPhase)
			{
			case SnakeMovementPhaseType.COMBAT:
				if (!snakeCombatMovementLookup.HasComponent(entity))
				{
					ecb.AddComponent<SnakeCombatMovement>(entity);
				}
				break;
			case SnakeMovementPhaseType.PATROL:
				if (snakeCombatMovementLookup.HasComponent(entity))
				{
					ecb.RemoveComponent<SnakeCombatMovement>(entity);
				}
				break;
			}
			bool flag2 = currentPhase != valueRW2.currentPhase;
			if (flag2 && valueRW2.currentPhase == SnakeMovementPhaseType.COMBAT)
			{
				if (targetPointsBuffer.Length == 0)
				{
					valueRW2.phase2Position = position;
				}
				else
				{
					int index = ((valueRW2.targetPointIndex == 0) ? (targetPointsBuffer.Length - 1) : (valueRW2.targetPointIndex - 1));
					valueRW2.phase2Position = FindNearestPointOnLine(targetPointsBuffer[index].targetPoint, targetPointsBuffer[valueRW2.targetPointIndex].targetPoint, position);
					if (math.distance(position, valueRW2.phase2Position) > 30f)
					{
						valueRW2.phase2Position = position;
					}
				}
			}
			bool flag3 = math.distance(position, valueRW2.targetPoint) < valueRW2.distanceToTargetToChangeTarget;
			switch (valueRW2.currentPhase)
			{
			case SnakeMovementPhaseType.PATROL:
				if (targetPointsBuffer.Length > 0)
				{
					if (flag3)
					{
						valueRW2.targetPointIndex = (valueRW2.targetPointIndex + 1) % targetPointsBuffer.Length;
					}
					valueRW2.targetPoint = targetPointsBuffer[valueRW2.targetPointIndex].targetPoint;
				}
				break;
			case SnakeMovementPhaseType.COMBAT:
			{
				valueRW2.targetEntity = Entity.Null;
				bool flag4 = valueRW2.playerTargetCooldownTimer.IsTimerElapsed(time);
				if (flag4)
				{
					Entity entity2 = Entity.Null;
					if (valueRW2.targetingType == SnakeTargetingType.LastAttacker)
					{
						ComponentLookup<LastAttackerCD> lastAttackerlookup = attackHelper.lastAttackerlookup;
						if (lastAttackerlookup.HasComponent(entity))
						{
							entity2 = lastAttackerlookup[entity].Value;
							if (entity2 == Entity.Null)
							{
								for (int i = 0; i < dynamicBuffer.Length; i++)
								{
									if (lastAttackerlookup.HasComponent(dynamicBuffer[i].segment))
									{
										LastAttackerCD lastAttackerCD = lastAttackerlookup[dynamicBuffer[i].segment];
										if (lastAttackerCD.Value != Entity.Null)
										{
											entity2 = lastAttackerCD.Value;
											break;
										}
									}
								}
							}
						}
					}
					else if (valueRW2.targetingType == SnakeTargetingType.ClosestPlayer)
					{
						entity2 = distanceToPlayerCD.closestPlayer;
					}
					if (entity2 != Entity.Null && localTransformLookup.HasComponent(entity2))
					{
						float3 position2 = localTransformLookup[entity2].Position;
						if (math.distancesq(position2, valueRW2.phase2Position) < valueRW2.distanceSqAllowedToMoveAwayFromCombatStartPosition)
						{
							valueRW2.targetPoint = position2;
							valueRW2.targetEntity = entity2;
						}
					}
				}
				float num = math.distancesq(valueRW2.targetPoint, position);
				bool flag5 = valueRW2.targetEntity != Entity.Null && flag4 && num < valueRW2.tooCloseDistanceForAttack;
				if (valueRW2.chaoticMovement && !flag5 && valueRW2.targetEntity != Entity.Null && num < valueRW2.tooCloseDistanceForAttack * 4f && rnd.NextFloat(1f) > 0.94f)
				{
					flag5 = true;
				}
				if (flag5 && !valueRW2.chaoticMovement)
				{
					valueRW2.playerTargetCooldownTimer.Start(time, rnd.NextFloat(valueRW2.playerTargetCooldownMin, valueRW2.playerTargetCooldownMax));
					float3 float5 = math.normalizesafe(valueRW2.targetPoint - position);
					valueRW2.targetPoint += float5 * rnd.NextFloat(6f, 9f);
				}
				else if (flag5 && valueRW2.chaoticMovement)
				{
					valueRW2.playerTargetCooldownTimer.Start(time, rnd.NextFloat(valueRW2.playerTargetCooldownMin, valueRW2.playerTargetCooldownMax));
					valueRW2.targetPoint += valueRW2.targetPoint * rnd.NextFloat(-3f, 3f);
				}
				else if (valueRW2.targetEntity == Entity.Null && (flag3 || flag2))
				{
					if (valueRW2.phase2Position.x < valueRW2.targetPoint.x)
					{
						valueRW2.targetPoint = valueRW2.phase2Position + new float3(0f - rnd.NextFloat(15f, 20f), 0f, rnd.NextFloat(-10f, 10f));
					}
					else
					{
						valueRW2.targetPoint = valueRW2.phase2Position + new float3(rnd.NextFloat(15f, 20f), 0f, rnd.NextFloat(-10f, 10f));
					}
				}
				break;
			}
			}
			if (valueRW2.slowDownForWalls)
			{
				bool num2 = tileLookup.HasType(position.RoundToInt2(), TileType.wall);
				bool flag6 = false;
				if (dynamicBuffer.Length >= 2 && localTransformLookup.HasComponent(dynamicBuffer[1].segment))
				{
					Entity segment = dynamicBuffer[1].segment;
					float3 position3 = localTransformLookup[segment].Position;
					flag6 = tileLookup.HasType(position3.RoundToInt2(), TileType.wall);
				}
				if (num2 && flag6 && !valueRW2.hasSetEnteredWallTime)
				{
					valueRW2.enteredWallTime = time;
					valueRW2.hasSetEnteredWallTime = true;
				}
				bool flag7 = valueRW2.currentPhase == SnakeMovementPhaseType.COMBAT && valueRW2.targetEntity != Entity.Null && math.distancesq(position, valueRW2.targetPoint) <= 64f;
				bool num3 = !num2 && flag6;
				bool flag8 = valueRW2.leaveWallTimer.isRunning && !valueRW2.leaveWallTimer.IsTimerElapsed(time);
				if (num3 && valueRW2.hasSetEnteredWallTime && time - valueRW2.enteredWallTime > 0.5)
				{
					valueRW2.hasSetEnteredWallTime = false;
					bool flag9 = false;
					Entity segment2 = dynamicBuffer[dynamicBuffer.Length - 1].segment;
					if (localTransformLookup.HasComponent(segment2))
					{
						float3 position4 = localTransformLookup[segment2].Position;
						flag9 = tileLookup.HasType(position4.RoundToInt2(), TileType.wall);
					}
					if (flag7 && flag9 && !flag8)
					{
						valueRW2.leaveWallTimer.Start(time, 0.7f);
					}
				}
				float num4 = ((valueRW2.leaveWallTimer.isRunning && !valueRW2.leaveWallTimer.IsTimerElapsed(time)) ? 10f : (-14f));
				valueRW2.leaveWallAlpha = math.clamp(valueRW2.leaveWallAlpha + num4 * fixedDeltaTime, 0f, 1f);
				valueRW2.movementSpeedMultiplier = math.lerp(1f, 0.05f, valueRW2.leaveWallAlpha);
				int num5;
				if (num2)
				{
					num5 = ((!flag6) ? 1 : 0);
					if (num5 != 0 && !valueRW2.triggeredEnterWallTimer && valueRW2.enterWallTimer.IsTimerElapsed(time))
					{
						valueRW2.enterWallTimer.Start(time, 0.5f);
						valueRW2.triggeredEnterWallTimer = true;
					}
				}
				else
				{
					num5 = 0;
				}
				if (num5 == 0)
				{
					valueRW2.triggeredEnterWallTimer = false;
				}
				float num6 = -1f;
				if (valueRW2.enterWallTimer.isRunning && !valueRW2.enterWallTimer.IsTimerElapsed(time))
				{
					num6 = 4f;
				}
				valueRW2.enterWallAlpha = math.clamp(valueRW2.enterWallAlpha + num6 * fixedDeltaTime, 0f, 1f);
				valueRW2.movementSpeedMultiplier *= math.lerp(1f, 0.5f, valueRW2.enterWallAlpha);
			}
			float3 targetDirection = valueRW2.targetPoint - position;
			float num7 = 1f / valueRW2.turnDuration * valueRW2.movementSpeedMultiplier;
			valueRW2.currentDirection = MathUtilities.YAxisRotation(valueRW2.currentDirection, targetDirection, 180f * num7 * fixedDeltaTime);
			float3 float6 = valueRW2.currentDirection;
			if (valueRW2.wavinessTurnTime > 0f)
			{
				float wavinessTurnTime = valueRW2.wavinessTurnTime;
				float wavinessAmplitude = valueRW2.wavinessAmplitude;
				float2 xz = math.cross(valueRW2.currentDirection, math.up()).xz;
				float2 float7 = (float)math.sin(time / (double)(wavinessTurnTime / MathF.PI)) * wavinessAmplitude * xz;
				float6 += new float3(float7.x, 0f, float7.y);
				float6 = math.normalizesafe(float6);
			}
			valueRW2.facingDirection = float6;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			BufferAccessor<TargetPointsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__TargetPointsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr3, k));
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
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithAll(new Type[]
	{
		typeof(SnakeMovementStateCD),
		typeof(LocalTransform)
	})]
	private struct SnakeMovementAnimationJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				public ComponentTypeHandle<SnakeMovementAnimationCD> __SnakeMovementAnimationCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
					__SnakeMovementAnimationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SnakeMovementAnimationCD>();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
					__SnakeMovementAnimationCD_RW_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SnakeMovementAnimationCD>();
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
			public void Run(ref SnakeMovementAnimationJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SnakeMovementAnimationJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SnakeMovementAnimationJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SnakeMovementAnimationJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SnakeMovementAnimationJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SnakeMovementAnimationJob job, EntityManager entityManager)
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

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, ref SnakeMovementAnimationCD animation, in StateInfoCD stateInfo)
		{
			if (!stateInfo.IsCurrentState(StateID.SnakeMovement))
			{
				animation.currentAnimation = 0;
			}
			else if (animation.currentAnimation != -281135240)
			{
				animation.currentAnimation = -281135240;
				AnimationUtilities.TriggerAnimation(-281135240, currentTick, animationBuffer, ref animationBufferPointer);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__SnakeMovementAnimationCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementAnimationCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i));
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
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementAnimationCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, nextRangeBegin));
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
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementAnimationCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j));
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
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SnakeMovementAnimationCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k));
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
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	[WithAll(new Type[]
	{
		typeof(SnakeMovementStateCD),
		typeof(PhysicsVelocity)
	})]
	private struct UpdateSnakeBodySegmentPositionsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RO_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
					__SnakeSegmentsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SnakeSegmentsBuffer>(isReadOnly: true);
					__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RW_ComponentTypeHandle.Update(ref state);
					__SnakeSegmentsBuffer_RO_BufferTypeHandle.Update(ref state);
					__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeSegmentsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PhysicsVelocity>();
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
			public void Run(ref UpdateSnakeBodySegmentPositionsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateSnakeBodySegmentPositionsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateSnakeBodySegmentPositionsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateSnakeBodySegmentPositionsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateSnakeBodySegmentPositionsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateSnakeBodySegmentPositionsJob job, EntityManager entityManager)
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
		public ComponentLookup<SpawnPointCD> spawnPointLookup;

		public double time;

		public float fixedDeltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref StateInfoCD stateInfo, in DynamicBuffer<SnakeSegmentsBuffer> segments, in MovementSpeedCD movementSpeed)
		{
			ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup = attackHelper.snakeMovementStateLookup;
			ComponentLookup<LocalTransform> localTransformLookup = attackHelper.localTransformLookup;
			ref SnakeMovementStateCD valueRW = ref snakeMovementStateLookup.GetRefRW(entity).ValueRW;
			if (!stateInfo.IsCurrentState(StateID.SnakeMovement) || !localTransformLookup.HasComponent(entity) || !valueRW.IsHead(entity) || (valueRW.pauseMovementTimer.isRunning && !valueRW.pauseMovementTimer.IsTimerElapsed(time)) || segments.IsEmpty)
			{
				return;
			}
			NativeArray<float3> segmentPositions = new NativeArray<float3>(segments.Length, Allocator.Temp);
			for (int i = 0; i < segments.Length; i++)
			{
				if (!localTransformLookup.HasComponent(segments[i].segment))
				{
					return;
				}
				segmentPositions[i] = localTransformLookup[segments[i].segment].Position;
			}
			if (segmentPositions.Length > 0)
			{
				segmentPositions[0] += (valueRW.usePhysVelocity ? float3.zero : (valueRW.facingDirection * (movementSpeed.speed * valueRW.movementSpeedMultiplier) / 10f * fixedDeltaTime));
			}
			if (spawnPointLookup.TryGetComponent(entity, out var componentData))
			{
				float3 y = segmentPositions[0];
				float3 position = componentData.position;
				if (float.IsNaN(y.x) || float.IsNaN(y.y) || float.IsNaN(y.z) || math.distancesq(position, y) > 100000000f)
				{
					segmentPositions[0] = componentData.position;
				}
			}
			for (int j = 1; j < segments.Length; j++)
			{
				float3 float5 = segmentPositions[j - 1];
				float3 float6 = segmentPositions[j];
				bool flag = segments.Length >= 3;
				float3 p = float5 + (flag ? GetTangent(segmentPositions, j - 1) : float3.zero);
				float3 p2 = float6 - (flag ? GetTangent(segmentPositions, j) : float3.zero);
				float3 x = float6 - float5;
				float num = math.length(x);
				if (!((double)num < 0.0001))
				{
					x /= num;
					float t = math.saturate((valueRW.spread + valueRW.additionalHorizontalSpread * math.abs(x.x)) / num);
					float3 float7 = CubicBezier(float5, p, p2, float6, t);
					if (float.IsNaN(float7.x) || float.IsNaN(float7.y) || float.IsNaN(float7.z))
					{
						float7 = segmentPositions[0];
					}
					if (valueRW.useCaterpillarMovement && j < segmentPositions.Length - 1)
					{
						x = segmentPositions[j - 1] - segmentPositions[j];
						x = math.normalizesafe(x);
						float3 float8 = x * valueRW.stretchOutStrength;
						float3 obj = -x * valueRW.stretchBackStrength;
						Vector3 vector = Vector3.Lerp(t: Mathf.Sin((float)time * valueRW.stretchFrequency + (float)j * valueRW.stretchSpread * 0.5f + 0.5f), a: obj, b: float8) * 6f;
						float7 += (float3)vector * fixedDeltaTime;
					}
					segmentPositions[j] = float7;
					attackHelper.localTransformLookup[segments[j].segment] = LocalTransform.FromPosition(float7);
				}
			}
			attackHelper.localTransformLookup[segments[0].segment] = LocalTransform.FromPosition(segmentPositions[0]);
			segmentPositions.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle);
			BufferAccessor<SnakeSegmentsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SnakeSegmentsBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin), bufferAccessor[nextRangeBegin], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, k));
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
	[WithAll(new Type[] { typeof(SnakeMovementStateCD) })]
	[WithNone(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(DeadSnakeSegmentCD)
	})]
	private struct SnakeDamageWorldJob : IJobEntity, IJobChunk
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
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__BehaviourTagsCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BehaviourTagsCD>(isReadOnly: true);
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__BehaviourTagsCD_RO_ComponentTypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DeadSnakeSegmentCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BehaviourTagsCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SnakeMovementStateCD>();
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
			public void Run(ref SnakeDamageWorldJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SnakeDamageWorldJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SnakeDamageWorldJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SnakeDamageWorldJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SnakeDamageWorldJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SnakeDamageWorldJob job, EntityManager entityManager)
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
		public TileAccessor tileLookUp;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public BufferLookup<SnakeSegmentsBuffer> segmentsGroup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<BossLarvaCD> bossLarvaLookup;

		[ReadOnly]
		public ComponentLookup<DropsLootFromLootTableCD> dropsLootLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> indestructibleLookup;

		[ReadOnly]
		public ComponentLookup<CustomSceneObjectCD> customSceneObjectLookup;

		[ReadOnly]
		public BufferLookup<DropsLootBuffer> dropsLootBufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containerBufferLookup;

		[ReadOnly]
		public ComponentLookup<SnakeMovementAttackCooldownCD> snakeMovementAttackCooldownGroup;

		public Entity updatedTilesSingleton;

		public Entity effectEventBufferSingleton;

		public EntityCommandBuffer ecb;

		public Unity.Mathematics.Random rnd;

		public Entity tileDamageBufferEntity;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in BehaviourTagsCD attackTags, in StateInfoCD stateInfo)
		{
			ComponentLookup<SnakeMovementStateCD> snakeMovementStateLookup = attackHelper.snakeMovementStateLookup;
			ComponentLookup<LocalTransform> localTransformLookup = attackHelper.localTransformLookup;
			SnakeMovementStateCD snakeMovementStateCD = snakeMovementStateLookup[entity];
			if (!stateInfo.IsCurrentState(StateID.SnakeMovement) || !localTransformLookup.HasComponent(entity) || !snakeMovementStateCD.IsHead(entity) || !segmentsGroup.HasBuffer(entity))
			{
				return;
			}
			if (snakeMovementStateCD.tilePlacementType != SnakeMovementTilePlacementType.None)
			{
				float tilePlacementRadiusMultiplier = snakeMovementStateCD.tilePlacementRadiusMultiplier;
				float2 float5 = new float2(localTransformLookup[entity].Position.x, localTransformLookup[entity].Position.z);
				float3 x = math.mul(snakeMovementStateCD.currentRotation, new float3(0f, 0f, 1f));
				float2 xz = math.cross(x, math.up()).xz;
				int2 int5 = (int2)math.round(float5 - 3.33f * tilePlacementRadiusMultiplier * xz + 3f * tilePlacementRadiusMultiplier * x.xz);
				int2 end = (int2)math.round(float5 + 3.33f * tilePlacementRadiusMultiplier * xz + 3f * tilePlacementRadiusMultiplier * x.xz);
				int2 pos = int5;
				do
				{
					ReplaceTile(in ecb, updatedTilesSingleton, pos, ref rnd, snakeMovementStateCD.tilePlacementType, tileLookUp, collisionWorld, attackHelper.playerGhostLookup, indestructibleLookup, dropsLootLookup, customSceneObjectLookup, dropsLootBufferLookup, containerBufferLookup, tileDamageBufferEntity);
				}
				while (MathUtilities.NextPosOnLine(int5, end, ref pos));
				int5 = (int2)math.round(float5 - 1.33f * tilePlacementRadiusMultiplier * xz + 4f * tilePlacementRadiusMultiplier * x.xz);
				end = (int2)math.round(float5 + 1.33f * tilePlacementRadiusMultiplier * xz + 4f * tilePlacementRadiusMultiplier * x.xz);
				pos = int5;
				do
				{
					ReplaceTile(in ecb, updatedTilesSingleton, pos, ref rnd, snakeMovementStateCD.tilePlacementType, tileLookUp, collisionWorld, attackHelper.playerGhostLookup, indestructibleLookup, dropsLootLookup, customSceneObjectLookup, dropsLootBufferLookup, containerBufferLookup, tileDamageBufferEntity);
				}
				while (MathUtilities.NextPosOnLine(int5, end, ref pos));
			}
			if (snakeMovementStateCD.dontDealDamage)
			{
				return;
			}
			DynamicBuffer<SnakeSegmentsBuffer> dynamicBuffer = segmentsGroup[entity];
			CanOnlyAttackType canOnlyAttackType = ((!bossLookup.HasComponent(entity)) ? CanOnlyAttackType.EnemyAndPlayer : CanOnlyAttackType.All);
			bool flag = bossLarvaLookup.HasComponent(entity);
			for (int i = 0; i < dynamicBuffer.Length; i++)
			{
				if (!localTransformLookup.HasComponent(dynamicBuffer[i].segment))
				{
					continue;
				}
				SnakeMovementStateCD snakeMovementStateCD2 = snakeMovementStateLookup[dynamicBuffer[i].segment];
				SnakeMovementAttackCooldownCD component = snakeMovementAttackCooldownGroup[dynamicBuffer[i].segment];
				if (component.attackCooldown <= 0f)
				{
					component.attackCooldown = rnd.NextFloat(1f, 1.25f);
					ecb.SetComponent(dynamicBuffer[i].segment, component);
				}
				if (!snakeMovementStateCD2.disableDamage)
				{
					CanOnlyAttackType canOnlyAttackType2 = canOnlyAttackType;
					if (flag && i == 0)
					{
						canOnlyAttackType2 = CanOnlyAttackType.EnemyAndPlayer;
					}
					Entity segment = dynamicBuffer[i].segment;
					AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
					{
						effectEventBufferSingleton = effectEventBufferSingleton,
						attacker = segment,
						isRanged = false,
						attackOffset = snakeMovementStateCD.attackOffset,
						canHitLowTriggers = true,
						radius = snakeMovementStateCD.attackRadius,
						damage = (bossLookup.HasComponent(entity) ? 10000 : snakeMovementStateCD.damage),
						playerDamage = snakeMovementStateCD.damage,
						pushback = snakeMovementStateCD.pushbackForce,
						bypassMaxDamagePerHit = true,
						skipWallAndRootsLootDropOnDestroy = true,
						skipLootDropOnDestroy = snakeMovementStateCD.dontDropLootFromObjectsBeingDestroyed,
						canOnlyAttackType = canOnlyAttackType2,
						instantlyDestroyObjectsRequiringDrills = true,
						attackTime = component.attackCooldown,
						behaviourTags = attackTags,
						cantHitSpecificObject = snakeMovementStateCD.cantHitSpecificObject
					};
					attackHelper.Attack(ecb, in p);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BehaviourTagsCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BehaviourTagsCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, k));
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
	private struct SnakeBossMoveDirectionKey
	{
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public BufferLookup<SnakeSegmentsBuffer> __SnakeSegmentsBuffer_RO_BufferLookup;

		public HandleSnakePartDeathsJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle;

		public FindAvailableSnakeGroupIndexJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<SnakeSegmentCD> __SnakeSegmentCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeMovementAttackCooldownCD> __SnakeMovementAttackCooldownCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SpawnPointCD> __SpawnPointCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<RoamingPathBuffer> __RoamingPathBuffer_RO_BufferLookup;

		public SetUpHeadsAndSegmentsJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle;

		public SetUpRoamingJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<BossCD> __BossCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MusicAreaCD> __MusicAreaCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<SnakeCombatMovement> __SnakeCombatMovement_RO_ComponentLookup;

		public SnakeBossMovementJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle;

		public SnakeWormMovementJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle;

		public SnakeMovementAnimationJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle;

		public UpdateSnakeBodySegmentPositionsJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<BossLarvaCD> __BossLarvaCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DropsLootFromLootTableCD> __DropsLootFromLootTableCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IndestructibleCD> __IndestructibleCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<CustomSceneObjectCD> __CustomSceneObjectCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<DropsLootBuffer> __DropsLootBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		public SnakeDamageWorldJob.InternalCompilerQueryAndHandleData __SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SnakeSegmentsBuffer_RO_BufferLookup = state.GetBufferLookup<SnakeSegmentsBuffer>(isReadOnly: true);
			__SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeSegmentCD_RW_ComponentLookup = state.GetComponentLookup<SnakeSegmentCD>();
			__SnakeMovementAttackCooldownCD_RO_ComponentLookup = state.GetComponentLookup<SnakeMovementAttackCooldownCD>(isReadOnly: true);
			__SpawnPointCD_RO_ComponentLookup = state.GetComponentLookup<SpawnPointCD>(isReadOnly: true);
			__RoamingPathBuffer_RO_BufferLookup = state.GetBufferLookup<RoamingPathBuffer>(isReadOnly: true);
			__SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BossCD_RO_ComponentLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
			__MusicAreaCD_RO_ComponentLookup = state.GetComponentLookup<MusicAreaCD>(isReadOnly: true);
			__SnakeCombatMovement_RO_ComponentLookup = state.GetComponentLookup<SnakeCombatMovement>(isReadOnly: true);
			__SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BossLarvaCD_RO_ComponentLookup = state.GetComponentLookup<BossLarvaCD>(isReadOnly: true);
			__DropsLootFromLootTableCD_RO_ComponentLookup = state.GetComponentLookup<DropsLootFromLootTableCD>(isReadOnly: true);
			__IndestructibleCD_RO_ComponentLookup = state.GetComponentLookup<IndestructibleCD>(isReadOnly: true);
			__CustomSceneObjectCD_RO_ComponentLookup = state.GetComponentLookup<CustomSceneObjectCD>(isReadOnly: true);
			__DropsLootBuffer_RO_BufferLookup = state.GetBufferLookup<DropsLootBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003DA3_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003DA3_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003DA3_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00003DA4_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003DA4_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003DA4_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_00003DA5_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00003DA5_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00003DA5_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStartRunning_00003DA6_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00003DA6_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00003DA6_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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

	private const float DISTANCE_SQ_TO_RESET_CREATURE_OUT_OF_PLACE = 100000000f;

	private static readonly SharedStatic<float2> SnakeBossMoveDirection = SharedStatic<float2>.GetOrCreateUnsafe(0u, -884448744187431153L, 0L);

	private NativeReference<int> _availableGroupIndex;

	private AttackSystem.Helper _attackHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2046689501_0;

	private EntityQuery __query_2046689501_1;

	private EntityQuery __query_2046689501_2;

	private EntityQuery __query_2046689501_3;

	private EntityQuery __query_2046689501_4;

	private EntityQuery __query_2046689501_5;

	private EntityQuery __query_2046689501_6;

	private EntityQuery __query_2046689501_7;

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("setSnakeBossMoveDirection", "Sets Snake Boss moving direction, useful for recording trailers.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void SetSnakeBossMoveDirection(Vector2 direction)
	{
		SnakeBossMoveDirection.Data = direction.normalized;
	}

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("resetSnakeBossMoveDirection", "Resets Snake Boss moving direction.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void ResetSnakeBossMoveDirection()
	{
	}

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<PhysicsWorldHistorySingleton>();
		_availableGroupIndex = new NativeReference<int>(Allocator.Persistent);
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_availableGroupIndex.Dispose();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		int simulationTickRate = __query_2046689501_0.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		_attackHelper = new AttackSystem.Helper(ref state, simulationTickRate);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		uint simulationTickRate = (uint)__query_2046689501_0.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		__query_2046689501_1.TryGetSingleton<NetworkTime>(out var value);
		_attackHelper.Update(ref state, value.ServerTick, simulationTickRate);
		double elapsedTime = state.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = __query_2046689501_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		float deltaTime = state.WorldUnmanaged.Time.DeltaTime;
		SharedStatic<float2> snakeBossMoveDirection = SnakeBossMoveDirection;
		NativeList<Entity> uninitializedSnakeSegments = new NativeList<Entity>(state.WorldUpdateAllocator);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new HandleSnakePartDeathsJob
		{
			attackHelper = _attackHelper,
			segmentsGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SnakeSegmentsBuffer_RO_BufferLookup, ref state),
			ecb = ecb,
			time = elapsedTime
		}, __TypeHandle.__SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_1(new FindAvailableSnakeGroupIndexJob
		{
			availableGroupIndexLocal = _availableGroupIndex,
			uninitializedSnakeSegments = uninitializedSnakeSegments
		}, __TypeHandle.__SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_2(new SetUpHeadsAndSegmentsJob
		{
			attackHelper = _attackHelper,
			snakeSegmentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeSegmentCD_RW_ComponentLookup, ref state),
			snakeMovementAttackCooldownLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeMovementAttackCooldownCD_RO_ComponentLookup, ref state),
			spawnPointLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnPointCD_RO_ComponentLookup, ref state),
			roamingPathLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__RoamingPathBuffer_RO_BufferLookup, ref state),
			ecb = ecb,
			availableGroupIndexLocal = _availableGroupIndex,
			uninitializedSnakeSegments = uninitializedSnakeSegments,
			databaseBankCD = __query_2046689501_3.GetSingleton<PugDatabase.DatabaseBankCD>(),
			rnd = PugRandom.GetRng(),
			time = elapsedTime
		}, __TypeHandle.__SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_3(new SetUpRoamingJob
		{
			ecb = ecb
		}, __TypeHandle.__SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_4(new SnakeBossMovementJob
		{
			attackHelper = _attackHelper,
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			segmentsGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SnakeSegmentsBuffer_RO_BufferLookup, ref state),
			musicGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MusicAreaCD_RO_ComponentLookup, ref state),
			snakeCombatMovementLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeCombatMovement_RO_ComponentLookup, ref state),
			ecb = ecb,
			rnd = PugRandom.GetRng(),
			time = elapsedTime,
			fixedDeltaTime = deltaTime,
			snakeBossMoveDirection = snakeBossMoveDirection.Data
		}, __TypeHandle.__SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_5(new SnakeWormMovementJob
		{
			attackHelper = _attackHelper,
			tileLookup = _attackHelper.GetTileAccessor(),
			segmentsGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SnakeSegmentsBuffer_RO_BufferLookup, ref state),
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			snakeCombatMovementLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeCombatMovement_RO_ComponentLookup, ref state),
			ecb = ecb,
			rnd = PugRandom.GetRng(),
			time = elapsedTime,
			fixedDeltaTime = deltaTime
		}, __TypeHandle.__SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_6(new SnakeMovementAnimationJob
		{
			currentTick = value.ServerTick
		}, __TypeHandle.__SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_7(new UpdateSnakeBodySegmentPositionsJob
		{
			attackHelper = _attackHelper,
			spawnPointLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SpawnPointCD_RO_ComponentLookup, ref state),
			time = elapsedTime,
			fixedDeltaTime = deltaTime
		}, __TypeHandle.__SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_8(new SnakeDamageWorldJob
		{
			attackHelper = _attackHelper,
			tileLookUp = _attackHelper.GetTileAccessor(),
			collisionWorld = __query_2046689501_4.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
			segmentsGroup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SnakeSegmentsBuffer_RO_BufferLookup, ref state),
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			bossLarvaLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossLarvaCD_RO_ComponentLookup, ref state),
			dropsLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DropsLootFromLootTableCD_RO_ComponentLookup, ref state),
			indestructibleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IndestructibleCD_RO_ComponentLookup, ref state),
			customSceneObjectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CustomSceneObjectCD_RO_ComponentLookup, ref state),
			dropsLootBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__DropsLootBuffer_RO_BufferLookup, ref state),
			containerBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
			snakeMovementAttackCooldownGroup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SnakeMovementAttackCooldownCD_RO_ComponentLookup, ref state),
			updatedTilesSingleton = __query_2046689501_5.GetSingletonEntity(),
			effectEventBufferSingleton = __query_2046689501_6.GetSingletonEntity(),
			ecb = ecb,
			rnd = PugRandom.GetRng(),
			tileDamageBufferEntity = __query_2046689501_7.GetSingletonEntity()
		}, __TypeHandle.__SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	private static float3 CubicBezier(float3 p0, float3 p1, float3 p2, float3 p3, float t)
	{
		float num = t * t;
		return num * t * (-p0 + 3f * p1 - 3f * p2 + p3) + num * (3f * p0 - 6f * p1 + 3f * p2) + t * (-3f * p0 + 3f * p1) + p0;
	}

	private static float3 GetTangent(NativeArray<float3> segmentPositions, int i)
	{
		if (i == 0)
		{
			float3 tangent = GetTangent(segmentPositions, 1);
			return segmentPositions[1] - segmentPositions[i] - tangent * 0.5f * 2f;
		}
		if (i == segmentPositions.Length - 1)
		{
			float3 tangent2 = GetTangent(segmentPositions, i - 1);
			return segmentPositions[i] - segmentPositions[i - 1] - tangent2 * 0.5f * 2f;
		}
		return (segmentPositions[i + 1] - segmentPositions[i - 1]) * 1f / 4f;
	}

	private static float EaseOutCubic(float t)
	{
		return (t -= 1f) * t * t + 1f;
	}

	private static void ReplaceTile(in EntityCommandBuffer ecb, Entity updatedTilesSingleton, int2 tilePos, ref Unity.Mathematics.Random rnd, SnakeMovementTilePlacementType tilePlacementType, TileAccessor tileLookUp, CollisionWorld collisionWorld, ComponentLookup<PlayerGhost> playerLookUp, ComponentLookup<IndestructibleCD> indestructibleLookUp, ComponentLookup<DropsLootFromLootTableCD> dropsLootLookUp, ComponentLookup<CustomSceneObjectCD> customSceneObjectLookUp, BufferLookup<DropsLootBuffer> dropsLootBufferLookUp, BufferLookup<ContainedObjectsBuffer> containerBufferLookUp, Entity tileDamageBufferEntity)
	{
		if (tilePlacementType == SnakeMovementTilePlacementType.None || tileLookUp.HasType(tilePos, TileType.immune))
		{
			return;
		}
		switch (tilePlacementType)
		{
		case SnakeMovementTilePlacementType.Slime:
		{
			ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
			{
				command = TileUpdateBuffer.Command.Clear,
				position = tilePos
			});
			ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
			{
				command = TileUpdateBuffer.Command.Add,
				position = tilePos,
				tile = new TileCD
				{
					tileset = 0,
					tileType = TileType.ground
				}
			});
			uint seed = (uint)(math.abs(tilePos.GetHashCode()) + 1);
			rnd.InitState(seed);
			if (rnd.NextFloat() > 0.2f)
			{
				ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Add,
					position = tilePos,
					tile = new TileCD
					{
						tileset = 0,
						tileType = TileType.dugUpGround
					}
				});
			}
			if (rnd.NextFloat() > 0.5f)
			{
				ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Add,
					position = tilePos,
					tile = new TileCD
					{
						tileset = 0,
						tileType = TileType.groundSlime
					}
				});
			}
			break;
		}
		case SnakeMovementTilePlacementType.SeaWater:
		{
			NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
			bool flag = false;
			if (collisionWorld.SphereCastAll(tilePos.ToFloat3(), 1f, float3.zero, 0f, ref outHits, new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 687967u
			}))
			{
				for (int i = 0; i < outHits.Length; i++)
				{
					Entity entity = outHits[i].Entity;
					if (playerLookUp.HasComponent(entity) || indestructibleLookUp.HasAndIsComponentEnabled(entity) || (customSceneObjectLookUp.HasComponent(entity) && (dropsLootLookUp.HasComponent(entity) || dropsLootBufferLookUp.HasComponent(entity) || containerBufferLookUp.HasComponent(entity))))
					{
						flag = true;
						break;
					}
				}
			}
			outHits.Dispose();
			if (!flag)
			{
				TileCD top = tileLookUp.GetTop(tilePos);
				if (top.tileType != TileType.water || top.tileset != 10)
				{
					ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Clear,
						position = tilePos
					});
					ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Add,
						position = tilePos,
						tile = new TileCD
						{
							tileset = 10,
							tileType = TileType.water
						}
					});
				}
			}
			break;
		}
		case SnakeMovementTilePlacementType.Ground:
			HydraBossSystem.DestroyTilesWithinRadius(1.2f, new float3(tilePos.x, 0f, tilePos.y), ecb, tileDamageBufferEntity);
			break;
		}
	}

	public static float SignedAngle(float3 from, float3 to, float3 axis)
	{
		float num = math.acos(math.dot(math.normalizesafe(from), math.normalizesafe(to)));
		float num2 = math.sign(math.dot(axis, math.cross(from, to)));
		return math.degrees(num * num2);
	}

	public static float3 FindNearestPointOnLine(float3 origin, float3 end, float3 point)
	{
		float3 x = end - origin;
		float upperBound = math.length(x);
		x = math.normalizesafe(x);
		float valueToClamp = math.dot(point - origin, x);
		valueToClamp = math.clamp(valueToClamp, 0f, upperBound);
		return origin + x * valueToClamp;
	}

	[BurstDiscard]
	private static void DebugDrawSnakeMovement(float3 worldPosition, SnakeMovementStateCD snakeMovement)
	{
		float3 float5 = EntityMonoBehaviour.ToRenderFromWorld(worldPosition + new float3(0f, 4f, 0f));
		UnityEngine.Debug.DrawLine(float5, float5 + snakeMovement.currentDirection * 2f, Color.green);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(HandleSnakePartDeathsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_HandleSnakePartDeathsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(FindAvailableSnakeGroupIndexJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_FindAvailableSnakeGroupIndexJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(SetUpHeadsAndSegmentsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_SetUpHeadsAndSegmentsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(SetUpRoamingJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_SetUpRoamingJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(SnakeBossMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_SnakeBossMovementJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_5(SnakeWormMovementJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_SnakeWormMovementJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_6(SnakeMovementAnimationJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_SnakeMovementAnimationJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_7(UpdateSnakeBodySegmentPositionsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_UpdateSnakeBodySegmentPositionsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_8(SnakeDamageWorldJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SnakeMovementStateSystem_SnakeDamageWorldJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2046689501_7 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00003DA3_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003DA4_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00003DA5_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00003DA6_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((SnakeMovementStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SnakeMovementStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeMovementStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeMovementStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeMovementStateSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SnakeMovementStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}
}
