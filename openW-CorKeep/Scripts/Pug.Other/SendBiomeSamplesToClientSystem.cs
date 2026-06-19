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
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct SendBiomeSamplesToClientSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	public struct BiomeEntityReference : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		public Entity Entity;
	}

	[BurstCompile]
	[WithNone(new Type[] { typeof(BiomeEntityReference) })]
	private struct CreateBiomeEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__PlayerGhost_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<BiomeEntityReference>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
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
			public void Run(ref CreateBiomeEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CreateBiomeEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CreateBiomeEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CreateBiomeEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CreateBiomeEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CreateBiomeEntitiesJob job, EntityManager entityManager)
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

		public EntityCommandBuffer Ecb;

		public Entity ClientBiomePrefabEntity;

		[ReadOnly]
		public ComponentLookup<NetworkId> NetworkIdLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity playerEntity, in PlayerGhost ghost)
		{
			if (NetworkIdLookup.TryGetComponent(ghost.connection, out var componentData))
			{
				Entity entity = Ecb.Instantiate(ClientBiomePrefabEntity);
				Ecb.SetComponent(entity, new OnlyRelevantForConnectionCD
				{
					networkId = componentData.Value
				});
				Ecb.AddComponent(playerEntity, new BiomeEntityReference
				{
					Entity = entity
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity playerEntity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(playerEntity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, i));
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
						Entity playerEntity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(playerEntity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, nextRangeBegin));
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
					Entity playerEntity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(playerEntity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity playerEntity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(playerEntity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, k));
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
		typeof(PlayerGhost),
		typeof(Disabled)
	})]
	private struct CleanupBiomeEntitiesJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BiomeEntityReference> __SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BiomeEntityReference>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeEntityReference>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<Disabled>();
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
			public void Run(ref CleanupBiomeEntitiesJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref CleanupBiomeEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref CleanupBiomeEntitiesJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref CleanupBiomeEntitiesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref CleanupBiomeEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref CleanupBiomeEntitiesJob job, EntityManager entityManager)
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

		public EntityCommandBuffer Ecb;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public void Execute(Entity playerEntity, in BiomeEntityReference biomeEntityReference)
		{
			Ecb.DestroyEntity(biomeEntityReference.Entity);
			Ecb.RemoveComponent<BiomeEntityReference>(playerEntity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity playerEntity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(playerEntity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, i));
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
						Entity playerEntity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						Execute(playerEntity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, nextRangeBegin));
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
					Entity playerEntity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					Execute(playerEntity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity playerEntity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					Execute(playerEntity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, k));
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
	private struct UpdateJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<BiomeEntityReference> __SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle = state.GetComponentTypeHandle<BiomeEntityReference>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<BiomeEntityReference>();
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
			public void Run(ref UpdateJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateJob job, EntityManager entityManager)
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
		public BiomeLookup BiomeLookup;

		public ComponentLookup<ClientBiomeSamplesCD> ClientBiomeLookup;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		public unsafe void Execute(in LocalTransform transform, in BiomeEntityReference biomeEntityReference)
		{
			ClientBiomeSamplesCD value = ClientBiomeLookup[biomeEntityReference.Entity];
			int2 int5 = transform.Position.RoundToInt2() & -16;
			int5 -= 32;
			if (int5.Equals(value.BasePosition))
			{
				return;
			}
			int2 baseIndex = ClientBiomeSamplesCD.GetBaseIndex(value.LinearBaseIndex);
			baseIndex += int5 - value.BasePosition >> 4;
			baseIndex %= 6;
			if (baseIndex.x < 0)
			{
				baseIndex.x += 6;
			}
			if (baseIndex.y < 0)
			{
				baseIndex.y += 6;
			}
			value.LinearBaseIndex = baseIndex.y * 6 + baseIndex.x;
			value.BasePosition = int5;
			byte* unsafePtr = value.Biomes.GetUnsafePtr();
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					int linearIndex = ClientBiomeSamplesCD.GetLinearIndex(baseIndex, new int2(j, i));
					int2 worldPosition = int5 + new int2(j, i) * 16;
					unsafePtr[linearIndex] = (byte)BiomeLookup.GetBiome(worldPosition);
				}
			}
			ClientBiomeLookup[biomeEntityReference.Entity] = value;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SendBiomeSamplesToClientSystem_BiomeEntityReference_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, i));
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
						Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Execute(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BiomeEntityReference>(nativeArrayPtr2, k));
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
		public ComponentLookup<ClientBiomeSamplesCD> __ClientBiomeSamplesCD_RO_ComponentLookup;

		public ComponentLookup<NetworkId> __Unity_NetCode_NetworkId_RW_ComponentLookup;

		public CreateBiomeEntitiesJob.InternalCompilerQueryAndHandleData __SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		public CleanupBiomeEntitiesJob.InternalCompilerQueryAndHandleData __SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle;

		public ComponentLookup<ClientBiomeSamplesCD> __ClientBiomeSamplesCD_RW_ComponentLookup;

		public UpdateJob.InternalCompilerQueryAndHandleData __SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ClientBiomeSamplesCD_RO_ComponentLookup = state.GetComponentLookup<ClientBiomeSamplesCD>(isReadOnly: true);
			__Unity_NetCode_NetworkId_RW_ComponentLookup = state.GetComponentLookup<NetworkId>();
			__SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__ClientBiomeSamplesCD_RW_ComponentLookup = state.GetComponentLookup<ClientBiomeSamplesCD>();
			__SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000473_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000473_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000473_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00000474_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000474_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000474_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_00000475_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_00000475_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_00000475_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
	internal delegate void __codegen__OnStartRunning_00000476_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_00000476_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00000476_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_00000477_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00000477_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00000477_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private Entity _clientBiomePrefabEntity;

	private BiomeLookup _biomeLookup;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1648067701_0;

	private EntityQuery __query_1648067701_1;

	private EntityQuery __query_1648067701_2;

	private EntityQuery __query_1648067701_3;

	private EntityQuery __query_1648067701_4;

	private EntityQuery __query_1648067701_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate(__query_1648067701_0);
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugPrefabBuffer>();
		state.RequireForUpdate(__query_1648067701_1);
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		if (_clientBiomePrefabEntity != Entity.Null)
		{
			return;
		}
		DynamicBuffer<PugPrefabBuffer> singletonBuffer = __query_1648067701_2.GetSingletonBuffer<PugPrefabBuffer>();
		for (int i = 0; i < singletonBuffer.Length; i++)
		{
			if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__ClientBiomeSamplesCD_RO_ComponentLookup, ref state, singletonBuffer[i].Value))
			{
				_clientBiomePrefabEntity = singletonBuffer[i].Value;
			}
		}
		if (_clientBiomePrefabEntity == Entity.Null)
		{
			UnityEngine.Debug.LogError("No client biome prefab entity in pug prefab buffer");
			state.Enabled = false;
		}
		_biomeLookup = (__query_1648067701_3.TryGetSingleton<BiomeSamplesCD>(out var value) ? new BiomeLookup(value) : new BiomeLookup(__query_1648067701_4.GetSingleton<BiomeRangesCD>().Value, Allocator.Persistent));
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		_biomeLookup.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1648067701_5.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		CreateBiomeEntitiesJob job = new CreateBiomeEntitiesJob
		{
			Ecb = ecb,
			ClientBiomePrefabEntity = _clientBiomePrefabEntity,
			NetworkIdLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_NetworkId_RW_ComponentLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_0(job, __TypeHandle.__SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		CleanupBiomeEntitiesJob job2 = new CleanupBiomeEntitiesJob
		{
			Ecb = ecb
		};
		state.Dependency = __ScheduleViaJobChunkExtension_1(job2, __TypeHandle.__SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		UpdateJob job3 = new UpdateJob
		{
			BiomeLookup = _biomeLookup,
			ClientBiomeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ClientBiomeSamplesCD_RW_ComponentLookup, ref state)
		};
		state.Dependency = __ScheduleViaJobChunkExtension_2(job3, __TypeHandle.__SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(CreateBiomeEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SendBiomeSamplesToClientSystem_CreateBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(CleanupBiomeEntitiesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SendBiomeSamplesToClientSystem_CleanupBiomeEntitiesJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_2(UpdateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__SendBiomeSamplesToClientSystem_UpdateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		__query_1648067701_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<BiomeRangesCD, BiomeSamplesCD>();
		__query_1648067701_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067701_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067701_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeRangesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067701_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067701_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00000473_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000474_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_00000475_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_00000476_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00000477_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SendBiomeSamplesToClientSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SendBiomeSamplesToClientSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SendBiomeSamplesToClientSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SendBiomeSamplesToClientSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SendBiomeSamplesToClientSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SendBiomeSamplesToClientSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
