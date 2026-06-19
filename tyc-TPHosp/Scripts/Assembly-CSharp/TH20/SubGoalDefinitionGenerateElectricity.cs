using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionGenerateElectricity : SubGoalDefinition
	{
		public int TargetAmount;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalGenerateElectricity(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.ElectricGenerated_Goal_CS.Replace("{[COUNT]}", StringUtils.FormatNumber(TargetAmount));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
