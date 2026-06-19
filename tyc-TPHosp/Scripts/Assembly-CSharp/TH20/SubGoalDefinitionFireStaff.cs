using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionFireStaff : SubGoalDefinition
	{
		public int NumStaffToFire;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalFireStaff(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.FireStaff_Goal_CS;
			LocalisationParams.Set("COUNT", NumStaffToFire);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
