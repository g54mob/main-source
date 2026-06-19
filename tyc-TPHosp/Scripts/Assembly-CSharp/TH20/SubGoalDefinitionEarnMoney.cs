using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionEarnMoney : SubGoalDefinition
	{
		public int TargetAmount;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalEarnMoney(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.EarnMoney_Goal_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(TargetAmount));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
