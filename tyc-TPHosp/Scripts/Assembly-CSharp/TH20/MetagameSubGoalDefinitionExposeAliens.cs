using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameSubGoalDefinitionExposeAliens : SubGoalDefinition
	{
		public int ExposedCount;

		public LocalisedString GoalTextOverride;

		public override string GoalText(Objective objective)
		{
			string text = (GoalTextOverride.IsNull() ? ScriptLocalization.Challenges_SubGoals.OwnPlots_Goal_CS : GoalTextOverride.Translation);
			LocalisationParams.Set("COUNT", ExposedCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalExposeAliens(owner, this);
		}
	}
}
