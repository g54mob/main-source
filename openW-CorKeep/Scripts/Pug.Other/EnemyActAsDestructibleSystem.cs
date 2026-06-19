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

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class EnemyActAsDestructibleSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00001CF6_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00001CF6_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00001CF6_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<EnemyActAsDestructibleCD> __enemyDestructibleCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __healthCDTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestructibleObjectCD> __DestructibleObjectCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MineableCD> __MineableCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref EnemyActAsDestructibleCD enemyDestructibleCD, [NoAlias] in HealthCD healthCD)
		{
			if (enemyDestructibleCD.healthThreshold < healthCD.Normalized)
			{
				if (__EnemyCD_ComponentLookup.HasComponent(entity))
				{
					ecb.RemoveComponent<EnemyCD>(entity);
				}
				if (!__DestructibleObjectCD_ComponentLookup.HasComponent(entity))
				{
					ecb.AddComponent<DestructibleObjectCD>(entity);
				}
				if (!__MineableCD_ComponentLookup.HasComponent(entity))
				{
					ecb.AddComponent<MineableCD>(entity);
				}
				if (!__DamageReductionCD_ComponentLookup.HasComponent(entity))
				{
					ecb.AddComponent(entity, enemyDestructibleCD.damageReductionBackup);
				}
				return;
			}
			if (!__EnemyCD_ComponentLookup.HasComponent(entity))
			{
				ecb.AddComponent<EnemyCD>(entity);
			}
			if (__DestructibleObjectCD_ComponentLookup.HasComponent(entity))
			{
				ecb.RemoveComponent<DestructibleObjectCD>(entity);
			}
			if (__MineableCD_ComponentLookup.HasComponent(entity))
			{
				ecb.RemoveComponent<MineableCD>(entity);
			}
			if (__DamageReductionCD_ComponentLookup.HasComponent(entity))
			{
				enemyDestructibleCD.damageReductionBackup = __DamageReductionCD_ComponentLookup[entity];
				ecb.RemoveComponent<DamageReductionCD>(entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __enemyDestructibleCDTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __healthCDTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyActAsDestructibleCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyActAsDestructibleCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyActAsDestructibleCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<EnemyActAsDestructibleCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00001CF6_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00001CF6_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<EnemyActAsDestructibleCD> __EnemyActAsDestructibleCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnemyCD> __EnemyCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DestructibleObjectCD> __DestructibleObjectCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<MineableCD> __MineableCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DamageReductionCD> __DamageReductionCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__EnemyActAsDestructibleCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<EnemyActAsDestructibleCD>();
			__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
			__EnemyCD_RO_ComponentLookup = state.GetComponentLookup<EnemyCD>(isReadOnly: true);
			__DestructibleObjectCD_RO_ComponentLookup = state.GetComponentLookup<DestructibleObjectCD>(isReadOnly: true);
			__MineableCD_RO_ComponentLookup = state.GetComponentLookup<MineableCD>(isReadOnly: true);
			__DamageReductionCD_RO_ComponentLookup = state.GetComponentLookup<DamageReductionCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2076620140_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		RequireForUpdate<EnemyActAsDestructibleCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Execute(ref ecb);
		base.OnUpdate();
	}

	private void EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Execute(ref EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnemyActAsDestructibleCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnemyCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DestructibleObjectCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__MineableCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DamageReductionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Job value = new EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Job
		{
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__enemyDestructibleCDTypeHandle = __TypeHandle.__EnemyActAsDestructibleCD_RW_ComponentTypeHandle,
			__healthCDTypeHandle = __TypeHandle.__HealthCD_RO_ComponentTypeHandle,
			__EnemyCD_ComponentLookup = __TypeHandle.__EnemyCD_RO_ComponentLookup,
			__DestructibleObjectCD_ComponentLookup = __TypeHandle.__DestructibleObjectCD_RO_ComponentLookup,
			__MineableCD_ComponentLookup = __TypeHandle.__MineableCD_RO_ComponentLookup,
			__DamageReductionCD_ComponentLookup = __TypeHandle.__DamageReductionCD_RO_ComponentLookup
		};
		if (!__query_2076620140_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			EnemyActAsDestructibleSystem_334B826C_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2076620140_0, jobPtr);
		}
		ecb = value.ecb;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<EnemyActAsDestructibleCD>();
		__query_2076620140_0 = entityQueryBuilder2.Build(ref state);
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
	public EnemyActAsDestructibleSystem()
	{
	}
}
