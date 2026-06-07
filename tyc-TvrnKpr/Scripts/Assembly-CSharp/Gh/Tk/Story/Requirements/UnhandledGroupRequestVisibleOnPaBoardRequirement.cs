using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class UnhandledGroupRequestVisibleOnPaBoardRequirement : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Invalidate(object sender, EventArgs e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
