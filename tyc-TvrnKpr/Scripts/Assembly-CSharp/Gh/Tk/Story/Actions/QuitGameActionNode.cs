using XNode;

namespace Gh.Tk.Story.Actions
{
	public class QuitGameActionNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
