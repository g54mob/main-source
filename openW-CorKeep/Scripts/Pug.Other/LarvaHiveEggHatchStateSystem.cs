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
public class LarvaHiveEggHatchStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003B2C_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003B2C_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003B2C_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public int state0Anim;

		public int state1Anim;

		public int state2Anim;

		public int goToState0Anim;

		public int goToState1Anim;

		public int goToState2Anim;

		public int isHatchingAnim;

		public int hatchAnim;

		public int hasHatchedAnim;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public EntityCommandBuffer ecb;

		public Unity.Mathematics.Random rnd;

		public NetworkTick currentTick;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<LarvaHiveEggHatchStateCD> __hatchStateTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationBufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<HealthCD> __healthTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref LarvaHiveEggHatchStateCD hatchState, DynamicBuffer<AnimationBuffer> animationBuffer, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref HealthCD health, [NoAlias] in LocalTransform transform)
		{
			if (!stateInfo.IsCurrentState(StateID.LarvaHiveEggHatch))
			{
				return;
			}
			if (health.health <= 0)
			{
				if (hatchState.internalState != 0)
				{
					if (hatchState.internalState == 8)
					{
						ObjectID objectID = rnd.NextInt(0, 3) switch
						{
							1 => ObjectID.BigLarva, 
							0 => ObjectID.Larva, 
							_ => ObjectID.AcidLarva, 
						};
						int num = 0;
						int variation = 0;
						switch (objectID)
						{
						case ObjectID.Larva:
							num = rnd.NextInt(6, 8);
							variation = 2;
							break;
						case ObjectID.BigLarva:
							num = rnd.NextInt(2, 3);
							variation = 2;
							break;
						case ObjectID.AcidLarva:
							num = rnd.NextInt(3, 4);
							variation = 1;
							break;
						}
						for (int i = 0; i < num; i++)
						{
							float3 float5 = new float3(rnd.NextFloat(-0.3f, 0.3f), 0f, rnd.NextFloat(-0.3f, 0.3f));
							EntityUtility.CreateEntity(ecb, transform.Position + float5, objectID, 1, databaseLocal, variation);
						}
						float3 float6 = new float3(rnd.NextFloat(-0.3f, 0.3f), 0f, rnd.NextFloat(-0.3f, 0.3f));
						EntityUtility.CreateEntity(ecb, transform.Position + float6, ObjectID.BigLarva, 1, databaseLocal, 2);
					}
					hatchState.internalState = 0;
					AnimationUtilities.TriggerAnimation(hatchAnim, currentTick, animationBuffer, ref animationBufferPointer);
					hatchState.internalTimer.Start(time, 1f);
				}
				else if (animationBuffer.GetLastAddedElement(in animationBufferPointer).animID != hasHatchedAnim && hatchState.internalTimer.IsTimerElapsed(time))
				{
					AnimationUtilities.TriggerAnimation(hasHatchedAnim, currentTick, animationBuffer, ref animationBufferPointer);
				}
				return;
			}
			if (hatchState.internalState != 0 && !hatchState.internalTimer.IsTimerElapsed(time))
			{
				stateInfo.LeaveState();
			}
			if (hatchState.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(goToState0Anim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 1;
				hatchState.internalTimer.Start(time, hatchState.stateTransitionDuration);
			}
			else if (hatchState.internalState == 1 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(state0Anim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 2;
				hatchState.internalTimer.Start(time, 2f);
			}
			else if (hatchState.internalState == 2 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(goToState1Anim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 3;
				hatchState.internalTimer.Start(time, hatchState.stateTransitionDuration);
			}
			else if (hatchState.internalState == 3 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(state1Anim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 4;
				hatchState.internalTimer.Start(time, 2f);
			}
			else if (hatchState.internalState == 4 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(goToState2Anim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 5;
				hatchState.internalTimer.Start(time, hatchState.stateTransitionDuration);
			}
			else if (hatchState.internalState == 5 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(state2Anim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 6;
				hatchState.internalTimer.Start(time, 2f);
			}
			else if (hatchState.internalState == 6 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(isHatchingAnim, currentTick, animationBuffer, ref animationBufferPointer);
				hatchState.internalState = 7;
				hatchState.internalTimer.Start(time, hatchState.hatchDuration);
			}
			else if (hatchState.internalState == 7 && hatchState.internalTimer.IsTimerElapsed(time))
			{
				hatchState.internalState = 8;
				health.health = 0;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __hatchStateTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animationBufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __healthTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i));
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j));
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LarvaHiveEggHatchStateCD>(nativeArrayPtr2, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003B2C_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003B2C_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<LarvaHiveEggHatchStateCD> __LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LarvaHiveEggHatchStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private const float TIME_BETWEEN_STATES = 2f;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_2116667487_0;

	private EntityQuery __query_2116667487_1;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		RequireForUpdate<LarvaHiveEggHatchStateCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		int state0Anim = -568891545;
		int state1Anim = -1458546703;
		int state2Anim = 806946379;
		int goToState0Anim = -1753203768;
		int goToState1Anim = -528020642;
		int goToState2Anim = 2039372516;
		int isHatchingAnim = 267581710;
		int hatchAnim = 2053665356;
		int hasHatchedAnim = -849250722;
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		Unity.Mathematics.Random rnd = PugRandom.GetRng();
		__query_2116667487_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Execute(ref time, ref state0Anim, ref state1Anim, ref state2Anim, ref goToState0Anim, ref goToState1Anim, ref goToState2Anim, ref isHatchingAnim, ref hatchAnim, ref hasHatchedAnim, ref databaseLocal, ref ecb, ref rnd, ref currentTick);
		base.OnUpdate();
	}

	private void LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Execute(ref double time, ref int state0Anim, ref int state1Anim, ref int state2Anim, ref int goToState0Anim, ref int goToState1Anim, ref int goToState2Anim, ref int isHatchingAnim, ref int hatchAnim, ref int hasHatchedAnim, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref EntityCommandBuffer ecb, ref Unity.Mathematics.Random rnd, ref NetworkTick currentTick)
	{
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Job value = new LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Job
		{
			time = time,
			state0Anim = state0Anim,
			state1Anim = state1Anim,
			state2Anim = state2Anim,
			goToState0Anim = goToState0Anim,
			goToState1Anim = goToState1Anim,
			goToState2Anim = goToState2Anim,
			isHatchingAnim = isHatchingAnim,
			hatchAnim = hatchAnim,
			hasHatchedAnim = hasHatchedAnim,
			databaseLocal = databaseLocal,
			ecb = ecb,
			rnd = rnd,
			currentTick = currentTick,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__hatchStateTypeHandle = __TypeHandle.__LarvaHiveEggHatchStateCD_RW_ComponentTypeHandle,
			__animationBufferTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__healthTypeHandle = __TypeHandle.__HealthCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		if (!__query_2116667487_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			LarvaHiveEggHatchStateSystem_9F7C0_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_2116667487_0, jobPtr);
		}
		time = value.time;
		state0Anim = value.state0Anim;
		state1Anim = value.state1Anim;
		state2Anim = value.state2Anim;
		goToState0Anim = value.goToState0Anim;
		goToState1Anim = value.goToState1Anim;
		goToState2Anim = value.goToState2Anim;
		isHatchingAnim = value.isHatchingAnim;
		hatchAnim = value.hatchAnim;
		hasHatchedAnim = value.hasHatchedAnim;
		databaseLocal = value.databaseLocal;
		ecb = value.ecb;
		rnd = value.rnd;
		currentTick = value.currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LarvaHiveEggHatchStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
		__query_2116667487_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_2116667487_1 = entityQueryBuilder2.Build(ref state);
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
	public LarvaHiveEggHatchStateSystem()
	{
	}
}
