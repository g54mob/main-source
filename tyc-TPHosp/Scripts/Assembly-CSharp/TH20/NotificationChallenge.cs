namespace TH20
{
	public class NotificationChallenge : NotificationGenericDecision
	{
		private readonly string _cachedLocalisedScoreText;

		private readonly Objective.CompletionType _completionResult;

		private readonly string _cachedLocalisedRewardsText;

		public Objective.CompletionType CompletionResult => _completionResult;

		public NotificationChallenge(ChallengeRewardOption challengeReward, Challenge challenge, ResponseDelegate responseDelegate, Level level)
			: base(challengeReward.RewardNotificationDef, responseDelegate, level)
		{
			_cachedLocalisedScoreText = challenge.GetScoreText();
			_completionResult = challenge.CompletionResult;
			if (challengeReward.Rewards != null && challengeReward.Rewards.Length != 0)
			{
				_cachedLocalisedRewardsText = challenge.Definition.GetDescriptionString(challenge, challengeReward.Rewards);
			}
			else
			{
				_cachedLocalisedRewardsText = string.Empty;
			}
		}

		public string GetRewardsText()
		{
			return _cachedLocalisedRewardsText;
		}

		public string GetScoreText()
		{
			return _cachedLocalisedScoreText;
		}
	}
}
