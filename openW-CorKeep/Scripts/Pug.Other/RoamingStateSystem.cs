using System;
using System.Runtime.CompilerServices;
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
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class RoamingStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct RoamingStateSystem_131D17EE_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public double time;

		public float deltaTime;

		public NetworkTick currentTick;

		public int moveAnimID;

		public Entity tileUpdateBufferEntity;

		public Entity tileDamageBufferEntity;

		[ReadOnly]
		public TileAccessor tileLookup;

		public AttackSystem.Helper attackHelper;

		public Entity effectEventBufferSingleton;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<RoamingStateCD> __roamingStateTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MovementSpeedCD> __movementSpeedTypeHandle;

		public BufferTypeHandle<RoamingPathBuffer> __roamingPathTypeHandle;

		[ReadOnly]
		public ComponentLookup<StateInfoCD> __StateInfoCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] ref RoamingStateCD roamingState, [NoAlias] in MovementSpeedCD movementSpeed, DynamicBuffer<RoamingPathBuffer> roamingPath)
		{
			if (roamingPath.IsEmpty || !__StateInfoCD_ComponentLookup[entity].IsCurrentState(StateID.Roaming))
			{
				return;
			}
			DynamicBuffer<AnimationBuffer> animationBuffer = attackHelper.animationBufferLookup[entity];
			ref AnimationBufferPointer valueRW = ref attackHelper.animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			LocalTransform localTransform = attackHelper.localTransformLookup[entity];
			ref AnimationOrientationCD valueRW2 = ref attackHelper.animationOrientationLookup.GetRefRW(entity).ValueRW;
			switch (roamingState.internalState)
			{
			case RoamingStateCD.RoamingInternalState.Idle:
			{
				roamingState.internalState = RoamingStateCD.RoamingInternalState.BeginMoving;
				float num2 = float.MaxValue;
				for (int i = 0; i < roamingPath.Length; i++)
				{
					float num3 = math.length(roamingPath[i].Value - localTransform.Position);
					if (num3 < num2)
					{
						num2 = num3;
						roamingState.currentPathIndex = i;
					}
				}
				break;
			}
			case RoamingStateCD.RoamingInternalState.BeginMoving:
				AnimationUtilities.TriggerAnimation(moveAnimID, currentTick, animationBuffer, ref valueRW);
				roamingState.internalState = RoamingStateCD.RoamingInternalState.Moving;
				break;
			case RoamingStateCD.RoamingInternalState.Moving:
			{
				int currentPathIndex = roamingState.currentPathIndex;
				float3 x = roamingPath[currentPathIndex].Value - localTransform.Position;
				if (math.length(x) < 1f)
				{
					roamingState.currentPathIndex = NextPoint(roamingState.directionReversed, roamingState.currentPathIndex, roamingPath.Length);
					break;
				}
				float speed = movementSpeed.speed;
				float3 float5 = math.normalizesafe(x);
				PhysicsVelocity velocityData = attackHelper.GetVelocity(entity);
				velocityData.AddLinear2D(float5 * speed * deltaTime);
				ecb.SetComponent(entity, velocityData);
				valueRW2.SetFacingDirectionFromVector(float5);
				float3 float6 = float5 * roamingState.distanceInfrontToDamageTiles;
				RemoveTiles(entity, in ecb, in tileLookup, tileUpdateBufferEntity, tileDamageBufferEntity, localTransform.Position + float6, roamingState.tileDamageRadius);
				AttackSystem.Helper.Parameters p = new AttackSystem.Helper.Parameters
				{
					effectEventBufferSingleton = effectEventBufferSingleton,
					attacker = entity,
					isRanged = false,
					attackOffset = float6,
					canHitLowTriggers = false,
					radius = roamingState.tileDamageRadius,
					damage = 10000,
					bypassMaxDamagePerHit = true,
					cannotHitTriggersOrLowObjects = true,
					skipWallAndRootsLootDropOnDestroy = true,
					canOnlyAttackType = CanOnlyAttackType.Object,
					cantHitSpecificObjects = roamingState.cantHitSpecificObjects
				};
				attackHelper.Attack(ecb, in p);
				float num = math.length(velocityData.Linear);
				if (roamingState.reverseDirectionCooldownTimer.isRunning && !roamingState.reverseDirectionCooldownTimer.IsTimerElapsed(time))
				{
					break;
				}
				roamingState.reverseDirectionCooldownTimer.Stop();
				if (num < 0.8f)
				{
					if (!roamingState.reverseDirectionTimer.isRunning)
					{
						roamingState.reverseDirectionTimer.Start(time, 0.5f);
					}
					else if (roamingState.reverseDirectionTimer.isRunning && roamingState.reverseDirectionTimer.IsTimerElapsed(time))
					{
						roamingState.directionReversed = !roamingState.directionReversed;
						roamingState.currentPathIndex = NextPoint(roamingState.directionReversed, roamingState.currentPathIndex, roamingPath.Length);
						roamingState.reverseDirectionTimer.Stop();
						roamingState.reverseDirectionCooldownTimer.Start(time, 2f);
					}
				}
				else if (roamingState.reverseDirectionTimer.isRunning)
				{
					roamingState.reverseDirectionTimer.Stop();
				}
				break;
			}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __roamingStateTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __movementSpeedTypeHandle);
			BufferAccessor<RoamingPathBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __roamingPathTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, i), bufferAccessor[i]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, j), bufferAccessor[j]);
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, k), bufferAccessor[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RoamingStateCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr3, l), bufferAccessor[l]);
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		public ComponentTypeHandle<RoamingStateCD> __RoamingStateCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public BufferTypeHandle<RoamingPathBuffer> __RoamingPathBuffer_RO_BufferTypeHandle;

		[ReadOnly]
		public ComponentLookup<StateInfoCD> __StateInfoCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__RoamingStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RoamingStateCD>();
			__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
			__RoamingPathBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<RoamingPathBuffer>(isReadOnly: true);
			__StateInfoCD_RO_ComponentLookup = state.GetComponentLookup<StateInfoCD>(isReadOnly: true);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_906114043_0;

	private EntityQuery __query_906114043_1;

	private EntityQuery __query_906114043_2;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<EffectEventBuffer>();
		NeedTileUpdateBuffer();
		NeedTileDamageBuffer();
		RequireForUpdate<WorldInfoCD>();
		base.OnCreate();
	}

	[BurstDiscard]
	private static void PrintDebug(DynamicBuffer<RoamingPathBuffer> roamingPath)
	{
		for (int i = 0; i < roamingPath.Length; i++)
		{
			float3 float5 = EntityMonoBehaviour.ToRenderFromWorld(roamingPath[i].Value);
			Debug.DrawLine(float5, float5 + new float3(0f, 5f, 0f), Color.red, 0.1f);
		}
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		__query_906114043_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		int moveAnimID = -281135240;
		Entity tileUpdateBufferEntity = tileUpdateBufferSingletonEntity;
		Entity tileDamageBufferEntity = tileDamageBufferSingletonEntity;
		TileAccessor tileLookup = CreateTileAccessor();
		AttackSystem.Helper helper = GetAttackHelper();
		PugRandom.GetRng();
		Entity singletonEntity = __query_906114043_2.GetSingletonEntity();
		RoamingStateSystem_131D17EE_LambdaJob_0_Execute(ecb, elapsedTime, deltaTime, serverTick, moveAnimID, tileUpdateBufferEntity, tileDamageBufferEntity, tileLookup, helper, singletonEntity);
		base.OnUpdate();
	}

	private static int NextPoint(bool directionReversed, int currentPathIndex, int roamingPathLength)
	{
		if (directionReversed)
		{
			if (currentPathIndex != 0)
			{
				return currentPathIndex - 1;
			}
			return roamingPathLength - 1;
		}
		return (currentPathIndex + 1) % roamingPathLength;
	}

	private static void RemoveTiles(Entity entity, in EntityCommandBuffer ecb, in TileAccessor tileLookup, Entity tileUpdateBufferEntity, Entity tileDamageBufferEntity, float3 pos, float radius)
	{
		for (float num = 0f - radius; num <= radius; num += radius)
		{
			for (float num2 = 0f - radius; num2 <= radius; num2 += radius)
			{
				float2 float5 = new float2(num, num2);
				int2 int5 = (pos.ToFloat2() + float5).RoundToInt2();
				if (!tileLookup.HasType(int5, TileType.immune))
				{
					RemoveTile(entity, in ecb, in tileLookup, tileUpdateBufferEntity, tileDamageBufferEntity, int5);
				}
			}
		}
	}

	private static void RemoveTile(Entity entity, in EntityCommandBuffer ecb, in TileAccessor tileLookup, Entity tileUpdateBufferEntity, Entity tileDamageBufferEntity, int2 tilePos)
	{
		TileCD top = tileLookup.GetTop(tilePos);
		if ((top.tileType == TileType.wall && top.tileset == 55) || (top.tileType == TileType.bigRoot && top.tileset == 55))
		{
			ecb.AppendToBuffer(tileDamageBufferEntity, new TileDamageBuffer
			{
				causedByEntity = entity,
				damage = 10000,
				position = tilePos,
				skipWallAndRootsLootDropOnDestroy = true,
				dontHitBridges = true,
				canHitLowColliders = true,
				dontHitWalkableTiles = true
			});
		}
	}

	private void RoamingStateSystem_131D17EE_LambdaJob_0_Execute(EntityCommandBuffer ecb, double time, float deltaTime, NetworkTick currentTick, int moveAnimID, Entity tileUpdateBufferEntity, Entity tileDamageBufferEntity, TileAccessor tileLookup, AttackSystem.Helper attackHelper, Entity effectEventBufferSingleton)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RoamingStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RoamingPathBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		RoamingStateSystem_131D17EE_LambdaJob_0_Job jobData = new RoamingStateSystem_131D17EE_LambdaJob_0_Job
		{
			ecb = ecb,
			time = time,
			deltaTime = deltaTime,
			currentTick = currentTick,
			moveAnimID = moveAnimID,
			tileUpdateBufferEntity = tileUpdateBufferEntity,
			tileDamageBufferEntity = tileDamageBufferEntity,
			tileLookup = tileLookup,
			attackHelper = attackHelper,
			effectEventBufferSingleton = effectEventBufferSingleton,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__roamingStateTypeHandle = __TypeHandle.__RoamingStateCD_RW_ComponentTypeHandle,
			__movementSpeedTypeHandle = __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle,
			__roamingPathTypeHandle = __TypeHandle.__RoamingPathBuffer_RO_BufferTypeHandle,
			__StateInfoCD_ComponentLookup = __TypeHandle.__StateInfoCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_906114043_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MovementSpeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<RoamingPathBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationOrientationCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RoamingStateCD>();
		_queryRequiredForUpdate = (__query_906114043_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_906114043_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_906114043_2 = entityQueryBuilder2.Build(ref state);
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
	public RoamingStateSystem()
	{
	}
}
