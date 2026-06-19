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
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class DynamicSpawnDistanceSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DynamicSpawnDistanceSet : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00001C17_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00001C17_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00001C17_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public NativeList<Entity> entitiesToAlwaysSpawn;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ClaimedByPlayerGuidCD> __claimedByPlayerTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in ClaimedByPlayerGuidCD claimedByPlayer)
		{
			if (claimedByPlayer.isClaimed)
			{
				entitiesToAlwaysSpawn.Add(in entity);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __claimedByPlayerTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClaimedByPlayerGuidCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClaimedByPlayerGuidCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClaimedByPlayerGuidCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ClaimedByPlayerGuidCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00001C17_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00001C17_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ClaimedByPlayerGuidCD> __ClaimedByPlayerGuidCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__ClaimedByPlayerGuidCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ClaimedByPlayerGuidCD>(isReadOnly: true);
		}
	}

	private EntityArchetype _enabledPositionArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2118786466_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		_enabledPositionArchetype = base.EntityManager.CreateArchetype(typeof(EnableEntitiesInCircleCD), typeof(EnableEntitiesTimerCD));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		NativeList<Entity> entitiesToAlwaysSpawn = new NativeList<Entity>(Allocator.Temp);
		DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Execute(ref entitiesToAlwaysSpawn);
		base.EntityManager.AddComponent<DynamicSpawnDistanceSet>(_queryRequiredForUpdate);
		foreach (Entity item in entitiesToAlwaysSpawn)
		{
			base.EntityManager.AddComponentData(item, new OverrideGhostRelevancyCD
			{
				rect = float.PositiveInfinity
			});
			base.EntityManager.AddComponent<DontDisableCD>(item);
			float2 xz = base.EntityManager.GetComponentData<LocalTransform>(item).Position.xz;
			Entity entity = base.EntityManager.CreateEntity(_enabledPositionArchetype);
			base.EntityManager.SetComponentData(entity, new EnableEntitiesInCircleCD
			{
				Center = xz,
				Radius = 1f
			});
			base.EntityManager.SetComponentData(entity, new EnableEntitiesTimerCD
			{
				RemainingTime = 0f
			});
		}
		base.OnUpdate();
	}

	private void DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Execute(ref NativeList<Entity> entitiesToAlwaysSpawn)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClaimedByPlayerGuidCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Job value = new DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Job
		{
			entitiesToAlwaysSpawn = entitiesToAlwaysSpawn,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__claimedByPlayerTypeHandle = __TypeHandle.__ClaimedByPlayerGuidCD_RO_ComponentTypeHandle
		};
		if (!__query_2118786466_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			DynamicSpawnDistanceSystem_32A99C83_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2118786466_0, jobPtr);
		}
		entitiesToAlwaysSpawn = value.entitiesToAlwaysSpawn;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<OverrideGhostRelevancyCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<DynamicSpawnDistanceSet>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ClaimedByPlayerGuidCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<GhostAlwaysRelevantWhenClaimedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		_queryRequiredForUpdate = (__query_2118786466_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		__query_2118786466_0.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(ClaimedByPlayerGuidCD))
		});
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public DynamicSpawnDistanceSystem()
	{
	}
}
