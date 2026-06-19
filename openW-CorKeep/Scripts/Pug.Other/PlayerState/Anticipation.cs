using Unity.Mathematics;

namespace PlayerState
{
	public static class Anticipation
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			ref AnticipationCD valueRW = ref changePlayerStateAspect.anticipationCD.ValueRW;
			bool flag = false;
			if (changePlayerStateLookup.meleeWeaponLookup.TryGetComponent(changePlayerStateAspect.equippedObjectCD.ValueRO.equipmentPrefab, out var componentData))
			{
				flag = componentData.skipAnticipationAnimation || changePlayerStateLookup.moveFreelyWeaponLookup.HasComponent(changePlayerStateAspect.equippedObjectCD.ValueRO.equipmentPrefab);
			}
			if (!flag)
			{
				PlayerController.PlayAnimationTrigger(-1041479638, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
			valueRW.AnticipationDuration.Start(changePlayerStateShared.currentTick);
			if (valueRW.cooldowmTimer.IsTimerElapsed(changePlayerStateShared.currentTick))
			{
				valueRW.firstAttack = true;
				valueRW.cooldowmTimer.Stop(changePlayerStateShared.currentTick);
			}
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.anticipationCD.ValueRW.AnticipationDuration.Stop(changePlayerStateShared.currentTick);
			changePlayerStateAspect.anticipationCD.ValueRW.cooldowmTimer.Stop(changePlayerStateShared.currentTick);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			ref AnticipationCD valueRW = ref stateUpdateAspect.anticipationCD.ValueRW;
			if (valueRW.firstAttack && !stateUpdateAspect.clientInput.ValueRO.IsButtonStateSet(CommandInputButtonStateNames.Interact_HeldDown))
			{
				stateUpdateAspect.anticipationCD.ValueRW.firstAttack = false;
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
			}
			else if ((valueRW.AnticipationDuration.isRunning && valueRW.AnticipationDuration.IsTimerElapsed(sharedStateUpdateData.currentTick)) || math.length(stateUpdateAspect.playerMovementCD.ValueRO.adjustedMovementVelocity) > 0f)
			{
				stateUpdateAspect.playerStateCD.ValueRW.SetNextState(PlayerStateEnum.Walk);
			}
		}
	}
}
