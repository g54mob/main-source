using Pug.UnityExtensions;
using Unity.Physics.GraphicsIntegration;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	public static class NoClip
	{
		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
		}

		public static void UpdateStateAfterPhysics(in ClientInput clientInput, ref LocalTransform localTransform, in PlayerMovementCD playerMovementCD, ref PhysicsGraphicalSmoothing physicsGraphicalSmoothing, float deltaTime, bool isFinalPredictionTick)
		{
			bool flag = clientInput.IsButtonStateSet(CommandInputButtonStateNames.SpeedupNoClip_HeldDown);
			localTransform.Position += (flag ? 3f : 1f) * playerMovementCD.noClipMovementSpeedMultipler * deltaTime * playerMovementCD.targetMovementVelocity.ToFloat3();
			if (isFinalPredictionTick)
			{
				physicsGraphicalSmoothing.ApplySmoothing = 0;
			}
		}

		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			PlayerController.PlayAnimationTrigger(1352515405, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			changePlayerStateLookup.disablePhysicsLookup.SetComponentEnabled(changePlayerStateAspect.entity, value: true);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateLookup.disablePhysicsLookup.SetComponentEnabled(changePlayerStateAspect.entity, value: false);
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			playerController.HidePlayer = false;
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, PlayerController playerController)
		{
			bool flag = Mathf.RoundToInt(Time.time * 60f) % 4 < 2;
			playerController.HidePlayer = !flag;
		}
	}
}
