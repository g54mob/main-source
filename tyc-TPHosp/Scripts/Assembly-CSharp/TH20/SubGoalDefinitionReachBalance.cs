using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionReachBalance : SubGoalDefinition
	{
		public int Target;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalReachBalance(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.ReachBalance_Goal_CS.Replace("{[CASH]}", StringUtils.FormatCurrency(Target));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.FinanceManager.Balance >= Target;
		}
	}
}
