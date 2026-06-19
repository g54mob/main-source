namespace PlayerState
{
	public static class PlayingInstrument
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared, ChangePlayerStateLookup changePlayerStateLookup)
		{
			PlayerController.PlayAnimationTrigger(changePlayerStateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.Sitting) ? (-356999548) : 759586287, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect)
		{
		}

		public static void EnterStatePresentation(PlayerController playerController)
		{
			playerController.instrumentHandler.StartPlaying();
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			playerController.instrumentHandler.StopPlaying();
		}

		public static void UpdateStatePresentation(StatePresentationUpdateAspect stateUpdateAspect, PlayerController playerController)
		{
			playerController.instrumentHandler.Update(new PlayedNotes
			{
				Value = stateUpdateAspect.clientInput.ValueRO.playedNotes
			});
		}
	}
}
