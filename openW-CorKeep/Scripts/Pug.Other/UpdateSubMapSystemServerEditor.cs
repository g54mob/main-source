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
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
[DisableAutoCreation]
public struct UpdateSubMapSystemServerEditor : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct FilterJob : IJob
	{
		public NativeList<TileUpdateBuffer> removeList;

		public NativeList<TileUpdateBuffer> addList;

		public NativeList<TileUpdateBuffer> clearList;

		public NativeParallelHashSet<int2> relevantMaps;

		public BufferLookup<TileUpdateBuffer> tileUpdateBufferLookup;

		public Entity tileUpdateSingleton;

		public void Execute()
		{
			DynamicBuffer<TileUpdateBuffer> dynamicBuffer = tileUpdateBufferLookup[tileUpdateSingleton];
			NativeArray<TileUpdateBuffer> tileUpdates = dynamicBuffer.AsNativeArray();
			UpdateSubMapCommon.EnvironmentalDecorationUpdates(in tileUpdates, ref removeList, ref addList);
			UpdateSubMapCommon.FilterUpdates(in tileUpdates, ref clearList, ref removeList, ref addList);
			GetAllRelevantSubMaps(in tileUpdates, ref relevantMaps);
			dynamicBuffer.Clear();
		}
	}

	[BurstCompile]
	private struct ApplyExistingSubmapsJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SubMapCD> __SubMapCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<SubMapLayerBuffer> __SubMapLayerBuffer_RW_BufferTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SubMapCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
					__SubMapLayerBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<SubMapLayerBuffer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SubMapCD_RO_ComponentTypeHandle.Update(ref state);
					__SubMapLayerBuffer_RW_BufferTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SubMapLayerBuffer>();
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
			public void Run(ref ApplyExistingSubmapsJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref ApplyExistingSubmapsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref ApplyExistingSubmapsJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref ApplyExistingSubmapsJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref ApplyExistingSubmapsJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref ApplyExistingSubmapsJob job, EntityManager entityManager)
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
		public NativeParallelHashSet<int2>.ReadOnly relevantMaps;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> removeList;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> addList;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> clearList;

		public NativeParallelHashSet<int2> updatedMaps;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public bool isPlaying;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in SubMapCD submap, ref DynamicBuffer<SubMapLayerBuffer> subMapLayerBuffer)
		{
			if (relevantMaps.Contains(submap.index))
			{
				DynamicBuffer<SubMapLayer> layers = subMapLayerBuffer.Reinterpret<SubMapLayer>();
				ApplyClear(in submap, ref layers, in clearList);
				ApplyRemove(in submap, ref layers, in removeList);
				ApplyAdd(in submap, ref layers, in addList, ref ecb, in databaseLocal, isPlaying);
				updatedMaps.Add(submap.index);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SubMapCD_RO_ComponentTypeHandle);
			BufferAccessor<SubMapLayerBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__SubMapLayerBuffer_RW_BufferTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref SubMapCD submap = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, i);
					DynamicBuffer<SubMapLayerBuffer> subMapLayerBuffer = bufferAccessor[i];
					Execute(entity, in submap, ref subMapLayerBuffer);
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
						ref SubMapCD submap2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, nextRangeBegin);
						DynamicBuffer<SubMapLayerBuffer> subMapLayerBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, in submap2, ref subMapLayerBuffer2);
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
					ref SubMapCD submap3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, j);
					DynamicBuffer<SubMapLayerBuffer> subMapLayerBuffer3 = bufferAccessor[j];
					Execute(entity3, in submap3, ref subMapLayerBuffer3);
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
					ref SubMapCD submap4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, k);
					DynamicBuffer<SubMapLayerBuffer> subMapLayerBuffer4 = bufferAccessor[k];
					Execute(entity4, in submap4, ref subMapLayerBuffer4);
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
	private struct ApplyToNewSubmapsJob : IJob
	{
		public NativeParallelHashMap<int2, Entity> subMapRegistry;

		[ReadOnly]
		public NativeParallelHashSet<int2>.ReadOnly relevantMaps;

		[ReadOnly]
		public NativeList<TileUpdateBuffer> addList;

		[ReadOnly]
		public NativeParallelHashSet<int2> updatedMaps;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public bool isPlaying;

		public EntityArchetype subMapArchetype;

		public void Execute()
		{
			subMapRegistry.Clear();
			NativeArray<int2> nativeArray = relevantMaps.ToNativeArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				int2 int5 = nativeArray[i];
				if (!updatedMaps.Contains(int5))
				{
					Entity entity = ecb.CreateEntity(subMapArchetype);
					SubMapCD subMap = new SubMapCD
					{
						index = int5,
						wasCreatedThisSession = true
					};
					ecb.SetComponent(entity, subMap);
					ecb.SetComponent(entity, LocalTransform.FromPosition(new float3((float)int5.x + 0.5f, 0f, (float)int5.y + 0.5f) * 64f));
					DynamicBuffer<SubMapLayer> layers = ecb.SetBuffer<SubMapLayerBuffer>(entity).Reinterpret<SubMapLayer>();
					ApplyAdd(in subMap, ref layers, in addList, ref ecb, in databaseLocal, isPlaying);
				}
			}
			nativeArray.Dispose();
		}
	}

	[BurstCompile]
	private struct UpdateSubMapRegistryJob : IJobEntity, IJobChunk
	{
		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<SubMapCD> __SubMapCD_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__SubMapCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SubMapCD>(isReadOnly: true);
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__SubMapCD_RO_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				DefaultQuery = entityQueryBuilder.WithAll<SubMapCD>().Build(ref state);
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
			public void Run(ref UpdateSubMapRegistryJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref UpdateSubMapRegistryJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref UpdateSubMapRegistryJob job, EntityManager entityManager)
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

		public NativeParallelHashMap<int2, Entity> subMapRegistry;

		public NativeArray<bool> hasWarnedDuplicateSubmap;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in SubMapCD submap)
		{
			if (!subMapRegistry.TryAdd(submap.index, entity) && !hasWarnedDuplicateSubmap[0])
			{
				hasWarnedDuplicateSubmap[0] = true;
				UnityEngine.Debug.LogError("has duplicate submap");
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__SubMapCD_RO_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					Execute(entity, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, i));
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
						Execute(entity2, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, nextRangeBegin));
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
					Execute(entity3, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, j));
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
					Execute(entity4, in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SubMapCD>(nativeArrayPtr2, k));
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
		public BufferLookup<TileUpdateBuffer> __TileUpdateBuffer_RW_BufferLookup;

		public ApplyExistingSubmapsJob.InternalCompilerQueryAndHandleData __UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle;

		public UpdateSubMapRegistryJob.InternalCompilerQueryAndHandleData __UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__TileUpdateBuffer_RW_BufferLookup = state.GetBufferLookup<TileUpdateBuffer>();
			__UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			__UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_000044B2_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000044B2_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000044B2_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnDestroy_000044B3_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000044B3_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000044B3_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

	private NativeArray<bool> _hasWarnedDuplicateSubmap;

	private EntityArchetype _subMapArchetype;

	private bool _isPlaying;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1502956912_0;

	private EntityQuery __query_1502956912_1;

	private EntityQuery __query_1502956912_2;

	private EntityQuery __query_1502956912_3;

	private EntityQuery __query_1502956912_4;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void GetAllRelevantSubMaps(in NativeArray<TileUpdateBuffer> tileUpdates, ref NativeParallelHashSet<int2> subMapPositions)
	{
		for (int i = 0; i < tileUpdates.Length; i++)
		{
			int2 item = (tileUpdates[i].position & -64) >> 6;
			subMapPositions.Add(item);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ApplyClear(in SubMapCD subMap, ref DynamicBuffer<SubMapLayer> layers, in NativeList<TileUpdateBuffer> tileUpdates)
	{
		for (int i = 0; i < tileUpdates.Length; i++)
		{
			int2 position = tileUpdates[i].position;
			int2 int5 = (position & -64) >> 6;
			if (!math.all(subMap.index == int5))
			{
				continue;
			}
			int2 pos = position - int5 * 64;
			for (int num = layers.Length - 1; num >= 0; num--)
			{
				ref SubMapLayer reference = ref layers.ElementAt(num);
				if (!reference.layer.tileType.IsIgnoreClear())
				{
					reference.Unset(pos);
				}
				if (reference.IsEmpty())
				{
					layers.RemoveAtSwapBack(num);
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ApplyRemove(in SubMapCD subMap, ref DynamicBuffer<SubMapLayer> layers, in NativeList<TileUpdateBuffer> tileUpdates)
	{
		for (int i = 0; i < tileUpdates.Length; i++)
		{
			int2 position = tileUpdates[i].position;
			int2 int5 = (position & -64) >> 6;
			if (!math.all(subMap.index == int5))
			{
				continue;
			}
			int2 pos = position - int5 * 64;
			for (int num = layers.Length - 1; num >= 0; num--)
			{
				ref SubMapLayer reference = ref layers.ElementAt(num);
				if (reference.layer.tileType == tileUpdates[i].tile.tileType)
				{
					reference.Unset(pos);
					if (reference.IsEmpty())
					{
						layers.RemoveAtSwapBack(num);
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ApplyAdd(in SubMapCD subMap, ref DynamicBuffer<SubMapLayer> layers, in NativeList<TileUpdateBuffer> tileUpdates, ref EntityCommandBuffer ecb, in BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, bool isPlaying)
	{
		NativeList<TileType> neededTile = new NativeList<TileType>(4, Allocator.Temp);
		NativeList<TileType> invalidTile = new NativeList<TileType>(4, Allocator.Temp);
		for (int num = tileUpdates.Length - 1; num >= 0; num--)
		{
			if (tileUpdates[num].tile.tileType != TileType.none)
			{
				int2 position = tileUpdates[num].position;
				int2 int5 = (position & -64) >> 6;
				if (math.all(subMap.index == int5))
				{
					neededTile.Clear();
					tileUpdates[num].tile.tileType.GetNeededTile(ref neededTile);
					invalidTile.Clear();
					tileUpdates[num].tile.tileType.GetInvalidTile(ref invalidTile);
					int2 pos = position - int5 * 64;
					int num2 = -1;
					bool flag = neededTile.Length == 0;
					bool flag2 = false;
					for (int num3 = layers.Length - 1; num3 >= 0; num3--)
					{
						ref SubMapLayer reference = ref layers.ElementAt(num3);
						if (reference.layer.Equals(tileUpdates[num].tile))
						{
							num2 = num3;
						}
						for (int i = 0; i < neededTile.Length; i++)
						{
							if (reference.layer.tileType == neededTile[i] && reference.Get(pos))
							{
								flag = true;
							}
						}
						for (int j = 0; j < invalidTile.Length; j++)
						{
							if (reference.layer.tileType == invalidTile[j] && reference.Get(pos))
							{
								flag2 = true;
							}
						}
					}
					if (!isPlaying || (flag && !flag2))
					{
						if (num2 == -1)
						{
							SubMapLayer sl = new SubMapLayer
							{
								layer = tileUpdates[num].tile
							};
							sl.Set(pos);
							layers.Add(sl);
						}
						else
						{
							layers.ElementAt(num2).Set(pos);
						}
					}
					else if (databaseLocal.IsCreated)
					{
						ObjectID objectID = PugDatabase.GetObjectID(tileUpdates[num].tile.tileset, tileUpdates[num].tile.tileType, databaseLocal);
						if (PugDatabase.GetEntityObjectInfo(objectID, databaseLocal).objectType != ObjectType.NonObtainable)
						{
							EntityUtility.DropNewEntity(ecb, new ContainedObjectsBuffer
							{
								objectData = new ObjectDataCD
								{
									objectID = objectID,
									amount = 1
								}
							}, tileUpdates[num].position.ToFloat3(), databaseLocal);
						}
					}
				}
			}
		}
	}

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<TileUpdateBuffer>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<PugPrefabBuffer>();
		if (Application.isPlaying)
		{
			state.RequireForUpdate<WorldHasBeenDeserializedCD>();
		}
		using EntityQuery entityQuery = state.EntityManager.CreateEntityQuery(typeof(TileUpdateBuffer));
		if (entityQuery.IsEmpty)
		{
			Entity entity = state.EntityManager.CreateEntity();
			state.EntityManager.AddBuffer<TileUpdateBuffer>(entity);
		}
		_subMapArchetype = state.EntityManager.CreateArchetype(typeof(SubMapCD), typeof(SubMapLayerBuffer), typeof(LocalTransform));
		state.EntityManager.CreateSingleton(new SubMapRegistry
		{
			IndexToEntity = new NativeParallelHashMap<int2, Entity>(10000, Allocator.Persistent)
		});
		_hasWarnedDuplicateSubmap = new NativeArray<bool>(1, Allocator.Persistent);
		_isPlaying = Application.isPlaying;
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		__query_1502956912_0.GetSingletonRW<SubMapRegistry>().ValueRW.IndexToEntity.Dispose();
		state.EntityManager.DestroyEntity(__query_1502956912_1.GetSingletonEntity());
		_hasWarnedDuplicateSubmap.Dispose();
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityCommandBuffer ecb = __query_1502956912_2.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
		Entity singletonEntity = __query_1502956912_3.GetSingletonEntity();
		__query_1502956912_4.TryGetSingleton<PugDatabase.DatabaseBankCD>(out var value);
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = value.databaseBankBlob;
		NativeList<TileUpdateBuffer> addList = new NativeList<TileUpdateBuffer>(4096, state.WorldUpdateAllocator);
		NativeList<TileUpdateBuffer> clearList = new NativeList<TileUpdateBuffer>(128, state.WorldUpdateAllocator);
		NativeList<TileUpdateBuffer> removeList = new NativeList<TileUpdateBuffer>(128, state.WorldUpdateAllocator);
		NativeParallelHashSet<int2> relevantMaps = new NativeParallelHashSet<int2>(128, state.WorldUpdateAllocator);
		NativeParallelHashSet<int2> updatedMaps = new NativeParallelHashSet<int2>(128, state.WorldUpdateAllocator);
		EntityArchetype subMapArchetype = _subMapArchetype;
		state.Dependency = IJobExtensions.Schedule(new FilterJob
		{
			removeList = removeList,
			addList = addList,
			clearList = clearList,
			relevantMaps = relevantMaps,
			tileUpdateBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__TileUpdateBuffer_RW_BufferLookup, ref state),
			tileUpdateSingleton = singletonEntity
		}, state.Dependency);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new ApplyExistingSubmapsJob
		{
			relevantMaps = relevantMaps.AsReadOnly(),
			removeList = removeList,
			addList = addList,
			clearList = clearList,
			updatedMaps = updatedMaps,
			ecb = ecb,
			databaseLocal = databaseBankBlob,
			isPlaying = _isPlaying
		}, __TypeHandle.__UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		NativeParallelHashMap<int2, Entity> indexToEntity = __query_1502956912_0.GetSingletonRW<SubMapRegistry>().ValueRW.IndexToEntity;
		state.Dependency = IJobExtensions.Schedule(new ApplyToNewSubmapsJob
		{
			subMapRegistry = indexToEntity,
			relevantMaps = relevantMaps.AsReadOnly(),
			addList = addList,
			updatedMaps = updatedMaps,
			ecb = ecb,
			databaseLocal = databaseBankBlob,
			isPlaying = _isPlaying,
			subMapArchetype = subMapArchetype
		}, state.Dependency);
		NativeArray<bool> hasWarnedDuplicateSubmap = _hasWarnedDuplicateSubmap;
		state.Dependency = __ScheduleViaJobChunkExtension_1(new UpdateSubMapRegistryJob
		{
			subMapRegistry = indexToEntity,
			hasWarnedDuplicateSubmap = hasWarnedDuplicateSubmap
		}, __TypeHandle.__UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(ApplyExistingSubmapsJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UpdateSubMapSystemServerEditor_ApplyExistingSubmapsJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_1(UpdateSubMapRegistryJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__UpdateSubMapSystemServerEditor_UpdateSubMapRegistryJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<SubMapRegistry>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502956912_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapRegistry>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502956912_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502956912_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502956912_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1502956912_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((UpdateSubMapSystemServerEditor*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000044B2_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000044B3_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateSubMapSystemServerEditor*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateSubMapSystemServerEditor*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateSubMapSystemServerEditor*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
