using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class SaveAndShareTemplateRequirement : RequirementNode
	{
		private static string SaveKey;

		private static string ShareKey;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void SaveTemplateHappened(object source, EventArgs eventArgs)
		{
		}

		private static void ShareTemplateHappened(object source, EventArgs<string> eventArgs)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
