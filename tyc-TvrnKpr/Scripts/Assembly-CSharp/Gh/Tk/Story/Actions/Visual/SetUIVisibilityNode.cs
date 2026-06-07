using Gh.Tk.UI;
using XNode;

namespace Gh.Tk.Story.Actions.Visual
{
	[NodeTint("#1B90AD")]
	public class SetUIVisibilityNode : ConnectedStoryNode
	{
		[DropDownChoice(typeof(UIVisibilityFlags), "GetAllFlags")]
		public string visibilityFlag;

		public bool isVisible;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
