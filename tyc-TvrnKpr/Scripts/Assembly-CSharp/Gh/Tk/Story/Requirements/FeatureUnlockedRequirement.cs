using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class FeatureUnlockedRequirement : RequirementNode
	{
		public UnlockType unlockType;

		public string unlockKey;

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
