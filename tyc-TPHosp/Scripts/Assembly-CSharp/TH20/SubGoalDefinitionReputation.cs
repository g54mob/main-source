using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionReputation : SubGoalDefinition
	{
		public int Target;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalReputation(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.Reputation_Goal_CS.Replace("{[TARGET]}", StringUtils.FormatPercentageValue((float)Target / 100f));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.ReputationTracker.OverallReputation * 100f >= (float)Target;
		}
	}
}
