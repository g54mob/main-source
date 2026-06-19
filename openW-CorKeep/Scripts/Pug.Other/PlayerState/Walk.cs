using Pug.Properties;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	public static class Walk
	{
		private const float PUSH_OUT_OF_ENEMIES_FORCE = 150f;

		public const float slideFactor = 0.98f;

		public const float slideFactorReferenceTickRate = 60f;

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			if (!changePlayerStateShared.isPartialTick)
			{
				PlayerController.PlayAnimationTrigger(1352515405, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
		}

		public static void ResetState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			PlayerController.PlayAnimationTrigger(1352515405, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect)
		{
			changePlayerStateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			RefRW<WalkStateCD> walkStateCD = stateUpdateAspect.walkStateCD;
			float3 float5 = stateUpdateAspect.playerMovementCD.ValueRO.adjustedMovementVelocity.ToFloat3();
			if (walkStateCD.ValueRO.previousDirection != stateUpdateAspect.animationOrientationCD.ValueRO.facingDirection)
			{
				if (math.length(walkStateCD.ValueRO.previousVelocity) <= float.Epsilon)
				{
					walkStateCD.ValueRW.reorientationDelay.Start(sharedStateUpdateData.currentTick);
				}
				walkStateCD.ValueRW.previousDirection = stateUpdateAspect.animationOrientationCD.ValueRO.facingDirection;
			}
			float3 float6 = float5;
			float6 += PlayerController.GetLeashForce(stateUpdateAspect.entity, in stateUpdateAspect.leashingCD.ValueRO, lookupStateUpdateData.localTransformLookup);
			if (lookupStateUpdateData.summarizedConditionEffectsLookup[stateUpdateAspect.entity][48].value > 0)
			{
				int value = lookupStateUpdateData.summarizedConditionsLookup[stateUpdateAspect.entity][137].value;
				float num = 1f - (float)value / 500f;
				float num2 = math.pow(0.98f, 60f / (float)sharedStateUpdateData.tickRate);
				float6 = math.lerp(float6, walkStateCD.ValueRO.previousVelocity, num2 * num);
				if (math.length(float5) < 0.05f && math.length(float6) < 0.05f)
				{
					float6 = float3.zero;
				}
			}
			stateUpdateAspect.walkStateCD.ValueRW.previousVelocity = float6;
			float reorientationProgressPercentage = (walkStateCD.ValueRO.reorientationDelay.isRunning ? walkStateCD.ValueRO.reorientationDelay.GetPercentageFinished(sharedStateUpdateData.currentTick) : 1f);
			float3 float7 = float6 * stateUpdateAspect.playerMovementCD.ValueRO.movementSpeed * CalculateSpeedMultiplier(reorientationProgressPercentage, in stateUpdateAspect, in sharedStateUpdateData, in lookupStateUpdateData);
			float7 -= GetPushOutOfEnemiesForce(lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity].Position, float7, in stateUpdateAspect.playerColliderCD.ValueRO, lookupStateUpdateData.enemyLookup, lookupStateUpdateData.enemyActAsDestructibleLookup, sharedStateUpdateData.currentTick, ref sharedStateUpdateData.physicsWorld, ref sharedStateUpdateData.physicsWorldHistory, in stateUpdateAspect.commandDataInterpolationDelay.ValueRO, in lookupStateUpdateData.objectPropertiesLookup);
			stateUpdateAspect.playerMovementForceCD.ValueRW.Value = float7;
		}

		public static void UpdateStateAfterPhysics(Entity entity, ref WalkStateCD walkStateCD, in PlayerMovementCD playerMovementCD, in SimulationTickStartPositionCD simulationTickStartPositionCD, in LocalTransform localTransform, EntityCommandBuffer ecb, bool isServer)
		{
			if (!(math.lengthsq(playerMovementCD.targetMovementVelocity) <= 0.01f))
			{
				float num = math.length(localTransform.Position.ToFloat2() - simulationTickStartPositionCD.Value);
				walkStateCD.accumulatedSkillMovement += num;
				if (walkStateCD.accumulatedSkillMovement > 1f)
				{
					walkStateCD.accumulatedSkillMovement -= 1f;
					PlayerController.AddSkill(entity, SkillID.Running, 1, ecb, isServer);
				}
			}
		}

		private static float CalculateSpeedMultiplier(float reorientationProgressPercentage, in StateUpdateAspect stateUpdateAspect, in SharedStateUpdateData sharedStateUpdateData, in LookupStateUpdateData lookupStateUpdateData)
		{
			float num = 1f;
			if (stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown) && !stateUpdateAspect.equippedObjectCD.ValueRO.isBroken && lookupStateUpdateData.moveFreelyWeaponLookup.TryGetComponent(stateUpdateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
			{
				num = componentData.moveSpeedMultiplier;
			}
			return 1f * num * reorientationProgressPercentage * reorientationProgressPercentage;
		}

		public static float3 GetPushOutOfEnemiesForce(float3 worldPosition, float3 moveDirection, in PlayerColliderCD playerColliderCD, ComponentLookup<EnemyCD> enemyLookup, ComponentLookup<EnemyActAsDestructibleCD> enemyActAsDestructibleLookup, NetworkTick tick, ref PhysicsWorld physicsWorld, ref PhysicsWorldHistorySingleton physicsWorldHistorySingleton, in CommandDataInterpolationDelay delay, in ComponentLookup<ObjectPropertiesCD> objectPropertiesLookup)
		{
			if (math.all(moveDirection == float3.zero))
			{
				return float3.zero;
			}
			float3 zero = float3.zero;
			float3 zero2 = float3.zero;
			NativeList<DistanceHit> outHits = new NativeList<DistanceHit>(Allocator.Temp);
			float3 float5 = new float3(playerColliderCD.capsuleHeight * 0.5f, 0f, 0f);
			float3 point = worldPosition + float5 + playerColliderCD.capsuleCenterOffset;
			float3 point2 = worldPosition - float5 + playerColliderCD.capsuleCenterOffset;
			CollisionFilter filter = new CollisionFilter
			{
				BelongsTo = 131349u,
				CollidesWith = 16u
			};
			tick.Decrement();
			physicsWorldHistorySingleton.GetCollisionWorldFromTick(tick, delay.Delay, ref physicsWorld, out var collWorld);
			if (collWorld.OverlapCapsule(point, point2, playerColliderCD.capsuleRadius, ref outHits, filter))
			{
				foreach (DistanceHit item in outHits)
				{
					EnemyCD componentData;
					bool num = enemyLookup.TryGetComponent(item.Entity, out componentData);
					bool flag = enemyActAsDestructibleLookup.HasComponent(item.Entity);
					if ((!num || (objectPropertiesLookup.TryGetComponent(item.Entity, out var componentData2) && componentData2.Has(1219741166))) && !flag)
					{
						continue;
					}
					float3 float6 = item.Position - worldPosition;
					if (Vector3.Angle(moveDirection, float6) < 90f)
					{
						float3 float7 = math.normalizesafe(new float3(float6.x, 0f, float6.z));
						zero += float7;
						if (flag)
						{
							zero2 += float7;
						}
					}
				}
			}
			outHits.Dispose();
			return math.normalizesafe(zero) * 150f + math.normalizesafe(zero2) * 150f;
		}

		public static void EnterStatePresentation(PlayerController playerController)
		{
			playerController.ResetAnimSROffset();
			playerController.ResetAnimSROffsetRot();
			if (playerController.isLocal)
			{
				playerController.SmoothSpeed = 3.5f;
			}
		}
	}
}
