using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class CycleSnappingPointRequirement : RequirementNode
	{
		private const string Key = "CycleSnappingPointHappened";

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void CycleSnappingPointHappened(object sender, EventArgs e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
