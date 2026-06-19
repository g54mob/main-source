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
public class MusicAreaSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct MusicAreaSystem_78AE8912_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_0000256A_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_0000256A_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_0000256A_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public NetworkTick currentTick;

		public uint tickRate;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<MusicAreaCD> __musicAreaTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref MusicAreaCD musicArea, [NoAlias] in StateInfoCD stateInfo)
		{
			bool flag = __IsInCombatCD_ComponentLookup.HasComponent(entity) && __IsInCombatCD_ComponentLookup[entity].isInCombat;
			if (entityDestroyedLookup.HasComponent(entity) && entityDestroyedLookup.IsComponentEnabled(entity) && __EntityDestroyedCD_ComponentLookup[entity].destroyTimer.GetElapsedSeconds(currentTick, tickRate) > 3f)
			{
				musicArea.isInactive = true;
			}
			else if (musicArea.activeWhenEntityIsInCombat)
			{
				musicArea.isInactive = !flag;
			}
			else if (musicArea.deactivateWhenEntityIsInState)
			{
				musicArea.isInactive = stateInfo.currentState == musicArea.stateToDeactivateIn;
			}
			if (musicArea.playOtherMusicWhenInCombat && flag)
			{
				musicArea.musicRosterType = musicArea.otherMusicRosterType;
				musicArea.fadeTime = musicArea.otherFadeTime;
			}
			else
			{
				musicArea.musicRosterType = musicArea.originalRosterType;
				musicArea.fadeTime = musicArea.originalFadeTime;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __musicAreaTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __stateInfoTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MusicAreaCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_0000256A_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_0000256A_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<MusicAreaSystem_78AE8912_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<MusicAreaCD> __MusicAreaCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<IsInCombatCD> __IsInCombatCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__MusicAreaCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<MusicAreaCD>();
			__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
			__IsInCombatCD_RO_ComponentLookup = state.GetComponentLookup<IsInCombatCD>(isReadOnly: true);
			__EntityDestroyedCD_RO_ComponentLookup = state.GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_414016293_0;

	private EntityQuery __query_414016293_1;

	private EntityQuery __query_414016293_2;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		__query_414016293_1.TryGetSingleton<NetworkTime>(out var value);
		if (!VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, value, 11, 1f))
		{
			base.OnUpdate();
			return;
		}
		NetworkTick currentTick = value.ServerTick;
		uint tickRate = (uint)__query_414016293_2.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		ComponentLookup<EntityDestroyedCD> entityDestroyedLookup = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		MusicAreaSystem_78AE8912_LambdaJob_0_Execute(ref currentTick, ref tickRate, ref entityDestroyedLookup);
		base.OnUpdate();
	}

	private void MusicAreaSystem_78AE8912_LambdaJob_0_Execute(ref NetworkTick currentTick, ref uint tickRate, ref ComponentLookup<EntityDestroyedCD> entityDestroyedLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MusicAreaCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__IsInCombatCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__EntityDestroyedCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		MusicAreaSystem_78AE8912_LambdaJob_0_Job value = new MusicAreaSystem_78AE8912_LambdaJob_0_Job
		{
			currentTick = currentTick,
			tickRate = tickRate,
			entityDestroyedLookup = entityDestroyedLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__musicAreaTypeHandle = __TypeHandle.__MusicAreaCD_RW_ComponentTypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle,
			__IsInCombatCD_ComponentLookup = __TypeHandle.__IsInCombatCD_RO_ComponentLookup,
			__EntityDestroyedCD_ComponentLookup = __TypeHandle.__EntityDestroyedCD_RO_ComponentLookup
		};
		if (!__query_414016293_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			MusicAreaSystem_78AE8912_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_414016293_0, jobPtr);
		}
		currentTick = value.currentTick;
		tickRate = value.tickRate;
		entityDestroyedLookup = value.entityDestroyedLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAny<IdleStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAny<BirdBossFlyingAboveStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<MusicAreaCD>();
		__query_414016293_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_414016293_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_414016293_2 = entityQueryBuilder2.Build(ref state);
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
	public MusicAreaSystem()
	{
	}
}
