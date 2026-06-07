using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class FeatureUnlockedOnProfileRequirement : RequirementNode
	{
		[DropDownChoice(typeof(FeatureUnlockKey), "GetAllKeys")]
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
