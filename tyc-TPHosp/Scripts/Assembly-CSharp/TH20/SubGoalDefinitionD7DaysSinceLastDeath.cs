using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionD7DaysSinceLastDeath : SubGoalDefinition
	{
		public int Days;

		[InspectorTooltip("Should include DAYS as part to be dynamically replaced")]
		public LocalisedString ChallengeText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalD7DaysSinceLastDeath(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ChallengeText.Translation;
			LocalisationParams.Set("DAYS", Days);
			return LocalisationParams.Localise(ref text);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
