using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class SpawnBasedOnPlayersSystem : SystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00002E22_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00002E22_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00002E22_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public NativeArray<int2> offsetsToCheckLocal;

		public Entity tileUpdateBufferSingleton;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in LocalTransform transform)
		{
			int2 int5 = transform.Position.RoundToInt2();
			for (int i = 0; i < offsetsToCheckLocal.Length; i++)
			{
				int2 position = int5 + offsetsToCheckLocal[i];
				ecb.AppendToBuffer(tileUpdateBufferSingleton, new TileUpdateBuffer
				{
					position = position,
					command = TileUpdateBuffer.Command.Add
				});
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, i));
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
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, j));
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
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00002E22_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00002E22_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private BeginSimulationEntityCommandBufferSystem ecbSystem;

	private NativeArray<int2> offsetsToCheck;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1674225998_0;

	private EntityQuery __query_1674225998_1;

	private EntityQuery __query_1674225998_2;

	[Preserve]
	protected override void OnCreate()
	{
		ecbSystem = base.World.GetOrCreateSystemManaged<BeginSimulationEntityCommandBufferSystem>();
		int2 int5 = new int2(32, 32);
		offsetsToCheck = new NativeArray<int2>(new int2[9]
		{
			new int2(0, 0),
			new int2(0, int5.y),
			new int2(0, -int5.y),
			new int2(int5.x, 0),
			new int2(int5.x, int5.y),
			new int2(int5.x, -int5.y),
			new int2(-int5.x, 0),
			new int2(-int5.x, int5.y),
			new int2(-int5.x, -int5.y)
		}, Allocator.Persistent);
		RequireForUpdate<InitialLoadingDoneCD>();
		RequireForUpdate<TileUpdateBuffer>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		offsetsToCheck.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NetworkTime singleton = __query_1674225998_1.GetSingleton<NetworkTime>();
		if (VariableSystemUpdate.ShouldUpdate(ref base.CheckedStateRef, singleton, 3, 1f))
		{
			EntityCommandBuffer ecb = ecbSystem.CreateCommandBuffer();
			NativeArray<int2> offsetsToCheckLocal = offsetsToCheck;
			Entity tileUpdateBufferSingleton = __query_1674225998_2.GetSingletonEntity();
			SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Execute(ref ecb, ref offsetsToCheckLocal, ref tileUpdateBufferSingleton);
			ecbSystem.AddJobHandleForProducer(base.Dependency);
		}
	}

	private void SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref NativeArray<int2> offsetsToCheckLocal, ref Entity tileUpdateBufferSingleton)
	{
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Job value = new SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Job
		{
			ecb = ecb,
			offsetsToCheckLocal = offsetsToCheckLocal,
			tileUpdateBufferSingleton = tileUpdateBufferSingleton,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		if (!__query_1674225998_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			SpawnBasedOnPlayersSystem_47DBA7D_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1674225998_0, jobPtr);
		}
		ecb = value.ecb;
		offsetsToCheckLocal = value.offsetsToCheckLocal;
		tileUpdateBufferSingleton = value.tileUpdateBufferSingleton;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
		__query_1674225998_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1674225998_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1674225998_2 = entityQueryBuilder2.Build(ref state);
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
	public SpawnBasedOnPlayersSystem()
	{
	}
}
