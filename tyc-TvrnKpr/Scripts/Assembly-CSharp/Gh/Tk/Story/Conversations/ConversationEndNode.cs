using XNode;

namespace Gh.Tk.Story.Conversations
{
	[NodeTint("#900000")]
	public class ConversationEndNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
