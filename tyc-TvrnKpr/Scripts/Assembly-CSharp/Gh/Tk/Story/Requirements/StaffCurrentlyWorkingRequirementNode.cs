using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StaffCurrentlyWorkingRequirementNode : StaffRequirement
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected override IEnumerable<Staff> GetStaff(ActiveStory story)
		{
			return null;
		}
	}
}
