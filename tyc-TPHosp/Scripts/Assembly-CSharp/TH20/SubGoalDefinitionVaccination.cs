using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionVaccination : SubGoalDefinition
	{
		public int Target;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalVaccination(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.Vaccination_Goal_CS;
			LocalisationParams.Set("COUNT", Target);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
