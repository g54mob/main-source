using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionMonobeastsKillStreak : SubGoalDefinition
	{
		public int TargetKillstreak;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalMonobeastsKillStreak(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.ShootMonoBeast_Goal_CS;
			LocalisationParams.Set("COUNT", TargetKillstreak);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
