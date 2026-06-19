using Unity.Mathematics;

namespace PlayerState
{
	public static class Release
	{
		public static void EnterState(in ChangePlayerStateAspect changePlayerStateAspect, in ChangePlayerStateShared changePlayerStateShared, in ChangePlayerStateLookup changePlayerStateLookup)
		{
			changePlayerStateAspect.releaseStateCD.ValueRW.nextState = PlayerStateEnum.Walk;
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect)
		{
			changePlayerStateAspect.playerOrientationCD.ValueRW.reorientationBlocked = false;
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			if (stateUpdateAspect.playerAttackCD.ValueRW.hitDuration.isRunning && stateUpdateAspect.playerAttackCD.ValueRW.hitDuration.IsTimerElapsed(sharedStateUpdateData.currentTick))
			{
				stateUpdateAspect.playerAttackCD.ValueRW.hitDuration.Stop(sharedStateUpdateData.currentTick);
				if (math.length(stateUpdateAspect.playerMovementCD.ValueRO.adjustedMovementVelocity) > 0f || stateUpdateAspect.equippedObjectCD.ValueRO.containedObject.objectData.objectID == ObjectID.None || !stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown))
				{
					stateUpdateAspect.releaseStateCD.ValueRW.nextState = PlayerStateEnum.Walk;
				}
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(stateUpdateAspect.releaseStateCD.ValueRW.nextState);
			}
		}
	}
}
