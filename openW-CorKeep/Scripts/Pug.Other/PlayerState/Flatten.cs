using Pug.UnityExtensions;
using Unity.Mathematics;

namespace PlayerState
{
	public static class Flatten
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref FlattenStateCD valueRW = ref changePlayerStateAspect.flattenStateCD.ValueRW;
			float3 position = changePlayerStateLookup.localTransformLookup.GetRefRO(changePlayerStateAspect.entity).ValueRO.Position;
			changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection = Direction.FromVector(valueRW.positionToPlaceAt - position);
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = true;
			valueRW.placeDuration.Start(changePlayerStateShared.currentTick, 2f / 15f, changePlayerStateShared.tickRate);
			PlayerController.PlayAnimationTrigger(1984257893, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
			PlayerStateCommon.ExitPoppedState(changePlayerStateAspect, changePlayerStateShared);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref FlattenStateCD valueRW = ref stateUpdateAspect.flattenStateCD.ValueRW;
			if (valueRW.placeDuration.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				valueRW.placeDuration.Stop(sharedStateUpdateData.currentTick);
				stateUpdateAspect.playerStateCD.ValueRW.PopState(PlayerStateEnum.Flatten);
			}
		}
	}
}
