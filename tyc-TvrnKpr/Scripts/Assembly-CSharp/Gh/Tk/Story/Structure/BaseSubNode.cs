using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#4b662b")]
	public abstract class BaseSubNode : StoryNode
	{
		public string label;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
