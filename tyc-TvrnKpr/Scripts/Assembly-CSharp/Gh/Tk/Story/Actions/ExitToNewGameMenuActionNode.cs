using XNode;

namespace Gh.Tk.Story.Actions
{
	public class ExitToNewGameMenuActionNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
