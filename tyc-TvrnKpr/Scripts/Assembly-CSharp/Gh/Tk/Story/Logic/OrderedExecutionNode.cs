using XNode;

namespace Gh.Tk.Story.Logic
{
	public class OrderedExecutionNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false, dynamicPortList = true)]
		public NodeConnection[] outputs;

		public int outputCount;

		public void InvalidateOutputs()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}
	}
}
