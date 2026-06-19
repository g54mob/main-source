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
using UnityEngine.Scripting;

[UpdateInGroup(typeof(StateUpdateGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public class FollowPheromoneStateSystem : PugSimulationSystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct FollowPheromoneStateSystem_3B385421_LambdaJob_0_Job : IJobChunk
	{
		public double elapsedTime;

		public float deltaTime;

		public int moveAnimID;

		[ReadOnly]
		public TileAccessor tileLookUp;

		public NativeArray<int2> dirToInt2;

		[ReadOnly]
		public CollisionWorld collisionWorld;

		public NetworkTick currentTick;

		public BufferLookup<AnimationBuffer> animationBufferLookup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<PhysicsVelocity> __velocityTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __orientationTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __stateInfoTypeHandle;

		public ComponentTypeHandle<FollowPheromoneStateCD> __phStateTypeHandle;

		public ComponentTypeHandle<PheromoneSensorCD> __phSensorTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MovementSpeedCD> __speedTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private unsafe void OriginalLambdaBody(Entity entity, [NoAlias] ref PhysicsVelocity velocity, [NoAlias] ref AnimationOrientationCD orientation, [NoAlias] ref StateInfoCD stateInfo, [NoAlias] ref FollowPheromoneStateCD phState, [NoAlias] ref PheromoneSensorCD phSensor, [NoAlias] in MovementSpeedCD speed, [NoAlias] in LocalTransform transform)
		{
			if (!stateInfo.IsCurrentState(StateID.FollowPheromone))
			{
				return;
			}
			DynamicBuffer<AnimationBuffer> dynamicBuffer = animationBufferLookup[entity];
			ref AnimationBufferPointer valueRW = ref animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = uint.MaxValue,
				CollidesWith = 131329u
			};
			int i;
			for (i = 0; i < 2; i++)
			{
				if (!phState.mask.HasType((PheromoneType)i) || phSensor.direction.dirs[i] == 0)
				{
					continue;
				}
				int2 int5 = transform.Position.RoundToInt2();
				int2 int6 = dirToInt2[phSensor.direction.dirs[i]];
				if (!tileLookUp.GetTopType(int5 + int6).IsWalkableTile() || collisionWorld.CheckSphere((int5 + int6).ToFloat3(), 0.49f, filter))
				{
					continue;
				}
				if (int6.x * int6.y != 0)
				{
					int2 int7 = int5 + new int2(int6.x, 0);
					int2 int8 = int5 + new int2(0, int6.y);
					if ((!tileLookUp.GetTopType(int7).IsWalkableTile() || collisionWorld.CheckSphere(int7.ToFloat3(), 0.3f, filter)) && (!tileLookUp.GetTopType(int8).IsWalkableTile() || collisionWorld.CheckSphere(int8.ToFloat3(), 0.3f, filter)))
					{
						continue;
					}
				}
				velocity.AddLinear2D(int6.ToFloat3() * speed.speed * deltaTime);
				orientation.SetFacingDirectionFromVector(int6.ToFloat2());
				break;
			}
			if (i == 2)
			{
				phSensor.reset = true;
				phState.cooldownTimer.Start(elapsedTime, 10f);
				stateInfo.LeaveState();
			}
			else if (dynamicBuffer.GetLastAddedElement(in valueRW).animID != moveAnimID)
			{
				AnimationUtilities.TriggerAnimation(moveAnimID, currentTick, dynamicBuffer, ref valueRW);
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __velocityTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __orientationTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __stateInfoTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __phStateTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __phSensorTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __speedTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr3, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FollowPheromoneStateCD>(nativeArrayPtr5, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSensorCD>(nativeArrayPtr6, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr3, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FollowPheromoneStateCD>(nativeArrayPtr5, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSensorCD>(nativeArrayPtr6, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr3, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FollowPheromoneStateCD>(nativeArrayPtr5, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSensorCD>(nativeArrayPtr6, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr3, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr4, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<FollowPheromoneStateCD>(nativeArrayPtr5, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PheromoneSensorCD>(nativeArrayPtr6, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr7, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, l));
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

		public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<FollowPheromoneStateCD> __FollowPheromoneStateCD_RW_ComponentTypeHandle;

		public ComponentTypeHandle<PheromoneSensorCD> __PheromoneSensorCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		public BufferLookup<AnimationBuffer> __AnimationBuffer_RW_BufferLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
			__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
			__StateInfoCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>();
			__FollowPheromoneStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<FollowPheromoneStateCD>();
			__PheromoneSensorCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PheromoneSensorCD>();
			__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__AnimationBuffer_RW_BufferLookup = state.GetBufferLookup<AnimationBuffer>();
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1591815839_0;

	private EntityQuery __query_1591815839_1;

	[Preserve]
	protected override void OnUpdate()
	{
		double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		int moveAnimID = -281135240;
		TileAccessor tileLookUp = CreateTileAccessor();
		NativeArray<int2> dirToInt = CollectionHelper.CreateNativeArray<int2>(9, base.World.UpdateAllocator.ToAllocator);
		for (int i = 0; i < dirToInt.Length; i++)
		{
			dirToInt[i] = ((Direction)(Direction.Id)i).i2;
		}
		CollisionWorld collisionWorld = GetPhysicsWorld().CollisionWorld;
		__query_1591815839_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		BufferLookup<AnimationBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__AnimationBuffer_RW_BufferLookup, ref base.CheckedStateRef);
		ComponentLookup<AnimationBufferPointer> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref base.CheckedStateRef);
		FollowPheromoneStateSystem_3B385421_LambdaJob_0_Execute(elapsedTime, deltaTime, moveAnimID, tileLookUp, dirToInt, collisionWorld, serverTick, bufferLookup, componentLookup);
		base.OnUpdate();
	}

	private void FollowPheromoneStateSystem_3B385421_LambdaJob_0_Execute(double elapsedTime, float deltaTime, int moveAnimID, TileAccessor tileLookUp, NativeArray<int2> dirToInt2, CollisionWorld collisionWorld, NetworkTick currentTick, BufferLookup<AnimationBuffer> animationBufferLookup, ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__FollowPheromoneStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PheromoneSensorCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		FollowPheromoneStateSystem_3B385421_LambdaJob_0_Job jobData = new FollowPheromoneStateSystem_3B385421_LambdaJob_0_Job
		{
			elapsedTime = elapsedTime,
			deltaTime = deltaTime,
			moveAnimID = moveAnimID,
			tileLookUp = tileLookUp,
			dirToInt2 = dirToInt2,
			collisionWorld = collisionWorld,
			currentTick = currentTick,
			animationBufferLookup = animationBufferLookup,
			animationBufferPointerLookup = animationBufferPointerLookup,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__velocityTypeHandle = __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle,
			__orientationTypeHandle = __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle,
			__stateInfoTypeHandle = __TypeHandle.__StateInfoCD_RW_ComponentTypeHandle,
			__phStateTypeHandle = __TypeHandle.__FollowPheromoneStateCD_RW_ComponentTypeHandle,
			__phSensorTypeHandle = __TypeHandle.__PheromoneSensorCD_RW_ComponentTypeHandle,
			__speedTypeHandle = __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1591815839_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<MovementSpeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<FollowPheromoneStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PheromoneSensorCD>();
		_queryRequiredForUpdate = (__query_1591815839_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1591815839_1 = entityQueryBuilder2.Build(ref state);
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
	public FollowPheromoneStateSystem()
	{
	}
}
