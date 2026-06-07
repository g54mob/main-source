using XNode;

namespace Gh.Tk.Story.Logic
{
	[NodeTint("#68581d")]
	public class DelayNode : ConnectedStoryNode
	{
		public float delayMinInHours;

		public float delayMaxInHours;

		private string _timeRemainingKey;

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		protected virtual bool AreFurtherRequirementsMet(ActiveStory story)
		{
			return false;
		}
	}
}
