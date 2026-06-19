using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionRotateItem : SubGoalDefinition
	{
		public int RotationsRequired = 3;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalRotateItem(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.RotateItem_Goal_CS;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
