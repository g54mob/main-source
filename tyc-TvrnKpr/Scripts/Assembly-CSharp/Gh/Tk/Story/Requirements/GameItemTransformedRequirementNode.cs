using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GameItemTransformedRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string oldTemplate;

		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string newTemplate;

		public int targetCount;

		protected string CounterKey => null;

		protected string MaxProgressPercentageKey => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnItemTransformed(ActiveStory story)
		{
		}

		private void OnItemProgressChanged(ActiveStory story)
		{
		}

		public override int GetMaxPips(ActiveStory story)
		{
			return 0;
		}

		public override float GetFilledPips(ActiveStory story)
		{
			return 0f;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
