using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StoryFlagRequirementNode : PipProgressBaseRequirementNode
	{
		[StoryNodeTranslateFieldContent("requirement label", "RequirementLabel")]
		public string label;

		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string storyFlagKey;

		[Preserve]
		private static void OnGameStarted()
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
