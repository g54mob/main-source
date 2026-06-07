using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StoryFlagComparisonRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string storyFlagA;

		[DropDownChoice(typeof(StoryHelper), "GetAllStoryFlags")]
		public string storyFlagB;

		public PipProgressBaseRequirementNode.ComparisonType comparisonType;

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
