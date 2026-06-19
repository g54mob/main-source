using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalResearchPointsDefinition : SubGoalDefinition
	{
		public float Points;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalResearchPoints(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.ResearchPoints_Goal_CS;
			LocalisationParams.Set("COUNT", Points);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
