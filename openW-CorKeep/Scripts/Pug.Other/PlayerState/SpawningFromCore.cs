using Pug.UnityExtensions;

namespace PlayerState
{
	public static class SpawningFromCore
	{
		public static void EnterState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			changePlayerStateAspect.animationOrientationCD.ValueRW.facingDirection = Direction.Id.back;
			changePlayerStateAspect.spawningFromCoreStateCD.ValueRW.spawnTimer.Start(changePlayerStateShared.currentTick, 12.950001f, changePlayerStateShared.tickRate);
		}

		public static void ExitState(ChangePlayerStateAspect changePlayerStateAspect)
		{
		}

		public static void UpdateState(StateUpdateAspect stateUpdateAspect, SharedStateUpdateData sharedStateUpdateData, LookupStateUpdateData lookupStateUpdateData)
		{
			float elapsedSeconds = stateUpdateAspect.spawningFromCoreStateCD.ValueRW.spawnTimer.GetElapsedSeconds(sharedStateUpdateData.currentTick, sharedStateUpdateData.tickRate);
			ref AnimationOrientationCD valueRW = ref stateUpdateAspect.animationOrientationCD.ValueRW;
			if (!(elapsedSeconds >= 12.950001f))
			{
				if (elapsedSeconds >= 12.450001f)
				{
					valueRW.facingDirection = Direction.Id.back;
				}
				else if (elapsedSeconds >= 11.650001f)
				{
					valueRW.facingDirection = Direction.Id.left;
				}
				else if (elapsedSeconds >= 1.7f)
				{
					valueRW.facingDirection = Direction.Id.right;
				}
			}
		}

		public static void EnterStatePresentation(PlayerController playerController)
		{
			if (playerController.isLocal)
			{
				playerController.spawningFromCoreFinished = false;
			}
		}

		public static void ExitStatePresentation(PlayerController playerController)
		{
			if (playerController.isLocal)
			{
				playerController.XScaler.gameObject.SetActive(value: true);
				playerController.shadow.gameObject.SetActive(value: true);
			}
		}
	}
}
