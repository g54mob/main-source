using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Physics;
using Unity.Physics.Systems;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(AfterPhysicsSystemGroup))]
public struct EnablePhysicsSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct UnsetKinematicJob : IJobChunk
	{
		public ComponentTypeHandle<Simulate> simulateHandle;

		[ReadOnly]
		public ComponentTypeHandle<DisablePhysicsRestoreCD> disablePhysicsRestoreHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			NativeArray<DisablePhysicsRestoreCD> nativeArray = chunk.GetNativeArray(disablePhysicsRestoreHandle);
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				bool restoreSimulate = nativeArray[nextIndex].restoreSimulate;
				chunk.SetComponentEnabled(ref simulateHandle, nextIndex, restoreSimulate);
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<Simulate> __Unity_Entities_Simulate_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DisablePhysicsRestoreCD> __DisablePhysicsRestoreCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Simulate_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Simulate>();
			__DisablePhysicsRestoreCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DisablePhysicsRestoreCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00001927_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00001927_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00001927_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1212305749_0;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		state.Dependency = JobChunkExtensions.Schedule(new UnsetKinematicJob
		{
			simulateHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Entities_Simulate_RW_ComponentTypeHandle, ref state),
			disablePhysicsRestoreHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DisablePhysicsRestoreCD_RO_ComponentTypeHandle, ref state)
		}, __query_1212305749_0, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<EntityDestroyedCD, GhostWaitingSpawnCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithPresent<DisablePhysicsCollider>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DisablePhysicsRestoreCD, PhysicsCollider>();
		entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<Simulate>();
		__query_1212305749_0 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnUpdate_00001927_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((EnablePhysicsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((EnablePhysicsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
