using System.Collections.Generic;

namespace Gh.Tk.Story.Actions
{
	public class StaffTakeTimeOffActionNode : ConnectedStoryNode, IJobCallbackStoryNode
	{
		public float durationInDaysF;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private List<int> GetStaffCompletedList(ActiveStory story)
		{
			return null;
		}

		private void SetStaffCompletedList(ActiveStory story, List<int> staffCompletedList)
		{
		}

		public void OnJobCompleted(ActiveStory story, Job sourceJob)
		{
		}

		private void MarkStaffCompletedJob(ActiveStory story, int staffId)
		{
		}

		public void OnJobFailed(ActiveStory story, Job sourceJob)
		{
		}
	}
}
