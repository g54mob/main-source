namespace Brewery.Minigames
{
	public static class MinigameRewardResolver
	{
		public static float ComputeBaseGrant(MinigameId id, int rawScore, MinigameTier tier, bool overclock, MinigameConfig config)
		{
			return 0f;
		}

		public static float ApplyDiminishingReturns(float baseGrant, float remainingCap, int playerSubmissionCount, MinigameConfig config)
		{
			return 0f;
		}

		public static float ApplyCoopScaler(float grant, int activeContributors, MinigameConfig config)
		{
			return 0f;
		}

		public static float ApplyPerPlayerCap(float grant, float playerTotalGranted, float stepCap, MinigameConfig config)
		{
			return 0f;
		}

		public static int ComputeRushDelta(MinigameId id, MinigameTier tier, int comboMax, int eventSuccesses, MinigameConfig config)
		{
			return 0;
		}

		public static (int, int) RollSecondaryRewards(MinigameId id, MinigameTier tier, bool overclock, int seed, MinigameConfig config)
		{
			return default((int, int));
		}

		public static float ComputeFinalGrant(MinigameId id, int rawScore, MinigameTier tier, bool overclock, float remainingStepCap, int playerSubmissionCount, float playerTotalGranted, float stepCap, int activeContributors, MinigameConfig config)
		{
			return 0f;
		}
	}
}
