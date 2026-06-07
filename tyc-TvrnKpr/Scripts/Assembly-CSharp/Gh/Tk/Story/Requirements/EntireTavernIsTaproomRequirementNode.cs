using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class EntireTavernIsTaproomRequirementNode : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnRoomsChanged(ActiveStory activeStory)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
