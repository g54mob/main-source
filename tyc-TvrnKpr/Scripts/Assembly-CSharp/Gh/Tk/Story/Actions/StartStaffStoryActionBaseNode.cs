using UnityEngine.Serialization;

namespace Gh.Tk.Story.Actions
{
	public abstract class StartStaffStoryActionBaseNode : ConnectedStoryNode
	{
		[FormerlySerializedAs("staff")]
		public StaffDataConfig staffConfig;

		public override void OnTrigger(ActiveStory story)
		{
		}

		protected abstract void OnTriggerInternal(ActiveStory story, Staff staff);
	}
}
