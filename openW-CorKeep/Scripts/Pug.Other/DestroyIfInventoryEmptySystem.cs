using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Inventory;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InventorySystemGroup))]
[UpdateAfter(typeof(InventoryUpdateSystem))]
public struct DestroyIfInventoryEmptySystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct DestroyEmptyDroppedItemsJob : IJobChunk
	{
		public uint GlobalSystemVersion;

		public ComponentTypeHandle<EntityDestroyedCD> EntityDestroyedTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> ContainedObjectsBufferTypeHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			if (!chunk.DidChange(ref ContainedObjectsBufferTypeHandle, GlobalSystemVersion) && !chunk.DidOrderChange(GlobalSystemVersion))
			{
				return;
			}
			BufferAccessor<ContainedObjectsBuffer> bufferAccessor = chunk.GetBufferAccessor(ref ContainedObjectsBufferTypeHandle);
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				if (IsEmpty(bufferAccessor[nextIndex]))
				{
					chunk.SetComponentEnabled(ref EntityDestroyedTypeHandle, nextIndex, value: true);
				}
			}
		}

		private static bool IsEmpty(DynamicBuffer<ContainedObjectsBuffer> containedObjects)
		{
			foreach (ContainedObjectsBuffer item in containedObjects)
			{
				if (item.objectID != ObjectID.None)
				{
					return false;
				}
			}
			return true;
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__EntityDestroyedCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>();
			__ContainedObjectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ContainedObjectsBuffer>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00001754_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001754_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001754_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private uint _globalSystemVersionWhenLastRun;

	private uint _globalSystemVersionWhenLastRunForDisabledEntities;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_334746024_0;

	private EntityQuery __query_334746024_1;

	private EntityQuery __query_334746024_2;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NetworkTime singleton = __query_334746024_2.GetSingleton<NetworkTime>();
		DestroyEmptyDroppedItemsJob jobData = new DestroyEmptyDroppedItemsJob
		{
			EntityDestroyedTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityDestroyedCD_RW_ComponentTypeHandle, ref state),
			ContainedObjectsBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferTypeHandle, ref state)
		};
		if (VariableSystemUpdate.ShouldUpdate(ref state, singleton, 0, 0.33f))
		{
			jobData.GlobalSystemVersion = _globalSystemVersionWhenLastRun;
			EntityQuery _query_334746024_ = __query_334746024_0;
			state.Dependency = JobChunkExtensions.Schedule(jobData, _query_334746024_, state.Dependency);
			_globalSystemVersionWhenLastRun = state.GlobalSystemVersion;
		}
		if (VariableSystemUpdate.ShouldUpdate(ref state, singleton, 20, 0.1f))
		{
			jobData.GlobalSystemVersion = _globalSystemVersionWhenLastRunForDisabledEntities;
			EntityQuery _query_334746024_2 = __query_334746024_1;
			state.Dependency = JobChunkExtensions.ScheduleParallel(jobData, _query_334746024_2, state.Dependency);
			_globalSystemVersionWhenLastRunForDisabledEntities = state.GlobalSystemVersion;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DestroyIfInventoryEmptyCD, ContainedObjectsBuffer, Simulate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<EntityDestroyedCD>();
		__query_334746024_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<DestroyIfInventoryEmptyCD, ContainedObjectsBuffer, Simulate, Disabled>();
		entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_334746024_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_334746024_2 = entityQueryBuilder2.Build(ref state);
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
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00001754_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DestroyIfInventoryEmptySystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DestroyIfInventoryEmptySystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
