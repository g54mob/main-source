using XNode;

namespace Gh.Tk.Story
{
	public abstract class ConnectedStoryNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection output;

		public override object GetValue(NodePort port)
		{
			return null;
		}
	}
}
