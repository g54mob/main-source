using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionD7LeagueTablePositionMonths : SubGoalDefinition
	{
		public int TargetPosition;

		public int TargetConsecutiveMonths;

		public AmbulanceDepartmentStats.AmbulanceDepartmentStat StatType;

		[InspectorTooltip("Should include POSITION and MONTHS as parts to be dynamically replaced")]
		public LocalisedString ChallengeText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalD7LeagueTablePositionMonths(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ChallengeText.Translation;
			LocalisationParams.Set("POSITION", TargetPosition);
			LocalisationParams.Set("MONTHS", TargetConsecutiveMonths);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
