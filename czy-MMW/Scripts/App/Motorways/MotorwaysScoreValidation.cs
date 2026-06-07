namespace Motorways
{
	public static class MotorwaysScoreValidation
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("MotorwaysScoreValidation");

		public static bool ShouldRecordScore(bool isScoreLocked, int currentScore, int newScore)
		{
			if (isScoreLocked)
			{
				Log.Info("Not recording score. Score is locked.", newScore);
				return false;
			}
			if (newScore < currentScore)
			{
				Log.Info("Not recording score. New score of {0} is less than current score of {1}.", newScore, currentScore);
				return false;
			}
			return true;
		}

		public static bool ShouldLockScoreWhenGameEnds(MapChallenge.ChallengeType challengeType, GameEndReason gameEndReason)
		{
			if (challengeType == MapChallenge.ChallengeType.Daily)
			{
				if (gameEndReason != GameEndReason.GameOver)
				{
					return gameEndReason == GameEndReason.Restart;
				}
				return true;
			}
			return false;
		}
	}
}
