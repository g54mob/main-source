namespace Gh.Tk.Story.Requirements
{
	public class LevelScenarioRequirementNode : RequirementNode
	{
		public string scenarioId;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
