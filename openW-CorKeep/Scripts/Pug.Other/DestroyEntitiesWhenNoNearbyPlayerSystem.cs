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
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class DestroyEntitiesWhenNoNearbyPlayerSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000016EF_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000016EF_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000016EF_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public double time;

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<DestroyEntityWhenNoNearbyPlayerCD> __destroyEntityWhenNoNearbyPlayerCDTypeHandle;

		public ComponentTypeHandle<HealthCD> __healthTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DistanceToPlayerCD> __distanceToPlayerTypeHandle;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref DestroyEntityWhenNoNearbyPlayerCD destroyEntityWhenNoNearbyPlayerCD, [NoAlias] ref HealthCD health, [NoAlias] in DistanceToPlayerCD distanceToPlayer)
		{
			if (__IsInCombatCD_ComponentLookup.HasComponent(entity) && __IsInCombatCD_ComponentLookup[entity].isInCombat)
			{
				return;
			}
			if (distanceToPlayer.minDistanceSq > destroyEntityWhenNoNearbyPlayerCD.distanceSq)
			{
				if (!destroyEntityWhenNoNearbyPlayerCD.timer.isRunning)
				{
					destroyEntityWhenNoNearbyPlayerCD.timer.Start(time, destroyEntityWhenNoNearbyPlayerCD.destroyDelay);
				}
				else if (destroyEntityWhenNoNearbyPlayerCD.timer.IsTimerElapsed(time))
				{
					health.health = 0;
					if (__DontDropLootCD_ComponentLookup.HasComponent(entity))
					{
						ecb.SetComponentEnabled<DontDropLootCD>(entity, value: true);
					}
				}
			}
			else
			{
				destroyEntityWhenNoNearbyPlayerCD.timer.Stop();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __destroyEntityWhenNoNearbyPlayerCDTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __healthTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __distanceToPlayerTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityWhenNoNearbyPlayerCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityWhenNoNearbyPlayerCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityWhenNoNearbyPlayerCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DestroyEntityWhenNoNearbyPlayerCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DistanceToPlayerCD>(nativeArrayPtr4, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000016EF_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000016EF_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<DestroyEntityWhenNoNearbyPlayerCD> __DestroyEntityWhenNoNearbyPlayerCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<DistanceToPlayerCD> __DistanceToPlayerCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__DestroyEntityWhenNoNearbyPlayerCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<DestroyEntityWhenNoNearbyPlayerCD>();
			__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
			__DistanceToPlayerCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DistanceToPlayerCD>(isReadOnly: true);
			__IsInCombatCD_RO_ComponentLookup = state.GetComponentLookup<IsInCombatCD>(isReadOnly: true);
			__DontDropLootCD_RO_ComponentLookup = state.GetComponentLookup<DontDropLootCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_81112649_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Execute(ref time, ref ecb);
		base.OnUpdate();
	}

	private void DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Execute(ref double time, ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__DestroyEntityWhenNoNearbyPlayerCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__IsInCombatCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DontDropLootCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Job value = new DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Job
		{
			time = time,
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__destroyEntityWhenNoNearbyPlayerCDTypeHandle = __TypeHandle.__DestroyEntityWhenNoNearbyPlayerCD_RW_ComponentTypeHandle,
			__healthTypeHandle = __TypeHandle.__HealthCD_RW_ComponentTypeHandle,
			__distanceToPlayerTypeHandle = __TypeHandle.__DistanceToPlayerCD_RO_ComponentTypeHandle,
			__IsInCombatCD_ComponentLookup = __TypeHandle.__IsInCombatCD_RO_ComponentLookup,
			__DontDropLootCD_ComponentLookup = __TypeHandle.__DontDropLootCD_RO_ComponentLookup
		};
		if (!__query_81112649_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			DestroyEntitiesWhenNoNearbyPlayerSystem_2BF25CCC_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_81112649_0, jobPtr);
		}
		time = value.time;
		ecb = value.ecb;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<DistanceToPlayerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<DestroyEntityWhenNoNearbyPlayerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
		_queryRequiredForUpdate = (__query_81112649_0 = entityQueryBuilder2.Build(ref state));
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
	public DestroyEntitiesWhenNoNearbyPlayerSystem()
	{
	}
}
