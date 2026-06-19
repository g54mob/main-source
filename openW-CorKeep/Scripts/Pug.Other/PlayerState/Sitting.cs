using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

namespace PlayerState
{
	public static class Sitting
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref SittingStateCD valueRW = ref changePlayerStateAspect.sittingStateCD.ValueRW;
			valueRW.tryingToLeaveStateTimer.Start(changePlayerStateShared.currentTick);
			valueRW.allowedToLeaveStateTimer.Start(changePlayerStateShared.currentTick);
			PlayerController.PlayAnimationTrigger(-390694685, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			if (changePlayerStateShared.isFinalFullPredictionTick)
			{
				changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
			}
			ControllingStateCommon.TryStartControllingControllableElseLeaveState(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateAspect.playerStateCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup, changePlayerStateLookup.sittableLookup, changePlayerStateShared.isPartialTick);
		}

		public static void ResetState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			PlayerController.PlayAnimationTrigger(-390694685, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup, ChangePlayerStateShared changePlayerStateShared)
		{
			Entity controlledEntity = changePlayerStateAspect.controllingOtherEntityCD.ValueRO.controlledEntity;
			ControllingStateCommon.ReleaseControlledEntity(changePlayerStateAspect.entity, changePlayerStateAspect.controllingOtherEntityCD, changePlayerStateLookup.controlledByOtherEntityLookup, changePlayerStateLookup.simulateLookup);
			if (changePlayerStateLookup.sittableLookup.TryGetComponent(controlledEntity, out var componentData))
			{
				float3 position = changePlayerStateLookup.localTransformLookup[controlledEntity].Position + componentData.leavePositionOffset.GetDataInDirection(changePlayerStateAspect.animationOrientationCD.ValueRO.facingDirection.id, componentData.leavePositionOffset.forward).ToFloat3();
				changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position = position;
				if (changePlayerStateShared.isFinalFullPredictionTick)
				{
					changePlayerStateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
				}
			}
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref SittingStateCD valueRW = ref stateUpdateAspect.sittingStateCD.ValueRW;
			ControllingStateCommon.TryChangeToRequestedControllable(stateUpdateAspect.entity, stateUpdateAspect.controllingOtherEntityCD, stateUpdateAspect.playerStateCD, lookupStateUpdateData.controlledByOtherEntityLookup, lookupStateUpdateData.simulateLookup, lookupStateUpdateData.sittableLookup, sharedStateUpdateData.isPartialTick);
			Entity controlledEntity = stateUpdateAspect.controllingOtherEntityCD.ValueRO.controlledEntity;
			if (lookupStateUpdateData.simulateLookup.HasAndIsComponentEnabled(controlledEntity) && lookupStateUpdateData.controlledByOtherEntityLookup.TryGetComponent(controlledEntity, out var componentData) && componentData.controlledByEntity != stateUpdateAspect.entity)
			{
				lookupStateUpdateData.controlledByOtherEntityLookup.GetRefRW(controlledEntity).ValueRW.controlledByEntity = stateUpdateAspect.entity;
			}
			bool num = lookupStateUpdateData.entityDestroyedLookup.HasComponent(controlledEntity) && !lookupStateUpdateData.entityDestroyedLookup.IsComponentEnabled(controlledEntity);
			Entity currentClosestInteractable = stateUpdateAspect.interactorCD.ValueRO.currentClosestInteractable;
			if (!num)
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			if (stateUpdateAspect.interactorCD.ValueRW.CanConsumeInteract() && currentClosestInteractable == Entity.Null)
			{
				stateUpdateAspect.interactorCD.ValueRW.TryConsumeInteract();
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				return;
			}
			SittableCD sittableCD = lookupStateUpdateData.sittableLookup[controlledEntity];
			float3 position = lookupStateUpdateData.localTransformLookup[controlledEntity].Position + sittableCD.sitPositionOffset.ToFloat3();
			lookupStateUpdateData.localTransformLookup.GetRefRW(stateUpdateAspect.entity).ValueRW.Position = position;
			if (!valueRW.allowedToLeaveStateTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				return;
			}
			if (math.length(stateUpdateAspect.playerMovementCD.ValueRO.targetMovementVelocity) > 0.1f)
			{
				if (!valueRW.tryingToLeaveStateTimer.isRunning)
				{
					valueRW.tryingToLeaveStateTimer.Start(sharedStateUpdateData.currentTick);
				}
				if (valueRW.tryingToLeaveStateTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
				{
					stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
				}
			}
			else
			{
				valueRW.tryingToLeaveStateTimer.ClearStart();
			}
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			playerController.shadow.gameObject.SetActive(value: false);
			SittableObject sittableObject = Manager.memory.GetEntityMono(changePlayerStatePresentationAspect.controllingOtherEntityCD.ValueRO.controlledEntity) as SittableObject;
			if (!(sittableObject == null))
			{
				playerController.SetAnimSROffset(sittableObject.visualSitPosition.localPosition);
			}
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			playerController.shadow.gameObject.SetActive(value: true);
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, PlayerController playerController)
		{
			SittableObject sittableObject = Manager.memory.GetEntityMono(stateUpdateAspect.controllingOtherEntityCD.ValueRO.controlledEntity) as SittableObject;
			if (sittableObject != null)
			{
				playerController.SetAnimSROffset(sittableObject.visualSitPosition.localPosition);
			}
		}
	}
}
