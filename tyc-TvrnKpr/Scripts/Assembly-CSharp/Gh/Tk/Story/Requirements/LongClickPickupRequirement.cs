using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class LongClickPickupRequirement : RequirementNode
	{
		private static string Key;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static EventHandler LongClickPickupHappened()
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
