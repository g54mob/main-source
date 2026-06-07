using XNode;

namespace Gh.Tk.Story.Conversations
{
	public abstract class ConversationNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection previous;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection next;

		public ConversationSpeaker speaker;
	}
}
