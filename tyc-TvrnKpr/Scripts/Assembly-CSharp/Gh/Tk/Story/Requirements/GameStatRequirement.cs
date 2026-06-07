using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GameStatRequirement : PipProgressBaseRequirementNode
	{
		public bool useGlobalStats;

		public bool onlyCountNewOccurences;

		public string gameStatKey;

		[StoryNodeTranslateFieldContent("requirement display text", "RequirementLabel")]
		public string displayText;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void StatChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
