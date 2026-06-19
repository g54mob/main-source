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
[UpdateInGroup(typeof(BeforePhysicsSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct DisablePhysicsSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct DisablePhysicsJob : IJobChunk
	{
		public ComponentTypeHandle<DisablePhysicsCollider> disablePhysicsColliderHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				chunk.SetComponentEnabled(ref disablePhysicsColliderHandle, nextIndex, value: true);
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct EnablePhysicsJob : IJobChunk
	{
		public ComponentTypeHandle<DisablePhysicsCollider> disablePhysicsColliderHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				chunk.SetComponentEnabled(ref disablePhysicsColliderHandle, nextIndex, value: false);
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[BurstCompile]
	private struct SetKinematicJob : IJobChunk
	{
		public ComponentTypeHandle<Simulate> simulateHandle;

		public ComponentTypeHandle<DisablePhysicsRestoreCD> disablePhysicsRestoreHandle;

		[ReadOnly]
		public ComponentTypeHandle<EntityDestroyedCD> entityDestroyedCDHandle;

		[ReadOnly]
		public ComponentTypeHandle<GhostWaitingSpawnCD> ghostWaitingSpawnCDHandle;

		public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			NativeArray<DisablePhysicsRestoreCD> nativeArray = chunk.GetNativeArray(disablePhysicsRestoreHandle);
			ChunkEntityEnumerator chunkEntityEnumerator = new ChunkEntityEnumerator(useEnabledMask, chunkEnabledMask, chunk.Count);
			int nextIndex;
			while (chunkEntityEnumerator.NextEntityIndex(out nextIndex))
			{
				bool flag = chunk.IsComponentEnabled(ref simulateHandle, nextIndex);
				DisablePhysicsRestoreCD value = nativeArray[nextIndex];
				value.restoreSimulate = flag;
				bool flag2 = chunk.IsComponentEnabled(ref entityDestroyedCDHandle, nextIndex);
				bool flag3 = chunk.IsComponentEnabled(ref ghostWaitingSpawnCDHandle, nextIndex);
				bool value2 = flag && !flag2 && !flag3;
				chunk.SetComponentEnabled(ref simulateHandle, nextIndex, value2);
				nativeArray[nextIndex] = value;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<DisablePhysicsCollider> __Unity_Physics_DisablePhysicsCollider_RW_ComponentTypeHandle;

		public ComponentTypeHandle<Simulate> __Unity_Entities_Simulate_RW_ComponentTypeHandle;

		public ComponentTypeHandle<DisablePhysicsRestoreCD> __DisablePhysicsRestoreCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<GhostWaitingSpawnCD> __GhostWaitingSpawnCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Physics_DisablePhysicsCollider_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DisablePhysicsCollider>();
			__Unity_Entities_Simulate_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Simulate>();
			__DisablePhysicsRestoreCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DisablePhysicsRestoreCD>();
			__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
			__GhostWaitingSpawnCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<GhostWaitingSpawnCD>(isReadOnly: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_0000191B_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_0000191B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_0000191B_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	private EntityQuery __query_1212305652_0;

	private EntityQuery __query_1212305652_1;

	private EntityQuery __query_1212305652_2;

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		state.Dependency = JobChunkExtensions.Schedule(new DisablePhysicsJob
		{
			disablePhysicsColliderHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Physics_DisablePhysicsCollider_RW_ComponentTypeHandle, ref state)
		}, __query_1212305652_0, state.Dependency);
		state.Dependency = JobChunkExtensions.Schedule(new EnablePhysicsJob
		{
			disablePhysicsColliderHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Physics_DisablePhysicsCollider_RW_ComponentTypeHandle, ref state)
		}, __query_1212305652_1, state.Dependency);
		state.Dependency = JobChunkExtensions.Schedule(new SetKinematicJob
		{
			simulateHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Entities_Simulate_RW_ComponentTypeHandle, ref state),
			disablePhysicsRestoreHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DisablePhysicsRestoreCD_RW_ComponentTypeHandle, ref state),
			entityDestroyedCDHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle, ref state),
			ghostWaitingSpawnCDHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__GhostWaitingSpawnCD_RO_ComponentTypeHandle, ref state)
		}, __query_1212305652_2, state.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<DisablePhysicsCD, EntityDestroyedCD, GhostWaitingSpawnCD, GodModeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithDisabled<DisablePhysicsCollider>();
		__query_1212305652_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<DisablePhysicsCD, EntityDestroyedCD, GhostWaitingSpawnCD, GodModeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DisablePhysicsCollider>();
		__query_1212305652_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAny<EntityDestroyedCD, GhostWaitingSpawnCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DisablePhysicsRestoreCD, PhysicsCollider, DisablePhysicsCollider>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IgnoreComponentEnabledState);
		__query_1212305652_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnUpdate_0000191B_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((DisablePhysicsSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((DisablePhysicsSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
