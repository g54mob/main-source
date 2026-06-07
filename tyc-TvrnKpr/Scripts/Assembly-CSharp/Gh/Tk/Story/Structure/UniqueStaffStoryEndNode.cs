using XNode;

namespace Gh.Tk.Story.Structure
{
	public class UniqueStaffStoryEndNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
