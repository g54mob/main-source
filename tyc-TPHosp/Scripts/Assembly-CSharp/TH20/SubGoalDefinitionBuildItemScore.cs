using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionBuildItemScore : SubGoalDefinitionBuildItem
	{
		public LocalisedString GoalLocString;

		public LocalisedString ProgressLocString;

		public int ItemMultiplier = 1;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalBuildItemScore(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = GoalLocString.Translation;
			LocalisationParams.Set("COUNT", ItemCount);
			LocalisationParams.Localise(ref text);
			return text;
		}
	}
}
