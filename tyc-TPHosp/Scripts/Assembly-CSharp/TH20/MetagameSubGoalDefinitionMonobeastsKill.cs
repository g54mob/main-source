using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionMonobeastsKill : SubGoalDefinition
	{
		public int TargetKills;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalMonobeastsKill(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.ShootMonoBeast_Goal_CS;
			LocalisationParams.Set("COUNT", TargetKills);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
