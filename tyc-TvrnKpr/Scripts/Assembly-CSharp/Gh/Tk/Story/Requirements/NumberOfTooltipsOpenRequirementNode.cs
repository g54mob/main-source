using System;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class NumberOfTooltipsOpenRequirementNode : PipProgressBaseRequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Invalidate(object sender, EventArgs e)
		{
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
