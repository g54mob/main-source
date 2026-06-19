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
using Unity.Physics;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class TeleportStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct TeleportStateSystem_133FECF8_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00004117_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00004117_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00004117_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
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

		public int startTeleportAnim;

		public int endTeleportAnim;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		[ReadOnly]
		public TileAccessor tileLookup;

		public Entity tileDamageBufferEntity;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public Unity.Mathematics.Random rng;

		public NetworkTick currentTick;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<TeleportStateCD> __teleportStateCDTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animCDTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __animationBufferPointerTypeHandle;

		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref TeleportStateCD teleportStateCD, DynamicBuffer<AnimationBuffer> animCD, [NoAlias] ref AnimationBufferPointer animationBufferPointer, [NoAlias] ref LocalTransform transform, [NoAlias] in ObjectDataCD objectData)
		{
			if (!stateInfo.IsCurrentState(StateID.Teleport))
			{
				teleportStateCD.internalState = 0;
			}
			else if (teleportStateCD.internalState == 0)
			{
				stateInfo.Lock();
				AnimationUtilities.TriggerAnimation(startTeleportAnim, currentTick, animCD, ref animationBufferPointer);
				teleportStateCD.internalState = 1;
				teleportStateCD.timer.Start(time, teleportStateCD.startTeleportDuration);
			}
			else if (teleportStateCD.internalState == 1 && teleportStateCD.timer.IsTimerElapsed(time))
			{
				AnimationUtilities.TriggerAnimation(endTeleportAnim, currentTick, animCD, ref animationBufferPointer);
				teleportStateCD.internalState = 2;
				teleportStateCD.timer.Start(time, teleportStateCD.endTeleportDuration);
				bool flag = true;
				ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseLocal);
				for (int i = 0; i < entityObjectInfo.prefabTileSize.x; i++)
				{
					for (int j = 0; j < entityObjectInfo.prefabTileSize.y; j++)
					{
						float3 float5 = teleportStateCD.targetDestination + new float3(i, 0f, j);
						bool num = tileLookup.HasTypeAndTileset(float5.RoundToInt2(), TileType.wall, 2);
						bool flag2 = teleportStateCD.canOnlyTeleportToNonBlockedGround && tileLookup.GetTopType(float5.RoundToInt2()).IsWalkableTile() && !PositionIsBlocked(collisionWorld, float5, 0.49f);
						bool flag3 = !teleportStateCD.canTeleportToPitAndWater && (tileLookup.HasType(float5.RoundToInt2(), TileType.water) || tileLookup.HasType(float5.RoundToInt2(), TileType.pit));
						flag = !num && !flag2 && !flag3;
						if (!flag)
						{
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
				if (flag)
				{
					transform.Position = teleportStateCD.targetDestination;
					int2 int5 = teleportStateCD.targetDestination.RoundToInt2() + teleportStateCD.updateTilesAtAreaMinCorner;
					int2 int6 = teleportStateCD.targetDestination.RoundToInt2() + teleportStateCD.updateTilesAtAreaMaxCorner;
					for (int k = int5.x; k <= int6.x; k++)
					{
						for (int l = int5.y; l <= int6.y; l++)
						{
							int2 position = new int2(k, l);
							ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
							{
								causedByEntity = entity,
								damage = 1000,
								position = position,
								skipWallAndRootsLootDropOnDestroy = true,
								dontHitBridges = true,
								canHitLowColliders = true
							});
						}
					}
				}
				teleportStateCD.cooldownTimer.Start(time, rng.NextFloat(teleportStateCD.minCooldown, teleportStateCD.maxCooldown));
			}
			else if (teleportStateCD.internalState == 2 && teleportStateCD.timer.IsTimerElapsed(time))
			{
				stateInfo.LeaveState();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __teleportStateCDTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animCDTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __animationBufferPointerTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TeleportStateCD>(nativeArrayPtr3, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TeleportStateCD>(nativeArrayPtr3, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TeleportStateCD>(nativeArrayPtr3, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TeleportStateCD>(nativeArrayPtr3, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr4, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr6, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00004117_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00004117_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<TeleportStateSystem_133FECF8_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<TeleportStateCD> __TeleportStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__TeleportStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<TeleportStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
			__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>();
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_787009461_0;

	private EntityQuery __query_787009461_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		NeedDatabase();
		NeedTileDamageBuffer();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double time = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		EntityCommandBuffer ecb = CreateCommandBuffer();
		int startTeleportAnim = -1518581387;
		int endTeleportAnim = -1065991089;
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		TileAccessor tileLookup = CreateTileAccessor();
		Entity tileDamageBufferEntity = tileDamageBufferSingletonEntity;
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		__query_787009461_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick currentTick = value.ServerTick;
		TeleportStateSystem_133FECF8_LambdaJob_0_Execute(ref time, ref ecb, ref startTeleportAnim, ref endTeleportAnim, ref collisionWorld, ref tileLookup, ref tileDamageBufferEntity, ref databaseLocal, ref rng, ref currentTick);
		base.OnUpdate();
	}

	public static bool PositionIsBlocked(CollisionWorld collisionWorld, float3 position, float radius)
	{
		return collisionWorld.SphereCast(position, radius, float3.zero, 0f, new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 131393u
		});
	}

	private void TeleportStateSystem_133FECF8_LambdaJob_0_Execute(ref double time, ref EntityCommandBuffer ecb, ref int startTeleportAnim, ref int endTeleportAnim, ref CollisionWorld collisionWorld, ref TileAccessor tileLookup, ref Entity tileDamageBufferEntity, ref BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, ref Unity.Mathematics.Random rng, ref NetworkTick currentTick)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__TeleportStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		TeleportStateSystem_133FECF8_LambdaJob_0_Job value = new TeleportStateSystem_133FECF8_LambdaJob_0_Job
		{
			time = time,
			ecb = ecb,
			startTeleportAnim = startTeleportAnim,
			endTeleportAnim = endTeleportAnim,
			collisionWorld = collisionWorld,
			tileLookup = tileLookup,
			tileDamageBufferEntity = tileDamageBufferEntity,
			databaseLocal = databaseLocal,
			rng = rng,
			currentTick = currentTick,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__teleportStateCDTypeHandle = __TypeHandle.__TeleportStateCD_RW_ComponentTypeHandle,
			__animCDTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__animationBufferPointerTypeHandle = __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle
		};
		if (!__query_787009461_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			TeleportStateSystem_133FECF8_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_787009461_0, jobPtr);
		}
		time = value.time;
		ecb = value.ecb;
		startTeleportAnim = value.startTeleportAnim;
		endTeleportAnim = value.endTeleportAnim;
		collisionWorld = value.collisionWorld;
		tileLookup = value.tileLookup;
		tileDamageBufferEntity = value.tileDamageBufferEntity;
		databaseLocal = value.databaseLocal;
		rng = value.rng;
		currentTick = value.currentTick;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<TeleportStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<LocalTransform>();
		_queryRequiredForUpdate = (__query_787009461_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_787009461_1 = entityQueryBuilder2.Build(ref state);
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
	public TeleportStateSystem()
	{
	}
}
