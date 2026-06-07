using XNode;

namespace Gh.Tk.Story.SelectTarget
{
	[NodeTint("#0094FF")]
	public class SelectPropTargetNode : ConnectedStoryNode
	{
		public PropFilterConfig filter;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
