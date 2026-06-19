using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

namespace PlayerState
{
	public static class VehicleRiding
	{
		private const bool useVehicleInertia = true;

		private const float inertiaFactor = 0.05f;

		private const float BASE_INERTIA = 0.9f;

		private const float MIN_ACCELERATION = 0.1f;

		private const float MAX_ACCELERATION = 2f;

		private const float DEACCELERATION = 2f;

		private const float MAX_TURNING_SPEED = 210f;

		private const float MIN_TURNING_SPEED = 170f;

		public const float MAX_SPEED = 2f;

		public const float MIN_SPEED = -0.5f;

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref VehicleRidingStateCD valueRW = ref changePlayerStateAspect.vehicleRidingState.ValueRW;
			valueRW.previousVelocity = float3.zero;
			changePlayerStateAspect.hungerCD.ValueRW.canConsumeHunger = false;
			PlayerController.PlayAnimationTrigger(296203075, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			changePlayerStateLookup.directionLookup.TryGetComponent(changePlayerStateAspect.controllingOtherEntityCD.ValueRO.requestToBeControlledEntity, out var componentData);
			valueRW.drivingDirection = componentData.direction;
			valueRW.speed = 0f;
			changePlayerStateAspect.receivePushbackCD.ValueRW.ClearPushback();
			if (ControllingStateCommon.TryStartControllingControllableElseLeaveState(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateAspect.playerStateCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup, changePlayerStateLookup.vehicleLookup, changePlayerStateShared.isPartialTick))
			{
				changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position = changePlayerStateLookup.localTransformLookup.GetRefRO(changePlayerStateAspect.controllingOtherEntityCD.ValueRO.controlledEntity).ValueRO.Position;
				if (changePlayerStateShared.isFinalFullPredictionTick)
				{
					changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
				}
			}
			if (changePlayerStateLookup.simulateLookup.HasComponent(changePlayerStateAspect.controllingOtherEntityCD.ValueRO.controlledEntity))
			{
				valueRW.vehicleEntityLocal = changePlayerStateAspect.controllingOtherEntityCD.ValueRO.controlledEntity;
			}
		}

		public static void ResetState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			PlayerController.PlayAnimationTrigger(296203075, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			ControllingStateCommon.ReleaseControlledEntity(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup);
			changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position += new float3(0f, 0f, -0.4f);
			changePlayerStateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
			changePlayerStateAspect.hungerCD.ValueRW.canConsumeHunger = true;
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
			if (changePlayerStateShared.isFinalFullPredictionTick)
			{
				changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
			}
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref VehicleRidingStateCD valueRW = ref stateUpdateAspect.vehicleRidingState.ValueRW;
			Entity controlledEntity = stateUpdateAspect.controllingOtherEntityCD.ValueRO.controlledEntity;
			if (!lookupStateUpdateData.entityDestroyedLookup.HasComponent(controlledEntity) || lookupStateUpdateData.entityDestroyedLookup.IsComponentEnabled(controlledEntity))
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			if (stateUpdateAspect.interactorCD.ValueRW.TryConsumeInteract() && !stateUpdateAspect.effectiveVelocityCD.ValueRO.IsMoving)
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			stateUpdateAspect.controllingOtherEntityCD.ValueRW.requestToBeControlledEntity = controlledEntity;
			if (!ControllingStateCommon.TryStartControllingControllableElseLeaveState(stateUpdateAspect.entity, stateUpdateAspect.controllingOtherEntityCD, stateUpdateAspect.playerStateCD, lookupStateUpdateData.controlledByOtherEntityLookup, lookupStateUpdateData.simulateLookup, lookupStateUpdateData.vehicleLookup, sharedStateUpdateData.isPartialTick))
			{
				return;
			}
			VehicleCD vehicleCD = lookupStateUpdateData.vehicleLookup.GetRefRO(controlledEntity).ValueRO;
			UpdateVehicleMovement(in stateUpdateAspect.clientInput.ValueRO, ref valueRW, ref stateUpdateAspect.playerMovementCD.ValueRW, ref stateUpdateAspect.animationOrientationCD.ValueRW, in stateUpdateAspect.effectiveVelocityCD.ValueRO, in vehicleCD, sharedStateUpdateData.deltaTime);
			valueRW.vehicleEntityLocal = controlledEntity;
			float3 start = stateUpdateAspect.playerMovementCD.ValueRO.targetMovementVelocity.ToFloat3();
			bool flag = EntityUtility.GetConditionEffectValue(ConditionEffect.SlipperyMovement, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionEffectsLookup) > 0;
			float t = valueRW.vehicleDriftingAmountCurve.Evaluate(math.clamp(valueRW.speed / 2f, 0f, 1f));
			float end = 0.9f + math.clamp(0.05f * vehicleCD.driftingMultiplier, 0f, 0.1f);
			float t2 = math.pow(flag ? 0.985f : math.lerp(math.clamp(0.8f * vehicleCD.driftingMultiplier, 0f, 1f), end, t), 60f / (float)sharedStateUpdateData.tickRate);
			start = math.lerp(start, valueRW.previousVelocity, t2);
			if (math.length(start) < 0.2f && math.length(stateUpdateAspect.playerMovementCD.ValueRO.targetMovementVelocity) < 0.1f)
			{
				start = Vector3.zero;
			}
			float num = (float)EntityUtility.GetConditionValue(ConditionID.SlowedBySlime, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) / 1000f;
			float num2 = CalculateSpeedMultiplier(in valueRW, sharedStateUpdateData.currentTick);
			float3 float5 = stateUpdateAspect.playerMovementCD.ValueRO.anyVelocityAffectorForce.ToFloat3() * stateUpdateAspect.playerMovementCD.ValueRO.movementSpeed * num2;
			float3 value = start * (stateUpdateAspect.playerMovementCD.ValueRO.movementSpeed * num2) * (1f + num) + float5;
			stateUpdateAspect.playerMovementForceCD.ValueRW.Value = value;
			valueRW.previousVelocity = start;
			valueRW.prevPosition = lookupStateUpdateData.localTransformLookup.GetRefRO(stateUpdateAspect.entity).ValueRO.Position;
			if (stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.Honk_Pressed))
			{
				DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer = stateUpdateAspect.ghostEffectEventBuffer;
				ref GhostEffectEventBufferPointerCD valueRW2 = ref stateUpdateAspect.ghostEffectEventBufferPointerCD.ValueRW;
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = sharedStateUpdateData.currentTick,
					value = new EffectEventCD
					{
						effectID = EffectID.HonkSound,
						entity = stateUpdateAspect.entity,
						value1 = vehicleCD.honkSound.value
					}
				};
				ghostEffectEventBuffer.AddToRingBuffer(ref valueRW2, in item);
			}
			if (!valueRW.attackDestructiblesTimer.isRunning || valueRW.attackDestructiblesTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				if (math.length(stateUpdateAspect.effectiveVelocityCD.ValueRO.Value) > 1f)
				{
					stateUpdateAspect.dealDamageToEntityBuffer.Add(new DealDamageToEntityBuffer
					{
						attackType = DealDamageToEntityBuffer.AttackType.Vehicle
					});
				}
				valueRW.attackDestructiblesTimer.Start(sharedStateUpdateData.currentTick);
			}
		}

		private static float CalculateSpeedMultiplier(in VehicleRidingStateCD vehicleRidingState, NetworkTick currentTick)
		{
			if (!vehicleRidingState.reorientationDelay.isRunning || vehicleRidingState.reorientationDelay.IsTimerElapsed(currentTick))
			{
				return 1f;
			}
			float elapsedRatio = vehicleRidingState.reorientationDelay.GetElapsedRatio(currentTick);
			return elapsedRatio * elapsedRatio;
		}

		public static void UpdateVehicleMovement(in ClientInput clientInput, ref VehicleRidingStateCD vehicleRidingStateCD, ref PlayerMovementCD playerMovementCD, ref AnimationOrientationCD animationOrientationCD, in EffectiveVelocityCD effectiveVelocityCD, in VehicleCD vehicleCD, float deltaTime)
		{
			float2 movementDirection = clientInput.movementDirection;
			bool flag = true;
			if (vehicleRidingStateCD.speed > 1f && math.length(effectiveVelocityCD.Value) < 1f)
			{
				vehicleRidingStateCD.speed = 0f;
			}
			float t = math.clamp(vehicleRidingStateCD.speed / 2f, 0f, 1f);
			float num = math.lerp(2f, 0.1f, t) * vehicleCD.accelerationMultiplier;
			bool num2 = clientInput.IsButtonStateSet(CommandInputButtonStateNames.AccelerateVehicle_HeldDown);
			bool flag2 = clientInput.IsButtonStateSet(CommandInputButtonStateNames.ReverseVehicle_HeldDown);
			if (num2)
			{
				vehicleRidingStateCD.speed += deltaTime * num;
				flag = false;
			}
			if (flag2)
			{
				vehicleRidingStateCD.speed -= deltaTime * num * 4f;
				flag = false;
			}
			vehicleRidingStateCD.speed = math.clamp(vehicleRidingStateCD.speed, -0.5f, 2f);
			t = math.clamp(vehicleRidingStateCD.speed / 2f, 0f, 1f);
			if (flag)
			{
				if (vehicleRidingStateCD.speed > 0f)
				{
					vehicleRidingStateCD.speed -= deltaTime * 2f;
				}
				else if (vehicleRidingStateCD.speed < 0f)
				{
					vehicleRidingStateCD.speed += deltaTime * 2f;
				}
			}
			if (math.abs(vehicleRidingStateCD.speed) > 0.1f)
			{
				float num3 = math.lerp(210f, 170f, t);
				if (vehicleRidingStateCD.speed < 0f)
				{
					num3 = 0f - num3;
				}
				vehicleRidingStateCD.drivingDirection = Quaternion.AngleAxis(movementDirection.x * deltaTime * num3, Vector3.up) * vehicleRidingStateCD.drivingDirection;
			}
			playerMovementCD.targetMovementVelocity = (vehicleRidingStateCD.drivingDirection * (vehicleRidingStateCD.speed * vehicleCD.speedMultiplier)).ToFloat2();
			float3 drivingDirection = vehicleRidingStateCD.drivingDirection;
			Direction facingDirection = Direction.forward;
			if (drivingDirection.z <= 0.38f)
			{
				facingDirection = ((drivingDirection.x > 0.38f) ? Direction.right : ((!(drivingDirection.x < -0.38f)) ? Direction.back : Direction.left));
			}
			animationOrientationCD.facingDirection = facingDirection;
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			playerController.shadow.gameObject.SetActive(value: false);
			playerController.HideCarryable();
			if (playerController.isLocal)
			{
				playerController.SmoothSpeed = 12f;
			}
		}

		public static void ExitStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect, ChangePlayerStatePresentationLookups changePlayerStatePresentationLookups)
		{
			playerController.shadow.gameObject.SetActive(value: true);
			playerController.ShowCarryable();
			if (playerController.isLocal)
			{
				playerController.previousMouseScreenPosition = Vector3.zero;
				playerController.SmoothSpeed = 3.5f;
			}
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, StatePresentationUpdateLookups statePresentationUpdateLookups, PlayerController playerController)
		{
		}
	}
}
