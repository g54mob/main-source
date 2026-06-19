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
public class SetVariationSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SetVariationSystem_68987E31_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000036B6_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000036B6_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000036B6_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public bool worldIsReadOnly;

		public ComponentLookup<ConnectionAdminLevelCD> adminLevelLookup;

		[ReadOnly]
		public ComponentTypeHandle<SetVariationRPC> __rpcTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __rpcSourceTypeHandle;

		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in SetVariationRPC rpc, [NoAlias] in ReceiveRpcCommandRequest rpcSource)
		{
			if ((!worldIsReadOnly || adminLevelLookup.GetAdminLevelOnServer(rpcSource.SourceConnection) > 0) && __ObjectDataCD_ComponentLookup.HasComponent(rpc.entity))
			{
				ObjectDataCD value = __ObjectDataCD_ComponentLookup[rpc.entity];
				if (rpc.updateCount > value.variationUpdateCount)
				{
					value.variation = rpc.variation;
					value.variationUpdateCount = rpc.updateCount;
					__ObjectDataCD_ComponentLookup[rpc.entity] = value;
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __rpcSourceTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SetVariationRPC>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SetVariationRPC>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SetVariationRPC>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SetVariationRPC>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ReceiveRpcCommandRequest>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000036B6_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000036B6_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SetVariationSystem_68987E31_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<SetVariationRPC> __SetVariationRPC_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ReceiveRpcCommandRequest> __Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle;

		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ConnectionAdminLevelCD> __ConnectionAdminLevelCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__SetVariationRPC_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SetVariationRPC>(isReadOnly: true);
			__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ReceiveRpcCommandRequest>(isReadOnly: true);
			__ObjectDataCD_RW_ComponentLookup = state.GetComponentLookup<ObjectDataCD>();
			__ConnectionAdminLevelCD_RO_ComponentLookup = state.GetComponentLookup<ConnectionAdminLevelCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_778868218_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		bool worldIsReadOnly = base.WorldInfo.guestMode;
		ComponentLookup<ConnectionAdminLevelCD> adminLevelLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ConnectionAdminLevelCD_RO_ComponentLookup, ref base.CheckedStateRef);
		SetVariationSystem_68987E31_LambdaJob_0_Execute(ref worldIsReadOnly, ref adminLevelLookup);
		base.EntityManager.DestroyEntity(_queryRequiredForUpdate);
		base.OnUpdate();
	}

	private void SetVariationSystem_68987E31_LambdaJob_0_Execute(ref bool worldIsReadOnly, ref ComponentLookup<ConnectionAdminLevelCD> adminLevelLookup)
	{
		__TypeHandle.__SetVariationRPC_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RW_ComponentLookup.Update(ref base.CheckedStateRef);
		SetVariationSystem_68987E31_LambdaJob_0_Job value = new SetVariationSystem_68987E31_LambdaJob_0_Job
		{
			worldIsReadOnly = worldIsReadOnly,
			adminLevelLookup = adminLevelLookup,
			__rpcTypeHandle = __TypeHandle.__SetVariationRPC_RO_ComponentTypeHandle,
			__rpcSourceTypeHandle = __TypeHandle.__Unity_NetCode_ReceiveRpcCommandRequest_RO_ComponentTypeHandle,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RW_ComponentLookup
		};
		if (!__query_778868218_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			SetVariationSystem_68987E31_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_778868218_0, jobPtr);
		}
		worldIsReadOnly = value.worldIsReadOnly;
		adminLevelLookup = value.adminLevelLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SetVariationRPC>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ReceiveRpcCommandRequest>();
		_queryRequiredForUpdate = (__query_778868218_0 = entityQueryBuilder2.Build(ref state));
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
	public SetVariationSystem()
	{
	}
}
