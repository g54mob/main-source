using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#900000")]
	public class ScenarioStoryEndNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}

		private void LogScenarioCompleteTimer(ActiveStory story)
		{
		}

		public ScenarioStoryStartNode GetStartNode()
		{
			return null;
		}

		private IEnumerable<Node> GetInputNodes(IEnumerable<Node> nodes)
		{
			return null;
		}
	}
}
