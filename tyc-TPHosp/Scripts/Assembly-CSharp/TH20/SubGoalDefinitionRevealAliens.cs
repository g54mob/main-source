using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionRevealAliens : SubGoalDefinition
	{
		public int NumAliens;

		public LocalisedString TextOverride;

		public LocalisedString ProgressTextOverride;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalRevealAliens(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = (TextOverride.IsNull() ? ScriptLocalization.Challenges_SubGoals.RevealAliens_Goal_CS : TextOverride.Translation);
			LocalisationParams.Set("COUNT_ALIENS", NumAliens);
			return LocalisationParams.Localise(ref text);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
