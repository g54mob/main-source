using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
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
[UpdateInGroup(typeof(PredictedSimulationSystemGroup))]
[UpdateAfter(typeof(SetEntitiesDestroyedSystem))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct DropLootSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TriggerCD : IComponentData, IQueryTypeParameter
	{
	}

	public struct LootChest
	{
		public Entity ecbEntity;

		public int2 position;

		public ObjectDataCD chestObjectData;

		public int currentSlotIndex;

		public int inventoryLength;
	}

	public struct LootChestItem
	{
		public int chestIndex;

		public ContainedObjectsBuffer itemInfo;
	}

	[BurstCompile]
	private struct CheckIfAnyDropLootEntitiesJob : IJobChunk
	{
		public NativeReference<bool> anyDropLootEntities;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count).NextEntityIndex(out var _))
			{
				anyDropLootEntities.Value = true;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct ResetTriggerJob : IJob
	{
		public EntityCommandBuffer ecb;

		public NativeReference<bool> anyDropLootEntities;

		public NativeArray<Entity> triggerEntities;

		public void Execute()
		{
			if (!anyDropLootEntities.Value)
			{
				ecb.DestroyEntity(triggerEntities);
			}
		}
	}

	[BurstCompile]
	[WithAll(new Type[]
	{
		typeof(DropLootDelayCD),
		typeof(Simulate)
	})]
	private struct UpdateDropLootDelayJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__EntityDestroyedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
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
			public void Run(ref UpdateDropLootDelayJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateDropLootDelayJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateDropLootDelayJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateDropLootDelayJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateDropLootDelayJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateDropLootDelayJob job, EntityManager entityManager)
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

		public ComponentLookup<DropLootDelayCD> dropLootDelayLookup;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in EntityDestroyedCD entityDestroyedCD)
		{
			if (entityDestroyedCD.destroyTimer.GetElapsedSeconds(currentTick, tickRate) >= dropLootDelayLookup[entity].Value)
			{
				dropLootDelayLookup.SetComponentEnabled(entity, value: false);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, k));
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
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithDisabled(new Type[] { typeof(StartDroppingLootCD) })]
	[WithNone(new Type[] { typeof(PlayerGhost) })]
	private struct StartDroppingLootJob : IJobEntity, IJobChunk
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
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
			public void Run(ref StartDroppingLootJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref StartDroppingLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref StartDroppingLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref StartDroppingLootJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref StartDroppingLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref StartDroppingLootJob job, EntityManager entityManager)
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

		public ComponentLookup<StartDroppingLootCD> startDroppingLootLookup;

		public bool isFirstTimeFullyPredictingTick;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity)
		{
			ref StartDroppingLootCD valueRW = ref startDroppingLootLookup.GetRefRW(entity).ValueRW;
			if ((valueRW.localLastStartTick.IsValid && valueRW.localLastStartTick.TicksSince(currentTick) < tickRate) || isFirstTimeFullyPredictingTick)
			{
				startDroppingLootLookup.SetComponentEnabled(entity, value: true);
				valueRW.localLastStartTick = currentTick;
			}
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
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD)
	})]
	[WithAny(new Type[]
	{
		typeof(DropsLootFromLootTableCD),
		typeof(DropsLootBuffer)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropBossChestJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BossCD> __BossCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__BossCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BossCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__BossCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<DropsLootFromLootTableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAny<DropsLootBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BossCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
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
			public void Run(ref DropBossChestJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropBossChestJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropBossChestJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropBossChestJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropBossChestJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropBossChestJob job, EntityManager entityManager)
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
		public TileAccessor tileLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public PugDatabase.DatabaseBankCD databaseLocal;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> containedObjectBufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup;

		public EntityCommandBuffer ecb;

		public NativeList<LootChest> lootChests;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(in ObjectDataCD objectData, in LocalTransform transform, in BossCD boss)
		{
			ObjectDataCD objectDataCD = (boss.spawnOptionalChest ? boss.optionalChestVersion : boss.chestToSpawn);
			if (objectDataCD.objectID != ObjectID.None)
			{
				int2 entitySize = PugDatabase.GetEntitySize(objectDataCD.objectID, databaseLocal.databaseBankBlob, objectDataCD.variation);
				float3 float5 = transform.Position + boss.chestSpawnOffset + PugDatabase.GetEntityLocalCenter(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation);
				if (math.lengthsq(boss.chestSpawnPositionOverride) > 0.1f)
				{
					float5 = boss.chestSpawnPositionOverride;
				}
				int2 int5 = float5.RoundToInt2();
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectDataCD.objectID, databaseLocal.databaseBankBlob);
				bool value = false;
				if (objectPropertiesLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
				{
					componentData.TryGet<bool>(-1535225238, out value);
				}
				if (IsBlockedByExistingObjects(int5, entitySize, value, tileLookup))
				{
					EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = objectDataCD.objectID,
							amount = 1,
							variation = 0
						}
					}, float5, databaseLocal.databaseBankBlob);
					return;
				}
				LootChest value2 = new LootChest
				{
					position = int5,
					chestObjectData = new ObjectDataCD
					{
						objectID = objectDataCD.objectID,
						variation = objectDataCD.variation
					},
					currentSlotIndex = 0
				};
				Entity prefabEntity;
				Entity ecbEntity = EntityUtility.CreateEntity(ecb, value2.position.ToFloat3(), value2.chestObjectData.objectID, 1, databaseLocal.databaseBankBlob, out prefabEntity, value2.chestObjectData.variation);
				value2.inventoryLength = containedObjectBufferLookup[prefabEntity].Length;
				value2.ecbEntity = ecbEntity;
				lootChests.Add(in value2);
			}
		}

		private bool IsBlockedByExistingObjects(int2 basePosition, int2 size, bool canBePlacedOnLava, TileAccessor tileAccessor)
		{
			for (int i = 0; i < size.y; i++)
			{
				for (int j = 0; j < size.x; j++)
				{
					int2 worldPosition = basePosition + new int2(j, i);
					CollisionFilter filter = new CollisionFilter
					{
						BelongsTo = uint.MaxValue,
						CollidesWith = 1u
					};
					if (!collisionWorld.CheckSphere(new float3(worldPosition.x, 0.25f, worldPosition.y), 0f, filter))
					{
						continue;
					}
					if (canBePlacedOnLava)
					{
						TileCD top = tileAccessor.GetTop(worldPosition);
						if (top.tileType == TileType.water && top.tileset == 3)
						{
							continue;
						}
					}
					return true;
				}
			}
			return false;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__BossCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossCD>(nativeArrayPtr3, i));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossCD>(nativeArrayPtr3, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BossCD>(nativeArrayPtr3, k));
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
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropLootFromLootTablesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DropsLootFromLootTableCD> __DropsLootFromLootTableCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__DropsLootFromLootTableCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DropsLootFromLootTableCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__DropsLootFromLootTableCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DropsLootFromLootTableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref DropLootFromLootTablesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropLootFromLootTablesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropLootFromLootTablesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropLootFromLootTablesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropLootFromLootTablesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropLootFromLootTablesJob job, EntityManager entityManager)
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
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> enemyLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> distanceToPlayerLookup;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public LootTableBankCD lootBankLocal;

		public EntityCommandBuffer ecb;

		public NativeList<LootChest> lootChests;

		public NativeList<LootChestItem> lootChestItems;

		public float bossLootDropMultiplier;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in ObjectDataCD objectdata, in LocalTransform transform, in DropsLootFromLootTableCD dropsLoot, ref RandomCD rand)
		{
			if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
			{
				componentData = default(KilledByPlayerCD);
			}
			bool flag = bossLookup.HasComponent(entity);
			if (!enemyLookup.HasComponent(entity) || flag || !distanceToPlayerLookup.TryGetComponent(entity, out var componentData2) || !(componentData2.minDistanceSq > 10000f))
			{
				float lootAmountMultiplier = 1f;
				if (flag)
				{
					lootAmountMultiplier = bossLootDropMultiplier;
				}
				float3 float5 = (flag ? bossLookup[entity].chestSpawnOffset : float3.zero);
				float3 float6 = transform.Position + float5 + PugDatabase.GetEntityLocalCenter(objectdata.objectID, databaseLocal.databaseBankBlob, objectdata.variation);
				if (flag && math.lengthsq(bossLookup[entity].chestSpawnPositionOverride) > 0.1f)
				{
					float6 = bossLookup[entity].chestSpawnPositionOverride;
				}
				int2 entitySize = PugDatabase.GetEntitySize(objectdata.objectID, databaseLocal.databaseBankBlob, objectdata.variation);
				LootChest lootChest;
				int lootChestIndex;
				bool num = HasLootChest(float6.RoundToInt2(), lootChests, out lootChest, out lootChestIndex);
				EntityUtility.DropLoot(biome: biomeLookup.GetBiome(float6.RoundToInt2()), ecb: ecb, lootTableID: dropsLoot.lootTableID, rand: ref rand.Value, initialPos: float6, entityInfoBank: databaseLocal.databaseBankBlob, lootTableBank: lootBankLocal.Value, lootChest: ref lootChest, lootChestIndex: lootChestIndex, maxPositionOffset: 0.3f * (float)entitySize.x, pullTowardsPlayerEntity: componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null, lootAmountMultiplier: lootAmountMultiplier, optionalInventoryToPutLootIn: lootChestItems, skipCreate: !isFirstTimeFullyPredictingTick);
				if (num)
				{
					UpdateLootChest(lootChest, lootChests);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DropsLootFromLootTableCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DropsLootFromLootTableCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DropsLootFromLootTableCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DropsLootFromLootTableCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DropsLootFromLootTableCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k));
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
		typeof(PlayerGhost),
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD),
		typeof(SpawnedByStreamIntegrationCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropLootFromLootBuffersJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public BufferTypeHandle<DropsLootBuffer> __DropsLootBuffer_RO_BufferTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__DropsLootBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<DropsLootBuffer>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__DropsLootBuffer_RO_BufferTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<SpawnedByStreamIntegrationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DropsLootBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref DropLootFromLootBuffersJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropLootFromLootBuffersJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropLootFromLootBuffersJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropLootFromLootBuffersJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropLootFromLootBuffersJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropLootFromLootBuffersJob job, EntityManager entityManager)
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
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<ChanceToDropLootCD> chanceToDropLootLookup;

		[ReadOnly]
		public ComponentLookup<PlantCD> plantLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> growingLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		public NativeArray<ActivatedContentBundlesBuffer> activatedContentBundles;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public EntityCommandBuffer ecb;

		public NativeList<LootChest> lootChests;

		public NativeList<LootChestItem> lootChestItems;

		public NativeList<CanBeScannedCD> scannedMarkers;

		public int playerCount;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in ObjectDataCD objectData, in LocalTransform transform, in DynamicBuffer<DropsLootBuffer> dropsLootBuffer, ref RandomCD rand, in ObjectPropertiesCD properties)
		{
			if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
			{
				componentData = default(KilledByPlayerCD);
			}
			float3 entityLocalCenter = PugDatabase.GetEntityLocalCenter(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation);
			float3 float5 = transform.Position + entityLocalCenter;
			if (bossLookup.TryGetComponent(entity, out var componentData2))
			{
				float5 = componentData2.chestSpawnOffset + transform.Position;
				if (math.lengthsq(componentData2.chestSpawnPositionOverride) > 0.1f)
				{
					float5 = bossLookup[entity].chestSpawnPositionOverride;
				}
			}
			LootChest lootChest;
			int lootChestIndex;
			bool flag = HasLootChest(float5.RoundToInt2(), lootChests, out lootChest, out lootChestIndex);
			for (int i = 0; i < dropsLootBuffer.Length; i++)
			{
				DropsLootBuffer dropsLootBuffer2 = dropsLootBuffer[i];
				if (dropsLootBuffer2.skipIfScanned.TryGetValue(out var output))
				{
					bool flag2 = false;
					foreach (CanBeScannedCD scannedMarker in scannedMarkers)
					{
						if (scannedMarker.objectData.objectID == output)
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						continue;
					}
				}
				if (dropsLootBuffer2.requiredContentBundle.TryGetValue(out var output2))
				{
					bool flag3 = true;
					foreach (ActivatedContentBundlesBuffer activatedContentBundle in activatedContentBundles)
					{
						if (activatedContentBundle.ContentBundle == output2)
						{
							flag3 = false;
							break;
						}
					}
					if (flag3)
					{
						continue;
					}
				}
				float3 position = float5 + new float3(rand.Value.NextFloat(-0.3f, 0.3f), 0f, rand.Value.NextFloat(-0.3f, 0.3f));
				float num = 1f;
				if (chanceToDropLootLookup.TryGetComponent(entity, out var componentData3))
				{
					num = componentData3.chance;
				}
				if (plantLookup.HasComponent(entity))
				{
					if (growingLookup.TryGetComponent(entity, out var componentData4) && !componentData4.HasFinishedGrowing(properties))
					{
						num = 1f;
					}
					if (componentData.playerEntity != Entity.Null && summarizedConditionsBufferLookup.TryGetBuffer(componentData.playerEntity, out var bufferData))
					{
						num += (float)bufferData[127].value / 100f;
					}
				}
				if (!(rand.Value.NextFloat() <= num) || dropsLootBuffer2.lootDropID == ObjectID.None)
				{
					continue;
				}
				int num2 = (int)math.round((float)dropsLootBuffer2.amount * (1f + (float)math.max(0, playerCount - 1) * dropsLootBuffer2.multiplayerAmountAdditionScaling));
				int num3 = 1;
				if (!PugDatabase.GetEntityObjectInfo(dropsLootBuffer2.lootDropID, databaseLocal.databaseBankBlob).isStackable)
				{
					num3 = num2;
					num2 = PugDatabase.GetEntityObjectInfo(dropsLootBuffer2.lootDropID, databaseLocal.databaseBankBlob).initialAmount;
				}
				ContainedObjectsBuffer containedObjectsBuffer = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = dropsLootBuffer2.lootDropID,
						amount = num2
					}
				};
				Entity pullTowardsPlayerEntity = (componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
				for (int j = 0; j < num3; j++)
				{
					if (flag && lootChest.currentSlotIndex < lootChest.inventoryLength)
					{
						ref NativeList<LootChestItem> reference = ref lootChestItems;
						LootChestItem value = new LootChestItem
						{
							chestIndex = lootChestIndex,
							itemInfo = containedObjectsBuffer
						};
						reference.Add(in value);
						lootChest.currentSlotIndex++;
					}
					else if (isFirstTimeFullyPredictingTick)
					{
						EntityUtility.DropNewEntity(ecb, containedObjectsBuffer, position, databaseLocal.databaseBankBlob, pullTowardsPlayerEntity);
					}
				}
			}
			if (flag)
			{
				UpdateLootChest(lootChest, lootChests);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			BufferAccessor<DropsLootBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__DropsLootBuffer_RO_BufferTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), bufferAccessor[nextRangeBegin], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr5, k));
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
		typeof(PlayerGhost),
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropSeasonalLootJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SeasonalLootCD> __SeasonalLootCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SeasonalLootCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SeasonalLootCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SeasonalLootCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SeasonalLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref DropSeasonalLootJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropSeasonalLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropSeasonalLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropSeasonalLootJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropSeasonalLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropSeasonalLootJob job, EntityManager entityManager)
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
		public ComponentLookup<BossCD> bossLookup;

		[ReadOnly]
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public EntityCommandBuffer ecb;

		public NativeList<LootChest> lootChests;

		public NativeList<LootChestItem> lootChestItems;

		public int playerCount;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in ObjectDataCD objectData, in LocalTransform transform, in SeasonalLootCD seasonalLootCD, ref RandomCD rand)
		{
			if (!seasonalLootCD.requirementToDropFulfilled)
			{
				return;
			}
			if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
			{
				componentData = default(KilledByPlayerCD);
			}
			float3 entityLocalCenter = PugDatabase.GetEntityLocalCenter(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation);
			float3 float5 = transform.Position + entityLocalCenter;
			if (bossLookup.TryGetComponent(entity, out var componentData2))
			{
				float5 = componentData2.chestSpawnOffset + transform.Position;
				if (math.lengthsq(componentData2.chestSpawnPositionOverride) > 0.1f)
				{
					float5 = bossLookup[entity].chestSpawnPositionOverride;
				}
			}
			LootChest lootChest;
			int lootChestIndex;
			bool flag = HasLootChest(float5.RoundToInt2(), lootChests, out lootChest, out lootChestIndex);
			ref BlobArray<SeasonalLootInfo> value = ref seasonalLootCD.lootBlob.Value;
			for (int i = 0; i < value.Length; i++)
			{
				SeasonalLootInfo seasonalLootInfo = value[i];
				float3 position = float5 + new float3(rand.Value.NextFloat(-0.3f, 0.3f), 0f, rand.Value.NextFloat(-0.3f, 0.3f));
				float chance = seasonalLootInfo.chance;
				if (!(rand.Value.NextFloat() <= chance) || seasonalLootInfo.lootDropID == ObjectID.None)
				{
					continue;
				}
				int num = (int)math.round((float)seasonalLootInfo.amount * (1f + (float)math.max(0, playerCount - 1) * seasonalLootInfo.multiplayerAmountAdditionScaling));
				int num2 = 1;
				if (!PugDatabase.GetEntityObjectInfo(seasonalLootInfo.lootDropID, databaseLocal.databaseBankBlob).isStackable)
				{
					num2 = num;
					num = PugDatabase.GetEntityObjectInfo(seasonalLootInfo.lootDropID, databaseLocal.databaseBankBlob).initialAmount;
				}
				ContainedObjectsBuffer containedObjectsBuffer = new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = seasonalLootInfo.lootDropID,
						amount = num
					}
				};
				Entity pullTowardsPlayerEntity = (componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
				for (int j = 0; j < num2; j++)
				{
					if (flag && lootChest.currentSlotIndex < lootChest.inventoryLength)
					{
						ref NativeList<LootChestItem> reference = ref lootChestItems;
						LootChestItem value2 = new LootChestItem
						{
							chestIndex = lootChestIndex,
							itemInfo = containedObjectsBuffer
						};
						reference.Add(in value2);
						lootChest.currentSlotIndex++;
					}
					else if (isFirstTimeFullyPredictingTick)
					{
						EntityUtility.DropNewEntity(ecb, containedObjectsBuffer, position, databaseLocal.databaseBankBlob, pullTowardsPlayerEntity);
					}
				}
			}
			if (flag)
			{
				UpdateLootChest(lootChest, lootChests);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SeasonalLootCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeasonalLootCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeasonalLootCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeasonalLootCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SeasonalLootCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k));
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
	private struct FinalizeLootChestSpawnJob : IJob
	{
		public EntityCommandBuffer ecb;

		[ReadOnly]
		public NativeList<LootChest> lootChests;

		[ReadOnly]
		public NativeList<LootChestItem> lootChestItems;

		public void Execute()
		{
			for (int i = 0; i < lootChests.Length; i++)
			{
				LootChest lootChest = lootChests[i];
				DynamicBuffer<ContainedObjectsBuffer> dynamicBuffer = ecb.SetBuffer<ContainedObjectsBuffer>(lootChest.ecbEntity);
				dynamicBuffer.Length = lootChest.inventoryLength;
				for (int j = 0; j < dynamicBuffer.Length; j++)
				{
					dynamicBuffer[j] = default(ContainedObjectsBuffer);
				}
				int num = 0;
				for (int k = 0; k < lootChestItems.Length; k++)
				{
					if (lootChestItems[k].chestIndex == i)
					{
						dynamicBuffer[num] = lootChestItems[k].itemInfo;
						num++;
					}
				}
			}
		}
	}

	[BurstCompile]
	[WithNone(new Type[]
	{
		typeof(DontDropSelfCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropHarvestedPlantsLootJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlantCD> __PlantCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<GrowingCD> __GrowingCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__PlantCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlantCD>(isReadOnly: true);
					__GrowingCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GrowingCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__PlantCD_RO_ComponentTypeHandle.Update(ref state);
					__GrowingCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropSelfCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlantCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<GrowingCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref DropHarvestedPlantsLootJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropHarvestedPlantsLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropHarvestedPlantsLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropHarvestedPlantsLootJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropHarvestedPlantsLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropHarvestedPlantsLootJob job, EntityManager entityManager)
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
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public EntityCommandBuffer ecb;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in PlantCD plant, in GrowingCD growing, ref RandomCD rand, in ObjectPropertiesCD properties)
		{
			if (growing.HasFinishedGrowing(properties))
			{
				if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
				{
					componentData = default(KilledByPlayerCD);
				}
				float3 position = transform.Position + new float3(rand.Value.NextFloat(-0.3f, 0.3f), 0f, rand.Value.NextFloat(-0.3f, 0.3f));
				if (isFirstTimeFullyPredictingTick)
				{
					ObjectID objectToDropWhenHarvested = plant.objectToDropWhenHarvested;
					ContainedObjectsBuffer containedObject = new ContainedObjectsBuffer
					{
						objectData = new ObjectDataCD
						{
							objectID = objectToDropWhenHarvested,
							amount = plant.numberOfPlantsToDrop
						}
					};
					EntityUtility.DropNewEntity(ecb, containedObject, position, databaseLocal.databaseBankBlob, componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlantCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__GrowingCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlantCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlantCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlantCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlantCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<GrowingCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr6, k));
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
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD),
		typeof(SpawnedByStreamIntegrationCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct SpawnEntityOnDeathJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SpawnEntityOnDeathCD> __SpawnEntityOnDeathCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SpawnEntityOnDeathCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnEntityOnDeathCD>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SpawnEntityOnDeathCD_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<SpawnedByStreamIntegrationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnEntityOnDeathCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref SpawnEntityOnDeathJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnEntityOnDeathJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnEntityOnDeathJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnEntityOnDeathJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnEntityOnDeathJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnEntityOnDeathJob job, EntityManager entityManager)
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
		public ComponentLookup<ObjectDataCD> objectDataLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> merchantLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> destroyTimerLookup;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public NativeList<Entity> merchants;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public bool isFirstTimeFullyPredictingTick;

		public NetworkTick currentTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in SpawnEntityOnDeathCD spawnEntityOnDeath, in ObjectDataCD objectData, ref RandomCD rand)
		{
			if (spawnEntityOnDeath.maxAmountAllowedWithinRadius > 0 && spawnEntityOnDeath.maxAmountCheckRadius > 0f)
			{
				int num = 0;
				NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
				if (collisionWorld.OverlapSphere(transform.Position, spawnEntityOnDeath.maxAmountCheckRadius, ref outHits, CollisionFilter.Default))
				{
					for (int i = 0; i < outHits.Length; i++)
					{
						Entity entity2 = outHits[i].Entity;
						if (objectDataLookup.TryGetComponent(entity2, out var componentData) && componentData.objectID == spawnEntityOnDeath.objectToSpawn)
						{
							num++;
						}
					}
				}
				outHits.Dispose();
				if (num >= spawnEntityOnDeath.maxAmountAllowedWithinRadius)
				{
					return;
				}
			}
			if (rand.Value.NextFloat() >= spawnEntityOnDeath.spawnChance)
			{
				return;
			}
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(spawnEntityOnDeath.objectToSpawn, databaseLocal.databaseBankBlob, spawnEntityOnDeath.objectVariation);
			if (merchantLookup.HasComponent(primaryPrefabEntity))
			{
				for (int j = 0; j < merchants.Length; j++)
				{
					if (objectDataLookup[merchants[j]].objectID == spawnEntityOnDeath.objectToSpawn)
					{
						return;
					}
				}
			}
			if (spawnEntityOnDeath.dontSpawnIfKilledByDestroyTimer && destroyTimerLookup.HasComponent(entity) && destroyTimerLookup.TryGetComponent(entity, out var componentData2) && componentData2.timer.IsTimerElapsed(currentTick))
			{
				return;
			}
			int num2 = rand.Value.NextInt(spawnEntityOnDeath.amount.min, spawnEntityOnDeath.amount.max + 1);
			if (isFirstTimeFullyPredictingTick)
			{
				for (int k = 0; k < num2; k++)
				{
					Entity e = EntityUtility.CreateEntity(ecb, spawnEntityOnDeath.objectToSpawn, 1, databaseLocal.databaseBankBlob, spawnEntityOnDeath.objectVariation);
					LocalTransform component = transform;
					component.Position += spawnEntityOnDeath.offset;
					ecb.SetComponent(e, component);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SpawnEntityOnDeathCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntityOnDeathCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntityOnDeathCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntityOnDeathCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnEntityOnDeathCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k));
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
		typeof(MineableCD),
		typeof(DiggableCD)
	})]
	[WithNone(new Type[]
	{
		typeof(TileCD),
		typeof(PlantCD),
		typeof(DontDropSelfCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropSelfJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<MineableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAny<DiggableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<TileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<PlantCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DontDropSelfCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
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
			public void Run(ref DropSelfJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropSelfJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropSelfJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropSelfJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropSelfJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropSelfJob job, EntityManager entityManager)
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
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<AlwaysDropVariationZeroCD> alwaysDropVariationZeroLookup;

		[ReadOnly]
		public ComponentLookup<AlwaysDropOneCD> alwaysDropOneLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseLocal;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in ObjectDataCD objectData)
		{
			if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
			{
				componentData = default(KilledByPlayerCD);
			}
			DirectionCD componentData2;
			float3 float5 = (directionLookup.TryGetComponent(entity, out componentData2) ? PugDatabase.GetEntityLocalCenter(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation, componentData2.direction.x) : PugDatabase.GetEntityLocalCenter(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation));
			float3 position = transform.Position + float5;
			EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
			{
				objectData = new ObjectDataCD
				{
					objectID = objectData.objectID,
					amount = math.max(1, alwaysDropOneLookup.HasComponent(entity) ? 1 : objectData.amount),
					variation = ((!alwaysDropVariationZeroLookup.HasComponent(entity)) ? objectData.variation : 0)
				}
			}, position, databaseLocal.databaseBankBlob, componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k));
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
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct SpawnTileJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SpawnTileOnDeathCD> __SpawnTileOnDeathCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SpawnTileOnDeathCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnTileOnDeathCD>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SpawnTileOnDeathCD_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<SpawnTileOnDeathCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref SpawnTileJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref SpawnTileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref SpawnTileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref SpawnTileJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref SpawnTileJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref SpawnTileJob job, EntityManager entityManager)
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
		public ComponentLookup<DirectionCD> directionLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public Entity updatedTilesSingleton;

		public TileAccessor tileAccessor;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in SpawnTileOnDeathCD spawnTileOnDeath, in ObjectDataCD objectData, ref RandomCD rand)
		{
			if (rand.Value.NextFloat() >= spawnTileOnDeath.spawnChance)
			{
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (directionLookup.TryGetComponent(entity, out var componentData))
			{
				componentData.GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			int2 int5 = transform.Position.RoundToInt2();
			for (int i = offset.x; i < size.x + offset.y; i++)
			{
				for (int j = offset.y; j < size.y + offset.y; j++)
				{
					int2 int6 = int5 + new int2(i, j);
					if (spawnTileOnDeath.clearOtherTiles)
					{
						tileUpdateBufferLookup[updatedTilesSingleton].Add(new TileUpdateBuffer
						{
							command = TileUpdateBuffer.Command.Clear,
							position = int6
						});
					}
					if (spawnTileOnDeath.tileType == TileType.wall && !tileAccessor.GetType(int6, TileType.ground, out var tileCD) && PugDatabase.TileExists((int)spawnTileOnDeath.tileset, TileType.ground, databaseLocal.databaseBankBlob))
					{
						tileUpdateBufferLookup[updatedTilesSingleton].Add(new TileUpdateBuffer
						{
							command = TileUpdateBuffer.Command.Clear,
							position = int6
						});
						tileUpdateBufferLookup[updatedTilesSingleton].Add(new TileUpdateBuffer
						{
							command = TileUpdateBuffer.Command.Add,
							position = int6,
							tile = new TileCD
							{
								tileset = (int)spawnTileOnDeath.tileset,
								tileType = TileType.ground
							}
						});
					}
					DynamicBuffer<TileUpdateBuffer> dynamicBuffer = tileUpdateBufferLookup[updatedTilesSingleton];
					TileUpdateBuffer elem = new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Add,
						position = int6
					};
					tileCD = (elem.tile = new TileCD
					{
						tileset = (int)spawnTileOnDeath.tileset,
						tileType = spawnTileOnDeath.tileType
					});
					dynamicBuffer.Add(elem);
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SpawnTileOnDeathCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnDeathCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnDeathCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnDeathCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnTileOnDeathCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k));
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
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct RemoveTileJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<RemoveTileOnDeathCD> __RemoveTileOnDeathCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__RemoveTileOnDeathCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RemoveTileOnDeathCD>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__RemoveTileOnDeathCD_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RemoveTileOnDeathCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref RemoveTileJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RemoveTileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RemoveTileJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RemoveTileJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RemoveTileJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RemoveTileJob job, EntityManager entityManager)
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
		public TileAccessor tileAccessor;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public Entity updatedTilesSingleton;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in LocalTransform transform, in RemoveTileOnDeathCD removeTileOnDeathCD, in ObjectDataCD objectData, ref RandomCD rand)
		{
			if (rand.Value.NextFloat() >= removeTileOnDeathCD.removeChance)
			{
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (directionLookup.TryGetComponent(entity, out var componentData))
			{
				componentData.GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			int2 int5 = transform.Position.RoundToInt2();
			for (int i = offset.x; i < size.x + offset.y; i++)
			{
				for (int j = offset.y; j < size.y + offset.y; j++)
				{
					int2 int6 = int5 + new int2(i, j);
					if (tileAccessor.HasTypeAndTileset(int6, removeTileOnDeathCD.tileType, (int)removeTileOnDeathCD.tileset))
					{
						tileUpdateBufferLookup[updatedTilesSingleton].Add(new TileUpdateBuffer
						{
							command = TileUpdateBuffer.Command.Remove,
							position = int6,
							tile = new TileCD
							{
								tileType = removeTileOnDeathCD.tileType,
								tileset = 0
							}
						});
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__RemoveTileOnDeathCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RemoveTileOnDeathCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RemoveTileOnDeathCD>(nativeArrayPtr3, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RemoveTileOnDeathCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RemoveTileOnDeathCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr5, k));
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
		typeof(DontDropLootCD),
		typeof(DropLootDelayCD)
	})]
	[WithAll(new Type[]
	{
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropContainedEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__ContainedObjectsBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__ContainedObjectsBuffer_RW_BufferTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__ObjectDataCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontDropLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ContainedObjectsBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref DropContainedEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropContainedEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropContainedEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropContainedEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropContainedEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropContainedEntitiesJob job, EntityManager entityManager)
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
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		public EntityCommandBuffer ecb;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, ref DynamicBuffer<ContainedObjectsBuffer> containedObjects, in LocalTransform transform, in ObjectDataCD objectDataCD, ref RandomCD rand)
		{
			if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
			{
				componentData = default(KilledByPlayerCD);
			}
			DirectionCD componentData2;
			float3 float5 = (directionLookup.TryGetComponent(entity, out componentData2) ? PugDatabase.GetEntityLocalCenter(objectDataCD.objectID, databaseLocal.databaseBankBlob, objectDataCD.variation, componentData2.direction.x) : PugDatabase.GetEntityLocalCenter(objectDataCD.objectID, databaseLocal.databaseBankBlob, objectDataCD.variation));
			float3 float6 = transform.Position + float5;
			for (int i = 0; i < containedObjects.Length; i++)
			{
				ContainedObjectsBuffer containedObject = containedObjects[i];
				if (containedObject.objectID != ObjectID.None)
				{
					bool isStackable = PugDatabase.GetEntityObjectInfo(containedObject.objectID, databaseLocal.databaseBankBlob, containedObject.variation).isStackable;
					if (containedObject.amount > 0 || !isStackable)
					{
						float3 position = float6 + new float3(rand.Value.NextFloat(-0.3f, 0.3f), 0f, rand.Value.NextFloat(-0.3f, 0.3f));
						if (isFirstTimeFullyPredictingTick)
						{
							EntityUtility.DropNewEntity(ecb, containedObject, position, databaseLocal.databaseBankBlob, componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
						}
					}
				}
				containedObjects[i] = default(ContainedObjectsBuffer);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					DynamicBuffer<ContainedObjectsBuffer> containedObjects = bufferAccessor[i];
					Execute(entity, ref containedObjects, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, i));
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
						DynamicBuffer<ContainedObjectsBuffer> containedObjects2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, ref containedObjects2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, nextRangeBegin));
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
					DynamicBuffer<ContainedObjectsBuffer> containedObjects3 = bufferAccessor[j];
					Execute(entity3, ref containedObjects3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, j));
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
					DynamicBuffer<ContainedObjectsBuffer> containedObjects4 = bufferAccessor[k];
					Execute(entity4, ref containedObjects4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr4, k));
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
	[WithNone(new Type[] { typeof(DropLootDelayCD) })]
	[WithAll(new Type[]
	{
		typeof(TileCD),
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithAny(new Type[]
	{
		typeof(MineableCD),
		typeof(DiggableCD)
	})]
	[WithAll(new Type[] { typeof(StartDroppingLootCD) })]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct DropTilesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<TileCD> __TileCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__TileCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TileCD>(isReadOnly: true);
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__TileCD_RO_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<MineableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAny<DiggableCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<TileCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
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
			public void Run(ref DropTilesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref DropTilesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref DropTilesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref DropTilesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref DropTilesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref DropTilesJob job, EntityManager entityManager)
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

		public ComponentLookup<FinishedDroppingLootCD> finishedDroppingLootLookup;

		[ReadOnly]
		public ComponentLookup<KilledByPlayerCD> killedByPlayerLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> dontDropLootCDLookup;

		[ReadOnly]
		public ComponentLookup<DontDropSelfCD> dontDropSelfCDLookup;

		[ReadOnly]
		public ComponentLookup<AlwaysDropVariationZeroCD> alwaysDropVariationZeroLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> conditionEffectsBuffer;

		[ReadOnly]
		public BiomeLookup biomeLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> effectEventBufferPointerLookup;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public TileAccessor tileLookup;

		public PugDatabase.DatabaseBankCD databaseLocal;

		public LootTableBankCD lootBankLocal;

		public Entity tileUpdateBufferSingleton;

		public NetworkTick tick;

		public bool isFirstTimeFullyPredictingTick;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in TileCD tile, ref RandomCD rand)
		{
			LocalTransform localTransform = localTransformLookup[entity];
			int2 int5 = (int2)math.round(new float2(localTransform.Position.x, localTransform.Position.z));
			bool flag = !dontDropLootCDLookup.HasComponent(entity) || !dontDropLootCDLookup.IsComponentEnabled(entity);
			bool flag2 = !dontDropSelfCDLookup.HasComponent(entity) || !dontDropSelfCDLookup.IsComponentEnabled(entity);
			NativeArray<TileCD> array = tileLookup.Get(int5, Allocator.Temp);
			array.Sort();
			if (flag2)
			{
				ecb.SetComponentEnabled<DontDropSelfCD>(entity, value: true);
			}
			if (killedByPlayerLookup.TryGetComponent(entity, out var componentData) && !killedByPlayerLookup.IsComponentEnabled(entity))
			{
				componentData = default(KilledByPlayerCD);
			}
			NativeList<TileType> neededTile = new NativeList<TileType>(4, Allocator.Temp);
			for (int i = 0; i < array.Length; i++)
			{
				bool flag3 = array[i].tileType.IsContainedResource();
				bool flag4 = array[i].Equals(tile);
				bool flag5 = false;
				neededTile.Clear();
				array[i].tileType.GetNeededTile(ref neededTile);
				for (int j = 0; j < neededTile.Length; j++)
				{
					flag5 |= neededTile[j] == tile.tileType;
				}
				if (!flag3 && !flag4 && !flag5)
				{
					continue;
				}
				if ((flag && ((flag4 && flag2) || flag5)) || flag3)
				{
					TileType tileType = array[i].tileType;
					if (tileType == TileType.ground)
					{
						tileType = TileType.wall;
					}
					ObjectDataCD objectData = PugDatabase.GetObjectData(array[i].tileset, tileType, databaseLocal.databaseBankBlob);
					if (PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation).objectType != ObjectType.NonObtainable)
					{
						float x = rand.Value.NextFloat(-0.3f, 0.3f);
						float z = rand.Value.NextFloat(-0.3f, 0.3f);
						float3 float5 = localTransform.Position + new float3(x, 0f, z);
						float5.y = 0f;
						if (flag3 && rand.Value.NextFloat() <= 0.15f)
						{
							objectData.amount++;
						}
						if (flag3 && componentData.playerEntity != Entity.Null && conditionEffectsBuffer.HasComponent(componentData.playerEntity) && rand.Value.NextFloat() <= (float)conditionEffectsBuffer[componentData.playerEntity][45].value / 100f)
						{
							objectData.amount++;
						}
						if (flag4 && array[i].tileType == TileType.wall && componentData.playerEntity != Entity.Null && conditionEffectsBuffer.HasComponent(componentData.playerEntity) && rand.Value.NextFloat() <= (float)conditionEffectsBuffer[componentData.playerEntity][71].value / 1000f)
						{
							int tileset = array[i].tileset;
							ObjectID objectID = ObjectID.None;
							switch (tileset)
							{
							case 11:
								objectID = ObjectID.TinOre;
								break;
							default:
								objectID = PugDatabase.GetObjectID(tileset, TileType.ore, databaseLocal.databaseBankBlob);
								break;
							case 6:
								break;
							}
							if (objectID != ObjectID.None)
							{
								float3 position = float5 + new float3(rand.Value.NextFloat(-0.2f, 0.2f), 0f, -0.2f);
								if (isFirstTimeFullyPredictingTick)
								{
									EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
									{
										objectData = new ObjectDataCD
										{
											objectID = objectID,
											amount = 1
										}
									}, position, databaseLocal.databaseBankBlob, componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
								}
							}
						}
						if (flag4 && array[i].tileType == TileType.wall && componentData.playerEntity != Entity.Null && rand.Value.NextFloat() < 0.0027027028f)
						{
							float3 position2 = localTransformLookup[componentData.playerEntity].Position;
							int2 int6 = ((MathUtilities.DominantSideF3(localTransform.Position - position2).x == 0f) ? (rand.Value.NextBool() ? new int2(1, 0) : new int2(-1, 0)) : (rand.Value.NextBool() ? new int2(0, 1) : new int2(0, -1)));
							int2 int7 = localTransform.Position.RoundToInt2() + int6;
							TileCD top = tileLookup.GetTop(int7);
							if (top.tileType == TileType.wall)
							{
								ObjectID objectID2 = BiomeAndTilesetToChest(biomeLookup.GetBiome(localTransform.Position.RoundToInt2()), (Tileset)top.tileset);
								if (objectID2 != ObjectID.None)
								{
									tileUpdateBufferLookup[tileUpdateBufferSingleton].Add(new TileUpdateBuffer
									{
										command = TileUpdateBuffer.Command.Remove,
										position = int7,
										tile = top
									});
									DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBufferLookup[componentData.playerEntity];
									ref GhostEffectEventBufferPointerCD valueRW = ref effectEventBufferPointerLookup.GetRefRW(componentData.playerEntity).ValueRW;
									GhostEffectEventBuffer item = new GhostEffectEventBuffer
									{
										Tick = tick,
										value = new EffectEventCD
										{
											position1 = int7.ToFloat3(),
											effectID = EffectID.ChestSpawn
										}
									};
									buffer.AddToRingBuffer(ref valueRW, in item);
									if (isFirstTimeFullyPredictingTick)
									{
										EntityUtility.CreateEntity(ecb, int7.ToFloat3(), objectID2, 1, databaseLocal.databaseBankBlob);
									}
								}
							}
						}
						Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseLocal.databaseBankBlob, objectData.variation);
						if (primaryPrefabEntity != Entity.Null)
						{
							objectData.variation = ((!alwaysDropVariationZeroLookup.HasComponent(primaryPrefabEntity)) ? objectData.variation : 0);
						}
						if (isFirstTimeFullyPredictingTick)
						{
							EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
							{
								objectData = objectData
							}, float5, databaseLocal.databaseBankBlob, componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
						}
						if (array[i].tileType == TileType.wall && componentData.playerEntity != Entity.Null && conditionEffectsBuffer.HasComponent(componentData.playerEntity) && rand.Value.NextFloat() < (float)conditionEffectsBuffer[componentData.playerEntity][47].value / 1000f)
						{
							Biome biome = biomeLookup.GetBiome(float5.RoundToInt2());
							EntityCommandBuffer entityCommandBuffer = ecb;
							ref Unity.Mathematics.Random value = ref rand.Value;
							float3 initialPos = float5;
							BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = databaseLocal.databaseBankBlob;
							BlobAssetReference<LootTableBankBlob> value2 = lootBankLocal.Value;
							Entity pullTowardsPlayerEntity = (componentData.shouldPullLootToPlayer ? componentData.playerEntity : Entity.Null);
							bool skipCreate = !isFirstTimeFullyPredictingTick;
							EntityUtility.DropLoot(entityCommandBuffer, LootTableID.ArcheologistWallLoot, ref value, initialPos, databaseBankBlob, value2, biome, 0.3f, pullTowardsPlayerEntity, 1f, default(DynamicBuffer<ContainedObjectsBuffer>), skipCreate);
						}
					}
				}
				tileUpdateBufferLookup[tileUpdateBufferSingleton].Add(new TileUpdateBuffer
				{
					command = TileUpdateBuffer.Command.Remove,
					position = int5,
					tile = array[i]
				});
			}
			neededTile.Dispose();
			array.Dispose();
			finishedDroppingLootLookup.SetComponentEnabled(entity, value: true);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__TileCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TileCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr3, k));
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
		typeof(StartDroppingLootCD),
		typeof(EntityDestroyedCD),
		typeof(Simulate)
	})]
	[WithNone(new Type[]
	{
		typeof(PlayerGhost),
		typeof(DropLootDelayCD)
	})]
	[WithDisabled(new Type[] { typeof(FinishedDroppingLootCD) })]
	private struct FinishDropLootJob : IJobEntity, IJobChunk
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
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithNone<DropLootDelayCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<FinishedDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<StartDroppingLootCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Simulate>();
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
			public void Run(ref FinishDropLootJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref FinishDropLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref FinishDropLootJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref FinishDropLootJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref FinishDropLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref FinishDropLootJob job, EntityManager entityManager)
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

		public ComponentLookup<FinishedDroppingLootCD> finishedDroppingLootLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity)
		{
			finishedDroppingLootLookup.SetComponentEnabled(entity, value: true);
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
	[WithNone(new Type[] { typeof(DontSerializeCD) })]
	private struct RemoveSerializeOnDeadEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__EntityDestroyedCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<DontSerializeCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
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
			public void Run(ref RemoveSerializeOnDeadEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RemoveSerializeOnDeadEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RemoveSerializeOnDeadEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RemoveSerializeOnDeadEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RemoveSerializeOnDeadEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RemoveSerializeOnDeadEntitiesJob job, EntityManager entityManager)
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
		public ComponentLookup<DropLootDelayCD> dropLootDelayLookup;

		public EntityCommandBuffer ecb;

		public NetworkTick currentTick;

		public uint tickRate;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in EntityDestroyedCD entityDestroyed)
		{
			if (!dropLootDelayLookup.TryGetComponent(entity, out var componentData) || !(entityDestroyed.destroyTimer.GetElapsedSeconds(currentTick, tickRate) < componentData.Value))
			{
				ecb.AddComponent<DontSerializeCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EntityDestroyedCD>(nativeArrayPtr2, k));
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
		public ComponentLookup<DropLootDelayCD> __DropLootDelayCD_RW_ComponentLookup;

		public UpdateDropLootDelayJob.InternalCompilerQueryAndHandleData __DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<StartDroppingLootCD> __StartDroppingLootCD_RW_ComponentLookup;

		public StartDroppingLootJob.InternalCompilerQueryAndHandleData __DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		[ReadOnly]
		public ComponentLookup<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup;

		public DropBossChestJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<KilledByPlayerCD> __KilledByPlayerCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AlwaysDropVariationZeroCD> __AlwaysDropVariationZeroCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<AlwaysDropOneCD> __AlwaysDropOneCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		public DropSelfJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<BossCD> __BossCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentLookup;

		public DropLootFromLootTablesJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ChanceToDropLootCD> __ChanceToDropLootCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<PlantCD> __PlantCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<GrowingCD> __GrowingCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

		public DropLootFromLootBuffersJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle;

		public DropSeasonalLootJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle;

		public DropHarvestedPlantsLootJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MerchantCD> __MerchantCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestroyTimerCD> __DestroyTimerCD_RO_ComponentLookup;

		public SpawnEntityOnDeathJob.InternalCompilerQueryAndHandleData __DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle;

		public DropContainedEntitiesJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		public SpawnTileJob.InternalCompilerQueryAndHandleData __DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle;

		public RemoveTileJob.InternalCompilerQueryAndHandleData __DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<FinishedDroppingLootCD> __FinishedDroppingLootCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropSelfCD> __DontDropSelfCD_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferLookup;

		public BufferLookup<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentLookup;

		public DropTilesJob.InternalCompilerQueryAndHandleData __DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle;

		public FinishDropLootJob.InternalCompilerQueryAndHandleData __DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle;

		[ReadOnly]
		public ComponentLookup<DropLootDelayCD> __DropLootDelayCD_RO_ComponentLookup;

		public RemoveSerializeOnDeadEntitiesJob.InternalCompilerQueryAndHandleData __DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__DropLootDelayCD_RW_ComponentLookup = state.GetComponentLookup<DropLootDelayCD>();
			__DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__StartDroppingLootCD_RW_ComponentLookup = state.GetComponentLookup<StartDroppingLootCD>();
			__DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup = state.GetComponentLookup<ObjectPropertiesCD>(isReadOnly: true);
			__DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__KilledByPlayerCD_RO_ComponentLookup = state.GetComponentLookup<KilledByPlayerCD>(isReadOnly: true);
			__AlwaysDropVariationZeroCD_RO_ComponentLookup = state.GetComponentLookup<AlwaysDropVariationZeroCD>(isReadOnly: true);
			__AlwaysDropOneCD_RO_ComponentLookup = state.GetComponentLookup<AlwaysDropOneCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__BossCD_RO_ComponentLookup = state.GetComponentLookup<BossCD>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__DistanceToPlayerCD_RO_ComponentLookup = state.GetComponentLookup<DistanceToPlayerCD>(isReadOnly: true);
			__DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ChanceToDropLootCD_RO_ComponentLookup = state.GetComponentLookup<ChanceToDropLootCD>(isReadOnly: true);
			__PlantCD_RO_ComponentLookup = state.GetComponentLookup<PlantCD>(isReadOnly: true);
			__GrowingCD_RO_ComponentLookup = state.GetComponentLookup<GrowingCD>(isReadOnly: true);
			__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			__DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__MerchantCD_RO_ComponentLookup = state.GetComponentLookup<MerchantCD>(isReadOnly: true);
			__DestroyTimerCD_RO_ComponentLookup = state.GetComponentLookup<DestroyTimerCD>(isReadOnly: true);
			__DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__FinishedDroppingLootCD_RW_ComponentLookup = state.GetComponentLookup<FinishedDroppingLootCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__DontDropLootCD_RO_ComponentLookup = state.GetComponentLookup<DontDropLootCD>(isReadOnly: true);
			__DontDropSelfCD_RO_ComponentLookup = state.GetComponentLookup<DontDropSelfCD>(isReadOnly: true);
			__SummarizedConditionEffectsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			__GhostEffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			__GhostEffectEventBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
			__DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__DropLootDelayCD_RO_ComponentLookup = state.GetComponentLookup<DropLootDelayCD>(isReadOnly: true);
			__DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_000019D9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000019D9_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000019D9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000019DA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000019DA_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000019DA_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_000019DB_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_000019DB_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_000019DB_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_000019DC_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_000019DC_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_000019DC_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private EntityQuery playerQuery;

	private EntityQuery scannedMarkersQuery;

	private EntityQuery merchantsQ;

	private const float MAX_SQ_DISTANCE_TO_PLAYER_TO_DROP_LOOT = 10000f;

	private TileAccessor _tileAccessor;

	private BiomeLookup _biomeLookup;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_177058627_0;

	private EntityQuery __query_177058627_1;

	private EntityQuery __query_177058627_2;

	private EntityQuery __query_177058627_3;

	private EntityQuery __query_177058627_4;

	private EntityQuery __query_177058627_5;

	private EntityQuery __query_177058627_6;

	private EntityQuery __query_177058627_7;

	private EntityQuery __query_177058627_8;

	private EntityQuery __query_177058627_9;

	private EntityQuery __query_177058627_10;

	private EntityQuery __query_177058627_11;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<LootTableBankCD>();
		state.RequireForUpdate<BiomeRangesCD>();
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<EffectEventBuffer>();
		state.RequireForUpdate(__query_177058627_0);
		state.RequireForUpdate<ActivatedContentBundlesBuffer>();
		NativeArray<ComponentType> nativeArray = new NativeArray<ComponentType>(1, Allocator.Temp);
		nativeArray[0] = ComponentType.ReadWrite<TileUpdateBuffer>();
		using NativeArray<ComponentType> componentTypes = nativeArray;
		state.RequireForUpdate(state.GetEntityQuery(componentTypes));
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		playerQuery = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<MerchantCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		merchantsQ = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<CanBeScannedCD>();
		scannedMarkersQuery = entityQueryBuilder2.Build(ref state);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
		_biomeLookup = (__query_177058627_1.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_177058627_2.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		EntityCommandBuffer ecb = __query_177058627_3.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		PugDatabase.DatabaseBankCD singleton = __query_177058627_4.GetSingleton<PugDatabase.DatabaseBankCD>();
		LootTableBankCD singleton2 = __query_177058627_5.GetSingleton<LootTableBankCD>();
		JobHandle outJobHandle;
		NativeList<CanBeScannedCD> scannedMarkers = scannedMarkersQuery.ToComponentDataListAsync<CanBeScannedCD>(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		int num = playerQuery.CalculateEntityCount();
		float num2 = 1f + (float)math.max(0, num - 1) * 0.5f;
		if (__query_177058627_6.GetSingleton<WorldInfoCD>().IsWorldModeEnabled(WorldMode.Hard))
		{
			num2 *= 1.5f;
		}
		Entity singletonEntity = __query_177058627_7.GetSingletonEntity();
		CollisionWorld collisionWorld = __query_177058627_8.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
		__query_177058627_9.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new UpdateDropLootDelayJob
		{
			dropLootDelayLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DropLootDelayCD_RW_ComponentLookup, ref state),
			currentTick = value.ServerTick,
			tickRate = (uint)__query_177058627_10.GetSingleton<ClientServerTickRate>().SimulationTickRate
		}, __TypeHandle.__DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		bool isFirstTimeFullyPredictingTick = value.IsFirstTimeFullyPredictingTick;
		state.Dependency = __ScheduleViaJobChunkExtension_1(new StartDroppingLootJob
		{
			startDroppingLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__StartDroppingLootCD_RW_ComponentLookup, ref state),
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick,
			currentTick = value.ServerTick,
			tickRate = (uint)__query_177058627_10.GetSingleton<ClientServerTickRate>().SimulationTickRate
		}, __TypeHandle.__DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		NativeList<LootChest> lootChests = new NativeList<LootChest>(0, state.WorldUpdateAllocator);
		NativeList<LootChestItem> lootChestItems = new NativeList<LootChestItem>(0, state.WorldUpdateAllocator);
		if (isFirstTimeFullyPredictingTick)
		{
			state.Dependency = __ScheduleViaJobChunkExtension_2(new DropBossChestJob
			{
				tileLookup = _tileAccessor,
				collisionWorld = collisionWorld,
				databaseLocal = singleton,
				containedObjectBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref state),
				objectPropertiesLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentLookup, ref state),
				ecb = ecb,
				lootChests = lootChests
			}, __TypeHandle.__DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
			state.Dependency = __ScheduleViaJobChunkExtension_3(new DropSelfJob
			{
				killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
				alwaysDropVariationZeroLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AlwaysDropVariationZeroCD_RO_ComponentLookup, ref state),
				alwaysDropOneLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AlwaysDropOneCD_RO_ComponentLookup, ref state),
				directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
				ecb = ecb,
				databaseLocal = singleton
			}, __TypeHandle.__DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
		state.Dependency = __ScheduleViaJobChunkExtension_4(new DropLootFromLootTablesJob
		{
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			enemyLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__EnemyCD_RO_ComponentLookup, ref state),
			distanceToPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DistanceToPlayerCD_RO_ComponentLookup, ref state),
			databaseLocal = singleton,
			lootBankLocal = singleton2,
			ecb = ecb,
			lootChests = lootChests,
			lootChestItems = lootChestItems,
			bossLootDropMultiplier = num2,
			biomeLookup = _biomeLookup,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick
		}, __TypeHandle.__DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		JobHandle dependency = JobHandle.CombineDependencies(outJobHandle, state.Dependency);
		DynamicBuffer<ActivatedContentBundlesBuffer> singletonBuffer = __query_177058627_11.GetSingletonBuffer<ActivatedContentBundlesBuffer>();
		state.Dependency = __ScheduleViaJobChunkExtension_5(new DropLootFromLootBuffersJob
		{
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			chanceToDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ChanceToDropLootCD_RO_ComponentLookup, ref state),
			plantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlantCD_RO_ComponentLookup, ref state),
			growingLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GrowingCD_RO_ComponentLookup, ref state),
			summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
			activatedContentBundles = singletonBuffer.AsNativeArray(),
			databaseLocal = singleton,
			ecb = ecb,
			lootChests = lootChests,
			lootChestItems = lootChestItems,
			scannedMarkers = scannedMarkers,
			playerCount = num,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick
		}, __TypeHandle.__DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_6(new DropSeasonalLootJob
		{
			bossLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BossCD_RO_ComponentLookup, ref state),
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			databaseLocal = singleton,
			ecb = ecb,
			lootChests = lootChests,
			lootChestItems = lootChestItems,
			playerCount = num,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick
		}, __TypeHandle.__DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = IJobExtensions.Schedule(new FinalizeLootChestSpawnJob
		{
			lootChests = lootChests,
			lootChestItems = lootChestItems,
			ecb = ecb
		}, state.Dependency);
		state.Dependency = __ScheduleViaJobChunkExtension_7(new DropHarvestedPlantsLootJob
		{
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			databaseLocal = singleton,
			ecb = ecb,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick
		}, __TypeHandle.__DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_8(new SpawnEntityOnDeathJob
		{
			objectDataLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ObjectDataCD_RO_ComponentLookup, ref state),
			merchantLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MerchantCD_RO_ComponentLookup, ref state),
			destroyTimerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DestroyTimerCD_RO_ComponentLookup, ref state),
			collisionWorld = collisionWorld,
			merchants = merchantsQ.ToEntityListAsync(state.WorldUpdateAllocator, out var outJobHandle2),
			ecb = ecb,
			databaseLocal = singleton,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick,
			currentTick = value.ServerTick
		}, __TypeHandle.__DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, JobHandle.CombineDependencies(state.Dependency, outJobHandle2), ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_9(new DropContainedEntitiesJob
		{
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			ecb = ecb,
			databaseLocal = singleton,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick
		}, __TypeHandle.__DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_10(new SpawnTileJob
		{
			directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			databaseLocal = singleton,
			tileAccessor = _tileAccessor,
			updatedTilesSingleton = singletonEntity
		}, __TypeHandle.__DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_11(new RemoveTileJob
		{
			tileAccessor = _tileAccessor,
			directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			databaseLocal = singleton,
			updatedTilesSingleton = singletonEntity
		}, __TypeHandle.__DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_12(new DropTilesJob
		{
			finishedDroppingLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FinishedDroppingLootCD_RW_ComponentLookup, ref state),
			killedByPlayerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__KilledByPlayerCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			dontDropLootCDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RO_ComponentLookup, ref state),
			dontDropSelfCDLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropSelfCD_RO_ComponentLookup, ref state),
			alwaysDropVariationZeroLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AlwaysDropVariationZeroCD_RO_ComponentLookup, ref state),
			conditionEffectsBuffer = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferLookup, ref state),
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			ghostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
			effectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
			ecb = ecb,
			tileLookup = _tileAccessor,
			databaseLocal = singleton,
			lootBankLocal = singleton2,
			tileUpdateBufferSingleton = singletonEntity,
			isFirstTimeFullyPredictingTick = isFirstTimeFullyPredictingTick,
			biomeLookup = _biomeLookup,
			tick = value.ServerTick
		}, __TypeHandle.__DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		state.Dependency = __ScheduleViaJobChunkExtension_13(new FinishDropLootJob
		{
			finishedDroppingLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__FinishedDroppingLootCD_RW_ComponentLookup, ref state)
		}, __TypeHandle.__DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		if (state.WorldUnmanaged.IsServer())
		{
			state.Dependency = __ScheduleViaJobChunkExtension_14(new RemoveSerializeOnDeadEntitiesJob
			{
				dropLootDelayLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DropLootDelayCD_RO_ComponentLookup, ref state),
				ecb = ecb,
				currentTick = value.ServerTick,
				tickRate = (uint)__query_177058627_10.GetSingleton<ClientServerTickRate>().SimulationTickRate
			}, __TypeHandle.__DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}
	}

	private static ObjectID BiomeAndTilesetToChest(Biome biome, Tileset tileset)
	{
		switch (biome)
		{
		case Biome.Slime:
			if (tileset == Tileset.Dirt || tileset == Tileset.Turf || tileset == Tileset.Sand)
			{
				return ObjectID.LockedCopperChest;
			}
			break;
		case Biome.Larva:
			if (tileset == Tileset.Clay || tileset == Tileset.Sand)
			{
				return ObjectID.LockedCopperChest;
			}
			break;
		case Biome.Stone:
			if (tileset == Tileset.Stone || tileset == Tileset.Sand)
			{
				return ObjectID.LockedIronChest;
			}
			break;
		case Biome.Nature:
			switch (tileset)
			{
			case Tileset.Stone:
			case Tileset.Nature:
				return ObjectID.LockedScarletChest;
			case Tileset.Crystal:
				return ObjectID.LockedSolariteChest;
			}
			break;
		case Biome.Sea:
			switch (tileset)
			{
			case Tileset.Sea:
				return ObjectID.LockedOctarineChest;
			case Tileset.Crystal:
				return ObjectID.LockedSolariteChest;
			}
			break;
		case Biome.Desert:
			switch (tileset)
			{
			case Tileset.Desert:
				return ObjectID.LockedGalaxiteChest;
			case Tileset.Crystal:
				return ObjectID.LockedSolariteChest;
			}
			break;
		case Biome.Crystal:
			if (tileset == Tileset.Crystal)
			{
				return ObjectID.LockedSolariteChest;
			}
			break;
		case Biome.Excavation:
			if (tileset == Tileset.ExcavationRock)
			{
				return ObjectID.LockedReluciteChest;
			}
			break;
		}
		return ObjectID.None;
	}

	private static bool HasLootChest(int2 position, NativeList<LootChest> lootChests, out LootChest lootChest, out int lootChestIndex)
	{
		for (int i = 0; i < lootChests.Length; i++)
		{
			if (math.all(position == lootChests[i].position))
			{
				lootChest = lootChests[i];
				lootChestIndex = i;
				return true;
			}
		}
		lootChest = default(LootChest);
		lootChestIndex = -1;
		return false;
	}

	private static void UpdateLootChest(LootChest lootChest, NativeList<LootChest> lootChests)
	{
		for (int i = 0; i < lootChests.Length; i++)
		{
			if (math.all(lootChest.position == lootChests[i].position))
			{
				lootChests[i] = lootChest;
				return;
			}
		}
		UnityEngine.Debug.LogError("failed to find loot chest to update");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(UpdateDropLootDelayJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_UpdateDropLootDelayJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(StartDroppingLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_StartDroppingLootJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(DropBossChestJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropBossChestJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_3(DropSelfJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropSelfJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_4(DropLootFromLootTablesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropLootFromLootTablesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_5(DropLootFromLootBuffersJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropLootFromLootBuffersJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_6(DropSeasonalLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropSeasonalLootJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_7(DropHarvestedPlantsLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropHarvestedPlantsLootJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_8(SpawnEntityOnDeathJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_SpawnEntityOnDeathJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_9(DropContainedEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropContainedEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_10(SpawnTileJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_SpawnTileJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_11(RemoveTileJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_RemoveTileJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_12(DropTilesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_DropTilesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_13(FinishDropLootJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_FinishDropLootJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_14(RemoveSerializeOnDeadEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__DropLootSystem_RemoveSerializeOnDeadEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_177058627_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LootTableBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_177058627_11 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000019D9_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000019DA_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_000019DB_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_000019DC_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DropLootSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DropLootSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DropLootSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DropLootSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DropLootSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
