using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionD7LeagueTablePosition : SubGoalDefinition
	{
		public int TargetPosition;

		public AmbulanceDepartmentStats.AmbulanceDepartmentStat StatType;

		[InspectorTooltip("Should include POSITION as part to be dynamically replaced")]
		public LocalisedString ChallengeText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalD7LeagueTablePosition(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ChallengeText.Translation;
			LocalisationParams.Set("POSITION", TargetPosition);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
