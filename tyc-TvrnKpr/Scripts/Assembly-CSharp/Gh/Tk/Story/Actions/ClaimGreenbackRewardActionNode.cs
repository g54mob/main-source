using XNode;

namespace Gh.Tk.Story.Actions
{
	[NodeTint("#4A90E2")]
	public class ClaimGreenbackRewardActionNode : ActionBaseNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetGreenbackRewardIds")]
		public string rewardId;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
