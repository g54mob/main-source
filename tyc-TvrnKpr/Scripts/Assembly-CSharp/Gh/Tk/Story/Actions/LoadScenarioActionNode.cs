using XNode;

namespace Gh.Tk.Story.Actions
{
	public class LoadScenarioActionNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public GameLevel level;

		public string scenarioId;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
