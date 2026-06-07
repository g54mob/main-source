using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class TooltipShownOnElementRequirementNode : RequirementNode
	{
		[Tooltip("The name of the GO which is the tooltip provider")]
		public string elementName;

		protected string ValueKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
