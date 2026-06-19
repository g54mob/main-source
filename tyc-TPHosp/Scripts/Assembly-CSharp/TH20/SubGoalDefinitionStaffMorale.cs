using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionStaffMorale : SubGoalDefinition
	{
		public int TargetPercentage;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalStaffMorale(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.StaffMorale_Goal_CS.Replace("{[TARGET]}", StringUtils.FormatPercentageValue((float)TargetPercentage / 100f));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.CharacterManager.StaffMorale * 100f >= (float)TargetPercentage;
		}
	}
}
