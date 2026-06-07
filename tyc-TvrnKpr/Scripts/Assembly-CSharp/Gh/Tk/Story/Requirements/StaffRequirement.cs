using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StaffRequirement : RequirementNode
	{
		public int minStaffCount;

		public int maxStaffCount;

		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnStaffChanged(ActiveStory data)
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected virtual IEnumerable<Staff> GetStaff(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
