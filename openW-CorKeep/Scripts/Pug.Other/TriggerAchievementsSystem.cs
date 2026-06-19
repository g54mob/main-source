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
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class TriggerAchievementsSystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct HasTriggeredDeathAchievement : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_000001B8_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_000001B8_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_000001B8_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public EntityArchetype localRpcArchetype;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<TriggerAchievementOnDeathCD> __triggerAchievementOnDeathTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in TriggerAchievementOnDeathCD triggerAchievementOnDeath)
		{
			AchievementSystem.TriggerAchievementForEveryone(ecb, localRpcArchetype, triggerAchievementOnDeath.achievement);
			ecb.AddComponent<HasTriggeredDeathAchievement>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __triggerAchievementOnDeathTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TriggerAchievementOnDeathCD>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TriggerAchievementOnDeathCD>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TriggerAchievementOnDeathCD>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TriggerAchievementOnDeathCD>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_000001B8_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_000001B8_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<TriggerAchievementOnDeathCD> __TriggerAchievementOnDeathCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__TriggerAchievementOnDeathCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TriggerAchievementOnDeathCD>(isReadOnly: true);
		}
	}

	private Entity achievementTrackerEntity;

	private float achievementTrackerTimer;

	private EntityQuery cherryBlossomQuery;

	private EntityArchetype rpcArchetype;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_671493807_0;

	private EntityQuery __query_671493807_1;

	private EntityQuery __query_671493807_2;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		rpcArchetype = base.EntityManager.CreateArchetype(typeof(AchievementSystem.AchievementRpc), typeof(SendRpcCommandRequest));
		RequireForUpdate<PugPrefabBuffer>();
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.Any = new ComponentType[1] { typeof(CherryBlossomTreeCD) };
		entityQueryDesc.None = new ComponentType[1] { typeof(CustomSceneObjectCD) };
		entityQueryDesc.Options = EntityQueryOptions.IncludeDisabledEntities;
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		cherryBlossomQuery = GetEntityQuery(entityQueryDesc2);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (!__query_671493807_1.HasSingleton<AchievementTrackerCD>())
		{
			DynamicBuffer<PugPrefabBuffer> singletonBuffer = __query_671493807_2.GetSingletonBuffer<PugPrefabBuffer>();
			for (int i = 0; i < singletonBuffer.Length; i++)
			{
				if (HasComponent<AchievementTrackerCD>(singletonBuffer[i].Value))
				{
					achievementTrackerEntity = base.EntityManager.Instantiate(singletonBuffer[i].Value);
					break;
				}
			}
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);
		EntityArchetype localRpcArchetype = rpcArchetype;
		TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Execute(ref ecb, ref localRpcArchetype);
		achievementTrackerTimer -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (achievementTrackerTimer < 0f)
		{
			achievementTrackerTimer = UnityEngine.Random.value + 0.5f;
			AchievementTrackerCD component = GetComponent<AchievementTrackerCD>(achievementTrackerEntity);
			if (!component.cherryBlossomAchievement && cherryBlossomQuery.CalculateEntityCount() >= 10)
			{
				component.cherryBlossomAchievement = true;
				base.EntityManager.SetComponentData(achievementTrackerEntity, component);
			}
		}
		ecb.Playback(base.EntityManager);
		ecb.Dispose();
		base.OnUpdate();
	}

	private void TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref EntityArchetype localRpcArchetype)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TriggerAchievementOnDeathCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Job value = new TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Job
		{
			ecb = ecb,
			localRpcArchetype = localRpcArchetype,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__triggerAchievementOnDeathTypeHandle = __TypeHandle.__TriggerAchievementOnDeathCD_RO_ComponentTypeHandle
		};
		if (!__query_671493807_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			TriggerAchievementsSystem_43FC76BC_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_671493807_0, jobPtr);
		}
		ecb = value.ecb;
		localRpcArchetype = value.localRpcArchetype;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<HasTriggeredDeathAchievement>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<DontDropLootCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<TriggerAchievementOnDeathCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EntityDestroyedCD>();
		__query_671493807_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<AchievementTrackerCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_671493807_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_671493807_2 = entityQueryBuilder2.Build(ref state);
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
	public TriggerAchievementsSystem()
	{
	}
}
