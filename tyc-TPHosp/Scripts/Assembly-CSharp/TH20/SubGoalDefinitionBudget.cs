using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionBudget : SubGoalDefinition
	{
		public int TargetBudgetScore;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalBudget(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.BudgetScore_Goal_CS.Replace("{[COUNT]}", StringUtils.FormatNumber(TargetBudgetScore));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
