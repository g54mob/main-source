using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
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

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public struct RandomWalkStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct RandomWalkJob : IJobEntity, IJobChunk
	{
		public struct DirectionOption
		{
			public float2 direction;

			public float length;
		}

		public struct InternalCompilerQueryAndHandleData
		{
			public struct TypeHandle
			{
				[ReadOnly]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<StateInfoCD> __StateInfoCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<PhysicsVelocity> __Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RandomWalkStateCD> __RandomWalkStateCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<RandomWalkStatePatternCD> __RandomWalkStatePatternCD_RO_ComponentTypeHandle;

				public BufferTypeHandle<AnimationBuffer> __AnimationBuffer_RW_BufferTypeHandle;

				public ComponentTypeHandle<AnimationOrientationCD> __AnimationOrientationCD_RW_ComponentTypeHandle;

				public ComponentTypeHandle<RandomCD> __RandomCD_RW_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<MovementSpeedCD> __MovementSpeedCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<ObjectPropertiesCD> __Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle;

				[ReadOnly]
				public ComponentTypeHandle<DetectCollisionCD> __DetectCollisionCD_RO_ComponentTypeHandle;

				public ComponentTypeHandle<AnimationBufferPointer> __AnimationBufferPointer_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void __AssignHandles(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
					__StateInfoCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<StateInfoCD>(isReadOnly: true);
					__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle = state.GetComponentTypeHandle<PhysicsVelocity>();
					__RandomWalkStateCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomWalkStateCD>();
					__RandomWalkStatePatternCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RandomWalkStatePatternCD>(isReadOnly: true);
					__AnimationBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<AnimationBuffer>();
					__AnimationOrientationCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationOrientationCD>();
					__RandomCD_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RandomCD>();
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
					__MovementSpeedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<MovementSpeedCD>(isReadOnly: true);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectPropertiesCD>(isReadOnly: true);
					__DetectCollisionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DetectCollisionCD>(isReadOnly: true);
					__AnimationBufferPointer_RW_ComponentTypeHandle = state.GetComponentTypeHandle<AnimationBufferPointer>();
				}

				public void Update(ref SystemState state)
				{
					__Unity_Entities_Entity_TypeHandle.Update(ref state);
					__StateInfoCD_RO_ComponentTypeHandle.Update(ref state);
					__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle.Update(ref state);
					__RandomWalkStateCD_RW_ComponentTypeHandle.Update(ref state);
					__RandomWalkStatePatternCD_RO_ComponentTypeHandle.Update(ref state);
					__AnimationBuffer_RW_BufferTypeHandle.Update(ref state);
					__AnimationOrientationCD_RW_ComponentTypeHandle.Update(ref state);
					__RandomCD_RW_ComponentTypeHandle.Update(ref state);
					__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref state);
					__MovementSpeedCD_RO_ComponentTypeHandle.Update(ref state);
					__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle.Update(ref state);
					__DetectCollisionCD_RO_ComponentTypeHandle.Update(ref state);
					__AnimationBufferPointer_RW_ComponentTypeHandle.Update(ref state);
				}
			}

			public TypeHandle __TypeHandle;

			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<StateInfoCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<RandomWalkStatePatternCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<MovementSpeedCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectPropertiesCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAll<DetectCollisionCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<PhysicsVelocity>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomWalkStateCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBuffer>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationOrientationCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<RandomCD>();
				entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<AnimationBufferPointer>();
				DefaultQuery = entityQueryBuilder2.Build(ref state);
				entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					__AssignQueries(ref state);
				}
				__TypeHandle.__AssignHandles(ref state);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Run(ref RandomWalkJob job, EntityQuery query)
			{
				job.__TypeHandle = __TypeHandle;
				JobChunkExtensions.RunByRef(ref job, query);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle Schedule(ref RandomWalkJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle ScheduleParallel(ref RandomWalkJob job, EntityQuery query, JobHandle dependency)
			{
				job.__TypeHandle = __TypeHandle;
				return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void UpdateBaseEntityIndexArray(ref RandomWalkJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public JobHandle UpdateBaseEntityIndexArray(ref RandomWalkJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void AssignEntityManager(ref RandomWalkJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		public ComponentLookup<RandomWalkGravityCD> randomWalkGravityLookup;

		[ReadOnly]
		public TileAccessor tileAccessor;

		public NativeList<DirectionOption> cachedDirectionOptions;

		public NetworkTick currentTick;

		public double time;

		public float deltaTime;

		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		private void Execute(Entity entity, in StateInfoCD stateInfoCD, ref PhysicsVelocity physVelocity, ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationOrientationCD orientation, ref RandomCD randomCD, in LocalTransform transform, in MovementSpeedCD movementSpeed, in ObjectPropertiesCD properties, in DetectCollisionCD detectCollision, ref AnimationBufferPointer animationBufferPointer)
		{
			if (stateInfoCD.IsCurrentState(StateID.RandomWalking))
			{
				bool isNewStateTrigger = randomWalkState.isNewStateTrigger;
				if (randomWalkState.isNewStateTrigger)
				{
					AnimationUtilities.TriggerAnimation((randomWalkState.internalState == RandomWalkStateCD.State.Walking) ? (-281135240) : (-601574123), currentTick, animationBuffer, ref animationBufferPointer);
					randomWalkState.isNewStateTrigger = false;
				}
				bool walkedIntoWall = CheckWalkedIntoWall(ref randomWalkState, in detectCollision);
				ref Unity.Mathematics.Random value = ref randomCD.Value;
				if (HasFinishedIdling(ref randomWalkState))
				{
					SetWalkState(entity, ref randomWalkState, ref value, in properties, in transform, ref animationBuffer, ref animationBufferPointer, in randomWalkStatePatternCD, isNewStateTrigger);
				}
				else if (HasFinishedWalking(ref randomWalkState, in transform, in randomWalkStatePatternCD, walkedIntoWall))
				{
					SetIdleState(ref randomWalkState, ref value, in properties, ref animationBuffer, ref animationBufferPointer, in randomWalkStatePatternCD);
				}
				if (randomWalkState.internalState == RandomWalkStateCD.State.Walking)
				{
					MoveByWalking(in randomWalkState, in movementSpeed, ref physVelocity, in transform, ref orientation, in randomWalkStatePatternCD);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool CheckWalkedIntoWall(ref RandomWalkStateCD randomWalkState, in DetectCollisionCD detectCollision)
		{
			bool result = false;
			if (detectCollision.hitEntity != Entity.Null && !randomWalkState.walkedIntoWallTimer.isRunning)
			{
				randomWalkState.walkedIntoWallTimer.Start(time, 0.1f);
			}
			else if (detectCollision.hitEntity == Entity.Null)
			{
				randomWalkState.walkedIntoWallTimer.Stop();
			}
			if (randomWalkState.walkedIntoWallTimer.isRunning && randomWalkState.walkedIntoWallTimer.IsTimerElapsed(time))
			{
				result = true;
				randomWalkState.walkedIntoWallTimer.Stop();
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ShouldBeAffectedByGravityWell(Entity entity, ref Unity.Mathematics.Random rand, in LocalTransform transform, out RandomWalkGravityCD gravity)
		{
			if (randomWalkGravityLookup.TryGetComponent(entity, out gravity) && gravity.isAffected && rand.NextFloat() < gravity.chanceToBeAffectedByGravityWell)
			{
				return gravity.maxDistanceToBeAffected > math.distance(transform.Position, gravity.position);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasFinishedIdling(ref RandomWalkStateCD randomWalkState)
		{
			if (randomWalkState.internalState == RandomWalkStateCD.State.Idle)
			{
				if (randomWalkState.durationTimer.isRunning)
				{
					return randomWalkState.durationTimer.IsTimerElapsed(time);
				}
				return true;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasFinishedWalking(ref RandomWalkStateCD randomWalkState, in LocalTransform transform, in RandomWalkStatePatternCD randomWalkStatePatternCD, bool walkedIntoWall)
		{
			if (randomWalkState.internalState == RandomWalkStateCD.State.Idle)
			{
				return false;
			}
			if (!HasActivePattern(in randomWalkState))
			{
				return true;
			}
			ref RandomWalkStatePatterData reference = ref randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex].patterns[randomWalkState.patternIndex];
			WalkStateCancelConditionType cancelConditionType = reference.cancelConditionType;
			if ((cancelConditionType & WalkStateCancelConditionType.Time) != WalkStateCancelConditionType.None && (!randomWalkState.durationTimer.isRunning || randomWalkState.durationTimer.IsTimerElapsed(time)))
			{
				return true;
			}
			if ((cancelConditionType & WalkStateCancelConditionType.WalkedIntoWall) != 0 && walkedIntoWall)
			{
				return true;
			}
			if ((cancelConditionType & WalkStateCancelConditionType.ReachedGoal) != WalkStateCancelConditionType.None && math.distancesq(transform.Position.xz, randomWalkState.target) < reference.goalCheckDistanceSqr)
			{
				return true;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetWalkState(Entity entity, ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in ObjectPropertiesCD properties, in LocalTransform transform, ref DynamicBuffer<AnimationBuffer> animationBuffer, ref AnimationBufferPointer animationBufferPointer, in RandomWalkStatePatternCD randomWalkStatePatternCD, bool triggerNewPatternGroup)
		{
			UpdateWalkPattern(ref randomWalkState, in randomWalkStatePatternCD, ref rand, triggerNewPatternGroup);
			UpdateMoveDataForCurrentPattern(entity, ref randomWalkState, ref rand, in properties, in transform, in randomWalkStatePatternCD);
			SetupInitialMovementPatternValues(ref randomWalkState, ref rand, in randomWalkStatePatternCD);
			randomWalkState.internalState = RandomWalkStateCD.State.Walking;
			AnimationUtilities.TriggerAnimation(-281135240, currentTick, animationBuffer, ref animationBufferPointer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateWalkPattern(ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD, ref Unity.Mathematics.Random rand, bool triggerNewPatternGroup)
		{
			if (HasActivePattern(in randomWalkState))
			{
				ProgressActivePattern(ref randomWalkState, in randomWalkStatePatternCD, ref rand, ref triggerNewPatternGroup);
			}
			if (triggerNewPatternGroup || randomWalkState.patternGroupIndex == -1)
			{
				SelectNewGroup(ref randomWalkState, in randomWalkStatePatternCD, ref rand);
			}
			if (randomWalkState.patternIndex == -1)
			{
				SelectNewPatternFromGroup(ref randomWalkState, in randomWalkStatePatternCD, ref rand);
			}
		}

		private void ProgressActivePattern(ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD, ref Unity.Mathematics.Random rand, ref bool triggerNewPatternGroup)
		{
			randomWalkState.patternProgress++;
			if (HasFinishedPattern(ref randomWalkState, in randomWalkStatePatternCD))
			{
				if (HasFinishedGroup(ref randomWalkState, in randomWalkStatePatternCD))
				{
					triggerNewPatternGroup = true;
				}
				else
				{
					SelectNewPatternFromGroup(ref randomWalkState, in randomWalkStatePatternCD, ref rand);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasActivePattern(in RandomWalkStateCD randomWalkState)
		{
			if (randomWalkState.patternGroupIndex != -1)
			{
				return randomWalkState.patternIndex != -1;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SelectNewGroup(ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD, ref Unity.Mathematics.Random rand)
		{
			ref RandomWalkStatePatternBlobData value = ref randomWalkStatePatternCD.Value.Value;
			randomWalkState.patternGroupIndex = (sbyte)UpdateIndexBySelectionType(randomWalkState.patternGroupIndex, value.groupSelectionType, value.totalGroupWeights, ref value.groupRandomWeights, ref rand);
			randomWalkState.patternIndex = -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SelectNewPatternFromGroup(ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD, ref Unity.Mathematics.Random rand)
		{
			ref RandomWalkStatePatternGroupData reference = ref randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex];
			randomWalkState.patternIndex = (sbyte)UpdateIndexBySelectionType(randomWalkState.patternIndex, reference.patternSelectionType, reference.totalPatternWeights, ref reference.patternRandomWeights, ref rand);
			randomWalkState.patternProgress = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasFinishedPattern(ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			return randomWalkState.patternProgress >= randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex].patterns[randomWalkState.patternIndex].patternSteps;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool HasFinishedGroup(ref RandomWalkStateCD randomWalkState, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			ref RandomWalkStatePatternGroupData reference = ref randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex];
			if (reference.patternSelectionType == WalkStateSelectionType.SequentialSingle)
			{
				return randomWalkState.patternIndex >= reference.patterns.Length - 1;
			}
			return false;
		}

		private int UpdateIndexBySelectionType(int previousIndex, WalkStateSelectionType walkStateSelectionType, float indicesTotalWeights, ref BlobArray<float> indexRandomWeights, ref Unity.Mathematics.Random rand)
		{
			return walkStateSelectionType switch
			{
				WalkStateSelectionType.SequentialLoop => (previousIndex + 1) % indexRandomWeights.Length, 
				WalkStateSelectionType.SequentialSingle => (previousIndex + 1) % indexRandomWeights.Length, 
				WalkStateSelectionType.Random => GetWeightedRandomIndex(indicesTotalWeights, ref indexRandomWeights, ref rand), 
				WalkStateSelectionType.RandomOnInitialization => (previousIndex == -1) ? GetWeightedRandomIndex(indicesTotalWeights, ref indexRandomWeights, ref rand) : previousIndex, 
				_ => 0, 
			};
		}

		private int GetWeightedRandomIndex(float totalWeight, ref BlobArray<float> randomWeightsForIndices, ref Unity.Mathematics.Random rand)
		{
			if (totalWeight <= 0f)
			{
				return 0;
			}
			float num = rand.NextFloat(0f, totalWeight);
			float num2 = 0f;
			for (int i = 0; i < randomWeightsForIndices.Length; i++)
			{
				num2 += randomWeightsForIndices[i];
				if (num <= num2)
				{
					return i;
				}
			}
			return randomWeightsForIndices.Length - 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UpdateMoveDataForCurrentPattern(Entity entity, ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in ObjectPropertiesCD properties, in LocalTransform localTransform, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			ref RandomWalkStatePatterData reference = ref randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex].patterns[randomWalkState.patternIndex];
			float2 target;
			float movementSpeedMultiplier;
			float maxWalkDuration;
			switch (reference.goalPatternType)
			{
			case WalkStateGoalPatternType.Default:
				GetDefaultTargetAndSpeedMultiplier(entity, ref randomWalkState, ref rand, in properties, in localTransform, out target, out movementSpeedMultiplier, out maxWalkDuration);
				break;
			case WalkStateGoalPatternType.CardinalRandom:
				GetCardinalRandomGoal(ref reference, ref randomWalkState, ref rand, in localTransform, out target, out movementSpeedMultiplier, out maxWalkDuration);
				break;
			case WalkStateGoalPatternType.CardinalMoveInSquare:
				GetCardinalMoveInSquareGoal(ref reference, ref randomWalkState, ref rand, in localTransform, out target, out movementSpeedMultiplier, out maxWalkDuration);
				break;
			case WalkStateGoalPatternType.CardinalMoveInSingleLine:
				GetCardinalMoveInSingleLineGoal(ref reference, ref randomWalkState, ref rand, in localTransform, out target, out movementSpeedMultiplier, out maxWalkDuration);
				break;
			default:
				throw new ArgumentOutOfRangeException("goalPatternType", reference.goalPatternType, null);
			}
			randomWalkState.movementSpeedMultiplier = movementSpeedMultiplier;
			randomWalkState.durationTimer.Start(time, maxWalkDuration);
			randomWalkState.target = target;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void GetDefaultTargetAndSpeedMultiplier(Entity entity, ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in ObjectPropertiesCD properties, in LocalTransform transform, out float2 target, out float movementSpeedMultiplier, out float maxWalkDuration)
		{
			float2 float5;
			if (ShouldBeAffectedByGravityWell(entity, ref rand, in transform, out var gravity))
			{
				float5 = math.normalizesafe(gravity.position - transform.Position).ToFloat2();
				if (gravity.maxAngleDeviation != 0f)
				{
					float5 = math.mul(quaternion.RotateY(math.radians(rand.NextFloat(0f - gravity.maxAngleDeviation, gravity.maxAngleDeviation))), float5.ToFloat3()).ToFloat2();
				}
				movementSpeedMultiplier = gravity.strength;
			}
			else
			{
				float5 = rand.NextFloat2Direction();
				movementSpeedMultiplier = (properties.TryGet<float>(369041197, out var value) ? value : 1f);
			}
			float2 float6 = float5 * rand.NextFloat(properties.Get<float>(-1694698514), properties.Get<float>(-1119382305));
			target = transform.Position.xz + float6;
			maxWalkDuration = properties.Get<float>(663391902);
		}

		private void GetCardinalRandomGoal(ref RandomWalkStatePatterData pattern, ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in LocalTransform localTransform, out float2 target, out float movementSpeedMultiplier, out float maxWalkDuration)
		{
			float checkDistance = rand.NextFloat(pattern.minMaxWalkDistance.x, pattern.minMaxWalkDistance.y);
			float2 xz = localTransform.Position.xz;
			float offsetToColliderDistance = rand.NextFloat(pattern.movementPatternGoalFloatValue, pattern.movementPatternGoalFloatValue2);
			cachedDirectionOptions.Clear();
			for (int i = 0; i < Direction.allFourClockwise.Length; i++)
			{
				cachedDirectionOptions.Add(new DirectionOption
				{
					direction = Direction.allFourClockwise[i].f2
				});
			}
			switch ((PatternRandomSelectionType)pattern.movementPatternGoalIntValue)
			{
			case PatternRandomSelectionType.RandomWeightedByDistance:
				target = GetTargetByWeightedDistance(ref pattern, ref rand, xz, checkDistance, offsetToColliderDistance, cachedDirectionOptions);
				break;
			case PatternRandomSelectionType.LongestDistance:
				target = GetTargetByLongestDistance(ref pattern, ref rand, xz, checkDistance, offsetToColliderDistance, cachedDirectionOptions);
				break;
			case PatternRandomSelectionType.ShortestDistance:
				target = GetTargetByShortestDistance(ref pattern, ref rand, xz, checkDistance, offsetToColliderDistance, cachedDirectionOptions);
				break;
			default:
				target = GetTargetByRandomUniform(ref pattern, ref rand, xz, checkDistance, offsetToColliderDistance, cachedDirectionOptions);
				break;
			}
			movementSpeedMultiplier = pattern.movementSpeedMultiplier;
			maxWalkDuration = pattern.maxWalkDuration;
		}

		private float2 GetTargetByWeightedDistance(ref RandomWalkStatePatterData pattern, ref Unity.Mathematics.Random rand, float2 origin, float checkDistance, float offsetToColliderDistance, NativeList<DirectionOption> directionOptions)
		{
			float totalLength = 0f;
			UpdateTargetLengthsByCollisionInDirection(ref pattern, origin, checkDistance, directionOptions, offsetToColliderDistance, ref totalLength);
			if (totalLength == 0f)
			{
				return origin;
			}
			float num = rand.NextFloat(0f, totalLength);
			totalLength = 0f;
			int index = 0;
			for (int i = 0; i < Direction.allFourClockwise.Length; i++)
			{
				totalLength += cachedDirectionOptions[i].length;
				if (num <= totalLength)
				{
					index = i;
					break;
				}
			}
			return origin + cachedDirectionOptions[index].direction * cachedDirectionOptions[index].length;
		}

		private void UpdateTargetLengthsByCollisionInDirection(ref RandomWalkStatePatterData pattern, float2 origin, float checkDistance, NativeList<DirectionOption> directionOptions, float offsetToColliderDistance, ref float totalLength)
		{
			for (int i = 0; i < directionOptions.Length; i++)
			{
				DirectionOption directionOption = directionOptions[i];
				float num = checkDistance;
				if (SinglePugMap.RaycastNonWalkableTiles(origin, directionOption.direction, checkDistance, out var hitInfo, tileAccessor))
				{
					num = math.max(hitInfo.distance - offsetToColliderDistance, 0f);
				}
				cachedDirectionOptions[i] = new DirectionOption
				{
					direction = directionOption.direction,
					length = num
				};
				totalLength += num;
			}
		}

		private float2 GetTargetByLongestDistance(ref RandomWalkStatePatterData pattern, ref Unity.Mathematics.Random rand, float2 origin, float checkDistance, float offsetToColliderDistance, NativeList<DirectionOption> directionOptions)
		{
			float totalLength = 0f;
			UpdateTargetLengthsByCollisionInDirection(ref pattern, origin, checkDistance, directionOptions, offsetToColliderDistance, ref totalLength);
			float num = 0f;
			float2 float5 = float2.zero;
			for (int i = 0; i < Direction.allFourClockwise.Length; i++)
			{
				float length = cachedDirectionOptions[i].length;
				if (length > num)
				{
					float5 = cachedDirectionOptions[i].direction;
					num = length;
				}
			}
			return origin + float5 * num;
		}

		private float2 GetTargetByShortestDistance(ref RandomWalkStatePatterData pattern, ref Unity.Mathematics.Random rand, float2 origin, float checkDistance, float offsetToColliderDistance, NativeList<DirectionOption> directionOptions)
		{
			float totalLength = 0f;
			UpdateTargetLengthsByCollisionInDirection(ref pattern, origin, checkDistance, directionOptions, offsetToColliderDistance, ref totalLength);
			float num = float.MaxValue;
			float2 float5 = float2.zero;
			for (int i = 0; i < Direction.allFourClockwise.Length; i++)
			{
				float length = cachedDirectionOptions[i].length;
				if (length < num)
				{
					float5 = cachedDirectionOptions[i].direction;
					num = length;
				}
			}
			return origin + float5 * num;
		}

		private float2 GetTargetByRandomUniform(ref RandomWalkStatePatterData pattern, ref Unity.Mathematics.Random rand, float2 origin, float checkDistance, float offsetToColliderDistance, NativeList<DirectionOption> directionOptions)
		{
			return GetTargetByCollisionInDirection(ref pattern, origin, checkDistance, directionOptions[rand.NextInt(directionOptions.Length)].direction, offsetToColliderDistance);
		}

		private float2 GetTargetByCollisionInDirection(ref RandomWalkStatePatterData pattern, float2 origin, float checkDistance, float2 direction, float offsetToColliderDistance)
		{
			float num = checkDistance;
			if (offsetToColliderDistance > 0f && SinglePugMap.RaycastNonWalkableTiles(origin, direction, checkDistance, out var hitInfo, tileAccessor))
			{
				num = math.max(hitInfo.distance - offsetToColliderDistance, 0f);
			}
			return origin + direction * num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void GetCardinalMoveInSquareGoal(ref RandomWalkStatePatterData pattern, ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in LocalTransform localTransform, out float2 target, out float movementSpeedMultiplier, out float maxWalkDuration)
		{
			if (randomWalkState.patternProgress == 0)
			{
				randomWalkState.patternGoalByteValue = (byte)rand.NextInt(Direction.allFourClockwise.Length);
				randomWalkState.patternGoalByteValue <<= 4;
				randomWalkState.patternGoalByteValue |= (byte)rand.NextInt(2);
			}
			int num = randomWalkState.patternGoalByteValue >> 4;
			int num2 = (((randomWalkState.patternGoalByteValue & 0xF) == 0) ? 1 : (-1));
			int num3 = Direction.allFourClockwise.Length;
			int num4 = pattern.patternSteps / num3 + 1;
			int num5 = (num + num2 * randomWalkState.patternProgress + num3 * num4) % num3;
			float2 f = Direction.allFourClockwise[num5].f2;
			movementSpeedMultiplier = pattern.movementSpeedMultiplier;
			maxWalkDuration = pattern.maxWalkDuration;
			float2 xz = localTransform.Position.xz;
			float offsetToColliderDistance = rand.NextFloat(pattern.movementPatternGoalFloatValue, pattern.movementPatternGoalFloatValue2);
			bool flag = IsStartOrEndModifiedStep(ref pattern, in randomWalkState);
			float checkDistance = rand.NextFloat(pattern.minMaxWalkDistance.x, pattern.minMaxWalkDistance.y) * (flag ? pattern.GetModifiedWalkDistanceMultiplier() : 1f);
			target = GetTargetByCollisionInDirection(ref pattern, xz, checkDistance, f, offsetToColliderDistance);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void GetCardinalMoveInSingleLineGoal(ref RandomWalkStatePatterData pattern, ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in LocalTransform localTransform, out float2 target, out float movementSpeedMultiplier, out float maxWalkDuration)
		{
			if (randomWalkState.patternProgress == 0)
			{
				randomWalkState.patternGoalByteValue = (byte)rand.NextInt(Direction.allFourClockwise.Length);
			}
			float2 f = Direction.allFourClockwise[randomWalkState.patternGoalByteValue].f2;
			f *= (float)((randomWalkState.patternProgress % 2 == 0) ? 1 : (-1));
			movementSpeedMultiplier = pattern.movementSpeedMultiplier;
			maxWalkDuration = pattern.maxWalkDuration;
			float2 xz = localTransform.Position.xz;
			float offsetToColliderDistance = rand.NextFloat(pattern.movementPatternGoalFloatValue, pattern.movementPatternGoalFloatValue2);
			bool flag = IsStartOrEndModifiedStep(ref pattern, in randomWalkState);
			float checkDistance = rand.NextFloat(pattern.minMaxWalkDistance.x, pattern.minMaxWalkDistance.y) * (flag ? pattern.GetModifiedWalkDistanceMultiplier() : 1f);
			target = GetTargetByCollisionInDirection(ref pattern, xz, checkDistance, f, offsetToColliderDistance);
		}

		private bool IsStartOrEndModifiedStep(ref RandomWalkStatePatterData pattern, in RandomWalkStateCD randomWalkState)
		{
			if (!((float)(int)randomWalkState.patternProgress < pattern.GetModifiedStartingSteps()))
			{
				return (float)(pattern.patternSteps - randomWalkState.patternProgress) <= pattern.GetModifiedEndingSteps();
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetupInitialMovementPatternValues(ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			WalkStateMovementPatternType movementPatternType = randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex].patterns[randomWalkState.patternIndex].movementPatternType;
			if ((uint)(movementPatternType - 1) <= 1u)
			{
				randomWalkState.patternMovementByteValue = (byte)rand.NextInt(2);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetIdleState(ref RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in ObjectPropertiesCD properties, ref DynamicBuffer<AnimationBuffer> anim, ref AnimationBufferPointer animationBufferPointer, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			float newLifespan = ((!HasActivePattern(in randomWalkState)) ? GetDefaultIdleTime(ref rand, in properties) : GetIdleTimeFromPattern(in randomWalkState, ref rand, in randomWalkStatePatternCD));
			randomWalkState.internalState = RandomWalkStateCD.State.Idle;
			randomWalkState.durationTimer.Start(time, newLifespan);
			AnimationUtilities.TriggerAnimation(-601574123, currentTick, anim, ref animationBufferPointer);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float GetIdleTimeFromPattern(in RandomWalkStateCD randomWalkState, ref Unity.Mathematics.Random rand, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			ref RandomWalkStatePatterData reference = ref randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex].patterns[randomWalkState.patternIndex];
			float2 minMaxIdleDurationAfterWalking = reference.minMaxIdleDurationAfterWalking;
			float num = 1f;
			WalkStateGoalPatternType goalPatternType = reference.goalPatternType;
			if (goalPatternType == WalkStateGoalPatternType.CardinalMoveInSquare || goalPatternType == WalkStateGoalPatternType.CardinalMoveInSingleLine)
			{
				num = (IsStartOrEndModifiedStep(ref reference, in randomWalkState) ? reference.GetModifiedIdleDurationAfterWalkingMultiplier() : 1f);
			}
			return rand.NextFloat(minMaxIdleDurationAfterWalking.x, minMaxIdleDurationAfterWalking.y) * num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float GetDefaultIdleTime(ref Unity.Mathematics.Random rand, in ObjectPropertiesCD properties)
		{
			return rand.NextFloat(properties.Get<float>(1552785565), properties.Get<float>(2067187628));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void MoveByWalking(in RandomWalkStateCD randomWalkState, in MovementSpeedCD movementSpeed, ref PhysicsVelocity physVelocity, in LocalTransform transform, ref AnimationOrientationCD orientation, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			float num = movementSpeed.speed * randomWalkState.movementSpeedMultiplier;
			float2 movementDirection = GetMovementDirection(in randomWalkState, in transform, in randomWalkStatePatternCD);
			physVelocity.AddLinear2D(movementDirection.ToFloat3() * num * deltaTime);
			orientation.SetFacingDirectionFromVector(movementDirection * math.sign(randomWalkState.movementSpeedMultiplier));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float2 GetMovementDirection(in RandomWalkStateCD randomWalkState, in LocalTransform transform, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			if (HasActivePattern(in randomWalkState))
			{
				return GetMovementDirectionFromPattern(in randomWalkState, in transform, in randomWalkStatePatternCD);
			}
			return DefaultDirection(in randomWalkState, in transform);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float2 GetMovementDirectionFromPattern(in RandomWalkStateCD randomWalkState, in LocalTransform transform, in RandomWalkStatePatternCD randomWalkStatePatternCD)
		{
			ref RandomWalkStatePatterData reference = ref randomWalkStatePatternCD.Value.Value.groups[randomWalkState.patternGroupIndex].patterns[randomWalkState.patternIndex];
			return reference.movementPatternType switch
			{
				WalkStateMovementPatternType.SinusoidalAngle => SinusoidalAngleDirection(in randomWalkState, in transform, ref reference), 
				WalkStateMovementPatternType.SinusoidalFlatAngle => SinusoidalFlatAngleDirection(in randomWalkState, in transform, ref reference), 
				_ => DefaultDirection(in randomWalkState, in transform), 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float2 SinusoidalAngleDirection(in RandomWalkStateCD randomWalkState, in LocalTransform transform, ref RandomWalkStatePatterData pattern)
		{
			float elapsedTime = randomWalkState.durationTimer.GetElapsedTime(time);
			float movementPatternFloatValue = pattern.movementPatternFloatValue;
			float movementPatternFloatValue2 = pattern.movementPatternFloatValue2;
			float angle = (float)((randomWalkState.patternMovementByteValue == 0) ? 1 : (-1)) * GetSinusoidalTurnAngle(elapsedTime, movementPatternFloatValue, movementPatternFloatValue2);
			return math.normalizesafe(math.mul(v: DefaultDirection(in randomWalkState, in transform).ToFloat3(), q: quaternion.RotateY(angle)).ToFloat2());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float2 SinusoidalFlatAngleDirection(in RandomWalkStateCD randomWalkState, in LocalTransform transform, ref RandomWalkStatePatterData pattern)
		{
			float elapsedTime = randomWalkState.durationTimer.GetElapsedTime(time);
			float movementPatternFloatValue = pattern.movementPatternFloatValue;
			float movementPatternFloatValue2 = pattern.movementPatternFloatValue2;
			float angle = (float)((randomWalkState.patternMovementByteValue == 0) ? 1 : (-1)) * math.round(GetSinusoidalTurnAngle(elapsedTime, movementPatternFloatValue, movementPatternFloatValue2));
			return math.normalizesafe(math.mul(v: DefaultDirection(in randomWalkState, in transform).ToFloat3(), q: quaternion.RotateY(angle)).ToFloat2());
		}

		private float GetSinusoidalTurnAngle(float walkTime, float maxTurnAngle, float repeatTimeSeconds)
		{
			return maxTurnAngle * math.sin(repeatTimeSeconds * walkTime * (MathF.PI * 2f) + MathF.PI / 2f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float2 HalfCircleDirection()
		{
			throw new NotImplementedException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private float2 DefaultDirection(in RandomWalkStateCD randomWalkState, in LocalTransform transform)
		{
			return math.normalizesafe(randomWalkState.target - transform.Position.xz);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __TypeHandle.__Unity_Entities_Entity_TypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__StateInfoCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__Unity_Physics_PhysicsVelocity_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr4 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomWalkStateCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr5 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__RandomWalkStatePatternCD_RO_ComponentTypeHandle);
			BufferAccessor<AnimationBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __TypeHandle.__AnimationBuffer_RW_BufferTypeHandle);
			IntPtr nativeArrayPtr6 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationOrientationCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr7 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__RandomCD_RW_ComponentTypeHandle);
			IntPtr nativeArrayPtr8 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr9 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__MovementSpeedCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr10 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__Pug_Properties_ObjectPropertiesCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr11 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __TypeHandle.__DetectCollisionCD_RO_ComponentTypeHandle);
			IntPtr nativeArrayPtr12 = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtr(chunk, ref __TypeHandle.__AnimationBufferPointer_RW_ComponentTypeHandle);
			int count = chunk.Count;
			int num = 0;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i);
					ref StateInfoCD stateInfoCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, i);
					ref PhysicsVelocity physVelocity = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, i);
					ref RandomWalkStateCD randomWalkState = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStateCD>(nativeArrayPtr4, i);
					ref RandomWalkStatePatternCD randomWalkStatePatternCD = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStatePatternCD>(nativeArrayPtr5, i);
					DynamicBuffer<AnimationBuffer> animationBuffer = bufferAccessor[i];
					Execute(entity, in stateInfoCD, ref physVelocity, ref randomWalkState, in randomWalkStatePatternCD, ref animationBuffer, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr9, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr10, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectCollisionCD>(nativeArrayPtr11, i), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr12, i));
					num++;
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int nextRangeBegin = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
				{
					while (nextRangeBegin < nextRangeEnd)
					{
						Entity entity2 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, nextRangeBegin);
						ref StateInfoCD stateInfoCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, nextRangeBegin);
						ref PhysicsVelocity physVelocity2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, nextRangeBegin);
						ref RandomWalkStateCD randomWalkState2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStateCD>(nativeArrayPtr4, nextRangeBegin);
						ref RandomWalkStatePatternCD randomWalkStatePatternCD2 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStatePatternCD>(nativeArrayPtr5, nextRangeBegin);
						DynamicBuffer<AnimationBuffer> animationBuffer2 = bufferAccessor[nextRangeBegin];
						Execute(entity2, in stateInfoCD2, ref physVelocity2, ref randomWalkState2, in randomWalkStatePatternCD2, ref animationBuffer2, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr9, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr10, nextRangeBegin), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectCollisionCD>(nativeArrayPtr11, nextRangeBegin), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr12, nextRangeBegin));
						nextRangeBegin++;
						num++;
					}
				}
				return;
			}
			ulong num2 = chunkEnabledMask.ULong0;
			int num3 = math.min(64, count);
			for (int j = 0; j < num3; j++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity3 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j);
					ref StateInfoCD stateInfoCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, j);
					ref PhysicsVelocity physVelocity3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, j);
					ref RandomWalkStateCD randomWalkState3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStateCD>(nativeArrayPtr4, j);
					ref RandomWalkStatePatternCD randomWalkStatePatternCD3 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStatePatternCD>(nativeArrayPtr5, j);
					DynamicBuffer<AnimationBuffer> animationBuffer3 = bufferAccessor[j];
					Execute(entity3, in stateInfoCD3, ref physVelocity3, ref randomWalkState3, in randomWalkStatePatternCD3, ref animationBuffer3, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr9, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr10, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectCollisionCD>(nativeArrayPtr11, j), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr12, j));
					num++;
				}
				num2 >>= 1;
			}
			num2 = chunkEnabledMask.ULong1;
			for (int k = 64; k < count; k++)
			{
				if ((num2 & 1) != 0L)
				{
					Entity entity4 = InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k);
					ref StateInfoCD stateInfoCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<StateInfoCD>(nativeArrayPtr2, k);
					ref PhysicsVelocity physVelocity4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PhysicsVelocity>(nativeArrayPtr3, k);
					ref RandomWalkStateCD randomWalkState4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStateCD>(nativeArrayPtr4, k);
					ref RandomWalkStatePatternCD randomWalkStatePatternCD4 = ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomWalkStatePatternCD>(nativeArrayPtr5, k);
					DynamicBuffer<AnimationBuffer> animationBuffer4 = bufferAccessor[k];
					Execute(entity4, in stateInfoCD4, ref physVelocity4, ref randomWalkState4, in randomWalkStatePatternCD4, ref animationBuffer4, ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationOrientationCD>(nativeArrayPtr6, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RandomCD>(nativeArrayPtr7, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr8, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<MovementSpeedCD>(nativeArrayPtr9, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectPropertiesCD>(nativeArrayPtr10, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<DetectCollisionCD>(nativeArrayPtr11, k), ref InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AnimationBufferPointer>(nativeArrayPtr12, k));
					num++;
				}
				num2 >>= 1;
			}
		}

		private JobHandle __ThrowCodeGenException()
		{
			throw new Exception("This method should have been replaced by source gen.");
		}

		public void Run()
		{
			__ThrowCodeGenException();
		}

		public void RunByRef()
		{
			__ThrowCodeGenException();
		}

		public void Run(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void RunByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public void Schedule()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef()
		{
			__ThrowCodeGenException();
		}

		public void Schedule(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		public void ScheduleParallel()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef()
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallel(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		public void ScheduleParallelByRef(EntityQuery query)
		{
			__ThrowCodeGenException();
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<RandomWalkGravityCD> __RandomWalkGravityCD_RO_ComponentLookup;

		public RandomWalkJob.InternalCompilerQueryAndHandleData __RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__RandomWalkGravityCD_RO_ComponentLookup = state.GetComponentLookup<RandomWalkGravityCD>(isReadOnly: true);
			__RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00000007_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000007_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000007_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	private TileAccessor _tileAccessor;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1359501413_0;

	public void OnStartRunning(ref SystemState state)
	{
		_tileAccessor = new TileAccessor(ref state);
	}

	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		_tileAccessor.Update(ref state);
		__query_1359501413_0.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = __ScheduleViaJobChunkExtension_0(new RandomWalkJob
		{
			randomWalkGravityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__RandomWalkGravityCD_RO_ComponentLookup, ref state),
			tileAccessor = _tileAccessor,
			cachedDirectionOptions = new NativeList<RandomWalkJob.DirectionOption>(16, state.WorldUpdateAllocator),
			currentTick = value.ServerTick,
			time = state.WorldUnmanaged.Time.ElapsedTime,
			deltaTime = state.WorldUnmanaged.Time.DeltaTime
		}, __TypeHandle.__RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private JobHandle __ScheduleViaJobChunkExtension_0(RandomWalkJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
	{
		dependency = __TypeHandle.__RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
		__TypeHandle.__RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
		__TypeHandle.__RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
		return __TypeHandle.__RandomWalkStateSystem_RandomWalkJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1359501413_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000007_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((RandomWalkStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		((RandomWalkStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((RandomWalkStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((RandomWalkStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
