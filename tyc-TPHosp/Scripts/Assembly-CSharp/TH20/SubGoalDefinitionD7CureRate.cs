using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionD7CureRate : SubGoalDefinition
	{
		public int CureRateTarget;

		[InspectorTooltip("Should include RATE as part to be dynamically replaced")]
		public LocalisedString ChallengeText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalD7CureRate(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ChallengeText.Translation;
			LocalisationParams.Set("RATE", CureRateTarget);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public bool IsValidPatient(Patient patient)
		{
			return patient.IsAEPatient;
		}
	}
}
