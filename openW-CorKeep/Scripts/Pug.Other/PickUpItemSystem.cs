using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using PlayerState;
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
using UnityEngine;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[UpdateBefore(typeof(EndPredictedSimulationSystemGroup))]
public struct PickUpItemSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct UpdatePickUpDistanceJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				public ComponentTypeHandle<AutoPickUpItemCD> __AutoPickUpItemCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__AutoPickUpItemCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AutoPickUpItemCD>();
					__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__AutoPickUpItemCD_RW_ComponentTypeHandle.Update(ref state);
					__SummarizedConditionsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SummarizedConditionsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AutoPickUpItemCD>();
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
			public void Run(ref UpdatePickUpDistanceJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdatePickUpDistanceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdatePickUpDistanceJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdatePickUpDistanceJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdatePickUpDistanceJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdatePickUpDistanceJob job, EntityManager entityManager)
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

		private const float BASE_PICKUP_DISTANCE = 1.4f;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(ref AutoPickUpItemCD autoPickUpItem, in DynamicBuffer<SummarizedConditionsBuffer> conditionsBuffer)
		{
			int index = 181;
			float num = (float)conditionsBuffer[index].value / 100f;
			autoPickUpItem.pickupDistance = 1.4f * (1f + num);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AutoPickUpItemCD_RW_ComponentTypeHandle);
			BufferAccessor<SummarizedConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr, i), bufferAccessor[i]);
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
						Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr, j), bufferAccessor[j]);
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr, k), bufferAccessor[k]);
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
	private struct GatherCanPickupJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<AutoPickUpItemCD> __AutoPickUpItemCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__AutoPickUpItemCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AutoPickUpItemCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__AutoPickUpItemCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<AutoPickUpItemCD>();
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
			public void Run(ref GatherCanPickupJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref GatherCanPickupJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref GatherCanPickupJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref GatherCanPickupJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref GatherCanPickupJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref GatherCanPickupJob job, EntityManager entityManager)
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

		public NativeParallelMultiHashMap<int2, Entity> CanPickupPositions;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, in AutoPickUpItemCD autoPickUpItem, in LocalTransform transform)
		{
			int2 int5 = (int2)math.floor(transform.Position.xz - autoPickUpItem.pickupDistance);
			int2 int6 = (int2)math.ceil(transform.Position.xz + autoPickUpItem.pickupDistance);
			for (int i = int5.x; i <= int6.x; i++)
			{
				for (int j = int5.y; j <= int6.y; j++)
				{
					CanPickupPositions.Add(new int2(i, j), entity);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__AutoPickUpItemCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AutoPickUpItemCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
	private struct StartPickUpJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PickUpItemCD> __PickUpItemCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PickUpItemCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PickUpItemCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PickUpItemCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RO_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PickUpItemCD>();
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
			public void Run(ref StartPickUpJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref StartPickUpJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref StartPickUpJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref StartPickUpJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref StartPickUpJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref StartPickUpJob job, EntityManager entityManager)
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

		private const float REENTER_DISTANCE_SQ = 2.25f;

		public TileAccessor TileAccessor;

		public CollisionWorld CollisionWorld;

		public NetworkTick Tick;

		[ReadOnly]
		public NativeParallelMultiHashMap<int2, Entity> CanPickupPositions;

		[ReadOnly]
		public ComponentLookup<AutoPickUpItemCD> AutoPickUpItemLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> LocalTransformLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> InventoryLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> PlayerStateLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> ContainedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<InventorySlotRequirementBuffer> SlotRequirementLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> ObjectTagsLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> PlayerGhostLookup;

		[ReadOnly]
		public ComponentLookup<InventoryAutoTransferEnabledCD> InventoryAutoTransferEnabledLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> DirectionLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> DoorLookup;

		[ReadOnly]
		public ComponentLookup<AffectObjectWhenMelodyPlayedCD> AffectObjectWhenMelodyPlayedLookup;

		[ReadOnly]
		public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> OverrideAlwaysAllowToBeTrashedLookup;

		public NativeList<Unity.Physics.RaycastHit> RayCastHitsCached;

		public bool IsGuestMode;

		public PugDatabase.DatabaseBankCD Database;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref PickUpItemCD pickUpItem, in LocalTransform transform, in DynamicBuffer<ContainedObjectsBuffer> containedObject)
		{
			if (containedObject.Length == 0)
			{
				UnityEngine.Debug.LogError("pickup system got dropped item with empty inventory");
				return;
			}
			PickUpItemState state = pickUpItem.state;
			if (state == PickUpItemState.IsBeingPickedUp || state == PickUpItemState.HasBeenPickedUp)
			{
				return;
			}
			float2 xz = transform.Position.xz;
			bool currentEntityIsValid = false;
			if (pickUpItem.state == PickUpItemState.ForcePickUp && (AutoPickUpItemLookup.HasComponent(pickUpItem.targetEntity) || InventoryAutoTransferEnabledLookup.HasComponent(pickUpItem.targetEntity)) && CheckIfCanPickup(entity, ref pickUpItem, pickUpItem.targetEntity, xz, containedObject[0].objectData, ref currentEntityIsValid))
			{
				return;
			}
			if (!CanPickupPositions.TryGetFirstValue((int2)xz, out var item, out var it))
			{
				pickUpItem.state = PickUpItemState.None;
				pickUpItem.targetEntity = Entity.Null;
				pickUpItem.ignoreRayChecksForPickup = false;
				return;
			}
			ObjectDataCD objectData = containedObject[0].objectData;
			while (!CheckIfCanPickup(entity, ref pickUpItem, item, xz, objectData, ref currentEntityIsValid) && CanPickupPositions.TryGetNextValue(out item, ref it))
			{
			}
			if (pickUpItem.state != PickUpItemState.IsBeingPickedUp && pickUpItem.state != PickUpItemState.HasBeenPickedUp && pickUpItem.targetEntity != Entity.Null && !currentEntityIsValid)
			{
				pickUpItem.state = PickUpItemState.None;
				pickUpItem.targetEntity = Entity.Null;
				pickUpItem.ignoreRayChecksForPickup = false;
			}
		}

		private bool CheckIfCanPickup(Entity entity, ref PickUpItemCD pickUpItem, Entity canPickupEntity, float2 position, ObjectDataCD containedObjectData, ref bool currentEntityIsValid)
		{
			float num = float.NaN;
			if ((PlayerStateLookup.HasComponent(canPickupEntity) && PlayerController.IsDyingOrDead(PlayerStateLookup[canPickupEntity])) || EntityDestroyedLookup.HasAndIsComponentEnabled(canPickupEntity))
			{
				return false;
			}
			if (IsGuestMode)
			{
				PlayerGhostLookup.TryGetComponent(canPickupEntity, out var componentData);
				if (componentData.adminPrivileges <= 0)
				{
					return false;
				}
			}
			PickUpItemState state = pickUpItem.state;
			if ((state == PickUpItemState.BlockPickupUntilReEnterStart || state == PickUpItemState.BlockPickupUntilReEnterHasMovedAway) && pickUpItem.targetEntity == canPickupEntity)
			{
				currentEntityIsValid = true;
				float num2 = math.lengthsq(LocalTransformLookup[canPickupEntity].Position.xz - position);
				if (pickUpItem.state == PickUpItemState.BlockPickupUntilReEnterStart && num2 < 2.25f)
				{
					return false;
				}
				pickUpItem.state = PickUpItemState.BlockPickupUntilReEnterHasMovedAway;
				AutoPickUpItemCD autoPickUpItemCD = AutoPickUpItemLookup[canPickupEntity];
				if (num2 > autoPickUpItemCD.pickupDistance * autoPickUpItemCD.pickupDistance)
				{
					pickUpItem.state = PickUpItemState.None;
					pickUpItem.targetEntity = Entity.Null;
					pickUpItem.ignoreRayChecksForPickup = false;
					return false;
				}
				num = 2.25f;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectData.objectID, Database.databaseBankBlob, containedObjectData.variation);
			ObjectTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData2);
			if (!InventoryUtility.HasRoomForObject(Database, ContainedObjectsBufferLookup[canPickupEntity], InventoryLookup[canPickupEntity], SlotRequirementLookup[canPickupEntity], OverrideAlwaysAllowToBeTrashedLookup, componentData2, containedObjectData.objectID, containedObjectData.variation))
			{
				return false;
			}
			float3 position2 = LocalTransformLookup[canPickupEntity].Position;
			float3 baselinePickupPosition = position2;
			DirectionLookup.TryGetComponent(canPickupEntity, out var componentData3);
			ObjectDataLookup.TryGetComponent(canPickupEntity, out var componentData4);
			position2 = PickUpSystemHelpers.GetPickupPosition(canPickupEntity, position2, componentData4.objectID, componentData4.variation, componentData3.direction, Database, InventoryAutoTransferEnabledLookup);
			if (float.IsNaN(num))
			{
				num = ((!AutoPickUpItemLookup.TryGetComponent(canPickupEntity, out var componentData5)) ? 2.1474836E+09f : (componentData5.pickupDistance * componentData5.pickupDistance));
			}
			if (pickUpItem.state != PickUpItemState.ForcePickUp && !(math.lengthsq(position2.xz - position) < num))
			{
				return false;
			}
			if (!pickUpItem.ignoreRayChecksForPickup && PickupCollidesWithDoorOrWall(baselinePickupPosition, position))
			{
				return false;
			}
			pickUpItem.targetEntity = canPickupEntity;
			pickUpItem.distanceWhenStartingPickUp = math.length(position2.xz - position);
			pickUpItem.targetPrevPos = position2.xz;
			pickUpItem.tickWhenStartingPickUp = Tick;
			pickUpItem.state = PickUpItemState.IsBeingPickedUp;
			pickUpItem.ignoreRayChecksForPickup = false;
			return true;
		}

		private bool PickupCollidesWithDoorOrWall(float3 baselinePickupPosition, float2 droppedItemPosition)
		{
			float2 float5 = baselinePickupPosition.xz - droppedItemPosition;
			float y = math.length(float5);
			float num = math.min(0.4f, y);
			float2 x = droppedItemPosition + float5 * num;
			float2 float6 = math.round(x);
			float5 = baselinePickupPosition.xz - float6;
			y = math.length(float5);
			if (y > float.Epsilon && SinglePugMap.RaycastWalls(float6, math.normalizesafe(float5), y, out var _, TileAccessor))
			{
				return true;
			}
			RaycastInput input = new RaycastInput
			{
				Start = new float3(x.x, 0.5f, x.y),
				End = new float3(baselinePickupPosition.x, 0.5f, baselinePickupPosition.z),
				Filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 1u,
					GroupIndex = 0
				}
			};
			RayCastHitsCached.Clear();
			if (CollisionWorld.CastRay(input, ref RayCastHitsCached))
			{
				for (int i = 0; i < RayCastHitsCached.Length; i++)
				{
					Entity entity = RayCastHitsCached[i].Entity;
					if (DoorLookup.HasComponent(entity) || AffectObjectWhenMelodyPlayedLookup.HasComponent(entity))
					{
						return true;
					}
				}
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PickUpItemCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), bufferAccessor[i]);
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), bufferAccessor[nextRangeBegin]);
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), bufferAccessor[j]);
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), bufferAccessor[k]);
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
	private struct SetPickedUpItemPredictedJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PickUpItemCD> __PickUpItemCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD> __MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PickUpItemCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PickUpItemCD>();
					__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MoveToPredictedByCombatOrInventoryInteractionCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PickUpItemCD_RW_ComponentTypeHandle.Update(ref state);
					__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PickUpItemCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MoveToPredictedByCombatOrInventoryInteractionCD>();
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
			public void Run(ref SetPickedUpItemPredictedJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SetPickedUpItemPredictedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SetPickedUpItemPredictedJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SetPickedUpItemPredictedJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SetPickedUpItemPredictedJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SetPickedUpItemPredictedJob job, EntityManager entityManager)
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
		public ComponentLookup<PredictedGhost> PredictedGhostLookup;

		public NetworkTick CurrentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, PickUpItemCD pickUpItem, ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD)
		{
			if (pickUpItem.state == PickUpItemState.IsBeingPickedUp || pickUpItem.state == PickUpItemState.HasBeenPickedUp)
			{
				moveToPredictedByCombatOrInventoryInteractionCD.SetLastInteractionTick(CurrentTick);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PickUpItemCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__MoveToPredictedByCombatOrInventoryInteractionCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref PickUpItemCD reference = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, i);
					ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, i);
					Execute(entity, reference, ref moveToPredictedByCombatOrInventoryInteractionCD);
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
						ref PickUpItemCD reference2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, nextRangeBegin);
						ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, nextRangeBegin);
						Execute(entity2, reference2, ref moveToPredictedByCombatOrInventoryInteractionCD2);
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
					ref PickUpItemCD reference3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, j);
					ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, j);
					Execute(entity3, reference3, ref moveToPredictedByCombatOrInventoryInteractionCD3);
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
					ref PickUpItemCD reference4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, k);
					ref MoveToPredictedByCombatOrInventoryInteractionCD moveToPredictedByCombatOrInventoryInteractionCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MoveToPredictedByCombatOrInventoryInteractionCD>(nativeArrayPtr3, k);
					Execute(entity4, reference4, ref moveToPredictedByCombatOrInventoryInteractionCD4);
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
		typeof(Simulate),
		typeof(ContainedObjectsBuffer)
	})]
	[WithNone(new Type[] { typeof(EntityDestroyedCD) })]
	private struct PickUpJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public ComponentTypeHandle<PickUpItemCD> __PickUpItemCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PickUpItemCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PickUpItemCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PickUpItemCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PickUpItemCD>();
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
			public void Run(ref PickUpJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref PickUpJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref PickUpJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref PickUpJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref PickUpJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref PickUpJob job, EntityManager entityManager)
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

		public NetworkTick Tick;

		public float TickFraction;

		public float TimePerTick;

		[ReadOnly]
		public ComponentLookup<LocalTransform> LocalTransformLookup;

		public BufferLookup<ContainedObjectsBuffer> ContainedObjectsBufferLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> InventoryLookup;

		[ReadOnly]
		public BufferLookup<InventorySlotRequirementBuffer> SlotRequirementLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> ObjectTagsLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> PlayerStateLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> ObjectDataLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> DirectionLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> EntityDestroyedLookup;

		[ReadOnly]
		public ComponentLookup<InventoryAutoTransferEnabledCD> InventoryAutoTransferEnabledLookup;

		[ReadOnly]
		public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> OverrideAlwaysAllowToBeTrashedLookup;

		public BufferLookup<InventoryChangeBuffer> InventoryHandlerCommandBufferLookup;

		public Entity InventoryHandlerCommandBufferEntity;

		public PugDatabase.DatabaseBankCD Database;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity entity, ref PickUpItemCD pickUpItem, in LocalTransform itemTransform)
		{
			if (pickUpItem.state != PickUpItemState.IsBeingPickedUp)
			{
				return;
			}
			if (!LocalTransformLookup.TryGetComponent(pickUpItem.targetEntity, out var componentData) || !CanPickup(entity, pickUpItem.targetEntity, ContainedObjectsBufferLookup[entity][0].objectData))
			{
				pickUpItem.state = PickUpItemState.None;
				pickUpItem.targetEntity = Entity.Null;
				pickUpItem.ignoreRayChecksForPickup = false;
				return;
			}
			float3 position = componentData.Position;
			DirectionLookup.TryGetComponent(pickUpItem.targetEntity, out var componentData2);
			ObjectDataLookup.TryGetComponent(pickUpItem.targetEntity, out var componentData3);
			float2 xz = PickUpSystemHelpers.GetPickupPosition(pickUpItem.targetEntity, position, componentData3.objectID, componentData3.variation, componentData2.direction, Database, InventoryAutoTransferEnabledLookup).xz;
			float2 xz2 = itemTransform.Position.xz;
			float additionalDistanceMovedAdded;
			float num = PickUpSystemHelpers.DistanceMoved(pickUpItem, Tick, TickFraction, TimePerTick, xz2, xz, pickUpItem.targetPrevPos, pickUpItem.additionalDistanceMoved, out additionalDistanceMovedAdded);
			pickUpItem.additionalDistanceMoved += additionalDistanceMovedAdded;
			pickUpItem.targetPrevPos = xz;
			float num2 = num + 0.3f;
			if (pickUpItem.distanceWhenStartingPickUp > num2)
			{
				return;
			}
			if (InventoryHandlerCommandBufferEntity == Entity.Null)
			{
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = ContainedObjectsBufferLookup[entity];
				for (int i = 0; i < dynamicBuffer.Length; i++)
				{
					dynamicBuffer[i] = default(ContainedObjectsBuffer);
				}
			}
			else
			{
				DynamicBuffer<InventoryChangeBuffer> dynamicBuffer2 = InventoryHandlerCommandBufferLookup[InventoryHandlerCommandBufferEntity];
				InventoryChangeData inventoryChangeData = Create.MoveOrDropAllItems(entity, pickUpItem.targetEntity, -1, -1, xz2.X0Y());
				dynamicBuffer2.Add(new InventoryChangeBuffer
				{
					inventoryChangeData = inventoryChangeData,
					playerEntity = pickUpItem.targetEntity
				});
				pickUpItem.state = PickUpItemState.HasBeenPickedUp;
			}
		}

		private bool CanPickup(Entity objectEntity, Entity canPickupEntity, ObjectDataCD containedObjectData)
		{
			if ((PlayerStateLookup.HasComponent(canPickupEntity) && PlayerController.IsDyingOrDead(PlayerStateLookup[canPickupEntity])) || EntityDestroyedLookup.HasAndIsComponentEnabled(canPickupEntity))
			{
				return false;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectData.objectID, Database.databaseBankBlob, containedObjectData.variation);
			ObjectTagsLookup.TryGetComponent(primaryPrefabEntity, out var componentData);
			if (!InventoryUtility.HasRoomForObject(Database, ContainedObjectsBufferLookup[canPickupEntity], InventoryLookup[canPickupEntity], SlotRequirementLookup[canPickupEntity], OverrideAlwaysAllowToBeTrashedLookup, componentData, containedObjectData.objectID, containedObjectData.variation))
			{
				return false;
			}
			return true;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__PickUpItemCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
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
						Execute(entity2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
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
					Execute(entity4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PickUpItemCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
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
		public BufferLookup<InventoryChangeBuffer> __Inventory_InventoryChangeBuffer_RW_BufferLookup;

		public UpdatePickUpDistanceJob.InternalCompilerQueryAndHandleData __PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle;

		public GatherCanPickupJob.InternalCompilerQueryAndHandleData __PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<AutoPickUpItemCD> __AutoPickUpItemCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<InventoryBuffer> __InventoryBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<PlayerStateCD> __PlayerState_PlayerStateCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public BufferLookup<InventorySlotRequirementBuffer> __InventorySlotRequirementBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectCategoryTagsCD> __ObjectCategoryTagsCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<InventoryAutoTransferEnabledCD> __InventoryAutoTransferEnabledCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DoorCD> __DoorCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AffectObjectWhenMelodyPlayedCD> __AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<OverrideLegendaryForSlotRequirementsCD> __OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup;

		public StartPickUpJob.InternalCompilerQueryAndHandleData __PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle;

		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferLookup;

		public PickUpJob.InternalCompilerQueryAndHandleData __PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<PredictedGhost> __Unity_NetCode_PredictedGhost_RO_ComponentLookup;

		public SetPickedUpItemPredictedJob.InternalCompilerQueryAndHandleData __PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Inventory_InventoryChangeBuffer_RW_BufferLookup = state.GetBufferLookup<InventoryChangeBuffer>();
			__PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__AutoPickUpItemCD_RO_ComponentLookup = state.GetComponentLookup<AutoPickUpItemCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__InventoryBuffer_RO_BufferLookup = state.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
			__PlayerState_PlayerStateCD_RO_ComponentLookup = state.GetComponentLookup<PlayerStateCD>(isReadOnly: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__InventorySlotRequirementBuffer_RO_BufferLookup = state.GetBufferLookup<InventorySlotRequirementBuffer>(isReadOnly: true);
			__ObjectCategoryTagsCD_RO_ComponentLookup = state.GetComponentLookup<ObjectCategoryTagsCD>(isReadOnly: true);
			__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
			__InventoryAutoTransferEnabledCD_RO_ComponentLookup = state.GetComponentLookup<InventoryAutoTransferEnabledCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
			__DoorCD_RO_ComponentLookup = state.GetComponentLookup<DoorCD>(isReadOnly: true);
			__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup = state.GetComponentLookup<AffectObjectWhenMelodyPlayedCD>(isReadOnly: true);
			__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup = state.GetComponentLookup<OverrideLegendaryForSlotRequirementsCD>(isReadOnly: true);
			__PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ContainedObjectsBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
			__PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__Unity_NetCode_PredictedGhost_RO_ComponentLookup = state.GetComponentLookup<PredictedGhost>(isReadOnly: true);
			__PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00002B28_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00002B28_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00002B28_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00002B29_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00002B29_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00002B29_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_00002B2A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00002B2A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00002B2A_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_587780749_0;

	private EntityQuery __query_587780749_1;

	private EntityQuery __query_587780749_2;

	private EntityQuery __query_587780749_3;

	private EntityQuery __query_587780749_4;

	private EntityQuery __query_587780749_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
	}

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		__query_587780749_0.TryGetSingleton<NetworkTime>(out var value);
		if (VariableSystemUpdate.ShouldUpdate(ref state, value, 2, 10f))
		{
			BufferLookup<InventoryChangeBuffer> inventoryHandlerCommandBufferLookup = default(BufferLookup<InventoryChangeBuffer>);
			if (__query_587780749_1.TryGetSingletonEntity<InventoryChangeBuffer>(out var value2))
			{
				inventoryHandlerCommandBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__Inventory_InventoryChangeBuffer_RW_BufferLookup, ref state);
			}
			if (!__query_587780749_2.TryGetSingleton<ClientServerTickRate>(out var value3))
			{
				value3.ResolveDefaults();
			}
			PugDatabase.DatabaseBankCD singleton = __query_587780749_3.GetSingleton<PugDatabase.DatabaseBankCD>();
			state.Dependency = __ScheduleViaJobChunkExtension_0(default(UpdatePickUpDistanceJob), __TypeHandle.__PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			NativeParallelMultiHashMap<int2, Entity> canPickupPositions = new NativeParallelMultiHashMap<int2, Entity>(256, state.WorldUpdateAllocator);
			GatherCanPickupJob job = new GatherCanPickupJob
			{
				CanPickupPositions = canPickupPositions
			};
			state.Dependency = __ScheduleViaJobChunkExtension_1(job, __TypeHandle.__PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			__query_587780749_4.TryGetSingleton<WorldInfoCD>(out var value4);
			_tileAccessor.Update(ref state);
			StartPickUpJob job2 = new StartPickUpJob
			{
				TileAccessor = _tileAccessor,
				CollisionWorld = __query_587780749_5.GetSingleton<PhysicsWorldSingleton>().CollisionWorld,
				Tick = value.ServerTick,
				CanPickupPositions = canPickupPositions,
				AutoPickUpItemLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AutoPickUpItemCD_RO_ComponentLookup, ref state),
				LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				InventoryLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventoryBuffer_RO_BufferLookup, ref state),
				PlayerStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup, ref state),
				ContainedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
				SlotRequirementLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventorySlotRequirementBuffer_RO_BufferLookup, ref state),
				ObjectTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
				PlayerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
				InventoryAutoTransferEnabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InventoryAutoTransferEnabledCD_RO_ComponentLookup, ref state),
				DirectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
				ObjectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				DoorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DoorCD_RO_ComponentLookup, ref state),
				AffectObjectWhenMelodyPlayedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AffectObjectWhenMelodyPlayedCD_RO_ComponentLookup, ref state),
				OverrideAlwaysAllowToBeTrashedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup, ref state),
				IsGuestMode = value4.guestMode,
				Database = singleton,
				RayCastHitsCached = new NativeList<Unity.Physics.RaycastHit>(8, state.WorldUpdateAllocator)
			};
			state.Dependency = __ScheduleViaJobChunkExtension_2(job2, __TypeHandle.__PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			PickUpJob job3 = new PickUpJob
			{
				Tick = value.ServerTick,
				TickFraction = value.ServerTickFraction,
				TimePerTick = 1f / (float)value3.SimulationTickRate,
				LocalTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
				ContainedObjectsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref state),
				InventoryLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventoryBuffer_RO_BufferLookup, ref state),
				SlotRequirementLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__InventorySlotRequirementBuffer_RO_BufferLookup, ref state),
				ObjectTagsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectCategoryTagsCD_RO_ComponentLookup, ref state),
				PlayerStateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerState_PlayerStateCD_RO_ComponentLookup, ref state),
				DirectionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
				ObjectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
				EntityDestroyedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup, ref state),
				InventoryAutoTransferEnabledLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__InventoryAutoTransferEnabledCD_RO_ComponentLookup, ref state),
				OverrideAlwaysAllowToBeTrashedLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OverrideLegendaryForSlotRequirementsCD_RO_ComponentLookup, ref state),
				InventoryHandlerCommandBufferLookup = inventoryHandlerCommandBufferLookup,
				InventoryHandlerCommandBufferEntity = value2,
				Database = singleton
			};
			state.Dependency = __ScheduleViaJobChunkExtension_3(job3, __TypeHandle.__PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			if (state.WorldUnmanaged.IsClient())
			{
				SetPickedUpItemPredictedJob job4 = new SetPickedUpItemPredictedJob
				{
					PredictedGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_PredictedGhost_RO_ComponentLookup, ref state),
					CurrentTick = value.ServerTick
				};
				state.Dependency = __ScheduleViaJobChunkExtension_4(job4, __TypeHandle.__PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdatePickUpDistanceJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PickUpItemSystem_UpdatePickUpDistanceJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(GatherCanPickupJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PickUpItemSystem_GatherCanPickupJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(StartPickUpJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PickUpItemSystem_StartPickUpJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(PickUpJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PickUpItemSystem_PickUpJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(SetPickedUpItemPredictedJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__PickUpItemSystem_SetPickedUpItemPredictedJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_587780749_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<InventoryChangeBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_587780749_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_587780749_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_587780749_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_587780749_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_587780749_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00002B28_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00002B29_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00002B2A_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((PickUpItemSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((PickUpItemSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((PickUpItemSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PickUpItemSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PickUpItemSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((PickUpItemSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
