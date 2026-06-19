using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using Unity.NetCode.LowLevel;
using Unity.Transforms;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(TransformSystemGroup), OrderFirst = true)]
public struct SetInterpolatedPositionSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct ResetInterpolatedDestroyPositionJob : IJobChunk
	{
		public ComponentTypeHandle<InterpolatedDestroyPositionCD> InterpolatedDestroyPositionTypeHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				chunk.SetComponentEnabled(ref InterpolatedDestroyPositionTypeHandle, nextIndex, value: false);
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SetInterpolatedPositionJob : IJobChunk
	{
		[ReadOnly]
		public ComponentTypeHandle<SnapshotData> SnapshotDataTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GhostInstance> GhostInstanceTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDataBuffer> SnapshotDataBufferTypeHandle;

		public ComponentTypeHandle<InterpolatedDestroyPositionCD> InterpolatedDestroyPositionTypeHandle;

		public ComponentTypeHandle<LocalTransform> LocalTransformTypeHandle;

		public SnapshotDataLookupHelper SnapshotDataLookupHelper;

		public NetworkTick InterpolationTick;

		public float InterpolationTickFraction;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			SnapshotDataBufferComponentLookup snapshotDataBufferComponentLookup = SnapshotDataLookupHelper.CreateSnapshotBufferLookup();
			NativeArray<SnapshotData> nativeArray = chunk.GetNativeArray(ref SnapshotDataTypeHandle);
			NativeArray<GhostInstance> nativeArray2 = chunk.GetNativeArray(ref GhostInstanceTypeHandle);
			BufferAccessor<SnapshotDataBuffer> bufferAccessor = chunk.GetBufferAccessor(ref SnapshotDataBufferTypeHandle);
			NativeArray<InterpolatedDestroyPositionCD> nativeArray3 = chunk.GetNativeArray(ref InterpolatedDestroyPositionTypeHandle);
			NativeArray<LocalTransform> nativeArray4 = chunk.GetNativeArray(ref LocalTransformTypeHandle);
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				LocalTransform value = nativeArray4[nextIndex];
				if (chunk.IsComponentEnabled(ref InterpolatedDestroyPositionTypeHandle, nextIndex))
				{
					value.Position = nativeArray3[nextIndex].position;
					nativeArray4[nextIndex] = value;
					continue;
				}
				SnapshotData snapshotData = nativeArray[nextIndex];
				GhostInstance ghostInstance = nativeArray2[nextIndex];
				DynamicBuffer<SnapshotDataBuffer> snapshotBuffer = bufferAccessor[nextIndex];
				if (snapshotDataBufferComponentLookup.TryGetComponentDataFromSnapshotHistory<LocalTransform>(ghostInstance.ghostType, snapshotData, in snapshotBuffer, out var componentData, InterpolationTick, InterpolationTickFraction))
				{
					value.Position = componentData.Position;
					nativeArray4[nextIndex] = value;
					nativeArray3[nextIndex] = new InterpolatedDestroyPositionCD
					{
						position = componentData.Position
					};
					chunk.SetComponentEnabled(ref InterpolatedDestroyPositionTypeHandle, nextIndex, value: true);
				}
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<SnapshotData> __Unity_NetCode_SnapshotData_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GhostInstance> __Unity_NetCode_GhostInstance_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<SnapshotDataBuffer> __Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle;

		public ComponentTypeHandle<InterpolatedDestroyPositionCD> __InterpolatedDestroyPositionCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SnapshotData>(isReadOnly: true);
			__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostInstance>(isReadOnly: true);
			__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SnapshotDataBuffer>(isReadOnly: true);
			__InterpolatedDestroyPositionCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<InterpolatedDestroyPositionCD>();
			__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003668_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003668_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003668_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_00003669_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00003669_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00003669_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStartRunning_0000366A_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStartRunning_0000366A_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_0000366A_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
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
	internal delegate void __codegen__OnStopRunning_0000366B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_0000366B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_0000366B_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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

	private SnapshotDataLookupHelper _snapshotDataLookupHelper;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_492828163_0;

	private EntityQuery __query_492828163_1;

	private EntityQuery __query_492828163_2;

	private EntityQuery __query_492828163_3;

	private EntityQuery __query_492828163_4;

	private EntityQuery __query_492828163_5;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<SpawnedGhostEntityMap>();
		state.RequireForUpdate<GhostCollection>();
	}

	[BurstCompile]
	public void OnStartRunning(ref SystemState state)
	{
		_snapshotDataLookupHelper = new SnapshotDataLookupHelper(ref state, __query_492828163_3.GetSingletonEntity(), __query_492828163_4.GetSingletonEntity());
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		EntityQuery _query_492828163_ = __query_492828163_0;
		if (!_query_492828163_.IsEmpty)
		{
			_snapshotDataLookupHelper.Update(ref state);
			NetworkTime singleton = __query_492828163_5.GetSingleton<NetworkTime>();
			state.Dependency = JobChunkExtensions.Schedule(new SetInterpolatedPositionJob
			{
				SnapshotDataTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_NetCode_SnapshotData_RO_ComponentTypeHandle, ref state),
				GhostInstanceTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_NetCode_GhostInstance_RO_ComponentTypeHandle, ref state),
				SnapshotDataBufferTypeHandle = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__Unity_NetCode_SnapshotDataBuffer_RO_BufferTypeHandle, ref state),
				InterpolatedDestroyPositionTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__InterpolatedDestroyPositionCD_RW_ComponentTypeHandle, ref state),
				LocalTransformTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle, ref state),
				SnapshotDataLookupHelper = _snapshotDataLookupHelper,
				InterpolationTick = singleton.InterpolationTick,
				InterpolationTickFraction = singleton.InterpolationTickFraction
			}, __query_492828163_1, state.Dependency);
		}
		state.Dependency = JobChunkExtensions.Schedule(new ResetInterpolatedDestroyPositionJob
		{
			InterpolatedDestroyPositionTypeHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__InterpolatedDestroyPositionCD_RW_ComponentTypeHandle, ref state)
		}, __query_492828163_2, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<UseLagCompensationCD, PredictedGhost, LocalTransform>();
		__query_492828163_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SnapshotData, GhostInstance, SnapshotDataBuffer, LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<UseLagCompensationCD, PredictedGhost, EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithPresent<InterpolatedDestroyPositionCD>();
		__query_492828163_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithDisabled<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<InterpolatedDestroyPositionCD>();
		__query_492828163_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostCollection>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_492828163_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SpawnedGhostEntityMap>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_492828163_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_492828163_5 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00003668_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00003669_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStartRunning_0000366A_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_0000366B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((SetInterpolatedPositionSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SetInterpolatedPositionSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SetInterpolatedPositionSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SetInterpolatedPositionSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((SetInterpolatedPositionSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
