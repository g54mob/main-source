using XNode;

namespace Gh.Tk.Story.Logic
{
	[NodeTint("#68581d")]
	public class DelayUntilAchievementEffectFinishedPlayingStoryNode : ConnectedStoryNode
	{
		public override void OnTrigger(ActiveStory story)
		{
		}

		private bool IsAchievementScheduledOrPlaying()
		{
			return false;
		}

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
