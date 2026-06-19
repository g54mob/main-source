using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionHygieneRating : SubGoalDefinition
	{
		public float Rating;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalHygieneRating(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.Hygiene_Goal_CS.Replace("{[RATING]}", StringUtils.FormatPercentageValue(Rating / 100f));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return GameAlgorithms.CalculateHygieneEnvironmentRating(level) >= Rating;
		}
	}
}
