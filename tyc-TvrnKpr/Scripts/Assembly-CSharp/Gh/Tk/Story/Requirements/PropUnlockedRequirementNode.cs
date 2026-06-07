using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class PropUnlockedRequirementNode : RequirementNode
	{
		[Header("Props")]
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptionsWithoutAnyX")]
		public string[] propIds;

		[DropDownChoice(typeof(StoryHelper), "GetAllDecoPropKeys")]
		public string[] decoProps;

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
