using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class HasPlayerSkillsAvailableRequirementNode : RequirementNode
	{
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
