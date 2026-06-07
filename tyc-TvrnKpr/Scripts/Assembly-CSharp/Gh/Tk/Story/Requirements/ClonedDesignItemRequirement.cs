using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class ClonedDesignItemRequirement : RequirementNode
	{
		private static string Key;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void CloneDecorationHappened(object source, EventArgs eventArgs)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
