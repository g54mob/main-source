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
public class PlaceObjectStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003CB1_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003CB1_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003CB1_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public int placeAnim;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public Unity.Mathematics.Random rng;

		public NetworkTick currentTick;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<PlaceObjectStateCD> __placeStateTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationBufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref PlaceObjectStateCD placeState, DynamicBuffer<AnimationBuffer> animationBuffer, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref ObjectDataCD objectData, [NoAlias] in LocalTransform transform)
		{
			if (stateInfo.IsCurrentState(StateID.PlaceObject))
			{
				if (placeState.internalState == 0)
				{
					placeState.cooldownTimer.Start(time, rng.NextFloat(placeState.minCooldown, placeState.maxCooldown));
					AnimationUtilities.TriggerAnimation(placeAnim, currentTick, animationBuffer, ref animationBufferPointer);
					placeState.internalState = 1;
					placeState.timer.Start(time, placeState.placeDuration);
				}
				else if (placeState.internalState == 1 && placeState.timer.IsTimerElapsed(time))
				{
					objectData.amount++;
					EntityUtility.CreateEntity(ecb, math.round(transform.Position), placeState.objectToPlace, 1, databaseLocal);
					placeState.internalState = 2;
				}
				else if (placeState.internalState == 2)
				{
					stateInfo.LeaveState();
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __placeStateTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animationBufferTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __objectDataTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlaceObjectStateCD>(nativeArrayPtr2, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i));
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
						OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlaceObjectStateCD>(nativeArrayPtr2, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j));
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
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlaceObjectStateCD>(nativeArrayPtr2, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlaceObjectStateCD>(nativeArrayPtr2, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr3, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003CB1_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003CB1_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<PlaceObjectStateCD> __PlaceObjectStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__PlaceObjectStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PlaceObjectStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1294900985_0;

	private EntityQuery __query_1294900985_1;

	[Preserve]
	protected override void OnCreate()
	{
		NeedDatabase();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		int placeAnim = -34540245;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		__query_1294900985_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Execute(ref time, ref placeAnim, ref ecb, ref databaseLocal, ref rng, ref currentTick);
		base.OnUpdate();
	}

	private void PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Execute(ref double time, ref int placeAnim, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref Unity.Mathematics.Random rng, ref NetworkTick currentTick)
	{
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlaceObjectStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Job value = new PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Job
		{
			time = time,
			placeAnim = placeAnim,
			ecb = ecb,
			databaseLocal = databaseLocal,
			rng = rng,
			currentTick = currentTick,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__placeStateTypeHandle = __TypeHandle.__PlaceObjectStateCD_RW_ComponentTypeHandle,
			__animationBufferTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		if (!__query_1294900985_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			PlaceObjectStateSystem_41ECADC3_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1294900985_0, jobPtr);
		}
		time = value.time;
		placeAnim = value.placeAnim;
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		rng = value.rng;
		currentTick = value.currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PlaceObjectStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ObjectDataCD>();
		_queryRequiredForUpdate = (__query_1294900985_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1294900985_1 = entityQueryBuilder2.Build(ref state);
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
	public PlaceObjectStateSystem()
	{
	}
}
