using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class OpenForBusinessRequirement : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnGrandOpening(ActiveStory data)
		{
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
