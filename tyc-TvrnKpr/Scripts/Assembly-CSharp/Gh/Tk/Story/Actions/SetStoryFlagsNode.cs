using UnityEngine.Serialization;
using XNode;

namespace Gh.Tk.Story.Actions
{
	[NodeTint("#3b2840")]
	[NodeWidth(300)]
	public class SetStoryFlagsNode : ConnectedStoryNode
	{
		[FormerlySerializedAs("variables")]
		public StoryFlagConfig[] flags;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
