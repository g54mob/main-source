using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionAnachronisticCureRate : SubGoalDefinitionAnachronisticCure
	{
		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalAnachronisticCureRate(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.AnachronisticCureRate_Goal_CS.Replace("{[SCORE]}", StringUtils.FormatPercentageValue((float)Target / 100f));
		}
	}
}
