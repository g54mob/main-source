using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionPatientDeaths : SubGoalDefinition
	{
		public int Deaths;

		public LocalisedString TextOverride;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalPatientDeaths(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = (TextOverride.IsNull() ? ScriptLocalization.Challenges_SubGoals.PatientDeaths_CS : TextOverride.Translation);
			LocalisationParams.Set("DEATHS", Deaths);
			return LocalisationParams.Localise(ref text);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
