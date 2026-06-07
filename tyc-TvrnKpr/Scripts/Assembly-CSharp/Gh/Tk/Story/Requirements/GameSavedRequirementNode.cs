using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GameSavedRequirementNode : RequirementNode
	{
		private string StoryKey => null;

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
