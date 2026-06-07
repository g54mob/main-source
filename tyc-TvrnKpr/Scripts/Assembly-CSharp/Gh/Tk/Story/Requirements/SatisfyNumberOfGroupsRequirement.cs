using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class SatisfyNumberOfGroupsRequirement : PipProgressBaseRequirementNode
	{
		private string _key => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void IncreaseCounter(ActiveStory story)
		{
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
