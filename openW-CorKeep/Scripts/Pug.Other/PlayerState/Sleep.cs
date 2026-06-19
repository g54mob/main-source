#define PUG_RGB_ENABLED
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace PlayerState
{
	public static class Sleep
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref PlayerSleepStateCD valueRW = ref changePlayerStateAspect.sleepStateCD.ValueRW;
			bool flag = EntityUtility.GetConditionValue(ConditionID.SleepingFromStandingStill, changePlayerStateAspect.entity, changePlayerStateLookup.summarizedConditionsBufferLookup) != 0;
			bool flag2 = EntityUtility.GetConditionValue(ConditionID.Sleeping, changePlayerStateAspect.entity, changePlayerStateLookup.summarizedConditionsBufferLookup) != 0;
			int conditionValue = EntityUtility.GetConditionValue(ConditionID.ExtraHealFromSleepPercentage, changePlayerStateAspect.entity, changePlayerStateLookup.summarizedConditionsBufferLookup);
			valueRW.wasPreviouslyForcedSleep = flag2;
			valueRW.wasPreviouslyAsleepFromBeingStill = flag;
			if (!flag2 && !flag)
			{
				PlayerController.PlayAnimationTrigger(255050412, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
			valueRW.minSleepTimer.Start(changePlayerStateShared.currentTick, 0.3f, changePlayerStateShared.tickRate);
			valueRW.qualitySleepTimer.Start(changePlayerStateShared.currentTick, 2f, changePlayerStateShared.tickRate);
			if (!flag2 || conditionValue != 0)
			{
				float num = 20f;
				EntityUtility.AddOrRefreshCondition(new ConditionData
				{
					conditionID = ConditionID.HealOverTimePercentage,
					value = (int)(num + num * (float)conditionValue / 100f)
				}, changePlayerStateAspect.conditionsBuffer, changePlayerStateShared.conditionsTableCD, changePlayerStateShared.currentTick, changePlayerStateShared.tickRate, changePlayerStateLookup.summarizedConditionsBufferLookup[changePlayerStateAspect.entity]);
			}
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			EntityUtility.RemoveCondition(ConditionID.HealOverTimePercentage, changePlayerStateAspect.conditionsBuffer);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref PlayerSleepStateCD valueRW = ref stateUpdateAspect.sleepStateCD.ValueRW;
			PlayerClaimedBed valueRO = stateUpdateAspect.playerClaimedBed.ValueRO;
			bool flag = EntityUtility.GetConditionValue(ConditionID.SleepingFromStandingStill, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) != 0;
			bool flag2 = EntityUtility.GetConditionValue(ConditionID.Sleeping, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup) != 0;
			bool flag3 = !valueRW.wasPreviouslyAsleepFromBeingStill && !valueRW.wasPreviouslyForcedSleep;
			bool flag4 = !flag2 && valueRW.wasPreviouslyForcedSleep;
			valueRW.wasPreviouslyForcedSleep = flag2;
			bool flag5 = math.length(stateUpdateAspect.playerMovementCD.ValueRO.targetMovementVelocity) > 0.1f;
			bool flag6 = valueRO.claimedBedEntity == Entity.Null || !lookupStateUpdateData.localTransformLookup.HasComponent(valueRO.claimedBedEntity);
			bool flag7 = flag3 && ((valueRW.minSleepTimer.IsTimerElapsed(sharedStateUpdateData.currentTick) && flag5) || flag6);
			bool flag8 = valueRW.wasPreviouslyAsleepFromBeingStill && (!flag || flag5);
			float3 position = lookupStateUpdateData.localTransformLookup[stateUpdateAspect.entity].Position;
			if (valueRW.qualitySleepTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				int conditionValue = EntityUtility.GetConditionValue(ConditionID.BuffsFromQualitySleep, stateUpdateAspect.entity, lookupStateUpdateData.summarizedConditionsLookup);
				if (conditionValue > 0)
				{
					EntityUtility.AddOrRefreshCondition(new ConditionData
					{
						conditionID = ConditionID.IncreasedManaRegenEffectiveness,
						value = conditionValue,
						duration = 30f
					}, stateUpdateAspect.conditionsBuffers, sharedStateUpdateData.conditionsTableCD, sharedStateUpdateData.currentTick, sharedStateUpdateData.tickRate, lookupStateUpdateData.summarizedConditionsLookup[stateUpdateAspect.entity]);
				}
			}
			if (flag4 || flag7 || flag8)
			{
				stateUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.Sleep);
			}
			else if (flag3)
			{
				GetOffsetAndFacingDirectionFromOccupiable(out var offset, out var facingDirection, valueRO.claimedBedEntity, lookupStateUpdateData.directionLookup, lookupStateUpdateData.occupiableLookup);
				float3 float5 = lookupStateUpdateData.localTransformLookup[valueRO.claimedBedEntity].Position + offset;
				if (math.lengthsq(position - float5) > 0.16000001f)
				{
					stateUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.Sleep);
					return;
				}
				stateUpdateAspect.playerMovementCD.ValueRW.targetMovementVelocity = float2.zero;
				lookupStateUpdateData.localTransformLookup.GetRefRW(stateUpdateAspect.entity).ValueRW.Position = float5;
				stateUpdateAspect.animationOrientationCD.ValueRW.facingDirection = facingDirection;
			}
		}

		public static void GetOffsetAndFacingDirectionFromOccupiable(out float3 offset, out Direction.Id facingDirection, Entity entity, ComponentLookup<DirectionCD> directionLookup, ComponentLookup<OccupiableCD> occupiableLookup)
		{
			facingDirection = Direction.Id.back;
			offset = float3.zero;
			if (directionLookup.TryGetComponent(entity, out var componentData))
			{
				occupiableLookup.TryGetComponent(entity, out var componentData2);
				switch (DirectionBasedOnVariationCD.GetVariationFromDirection(componentData.direction.RoundToInt2()))
				{
				case 0:
					facingDirection = Direction.Id.forward;
					offset = componentData2.occupyOffsetForward;
					break;
				case 1:
					facingDirection = Direction.Id.right;
					offset = componentData2.occupyOffsetRight;
					break;
				case 2:
					facingDirection = Direction.Id.back;
					offset = componentData2.occupyOffsetBack;
					break;
				case 3:
					facingDirection = Direction.Id.left;
					offset = componentData2.occupyOffsetLeft;
					break;
				}
			}
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			if (!changePlayerStatePresentationAspect.sleepStateCD.ValueRO.wasPreviouslyAsleepFromBeingStill && !changePlayerStatePresentationAspect.sleepStateCD.ValueRO.wasPreviouslyForcedSleep)
			{
				playerController.HideCarryable();
			}
			playerController.animator.SetBool(-592829941, value: true);
			if (playerController.isLocal)
			{
				Manager.rgb.TriggerEvent(RGBManager.Event.Sleeping);
			}
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			playerController.animator.SetBool(-592829941, value: false);
			playerController.ResetAnimSROffset();
			playerController.ResetAnimSROffsetRot();
			playerController.ShowCarryable();
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, PlayerController playerController, StatePresentationUpdateLookups statePresentationUpdateLookups)
		{
			if (!stateUpdateAspect.sleepState.ValueRO.wasPreviouslyAsleepFromBeingStill && !stateUpdateAspect.sleepState.ValueRO.wasPreviouslyForcedSleep)
			{
				PlayerClaimedBed valueRO = stateUpdateAspect.playerClaimedBed.ValueRO;
				Bed bed = Manager.memory.GetEntityMono(valueRO.claimedBedEntity) as Bed;
				if (bed != null)
				{
					Transform sleepingTransform = bed.GetSleepingTransform();
					playerController.SetAnimSROffset(sleepingTransform.localPosition);
					playerController.SetAnimSROffsetRot(sleepingTransform.localRotation);
				}
			}
		}
	}
}
