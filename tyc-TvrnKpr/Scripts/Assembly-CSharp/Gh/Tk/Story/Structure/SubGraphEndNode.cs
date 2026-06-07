using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#900000")]
	public class SubGraphEndNode : BaseSubNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public override void Complete(ActiveStory story)
		{
		}
	}
}
