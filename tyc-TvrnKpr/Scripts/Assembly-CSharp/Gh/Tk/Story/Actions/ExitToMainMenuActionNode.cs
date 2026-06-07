using XNode;

namespace Gh.Tk.Story.Actions
{
	public class ExitToMainMenuActionNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
