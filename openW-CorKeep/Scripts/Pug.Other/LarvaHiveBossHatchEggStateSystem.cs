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
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class LarvaHiveBossHatchEggStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003B21_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003B21_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003B21_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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
		public NativeArray<Entity> eggs;

		public Unity.Mathematics.Random rnd;

		public int amountOfPlayers;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<LarvaHiveBossHatchEggStateCD> __bossStateTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __healthTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnrageStateCD> __EnrageStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LarvaHiveEggHatchStateCD> __LarvaHiveEggHatchStateCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref LarvaHiveBossHatchEggStateCD bossState, [NoAlias] in HealthCD health)
		{
			if (!stateInfo.IsCurrentState(StateID.LarvaHiveBossHatchEgg) || (bossState.eggCooldownTimer.isRunning && !bossState.eggCooldownTimer.IsTimerElapsed(time)))
			{
				return;
			}
			int num = ((amountOfPlayers >= 6) ? 2 : ((amountOfPlayers >= 3) ? 1 : 0));
			int num2 = 1 + num;
			if (__EnrageStateCD_ComponentLookup.HasComponent(entity) && __EnrageStateCD_ComponentLookup[entity].isEnraged)
			{
				num2 = 2 + num;
			}
			if (eggs.Length > 0)
			{
				for (int i = 0; i < num2; i++)
				{
					int index = rnd.NextInt(0, eggs.Length);
					Entity entity2 = eggs[index];
					if (__LarvaHiveEggHatchStateCD_ComponentLookup[entity2].internalState != 0)
					{
						stateInfo.LeaveState();
						bossState.eggCooldownTimer.Start(time, 1f);
						return;
					}
					if (entity2 != Entity.Null && __HealthCD_ComponentLookup.HasComponent(entity2))
					{
						HealthCD healthCD = __HealthCD_ComponentLookup[entity2];
						ecb.SetComponent(entity2, new HealthCD
						{
							health = healthCD.maxHealth,
							maxHealth = healthCD.maxHealth
						});
					}
				}
			}
			stateInfo.LeaveState();
			float t = (float)health.health / (float)health.maxHealth;
			float newLifespan = math.lerp(10f, 17f, t);
			bossState.eggCooldownTimer.Start(time, newLifespan);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __bossStateTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __healthTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveBossHatchEggStateCD>(nativeArrayPtr3, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveBossHatchEggStateCD>(nativeArrayPtr3, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveBossHatchEggStateCD>(nativeArrayPtr3, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveBossHatchEggStateCD>(nativeArrayPtr3, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, l));
				}
				num >>= 1;
			}
		}

		public void DisposeOnCompletion()
		{
			eggs.Dispose();
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003B21_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003B21_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<LarvaHiveBossHatchEggStateCD> __LarvaHiveBossHatchEggStateCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<EnrageStateCD> __EnrageStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LarvaHiveEggHatchStateCD> __LarvaHiveEggHatchStateCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<HealthCD> __HealthCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__LarvaHiveBossHatchEggStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LarvaHiveBossHatchEggStateCD>();
			__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
			__EnrageStateCD_RO_ComponentLookup = state.GetComponentLookup<EnrageStateCD>(isReadOnly: true);
			__LarvaHiveEggHatchStateCD_RO_ComponentLookup = state.GetComponentLookup<LarvaHiveEggHatchStateCD>(isReadOnly: true);
			__HealthCD_RO_ComponentLookup = state.GetComponentLookup<HealthCD>(isReadOnly: true);
		}
	}

	public const float hatchEggsInitialCooldown = 3f;

	public const float hatchEggsMinCooldown = 10f;

	public const float hatchEggsMaxCooldown = 17f;

	private EntityQuery eggQuery;

	private EntityQuery playerQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1486298716_0;

	[Preserve]
	protected override void OnCreate()
	{
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<PlayerGhost>() };
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		playerQuery = GetEntityQuery(entityQueryDesc2);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<LarvaHiveEggHatchStateCD>() };
		EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
		eggQuery = GetEntityQuery(entityQueryDesc3);
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		NativeArray<Entity> eggs = eggQuery.ToEntityArray(Allocator.Temp);
		Unity.Mathematics.Random rnd = PugRandom.GetRng();
		int amountOfPlayers = math.max(1, playerQuery.CalculateEntityCount());
		LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Execute(ref time, ref ecb, ref eggs, ref rnd, ref amountOfPlayers);
		base.OnUpdate();
	}

	private void LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Execute(ref double time, ref EntityCommandBuffer ecb, ref NativeArray<Entity> eggs, ref Unity.Mathematics.Random rnd, ref int amountOfPlayers)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LarvaHiveBossHatchEggStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__EnrageStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__LarvaHiveEggHatchStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Job value = new LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Job
		{
			time = time,
			ecb = ecb,
			eggs = eggs,
			rnd = rnd,
			amountOfPlayers = amountOfPlayers,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__bossStateTypeHandle = __TypeHandle.__LarvaHiveBossHatchEggStateCD_RW_ComponentTypeHandle,
			__healthTypeHandle = __TypeHandle.__HealthCD_RO_ComponentTypeHandle,
			__EnrageStateCD_ComponentLookup = __TypeHandle.__EnrageStateCD_RO_ComponentLookup,
			__LarvaHiveEggHatchStateCD_ComponentLookup = __TypeHandle.__LarvaHiveEggHatchStateCD_RO_ComponentLookup,
			__HealthCD_ComponentLookup = __TypeHandle.__HealthCD_RO_ComponentLookup
		};
		if (!__query_1486298716_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LarvaHiveBossHatchEggStateSystem_2D48F2C1_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1486298716_0, jobPtr);
		}
		value.DisposeOnCompletion();
		time = value.time;
		ecb = value.ecb;
		eggs = value.eggs;
		rnd = value.rnd;
		amountOfPlayers = value.amountOfPlayers;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LarvaHiveBossHatchEggStateCD>();
		_queryRequiredForUpdate = (__query_1486298716_0 = entityQueryBuilder2.Build(ref state));
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
	public LarvaHiveBossHatchEggStateSystem()
	{
	}
}
