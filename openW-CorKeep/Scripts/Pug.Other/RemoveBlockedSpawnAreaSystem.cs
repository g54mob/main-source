using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class RemoveBlockedSpawnAreaSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000031EA_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000031EA_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000031EA_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public int ticksPerUpdate;

		public NativeList<Entity> toRemove;

		public int ticksUntilRemoveCheck;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<BlockedSpawnAreaCD> __blockedSpawnAreaTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref BlockedSpawnAreaCD blockedSpawnArea)
		{
			blockedSpawnArea.Value.ElapsedTicks += ticksPerUpdate;
			if (blockedSpawnArea.Value.ElapsedTicks > ticksUntilRemoveCheck)
			{
				toRemove.Add(in entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __blockedSpawnAreaTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BlockedSpawnAreaCD>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BlockedSpawnAreaCD>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BlockedSpawnAreaCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<BlockedSpawnAreaCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000031EA_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000031EA_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<BlockedSpawnAreaCD> __BlockedSpawnAreaCD_RW_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__BlockedSpawnAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<BlockedSpawnAreaCD>();
		}
	}

	private int _ticksUntilRemove;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1724569366_0;

	private EntityQuery __query_1724569366_1;

	[Preserve]
	protected override void OnCreate()
	{
		_ticksUntilRemove = 30 * PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NetworkTime singleton = __query_1724569366_1.GetSingleton<NetworkTime>();
		if (VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, singleton, 1, 0.1f, out var ticksPerUpdate) && Manager.sceneHandler.isInGame)
		{
			NativeList<Entity> toRemove = new NativeList<Entity>(Allocator.Temp);
			int ticksUntilRemoveCheck = _ticksUntilRemove;
			RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Execute(ref ticksPerUpdate, ref toRemove, ref ticksUntilRemoveCheck);
			base.EntityManager.DestroyEntity(toRemove);
			toRemove.Dispose();
			base.OnUpdate();
		}
	}

	private void RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Execute(ref int ticksPerUpdate, ref NativeList<Entity> toRemove, ref int ticksUntilRemoveCheck)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__BlockedSpawnAreaCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Job value = new RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Job
		{
			ticksPerUpdate = ticksPerUpdate,
			toRemove = toRemove,
			ticksUntilRemoveCheck = ticksUntilRemoveCheck,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__blockedSpawnAreaTypeHandle = __TypeHandle.__BlockedSpawnAreaCD_RW_ComponentTypeHandle
		};
		if (!__query_1724569366_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			RemoveBlockedSpawnAreaSystem_32F61984_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1724569366_0, jobPtr);
		}
		ticksPerUpdate = value.ticksPerUpdate;
		toRemove = value.toRemove;
		ticksUntilRemoveCheck = value.ticksUntilRemoveCheck;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<BlockedSpawnAreaCD>();
		__query_1724569366_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1724569366_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public RemoveBlockedSpawnAreaSystem()
	{
	}
}
