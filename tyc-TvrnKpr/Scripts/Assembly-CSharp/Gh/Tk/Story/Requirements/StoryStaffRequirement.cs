using UnityEngine;

namespace Gh.Tk.Story.Requirements
{
	public class StoryStaffRequirement : RequirementNode
	{
		public StoryStaffConfig staffConfig;

		[Tooltip("If true, use the target actor instead of using the staffConfig")]
		public bool useTargetActor;

		public bool bypassBusyChecks;

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory context)
		{
			return false;
		}

		public Staff GetStaffForStory()
		{
			return null;
		}

		private bool IsStaffAvailableForStory(Staff staff)
		{
			return false;
		}
	}
}
