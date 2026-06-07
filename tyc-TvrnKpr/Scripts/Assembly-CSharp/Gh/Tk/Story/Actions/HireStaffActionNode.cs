namespace Gh.Tk.Story.Actions
{
	public class HireStaffActionNode : StartStaffStoryActionBaseNode
	{
		public bool withHiringAnimation;

		public bool suppressTavernLogEntry;

		protected override void OnTriggerInternal(ActiveStory story, Staff staff)
		{
		}
	}
}
