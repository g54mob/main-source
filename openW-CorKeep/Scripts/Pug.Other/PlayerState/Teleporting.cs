#define PUG_RGB_ENABLED
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	public static class Teleporting
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateAspect.teleportingCD.ValueRW.teleportingTimer.Start(changePlayerStateShared.currentTick);
			changePlayerStateAspect.deathStateCD.ValueRW.isDyingOrDead = true;
			changePlayerStateLookup.disablePhysicsLookup.SetComponentEnabled(changePlayerStateAspect.entity, value: true);
			changePlayerStateAspect.playerInvincibilityCD.ValueRW.isInvincible = true;
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRW(changePlayerStateAspect.entity).ValueRW.Position;
			DynamicBuffer<GhostEffectEventBuffer> effectEventBuffer = changePlayerStateAspect.effectEventBuffer;
			ref GhostEffectEventBufferPointerCD valueRW = ref changePlayerStateAspect.effectEventBufferPointerCD.ValueRW;
			GhostEffectEventBuffer item = new GhostEffectEventBuffer
			{
				Tick = changePlayerStateShared.currentTick,
				value = new EffectEventCD
				{
					entity = changePlayerStateAspect.entity,
					position1 = position,
					effectID = EffectID.TeleportExplosion
				}
			};
			effectEventBuffer.AddToRingBuffer(ref valueRW, in item);
			PlayerController.PlayAnimationTrigger(1914833150, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			NetworkTick currentTick = sharedStateUpdateData.currentTick;
			currentTick.Decrement();
			float elapsedSeconds = stateUpdateAspect.teleportingStateCD.ValueRO.teleportingTimer.GetElapsedSeconds(currentTick, sharedStateUpdateData.tickRate);
			if (stateUpdateAspect.teleportingStateCD.ValueRO.teleportingTimer.GetElapsedSeconds(sharedStateUpdateData.currentTick, sharedStateUpdateData.tickRate) >= 4.1f && elapsedSeconds < 4.1f)
			{
				stateUpdateAspect.deathStateCD.ValueRW.isDyingOrDead = false;
				RefRW<LocalTransform> refRW = lookupStateUpdateData.localTransformLookup.GetRefRW(stateUpdateAspect.entity);
				ref LocalTransform valueRW = ref refRW.ValueRW;
				valueRW.Position = stateUpdateAspect.teleportingStateCD.ValueRO.targetPosition;
				if (sharedStateUpdateData.isFinalFullPredictionTick)
				{
					stateUpdateAspect.physicsGraphicalSmoothing.ValueRW.ApplySmoothing = 0;
				}
				stateUpdateAspect.playerMovementCD.ValueRW.targetMovementVelocity = float2.zero;
				Entity leashedEntity = stateUpdateAspect.leashingCD.ValueRO.leashedEntity;
				if (lookupStateUpdateData.simulateLookup.HasAndIsComponentEnabled(leashedEntity) && lookupStateUpdateData.localTransformLookup.HasComponent(leashedEntity))
				{
					refRW = lookupStateUpdateData.localTransformLookup.GetRefRW(leashedEntity);
					refRW.ValueRW.Position = valueRW.Position + new float3(0f, 0f, -0.1f);
				}
			}
			if (stateUpdateAspect.teleportingStateCD.ValueRO.teleportingTimer.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				lookupStateUpdateData.disablePhysicsLookup.SetComponentEnabled(stateUpdateAspect.entity, value: false);
				stateUpdateAspect.playerInvincibilityCD.ValueRW.isInvincible = false;
				stateUpdateAspect.playerStateCD.ValueRW.UnlockCurrentState(ref stateUpdateAspect.playerOrientationCD.ValueRW);
			}
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect)
		{
			changePlayerStateAspect.teleportingCD.ValueRW.targetPosition = Vector3.zero;
		}

		public static void EnterStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			if (playerController.isLocal)
			{
				Manager.rgb.TriggerEvent(RGBManager.Event.PortalTeleport);
				Manager.ui.FadeOutAllGameplayUI();
				Manager.ui.FadeInMouse();
				playerController.shadow.gameObject.SetActive(value: false);
				playerController.flashableComponent.FlashLinearNoCurve(1f);
			}
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, StatePresentationShared statePresentationShared, StatePresentationUpdateLookups statePresentationUpdateLookups, PlayerController playerController)
		{
			float fraction;
			NetworkTick currentTickOnClient = EntityUtility.GetCurrentTickOnClient(stateUpdateAspect.entity, statePresentationShared.networkTime, statePresentationUpdateLookups.predictedGhostLookup, out fraction);
			float elapsedSeconds = stateUpdateAspect.teleportingStateCD.ValueRO.teleportingTimer.GetElapsedSeconds(currentTickOnClient, fraction, statePresentationShared.tickRate);
			if (elapsedSeconds >= 1.1f && stateUpdateAspect.teleportingStateCD.ValueRO.lastVisualTeleportTimestamp < 1.1f && playerController.isLocal)
			{
				Manager.load.FadeOut(2f, FadePresets.blackToBlack);
			}
			stateUpdateAspect.teleportingStateCD.ValueRW.lastVisualTeleportTimestamp = elapsedSeconds;
		}

		public static void ExitStatePresentation(PlayerController playerController, ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
		{
			if (playerController.isLocal)
			{
				Manager.ui.FadeInAllGameplayUI();
				Manager.ui.FadeInMouse();
				Manager.load.FadeIn(1f, FadePresets.blackToBlack);
			}
			playerController.shadow.gameObject.SetActive(value: true);
			changePlayerStatePresentationAspect.teleportingStateCD.ValueRW.lastVisualTeleportTimestamp = 0f;
		}
	}
}
