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
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class HatchWhenPlayerNearbyStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct hatch_state_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003A81_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003A81_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003A81_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		[ReadOnly]
		public NativeArray<Entity> players;

		public EntityCommandBuffer ecb;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public int isHatchingAnimID;

		public int hatchAnimID;

		public int hasHatchedAnimID;

		public Unity.Mathematics.Random rand;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> dontDropLootLookup;

		public WorldInfoCD worldInfo;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		public ComponentLookup<IsCloneCD> isCloneLookup;

		public NetworkTick currentTick;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		public ComponentTypeHandle<HatchWhenPlayerNearbyStateCD> __hatchStateTypeHandle;

		public ComponentTypeHandle<HealthCD> __healthCDTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animationBufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<FactionCD> __factionTypeHandle;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref ObjectDataCD objectData, [NoAlias] ref HatchWhenPlayerNearbyStateCD hatchState, [NoAlias] ref HealthCD healthCD, DynamicBuffer<AnimationBuffer> animationBuffer, [NoAlias] in LocalTransform transform, [NoAlias] in FactionCD faction)
		{
			if (!stateInfo.IsCurrentState(StateID.HatchWhenPlayerNearby))
			{
				return;
			}
			ref AnimationBufferPointer valueRW = ref animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			if (hatchState.internalState == 3 || objectData.amount == 100)
			{
				hatchState.internalState = 3;
				objectData.amount = 100;
				if (!hatchState.hatchAnimationIsPlaying)
				{
					AnimationUtilities.TriggerAnimation(hasHatchedAnimID, currentTick, animationBuffer, ref valueRW);
					hatchState.hatchAnimationIsPlaying = true;
				}
				return;
			}
			if (hatchState.timer.isRunning && hatchState.timer.IsTimerElapsed(time) && hatchState.internalState == 1)
			{
				hatchState.internalState = 2;
				hatchState.timer.Start(time, 0.2f);
				healthCD.health = 1;
				AnimationUtilities.TriggerAnimation(hatchAnimID, currentTick, animationBuffer, ref valueRW);
				int num = rand.NextInt(hatchState.minSpawnAmount, hatchState.maxSpawnAmount + 1);
				for (int i = 0; i < num; i++)
				{
					float3 x = new float3(rand.NextFloat(-0.3f, 0.3f), 0f, rand.NextFloat(-0.3f, 0.3f));
					float3 position = transform.Position;
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(hatchState.objectToSpawn, databaseLocal);
					Entity e = EntityUtility.CreateEntity(ecb, position, hatchState.objectToSpawn, 1, databaseLocal);
					ecb.SetComponent(e, new PhysicsVelocity
					{
						Linear = math.normalizesafe(x) * 7f
					});
					if (isCloneLookup.HasAndIsComponentEnabled(entity))
					{
						ecb.AddComponent<DontSerializeCD>(e);
						if (dontDropLootLookup.HasComponent(primaryPrefabEntity))
						{
							ecb.SetComponentEnabled<DontDropLootCD>(e, value: true);
						}
						Entity primaryPrefabEntity2 = PugDatabase.GetPrimaryPrefabEntity(hatchState.objectToSpawn, databaseLocal);
						if (isCloneLookup.HasComponent(primaryPrefabEntity2))
						{
							ecb.SetComponentEnabled<IsCloneCD>(e, value: true);
						}
					}
				}
				return;
			}
			if (hatchState.timer.isRunning && hatchState.timer.IsTimerElapsed(time) && hatchState.internalState == 2)
			{
				hatchState.internalState = 3;
				AnimationUtilities.TriggerAnimation(hasHatchedAnimID, currentTick, animationBuffer, ref valueRW);
				return;
			}
			bool flag = false;
			for (int j = 0; j < players.Length; j++)
			{
				Entity entity2 = players[j];
				FactionCD targetFaction = __FactionCD_ComponentLookup[entity2];
				if (faction.CanAttack(targetFaction, worldInfo) && math.distancesq(__Unity_Transforms_LocalTransform_ComponentLookup[entity2].Position, transform.Position) < 100f)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				stateInfo.LeaveState();
			}
			else if (!hatchState.timer.isRunning && hatchState.internalState == 0)
			{
				hatchState.internalState = 1;
				hatchState.timer.Start(time, hatchState.timeToHatch);
				AnimationUtilities.TriggerAnimation(isHatchingAnimID, currentTick, animationBuffer, ref valueRW);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __objectDataTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __hatchStateTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __healthCDTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animationBufferTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __factionTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HatchWhenPlayerNearbyStateCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr7, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HatchWhenPlayerNearbyStateCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr7, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HatchWhenPlayerNearbyStateCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr7, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HatchWhenPlayerNearbyStateCD>(nativeArrayPtr4, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<HealthCD>(nativeArrayPtr5, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr6, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FactionCD>(nativeArrayPtr7, l));
				}
				num >>= 1;
			}
		}

		public void DisposeOnCompletion()
		{
			players.Dispose();
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003A81_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003A81_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<hatch_state_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<HatchWhenPlayerNearbyStateCD> __HatchWhenPlayerNearbyStateCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<HealthCD> __HealthCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<FactionCD> __FactionCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<FactionCD> __FactionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DontDropLootCD> __DontDropLootCD_RO_ComponentLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<IsCloneCD> __IsCloneCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__ObjectDataCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>();
			__HatchWhenPlayerNearbyStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HatchWhenPlayerNearbyStateCD>();
			__HealthCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__FactionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<FactionCD>(isReadOnly: true);
			__FactionCD_RO_ComponentLookup = state.GetComponentLookup<FactionCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__DontDropLootCD_RO_ComponentLookup = state.GetComponentLookup<DontDropLootCD>(isReadOnly: true);
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
			__IsCloneCD_RO_ComponentLookup = state.GetComponentLookup<IsCloneCD>(isReadOnly: true);
		}
	}

	private const float SQR_DISTANCE_TO_PLAYER_TO_STOP_HATCH = 100f;

	private EntityQuery playersQ;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1622856135_0;

	private EntityQuery __query_1622856135_1;

	[Preserve]
	protected override void OnCreate()
	{
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[3]
		{
			ComponentType.ReadOnly<PlayerGhost>(),
			ComponentType.ReadOnly<LocalTransform>(),
			ComponentType.ReadOnly<FactionCD>()
		};
		entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadOnly<DisablePhysicsCD>() };
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		playersQ = GetEntityQuery(entityQueryDesc2);
		NeedDatabase();
		RequireForUpdate<HatchWhenPlayerNearbyStateCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		NativeArray<Entity> players = playersQ.ToEntityArray(Allocator.Temp);
		EntityCommandBuffer ecb = CreateCommandBuffer();
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		int isHatchingAnimID = 267581710;
		int hatchAnimID = -1296348555;
		int hasHatchedAnimID = -849250722;
		Unity.Mathematics.Random rand = PugRandom.GetRng();
		ComponentLookup<DontDropLootCD> dontDropLootLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DontDropLootCD_RO_ComponentLookup, ref base.CheckedStateRef);
		WorldInfoCD worldInfo = base.WorldInfo;
		ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<IsCloneCD> isCloneLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__IsCloneCD_RO_ComponentLookup, ref base.CheckedStateRef);
		__query_1622856135_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		hatch_state_Execute(ref time, ref players, ref ecb, ref databaseLocal, ref isHatchingAnimID, ref hatchAnimID, ref hasHatchedAnimID, ref rand, ref dontDropLootLookup, ref worldInfo, ref animationBufferPointerLookup, ref isCloneLookup, ref currentTick);
		base.OnUpdate();
	}

	private void hatch_state_Execute(ref double time, ref NativeArray<Entity> players, ref EntityCommandBuffer ecb, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref int isHatchingAnimID, ref int hatchAnimID, ref int hasHatchedAnimID, ref Unity.Mathematics.Random rand, ref ComponentLookup<DontDropLootCD> dontDropLootLookup, ref WorldInfoCD worldInfo, ref ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup, ref ComponentLookup<IsCloneCD> isCloneLookup, ref NetworkTick currentTick)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HatchWhenPlayerNearbyStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HealthCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__FactionCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__FactionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		hatch_state_Job value = new hatch_state_Job
		{
			time = time,
			players = players,
			ecb = ecb,
			databaseLocal = databaseLocal,
			isHatchingAnimID = isHatchingAnimID,
			hatchAnimID = hatchAnimID,
			hasHatchedAnimID = hasHatchedAnimID,
			rand = rand,
			dontDropLootLookup = dontDropLootLookup,
			worldInfo = worldInfo,
			animationBufferPointerLookup = animationBufferPointerLookup,
			isCloneLookup = isCloneLookup,
			currentTick = currentTick,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RW_ComponentTypeHandle,
			__hatchStateTypeHandle = __TypeHandle.__HatchWhenPlayerNearbyStateCD_RW_ComponentTypeHandle,
			__healthCDTypeHandle = __TypeHandle.__HealthCD_RW_ComponentTypeHandle,
			__animationBufferTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__factionTypeHandle = __TypeHandle.__FactionCD_RO_ComponentTypeHandle,
			__FactionCD_ComponentLookup = __TypeHandle.__FactionCD_RO_ComponentLookup,
			__Unity_Transforms_LocalTransform_ComponentLookup = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup
		};
		if (!__query_1622856135_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			hatch_state_Job.RunWithoutJobSystem(ref __query_1622856135_0, jobPtr);
		}
		value.DisposeOnCompletion();
		time = value.time;
		players = value.players;
		ecb = value.ecb;
		databaseLocal = value.databaseLocal;
		isHatchingAnimID = value.isHatchingAnimID;
		hatchAnimID = value.hatchAnimID;
		hasHatchedAnimID = value.hasHatchedAnimID;
		rand = value.rand;
		dontDropLootLookup = value.dontDropLootLookup;
		worldInfo = value.worldInfo;
		animationBufferPointerLookup = value.animationBufferPointerLookup;
		isCloneLookup = value.isCloneLookup;
		currentTick = value.currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<FactionCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HatchWhenPlayerNearbyStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<HealthCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		__query_1622856135_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1622856135_1 = entityQueryBuilder2.Build(ref state);
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
	public HatchWhenPlayerNearbyStateSystem()
	{
	}
}
