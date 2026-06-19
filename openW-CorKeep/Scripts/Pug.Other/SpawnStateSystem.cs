using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugTilemap;
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
public class SpawnStateSystem : SystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct SpawnStateSystem_21D22886_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00003F02_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00003F02_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00003F02_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public ComponentLookup<AnimationOrientationCD> animationOrientationLookUp;

		public EntityCommandBuffer ecb;

		public double time;

		public NetworkTick currentTick;

		public Entity updatedTilesSingleton;

		public TileAccessor tileAccessor;

		public PugDatabase.DatabaseBankCD databaseBankCD;

		public ComponentLookup<IndestructibleCD> indestructibleLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<SpawnStateCD> __spawnStateTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animCDTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentLookup<HasRunSpawnStateCD> __HasRunSpawnStateCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref SpawnStateCD spawnState, DynamicBuffer<AnimationBuffer> animCD, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] in LocalTransform transform)
		{
			if (!stateInfo.IsCurrentState(StateID.Spawn))
			{
				return;
			}
			if (spawnState.internalState == 0)
			{
				AnimationUtilities.TriggerAnimation(spawnState.animId, currentTick, animCD, ref animationBufferPointer);
				spawnState.internalState = 1;
				spawnState.timer.Start(time, spawnState.duration);
				if (math.lengthsq(spawnState.facingDirection) > 0f && animationOrientationLookUp.HasComponent(entity))
				{
					animationOrientationLookUp.GetRefRW(entity).ValueRW.SetFacingDirectionFromVector(spawnState.facingDirection);
				}
				if (spawnState.removeTilesOnSpawn)
				{
					RemoveTiles(in spawnState, in transform, ref ecb, updatedTilesSingleton, in tileAccessor, in databaseBankCD, in indestructibleLookup);
				}
			}
			else if (spawnState.internalState == 1 && spawnState.timer.IsTimerElapsed(time))
			{
				if (!__HasRunSpawnStateCD_ComponentLookup.HasComponent(entity))
				{
					ecb.AddComponent<HasRunSpawnStateCD>(entity);
				}
				stateInfo.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __spawnStateTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animCDTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnStateCD>(nativeArrayPtr3, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnStateCD>(nativeArrayPtr3, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnStateCD>(nativeArrayPtr3, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<SpawnStateCD>(nativeArrayPtr3, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00003F02_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00003F02_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<SpawnStateSystem_21D22886_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<SpawnStateCD> __SpawnStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<HasRunSpawnStateCD> __HasRunSpawnStateCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__SpawnStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<SpawnStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__HasRunSpawnStateCD_RO_ComponentLookup = state.GetComponentLookup<HasRunSpawnStateCD>(isReadOnly: true);
		}
	}

	private BeginSimulationEntityCommandBufferSystem _ecbSystem;

	private EntityQuery _query;

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1401896983_0;

	private EntityQuery __query_1401896983_1;

	private EntityQuery __query_1401896983_2;

	private EntityQuery __query_1401896983_3;

	[Preserve]
	protected override void OnCreate()
	{
		_ecbSystem = base.World.GetOrCreateSystemManaged<BeginSimulationEntityCommandBufferSystem>();
		RequireForUpdate(_query);
		RequireForUpdate<TileUpdateBuffer>();
		RequireForUpdate<PugDatabase.DatabaseBankCD>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		_tileAccessor = new TileAccessor(ref base.CheckedStateRef);
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		__query_1401896983_1.TryGetSingleton<NetworkTime>(out var value);
		ComponentLookup<AnimationOrientationCD> animationOrientationLookUp = GetComponentLookup<AnimationOrientationCD>();
		EntityCommandBuffer ecb = _ecbSystem.CreateCommandBuffer();
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		NetworkTick currentTick = value.ServerTick;
		Entity updatedTilesSingleton = __query_1401896983_2.GetSingletonEntity();
		_tileAccessor.Update(ref base.CheckedStateRef);
		TileAccessor tileAccessor = _tileAccessor;
		PugDatabase.DatabaseBankCD databaseBankCD = __query_1401896983_3.GetSingleton<PugDatabase.DatabaseBankCD>();
		ComponentLookup<IndestructibleCD> indestructibleLookup = GetComponentLookup<IndestructibleCD>(isReadOnly: true);
		SpawnStateSystem_21D22886_LambdaJob_0_Execute(ref animationOrientationLookUp, ref ecb, ref time, ref currentTick, ref updatedTilesSingleton, ref tileAccessor, ref databaseBankCD, ref indestructibleLookup);
		_ecbSystem.AddJobHandleForProducer(base.Dependency);
	}

	private static void RemoveTiles(in SpawnStateCD spawnState, in LocalTransform transform, ref EntityCommandBuffer ecb, Entity updatedTilesSingleton, in TileAccessor tileAccessor, in PugDatabase.DatabaseBankCD databaseBankCD, in ComponentLookup<IndestructibleCD> indestructibleLookup)
	{
		float2 float5 = transform.Position.xz + spawnState.removeTilesOnSpawnOffset;
		int num = (int)math.round(spawnState.radiusSqToRemoveTilesWithin);
		for (int i = -num; i <= num; i++)
		{
			for (int j = -num; j <= num; j++)
			{
				int2 int5 = (new int2(i, j) + float5).RoundToInt2();
				if (!tileAccessor.HasType(int5, TileType.immune) && !IsTileIndestructible(int5, in tileAccessor, in databaseBankCD, in indestructibleLookup))
				{
					ecb.AppendToBuffer(updatedTilesSingleton, new TileUpdateBuffer
					{
						command = TileUpdateBuffer.Command.Remove,
						position = int5,
						tile = new TileCD
						{
							tileType = TileType.wall
						}
					});
				}
			}
		}
	}

	private static bool IsTileIndestructible(int2 tilePos, in TileAccessor tileAccessor, in PugDatabase.DatabaseBankCD databaseBankCD, in ComponentLookup<IndestructibleCD> indestructibleLookup)
	{
		TileCD topDamageableTile = tileAccessor.GetTopDamageableTile(tilePos);
		if (topDamageableTile.tileType == TileType.none)
		{
			return false;
		}
		ObjectDataCD objectData = PugDatabase.GetObjectData(topDamageableTile.tileset, topDamageableTile.tileType, databaseBankCD.databaseBankBlob);
		if (objectData.objectID == ObjectID.None)
		{
			return false;
		}
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectData.objectID, databaseBankCD.databaseBankBlob, objectData.variation);
		if (primaryPrefabEntity != Entity.Null)
		{
			return indestructibleLookup.HasAndIsComponentEnabled(primaryPrefabEntity);
		}
		return false;
	}

	private void SpawnStateSystem_21D22886_LambdaJob_0_Execute(ref ComponentLookup<AnimationOrientationCD> animationOrientationLookUp, ref EntityCommandBuffer ecb, ref double time, ref NetworkTick currentTick, ref Entity updatedTilesSingleton, ref TileAccessor tileAccessor, ref PugDatabase.DatabaseBankCD databaseBankCD, ref ComponentLookup<IndestructibleCD> indestructibleLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__SpawnStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__HasRunSpawnStateCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		SpawnStateSystem_21D22886_LambdaJob_0_Job value = new SpawnStateSystem_21D22886_LambdaJob_0_Job
		{
			animationOrientationLookUp = animationOrientationLookUp,
			ecb = ecb,
			time = time,
			currentTick = currentTick,
			updatedTilesSingleton = updatedTilesSingleton,
			tileAccessor = tileAccessor,
			databaseBankCD = databaseBankCD,
			indestructibleLookup = indestructibleLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__spawnStateTypeHandle = __TypeHandle.__SpawnStateCD_RW_ComponentTypeHandle,
			__animCDTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__HasRunSpawnStateCD_ComponentLookup = __TypeHandle.__HasRunSpawnStateCD_RO_ComponentLookup
		};
		if (!__query_1401896983_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			SpawnStateSystem_21D22886_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1401896983_0, jobPtr);
		}
		animationOrientationLookUp = value.animationOrientationLookUp;
		ecb = value.ecb;
		time = value.time;
		currentTick = value.currentTick;
		updatedTilesSingleton = value.updatedTilesSingleton;
		tileAccessor = value.tileAccessor;
		databaseBankCD = value.databaseBankCD;
		indestructibleLookup = value.indestructibleLookup;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<SpawnStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		_query = (__query_1401896983_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1401896983_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1401896983_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1401896983_3 = entityQueryBuilder2.Build(ref state);
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
	public SpawnStateSystem()
	{
	}
}
