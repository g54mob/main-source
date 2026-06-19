using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionTotalStars : SubGoalDefinition
	{
		public int TargetAmount;

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.TotalStars_Goal_CS;
			LocalisationParams.Set("COUNT", TargetAmount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalTotalStars(owner, this);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
