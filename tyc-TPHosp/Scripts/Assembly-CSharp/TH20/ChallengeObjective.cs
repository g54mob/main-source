namespace TH20
{
	public class ChallengeObjective : Challenge
	{
		private bool _abandoned;

		private bool _failed;

		private readonly ChallengeObjectiveConfig _config;

		public ChallengeObjective(ChallengeConfig config, Level level)
			: base(config, level)
		{
			_config = GetConfig<ChallengeObjectiveConfig>();
		}

		public override IReward[] GetRewards(CompletionType completionType)
		{
			if (_challengeReward == null && completionType == CompletionType.Abandoned)
			{
				return _definition.Reward.FindRewardForScore(-1)?.Rewards;
			}
			return base.GetRewards(completionType);
		}

		protected override int CalculateChallengeScore()
		{
			if (!_abandoned)
			{
				if (!_failed)
				{
					return 1;
				}
				return 0;
			}
			return -1;
		}

		public override void Abandon()
		{
			_abandoned = true;
			base.Abandon();
		}

		public override void CheckForObjectiveCompletion()
		{
			bool flag = true;
			foreach (ObjectiveSubGoal subGoal in SubGoals)
			{
				if (subGoal.Failed())
				{
					_failed = true;
					FinishChallenge();
					return;
				}
				if (!subGoal.Completed())
				{
					flag = false;
				}
			}
			if (flag)
			{
				base.CompletionResult = CompletionType.Successful;
				FinishChallenge();
			}
			else if (base.Definition.IsTimed && DaysElapsed > base.Definition.TimeLength)
			{
				_failed = true;
				base.CompletionResult = CompletionType.Failed;
				FinishChallenge();
			}
		}

		public override bool GiveRewardOnComplete()
		{
			return false;
		}

		public override bool CanDismiss()
		{
			return _config.CanAbandon;
		}
	}
}
