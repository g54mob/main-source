using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionDaysSinceLastDeath : SubGoalDefinition
	{
		public int Days;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalDaysSinceLastDeath(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.DaysSinceLastDeath_CS;
			LocalisationParams.Set("DAYS", Days);
			return LocalisationParams.Localise(ref text);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
