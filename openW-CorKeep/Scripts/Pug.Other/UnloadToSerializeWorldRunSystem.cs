using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Profiling;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct UnloadToSerializeWorldRunSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00003658_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00003658_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00003658_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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

	private static readonly ProfilerMarker MoveSerializedEntitiesMarker = new ProfilerMarker("MoveSerializedEntitiesMarker");

	private static readonly ProfilerMarker AddBlockSaveMarker = new ProfilerMarker("AddBlockSaveMarker");

	private EntityQuery _moveQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_959652297_0;

	private EntityQuery __query_959652297_1;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<SerializeWorldDataCD>();
		state.RequireForUpdate<InitialLoadingDoneCD>();
	}

	public void OnUpdate(ref SystemState state)
	{
		SerializeWorldDataCD singleton = __query_959652297_1.GetSingleton<SerializeWorldDataCD>();
		if (singleton.State == SerializeWorldState.Idle)
		{
			if (!_moveQuery.IsEmpty)
			{
				state.EntityManager.MoveEntitiesFrom(singleton.entityManager, _moveQuery);
			}
			EntityQuery _query_959652297_ = __query_959652297_0;
			if (!_query_959652297_.IsEmptyIgnoreFilter)
			{
				state.EntityManager.AddComponent<BlockSaveCD>(_query_959652297_);
			}
		}
	}

	public void OnStartRunning(ref SystemState state)
	{
		SerializeWorldDataCD singleton = __query_959652297_1.GetSingleton<SerializeWorldDataCD>();
		using EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp).WithAll<SerializedEntityPendingLoadCD>();
		_moveQuery = entityQueryBuilder.Build(singleton.entityManager);
	}

	public void OnStopRunning(ref SystemState state)
	{
		_moveQuery.Dispose();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SerializedEntityPendingLoadCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<BlockSaveCD>();
		__query_959652297_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SerializeWorldDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_959652297_1 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_00003658_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldRunSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldRunSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldRunSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldRunSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UnloadToSerializeWorldRunSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}
}
