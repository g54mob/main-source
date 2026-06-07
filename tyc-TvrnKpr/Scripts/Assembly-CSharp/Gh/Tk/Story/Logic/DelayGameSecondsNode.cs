using XNode;

namespace Gh.Tk.Story.Logic
{
	[NodeTint("#68581d")]
	public class DelayGameSecondsNode : ConnectedStoryNode
	{
		public float delayInGameSeconds;

		public bool useUnscaledTime;

		private string _timeRemainingKey;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}
	}
}
