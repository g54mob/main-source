using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class RandomFollowStateSystem : SystemBase
{
	[NoAlias]
	[BurstCompile]
	private struct RandomFollowStateSystem_622A927B_LambdaJob_0_Job : IJobChunk
	{
		[ReadOnly]
		public NativeArray<int> __ChunkBaseEntityIndices;

		public double time;

		public float deltaTime;

		public uint seed;

		public int moveAnimID;

		public int idleAnimID;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformGroup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> nearbyEntitiesGroup;

		public ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup;

		[ReadOnly]
		public ComponentLookup<EntityDestroyedCD> entityDestroyedLookup;

		public NetworkTick currentTick;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public ComponentTypeHandle<PhysicsVelocity> __physVelocityTypeHandle;

		public ComponentTypeHandle<RandomFollowStateCD> __randomFollowStateTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __animTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __orientationTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MovementSpeedCD> __movementSpeedTypeHandle;

		[ReadOnly]
		public ComponentLookup<StateInfoCD> __StateInfoCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DetectCollisionCD> __DetectCollisionCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RandomWalkGravityCD> __RandomWalkGravityCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [NoAlias] ref PhysicsVelocity physVelocity, [NoAlias] ref RandomFollowStateCD randomFollowState, DynamicBuffer<AnimationBuffer> anim, [NoAlias] ref AnimationOrientationCD orientation, [NoAlias] in LocalTransform transform, [NoAlias] in MovementSpeedCD movementSpeed)
		{
			if (!__StateInfoCD_ComponentLookup[entity].IsCurrentState(StateID.RandomFollowing))
			{
				return;
			}
			ref AnimationBufferPointer valueRW = ref animationBufferPointerLookup.GetRefRW(entity).ValueRW;
			if (randomFollowState.replayAnimation)
			{
				if (randomFollowState.internalState == 1)
				{
					AnimationUtilities.TriggerAnimation(moveAnimID, currentTick, anim, ref valueRW);
				}
				else
				{
					AnimationUtilities.TriggerAnimation(idleAnimID, currentTick, anim, ref valueRW);
				}
				randomFollowState.replayAnimation = false;
			}
			Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(seed + (uint)entityInQueryIndex);
			DetectCollisionCD detectCollisionCD = __DetectCollisionCD_ComponentLookup[entity];
			bool flag = false;
			if (detectCollisionCD.hitEntity != Entity.Null && !randomFollowState.walkedIntoWallTimer.isRunning)
			{
				randomFollowState.walkedIntoWallTimer.Start(time, 0.1f);
			}
			else if (detectCollisionCD.hitEntity == Entity.Null)
			{
				randomFollowState.walkedIntoWallTimer.Stop();
			}
			if (randomFollowState.walkedIntoWallTimer.isRunning && randomFollowState.walkedIntoWallTimer.IsTimerElapsed(time))
			{
				flag = true;
				randomFollowState.walkedIntoWallTimer.Stop();
			}
			if (randomFollowState.internalState == 0 && (!randomFollowState.durationTimer.isRunning || randomFollowState.durationTimer.IsTimerElapsed(time)))
			{
				float2 float5 = random.NextFloat2Direction();
				if (__RandomWalkGravityCD_ComponentLookup.HasComponent(entity))
				{
					RandomWalkGravityCD randomWalkGravityCD = __RandomWalkGravityCD_ComponentLookup[entity];
					if (randomWalkGravityCD.isAffected && random.NextFloat() < randomWalkGravityCD.chanceToBeAffectedByGravityWell && randomWalkGravityCD.maxDistanceToBeAffected > math.distance(transform.Position, randomWalkGravityCD.position))
					{
						float5 = math.normalizesafe(randomWalkGravityCD.position - transform.Position).ToFloat2();
						if (randomWalkGravityCD.maxAngleDeviation != 0f)
						{
							float5 = math.mul(quaternion.RotateY(math.radians(random.NextFloat(0f - randomWalkGravityCD.maxAngleDeviation, randomWalkGravityCD.maxAngleDeviation))), float5.ToFloat3()).ToFloat2();
						}
						randomFollowState.currentGravityStrength = randomWalkGravityCD.strength;
					}
					else
					{
						randomFollowState.currentGravityStrength = 1f;
					}
				}
				else
				{
					randomFollowState.currentGravityStrength = 1f;
				}
				randomFollowState.internalState = 1;
				randomFollowState.durationTimer.Start(time, randomFollowState.maxWalkDuration);
				float2 float6 = float5 * random.NextFloat(randomFollowState.minDistanceFromObjectToFollow, randomFollowState.maxDistanceFromObjectToFollow);
				float3 float7 = new float3(float6.x, 0f, float6.y);
				Entity entity2 = Entity.Null;
				float3 position = localTransformGroup[entity].Position;
				if (nearbyEntitiesGroup.HasComponent(entity))
				{
					DynamicBuffer<NearbyEntitiesBufferCD> dynamicBuffer = nearbyEntitiesGroup[entity];
					for (int i = 0; i < dynamicBuffer.Length; i++)
					{
						if (__ObjectDataCD_ComponentLookup.HasComponent(dynamicBuffer[i].entity) && __ObjectDataCD_ComponentLookup[dynamicBuffer[i].entity].objectID == randomFollowState.objectToFollow && (!entityDestroyedLookup.HasComponent(dynamicBuffer[i].entity) || !entityDestroyedLookup.IsComponentEnabled(dynamicBuffer[i].entity)))
						{
							entity2 = dynamicBuffer[i].entity;
							position = localTransformGroup[entity2].Position;
							break;
						}
					}
				}
				randomFollowState.goal = ((entity2 != Entity.Null) ? (position + float7) : (transform.Position + float7));
				AnimationUtilities.TriggerAnimation(moveAnimID, currentTick, anim, ref valueRW);
			}
			else if (randomFollowState.internalState >= 1 && (!randomFollowState.durationTimer.isRunning || randomFollowState.durationTimer.IsTimerElapsed(time) || math.distancesq(transform.Position, randomFollowState.goal) < 0.5f || flag))
			{
				randomFollowState.internalState = 0;
				randomFollowState.durationTimer.Start(time, random.NextFloat(randomFollowState.minIdleDuration, randomFollowState.maxIdleDuration));
				AnimationUtilities.TriggerAnimation(idleAnimID, currentTick, anim, ref valueRW);
			}
			if (randomFollowState.internalState != 0 && randomFollowState.internalState == 1)
			{
				float num = movementSpeed.speed * randomFollowState.currentGravityStrength;
				float3 float8 = math.normalizesafe(randomFollowState.goal - transform.Position);
				physVelocity.AddLinear2D(float8 * num * deltaTime);
				orientation.SetFacingDirectionFromVector(float8 * math.sign(randomFollowState.currentGravityStrength));
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __physVelocityTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __randomFollowStateTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __animTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __orientationTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __movementSpeedTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					int entityInQueryIndex = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), entityInQueryIndex, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomFollowStateCD>(nativeArrayPtr3, i), bufferAccessor[i], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, i));
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
						int entityInQueryIndex2 = __ChunkBaseEntityIndices[batchIndex] + num++;
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), entityInQueryIndex2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomFollowStateCD>(nativeArrayPtr3, j), bufferAccessor[j], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, j));
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int k = 0; k < num3; k++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex3 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), entityInQueryIndex3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomFollowStateCD>(nativeArrayPtr3, k), bufferAccessor[k], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, k));
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num2 & 1) != 0L)
				{
					int entityInQueryIndex4 = __ChunkBaseEntityIndices[batchIndex] + num++;
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), entityInQueryIndex4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr2, l), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomFollowStateCD>(nativeArrayPtr3, l), bufferAccessor[l], ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr4, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr5, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr6, l));
				}
				num2 >>= 1;
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

		public ComponentTypeHandle<RandomFollowStateCD> __RandomFollowStateCD_RW_ComponentTypeHandle;

		public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

		public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<StateInfoCD> __StateInfoCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<DetectCollisionCD> __DetectCollisionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<RandomWalkGravityCD> __RandomWalkGravityCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<ObjectDataCD> __ObjectDataCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		[ReadOnly]
		public BufferLookup<NearbyEntitiesBufferCD> __NearbyEntitiesBufferCD_RO_BufferLookup;

		public ComponentLookup<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
			__RandomFollowStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomFollowStateCD>();
			__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
			__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
			__StateInfoCD_RO_ComponentLookup = state.GetComponentLookup<StateInfoCD>(isReadOnly: true);
			__DetectCollisionCD_RO_ComponentLookup = state.GetComponentLookup<DetectCollisionCD>(isReadOnly: true);
			__RandomWalkGravityCD_RO_ComponentLookup = state.GetComponentLookup<RandomWalkGravityCD>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentLookup = state.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__NearbyEntitiesBufferCD_RO_BufferLookup = state.GetBufferLookup<NearbyEntitiesBufferCD>(isReadOnly: true);
			__AnimationBufferPointer_RW_ComponentLookup = state.GetComponentLookup<AnimationBufferPointer>();
		}
	}

	private EntityQuery _query;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_799967127_0;

	private EntityQuery __query_799967127_1;

	[Preserve]
	protected override void OnCreate()
	{
		base.OnCreate();
		RequireForUpdate(_query);
	}

	[Preserve]
	protected override void OnUpdate()
	{
		double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
		float deltaTime = base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		uint seed = (uint)UnityEngine.Random.Range(1, 1073741823);
		int moveAnimID = -281135240;
		int idleAnimID = -601574123;
		ComponentLookup<LocalTransform> componentLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref base.CheckedStateRef);
		BufferLookup<NearbyEntitiesBufferCD> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__NearbyEntitiesBufferCD_RO_BufferLookup, ref base.CheckedStateRef);
		ComponentLookup<AnimationBufferPointer> componentLookup2 = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__AnimationBufferPointer_RW_ComponentLookup, ref base.CheckedStateRef);
		ComponentLookup<EntityDestroyedCD> componentLookup3 = GetComponentLookup<EntityDestroyedCD>(isReadOnly: true);
		__query_799967127_1.TryGetSingleton<NetworkTime>(out var value);
		NetworkTick serverTick = value.ServerTick;
		RandomFollowStateSystem_622A927B_LambdaJob_0_Execute(elapsedTime, deltaTime, seed, moveAnimID, idleAnimID, componentLookup, bufferLookup, componentLookup2, componentLookup3, serverTick);
	}

	private void RandomFollowStateSystem_622A927B_LambdaJob_0_Execute(double time, float deltaTime, uint seed, int moveAnimID, int idleAnimID, ComponentLookup<LocalTransform> localTransformGroup, BufferLookup<NearbyEntitiesBufferCD> nearbyEntitiesGroup, ComponentLookup<AnimationBufferPointer> animationBufferPointerLookup, ComponentLookup<EntityDestroyedCD> entityDestroyedLookup, NetworkTick currentTick)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RandomFollowStateCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__StateInfoCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__DetectCollisionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__RandomWalkGravityCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		RandomFollowStateSystem_622A927B_LambdaJob_0_Job jobData = new RandomFollowStateSystem_622A927B_LambdaJob_0_Job
		{
			time = time,
			deltaTime = deltaTime,
			seed = seed,
			moveAnimID = moveAnimID,
			idleAnimID = idleAnimID,
			localTransformGroup = localTransformGroup,
			nearbyEntitiesGroup = nearbyEntitiesGroup,
			animationBufferPointerLookup = animationBufferPointerLookup,
			entityDestroyedLookup = entityDestroyedLookup,
			currentTick = currentTick,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__physVelocityTypeHandle = __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle,
			__randomFollowStateTypeHandle = __TypeHandle.__RandomFollowStateCD_RW_ComponentTypeHandle,
			__animTypeHandle = __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle,
			__orientationTypeHandle = __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__movementSpeedTypeHandle = __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle,
			__StateInfoCD_ComponentLookup = __TypeHandle.__StateInfoCD_RO_ComponentLookup,
			__DetectCollisionCD_ComponentLookup = __TypeHandle.__DetectCollisionCD_RO_ComponentLookup,
			__RandomWalkGravityCD_ComponentLookup = __TypeHandle.__RandomWalkGravityCD_RO_ComponentLookup,
			__ObjectDataCD_ComponentLookup = __TypeHandle.__ObjectDataCD_RO_ComponentLookup
		};
		JobHandle outJobHandle;
		NativeArray<int> _ChunkBaseEntityIndices = __query_799967127_0.CalculateBaseEntityIndexArrayAsync(base.CheckedStateRef.WorldUpdateAllocator, base.Dependency, out outJobHandle);
		jobData.__ChunkBaseEntityIndices = _ChunkBaseEntityIndices;
		base.Dependency = outJobHandle;
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_799967127_0, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<StateInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomFollowStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
		_query = (__query_799967127_0 = entityQueryBuilder2.Build(ref state));
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_799967127_1 = entityQueryBuilder2.Build(ref state);
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
	public RandomFollowStateSystem()
	{
	}
}
