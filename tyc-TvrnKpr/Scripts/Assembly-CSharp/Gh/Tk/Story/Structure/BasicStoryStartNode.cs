using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#4b662b")]
	[NodeWidth(265)]
	public class BasicStoryStartNode : StartNode
	{
		public GameLevel level;

		public override bool CanTrigger()
		{
			return false;
		}
	}
}
