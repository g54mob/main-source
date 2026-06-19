using I2.Loc;

namespace TH20
{
	public class MetagameSubGoalDefinitionResearchProjects : SubGoalDefinition
	{
		public int Count;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalResearchProjects(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.CompleteResearchProjectsCount_Goal_CS;
			LocalisationParams.Set("COUNT", Count);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
