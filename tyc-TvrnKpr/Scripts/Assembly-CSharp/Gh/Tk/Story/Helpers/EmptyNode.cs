using XNode;

namespace Gh.Tk.Story.Helpers
{
	[NodeTint("#1B90AD")]
	[NodeWidth(120)]
	public class EmptyNode : ConnectedStoryNode
	{
		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
