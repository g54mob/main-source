using XNode;

namespace Gh.Tk.Story.Helpers
{
	[NodeTint("#FF0000")]
	public class NotImplementedNode : ConnectedStoryNode
	{
		public string message;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
